﻿using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.IO;

namespace MBACNationals.ReadModels
{
    public abstract class AzureReadModel
    {
        public class Entity : TableEntity
        {
            public string AzureEntityType { get; set; }
        }

        public class Blob
        {
            public Guid Id { get; set; }
            public byte[] Contents { get; set; }
        }

        private AzureTableHelper.AzureTableHelper AzureTableHelper { get; set; }
        private AzureTableHelper.AzureBlobHelper AzureBlobHelper { get; set; }

        private CloudTable Table
        {
            get
            {
                return AzureTableHelper.GetTableFor(GetType());
            }
        }

        private CloudBlobContainer Container
        {
            get
            {
                return AzureBlobHelper.GetContainerFor(GetType());
            }
        }

        protected AzureReadModel()
        {
            var tableStorageConn = ConfigurationManager.ConnectionStrings["AzureTableStorage"].ConnectionString;
            var storageAccount = CloudStorageAccount.Parse(tableStorageConn);
    
            var servicePoint = ServicePointManager.FindServicePoint(storageAccount.TableEndpoint);
            servicePoint.UseNagleAlgorithm = false;
            servicePoint.Expect100Continue = false;
            servicePoint.ConnectionLimit = 100;

            var tableClient = storageAccount.CreateCloudTableClient();
            AzureTableHelper = new AzureTableHelper.AzureTableHelper(tableClient);

            var blobClient = storageAccount.CreateCloudBlobClient();
            AzureBlobHelper = new AzureTableHelper.AzureBlobHelper(blobClient);
        }

        protected void Create<T>(Guid partition, Guid key, T entity)
            where T : Entity, new()
        {
            entity.PartitionKey = partition.ToString();
            entity.RowKey = key.ToString();
            entity.AzureEntityType = typeof(T).Name;

            
            Table.Execute(TableOperation.InsertOrReplace(entity));
        }

        protected void Create<T>(T blob)
            where T : Blob, new()
        {
            var azureBlobType = typeof(T).Name;
            var key = azureBlobType + blob.Id;
            var blockBlob = Container.GetBlockBlobReference(key);
            
            using (var stream = new MemoryStream(blob.Contents, writable: false))
            {
                blockBlob.UploadFromStream(stream);
            }
        }

        protected T Read<T>(Guid key)
            where T : Entity, new()
        {
            var entity = Query<T>(x => x.RowKey == key.ToString()).FirstOrDefault();
            return entity;
        }

        protected T Read<T>(Guid partition, Guid key)
            where T : Entity, new()
        {            
            var tableResults = Table.Execute(TableOperation.Retrieve<T>(partition.ToString(), key.ToString()));
            var entity = (T)tableResults.Result;
            return entity;
        }

        protected List<T> Query<T>()
            where T : Entity, new()
        {            
            return Table.CreateQuery<T>().Where(x => x.AzureEntityType.Equals(typeof(T).Name)).ToList();
        }

        protected List<T> Query<T>(Func<T, bool> predicate)
            where T : Entity, new()
        {            
            return Table.CreateQuery<T>().Where(x => x.AzureEntityType.Equals(typeof(T).Name)).Where(predicate).ToList();
        }

        protected void Update<T>(Guid partition, Guid key, Action<T> func)
            where T : Entity, new()
        {
            var entity = Read<T>(partition, key);
            func(entity);

            Table.Execute(TableOperation.Replace(entity));
        }

        protected void Update<T>(Guid key, Action<T> func)
            where T : Entity, new()
        {
            var entity = Read<T>(key);
            func(entity);

            Table.Execute(TableOperation.Replace(entity));
        }

        protected void Delete<T>(Guid partition, Guid key)
            where T : Entity, new()
        {
            var entity = Read<T>(partition, key);
            
            Table.Execute(TableOperation.Delete(entity));
        }
    }
}
