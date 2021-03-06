﻿using Edument.CQRS;
using MBACNationals.ReadModels;
using MBACNationals.Scores.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MBACNationals
{
    public static class ScheduleBuilder
    {
        const string year = "2017";

        public static Func<int, string, string, int, string, SaveMatch> MatchBuilder(ICommandQueries commandQueries, string division, BowlingCentre at, bool isPoa)
        {
            var tournament = commandQueries.GetTournaments().Single(x => x.Year == year);
            return (game, away, home, lane, slot) =>
            {
                var match = commandQueries.GetMatch(tournament.Year, division, game, slot)
                    ?? new CommandQueries.Match { Id = Guid.NewGuid() };

                return new SaveMatch(match.Id, tournament.Id, tournament.Year, division, game, away, home, lane, slot, at, isPoa);
            };
        }

        public static void TournamentMenSingle(ICommandQueries commandQueries, MessageDispatcher dispatcher)
        {
            var division = "Tournament Men Single";
            var isPoa = false;
            var game = 0;
            var lane = 0;
            Func<int, string, string, int, string, SaveMatch> build;
            var commands = new List<SaveMatch>();

            build = MatchBuilder(commandQueries, division, BowlingCentre.Nortown, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "SO", "BC", lane = 15, "A"), build(game, "MB", "SK", lane += 2, "B"), build(game, "NO", "NL", lane += 2, "C"), build(game, "QC", "AB", lane += 2, "D"),
                build(++game, "SK", "NL", lane = 15, "A"), build(game, "AB", "BC", lane += 2, "B"), build(game, "SO", "QC", lane += 2, "C"), build(game, "MB", "NO", lane += 2, "D"),
                build(++game, "AB", "NO", lane = 15, "A"), build(game, "NL", "QC", lane += 2, "B"), build(game, "BC", "MB", lane += 2, "C"), build(game, "SK", "SO", lane += 2, "D"),
                build(++game, "MB", "QC", lane = 15, "A"), build(game, "SO", "NO", lane += 2, "B"), build(game, "AB", "SK", lane += 2, "C"), build(game, "BC", "NL", lane += 2, "D"),
                build(++game, "NL", "SO", lane = 15, "A"), build(game, "MB", "AB", lane += 2, "B"), build(game, "NO", "BC", lane += 2, "C"), build(game, "QC", "SK", lane += 2, "D"),
                build(++game, "BC", "QC", lane = 15, "A"), build(game, "NO", "SK", lane += 2, "B"), build(game, "AB", "SO", lane += 2, "C"), build(game, "NL", "MB", lane += 2, "D"),
                build(++game, "SO", "MB", lane = 15, "A"), build(game, "NL", "AB", lane += 2, "B"), build(game, "QC", "NO", lane += 2, "C"), build(game, "SK", "BC", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.GoldenMile, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "AB", "NO", lane = 09, "A"), build(game, "QC", "NL", lane += 2, "B"), build(game, "MB", "BC", lane += 2, "C"), build(game, "SO", "SK", lane += 2, "D"),
                build(++game, "BC", "SO", lane = 09, "A"), build(game, "SK", "MB", lane += 2, "B"), build(game, "NL", "NO", lane += 2, "C"), build(game, "AB", "QC", lane += 2, "D"),
                build(++game, "NL", "SK", lane = 09, "A"), build(game, "BC", "AB", lane += 2, "B"), build(game, "QC", "SO", lane += 2, "C"), build(game, "NO", "MB", lane += 2, "D"),
                build(++game, "QC", "MB", lane = 09, "A"), build(game, "NO", "SO", lane += 2, "B"), build(game, "AB", "SK", lane += 2, "C"), build(game, "BC", "NL", lane += 2, "D"),
                build(++game, "SK", "BC", lane = 09, "A"), build(game, "AB", "NL", lane += 2, "B"), build(game, "NO", "QC", lane += 2, "C"), build(game, "MB", "SO", lane += 2, "D"),
                build(++game, "SO", "NL", lane = 09, "A"), build(game, "SK", "QC", lane += 2, "B"), build(game, "MB", "AB", lane += 2, "C"), build(game, "BC", "NO", lane += 2, "D"),
                build(++game, "NO", "SK", lane = 09, "A"), build(game, "NL", "MB", lane += 2, "B"), build(game, "QC", "BC", lane += 2, "C"), build(game, "SO", "AB", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Glencairn, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "QC", "MB", lane = 01, "A"), build(game, "NO", "SO", lane += 2, "B"), build(game, "SK", "AB", lane += 2, "C"), build(game, "NL", "BC", lane += 2, "D"),
                build(++game, "NO", "AB", lane = 01, "A"), build(game, "NL", "QC", lane += 2, "B"), build(game, "MB", "BC", lane += 2, "C"), build(game, "SO", "SK", lane += 2, "D"),
                build(++game, "NL", "SK", lane = 01, "A"), build(game, "AB", "BC", lane += 2, "B"), build(game, "SO", "QC", lane += 2, "C"), build(game, "MB", "NO", lane += 2, "D"),
                build(++game, "BC", "SO", lane = 01, "A"), build(game, "SK", "MB", lane += 2, "B"), build(game, "NO", "NL", lane += 2, "C"), build(game, "QC", "AB", lane += 2, "D"),
                build(++game, "MB", "NL", lane = 01, "A"), build(game, "SO", "AB", lane += 2, "B"), build(game, "BC", "QC", lane += 2, "C"), build(game, "SK", "NO", lane += 2, "D"),
                build(++game, "SK", "QC", lane = 01, "A"), build(game, "NO", "BC", lane += 2, "B"), build(game, "NL", "SO", lane += 2, "C"), build(game, "AB", "MB", lane += 2, "D"),
                build(++game, "SO", "MB", lane = 01, "A"), build(game, "AB", "NL", lane += 2, "B"), build(game, "QC", "NO", lane += 2, "C"), build(game, "BC", "SK", lane += 2, "D"),
            });

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }

        public static void TournamentLadiesSingle(ICommandQueries commandQueries, MessageDispatcher dispatcher)
        {
            var division = "Tournament Ladies Single";
            var isPoa = false;
            var game = 0;
            var lane = 0;
            Func<int, string, string, int, string, SaveMatch> build;
            var commands = new List<SaveMatch>();

            build = MatchBuilder(commandQueries, division, BowlingCentre.Nortown, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "SO", "BC", lane = 15, "A"), build(game, "MB", "SK", lane += 2, "B"), build(game, "NO", "NL", lane += 2, "C"), build(game, "QC", "AB", lane += 2, "D"),
                build(++game, "SK", "NL", lane = 15, "A"), build(game, "AB", "BC", lane += 2, "B"), build(game, "SO", "QC", lane += 2, "C"), build(game, "MB", "NO", lane += 2, "D"),
                build(++game, "AB", "NO", lane = 15, "A"), build(game, "NL", "QC", lane += 2, "B"), build(game, "BC", "MB", lane += 2, "C"), build(game, "SK", "SO", lane += 2, "D"),
                build(++game, "MB", "QC", lane = 15, "A"), build(game, "SO", "NO", lane += 2, "B"), build(game, "AB", "SK", lane += 2, "C"), build(game, "BC", "NL", lane += 2, "D"),
                build(++game, "NL", "SO", lane = 15, "A"), build(game, "MB", "AB", lane += 2, "B"), build(game, "NO", "BC", lane += 2, "C"), build(game, "QC", "SK", lane += 2, "D"),
                build(++game, "BC", "QC", lane = 15, "A"), build(game, "NO", "SK", lane += 2, "B"), build(game, "AB", "SO", lane += 2, "C"), build(game, "NL", "MB", lane += 2, "D"),
                build(++game, "SO", "MB", lane = 15, "A"), build(game, "NL", "AB", lane += 2, "B"), build(game, "QC", "NO", lane += 2, "C"), build(game, "SK", "BC", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.GoldenMile, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "AB", "NO", lane = 09, "A"), build(game, "QC", "NL", lane += 2, "B"), build(game, "MB", "BC", lane += 2, "C"), build(game, "SO", "SK", lane += 2, "D"),
                build(++game, "BC", "SO", lane = 09, "A"), build(game, "SK", "MB", lane += 2, "B"), build(game, "NL", "NO", lane += 2, "C"), build(game, "AB", "QC", lane += 2, "D"),
                build(++game, "NL", "SK", lane = 09, "A"), build(game, "BC", "AB", lane += 2, "B"), build(game, "QC", "SO", lane += 2, "C"), build(game, "NO", "MB", lane += 2, "D"),
                build(++game, "QC", "MB", lane = 09, "A"), build(game, "NO", "SO", lane += 2, "B"), build(game, "AB", "SK", lane += 2, "C"), build(game, "BC", "NL", lane += 2, "D"),
                build(++game, "SK", "BC", lane = 09, "A"), build(game, "AB", "NL", lane += 2, "B"), build(game, "NO", "QC", lane += 2, "C"), build(game, "MB", "SO", lane += 2, "D"),
                build(++game, "SO", "NL", lane = 09, "A"), build(game, "SK", "QC", lane += 2, "B"), build(game, "MB", "AB", lane += 2, "C"), build(game, "BC", "NO", lane += 2, "D"),
                build(++game, "NO", "SK", lane = 09, "A"), build(game, "NL", "MB", lane += 2, "B"), build(game, "QC", "BC", lane += 2, "C"), build(game, "SO", "AB", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Glencairn, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "QC", "MB", lane = 01, "A"), build(game, "NO", "SO", lane += 2, "B"), build(game, "SK", "AB", lane += 2, "C"), build(game, "NL", "BC", lane += 2, "D"),
                build(++game, "NO", "AB", lane = 01, "A"), build(game, "NL", "QC", lane += 2, "B"), build(game, "MB", "BC", lane += 2, "C"), build(game, "SO", "SK", lane += 2, "D"),
                build(++game, "NL", "SK", lane = 01, "A"), build(game, "AB", "BC", lane += 2, "B"), build(game, "SO", "QC", lane += 2, "C"), build(game, "MB", "NO", lane += 2, "D"),
                build(++game, "BC", "SO", lane = 01, "A"), build(game, "SK", "MB", lane += 2, "B"), build(game, "NO", "NL", lane += 2, "C"), build(game, "QC", "AB", lane += 2, "D"),
                build(++game, "MB", "NL", lane = 01, "A"), build(game, "SO", "AB", lane += 2, "B"), build(game, "BC", "QC", lane += 2, "C"), build(game, "SK", "NO", lane += 2, "D"),
                build(++game, "SK", "QC", lane = 01, "A"), build(game, "NO", "BC", lane += 2, "B"), build(game, "NL", "SO", lane += 2, "C"), build(game, "AB", "MB", lane += 2, "D"),
                build(++game, "SO", "MB", lane = 01, "A"), build(game, "AB", "NL", lane += 2, "B"), build(game, "QC", "NO", lane += 2, "C"), build(game, "BC", "SK", lane += 2, "D"),
            });

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }

        public static void TournamentMen(ICommandQueries commandQueries, MessageDispatcher dispatcher)
        {
            var division = "Tournament Men";
            var isPoa = false;
            var game = 0;
            var lane = 0;
            Func<int, string, string, int, string, SaveMatch> build;
            var commands = new List<SaveMatch>();

            build = MatchBuilder(commandQueries, division, BowlingCentre.GoldenMile, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "QC", "SK", lane = 01, "A"), build(game, "NL", "MB", lane += 2, "B"), build(game, "AB", "SO", lane += 2, "C"), build(game, "BC", "NO", lane += 2, "D"),
                build(++game, "SO", "NL", lane = 01, "A"), build(game, "SK", "NO", lane += 2, "B"), build(game, "QC", "BC", lane += 2, "C"), build(game, "MB", "AB", lane += 2, "D"),
                build(++game, "NO", "AB", lane = 01, "A"), build(game, "BC", "SO", lane += 2, "B"), build(game, "SK", "MB", lane += 2, "C"), build(game, "NL", "QC", lane += 2, "D"),
                build(++game, "MB", "BC", lane = 01, "A"), build(game, "AB", "QC", lane += 2, "B"), build(game, "NO", "NL", lane += 2, "C"), build(game, "SO", "SK", lane += 2, "D"),
                build(++game, "SO", "QC", lane = 09, "A"), build(game, "NO", "MB", lane += 2, "B"), build(game, "AB", "SK", lane += 2, "C"), build(game, "BC", "NL", lane += 2, "D"),
                build(++game, "SK", "BC", lane = 09, "A"), build(game, "NL", "AB", lane += 2, "B"), build(game, "MB", "SO", lane += 2, "C"), build(game, "QC", "NO", lane += 2, "D"),
                build(++game, "QC", "MB", lane = 09, "A"), build(game, "SO", "NO", lane += 2, "B"), build(game, "BC", "AB", lane += 2, "C"), build(game, "NL", "SK", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Nortown, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "SO", "BC", lane = 03, "A"), build(game, "MB", "SK", lane += 2, "B"), build(game, "QC", "NL", lane += 2, "C"), build(game, "AB", "NO", lane += 2, "D"),
                build(++game, "MB", "NL", lane = 03, "A"), build(game, "AB", "SO", lane += 2, "B"), build(game, "NO", "BC", lane += 2, "C"), build(game, "SK", "QC", lane += 2, "D"),
                build(++game, "QC", "AB", lane = 03, "A"), build(game, "NL", "NO", lane += 2, "B"), build(game, "SK", "SO", lane += 2, "C"), build(game, "MB", "BC", lane += 2, "D"),
                build(++game, "NO", "SK", lane = 03, "A"), build(game, "BC", "QC", lane += 2, "B"), build(game, "AB", "MB", lane += 2, "C"), build(game, "NL", "SO", lane += 2, "D"),
                build(++game, "NL", "AB", lane = 03, "A"), build(game, "SO", "MB", lane += 2, "B"), build(game, "BC", "SK", lane += 2, "C"), build(game, "NO", "QC", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Glencairn, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "QC", "SO", lane = 09, "A"), build(game, "NL", "BC", lane += 2, "B"), build(game, "MB", "NO", lane += 2, "C"), build(game, "SK", "AB", lane += 2, "D"),
                build(++game, "SK", "NL", lane = 09, "A"), build(game, "QC", "MB", lane += 2, "B"), build(game, "AB", "BC", lane += 2, "C"), build(game, "NO", "SO", lane += 2, "D"),
                build(++game, "AB", "QC", lane = 09, "A"), build(game, "NL", "NO", lane += 2, "B"), build(game, "SO", "SK", lane += 2, "C"), build(game, "BC", "MB", lane += 2, "D"),
                build(++game, "BC", "SO", lane = 09, "A"), build(game, "MB", "SK", lane += 2, "B"), build(game, "NL", "QC", lane += 2, "C"), build(game, "NO", "AB", lane += 2, "D"),
                build(++game, "NO", "SK", lane = 09, "A"), build(game, "QC", "BC", lane += 2, "B"), build(game, "AB", "MB", lane += 2, "C"), build(game, "SO", "NL", lane += 2, "D"),
                build(++game, "MB", "NL", lane = 09, "A"), build(game, "SO", "AB", lane += 2, "B"), build(game, "BC", "NO", lane += 2, "C"), build(game, "SK", "QC", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.GoldenMile, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "SO", "QC", lane = 01, "A"), build(game, "NO", "MB", lane += 2, "B"), build(game, "AB", "SK", lane += 2, "C"), build(game, "BC", "NL", lane += 2, "D"),
                build(++game, "SO", "NO", lane = 09, "A"), build(game, "MB", "QC", lane += 2, "B"), build(game, "NL", "SK", lane += 2, "C"), build(game, "BC", "AB", lane += 2, "D"),
                build(++game, "AB", "NL", lane = 09, "A"), build(game, "SK", "BC", lane += 2, "B"), build(game, "QC", "NO", lane += 2, "C"), build(game, "MB", "SO", lane += 2, "D"),
            });

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }

        public static void TournamentLadies(ICommandQueries commandQueries, MessageDispatcher dispatcher)
        {
            var division = "Tournament Ladies";
            var isPoa = false;
            var game = 0;
            var lane = 0;
            Func<int, string, string, int, string, SaveMatch> build;
            var commands = new List<SaveMatch>();

            build = MatchBuilder(commandQueries, division, BowlingCentre.GoldenMile, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "SK", "QC", lane = 09, "A"), build(game, "MB", "NL", lane += 2, "B"), build(game, "SO", "AB", lane += 2, "C"), build(game, "NO", "BC", lane += 2, "D"),
                build(++game, "NL", "SO", lane = 09, "A"), build(game, "NO", "SK", lane += 2, "B"), build(game, "BC", "QC", lane += 2, "C"), build(game, "AB", "MB", lane += 2, "D"),
                build(++game, "AB", "NO", lane = 09, "A"), build(game, "SO", "BC", lane += 2, "B"), build(game, "MB", "SK", lane += 2, "C"), build(game, "QC", "NL", lane += 2, "D"),
                build(++game, "BC", "MB", lane = 09, "A"), build(game, "QC", "AB", lane += 2, "B"), build(game, "NL", "NO", lane += 2, "C"), build(game, "SK", "SO", lane += 2, "D"),
                build(++game, "QC", "SO", lane = 01, "A"), build(game, "MB", "NO", lane += 2, "B"), build(game, "SK", "AB", lane += 2, "C"), build(game, "NL", "BC", lane += 2, "D"),
                build(++game, "BC", "SK", lane = 01, "A"), build(game, "AB", "NL", lane += 2, "B"), build(game, "SO", "MB", lane += 2, "C"), build(game, "NO", "QC", lane += 2, "D"),
                build(++game, "MB", "QC", lane = 01, "A"), build(game, "NO", "SO", lane += 2, "B"), build(game, "AB", "BC", lane += 2, "C"), build(game, "SK", "NL", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Glencairn, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "BC", "SO", lane = 01, "A"), build(game, "SK", "MB", lane += 2, "B"), build(game, "NL", "QC", lane += 2, "C"), build(game, "NO", "AB", lane += 2, "D"),
                build(++game, "NL", "MB", lane = 01, "A"), build(game, "SO", "AB", lane += 2, "B"), build(game, "BC", "NO", lane += 2, "C"), build(game, "QC", "SK", lane += 2, "D"),
                build(++game, "AB", "QC", lane = 01, "A"), build(game, "NO", "NL", lane += 2, "B"), build(game, "SO", "SK", lane += 2, "C"), build(game, "BC", "MB", lane += 2, "D"),
                build(++game, "SK", "NO", lane = 01, "A"), build(game, "QC", "BC", lane += 2, "B"), build(game, "MB", "AB", lane += 2, "C"), build(game, "SO", "NL", lane += 2, "D"),
                build(++game, "AB", "NL", lane = 01, "A"), build(game, "MB", "SO", lane += 2, "B"), build(game, "SK", "BC", lane += 2, "C"), build(game, "QC", "NO", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Nortown, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "SO", "QC", lane = 03, "A"), build(game, "BC", "NL", lane += 2, "B"), build(game, "NO", "MB", lane += 2, "C"), build(game, "AB", "SK", lane += 2, "D"),
                build(++game, "NL", "SK", lane = 03, "A"), build(game, "MB", "QC", lane += 2, "B"), build(game, "BC", "AB", lane += 2, "C"), build(game, "SO", "NO", lane += 2, "D"),
                build(++game, "QC", "AB", lane = 03, "A"), build(game, "NO", "NL", lane += 2, "B"), build(game, "SK", "SO", lane += 2, "C"), build(game, "MB", "BC", lane += 2, "D"),
                build(++game, "SO", "BC", lane = 03, "A"), build(game, "SK", "MB", lane += 2, "B"), build(game, "QC", "NL", lane += 2, "C"), build(game, "AB", "NO", lane += 2, "D"),
                build(++game, "SK", "NO", lane = 03, "A"), build(game, "BC", "QC", lane += 2, "B"), build(game, "MB", "AB", lane += 2, "C"), build(game, "NL", "SO", lane += 2, "D"),
                build(++game, "NL", "MB", lane = 03, "A"), build(game, "AB", "SO", lane += 2, "B"), build(game, "NO", "BC", lane += 2, "C"), build(game, "QC", "SK", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.GoldenMile, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "QC", "SO", lane = 09, "A"), build(game, "MB", "NO", lane += 2, "B"), build(game, "SK", "AB", lane += 2, "C"), build(game, "NL", "BC", lane += 2, "D"),
                build(++game, "NO", "SO", lane = 01, "A"), build(game, "QC", "MB", lane += 2, "B"), build(game, "SK", "NL", lane += 2, "C"), build(game, "AB", "BC", lane += 2, "D"),
                build(++game, "NL", "AB", lane = 01, "A"), build(game, "BC", "SK", lane += 2, "B"), build(game, "NO", "QC", lane += 2, "C"), build(game, "SO", "MB", lane += 2, "D"),
            });

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }

        public static void TeachingMen(ICommandQueries commandQueries, MessageDispatcher dispatcher)
        {
            var division = "Teaching Men";
            var isPoa = true;
            var game = 0;
            var lane = 0;
            Func<int, string, string, int, string, SaveMatch> build;
            var commands = new List<SaveMatch>();

            build = MatchBuilder(commandQueries, division, BowlingCentre.Glencairn, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "MB", "NL", lane = 09, "A"), build(game, "QC", "AB", lane += 2, "B"), build(game, "NO", "BC", lane += 2, "C"), build(game, "SK", "SO", lane += 2, "D"),
                build(++game, "BC", "SK", lane = 09, "A"), build(game, "SO", "NO", lane += 2, "B"), build(game, "NL", "QC", lane += 2, "C"), build(game, "AB", "MB", lane += 2, "D"),
                build(++game, "QC", "MB", lane = 09, "A"), build(game, "NL", "AB", lane += 2, "B"), build(game, "SK", "NO", lane += 2, "C"), build(game, "SO", "BC", lane += 2, "D"),
                build(++game, "MB", "BC", lane = 09, "A"), build(game, "AB", "SK", lane += 2, "B"), build(game, "QC", "SO", lane += 2, "C"), build(game, "NO", "NL", lane += 2, "D"),
                build(++game, "NL", "SO", lane = 09, "A"), build(game, "NO", "QC", lane += 2, "B"), build(game, "BC", "AB", lane += 2, "C"), build(game, "SK", "MB", lane += 2, "D"),
                build(++game, "SK", "QC", lane = 09, "A"), build(game, "BC", "NL", lane += 2, "B"), build(game, "MB", "NO", lane += 2, "C"), build(game, "SO", "AB", lane += 2, "D"),
                build(++game, "AB", "NO", lane = 09, "A"), build(game, "SO", "MB", lane += 2, "B"), build(game, "NL", "SK", lane += 2, "C"), build(game, "QC", "BC", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.GoldenMile, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "MB", "AB", lane = 01, "A"), build(game, "QC", "NL", lane += 2, "B"), build(game, "SK", "BC", lane += 2, "C"), build(game, "NO", "SO", lane += 2, "D"),
                build(++game, "NL", "SO", lane = 01, "A"), build(game, "MB", "SK", lane += 2, "B"), build(game, "QC", "NO", lane += 2, "C"), build(game, "AB", "BC", lane += 2, "D"),
                build(++game, "BC", "QC", lane = 01, "A"), build(game, "NO", "AB", lane += 2, "B"), build(game, "MB", "SO", lane += 2, "C"), build(game, "SK", "NL", lane += 2, "D"),
                build(++game, "SO", "QC", lane = 01, "A"), build(game, "BC", "MB", lane += 2, "B"), build(game, "NO", "NL", lane += 2, "C"), build(game, "AB", "SK", lane += 2, "D"),
                build(++game, "BC", "NO", lane = 01, "A"), build(game, "SO", "SK", lane += 2, "B"), build(game, "AB", "QC", lane += 2, "C"), build(game, "NL", "MB", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Nortown, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "AB", "SO", lane = 15, "A"), build(game, "NO", "MB", lane += 2, "B"), build(game, "QC", "SK", lane += 2, "C"), build(game, "NL", "BC", lane += 2, "D"),
                build(++game, "MB", "QC", lane = 15, "A"), build(game, "AB", "NL", lane += 2, "B"), build(game, "BC", "SO", lane += 2, "C"), build(game, "NO", "SK", lane += 2, "D"),
                build(++game, "NL", "SK", lane = 15, "A"), build(game, "BC", "QC", lane += 2, "B"), build(game, "AB", "NO", lane += 2, "C"), build(game, "SO", "MB", lane += 2, "D"),
                build(++game, "NO", "BC", lane = 15, "A"), build(game, "SK", "SO", lane += 2, "B"), build(game, "MB", "NL", lane += 2, "C"), build(game, "QC", "AB", lane += 2, "D"),
                build(++game, "SO", "NL", lane = 15, "A"), build(game, "QC", "NO", lane += 2, "B"), build(game, "BC", "AB", lane += 2, "C"), build(game, "SK", "MB", lane += 2, "D"),
                build(++game, "SK", "AB", lane = 15, "A"), build(game, "MB", "BC", lane += 2, "B"), build(game, "SO", "QC", lane += 2, "C"), build(game, "NL", "NO", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Nortown, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "NL", "QC", lane = 03, "A"), build(game, "NO", "SO", lane += 2, "B"), build(game, "AB", "MB", lane += 2, "C"), build(game, "BC", "SK", lane += 2, "D"),
                build(++game, "SO", "BC", lane = 03, "A"), build(game, "NL", "AB", lane += 2, "B"), build(game, "SK", "NO", lane += 2, "C"), build(game, "QC", "MB", lane += 2, "D"),
                build(++game, "MB", "NO", lane = 03, "A"), build(game, "SK", "QC", lane += 2, "B"), build(game, "BC", "NL", lane += 2, "C"), build(game, "SO", "AB", lane += 2, "D"),
            });

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }

        public static void TeachingLadies(ICommandQueries commandQueries, MessageDispatcher dispatcher)
        {
            var division = "Teaching Ladies";
            var isPoa = true;
            var game = 0;
            var lane = 0;
            Func<int, string, string, int, string, SaveMatch> build;
            var commands = new List<SaveMatch>();

            build = MatchBuilder(commandQueries, division, BowlingCentre.Glencairn, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "BC", "MB", lane = 01, "A"), build(game, "SK", "AB", lane += 2, "B"), build(game, "SO", "QC", lane += 2, "C"), build(game, "NL", "NO", lane += 2, "D"),
                build(++game, "SO", "NL", lane = 01, "A"), build(game, "QC", "NO", lane += 2, "B"), build(game, "AB", "BC", lane += 2, "C"), build(game, "MB", "SK", lane += 2, "D"),
                build(++game, "QC", "SK", lane = 01, "A"), build(game, "NL", "BC", lane += 2, "B"), build(game, "NO", "MB", lane += 2, "C"), build(game, "AB", "SO", lane += 2, "D"),
                build(++game, "NO", "AB", lane = 01, "A"), build(game, "MB", "SO", lane += 2, "B"), build(game, "SK", "NL", lane += 2, "C"), build(game, "BC", "QC", lane += 2, "D"),
                build(++game, "NL", "MB", lane = 01, "A"), build(game, "AB", "QC", lane += 2, "B"), build(game, "BC", "NO", lane += 2, "C"), build(game, "SO", "SK", lane += 2, "D"),
                build(++game, "SK", "BC", lane = 01, "A"), build(game, "NO", "SO", lane += 2, "B"), build(game, "QC", "NL", lane += 2, "C"), build(game, "MB", "AB", lane += 2, "D"),
                build(++game, "MB", "QC", lane = 01, "A"), build(game, "AB", "NL", lane += 2, "B"), build(game, "NO", "SK", lane += 2, "C"), build(game, "BC", "SO", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Glencairn, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "QC", "BC", lane = 09, "A"), build(game, "AB", "NO", lane += 2, "B"), build(game, "SO", "MB", lane += 2, "C"), build(game, "NL", "SK", lane += 2, "D"),
                build(++game, "SO", "NL", lane = 09, "A"), build(game, "SK", "MB", lane += 2, "B"), build(game, "NO", "QC", lane += 2, "C"), build(game, "BC", "AB", lane += 2, "D"),
                build(++game, "AB", "MB", lane = 09, "A"), build(game, "NL", "QC", lane += 2, "B"), build(game, "BC", "SK", lane += 2, "C"), build(game, "SO", "NO", lane += 2, "D"),
                build(++game, "QC", "SO", lane = 09, "A"), build(game, "MB", "BC", lane += 2, "B"), build(game, "NL", "NO", lane += 2, "C"), build(game, "SK", "AB", lane += 2, "D"),
                build(++game, "NO", "BC", lane = 09, "A"), build(game, "SK", "SO", lane += 2, "B"), build(game, "QC", "AB", lane += 2, "C"), build(game, "MB", "NL", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.GoldenMile, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "SO", "AB", lane = 09, "A"), build(game, "MB", "NO", lane += 2, "B"), build(game, "SK", "QC", lane += 2, "C"), build(game, "BC", "NL", lane += 2, "D"),
                build(++game, "QC", "MB", lane = 09, "A"), build(game, "NL", "AB", lane += 2, "B"), build(game, "SO", "BC", lane += 2, "C"), build(game, "SK", "NO", lane += 2, "D"),
                build(++game, "SK", "NL", lane = 09, "A"), build(game, "QC", "BC", lane += 2, "B"), build(game, "NO", "AB", lane += 2, "C"), build(game, "MB", "SO", lane += 2, "D"),
                build(++game, "BC", "NO", lane = 09, "A"), build(game, "SO", "SK", lane += 2, "B"), build(game, "NL", "MB", lane += 2, "C"), build(game, "AB", "QC", lane += 2, "D"),
                build(++game, "NL", "SO", lane = 09, "A"), build(game, "NO", "QC", lane += 2, "B"), build(game, "AB", "BC", lane += 2, "C"), build(game, "MB", "SK", lane += 2, "D"),
                build(++game, "AB", "SK", lane = 09, "A"), build(game, "BC", "MB", lane += 2, "B"), build(game, "QC", "SO", lane += 2, "C"), build(game, "NO", "NL", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Nortown, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "QC", "NL", lane = 15, "A"), build(game, "SO", "NO", lane += 2, "B"), build(game, "MB", "AB", lane += 2, "C"), build(game, "SK", "BC", lane += 2, "D"),
                build(++game, "BC", "SO", lane = 15, "A"), build(game, "AB", "NL", lane += 2, "B"), build(game, "NO", "SK", lane += 2, "C"), build(game, "MB", "QC", lane += 2, "D"),
                build(++game, "NO", "MB", lane = 15, "A"), build(game, "QC", "SK", lane += 2, "B"), build(game, "NL", "BC", lane += 2, "C"), build(game, "AB", "SO", lane += 2, "D"),
            });

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }

        public static void Seniors(ICommandQueries commandQueries, MessageDispatcher dispatcher)
        {
            var division = "Seniors";
            var isPoa = true;
            var game = 0;
            var lane = 0;
            Func<int, string, string, int, string, SaveMatch> build;
            var commands = new List<SaveMatch>();

            build = MatchBuilder(commandQueries, division, BowlingCentre.Nortown, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "BC", "MB", lane = 03, "A"), build(game, "SK", "AB", lane += 2, "B"), build(game, "SO", "QC", lane += 2, "C"), build(game, "NL", "NO", lane += 2, "D"),
                build(++game, "SO", "NL", lane = 03, "A"), build(game, "QC", "NO", lane += 2, "B"), build(game, "AB", "BC", lane += 2, "C"), build(game, "MB", "SK", lane += 2, "D"),
                build(++game, "QC", "SK", lane = 03, "A"), build(game, "NL", "BC", lane += 2, "B"), build(game, "NO", "MB", lane += 2, "C"), build(game, "AB", "SO", lane += 2, "D"),
                build(++game, "NO", "AB", lane = 03, "A"), build(game, "MB", "SO", lane += 2, "B"), build(game, "SK", "NL", lane += 2, "C"), build(game, "BC", "QC", lane += 2, "D"),
                build(++game, "NL", "MB", lane = 03, "A"), build(game, "AB", "QC", lane += 2, "B"), build(game, "BC", "NO", lane += 2, "C"), build(game, "SO", "SK", lane += 2, "D"),
                build(++game, "SK", "BC", lane = 03, "A"), build(game, "NO", "SO", lane += 2, "B"), build(game, "QC", "NL", lane += 2, "C"), build(game, "MB", "AB", lane += 2, "D"),
                build(++game, "MB", "QC", lane = 03, "A"), build(game, "AB", "NL", lane += 2, "B"), build(game, "NO", "SK", lane += 2, "C"), build(game, "BC", "SO", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Nortown, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "QC", "BC", lane = 15, "A"), build(game, "AB", "NO", lane += 2, "B"), build(game, "SO", "MB", lane += 2, "C"), build(game, "NL", "SK", lane += 2, "D"),
                build(++game, "SO", "NL", lane = 15, "A"), build(game, "SK", "MB", lane += 2, "B"), build(game, "NO", "QC", lane += 2, "C"), build(game, "BC", "AB", lane += 2, "D"),
                build(++game, "AB", "MB", lane = 15, "A"), build(game, "NL", "QC", lane += 2, "B"), build(game, "BC", "SK", lane += 2, "C"), build(game, "SO", "NO", lane += 2, "D"),
                build(++game, "QC", "SO", lane = 15, "A"), build(game, "MB", "BC", lane += 2, "B"), build(game, "NL", "NO", lane += 2, "C"), build(game, "SK", "AB", lane += 2, "D"),
                build(++game, "NO", "BC", lane = 15, "A"), build(game, "SK", "SO", lane += 2, "B"), build(game, "QC", "AB", lane += 2, "C"), build(game, "MB", "NL", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.GoldenMile, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "SO", "AB", lane = 01, "A"), build(game, "MB", "NO", lane += 2, "B"), build(game, "SK", "QC", lane += 2, "C"), build(game, "BC", "NL", lane += 2, "D"),
                build(++game, "QC", "MB", lane = 01, "A"), build(game, "NL", "AB", lane += 2, "B"), build(game, "SO", "BC", lane += 2, "C"), build(game, "SK", "NO", lane += 2, "D"),
                build(++game, "SK", "NL", lane = 01, "A"), build(game, "QC", "BC", lane += 2, "B"), build(game, "NO", "AB", lane += 2, "C"), build(game, "MB", "SO", lane += 2, "D"),
                build(++game, "BC", "NO", lane = 01, "A"), build(game, "SO", "SK", lane += 2, "B"), build(game, "NL", "MB", lane += 2, "C"), build(game, "AB", "QC", lane += 2, "D"),
                build(++game, "NL", "SO", lane = 01, "A"), build(game, "NO", "QC", lane += 2, "B"), build(game, "AB", "BC", lane += 2, "C"), build(game, "MB", "SK", lane += 2, "D"),
                build(++game, "AB", "SK", lane = 01, "A"), build(game, "BC", "MB", lane += 2, "B"), build(game, "QC", "SO", lane += 2, "C"), build(game, "NO", "NL", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Glencairn, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "QC", "NL", lane = 01, "A"), build(game, "SO", "NO", lane += 2, "B"), build(game, "MB", "AB", lane += 2, "C"), build(game, "SK", "BC", lane += 2, "D"),
                build(++game, "BC", "SO", lane = 01, "A"), build(game, "AB", "NL", lane += 2, "B"), build(game, "NO", "SK", lane += 2, "C"), build(game, "MB", "QC", lane += 2, "D"),
                build(++game, "NO", "MB", lane = 01, "A"), build(game, "QC", "SK", lane += 2, "B"), build(game, "NL", "BC", lane += 2, "C"), build(game, "AB", "SO", lane += 2, "D"),
            });

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }
    }

    /*
    public static class ScheduleBuilder
    {
        const string year = "2016";

        public static Func<int, string, string, int, string, SaveMatch> MatchBuilder(ICommandQueries commandQueries, string division, BowlingCentre at, bool isPoa)
        {
            var tournament = commandQueries.GetTournaments().Single(x => x.Year == year);
            return (game, away, home, lane, slot) => 
            {
                var match = commandQueries.GetMatch(tournament.Year, division, game, slot)
                    ?? new CommandQueries.Match { Id = Guid.NewGuid() };

                return new SaveMatch(match.Id, tournament.Id, tournament.Year, division, game, away, home, lane, slot, at, isPoa);
            };
        }
        
        public static void TournamentMenSingle(ICommandQueries commandQueries, MessageDispatcher dispatcher)
        {
            var division = "Tournament Men Single";
            var isPoa = false;
            var game = 0;
            var lane = 0;
            Func<int, string, string, int, string, SaveMatch> build;
            var commands = new List<SaveMatch>();

            build = MatchBuilder(commandQueries, division, BowlingCentre.Scottsdale, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "SO", "MB", lane = 17, "A"), build(game, "QC", "AB", lane += 2, "B"), build(game, "NO", "BC", lane += 2, "C"), build(game, "SK", "NL", lane += 2, "D"),
                build(++game, "BC", "QC", lane = 17, "A"), build(game, "NL", "SO", lane += 2, "B"), build(game, "MB", "SK", lane += 2, "C"), build(game, "AB", "NO", lane += 2, "D"),
                build(++game, "NL", "NO", lane = 17, "A"), build(game, "SK", "BC", lane += 2, "B"), build(game, "AB", "SO", lane += 2, "C"), build(game, "QC", "MB", lane += 2, "D"),
                build(++game, "AB", "SK", lane = 17, "A"), build(game, "NO", "MB", lane += 2, "B"), build(game, "QC", "NL", lane += 2, "C"), build(game, "SO", "BC", lane += 2, "D"),
                build(++game, "MB", "BC", lane = 17, "A"), build(game, "AB", "NL", lane += 2, "B"), build(game, "SO", "NO", lane += 2, "C"), build(game, "QC", "SK", lane += 2, "D"),
                build(++game, "SK", "SO", lane = 17, "A"), build(game, "NO", "QC", lane += 2, "B"), build(game, "NL", "MB", lane += 2, "C"), build(game, "BC", "AB", lane += 2, "D"),
                build(++game, "AB", "MB", lane = 17, "A"), build(game, "NL", "BC", lane += 2, "B"), build(game, "NO", "SK", lane += 2, "C"), build(game, "SO", "QC", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Cloverdale, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "NO", "NL", lane = 03, "A"), build(game, "BC", "SK", lane += 2, "B"), build(game, "SO", "AB", lane += 2, "C"), build(game, "MB", "QC", lane += 2, "D"),
                build(++game, "MB", "SO", lane = 03, "A"), build(game, "AB", "QC", lane += 2, "B"), build(game, "BC", "NO", lane += 2, "C"), build(game, "NL", "SK", lane += 2, "D"),
                build(++game, "QC", "BC", lane = 03, "A"), build(game, "SO", "NL", lane += 2, "B"), build(game, "SK", "MB", lane += 2, "C"), build(game, "NO", "AB", lane += 2, "D"),
                build(++game, "SK", "AB", lane = 03, "A"), build(game, "MB", "NO", lane += 2, "B"), build(game, "NL", "QC", lane += 2, "C"), build(game, "BC", "SO", lane += 2, "D"),
                build(++game, "QC", "SO", lane = 03, "A"), build(game, "NL", "BC", lane += 2, "B"), build(game, "NO", "SK", lane += 2, "C"), build(game, "AB", "MB", lane += 2, "D"),
                build(++game, "MB", "BC", lane = 03, "A"), build(game, "QC", "SK", lane += 2, "B"), build(game, "AB", "NL", lane += 2, "C"), build(game, "SO", "NO", lane += 2, "D"),
                build(++game, "NO", "QC", lane = 03, "A"), build(game, "BC", "AB", lane += 2, "B"), build(game, "SK", "SO", lane += 2, "C"), build(game, "MB", "NL", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Willowbrook, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "AB", "SK", lane = 13, "A"), build(game, "NO", "MB", lane += 2, "B"), build(game, "QC", "NL", lane += 2, "C"), build(game, "SO", "BC", lane += 2, "D"),
                build(++game, "NL", "NO", lane = 13, "A"), build(game, "SK", "BC", lane += 2, "B"), build(game, "AB", "SO", lane += 2, "C"), build(game, "QC", "MB", lane += 2, "D"),
                build(++game, "BC", "QC", lane = 13, "A"), build(game, "NL", "SO", lane += 2, "B"), build(game, "MB", "SK", lane += 2, "C"), build(game, "AB", "NO", lane += 2, "D"),
                build(++game, "SO", "MB", lane = 13, "A"), build(game, "QC", "AB", lane += 2, "B"), build(game, "NO", "BC", lane += 2, "C"), build(game, "SK", "NL", lane += 2, "D"),
                build(++game, "AB", "BC", lane = 13, "A"), build(game, "MB", "NL", lane += 2, "B"), build(game, "SO", "SK", lane += 2, "C"), build(game, "QC", "NO", lane += 2, "D"),
                build(++game, "SK", "QC", lane = 13, "A"), build(game, "NO", "SO", lane += 2, "B"), build(game, "BC", "MB", lane += 2, "C"), build(game, "NL", "AB", lane += 2, "D"),
                build(++game, "MB", "AB", lane = 13, "A"), build(game, "NL", "BC", lane += 2, "B"), build(game, "SK", "NO", lane += 2, "C"), build(game, "SO", "QC", lane += 2, "D"),
            });

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }

        public static void TournamentLadiesSingle(ICommandQueries commandQueries, MessageDispatcher dispatcher)
        {
            var division = "Tournament Ladies Single";
            var isPoa = false;
            var game = 0;
            var lane = 0;
            Func<int, string, string, int, string, SaveMatch> build;
            var commands = new List<SaveMatch>();

            build = MatchBuilder(commandQueries, division, BowlingCentre.Scottsdale, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "SO", "MB", lane = 17, "A"), build(game, "QC", "AB", lane += 2, "B"), build(game, "NO", "BC", lane += 2, "C"), build(game, "SK", "NL", lane += 2, "D"),
                build(++game, "BC", "QC", lane = 17, "A"), build(game, "NL", "SO", lane += 2, "B"), build(game, "MB", "SK", lane += 2, "C"), build(game, "AB", "NO", lane += 2, "D"),
                build(++game, "NL", "NO", lane = 17, "A"), build(game, "SK", "BC", lane += 2, "B"), build(game, "AB", "SO", lane += 2, "C"), build(game, "QC", "MB", lane += 2, "D"),
                build(++game, "AB", "SK", lane = 17, "A"), build(game, "NO", "MB", lane += 2, "B"), build(game, "QC", "NL", lane += 2, "C"), build(game, "SO", "BC", lane += 2, "D"),
                build(++game, "MB", "BC", lane = 17, "A"), build(game, "AB", "NL", lane += 2, "B"), build(game, "SO", "NO", lane += 2, "C"), build(game, "QC", "SK", lane += 2, "D"),
                build(++game, "SK", "SO", lane = 17, "A"), build(game, "NO", "QC", lane += 2, "B"), build(game, "NL", "MB", lane += 2, "C"), build(game, "BC", "AB", lane += 2, "D"),
                build(++game, "AB", "MB", lane = 17, "A"), build(game, "NL", "BC", lane += 2, "B"), build(game, "NO", "SK", lane += 2, "C"), build(game, "SO", "QC", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Cloverdale, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "NO", "NL", lane = 03, "A"), build(game, "BC", "SK", lane += 2, "B"), build(game, "SO", "AB", lane += 2, "C"), build(game, "MB", "QC", lane += 2, "D"),
                build(++game, "MB", "SO", lane = 03, "A"), build(game, "AB", "QC", lane += 2, "B"), build(game, "BC", "NO", lane += 2, "C"), build(game, "NL", "SK", lane += 2, "D"),
                build(++game, "QC", "BC", lane = 03, "A"), build(game, "SO", "NL", lane += 2, "B"), build(game, "SK", "MB", lane += 2, "C"), build(game, "NO", "AB", lane += 2, "D"),
                build(++game, "SK", "AB", lane = 03, "A"), build(game, "MB", "NO", lane += 2, "B"), build(game, "NL", "QC", lane += 2, "C"), build(game, "BC", "SO", lane += 2, "D"),
                build(++game, "QC", "SO", lane = 03, "A"), build(game, "NL", "BC", lane += 2, "B"), build(game, "NO", "SK", lane += 2, "C"), build(game, "AB", "MB", lane += 2, "D"),
                build(++game, "MB", "BC", lane = 03, "A"), build(game, "QC", "SK", lane += 2, "B"), build(game, "AB", "NL", lane += 2, "C"), build(game, "SO", "NO", lane += 2, "D"),
                build(++game, "NO", "QC", lane = 03, "A"), build(game, "BC", "AB", lane += 2, "B"), build(game, "SK", "SO", lane += 2, "C"), build(game, "MB", "NL", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Willowbrook, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "AB", "SK", lane = 13, "A"), build(game, "NO", "MB", lane += 2, "B"), build(game, "QC", "NL", lane += 2, "C"), build(game, "SO", "BC", lane += 2, "D"),
                build(++game, "NL", "NO", lane = 13, "A"), build(game, "SK", "BC", lane += 2, "B"), build(game, "AB", "SO", lane += 2, "C"), build(game, "QC", "MB", lane += 2, "D"),
                build(++game, "BC", "QC", lane = 13, "A"), build(game, "NL", "SO", lane += 2, "B"), build(game, "MB", "SK", lane += 2, "C"), build(game, "AB", "NO", lane += 2, "D"),
                build(++game, "SO", "MB", lane = 13, "A"), build(game, "QC", "AB", lane += 2, "B"), build(game, "NO", "BC", lane += 2, "C"), build(game, "SK", "NL", lane += 2, "D"),
                build(++game, "AB", "BC", lane = 13, "A"), build(game, "MB", "NL", lane += 2, "B"), build(game, "SO", "SK", lane += 2, "C"), build(game, "QC", "NO", lane += 2, "D"),
                build(++game, "SK", "QC", lane = 13, "A"), build(game, "NO", "SO", lane += 2, "B"), build(game, "BC", "MB", lane += 2, "C"), build(game, "NL", "AB", lane += 2, "D"),
                build(++game, "MB", "AB", lane = 13, "A"), build(game, "NL", "BC", lane += 2, "B"), build(game, "SK", "NO", lane += 2, "C"), build(game, "SO", "QC", lane += 2, "D"),
            });

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }

        public static void TournamentMen(ICommandQueries commandQueries, MessageDispatcher dispatcher)
        {
            var division = "Tournament Men";
            var isPoa = false;
            var game = 0;
            var lane = 0;
            Func<int, string, string, int, string, SaveMatch> build;
            var commands = new List<SaveMatch>();

            build = MatchBuilder(commandQueries, division, BowlingCentre.Willowbrook, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "SK", "NO", lane = 03, "A"), build(game, "NL", "AB", lane += 2, "B"), build(game, "MB", "QC", lane += 2, "C"), build(game, "SO", "BC", lane += 2, "D"),
                build(++game, "QC", "NL", lane = 03, "A"), build(game, "NO", "BC", lane += 2, "B"), build(game, "SK", "SO", lane += 2, "C"), build(game, "AB", "MB", lane += 2, "D"),
                build(++game, "BC", "MB", lane = 03, "A"), build(game, "SO", "QC", lane += 2, "B"), build(game, "NO", "AB", lane += 2, "C"), build(game, "NL", "SK", lane += 2, "D"),
                build(++game, "AB", "SO", lane = 03, "A"), build(game, "MB", "SK", lane += 2, "B"), build(game, "BC", "NL", lane += 2, "C"), build(game, "QC", "NO", lane += 2, "D"),
                build(++game, "QC", "SK", lane = 03, "A"), build(game, "BC", "AB", lane += 2, "B"), build(game, "MB", "NO", lane += 2, "C"), build(game, "SO", "NL", lane += 2, "D"),
                build(++game, "NO", "SO", lane = 03, "A"), build(game, "NL", "MB", lane += 2, "B"), build(game, "AB", "QC", lane += 2, "C"), build(game, "SK", "BC", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Scottsdale, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "SK", "AB", lane = 01, "A"), build(game, "QC", "BC", lane += 2, "B"), build(game, "SO", "MB", lane += 2, "C"), build(game, "NO", "NL", lane += 2, "D"),
                build(++game, "QC", "SO", lane = 01, "A"), build(game, "AB", "NO", lane += 2, "B"), build(game, "SK", "NL", lane += 2, "C"), build(game, "MB", "BC", lane += 2, "D"),
                build(++game, "AB", "NL", lane = 01, "A"), build(game, "MB", "QC", lane += 2, "B"), build(game, "BC", "SO", lane += 2, "C"), build(game, "NO", "SK", lane += 2, "D"),
                build(++game, "SK", "MB", lane = 01, "A"), build(game, "NL", "BC", lane += 2, "B"), build(game, "NO", "QC", lane += 2, "C"), build(game, "AB", "SO", lane += 2, "D"),
                build(++game, "BC", "NO", lane = 01, "A"), build(game, "SO", "SK", lane += 2, "B"), build(game, "MB", "AB", lane += 2, "C"), build(game, "NL", "QC", lane += 2, "D"),
                build(++game, "NL", "MB", lane = 01, "A"), build(game, "QC", "AB", lane += 2, "B"), build(game, "SO", "NO", lane += 2, "C"), build(game, "BC", "SK", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Cloverdale, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "SK", "QC", lane = 03, "A"), build(game, "NL", "SO", lane += 2, "B"), build(game, "AB", "BC", lane += 2, "C"), build(game, "NO", "MB", lane += 2, "D"),
                build(++game, "NO", "NL", lane = 03, "A"), build(game, "SK", "AB", lane += 2, "B"), build(game, "MB", "SO", lane += 2, "C"), build(game, "BC", "QC", lane += 2, "D"),
                build(++game, "MB", "SK", lane = 03, "A"), build(game, "NL", "BC", lane += 2, "B"), build(game, "QC", "NO", lane += 2, "C"), build(game, "SO", "AB", lane += 2, "D"),
                build(++game, "SO", "QC", lane = 03, "A"), build(game, "AB", "NO", lane += 2, "B"), build(game, "NL", "SK", lane += 2, "C"), build(game, "BC", "MB", lane += 2, "D"),
                build(++game, "BC", "NO", lane = 03, "A"), build(game, "SK", "SO", lane += 2, "B"), build(game, "MB", "AB", lane += 2, "C"), build(game, "QC", "NL", lane += 2, "D"),
                build(++game, "AB", "NL", lane = 03, "A"), build(game, "QC", "MB", lane += 2, "B"), build(game, "SO", "BC", lane += 2, "C"), build(game, "NO", "SK", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Scottsdale, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "AB", "SK", lane = 15, "A"), build(game, "NL", "NO", lane += 2, "B"), build(game, "QC", "BC", lane += 2, "C"), build(game, "SO", "MB", lane += 2, "D"),
                build(++game, "MB", "NL", lane = 15, "A"), build(game, "SK", "BC", lane += 2, "B"), build(game, "NO", "SO", lane += 2, "C"), build(game, "AB", "QC", lane += 2, "D"),
                build(++game, "QC", "SK", lane = 15, "A"), build(game, "MB", "NO", lane += 2, "B"), build(game, "BC", "AB", lane += 2, "C"), build(game, "SO", "NL", lane += 2, "D"),
            });

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }
        
        public static void TournamentLadies(ICommandQueries commandQueries, MessageDispatcher dispatcher)
        {
            var division = "Tournament Ladies";
            var isPoa = false;
            var game = 0;
            var lane = 0;
            Func<int, string, string, int, string, SaveMatch> build;
            var commands = new List<SaveMatch>();

            build = MatchBuilder(commandQueries, division, BowlingCentre.Scottsdale, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "SK", "NO", lane = 09, "A"), build(game, "NL", "AB", lane += 2, "B"), build(game, "MB", "QC", lane += 2, "C"), build(game, "SO", "BC", lane += 2, "D"),
                build(++game, "QC", "NL", lane = 09, "A"), build(game, "NO", "BC", lane += 2, "B"), build(game, "SK", "SO", lane += 2, "C"), build(game, "AB", "MB", lane += 2, "D"),
                build(++game, "BC", "MB", lane = 09, "A"), build(game, "SO", "QC", lane += 2, "B"), build(game, "NO", "AB", lane += 2, "C"), build(game, "NL", "SK", lane += 2, "D"),
                build(++game, "AB", "SO", lane = 09, "A"), build(game, "MB", "SK", lane += 2, "B"), build(game, "BC", "NL", lane += 2, "C"), build(game, "QC", "NO", lane += 2, "D"),
                build(++game, "QC", "SK", lane = 09, "A"), build(game, "BC", "AB", lane += 2, "B"), build(game, "MB", "NO", lane += 2, "C"), build(game, "SO", "NL", lane += 2, "D"),
                build(++game, "NO", "SO", lane = 09, "A"), build(game, "NL", "MB", lane += 2, "B"), build(game, "AB", "QC", lane += 2, "C"), build(game, "SK", "BC", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Willowbrook, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "SK", "AB", lane = 13, "A"), build(game, "QC", "BC", lane += 2, "B"), build(game, "SO", "MB", lane += 2, "C"), build(game, "NO", "NL", lane += 2, "D"),
                build(++game, "QC", "SO", lane = 13, "A"), build(game, "AB", "NO", lane += 2, "B"), build(game, "SK", "NL", lane += 2, "C"), build(game, "MB", "BC", lane += 2, "D"),
                build(++game, "AB", "NL", lane = 13, "A"), build(game, "MB", "QC", lane += 2, "B"), build(game, "BC", "SO", lane += 2, "C"), build(game, "NO", "SK", lane += 2, "D"),
                build(++game, "SK", "MB", lane = 13, "A"), build(game, "NL", "BC", lane += 2, "B"), build(game, "NO", "QC", lane += 2, "C"), build(game, "AB", "SO", lane += 2, "D"),
                build(++game, "BC", "NO", lane = 13, "A"), build(game, "SO", "SK", lane += 2, "B"), build(game, "MB", "AB", lane += 2, "C"), build(game, "NL", "QC", lane += 2, "D"),
                build(++game, "NL", "MB", lane = 13, "A"), build(game, "QC", "AB", lane += 2, "B"), build(game, "SO", "NO", lane += 2, "C"), build(game, "BC", "SK", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Scottsdale, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "SK", "QC", lane = 17, "A"), build(game, "NL", "SO", lane += 2, "B"), build(game, "AB", "BC", lane += 2, "C"), build(game, "NO", "MB", lane += 2, "D"),
                build(++game, "NO", "NL", lane = 17, "A"), build(game, "SK", "AB", lane += 2, "B"), build(game, "MB", "SO", lane += 2, "C"), build(game, "BC", "QC", lane += 2, "D"),
                build(++game, "MB", "SK", lane = 17, "A"), build(game, "NL", "BC", lane += 2, "B"), build(game, "QC", "NO", lane += 2, "C"), build(game, "SO", "AB", lane += 2, "D"),
                build(++game, "SO", "QC", lane = 17, "A"), build(game, "AB", "NO", lane += 2, "B"), build(game, "NL", "SK", lane += 2, "C"), build(game, "BC", "MB", lane += 2, "D"),
                build(++game, "BC", "NO", lane = 17, "A"), build(game, "SK", "SO", lane += 2, "B"), build(game, "MB", "AB", lane += 2, "C"), build(game, "QC", "NL", lane += 2, "D"),
                build(++game, "AB", "NL", lane = 17, "A"), build(game, "QC", "MB", lane += 2, "B"), build(game, "SO", "BC", lane += 2, "C"), build(game, "NO", "SK", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Willowbrook, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "AB", "SK", lane = 03, "A"), build(game, "NL", "NO", lane += 2, "B"), build(game, "QC", "BC", lane += 2, "C"), build(game, "SO", "MB", lane += 2, "D"),
                build(++game, "MB", "NL", lane = 03, "A"), build(game, "SK", "BC", lane += 2, "B"), build(game, "NO", "SO", lane += 2, "C"), build(game, "AB", "QC", lane += 2, "D"),
                build(++game, "QC", "SK", lane = 03, "A"), build(game, "MB", "NO", lane += 2, "B"), build(game, "BC", "AB", lane += 2, "C"), build(game, "SO", "NL", lane += 2, "D"),
            });

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }

        public static void TeachingMen(ICommandQueries commandQueries, MessageDispatcher dispatcher)
        {
            var division = "Teaching Men";
            var isPoa = true;
            var game = 0;
            var lane = 0;
            Func<int, string, string, int, string, SaveMatch> build;
            var commands = new List<SaveMatch>();

            build = MatchBuilder(commandQueries, division, BowlingCentre.Scottsdale, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "NO", "QC", lane = 01, "A"), build(game, "SO", "SK", lane += 2, "B"), build(game, "MB", "NL", lane += 2, "C"), build(game, "AB", "BC", lane += 2, "D"),
                build(++game, "MB", "AB", lane = 01, "A"), build(game, "NL", "BC", lane += 2, "B"), build(game, "SK", "NO", lane += 2, "C"), build(game, "QC", "SO", lane += 2, "D"),
                build(++game, "NL", "SO", lane = 01, "A"), build(game, "AB", "NO", lane += 2, "B"), build(game, "BC", "QC", lane += 2, "C"), build(game, "SK", "MB", lane += 2, "D"),
                build(++game, "BC", "SK", lane = 01, "A"), build(game, "QC", "MB", lane += 2, "B"), build(game, "SO", "AB", lane += 2, "C"), build(game, "NO", "NL", lane += 2, "D"),
                build(++game, "AB", "QC", lane = 01, "A"), build(game, "SK", "NL", lane += 2, "B"), build(game, "NO", "BC", lane += 2, "C"), build(game, "MB", "SO", lane += 2, "D"),
                build(++game, "SO", "NO", lane = 01, "A"), build(game, "BC", "MB", lane += 2, "B"), build(game, "NL", "AB", lane += 2, "C"), build(game, "QC", "SK", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Willowbrook, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "BC", "SO", lane = 03, "A"), build(game, "NO", "MB", lane += 2, "B"), build(game, "SK", "AB", lane += 2, "C"), build(game, "QC", "NL", lane += 2, "D"),
                build(++game, "NL", "NO", lane = 03, "A"), build(game, "SK", "BC", lane += 2, "B"), build(game, "MB", "QC", lane += 2, "C"), build(game, "AB", "SO", lane += 2, "D"),
                build(++game, "MB", "AB", lane = 03, "A"), build(game, "SO", "QC", lane += 2, "B"), build(game, "BC", "NL", lane += 2, "C"), build(game, "NO", "SK", lane += 2, "D"),
                build(++game, "SK", "QC", lane = 03, "A"), build(game, "AB", "NL", lane += 2, "B"), build(game, "NO", "SO", lane += 2, "C"), build(game, "MB", "BC", lane += 2, "D"),
                build(++game, "NL", "MB", lane = 03, "A"), build(game, "QC", "NO", lane += 2, "B"), build(game, "AB", "BC", lane += 2, "C"), build(game, "SO", "SK", lane += 2, "D"),
                build(++game, "BC", "NO", lane = 03, "A"), build(game, "SO", "MB", lane += 2, "B"), build(game, "NL", "SK", lane += 2, "C"), build(game, "QC", "AB", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Scottsdale, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "SO", "AB", lane = 09, "A"), build(game, "NL", "NO", lane += 2, "B"), build(game, "BC", "SK", lane += 2, "C"), build(game, "QC", "MB", lane += 2, "D"),
                build(++game, "MB", "SK", lane = 09, "A"), build(game, "QC", "BC", lane += 2, "B"), build(game, "SO", "NL", lane += 2, "C"), build(game, "NO", "AB", lane += 2, "D"),
                build(++game, "NL", "QC", lane = 09, "A"), build(game, "AB", "SK", lane += 2, "B"), build(game, "MB", "NO", lane += 2, "C"), build(game, "SO", "BC", lane += 2, "D"),
                build(++game, "NO", "BC", lane = 09, "A"), build(game, "MB", "SO", lane += 2, "B"), build(game, "AB", "QC", lane += 2, "C"), build(game, "SK", "NL", lane += 2, "D"),
                build(++game, "AB", "MB", lane = 09, "A"), build(game, "BC", "NL", lane += 2, "B"), build(game, "SK", "NO", lane += 2, "C"), build(game, "QC", "SO", lane += 2, "D"),
                build(++game, "SK", "SO", lane = 09, "A"), build(game, "NO", "QC", lane += 2, "B"), build(game, "NL", "MB", lane += 2, "C"), build(game, "BC", "AB", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Willowbrook, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "NL", "AB", lane = 13, "A"), build(game, "MB", "BC", lane += 2, "B"), build(game, "QC", "SK", lane += 2, "C"), build(game, "SO", "NO", lane += 2, "D"),
                build(++game, "NO", "MB", lane = 13, "A"), build(game, "SK", "AB", lane += 2, "B"), build(game, "BC", "SO", lane += 2, "C"), build(game, "QC", "NL", lane += 2, "D"),
                build(++game, "BC", "QC", lane = 13, "A"), build(game, "NL", "SO", lane += 2, "B"), build(game, "AB", "NO", lane += 2, "C"), build(game, "SK", "MB", lane += 2, "D"),
            });

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }

        public static void TeachingLadies(ICommandQueries commandQueries, MessageDispatcher dispatcher)
        {
            var division = "Teaching Ladies";
            var isPoa = true;
            var game = 0;
            var lane = 0;
            Func<int, string, string, int, string, SaveMatch> build;
            var commands = new List<SaveMatch>();

            build = MatchBuilder(commandQueries, division, BowlingCentre.Cloverdale, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "NO", "QC", lane = 03, "A"), build(game, "SO", "SK", lane += 2, "B"), build(game, "MB", "NL", lane += 2, "C"), build(game, "AB", "BC", lane += 2, "D"),
                build(++game, "MB", "AB", lane = 03, "A"), build(game, "NL", "BC", lane += 2, "B"), build(game, "SK", "NO", lane += 2, "C"), build(game, "QC", "SO", lane += 2, "D"),
                build(++game, "NL", "SO", lane = 03, "A"), build(game, "AB", "NO", lane += 2, "B"), build(game, "BC", "QC", lane += 2, "C"), build(game, "SK", "MB", lane += 2, "D"),
                build(++game, "BC", "SK", lane = 03, "A"), build(game, "QC", "MB", lane += 2, "B"), build(game, "SO", "AB", lane += 2, "C"), build(game, "NO", "NL", lane += 2, "D"),
                build(++game, "AB", "QC", lane = 03, "A"), build(game, "SK", "NL", lane += 2, "B"), build(game, "NO", "BC", lane += 2, "C"), build(game, "MB", "SO", lane += 2, "D"),
                build(++game, "SO", "NO", lane = 03, "A"), build(game, "BC", "MB", lane += 2, "B"), build(game, "NL", "AB", lane += 2, "C"), build(game, "QC", "SK", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Scottsdale, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "BC", "SO", lane = 17, "A"), build(game, "NO", "MB", lane += 2, "B"), build(game, "SK", "AB", lane += 2, "C"), build(game, "QC", "NL", lane += 2, "D"),
                build(++game, "NL", "NO", lane = 17, "A"), build(game, "SK", "BC", lane += 2, "B"), build(game, "MB", "QC", lane += 2, "C"), build(game, "AB", "SO", lane += 2, "D"),
                build(++game, "MB", "AB", lane = 17, "A"), build(game, "SO", "QC", lane += 2, "B"), build(game, "BC", "NL", lane += 2, "C"), build(game, "NO", "SK", lane += 2, "D"),
                build(++game, "SK", "QC", lane = 17, "A"), build(game, "AB", "NL", lane += 2, "B"), build(game, "NO", "SO", lane += 2, "C"), build(game, "MB", "BC", lane += 2, "D"),
                build(++game, "NL", "MB", lane = 17, "A"), build(game, "QC", "NO", lane += 2, "B"), build(game, "AB", "BC", lane += 2, "C"), build(game, "SO", "SK", lane += 2, "D"),
                build(++game, "BC", "NO", lane = 17, "A"), build(game, "SO", "MB", lane += 2, "B"), build(game, "NL", "SK", lane += 2, "C"), build(game, "QC", "AB", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Willowbrook, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "SO", "AB", lane = 03, "A"), build(game, "NL", "NO", lane += 2, "B"), build(game, "BC", "SK", lane += 2, "C"), build(game, "QC", "MB", lane += 2, "D"),
                build(++game, "MB", "SK", lane = 03, "A"), build(game, "QC", "BC", lane += 2, "B"), build(game, "SO", "NL", lane += 2, "C"), build(game, "NO", "AB", lane += 2, "D"),
                build(++game, "NL", "QC", lane = 03, "A"), build(game, "AB", "SK", lane += 2, "B"), build(game, "MB", "NO", lane += 2, "C"), build(game, "SO", "BC", lane += 2, "D"),
                build(++game, "NO", "BC", lane = 03, "A"), build(game, "MB", "SO", lane += 2, "B"), build(game, "AB", "QC", lane += 2, "C"), build(game, "SK", "NL", lane += 2, "D"),
                build(++game, "AB", "MB", lane = 03, "A"), build(game, "BC", "NL", lane += 2, "B"), build(game, "SK", "NO", lane += 2, "C"), build(game, "QC", "SO", lane += 2, "D"),
                build(++game, "SK", "SO", lane = 03, "A"), build(game, "NO", "QC", lane += 2, "B"), build(game, "NL", "MB", lane += 2, "C"), build(game, "BC", "AB", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Scottsdale, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "NL", "AB", lane = 03, "A"), build(game, "MB", "BC", lane += 2, "B"), build(game, "QC", "SK", lane += 2, "C"), build(game, "SO", "NO", lane += 2, "D"),
                build(++game, "NO", "MB", lane = 03, "A"), build(game, "SK", "AB", lane += 2, "B"), build(game, "BC", "SO", lane += 2, "C"), build(game, "QC", "NL", lane += 2, "D"),
                build(++game, "BC", "QC", lane = 03, "A"), build(game, "NL", "SO", lane += 2, "B"), build(game, "AB", "NO", lane += 2, "C"), build(game, "SK", "MB", lane += 2, "D"),
            });

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }

        public static void Seniors(ICommandQueries commandQueries, MessageDispatcher dispatcher)
        {
            var division = "Seniors";
            var isPoa = true;
            var game = 0;
            var lane = 0;
            Func<int, string, string, int, string, SaveMatch> build;
            var commands = new List<SaveMatch>();

            build = MatchBuilder(commandQueries, division, BowlingCentre.Willowbrook, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "AB", "SK", lane = 13, "A"), build(game, "BC", "SO", lane += 2, "B"), build(game, "QC", "MB", lane += 2, "C"), build(game, "NO", "NL", lane += 2, "D"),
                build(++game, "MB", "BC", lane = 13, "A"), build(game, "SK", "NL", lane += 2, "B"), build(game, "AB", "NO", lane += 2, "C"), build(game, "SO", "QC", lane += 2, "D"),
                build(++game, "NL", "QC", lane = 13, "A"), build(game, "NO", "MB", lane += 2, "B"), build(game, "SK", "SO", lane += 2, "C"), build(game, "BC", "AB", lane += 2, "D"),
                build(++game, "SO", "NO", lane = 13, "A"), build(game, "QC", "AB", lane += 2, "B"), build(game, "NL", "BC", lane += 2, "C"), build(game, "MB", "SK", lane += 2, "D"),
                build(++game, "MB", "AB", lane = 13, "A"), build(game, "NL", "SO", lane += 2, "B"), build(game, "QC", "SK", lane += 2, "C"), build(game, "NO", "BC", lane += 2, "D"),
                build(++game, "SK", "NO", lane = 13, "A"), build(game, "BC", "QC", lane += 2, "B"), build(game, "SO", "MB", lane += 2, "C"), build(game, "AB", "NL", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Scottsdale, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "AB", "SO", lane = 09, "A"), build(game, "MB", "NL", lane += 2, "B"), build(game, "NO", "QC", lane += 2, "C"), build(game, "SK", "BC", lane += 2, "D"),
                build(++game, "MB", "NO", lane = 09, "A"), build(game, "SO", "SK", lane += 2, "B"), build(game, "AB", "BC", lane += 2, "C"), build(game, "QC", "NL", lane += 2, "D"),
                build(++game, "SO", "BC", lane = 09, "A"), build(game, "QC", "MB", lane += 2, "B"), build(game, "NL", "NO", lane += 2, "C"), build(game, "SK", "AB", lane += 2, "D"),
                build(++game, "AB", "QC", lane = 09, "A"), build(game, "BC", "NL", lane += 2, "B"), build(game, "SK", "MB", lane += 2, "C"), build(game, "SO", "NO", lane += 2, "D"),
                build(++game, "NL", "SK", lane = 09, "A"), build(game, "NO", "AB", lane += 2, "B"), build(game, "QC", "SO", lane += 2, "C"), build(game, "BC", "MB", lane += 2, "D"),
                build(++game, "BC", "QC", lane = 09, "A"), build(game, "MB", "SO", lane += 2, "B"), build(game, "NO", "SK", lane += 2, "C"), build(game, "NL", "AB", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Scottsdale, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "AB", "MB", lane = 01, "A"), build(game, "BC", "NO", lane += 2, "B"), build(game, "SO", "NL", lane += 2, "C"), build(game, "SK", "QC", lane += 2, "D"),
                build(++game, "SK", "BC", lane = 01, "A"), build(game, "AB", "SO", lane += 2, "B"), build(game, "QC", "NO", lane += 2, "C"), build(game, "NL", "MB", lane += 2, "D"),
                build(++game, "QC", "AB", lane = 01, "A"), build(game, "BC", "NL", lane += 2, "B"), build(game, "MB", "SK", lane += 2, "C"), build(game, "NO", "SO", lane += 2, "D"),
                build(++game, "NO", "MB", lane = 01, "A"), build(game, "SO", "SK", lane += 2, "B"), build(game, "BC", "AB", lane += 2, "C"), build(game, "NL", "QC", lane += 2, "D"),
                build(++game, "NL", "SK", lane = 01, "A"), build(game, "AB", "NO", lane += 2, "B"), build(game, "QC", "SO", lane += 2, "C"), build(game, "MB", "BC", lane += 2, "D"),
                build(++game, "SO", "BC", lane = 01, "A"), build(game, "MB", "QC", lane += 2, "B"), build(game, "NO", "NL", lane += 2, "C"), build(game, "SK", "AB", lane += 2, "D"),
            });

            build = MatchBuilder(commandQueries, division, BowlingCentre.Cloverdale, isPoa);
            commands.AddRange(new List<SaveMatch>
            {
                build(++game, "SO", "AB", lane = 03, "A"), build(game, "BC", "SK", lane += 2, "B"), build(game, "MB", "NL", lane += 2, "C"), build(game, "NO", "QC", lane += 2, "D"),
                build(++game, "QC", "BC", lane = 03, "A"), build(game, "AB", "NL", lane += 2, "B"), build(game, "SK", "NO", lane += 2, "C"), build(game, "SO", "MB", lane += 2, "D"),
                build(++game, "MB", "AB", lane = 03, "A"), build(game, "QC", "SK", lane += 2, "B"), build(game, "NL", "SO", lane += 2, "C"), build(game, "NO", "BC", lane += 2, "D"),
            });

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }
    }
    */

    /*
    public static class ScheduleBuilder2015
    {
        public static void TournamentMenSingle(MessageDispatcher dispatcher)
        {
            var tournamentId = new Guid("238cbf84-1891-4e19-b467-c3c13442c6bd");
            var year = "2015";
            var division = "Tournament Men Single";

            var commands = new List<SaveMatch>
                {
                     new SaveMatch(new Guid("1a0a4f1c-cfbc-41c9-b00e-e1a9d6a1f2e0"), tournamentId, year, division,  01, "NO", "NL", 01, BowlingCentre.Sherwood), new SaveMatch(new Guid("c8555ed7-9a07-4022-9684-71a2d0c2d980"), tournamentId, year, division,  01, "QC", "MB", 03, BowlingCentre.Sherwood), new SaveMatch(new Guid("297fd90c-5131-4688-8e07-49f854f1399b"), tournamentId, year, division,  01, "SO", "AB", 05, BowlingCentre.Sherwood), new SaveMatch(new Guid("b660c4a3-012a-4cbc-9847-afee51376eb6"), tournamentId, year, division,  01, "BC", "SK", 07, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("8b0aefd7-b1db-4d83-b80b-bca3b3a9b347"), tournamentId, year, division,  02, "AB", "SK", 01, BowlingCentre.Sherwood), new SaveMatch(new Guid("5d4b4568-5654-43af-80d5-09bcc2444a22"), tournamentId, year, division,  02, "SO", "BC", 03, BowlingCentre.Sherwood), new SaveMatch(new Guid("8febaf7e-0d89-468b-90bc-3886fb60c624"), tournamentId, year, division,  02, "NL", "MB", 05, BowlingCentre.Sherwood), new SaveMatch(new Guid("2314b755-b0b2-4e3e-a440-94b9b3c0dd8f"), tournamentId, year, division,  02, "NO", "QC", 07, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("ceb66529-90f2-42c5-aee9-6b85a6fed09d"), tournamentId, year, division,  03, "SO", "MB", 01, BowlingCentre.Sherwood), new SaveMatch(new Guid("9e6c15fc-430c-48d2-afda-302d5e168a02"), tournamentId, year, division,  03, "NO", "SK", 03, BowlingCentre.Sherwood), new SaveMatch(new Guid("4d0bf729-2d90-41f9-b593-8140602d611f"), tournamentId, year, division,  03, "BC", "QC", 05, BowlingCentre.Sherwood), new SaveMatch(new Guid("90abbfce-4d22-4dc8-9582-0dfdd804f4c8"), tournamentId, year, division,  03, "NL", "AB", 07, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("81c96984-6d14-461a-b2fb-644af4771217"), tournamentId, year, division,  04, "QC", "AB", 01, BowlingCentre.Sherwood), new SaveMatch(new Guid("ecaf850b-d063-48e4-a5e5-ce8304ca314b"), tournamentId, year, division,  04, "BC", "NL", 03, BowlingCentre.Sherwood), new SaveMatch(new Guid("64d6bea0-8c15-4ff8-8edb-a26db074c17d"), tournamentId, year, division,  04, "NO", "SO", 05, BowlingCentre.Sherwood), new SaveMatch(new Guid("2fc9e20d-e354-45bf-a4ea-c83475165c11"), tournamentId, year, division,  04, "SK", "MB", 07, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("ef69cb58-7780-4579-a4af-71c7f4058323"), tournamentId, year, division,  05, "BC", "NO", 01, BowlingCentre.Sherwood), new SaveMatch(new Guid("28b06f5b-f85f-4e6a-a22e-3ac74b5c1cc0"), tournamentId, year, division,  05, "MB", "AB", 03, BowlingCentre.Sherwood), new SaveMatch(new Guid("58c25cc8-5a2e-4063-9f67-4f7c248a3eac"), tournamentId, year, division,  05, "QC", "SK", 05, BowlingCentre.Sherwood), new SaveMatch(new Guid("e307808f-6bdd-41e6-86e7-367d3afd08e9"), tournamentId, year, division,  05, "SO", "NL", 07, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("161c596c-baed-4196-a2c8-a8fe80c09ea1"), tournamentId, year, division,  06, "NL", "QC", 01, BowlingCentre.Sherwood), new SaveMatch(new Guid("ac741fc0-235c-4101-8d3b-d3d1787cf5f4"), tournamentId, year, division,  06, "SK", "SO", 03, BowlingCentre.Sherwood), new SaveMatch(new Guid("73359a02-50d9-485b-9579-b664b23916f3"), tournamentId, year, division,  06, "MB", "NO", 05, BowlingCentre.Sherwood), new SaveMatch(new Guid("7619180a-2b89-4749-bc53-cbea57860546"), tournamentId, year, division,  06, "AB", "BC", 07, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("9210c6ce-991c-4418-8487-467965e928db"), tournamentId, year, division,  07, "MB", "BC", 01, BowlingCentre.Sherwood), new SaveMatch(new Guid("718359e6-1654-485e-a73e-ea2f5ba03c50"), tournamentId, year, division,  07, "AB", "NO", 03, BowlingCentre.Sherwood), new SaveMatch(new Guid("427b6ac1-e7b6-4b8a-b8ee-1930f05b8e6c"), tournamentId, year, division,  07, "SK", "NL", 05, BowlingCentre.Sherwood), new SaveMatch(new Guid("bd7f500c-8873-4b87-91be-7a6c44a51495"), tournamentId, year, division,  07, "QC", "SO", 07, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("49ab16f3-f5a1-4bb1-8a91-fe8fd9764e1a"), tournamentId, year, division,  08, "NL", "BC", 17, BowlingCentre.Sherwood), new SaveMatch(new Guid("4b65d251-c465-4d41-962c-83958c019182"), tournamentId, year, division,  08, "MB", "SK", 19, BowlingCentre.Sherwood), new SaveMatch(new Guid("89dc6ff8-7527-4e50-bf9e-6dda8bb5f5c5"), tournamentId, year, division,  08, "AB", "QC", 21, BowlingCentre.Sherwood), new SaveMatch(new Guid("afb534f0-20c5-4ee9-a286-3a9dde341098"), tournamentId, year, division,  08, "SO", "NO", 23, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("89f63032-6f5b-48c1-af4f-d74553f0a5d8"), tournamentId, year, division,  09, "AB", "MB", 17, BowlingCentre.Sherwood), new SaveMatch(new Guid("6138d8df-e006-4c09-b6ce-48a058ad57e8"), tournamentId, year, division,  09, "NL", "SO", 19, BowlingCentre.Sherwood), new SaveMatch(new Guid("f6026927-e2a2-429a-8eb9-d2e8682bfcf2"), tournamentId, year, division,  09, "NO", "BC", 21, BowlingCentre.Sherwood), new SaveMatch(new Guid("aed225ba-4b51-4df4-bb75-dcc7868cd5ce"), tournamentId, year, division,  09, "SK", "QC", 23, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("57071d08-4107-48a7-9cdc-55b1a6b5c7a2"), tournamentId, year, division,  10, "SO", "SK", 17, BowlingCentre.Sherwood), new SaveMatch(new Guid("d3a3c33e-b2e4-42af-801d-6401ee3115c9"), tournamentId, year, division,  10, "BC", "AB", 19, BowlingCentre.Sherwood), new SaveMatch(new Guid("aad88aba-d832-4481-99ad-aea5adc59c13"), tournamentId, year, division,  10, "QC", "NL", 21, BowlingCentre.Sherwood), new SaveMatch(new Guid("52e816c9-2ad0-423b-9aa7-60d460b62bc4"), tournamentId, year, division,  10, "NO", "MB", 23, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("26db94a4-ba1e-43a1-a7a7-7d7c4391203a"), tournamentId, year, division,  11, "NO", "AB", 17, BowlingCentre.Sherwood), new SaveMatch(new Guid("7db4d925-3e16-4220-bfd9-bff4cf26659b"), tournamentId, year, division,  11, "SO", "QC", 19, BowlingCentre.Sherwood), new SaveMatch(new Guid("4d2eaa2b-1c54-40f1-8536-e032aff8060e"), tournamentId, year, division,  11, "BC", "MB", 21, BowlingCentre.Sherwood), new SaveMatch(new Guid("72886e3e-0cff-4a7d-833b-d3e265da45c5"), tournamentId, year, division,  11, "NL", "SK", 23, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("e644361f-bcff-4daf-a9a8-c33c1808af20"), tournamentId, year, division,  12, "MB", "QC", 17, BowlingCentre.Sherwood), new SaveMatch(new Guid("b5c00680-8d15-46f5-9472-68e570f51d1e"), tournamentId, year, division,  12, "SK", "BC", 19, BowlingCentre.Sherwood), new SaveMatch(new Guid("083055b5-6f88-4ca2-bee3-89a09a514ef5"), tournamentId, year, division,  12, "NL", "NO", 21, BowlingCentre.Sherwood), new SaveMatch(new Guid("03654920-964a-4fb0-a534-9a29e3165354"), tournamentId, year, division,  12, "AB", "SO", 23, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("7a6f46ef-0b02-4fd2-9bde-5c6e0a4f4c17"), tournamentId, year, division,  13, "BC", "SO", 17, BowlingCentre.Sherwood), new SaveMatch(new Guid("b331a118-0b57-42ba-85b2-809e23247834"), tournamentId, year, division,  13, "QC", "NO", 19, BowlingCentre.Sherwood), new SaveMatch(new Guid("604fb81f-cebf-4fbf-b03f-745d16270ac6"), tournamentId, year, division,  13, "SK", "AB", 21, BowlingCentre.Sherwood), new SaveMatch(new Guid("20be7f4c-ec43-4f73-a7df-49531d23338f"), tournamentId, year, division,  13, "MB", "NL", 23, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("11df2981-2cbd-45cc-be92-8d8467cbc8cc"), tournamentId, year, division,  14, "SK", "NO", 17, BowlingCentre.Sherwood), new SaveMatch(new Guid("9c584e35-2f57-42fe-943b-f88189bf00eb"), tournamentId, year, division,  14, "AB", "NL", 19, BowlingCentre.Sherwood), new SaveMatch(new Guid("2ef71ea1-776f-4ebc-9403-b004b706c3a8"), tournamentId, year, division,  14, "MB", "SO", 21, BowlingCentre.Sherwood), new SaveMatch(new Guid("026b72b2-3cd2-43c9-8b6d-b7590bc53654"), tournamentId, year, division,  14, "QC", "BC", 23, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("c0829f0a-b08c-42f8-8c8c-8e4c096c3ff6"), tournamentId, year, division,  15, "AB", "BC", 25, BowlingCentre.Sherwood), new SaveMatch(new Guid("064b5934-97c8-4fc6-90ba-ef2d440a0b06"), tournamentId, year, division,  15, "NL", "QC", 27, BowlingCentre.Sherwood), new SaveMatch(new Guid("84c0b097-80dd-4a38-a8c8-2c9c6bb2130d"), tournamentId, year, division,  15, "SK", "SO", 29, BowlingCentre.Sherwood), new SaveMatch(new Guid("4ac8c63f-8fc1-4808-b35e-24f4f4126293"), tournamentId, year, division,  15, "MB", "NO", 31, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("c4b5f166-0113-467e-98b3-89fba9866057"), tournamentId, year, division,  16, "QC", "SO", 25, BowlingCentre.Sherwood), new SaveMatch(new Guid("e85b08c9-c188-44d3-aab2-4f020d199793"), tournamentId, year, division,  16, "MB", "BC", 27, BowlingCentre.Sherwood), new SaveMatch(new Guid("d9cd7521-b264-48e7-8a14-89cc3fce0bf6"), tournamentId, year, division,  16, "AB", "NO", 29, BowlingCentre.Sherwood), new SaveMatch(new Guid("6d19f79e-2a43-4759-b46f-5e1c5a3f5d16"), tournamentId, year, division,  16, "SK", "NL", 31, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("48cca1ae-f21e-498b-bf7d-ac3b5b908364"), tournamentId, year, division,  17, "BC", "SK", 25, BowlingCentre.Sherwood), new SaveMatch(new Guid("241b50c8-9bb8-4f10-888c-d78b6cdd7f18"), tournamentId, year, division,  17, "NO", "NL", 27, BowlingCentre.Sherwood), new SaveMatch(new Guid("82a49457-1bc2-42ed-804f-98091c0a5a95"), tournamentId, year, division,  17, "QC", "MB", 29, BowlingCentre.Sherwood), new SaveMatch(new Guid("20b28677-31f6-4738-87e2-67548e58ee1a"), tournamentId, year, division,  17, "SO", "AB", 31, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("a4ae7dcf-72a1-4006-b207-d1eaf0355c85"), tournamentId, year, division,  18, "NO", "QC", 25, BowlingCentre.Sherwood), new SaveMatch(new Guid("d4869f6b-ec62-4b4f-9db4-872af1f7ab9c"), tournamentId, year, division,  18, "AB", "SK", 27, BowlingCentre.Sherwood), new SaveMatch(new Guid("404b86ad-9a8e-43b7-89f0-adfa93050325"), tournamentId, year, division,  18, "SO", "BC", 29, BowlingCentre.Sherwood), new SaveMatch(new Guid("0fe505ca-a6fc-4bdc-9b40-af856e78aa61"), tournamentId, year, division,  18, "NL", "MB", 31, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("bc3c59fe-5c91-4b9d-b3a8-4f1ffccef734"), tournamentId, year, division,  19, "NL", "AB", 25, BowlingCentre.Sherwood), new SaveMatch(new Guid("7cb7265f-3321-4cbb-b16d-c9e20cf958a8"), tournamentId, year, division,  19, "SO", "MB", 27, BowlingCentre.Sherwood), new SaveMatch(new Guid("bffdbdeb-a997-41bb-b384-a9e106239090"), tournamentId, year, division,  19, "NO", "SK", 29, BowlingCentre.Sherwood), new SaveMatch(new Guid("336a8a81-495d-43c4-a49b-21db67b0233f"), tournamentId, year, division,  19, "BC", "QC", 31, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("efad3103-c36e-4eb7-98ac-e8a0e448609d"), tournamentId, year, division,  20, "SK", "MB", 25, BowlingCentre.Sherwood), new SaveMatch(new Guid("0d4f5123-e6f6-42f7-a1cb-e72eb8dc2b8a"), tournamentId, year, division,  20, "QC", "AB", 27, BowlingCentre.Sherwood), new SaveMatch(new Guid("e1db6f52-4225-4652-a443-884210e28868"), tournamentId, year, division,  20, "BC", "NL", 29, BowlingCentre.Sherwood), new SaveMatch(new Guid("d013974e-7282-4f14-b2b2-5206de550ceb"), tournamentId, year, division,  20, "NO", "SO", 31, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("45e2306b-4e24-49e6-ab90-cae77adbb70f"), tournamentId, year, division,  21, "SO", "NL", 25, BowlingCentre.Sherwood), new SaveMatch(new Guid("0e246fc2-70ae-4faa-8ae1-a89503b91e9a"), tournamentId, year, division,  21, "BC", "NO", 27, BowlingCentre.Sherwood), new SaveMatch(new Guid("46e67a26-07ce-440b-858a-25be6deb3f39"), tournamentId, year, division,  21, "MB", "AB", 29, BowlingCentre.Sherwood), new SaveMatch(new Guid("b6c9ca47-b08d-4bd7-8a2c-6b64b6715c46"), tournamentId, year, division,  21, "QC", "SK", 31, BowlingCentre.Sherwood),
                };

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }

        public static void TournamentLadiesSingle(MessageDispatcher dispatcher)
        {
            var tournamentId = new Guid("238cbf84-1891-4e19-b467-c3c13442c6bd");
            var year = "2015";
            var division = "Tournament Ladies Single";

            var commands = new List<SaveMatch>
                {
                     new SaveMatch(new Guid("f6b68fc1-4618-495d-98ea-ac9af964d0e1"), tournamentId, year, division,  01, "NO", "NL", 01, BowlingCentre.Sherwood), new SaveMatch(new Guid("ef034c55-b951-40f9-8e4b-7b87f008a6e1"), tournamentId, year, division,  01, "QC", "MB", 03, BowlingCentre.Sherwood), new SaveMatch(new Guid("2a3e7960-8055-4839-accf-2fc80cbf0ead"), tournamentId, year, division,  01, "SO", "AB", 05, BowlingCentre.Sherwood), new SaveMatch(new Guid("a762b29e-3bee-4566-89a5-082f0b888a7f"), tournamentId, year, division,  01, "BC", "SK", 07, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("f49c7c52-55ee-47fa-b913-4898298e797c"), tournamentId, year, division,  02, "AB", "SK", 01, BowlingCentre.Sherwood), new SaveMatch(new Guid("b8387789-3002-47dd-a2e4-9ac8fae86270"), tournamentId, year, division,  02, "SO", "BC", 03, BowlingCentre.Sherwood), new SaveMatch(new Guid("4273a150-54bd-4265-ae77-d9094e3622b8"), tournamentId, year, division,  02, "NL", "MB", 05, BowlingCentre.Sherwood), new SaveMatch(new Guid("533c7f4d-36db-4861-9043-7a76a9053544"), tournamentId, year, division,  02, "NO", "QC", 07, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("c52c6f69-ed2e-482c-94ce-e0deac7a049a"), tournamentId, year, division,  03, "SO", "MB", 01, BowlingCentre.Sherwood), new SaveMatch(new Guid("11d9f78f-f6d5-491b-a410-f434b951da8d"), tournamentId, year, division,  03, "NO", "SK", 03, BowlingCentre.Sherwood), new SaveMatch(new Guid("11c56aeb-2a4e-4a48-bc27-c8c7f96126c5"), tournamentId, year, division,  03, "BC", "QC", 05, BowlingCentre.Sherwood), new SaveMatch(new Guid("9f7bccd8-aa05-49c7-adc8-23f5152f5022"), tournamentId, year, division,  03, "NL", "AB", 07, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("cca60dd0-16b3-4580-94f2-14db9735dfe5"), tournamentId, year, division,  04, "QC", "AB", 01, BowlingCentre.Sherwood), new SaveMatch(new Guid("999c8588-705d-4a0c-81fb-1bea6b2b2f5e"), tournamentId, year, division,  04, "BC", "NL", 03, BowlingCentre.Sherwood), new SaveMatch(new Guid("002f00b5-eaea-4d09-ab74-6eb191884c88"), tournamentId, year, division,  04, "NO", "SO", 05, BowlingCentre.Sherwood), new SaveMatch(new Guid("da01878a-cff5-4153-9604-7f138b95a433"), tournamentId, year, division,  04, "SK", "MB", 07, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("a05c0b7f-38e2-43fe-8611-43474566b3a8"), tournamentId, year, division,  05, "BC", "NO", 01, BowlingCentre.Sherwood), new SaveMatch(new Guid("74390302-d760-4065-9428-c72c751ab24d"), tournamentId, year, division,  05, "MB", "AB", 03, BowlingCentre.Sherwood), new SaveMatch(new Guid("e03267d6-f50b-4916-96ab-4cf4e89c4c8a"), tournamentId, year, division,  05, "QC", "SK", 05, BowlingCentre.Sherwood), new SaveMatch(new Guid("f852ed40-1da6-4f63-9fd1-e7adbf2880e3"), tournamentId, year, division,  05, "SO", "NL", 07, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("fff473d5-ff2f-40d4-937f-550505efdb20"), tournamentId, year, division,  06, "NL", "QC", 01, BowlingCentre.Sherwood), new SaveMatch(new Guid("673ac8c6-6f3c-47cd-8632-2ed15e04762e"), tournamentId, year, division,  06, "SK", "SO", 03, BowlingCentre.Sherwood), new SaveMatch(new Guid("c3f340f4-dec5-4560-ad6f-e884473e5ced"), tournamentId, year, division,  06, "MB", "NO", 05, BowlingCentre.Sherwood), new SaveMatch(new Guid("8b70f05b-c738-441f-8516-4090aa99af42"), tournamentId, year, division,  06, "AB", "BC", 07, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("0538a0fa-f55e-47d8-a904-319cd632b222"), tournamentId, year, division,  07, "MB", "BC", 01, BowlingCentre.Sherwood), new SaveMatch(new Guid("c8cff4b3-630d-4970-91e2-6ed639db8c49"), tournamentId, year, division,  07, "AB", "NO", 03, BowlingCentre.Sherwood), new SaveMatch(new Guid("bf5403fe-b64e-4171-b487-aa62ff310ba8"), tournamentId, year, division,  07, "SK", "NL", 05, BowlingCentre.Sherwood), new SaveMatch(new Guid("b4b5bca2-6b1f-4787-a95c-80c9370e7695"), tournamentId, year, division,  07, "QC", "SO", 07, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("f941d006-94f5-499c-aa62-c4f87ba84763"), tournamentId, year, division,  08, "NL", "BC", 17, BowlingCentre.Sherwood), new SaveMatch(new Guid("2c161825-be55-4129-9280-e131dd57aba2"), tournamentId, year, division,  08, "MB", "SK", 19, BowlingCentre.Sherwood), new SaveMatch(new Guid("41b80d4e-425b-420b-837d-c9eb68602121"), tournamentId, year, division,  08, "AB", "QC", 21, BowlingCentre.Sherwood), new SaveMatch(new Guid("1592d4cc-c914-4aa7-9e06-696e8454b110"), tournamentId, year, division,  08, "SO", "NO", 23, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("1749e7c3-69c1-47a7-b211-a9045eb2842e"), tournamentId, year, division,  09, "AB", "MB", 17, BowlingCentre.Sherwood), new SaveMatch(new Guid("6512ab2a-31c1-4a1a-a019-a2c33275927c"), tournamentId, year, division,  09, "NL", "SO", 19, BowlingCentre.Sherwood), new SaveMatch(new Guid("4e8f7a75-dc64-4927-a17c-ba11787ea4dc"), tournamentId, year, division,  09, "NO", "BC", 21, BowlingCentre.Sherwood), new SaveMatch(new Guid("1cf97243-7db3-4963-ad3e-dadfe017a599"), tournamentId, year, division,  09, "SK", "QC", 23, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("ef7b4acc-c094-46e9-a50f-69ce8310f0fd"), tournamentId, year, division,  10, "SO", "SK", 17, BowlingCentre.Sherwood), new SaveMatch(new Guid("b67f1395-d327-4c22-a59d-ff3d99086210"), tournamentId, year, division,  10, "BC", "AB", 19, BowlingCentre.Sherwood), new SaveMatch(new Guid("7c7d6950-c263-49b8-99f2-e43680fdbd4e"), tournamentId, year, division,  10, "QC", "NL", 21, BowlingCentre.Sherwood), new SaveMatch(new Guid("b336403f-6a51-4460-b51c-1ea5b3eca6cd"), tournamentId, year, division,  10, "NO", "MB", 23, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("6a838631-1f21-4926-86fd-b96dc99e5d68"), tournamentId, year, division,  11, "NO", "AB", 17, BowlingCentre.Sherwood), new SaveMatch(new Guid("65ae96b3-c06f-457c-a36f-e8c82820a69e"), tournamentId, year, division,  11, "SO", "QC", 19, BowlingCentre.Sherwood), new SaveMatch(new Guid("01c4ba0a-300f-49a6-adaa-a535006f3f38"), tournamentId, year, division,  11, "BC", "MB", 21, BowlingCentre.Sherwood), new SaveMatch(new Guid("11430acb-9500-4253-8ac3-56528aba4602"), tournamentId, year, division,  11, "NL", "SK", 23, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("e4f6a735-71be-4111-9473-5c14361ad84c"), tournamentId, year, division,  12, "MB", "QC", 17, BowlingCentre.Sherwood), new SaveMatch(new Guid("85f7371e-9749-4d95-af69-d7a51e20483c"), tournamentId, year, division,  12, "SK", "BC", 19, BowlingCentre.Sherwood), new SaveMatch(new Guid("b510ec50-8dc6-414d-a328-ecfcabd8fcf4"), tournamentId, year, division,  12, "NL", "NO", 21, BowlingCentre.Sherwood), new SaveMatch(new Guid("74ba95d3-552a-48e9-ab04-56b456cc93b4"), tournamentId, year, division,  12, "AB", "SO", 23, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("91d56815-9e22-4659-9937-43ce1ca1ce16"), tournamentId, year, division,  13, "BC", "SO", 17, BowlingCentre.Sherwood), new SaveMatch(new Guid("fe6ce641-9c15-4c9c-b909-9db775499b6d"), tournamentId, year, division,  13, "QC", "NO", 19, BowlingCentre.Sherwood), new SaveMatch(new Guid("38f9b780-f767-47a4-94a2-cefd6997a7a8"), tournamentId, year, division,  13, "SK", "AB", 21, BowlingCentre.Sherwood), new SaveMatch(new Guid("e395e094-4657-4841-9539-e0b1d4252855"), tournamentId, year, division,  13, "MB", "NL", 23, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("cd97db45-7544-43c2-9b12-5be275636a38"), tournamentId, year, division,  14, "SK", "NO", 17, BowlingCentre.Sherwood), new SaveMatch(new Guid("70cd54f9-a9b4-48ce-9a91-f690a3918903"), tournamentId, year, division,  14, "AB", "NL", 19, BowlingCentre.Sherwood), new SaveMatch(new Guid("4a5ee975-c094-4981-919e-28e31a0e14e5"), tournamentId, year, division,  14, "MB", "SO", 21, BowlingCentre.Sherwood), new SaveMatch(new Guid("3af11504-52e9-4ed1-8aea-0b514c942e50"), tournamentId, year, division,  14, "QC", "BC", 23, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("6b956806-dbe1-4d5e-a610-defd2682cf4c"), tournamentId, year, division,  15, "AB", "BC", 25, BowlingCentre.Sherwood), new SaveMatch(new Guid("b3cf28b2-b3cc-4dd3-980b-bb19bc83ef99"), tournamentId, year, division,  15, "NL", "QC", 27, BowlingCentre.Sherwood), new SaveMatch(new Guid("cb0e4efc-8835-4593-8fba-8272448757d6"), tournamentId, year, division,  15, "SK", "SO", 29, BowlingCentre.Sherwood), new SaveMatch(new Guid("0de3db78-fea2-4ebe-9273-2276d9f6ceea"), tournamentId, year, division,  15, "MB", "NO", 31, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("cbcce785-468d-4de9-a632-8637a80d58ca"), tournamentId, year, division,  16, "QC", "SO", 25, BowlingCentre.Sherwood), new SaveMatch(new Guid("01b04b1c-dc3a-4866-af89-c1de89cc3647"), tournamentId, year, division,  16, "MB", "BC", 27, BowlingCentre.Sherwood), new SaveMatch(new Guid("9cf8e297-7233-458a-9409-bbac16a0e4be"), tournamentId, year, division,  16, "AB", "NO", 29, BowlingCentre.Sherwood), new SaveMatch(new Guid("045088a6-dd74-4d56-b09e-41be278042e2"), tournamentId, year, division,  16, "SK", "NL", 31, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("f38a548a-e7ff-4cc4-96fa-7ae6aef2a5d0"), tournamentId, year, division,  17, "BC", "SK", 25, BowlingCentre.Sherwood), new SaveMatch(new Guid("474cebf0-fd3e-475e-80e2-9512698a0ffd"), tournamentId, year, division,  17, "NO", "NL", 27, BowlingCentre.Sherwood), new SaveMatch(new Guid("2f4f872f-078f-4f40-9275-fd2c783693ee"), tournamentId, year, division,  17, "QC", "MB", 29, BowlingCentre.Sherwood), new SaveMatch(new Guid("ad2e68d1-670a-411e-8359-03402bb800c5"), tournamentId, year, division,  17, "SO", "AB", 31, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("91109103-9c54-47eb-be8a-de04d7064736"), tournamentId, year, division,  18, "NO", "QC", 25, BowlingCentre.Sherwood), new SaveMatch(new Guid("14b3d173-03c5-42da-ac09-8a6b1366eaa3"), tournamentId, year, division,  18, "AB", "SK", 27, BowlingCentre.Sherwood), new SaveMatch(new Guid("a187ca97-172a-45a3-9077-1548c1c9ad56"), tournamentId, year, division,  18, "SO", "BC", 29, BowlingCentre.Sherwood), new SaveMatch(new Guid("4ac02128-d393-4627-96f0-c28558236563"), tournamentId, year, division,  18, "NL", "MB", 31, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("2a0812ab-c908-4b26-8976-86f315b7e012"), tournamentId, year, division,  19, "NL", "AB", 25, BowlingCentre.Sherwood), new SaveMatch(new Guid("1c249e2a-c1bc-46d0-8b9d-662746ed7121"), tournamentId, year, division,  19, "SO", "MB", 27, BowlingCentre.Sherwood), new SaveMatch(new Guid("3bc2f1aa-6b4e-44c5-805a-f255692c4306"), tournamentId, year, division,  19, "NO", "SK", 29, BowlingCentre.Sherwood), new SaveMatch(new Guid("f418ff89-9ffe-4c37-869b-77ded93beceb"), tournamentId, year, division,  19, "BC", "QC", 31, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("624a2124-b3f5-4af9-9715-517694dab721"), tournamentId, year, division,  20, "SK", "MB", 25, BowlingCentre.Sherwood), new SaveMatch(new Guid("9d612beb-350c-4e38-949d-668dde119a0a"), tournamentId, year, division,  20, "QC", "AB", 27, BowlingCentre.Sherwood), new SaveMatch(new Guid("5e379f13-dc0d-45bc-880b-618d35caf931"), tournamentId, year, division,  20, "BC", "NL", 29, BowlingCentre.Sherwood), new SaveMatch(new Guid("60863064-bde1-41aa-b03d-cdb186fb9b7f"), tournamentId, year, division,  20, "NO", "SO", 31, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("913aeb76-f456-49f6-b895-73df0d752045"), tournamentId, year, division,  21, "SO", "NL", 25, BowlingCentre.Sherwood), new SaveMatch(new Guid("1e6ef596-e3fc-4425-95f0-3126ca85614e"), tournamentId, year, division,  21, "BC", "NO", 27, BowlingCentre.Sherwood), new SaveMatch(new Guid("b4515953-ae8e-427d-8309-5a6ab8b9e77c"), tournamentId, year, division,  21, "MB", "AB", 29, BowlingCentre.Sherwood), new SaveMatch(new Guid("396bd3b1-0b0f-494e-a151-d1268039df70"), tournamentId, year, division,  21, "QC", "SK", 31, BowlingCentre.Sherwood),
                };

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }

        public static void TournamentLadies(MessageDispatcher dispatcher)
        {
            var tournamentId = new Guid("238cbf84-1891-4e19-b467-c3c13442c6bd");
            var year = "2015";
            var division = "Tournament Ladies";

            var commands = new List<SaveMatch>
                {
                     new SaveMatch(new Guid("aa9af63f-a237-4014-a74e-2bf8c5ab6aea"), tournamentId, year, division,  01, "QC", "BC", 09, BowlingCentre.Sherwood), new SaveMatch(new Guid("636773b3-aa3b-4624-8c00-026f4ff0c711"), tournamentId, year, division,  01, "MB", "NL", 11, BowlingCentre.Sherwood), new SaveMatch(new Guid("9fd7bcd0-092f-4fa7-97f5-0371683cff95"), tournamentId, year, division,  01, "NO", "SK", 13, BowlingCentre.Sherwood), new SaveMatch(new Guid("73964dbb-003e-4238-b8d0-dc77c55e4acc"), tournamentId, year, division,  01, "SO", "AB", 15, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("f12ebf3a-3552-463d-93d2-94ef4c910915"), tournamentId, year, division,  02, "SK", "AB", 09, BowlingCentre.Sherwood), new SaveMatch(new Guid("fa6f6c2c-83c4-4462-a7c1-a57ad692c908"), tournamentId, year, division,  02, "NO", "SO", 11, BowlingCentre.Sherwood), new SaveMatch(new Guid("c7b3af46-b2fc-4213-983c-5f2126cd8208"), tournamentId, year, division,  02, "BC", "NL", 13, BowlingCentre.Sherwood), new SaveMatch(new Guid("b69faae9-fe48-48bb-98dd-145a0b407c8b"), tournamentId, year, division,  02, "QC", "MB", 15, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("db7a82c1-c53f-48d7-bcb3-27bee9f7b338"), tournamentId, year, division,  03, "NL", "NO", 09, BowlingCentre.Sherwood), new SaveMatch(new Guid("d1b26ea2-2ea3-4c78-8c18-de119e1d25d4"), tournamentId, year, division,  03, "AB", "QC", 11, BowlingCentre.Sherwood), new SaveMatch(new Guid("683060bc-62f7-40ee-8b83-61b4bda6370d"), tournamentId, year, division,  03, "SO", "MB", 13, BowlingCentre.Sherwood), new SaveMatch(new Guid("22a1335d-f725-45dd-9d3e-2051c3440c24"), tournamentId, year, division,  03, "SK", "BC", 15, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("6c20f532-ecd5-497d-83a9-171a1ac52248"), tournamentId, year, division,  04, "MB", "SK", 17, BowlingCentre.Sherwood), new SaveMatch(new Guid("5a900690-7f15-4b39-88bb-eb0002c1fec0"), tournamentId, year, division,  04, "BC", "SO", 19, BowlingCentre.Sherwood), new SaveMatch(new Guid("02fe4f75-d1e7-47f5-8974-e72de40fabd9"), tournamentId, year, division,  04, "AB", "NL", 21, BowlingCentre.Sherwood), new SaveMatch(new Guid("4aa73cbd-9fa1-4b5b-8140-cc9eda2f15cb"), tournamentId, year, division,  04, "QC", "NO", 23, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("40b3882f-8dcc-4469-8388-fee791d24d2e"), tournamentId, year, division,  05, "SO", "QC", 17, BowlingCentre.Sherwood), new SaveMatch(new Guid("22f76ce1-bf4a-4baa-a24e-64d0d300d987"), tournamentId, year, division,  05, "MB", "AB", 19, BowlingCentre.Sherwood), new SaveMatch(new Guid("9b140ab0-acb7-44e5-be4d-dd2629adb473"), tournamentId, year, division,  05, "NO", "BC", 21, BowlingCentre.Sherwood), new SaveMatch(new Guid("cca36bad-a69d-481d-8275-ea1d26f4adcb"), tournamentId, year, division,  05, "NL", "SK", 23, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("8236dbe9-41d0-43f3-a3d2-16f6e58205e1"), tournamentId, year, division,  06, "AB", "NO", 17, BowlingCentre.Sherwood), new SaveMatch(new Guid("2b60f6fa-1c31-4a8f-a47a-a98eea75f194"), tournamentId, year, division,  06, "NL", "QC", 19, BowlingCentre.Sherwood), new SaveMatch(new Guid("554a9a0b-2a07-4fb3-9edb-71cb475f3915"), tournamentId, year, division,  06, "SK", "SO", 21, BowlingCentre.Sherwood), new SaveMatch(new Guid("16b63a9b-3a57-4dfa-a405-37f960df435a"), tournamentId, year, division,  06, "BC", "MB", 23, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("baa56209-fafb-4588-ad2f-32c5a0abad4f"), tournamentId, year, division,  07, "NL", "SO", 33, BowlingCentre.Sherwood), new SaveMatch(new Guid("96438b2c-1d81-4085-a3e7-8e39d9d74ad4"), tournamentId, year, division,  07, "SK", "QC", 35, BowlingCentre.Sherwood), new SaveMatch(new Guid("b35d5f14-e940-4d1a-a092-006ad571eb7e"), tournamentId, year, division,  07, "AB", "BC", 37, BowlingCentre.Sherwood), new SaveMatch(new Guid("28344048-e802-46ea-8fdc-43109f534356"), tournamentId, year, division,  07, "MB", "NO", 39, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("90283cf7-6a3f-4acd-b996-854de73a53f9"), tournamentId, year, division,  08, "QC", "AB", 33, BowlingCentre.Sherwood), new SaveMatch(new Guid("55f2821e-d37f-4ccf-8b78-4cdbd39b96b2"), tournamentId, year, division,  08, "NO", "NL", 35, BowlingCentre.Sherwood), new SaveMatch(new Guid("873a8eef-7b1e-4969-acf2-57904eb60f16"), tournamentId, year, division,  08, "MB", "SO", 37, BowlingCentre.Sherwood), new SaveMatch(new Guid("b0dd3050-3ea3-4ae8-94c0-f8f0cca246d0"), tournamentId, year, division,  08, "BC", "SK", 39, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("18e96403-c12a-43d7-8af4-d117ac40bd96"), tournamentId, year, division,  09, "SK", "MB", 33, BowlingCentre.Sherwood), new SaveMatch(new Guid("4c38fe6b-3b92-4bf0-b6bc-b592d0a1bc6e"), tournamentId, year, division,  09, "SO", "BC", 35, BowlingCentre.Sherwood), new SaveMatch(new Guid("91d52b30-5b34-44b6-bfb2-d7caa795d3e8"), tournamentId, year, division,  09, "NO", "QC", 37, BowlingCentre.Sherwood), new SaveMatch(new Guid("34abeb3c-e5be-4eb0-bb72-47fccd7e9f53"), tournamentId, year, division,  09, "NL", "AB", 39, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("81f0ab6a-dfac-470b-bcf9-3c39eb90b75d"), tournamentId, year, division,  10, "QC", "SO", 25, BowlingCentre.Sherwood), new SaveMatch(new Guid("f19205fd-61bb-455b-bb9d-504af0435cff"), tournamentId, year, division,  10, "BC", "NO", 27, BowlingCentre.Sherwood), new SaveMatch(new Guid("4a1e8a97-f78d-4968-93d1-6e9004b58cc2"), tournamentId, year, division,  10, "SK", "NL", 29, BowlingCentre.Sherwood), new SaveMatch(new Guid("9b5e4d6a-2f91-468e-85ae-74d148588c15"), tournamentId, year, division,  10, "AB", "MB", 31, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("43f2959a-9e7a-4ca1-beb4-604b19ed1823"), tournamentId, year, division,  11, "NO", "AB", 25, BowlingCentre.Sherwood), new SaveMatch(new Guid("e921fb1a-61f9-4e21-8659-884402ee8606"), tournamentId, year, division,  11, "QC", "NL", 27, BowlingCentre.Sherwood), new SaveMatch(new Guid("3db1981f-63d9-482a-80a8-1bf0b05ea350"), tournamentId, year, division,  11, "BC", "MB", 29, BowlingCentre.Sherwood), new SaveMatch(new Guid("b6e3f76f-c364-4613-a409-40a25041ec53"), tournamentId, year, division,  11, "SO", "SK", 31, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("74b3cf0b-6d87-4bd9-ba87-e563aa712b6a"), tournamentId, year, division,  12, "NL", "BC", 25, BowlingCentre.Sherwood), new SaveMatch(new Guid("04be2d40-500f-4890-b718-07f314858159"), tournamentId, year, division,  12, "AB", "SK", 27, BowlingCentre.Sherwood), new SaveMatch(new Guid("ed1e2e7b-64cf-4647-a35e-b3a13b581d7d"), tournamentId, year, division,  12, "SO", "NO", 29, BowlingCentre.Sherwood), new SaveMatch(new Guid("0eeba368-aa0e-4b13-9c30-ab1e5ef2872a"), tournamentId, year, division,  12, "MB", "QC", 31, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("c06dc5f2-e77f-42f2-96ef-dbe885403ee8"), tournamentId, year, division,  13, "BC", "QC", 41, BowlingCentre.Sherwood), new SaveMatch(new Guid("5747c6b8-1517-45f1-bc49-86eb83419d0a"), tournamentId, year, division,  13, "NL", "MB", 43, BowlingCentre.Sherwood), new SaveMatch(new Guid("614c89a2-c287-4a34-bf65-679e8dbb9c9c"), tournamentId, year, division,  13, "SK", "NO", 45, BowlingCentre.Sherwood), new SaveMatch(new Guid("824ca806-8415-42ca-8961-be2e708b57fb"), tournamentId, year, division,  13, "AB", "SO", 47, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("9a75bad1-7f68-4a5b-8599-80d058c59a1f"), tournamentId, year, division,  14, "SO", "NL", 41, BowlingCentre.Sherwood), new SaveMatch(new Guid("402e28a1-76d3-4993-9270-b72fe2842190"), tournamentId, year, division,  14, "QC", "SK", 43, BowlingCentre.Sherwood), new SaveMatch(new Guid("437d361d-3bfa-4948-ba3d-3efe6b161952"), tournamentId, year, division,  14, "BC", "AB", 45, BowlingCentre.Sherwood), new SaveMatch(new Guid("bb3d0733-61f0-4929-9241-dd8168c5a8fc"), tournamentId, year, division,  14, "NO", "MB", 47, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("2b239a0c-c4c2-4592-be5e-fced2d9cdcb6"), tournamentId, year, division,  15, "SK", "AB", 41, BowlingCentre.Sherwood), new SaveMatch(new Guid("5d5eddb6-5b4d-4f87-99d6-d47baabb3b6d"), tournamentId, year, division,  15, "NO", "SO", 43, BowlingCentre.Sherwood), new SaveMatch(new Guid("cef4fe1a-3768-47be-aa84-d54628ebc224"), tournamentId, year, division,  15, "QC", "MB", 45, BowlingCentre.Sherwood), new SaveMatch(new Guid("a6448dd1-84bc-4319-af8c-29af68770869"), tournamentId, year, division,  15, "BC", "NL", 47, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("37d2b19a-55e9-4f79-9307-fdbb7255bc18"), tournamentId, year, division,  16, "MB", "AB", 01, BowlingCentre.Sherwood), new SaveMatch(new Guid("0ca1dedc-51ec-4dd1-94f7-5c5b2e92d800"), tournamentId, year, division,  16, "NO", "BC", 03, BowlingCentre.Sherwood), new SaveMatch(new Guid("867ecdee-961c-4a24-b0f1-206d1a2a7051"), tournamentId, year, division,  16, "SO", "QC", 05, BowlingCentre.Sherwood), new SaveMatch(new Guid("678cb98d-c60f-4167-ae72-baac2f37cb2a"), tournamentId, year, division,  16, "NL", "SK", 07, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("8863070a-9106-4793-b8d1-87bc2f2ec57f"), tournamentId, year, division,  17, "NL", "QC", 01, BowlingCentre.Sherwood), new SaveMatch(new Guid("da09a685-1135-4250-9fc6-da158b17ab81"), tournamentId, year, division,  17, "SK", "SO", 03, BowlingCentre.Sherwood), new SaveMatch(new Guid("553dbb1a-7257-44e7-967e-759b6954011d"), tournamentId, year, division,  17, "AB", "NO", 05, BowlingCentre.Sherwood), new SaveMatch(new Guid("9c3092bd-b883-484f-aafd-b99a700b9164"), tournamentId, year, division,  17, "MB", "BC", 07, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("8efbfab9-2506-4123-9674-5acec397ec3d"), tournamentId, year, division,  18, "SO", "BC", 01, BowlingCentre.Sherwood), new SaveMatch(new Guid("43848474-8cf5-434b-8bb6-e895c5e0eaef"), tournamentId, year, division,  18, "AB", "NL", 03, BowlingCentre.Sherwood), new SaveMatch(new Guid("870c97cf-33b5-4793-af0f-1c3b5346937a"), tournamentId, year, division,  18, "MB", "SK", 05, BowlingCentre.Sherwood), new SaveMatch(new Guid("d8bc1a9b-1921-4a22-a5be-6cce5a2fcd5e"), tournamentId, year, division,  18, "QC", "NO", 07, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("4253c59d-fbfe-4a49-b696-c9e2321ab673"), tournamentId, year, division,  19, "BC", "SK", 17, BowlingCentre.Sherwood), new SaveMatch(new Guid("b197669b-5fa4-4cdd-8a2f-de432ec4f43d"), tournamentId, year, division,  19, "QC", "AB", 19, BowlingCentre.Sherwood), new SaveMatch(new Guid("83825afd-8c20-40b6-a04c-3934561e2ff6"), tournamentId, year, division,  19, "SO", "MB", 21, BowlingCentre.Sherwood), new SaveMatch(new Guid("41f47f61-db67-4b08-985d-f015cc9a643e"), tournamentId, year, division,  19, "NO", "NL", 23, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("cbaa4d22-55e8-40e2-bc70-86997de30c5f"), tournamentId, year, division,  20, "MB", "NL", 17, BowlingCentre.Sherwood), new SaveMatch(new Guid("6616fda2-955d-4202-95a3-c205d3b6c925"), tournamentId, year, division,  20, "NO", "SK", 19, BowlingCentre.Sherwood), new SaveMatch(new Guid("b3a2227b-1c66-4198-814e-ff276dcaa45b"), tournamentId, year, division,  20, "QC", "BC", 21, BowlingCentre.Sherwood), new SaveMatch(new Guid("f27b1fae-212b-4765-b380-1af72976aa87"), tournamentId, year, division,  20, "SO", "AB", 23, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("0621887d-059a-4c01-88f4-677c11d5c290"), tournamentId, year, division,  21, "AB", "BC", 17, BowlingCentre.Sherwood), new SaveMatch(new Guid("4238f722-2a1c-42ba-ab3e-7adec0675023"), tournamentId, year, division,  21, "NL", "SO", 19, BowlingCentre.Sherwood), new SaveMatch(new Guid("f726f4ec-ea54-46c7-ac08-8619e95bef44"), tournamentId, year, division,  21, "MB", "NO", 21, BowlingCentre.Sherwood), new SaveMatch(new Guid("508d1ab1-d9a3-4256-93e4-475017afbe72"), tournamentId, year, division,  21, "SK", "QC", 23, BowlingCentre.Sherwood),
                };

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }

        public static void TournamentMen(MessageDispatcher dispatcher)
        {
            var tournamentId = new Guid("238cbf84-1891-4e19-b467-c3c13442c6bd");
            var year = "2015";
            var division = "Tournament Men";

            var commands = new List<SaveMatch>
                {
                     new SaveMatch(new Guid("ddbea3d0-5e96-40ed-8919-8d802bef9d4f"), tournamentId, year, division,  01, "QC", "BC", 17, BowlingCentre.Sherwood), new SaveMatch(new Guid("135c1711-e8af-4ba6-aa8c-9ae7d4f49c55"), tournamentId, year, division,  01, "MB", "NL", 19, BowlingCentre.Sherwood), new SaveMatch(new Guid("961f2d2c-0375-4a03-b5bd-755866241a97"), tournamentId, year, division,  01, "NO", "SK", 21, BowlingCentre.Sherwood), new SaveMatch(new Guid("d2107c3a-ef8f-4055-a459-9a6c96f67a0d"), tournamentId, year, division,  01, "SO", "AB", 23, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("a35bb9b4-c110-4319-89ea-f07e1d6fbeb0"), tournamentId, year, division,  02, "SK", "AB", 17, BowlingCentre.Sherwood), new SaveMatch(new Guid("5313170a-fff8-4ce0-922e-2160b7c57b33"), tournamentId, year, division,  02, "NO", "SO", 19, BowlingCentre.Sherwood), new SaveMatch(new Guid("8c72aa98-8962-48fc-88cb-3d82be6500ea"), tournamentId, year, division,  02, "BC", "NL", 21, BowlingCentre.Sherwood), new SaveMatch(new Guid("133df404-9bc9-456d-a83a-2cdc2f76e3fd"), tournamentId, year, division,  02, "QC", "MB", 23, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("959d5640-323f-4d01-887c-54d9d7df9ac7"), tournamentId, year, division,  03, "NL", "NO", 17, BowlingCentre.Sherwood), new SaveMatch(new Guid("1fb9e850-1341-4832-82fc-d6eaa729012d"), tournamentId, year, division,  03, "AB", "QC", 19, BowlingCentre.Sherwood), new SaveMatch(new Guid("e9e78ccf-762c-4d65-ac49-c02a59f69ae8"), tournamentId, year, division,  03, "SO", "MB", 21, BowlingCentre.Sherwood), new SaveMatch(new Guid("059446fc-03a8-4c4c-8c0d-b32b4d4619d7"), tournamentId, year, division,  03, "SK", "BC", 23, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("e73585de-59f8-4875-b9bf-e7354e980a8f"), tournamentId, year, division,  04, "MB", "SK", 09, BowlingCentre.Sherwood), new SaveMatch(new Guid("7f28e55d-c15e-42f6-a5b8-3787b5297caa"), tournamentId, year, division,  04, "BC", "SO", 11, BowlingCentre.Sherwood), new SaveMatch(new Guid("32bf137a-6b20-444d-bde2-7d7e25c6108a"), tournamentId, year, division,  04, "QC", "NO", 13, BowlingCentre.Sherwood), new SaveMatch(new Guid("cb1b32c8-6ba8-4429-b8a4-e1a4ca2231ae"), tournamentId, year, division,  04, "AB", "NL", 15, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("0c853162-9745-46af-bd12-c730bf574b45"), tournamentId, year, division,  05, "SO", "QC", 09, BowlingCentre.Sherwood), new SaveMatch(new Guid("d7affac6-476d-4bc3-b5ee-8217086f0546"), tournamentId, year, division,  05, "MB", "AB", 11, BowlingCentre.Sherwood), new SaveMatch(new Guid("b7218824-a404-4c47-bae4-910d5c5c952b"), tournamentId, year, division,  05, "NL", "SK", 13, BowlingCentre.Sherwood), new SaveMatch(new Guid("1948c309-847b-425b-b65a-ac3cff12b21a"), tournamentId, year, division,  05, "NO", "BC", 15, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("450e3ca6-c1de-44f5-be0e-241b43d1b0d2"), tournamentId, year, division,  06, "AB", "NO", 09, BowlingCentre.Sherwood), new SaveMatch(new Guid("34a78b25-75d1-42a1-b9d6-0af843825e7e"), tournamentId, year, division,  06, "NL", "QC", 11, BowlingCentre.Sherwood), new SaveMatch(new Guid("5dce84cc-2676-409e-8f6f-c76cc751d959"), tournamentId, year, division,  06, "BC", "MB", 13, BowlingCentre.Sherwood), new SaveMatch(new Guid("657d958b-7d68-4b00-93a1-3c2f488e4f80"), tournamentId, year, division,  06, "SK", "SO", 15, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("a42cdf1c-b997-4cf9-82eb-1fa0d1ba4238"), tournamentId, year, division,  07, "NL", "SO", 25, BowlingCentre.Sherwood), new SaveMatch(new Guid("e9b93c01-f552-4c7a-869c-ae25710abd2d"), tournamentId, year, division,  07, "SK", "QC", 27, BowlingCentre.Sherwood), new SaveMatch(new Guid("ad02338f-0a21-481d-b900-5b44bbb471c0"), tournamentId, year, division,  07, "AB", "BC", 29, BowlingCentre.Sherwood), new SaveMatch(new Guid("9d2a92e4-38eb-4611-97a4-5fc784a61eb2"), tournamentId, year, division,  07, "MB", "NO", 31, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("ff793aef-e9f4-4388-a0d2-24d0d97b75dc"), tournamentId, year, division,  08, "QC", "AB", 25, BowlingCentre.Sherwood), new SaveMatch(new Guid("e5efb978-3cd2-479e-b35a-71a3de23db27"), tournamentId, year, division,  08, "NO", "NL", 27, BowlingCentre.Sherwood), new SaveMatch(new Guid("13117034-bdbe-4065-8c72-482e779130d9"), tournamentId, year, division,  08, "MB", "SO", 29, BowlingCentre.Sherwood), new SaveMatch(new Guid("0e596e5b-34a3-4079-9602-1f860795bb54"), tournamentId, year, division,  08, "BC", "SK", 31, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("ff921970-f7d0-4d07-913b-d9fcca1cd3d6"), tournamentId, year, division,  09, "SK", "MB", 25, BowlingCentre.Sherwood), new SaveMatch(new Guid("61d031f2-ab7a-4f9b-9fe6-ef41b6f1fbc9"), tournamentId, year, division,  09, "SO", "BC", 27, BowlingCentre.Sherwood), new SaveMatch(new Guid("9027af3a-ead0-42ef-bc8d-31853655caff"), tournamentId, year, division,  09, "NO", "QC", 29, BowlingCentre.Sherwood), new SaveMatch(new Guid("e0b0e5e5-9b25-4887-8917-b627c1b8845c"), tournamentId, year, division,  09, "NL", "AB", 31, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("bd5d89ce-9323-4ea1-9c9d-f3ea9ebdfba6"), tournamentId, year, division,  10, "QC", "SO", 33, BowlingCentre.Sherwood), new SaveMatch(new Guid("b73ed893-6e87-4a03-b2e0-1c2bf1b1248c"), tournamentId, year, division,  10, "BC", "NO", 35, BowlingCentre.Sherwood), new SaveMatch(new Guid("3d7111af-8ede-4dd9-bb78-b70d57257469"), tournamentId, year, division,  10, "SK", "NL", 37, BowlingCentre.Sherwood), new SaveMatch(new Guid("d7d633d0-2564-4f00-baf6-ce02230471b9"), tournamentId, year, division,  10, "AB", "MB", 39, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("64755fd0-efed-443a-9e6e-8fe29c91af7f"), tournamentId, year, division,  11, "NO", "AB", 33, BowlingCentre.Sherwood), new SaveMatch(new Guid("f286f9f6-f7ce-470d-a004-549100ea6bc3"), tournamentId, year, division,  11, "QC", "NL", 35, BowlingCentre.Sherwood), new SaveMatch(new Guid("753d9619-c3eb-40d7-93bd-333a6ba08f76"), tournamentId, year, division,  11, "BC", "MB", 37, BowlingCentre.Sherwood), new SaveMatch(new Guid("0c8dbbf9-5225-4852-9a84-73a3547106b3"), tournamentId, year, division,  11, "SO", "SK", 39, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("1660a0a5-8c96-4ed8-bc7e-0fcd64cfd197"), tournamentId, year, division,  12, "NL", "BC", 33, BowlingCentre.Sherwood), new SaveMatch(new Guid("aa6f63ec-754d-4952-83bf-b3ff39beb9a7"), tournamentId, year, division,  12, "AB", "SK", 35, BowlingCentre.Sherwood), new SaveMatch(new Guid("bd49103a-4627-4c0c-8494-b9534c117e5f"), tournamentId, year, division,  12, "SO", "NO", 37, BowlingCentre.Sherwood), new SaveMatch(new Guid("7fed8660-8993-49c7-b56b-45a0ddd8caf4"), tournamentId, year, division,  12, "MB", "QC", 39, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("5e12dbc3-8eff-4447-83bf-0ae5d482fe42"), tournamentId, year, division,  13, "BC", "QC", 01, BowlingCentre.Sherwood), new SaveMatch(new Guid("8c905bfa-83ad-450a-8695-9d2e0e760d10"), tournamentId, year, division,  13, "NL", "MB", 03, BowlingCentre.Sherwood), new SaveMatch(new Guid("a422973b-df74-4ba1-8c6b-0680ad3fda10"), tournamentId, year, division,  13, "SK", "NO", 05, BowlingCentre.Sherwood), new SaveMatch(new Guid("cba9302c-a134-4b70-8bff-671188fe2c29"), tournamentId, year, division,  13, "AB", "SO", 07, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("2707cc10-2b84-4bf5-878d-3d638128e49a"), tournamentId, year, division,  14, "SO", "NL", 01, BowlingCentre.Sherwood), new SaveMatch(new Guid("b1ea0e53-0f66-4264-b482-fa744016a835"), tournamentId, year, division,  14, "QC", "SK", 03, BowlingCentre.Sherwood), new SaveMatch(new Guid("8c8a38a9-d727-4ab4-84b1-f441d5c2adf1"), tournamentId, year, division,  14, "BC", "AB", 05, BowlingCentre.Sherwood), new SaveMatch(new Guid("ad6d6ba7-ac37-423d-988a-a0b7e8d021df"), tournamentId, year, division,  14, "NO", "MB", 07, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("34eec218-1399-4c22-9677-ebb72e22ae28"), tournamentId, year, division,  15, "SK", "AB", 01, BowlingCentre.Sherwood), new SaveMatch(new Guid("67da740a-2b81-425f-a554-32edc3298d9e"), tournamentId, year, division,  15, "NO", "SO", 03, BowlingCentre.Sherwood), new SaveMatch(new Guid("103a1de5-e7e3-41df-aa0c-f0fd19a3685b"), tournamentId, year, division,  15, "QC", "MB", 05, BowlingCentre.Sherwood), new SaveMatch(new Guid("d5b78078-f42d-4412-be40-0a6e0bf3aa57"), tournamentId, year, division,  15, "BC", "NL", 07, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("57c3deb4-ff96-4bdf-847f-7c5d94a38948"), tournamentId, year, division,  16, "MB", "AB", 41, BowlingCentre.Sherwood), new SaveMatch(new Guid("cebe9aca-5354-42a8-9296-ceb4131f6fb8"), tournamentId, year, division,  16, "NO", "BC", 43, BowlingCentre.Sherwood), new SaveMatch(new Guid("f8f76c62-9c45-41bf-97f0-1fd9bace9073"), tournamentId, year, division,  16, "SO", "QC", 45, BowlingCentre.Sherwood), new SaveMatch(new Guid("19df00a8-1f5e-48fb-acfb-b6ce5a265fbd"), tournamentId, year, division,  16, "NL", "SK", 47, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("688b5d40-7c88-4188-8f1f-94b289d2e03e"), tournamentId, year, division,  17, "NL", "QC", 41, BowlingCentre.Sherwood), new SaveMatch(new Guid("233b1ad6-ea08-4e75-bed4-76f9d45aed7e"), tournamentId, year, division,  17, "SK", "SO", 43, BowlingCentre.Sherwood), new SaveMatch(new Guid("e641eda1-2a82-4fb0-8897-0dd2ec87999e"), tournamentId, year, division,  17, "AB", "NO", 45, BowlingCentre.Sherwood), new SaveMatch(new Guid("5aea39a7-517b-4d51-b3bf-fe178358e4f4"), tournamentId, year, division,  17, "MB", "BC", 47, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("b55e7cea-7345-4b4a-b922-ff5207fc3e26"), tournamentId, year, division,  18, "SO", "BC", 41, BowlingCentre.Sherwood), new SaveMatch(new Guid("96d815cd-4523-4cc4-8aca-bcdc371b1854"), tournamentId, year, division,  18, "AB", "NL", 43, BowlingCentre.Sherwood), new SaveMatch(new Guid("37041f42-f77e-4942-a016-b890ce239d82"), tournamentId, year, division,  18, "MB", "SK", 45, BowlingCentre.Sherwood), new SaveMatch(new Guid("fc080bbf-48da-4eff-8ceb-663bde5d34a0"), tournamentId, year, division,  18, "QC", "NO", 47, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("0182abe1-2440-4eeb-96ac-593c8b599224"), tournamentId, year, division,  19, "NO", "NL", 09, BowlingCentre.Sherwood), new SaveMatch(new Guid("a5e93dde-d8ab-4022-b98c-5518f8910dc6"), tournamentId, year, division,  19, "BC", "SK", 11, BowlingCentre.Sherwood), new SaveMatch(new Guid("0a68883d-5ec0-4221-9a9e-1304a8b46a90"), tournamentId, year, division,  19, "SO", "MB", 13, BowlingCentre.Sherwood), new SaveMatch(new Guid("a627e597-453c-4ea5-9786-812286519ccb"), tournamentId, year, division,  19, "QC", "AB", 15, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("014c4d91-a169-43b2-8031-71a2259e3bfb"), tournamentId, year, division,  20, "QC", "BC", 09, BowlingCentre.Sherwood), new SaveMatch(new Guid("ae3764e8-be04-486f-9abf-e1cb875b00e2"), tournamentId, year, division,  20, "SO", "AB", 11, BowlingCentre.Sherwood), new SaveMatch(new Guid("f0418504-47b0-4724-889a-3d0af43f1ed8"), tournamentId, year, division,  20, "NO", "SK", 13, BowlingCentre.Sherwood), new SaveMatch(new Guid("8ca97d5b-5387-4817-9e83-2ca021d1d248"), tournamentId, year, division,  20, "MB", "NL", 15, BowlingCentre.Sherwood),
                     new SaveMatch(new Guid("6229e593-fff7-45a2-809a-10acd5035a91"), tournamentId, year, division,  21, "NL", "SO", 09, BowlingCentre.Sherwood), new SaveMatch(new Guid("5652e6f2-c290-4c26-a21e-b701d32d55f5"), tournamentId, year, division,  21, "MB", "NO", 11, BowlingCentre.Sherwood), new SaveMatch(new Guid("632f3563-465d-4d4a-94f5-840e11914c45"), tournamentId, year, division,  21, "AB", "BC", 13, BowlingCentre.Sherwood), new SaveMatch(new Guid("f0d6c35e-244d-4efb-86e8-3559c1d37382"), tournamentId, year, division,  21, "SK", "QC", 15, BowlingCentre.Sherwood),
                };

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }

        public static void TeachingLadies(MessageDispatcher dispatcher)
        {
            var tournamentId = new Guid("238cbf84-1891-4e19-b467-c3c13442c6bd");
            var year = "2015";
            var division = "Teaching Ladies";

            var commands = new List<SaveMatch>
                {
                     new SaveMatch(new Guid("fa04a04a-6ba5-44d2-be7b-1c7e1468c49c"), tournamentId, year, division,  01, "QC", "SK", 33, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("f2ccbbad-4efd-42e9-aee5-c672293e7843"), tournamentId, year, division,  01, "SO", "BC", 35, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("bda7d8da-9243-4b26-bf13-d3c0e7240dc3"), tournamentId, year, division,  01, "NO", "NL", 37, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("87c50f55-b1c1-4675-8249-4fcc3c0a1008"), tournamentId, year, division,  01, "MB", "AB", 39, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("da91e05e-2f98-4873-90f5-c058b2df5bf6"), tournamentId, year, division,  02, "NL", "AB", 33, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("dd1cca5e-dcd7-4ee2-8165-ea745707cdba"), tournamentId, year, division,  02, "NO", "MB", 35, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("d7d23960-57f2-41f3-a66b-d1749ed239d4"), tournamentId, year, division,  02, "SK", "BC", 37, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("7b1f5c2a-a894-413f-a74b-90c4efce519e"), tournamentId, year, division,  02, "QC", "SO", 39, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("43f4fed6-9636-44ca-8d59-336ad346a60a"), tournamentId, year, division,  03, "BC", "NO", 33, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("76120d49-6696-4384-ba26-8563b28a0dc0"), tournamentId, year, division,  03, "AB", "QC", 35, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("a66d1c41-e241-474c-b961-efe9c2e8844d"), tournamentId, year, division,  03, "MB", "SO", 37, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("a59f998e-57bf-40e4-ba40-c93b7039ec23"), tournamentId, year, division,  03, "NL", "SK", 39, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("971d16a0-6222-4a98-ab56-b9404c9410a4"), tournamentId, year, division,  04, "SO", "NL", 33, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("11caaa61-28c5-4037-a40d-f39269f0964e"), tournamentId, year, division,  04, "SK", "MB", 35, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("5be0fcf8-1512-43dc-81af-3848c8ea6f97"), tournamentId, year, division,  04, "QC", "NO", 37, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("97cdd5f5-61e1-42ad-9497-7dc3dd816399"), tournamentId, year, division,  04, "AB", "BC", 39, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("23862c13-0cd9-46f5-b675-dc4452c1b083"), tournamentId, year, division,  05, "MB", "QC", 25, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("9191b6ec-83db-4758-b02b-9cd0de79d868"), tournamentId, year, division,  05, "BC", "NL", 27, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("be81ac3c-41dd-41a6-8b03-f47306136c4c"), tournamentId, year, division,  05, "SO", "AB", 29, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("a44756a0-2639-4d90-8644-8ea8ff8955d5"), tournamentId, year, division,  05, "NO", "SK", 31, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("51f9fcb3-9179-4090-9277-cc7d1e472a0c"), tournamentId, year, division,  06, "SK", "SO", 25, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("5e730acd-d12e-4bcc-b3ee-339572bc76f6"), tournamentId, year, division,  06, "AB", "NO", 27, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("090b13e1-d4d7-4baa-a0f9-c3cff8ea6094"), tournamentId, year, division,  06, "BC", "QC", 29, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("3d0ac0f4-2a9a-410e-abcf-42e0b4113456"), tournamentId, year, division,  06, "NL", "MB", 31, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("40de0ad1-bdc5-490c-a24a-7077264f8cd9"), tournamentId, year, division,  07, "AB", "SK", 09, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("7d5b2051-eec2-4d75-9fc5-ca054edaa19e"), tournamentId, year, division,  07, "SO", "NO", 11, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("05e6da3e-4e7a-46bb-b10c-8f2956f0b4da"), tournamentId, year, division,  07, "QC", "NL", 13, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("c400d3d3-e8f9-4735-8668-a3f3abc55c0d"), tournamentId, year, division,  07, "BC", "MB", 15, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("4105f870-23d8-442a-9b5a-044f8d779cb5"), tournamentId, year, division,  08, "NO", "BC", 09, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("7722a5b8-d3ed-4443-a220-b685b40e4bf2"), tournamentId, year, division,  08, "QC", "AB", 11, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("e5bc9dfe-192f-40d1-a3a5-885b270b049b"), tournamentId, year, division,  08, "SO", "MB", 13, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("11d01ea9-2a70-4a83-a8be-4c91de06a90b"), tournamentId, year, division,  08, "SK", "NL", 15, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("11f4bebe-7ff5-4b0c-a39f-09d9a97ecabf"), tournamentId, year, division,  09, "NL", "SO", 09, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("4cb023e9-9a75-47e7-bd47-2b70c43b6e46"), tournamentId, year, division,  09, "MB", "SK", 11, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("ebb024fb-8375-4aaa-94e4-1b795661925b"), tournamentId, year, division,  09, "BC", "AB", 13, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("266b1f5b-9c4a-412c-a15b-f8bcf261e538"), tournamentId, year, division,  09, "NO", "QC", 15, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("d91ee397-5b85-4404-8b5b-fb84d57c4d06"), tournamentId, year, division,  10, "MB", "QC", 09, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("71dcbf9a-9347-48c9-8827-05867ad1ad57"), tournamentId, year, division,  10, "NL", "BC", 11, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("c3524263-ab87-4f3d-8168-d0292ee9176e"), tournamentId, year, division,  10, "SK", "NO", 13, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("527646fc-6d0e-48af-8788-b9db2f8046ed"), tournamentId, year, division,  10, "AB", "SO", 15, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("5cf43759-400a-4c85-94d8-1550d66d2d78"), tournamentId, year, division,  11, "SO", "SK", 01, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("ced3bdee-17ab-4dff-8b67-fc8ee4e54574"), tournamentId, year, division,  11, "NO", "AB", 03, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("d14d5ef8-3183-4f2f-b5a2-0ec2ceea2d7f"), tournamentId, year, division,  11, "QC", "BC", 05, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("1b016f6c-fec9-40ae-837d-87f8f6b17cbd"), tournamentId, year, division,  11, "MB", "NL", 07, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("b583a912-682b-4e32-9c8a-db63dfd2fe27"), tournamentId, year, division,  12, "AB", "MB", 01, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("44f88164-819d-4c0c-88e9-5063d282f64b"), tournamentId, year, division,  12, "SK", "QC", 03, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("1fb56de6-2929-403b-b243-88f2b14863b1"), tournamentId, year, division,  12, "NL", "NO", 05, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("4e7e3070-6e07-4f93-ba67-db1187242a4c"), tournamentId, year, division,  12, "BC", "SO", 07, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("7cfbde4a-0add-4ed5-922f-a2de2a60c9a9"), tournamentId, year, division,  13, "NO", "SO", 17, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("4ca61a53-aa9a-4cb5-8778-0a5e3686e124"), tournamentId, year, division,  13, "NL", "QC", 19, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("8af4523c-92ee-4b22-8575-81739412bf1b"), tournamentId, year, division,  13, "SK", "AB", 21, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("b0988315-5623-44ba-8e59-7ea21b1ffe10"), tournamentId, year, division,  13, "MB", "BC", 23, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("a949b921-b4f4-4192-982e-a8376b730860"), tournamentId, year, division,  14, "AB", "NL", 17, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("39b7a868-b2f9-4016-ab68-3a66b5d7c387"), tournamentId, year, division,  14, "BC", "SK", 19, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("76d9d76a-bb97-4c36-8f10-f2b9d7baf37a"), tournamentId, year, division,  14, "MB", "NO", 21, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("2019d3e9-e8aa-420a-a0fd-5e5f9ffaed8c"), tournamentId, year, division,  14, "SO", "QC", 23, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("6b23693d-0189-45e5-b62d-e16a5c8f4862"), tournamentId, year, division,  15, "QC", "MB", 17, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("88ec391e-f3ec-4e40-95c2-f6db04f7e7b4"), tournamentId, year, division,  15, "SO", "AB", 19, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("6dd0c298-4acc-4992-8025-80ac7872db55"), tournamentId, year, division,  15, "BC", "NL", 21, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("0f037a1b-1207-4108-bed1-b104efae8a32"), tournamentId, year, division,  15, "NO", "SK", 23, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("2f0c3427-aad0-4879-a96e-49541ac00d43"), tournamentId, year, division,  16, "AB", "NO", 17, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("a792372a-2b11-413c-bcfc-fe69c0a33936"), tournamentId, year, division,  16, "BC", "QC", 19, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("adf4943c-390b-4abf-9c50-01107993e99d"), tournamentId, year, division,  16, "SK", "SO", 21, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("f55d29d2-b47f-44be-930d-e79d6d634a7c"), tournamentId, year, division,  16, "NL", "MB", 23, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("8ca936fe-6c11-425c-b7a3-1dfe820e2680"), tournamentId, year, division,  17, "MB", "SO", 33, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("859c9e94-54a3-4c48-8cab-1a5b5d2bf95d"), tournamentId, year, division,  17, "SK", "NL", 35, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("bab16c5c-d053-4d2d-84c8-1f2f9bfa3284"), tournamentId, year, division,  17, "QC", "AB", 37, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("53201d1d-aa4a-4ec5-9cb4-b0d4c468ca6f"), tournamentId, year, division,  17, "NO", "BC", 39, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("0df8d139-8f92-4ae6-aca7-947fe6ff7b6d"), tournamentId, year, division,  18, "AB", "BC", 33, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("cb9baf28-dea9-4524-8d43-d66a0f1d8b27"), tournamentId, year, division,  18, "QC", "NO", 35, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("d2d19795-d0bf-4659-8edb-49be372df742"), tournamentId, year, division,  18, "SO", "NL", 37, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("96de44eb-e7f9-47f5-9bcb-53a9c89b13dc"), tournamentId, year, division,  18, "MB", "SK", 39, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("7cedea47-ab5e-4691-8866-c6d1a2b2537c"), tournamentId, year, division,  19, "NL", "AB", 25, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("4a90a9a7-0627-4686-a112-a9fcc37bfb28"), tournamentId, year, division,  19, "NO", "MB", 27, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("7594f3e8-1ef5-48d9-9953-674d73b1a993"), tournamentId, year, division,  19, "QC", "SO", 29, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("706f157f-b1f7-4e16-9306-6d75a3fbaf84"), tournamentId, year, division,  19, "SK", "BC", 31, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("ef211758-ebb9-432a-a043-7d23d1b85ab3"), tournamentId, year, division,  20, "QC", "SK", 25, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("34315abe-e108-43ec-8976-32cd3b9c3e5b"), tournamentId, year, division,  20, "SO", "BC", 27, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("1c9c5dbf-d405-4e16-b131-9a71c3a96338"), tournamentId, year, division,  20, "NO", "NL", 29, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("c24f3853-8497-4bf8-a507-70cf68a828fa"), tournamentId, year, division,  20, "MB", "AB", 31, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("6f1f94fd-6ef3-48e0-83cf-916d004b43bf"), tournamentId, year, division,  21, "SO", "NO", 25, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("1c0a056f-893b-435c-8ee7-a9c87b43e4a8"), tournamentId, year, division,  21, "AB", "SK", 27, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("1da49c7d-4771-4643-9ed6-7fe98c8301fd"), tournamentId, year, division,  21, "BC", "MB", 29, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("7bc588c2-be8f-4939-ae4c-0309086ea0a6"), tournamentId, year, division,  21, "NL", "QC", 31, BowlingCentre.Sherwood, true),
                };

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }

        public static void TeachingMen(MessageDispatcher dispatcher)
        {
            var tournamentId = new Guid("238cbf84-1891-4e19-b467-c3c13442c6bd");
            var year = "2015";
            var division = "Teaching Men";

            var commands = new List<SaveMatch>
                {
                     new SaveMatch(new Guid("52583069-06eb-4b47-aba1-fcdbcc785f4b"), tournamentId, year, division,  01, "QC", "SK", 25, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("4fae70c4-48a5-4551-8b61-49d9c29b987b"), tournamentId, year, division,  01, "SO", "BC", 27, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("d81593cd-12a2-4534-8898-b3b86e34f15b"), tournamentId, year, division,  01, "NO", "NL", 29, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("3248e5ea-7f48-44b7-bd6b-941f98c9374b"), tournamentId, year, division,  01, "MB", "AB", 31, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("4f2e2903-ace7-4d44-8d41-d6a15678acbf"), tournamentId, year, division,  02, "NL", "AB", 25, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("873b943f-08b4-4840-b31f-0a1291bea8fc"), tournamentId, year, division,  02, "NO", "MB", 27, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("13cc3763-d8d8-4eb0-8bf0-1154c7ff4502"), tournamentId, year, division,  02, "SK", "BC", 29, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("b407f6ba-f283-4c56-a23b-83aa57018466"), tournamentId, year, division,  02, "QC", "SO", 31, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("7f71db75-66d5-4329-8bf7-b992c92ff3a2"), tournamentId, year, division,  03, "BC", "NO", 25, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("c9aebfd5-ac33-4eca-b5de-1020e8d90b0a"), tournamentId, year, division,  03, "AB", "QC", 27, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("6343efb3-5466-4ab2-a72b-cd81aa73c754"), tournamentId, year, division,  03, "MB", "SO", 29, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("561e63a5-50a5-440e-9498-76f4d15b7e36"), tournamentId, year, division,  03, "NL", "SK", 31, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("081d42ad-6a28-4645-af5b-db17735b448c"), tournamentId, year, division,  04, "SO", "NL", 25, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("6b49b880-efdf-45a4-a028-00252dcd664a"), tournamentId, year, division,  04, "SK", "MB", 27, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("9f1dc4f8-2d7c-4d53-861b-3eb84fcba767"), tournamentId, year, division,  04, "QC", "NO", 29, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("03b0d6c1-60c2-4161-a26a-41ca1633d529"), tournamentId, year, division,  04, "AB", "BC", 31, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("85c4927f-5fd4-42e7-bddf-67aeba8b2e81"), tournamentId, year, division,  05, "BC", "NL", 33, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("7c5f3570-72d7-4ac2-9e5d-7b27fb8ba92d"), tournamentId, year, division,  05, "MB", "QC", 35, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("a3d75e4c-eb31-486e-855f-55ef4be58075"), tournamentId, year, division,  05, "NO", "SK", 37, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("9e0ff088-a9b6-41cd-b441-895fe4777685"), tournamentId, year, division,  05, "SO", "AB", 39, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("9a574969-eb7b-4894-9bc8-71d720d9379c"), tournamentId, year, division,  06, "AB", "NO", 33, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("2c731b3a-c50f-47d9-a9bb-645c5b308b27"), tournamentId, year, division,  06, "SK", "SO", 35, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("a5d6ba1e-c12d-4b08-a012-50dde658eee1"), tournamentId, year, division,  06, "BC", "QC", 37, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("37ee58c0-4549-432c-ae02-bc5dd1cb50c4"), tournamentId, year, division,  06, "NL", "MB", 39, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("daa2b8dc-ab50-47e9-9223-b7311e178447"), tournamentId, year, division,  07, "AB", "SK", 41, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("727ce56b-2a59-4467-a16c-15fc3ae3da27"), tournamentId, year, division,  07, "SO", "NO", 43, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("e90c2884-8e59-4410-bb4d-ecd81bca107f"), tournamentId, year, division,  07, "QC", "NL", 45, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("fb294ecd-d002-4fd0-b1a2-b97d22aeb759"), tournamentId, year, division,  07, "BC", "MB", 47, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("6a1c5deb-632a-492e-9347-b55f5155a382"), tournamentId, year, division,  08, "NO", "BC", 41, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("87d24759-2e46-45fd-9b12-c3b1cec21075"), tournamentId, year, division,  08, "QC", "AB", 43, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("38cd4cb7-9326-4d1a-928d-a092c1f7144c"), tournamentId, year, division,  08, "SO", "MB", 45, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("3cbf3a68-1bf1-494f-91b7-6f55ad7d4c9e"), tournamentId, year, division,  08, "SK", "NL", 47, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("94c593ad-6120-4082-b9a2-b84fd668b780"), tournamentId, year, division,  09, "NL", "SO", 41, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("b2e0aee4-4425-491d-87fd-f832962da42c"), tournamentId, year, division,  09, "MB", "SK", 43, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("59448f6d-331f-4a4b-8e65-00b4baf0bc7e"), tournamentId, year, division,  09, "BC", "AB", 45, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("492f7e4e-9bbc-4e21-b62a-896dd2e2b077"), tournamentId, year, division,  09, "NO", "QC", 47, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("9b89aeed-b739-4767-a213-e847db6f221f"), tournamentId, year, division,  10, "MB", "QC", 41, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("33eb83c0-1743-4355-a6d9-e95be1322110"), tournamentId, year, division,  10, "NL", "BC", 43, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("661a0321-324d-44d1-a9d9-e10499b2c514"), tournamentId, year, division,  10, "SK", "NO", 45, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("5080e99e-b8ed-4384-abd0-863cf5adb94a"), tournamentId, year, division,  10, "AB", "SO", 47, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("b3d03545-b976-4fd1-a6b4-6c165fc5fed4"), tournamentId, year, division,  11, "SO", "SK", 09, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("611dd9dc-4111-4b22-a378-3d74ebf8348d"), tournamentId, year, division,  11, "NO", "AB", 11, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("e29a7136-9ecd-4d95-bcd9-d1b1052a0bf8"), tournamentId, year, division,  11, "QC", "BC", 13, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("f06671d2-2759-441d-b2d1-220a8fc7a617"), tournamentId, year, division,  11, "MB", "NL", 15, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("9c84954a-02b3-4338-88ad-cb06c326e4fb"), tournamentId, year, division,  12, "AB", "MB", 09, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("c3804948-5972-47c4-a44c-a5a6f86d4d1a"), tournamentId, year, division,  12, "BC", "SO", 11, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("ca9e47c8-f5c0-451d-997d-bca57f9ec802"), tournamentId, year, division,  12, "NL", "NO", 13, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("7c39ca87-4ab3-4deb-b38a-32e16fc70242"), tournamentId, year, division,  12, "SK", "QC", 15, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("49f81132-8db9-48ce-afde-981d92d6bdfd"), tournamentId, year, division,  13, "NO", "SO", 33, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("6cb70385-974a-4881-8654-38436e73fc51"), tournamentId, year, division,  13, "SK", "AB", 35, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("05ddb345-ce51-468c-a371-2e42fbcba6f2"), tournamentId, year, division,  13, "NL", "QC", 37, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("c43c27b1-ac06-4fa6-bc45-749979ca3344"), tournamentId, year, division,  13, "MB", "BC", 39, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("7291a87c-ac06-400b-9fcd-1ea9f1583c87"), tournamentId, year, division,  14, "BC", "SK", 33, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("82ad277a-3221-4db4-8ee2-002534814a0b"), tournamentId, year, division,  14, "SO", "QC", 35, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("10635efc-fde4-4fad-a711-859e0967051d"), tournamentId, year, division,  14, "MB", "NO", 37, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("4326dc53-3e11-44c2-b6ec-94a6749e43bd"), tournamentId, year, division,  14, "AB", "NL", 39, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("ebcd2d2a-7430-4aaf-a5b6-bae7bfe27ac5"), tournamentId, year, division,  15, "QC", "MB", 33, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("28e1e9ae-3202-449c-8602-04e0774aef83"), tournamentId, year, division,  15, "BC", "NL", 35, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("782e9771-dcde-4a00-a889-625bbc703697"), tournamentId, year, division,  15, "SO", "AB", 37, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("63577ee6-0cad-4eb7-9a50-45120b3a4310"), tournamentId, year, division,  15, "NO", "SK", 39, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("c4168641-1f44-41f9-be02-e6a6a702fd0a"), tournamentId, year, division,  16, "SK", "SO", 33, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("c5b4800c-b3b7-4ef7-9d35-d595bc849db6"), tournamentId, year, division,  16, "AB", "NO", 35, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("4fa93a44-beb9-49ec-859b-303f772899ab"), tournamentId, year, division,  16, "NL", "MB", 37, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("a7d65f48-1586-4f84-bafe-91a630f51046"), tournamentId, year, division,  16, "BC", "QC", 39, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("0401c4fc-bfde-4739-a184-48ec465be0ba"), tournamentId, year, division,  17, "NO", "BC", 17, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("84d7c6ee-21eb-4c41-b0a9-708a31f9414d"), tournamentId, year, division,  17, "QC", "AB", 19, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("088f0dd5-92db-462d-ac1d-38385683c9ff"), tournamentId, year, division,  17, "MB", "SO", 21, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("978ad481-713a-4b9e-b330-63e7f1e8e740"), tournamentId, year, division,  17, "SK", "NL", 23, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("5c235ad1-c898-4f22-82f7-efb97e9d5dfb"), tournamentId, year, division,  18, "SO", "NL", 17, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("fae438c6-48a4-4a67-ae61-e5fa111301c9"), tournamentId, year, division,  18, "MB", "SK", 19, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("79748ce8-6fed-4aca-a3d5-3f52d752ee31"), tournamentId, year, division,  18, "QC", "NO", 21, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("70360e8d-e9ca-4b1e-9786-b1a0a2cc98b5"), tournamentId, year, division,  18, "AB", "BC", 23, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("e5dfc1f5-8537-4e23-9131-0838b3a900e0"), tournamentId, year, division,  19, "NL", "AB", 01, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("a98fed7a-cf3a-4738-b2d4-4bc09736265d"), tournamentId, year, division,  19, "NO", "MB", 03, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("7f031b41-7985-4d40-ae13-8f6d4a4a7a1b"), tournamentId, year, division,  19, "QC", "SO", 05, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("1395d748-cc8e-4f04-b9ae-f98ffb031569"), tournamentId, year, division,  19, "SK", "BC", 07, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("f0066c8b-8157-4049-b84c-c309a2354004"), tournamentId, year, division,  20, "QC", "SK", 01, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("a20f0228-2b24-4084-9508-3e4fdec89647"), tournamentId, year, division,  20, "SO", "BC", 03, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("e444188d-c7c6-45e5-b0c7-1cb2f88e78c5"), tournamentId, year, division,  20, "NO", "NL", 05, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("2b0392e9-5144-41e9-ae9b-8ab16dfd1652"), tournamentId, year, division,  20, "MB", "AB", 07, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("aaa27e06-7853-4aa2-abc9-336db2a62e04"), tournamentId, year, division,  21, "SO", "NO", 01, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("8a7da5fe-7a08-48f1-ab5f-604840feb44f"), tournamentId, year, division,  21, "AB", "SK", 03, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("f26e0f0b-d96f-4cea-8d61-00ca9f43a90f"), tournamentId, year, division,  21, "BC", "MB", 05, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("da6c681f-f80c-4353-a581-7a589e0f78fa"), tournamentId, year, division,  21, "NL", "QC", 07, BowlingCentre.Sherwood, true),
                };

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }

        public static void Seniors(MessageDispatcher dispatcher)
        {
            var tournamentId = new Guid("238cbf84-1891-4e19-b467-c3c13442c6bd");
            var year = "2015";
            var division = "Seniors";

            var commands = new List<SaveMatch>
                {
                     new SaveMatch(new Guid("ca6e7c1e-2a3a-4aa5-b32c-3731b5c46f8e"), tournamentId, year, division,  01, "QC", "NL", 41, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("47394f9c-b46d-4fc7-964e-38473f0fb78f"), tournamentId, year, division,  01, "SO", "MB", 43, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("05b6442e-1cce-49ff-beaa-99564a47cc50"), tournamentId, year, division,  01, "NO", "BC", 45, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("36057272-d799-4d13-918f-0f3820eeb76d"), tournamentId, year, division,  01, "AB", "SK", 47, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("7b7e3ece-8d50-4b66-be30-7cc27abf6512"), tournamentId, year, division,  02, "BC", "SK", 41, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("9d6bb445-f34d-4d8d-b702-ffda35a26ab6"), tournamentId, year, division,  02, "NO", "AB", 43, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("2ec5e1a8-9004-4a43-bcac-e6bfc89fa9b5"), tournamentId, year, division,  02, "NL", "MB", 45, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("e34da098-58b5-4661-a13f-112051dcbcb0"), tournamentId, year, division,  02, "QC", "SO", 47, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("4c286266-6846-4c6e-a0ed-b4ba1e33e3c7"), tournamentId, year, division,  03, "MB", "NO", 41, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("d984e9a3-703d-482f-8801-152b77b3a636"), tournamentId, year, division,  03, "SK", "QC", 43, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("2fcc302b-50f2-47a6-adc3-1a4e92dc08ea"), tournamentId, year, division,  03, "AB", "SO", 45, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("1819c6cb-4793-473b-82f5-fa9b4f6132e8"), tournamentId, year, division,  03, "BC", "NL", 47, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("704d246e-1925-47df-9f76-7a82831c53ed"), tournamentId, year, division,  04, "SO", "BC", 41, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("03870cb2-e0d3-46d2-91ca-edbb8ccd39f5"), tournamentId, year, division,  04, "NL", "AB", 43, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("7eb0527d-6226-4744-88f0-85098ff2f0aa"), tournamentId, year, division,  04, "QC", "NO", 45, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("dd27eb33-f9a8-4f2f-afa3-60fc736d251c"), tournamentId, year, division,  04, "SK", "MB", 47, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("22c81a90-24d4-4a02-b8a3-ad72a6195030"), tournamentId, year, division,  05, "AB", "QC", 41, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("8a42bece-5e49-4dd4-b58c-5b7f9c3d1494"), tournamentId, year, division,  05, "MB", "BC", 43, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("262eae56-a85b-4517-b20b-ebb4ecae4b6b"), tournamentId, year, division,  05, "SO", "SK", 45, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("f3ab901d-9a9d-4b4a-bbee-7c5bace99e53"), tournamentId, year, division,  05, "NO", "NL", 47, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("d5f85a70-9d25-4d9e-8f09-6c3b015b6d35"), tournamentId, year, division,  06, "NL", "SO", 41, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("a6c859de-0953-409a-8195-c9d0662bc91d"), tournamentId, year, division,  06, "SK", "NO", 43, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("b10eff15-a39d-4765-be74-0d51e5425941"), tournamentId, year, division,  06, "MB", "QC", 45, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("6c511096-b847-4a17-9bdc-c0ed2b9c03ed"), tournamentId, year, division,  06, "BC", "AB", 47, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("08eb9423-604a-49fb-88d7-1626e7e49a70"), tournamentId, year, division,  07, "MB", "AB", 01, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("04457c2b-6504-4a70-a8ab-f608d84d3738"), tournamentId, year, division,  07, "BC", "QC", 03, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("d4f00e10-5cbe-46de-877a-7dee3ac24bbc"), tournamentId, year, division,  07, "SK", "NL", 05, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("45d727d4-0272-4c73-b690-e89eab2531a5"), tournamentId, year, division,  07, "SO", "NO", 07, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("59f8f640-aa53-4c0a-943a-8bd0127a6533"), tournamentId, year, division,  08, "QC", "SK", 01, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("dc825f5a-769b-42b0-b0cf-f7968a3e59a7"), tournamentId, year, division,  08, "NO", "MB", 03, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("469230ba-74c2-4317-837f-4ebc7b50ef93"), tournamentId, year, division,  08, "SO", "AB", 05, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("f23531f2-e918-4a8a-85da-c9b81ccf8bbe"), tournamentId, year, division,  08, "NL", "BC", 07, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("2d84b6b9-eae6-436d-a798-1b090bedf2b5"), tournamentId, year, division,  09, "BC", "SO", 01, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("a87a44ed-8973-4786-ad3c-f0894f42b245"), tournamentId, year, division,  09, "AB", "NL", 03, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("de9f750e-a62e-4aa5-8c9c-926be2381370"), tournamentId, year, division,  09, "NO", "QC", 05, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("bf21d3fb-07b0-471b-b94d-acedabfa1b56"), tournamentId, year, division,  09, "MB", "SK", 07, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("e8a8e67f-da82-45c1-bdbc-efcc30913023"), tournamentId, year, division,  10, "BC", "MB", 17, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("3971ff48-96c9-49b7-9d44-cfa9a3c5218c"), tournamentId, year, division,  10, "QC", "AB", 19, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("595bd46c-c285-4909-8456-160b8437e222"), tournamentId, year, division,  10, "SK", "SO", 21, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("26f99517-9078-48cb-848b-3deb073b58d7"), tournamentId, year, division,  10, "NL", "NO", 23, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("422a81b6-33da-4a0a-b83d-0a9407ae1abc"), tournamentId, year, division,  11, "NO", "SK", 17, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("aecd4c00-683e-40fa-8505-569063192647"), tournamentId, year, division,  11, "SO", "NL", 19, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("74fb5b87-ea00-4720-aefd-644ec8c86001"), tournamentId, year, division,  11, "AB", "BC", 21, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("90ded297-a2a9-46fd-9998-bd0936b66ce2"), tournamentId, year, division,  11, "QC", "MB", 23, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("0d66f900-4d26-41e2-9b67-65b8bc2de526"), tournamentId, year, division,  12, "MB", "SO", 17, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("efdb6eed-e9d5-4eeb-baa5-afade84b4409"), tournamentId, year, division,  12, "BC", "NO", 19, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("7124923a-c379-40e0-8db0-f0cf3aa728f9"), tournamentId, year, division,  12, "NL", "QC", 21, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("70719f4a-ba99-43fa-a447-63d016fe751c"), tournamentId, year, division,  12, "SK", "AB", 23, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("ccf4f261-c268-4f14-864a-bfa2b3cee28b"), tournamentId, year, division,  13, "NL", "SK", 09, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("8d3b13ef-82aa-403d-8844-1ead50e74e44"), tournamentId, year, division,  13, "QC", "BC", 11, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("5ddc565a-1dce-4fe4-86ce-108743c3db66"), tournamentId, year, division,  13, "AB", "MB", 13, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("8e7189e6-2240-4763-913f-ca40c09330d1"), tournamentId, year, division,  13, "NO", "SO", 15, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("7236af39-06c9-46e7-928a-35ac8e62ea52"), tournamentId, year, division,  14, "SO", "QC", 09, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("14b38324-baf5-417e-9a62-a668d9d96e58"), tournamentId, year, division,  14, "AB", "NO", 11, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("d7b5b05a-5780-4942-873e-ccc50c96e1a0"), tournamentId, year, division,  14, "SK", "BC", 13, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("e0792705-42d5-406e-bd6d-d06d97938697"), tournamentId, year, division,  14, "MB", "NL", 15, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("4d931eef-9a62-4b6b-ade8-0d8719746210"), tournamentId, year, division,  15, "BC", "AB", 09, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("8fa1f116-96e6-4843-8be1-071149551e92"), tournamentId, year, division,  15, "MB", "QC", 11, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("9ec59638-096a-4539-bb18-75b24cf74033"), tournamentId, year, division,  15, "NL", "SO", 13, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("5a9d8813-747f-4da6-9233-80059d555837"), tournamentId, year, division,  15, "SK", "NO", 15, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("5bf6fbef-970a-4183-a9f3-aaefeb4d3af5"), tournamentId, year, division,  16, "NO", "MB", 09, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("306254e4-5a0a-4ea9-ad7d-fef0e83d0caa"), tournamentId, year, division,  16, "AB", "SO", 11, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("29a942b9-34a4-43e8-bfb4-4d4d3404ca31"), tournamentId, year, division,  16, "QC", "SK", 13, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("275184af-722b-44d4-88a2-c79f662fc571"), tournamentId, year, division,  16, "NL", "BC", 15, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("10b7753a-56b8-48f8-b4d4-ea08a5fcd1fa"), tournamentId, year, division,  17, "SO", "SK", 09, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("cc338039-7008-4b77-89e0-e70da95c923c"), tournamentId, year, division,  17, "NO", "NL", 11, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("9261f594-dd1a-4da7-b6d5-cf2db835bd18"), tournamentId, year, division,  17, "MB", "BC", 13, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("357a1a21-c3ec-43c9-bce5-70e72babc6b1"), tournamentId, year, division,  17, "AB", "QC", 15, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("5ebaf28b-cd3d-43f3-99e1-477e5870000f"), tournamentId, year, division,  18, "AB", "NL", 09, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("a9f75c46-8d2d-474d-a9de-a6fa34ed64be"), tournamentId, year, division,  18, "SK", "MB", 11, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("73d91f53-1f80-4f74-9e08-792d61fa0113"), tournamentId, year, division,  18, "QC", "NO", 13, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("be7822db-a1b6-4dbc-bb73-4e25fe321cba"), tournamentId, year, division,  18, "SO", "BC", 15, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("b098d403-5158-4bae-b827-24c78609f323"), tournamentId, year, division,  19, "BC", "SK", 33, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("eedc6f89-b4d7-4037-a27f-37810c540f1e"), tournamentId, year, division,  19, "NO", "AB", 35, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("d6c548f4-5d9b-46ca-bac0-2e9e7dc5bd51"), tournamentId, year, division,  19, "QC", "SO", 37, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("8d89dcc2-296e-4fc1-9dc3-cf694f4ae2a3"), tournamentId, year, division,  19, "NL", "MB", 39, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("a77a0216-6332-4adf-81b8-ac14f550350d"), tournamentId, year, division,  20, "QC", "NL", 33, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("eb538110-fef1-41fe-ad59-7c659e716473"), tournamentId, year, division,  20, "SO", "MB", 35, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("30df27f8-87e1-4879-aae4-c545585ad8d5"), tournamentId, year, division,  20, "NO", "BC", 37, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("a6f10c62-13eb-445b-bd1c-746dfa6bb498"), tournamentId, year, division,  20, "AB", "SK", 39, BowlingCentre.Sherwood, true),
                     new SaveMatch(new Guid("6cc61753-6201-49e2-a514-c67b7437729a"), tournamentId, year, division,  21, "SO", "NO", 33, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("b62d1f25-9afe-41f0-8de2-6dad79a9813e"), tournamentId, year, division,  21, "SK", "NL", 35, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("449a3398-7434-417c-bebd-9905a2cf0a9c"), tournamentId, year, division,  21, "MB", "AB", 37, BowlingCentre.Sherwood, true), new SaveMatch(new Guid("658d3723-1b65-4ac5-a4ab-a25ca1edf6d9"), tournamentId, year, division,  21, "BC", "QC", 39, BowlingCentre.Sherwood, true),
                };

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }
    }
    */

    /*
    public static class ScheduleBuilder2014
    {
        public static void TournamentMenSingle(MessageDispatcher dispatcher)
        {
            var scheduleId = new Guid("defd5a4a-4896-4eac-ba16-4e1302bec46b");
            var division = "Tournament Men Single";

            var commands = new List<SaveMatch>
                {
                     new SaveMatch(new Guid("56ca5e66-9699-42fd-b5c5-a141c4c2f86d"), tournamentId, year, division,  01, "SO", "AB", 1, BowlingCentre.Rossmere),   new SaveMatch(new Guid("85209746-7fd8-4af3-ac11-79ec1bafc8d0"), tournamentId, year, division,  01, "NO", "MB", 3, BowlingCentre.Rossmere),   new SaveMatch(new Guid("ddc437fc-4760-4a21-8d81-882960a8218a"), tournamentId, year, division,  01, "BC", "NL", 5, BowlingCentre.Rossmere),   new SaveMatch(new Guid("c6d51abb-3618-4c0d-a3bc-436757677b2c"), tournamentId, year, division,  01, "QC", "SK", 7, BowlingCentre.Rossmere), 
                     new SaveMatch(new Guid("d4174f7c-bd4c-40e7-a33b-f6cfafc6780d"), tournamentId, year, division,  02, "BC", "SK", 1, BowlingCentre.Rossmere),   new SaveMatch(new Guid("0b2c7722-b045-45e5-9a73-63b4f20d0d1d"), tournamentId, year, division,  02, "NL", "QC", 3, BowlingCentre.Rossmere),   new SaveMatch(new Guid("548db1a7-2ef5-40a6-a6d6-57cbdf2344cd"), tournamentId, year, division,  02, "MB", "SO", 5, BowlingCentre.Rossmere),   new SaveMatch(new Guid("db574d9f-c7a2-4fff-bce5-6a997d0a2ca0"), tournamentId, year, division,  02, "AB", "NO", 7, BowlingCentre.Rossmere), 
                     new SaveMatch(new Guid("87106ecf-0aad-4898-86ed-48e5a58ec93f"), tournamentId, year, division,  03, "NL", "NO", 1, BowlingCentre.Rossmere),   new SaveMatch(new Guid("cb8a770f-2181-4d57-b783-760e937d12af"), tournamentId, year, division,  03, "SK", "SO", 3, BowlingCentre.Rossmere),   new SaveMatch(new Guid("32e967c5-85fc-466c-bb1d-0680460b9a08"), tournamentId, year, division,  03, "QC", "AB", 5, BowlingCentre.Rossmere),   new SaveMatch(new Guid("5e002afb-5cf3-4bab-ac40-3feb9084df5c"), tournamentId, year, division,  03, "MB", "BC", 7, BowlingCentre.Rossmere), 
                     new SaveMatch(new Guid("93e5ee03-ab14-4460-ae6e-82793f6c6960"), tournamentId, year, division,  04, "QC", "MB", 1, BowlingCentre.Rossmere),   new SaveMatch(new Guid("b20f7625-4ad0-4ede-9c69-15ccf9c43b95"), tournamentId, year, division,  04, "AB", "BC", 3, BowlingCentre.Rossmere),   new SaveMatch(new Guid("5bc18a6a-f462-4820-ad36-5229457fbf42"), tournamentId, year, division,  04, "NO", "SK", 5, BowlingCentre.Rossmere),   new SaveMatch(new Guid("5a7a77d1-5f6c-418a-aed9-5f5fad6e3035"), tournamentId, year, division,  04, "SO", "NL", 7, BowlingCentre.Rossmere), 
                     new SaveMatch(new Guid("953e6064-e396-4945-b3f9-e093148cb4d6"), tournamentId, year, division,  05, "SK", "AB", 1, BowlingCentre.Rossmere),   new SaveMatch(new Guid("416cefd5-12b6-4939-af54-38567eda5188"), tournamentId, year, division,  05, "MB", "NL", 3, BowlingCentre.Rossmere),   new SaveMatch(new Guid("6b3d1096-096b-444d-b7f7-7827b0997d58"), tournamentId, year, division,  05, "SO", "QC", 5, BowlingCentre.Rossmere),   new SaveMatch(new Guid("10049fa0-8218-40e6-8348-f624b89062e5"), tournamentId, year, division,  05, "BC", "NO", 7, BowlingCentre.Rossmere), 
                     new SaveMatch(new Guid("e5181234-4062-45c9-a9c5-f1f81150a1e2"), tournamentId, year, division,  06, "NO", "SO", 1, BowlingCentre.Rossmere),   new SaveMatch(new Guid("24e53524-7a89-4060-87f6-3ef9741ec4fc"), tournamentId, year, division,  06, "BC", "QC", 3, BowlingCentre.Rossmere),   new SaveMatch(new Guid("9265f331-4aee-405c-9c23-fa66fdb4b877"), tournamentId, year, division,  06, "NL", "SK", 5, BowlingCentre.Rossmere),   new SaveMatch(new Guid("3a386947-ce13-4d9f-b5ff-ae9be20d713a"), tournamentId, year, division,  06, "AB", "MB", 7, BowlingCentre.Rossmere), 
                     new SaveMatch(new Guid("e1307cf7-ee33-45e0-8175-869d6fb005f9"), tournamentId, year, division,  07, "AB", "NL", 1, BowlingCentre.Rossmere),   new SaveMatch(new Guid("db1fed25-a598-4394-a725-e21620aa4d0e"), tournamentId, year, division,  07, "SK", "MB", 3, BowlingCentre.Rossmere),   new SaveMatch(new Guid("cd960c65-a32f-42aa-83a0-dcdd1c5ecb97"), tournamentId, year, division,  07, "QC", "NO", 5, BowlingCentre.Rossmere),   new SaveMatch(new Guid("a315c988-866a-49bd-9e34-e6d5c9df6e98"), tournamentId, year, division,  07, "SO", "BC", 7, BowlingCentre.Rossmere), 
                     new SaveMatch(new Guid("ddf0117a-c6ef-4d53-a43f-ed52bca28bcb"), tournamentId, year, division,  08, "SO", "NL", 1, BowlingCentre.Coronation), new SaveMatch(new Guid("75f83afe-7275-4d5c-a274-93be62c42c85"), tournamentId, year, division,  08, "MB", "QC", 3, BowlingCentre.Coronation), new SaveMatch(new Guid("eab986f5-e9d1-48ae-b60a-7a84fd552cd0"), tournamentId, year, division,  08, "BC", "AB", 5, BowlingCentre.Coronation), new SaveMatch(new Guid("a4d5195b-c72e-4974-b6b4-490933dffaba"), tournamentId, year, division,  08, "SK", "NO", 7, BowlingCentre.Coronation), 
                     new SaveMatch(new Guid("ad627756-89a3-4a2f-8ccc-76179b1dde01"), tournamentId, year, division,  09, "SK", "BC", 1, BowlingCentre.Coronation), new SaveMatch(new Guid("e45d11ea-4190-4960-a34f-aa1705a1b2f1"), tournamentId, year, division,  09, "NO", "AB", 3, BowlingCentre.Coronation), new SaveMatch(new Guid("90a427ba-2c96-4428-b08b-70b89bdbacd3"), tournamentId, year, division,  09, "QC", "NL", 5, BowlingCentre.Coronation), new SaveMatch(new Guid("f7be7c7c-0a7d-4850-bc59-8d6f377343e0"), tournamentId, year, division,  09, "SO", "MB", 7, BowlingCentre.Coronation), 
                     new SaveMatch(new Guid("d2c1b4de-7a25-4c51-96a7-23294ab6b968"), tournamentId, year, division,  10, "NO", "QC", 1, BowlingCentre.Coronation), new SaveMatch(new Guid("d4c90072-4a25-4b04-8fda-2cb8bd91f7ba"), tournamentId, year, division,  10, "BC", "SO", 3, BowlingCentre.Coronation), new SaveMatch(new Guid("3be33973-5cba-41c0-a448-9163f01213f9"), tournamentId, year, division,  10, "MB", "SK", 5, BowlingCentre.Coronation), new SaveMatch(new Guid("adb139d0-c477-4b3c-af59-740e16186de6"), tournamentId, year, division,  10, "NL", "AB", 7, BowlingCentre.Coronation), 
                     new SaveMatch(new Guid("b2a6f30b-986a-434d-a949-70daca6ca91d"), tournamentId, year, division,  11, "MB", "AB", 1, BowlingCentre.Coronation), new SaveMatch(new Guid("a1ddc070-17a3-4782-8d6c-143299f754f5"), tournamentId, year, division,  11, "SK", "NL", 3, BowlingCentre.Coronation), new SaveMatch(new Guid("7f055841-05c9-4f98-84a6-eb847747c906"), tournamentId, year, division,  11, "SO", "NO", 5, BowlingCentre.Coronation), new SaveMatch(new Guid("411775e9-d03a-4be7-a506-d3b7b1c6f7f7"), tournamentId, year, division,  11, "QC", "BC", 7, BowlingCentre.Coronation), 
                     new SaveMatch(new Guid("82cf1637-988e-4b36-bb45-0f7770912b3e"), tournamentId, year, division,  12, "QC", "SO", 1, BowlingCentre.Coronation), new SaveMatch(new Guid("0f97150d-67e7-49a4-8e91-96d4eebb39a1"), tournamentId, year, division,  12, "NO", "BC", 3, BowlingCentre.Coronation), new SaveMatch(new Guid("eef6d610-6a4d-49a9-a850-3c14c06e301b"), tournamentId, year, division,  12, "NL", "MB", 5, BowlingCentre.Coronation), new SaveMatch(new Guid("70b94504-2f75-4966-b8eb-9f8e70ffbaad"), tournamentId, year, division,  12, "AB", "SK", 7, BowlingCentre.Coronation), 
                     new SaveMatch(new Guid("989f97ed-2c8d-4576-9ad7-14cea465b6b4"), tournamentId, year, division,  13, "NO", "NL", 1, BowlingCentre.Coronation), new SaveMatch(new Guid("e56db559-2d93-4d43-ab19-c99c7f46932d"), tournamentId, year, division,  13, "SO", "SK", 3, BowlingCentre.Coronation), new SaveMatch(new Guid("9402c9e1-bb8a-4e4e-a4fe-53f6cc053ebd"), tournamentId, year, division,  13, "AB", "QC", 5, BowlingCentre.Coronation), new SaveMatch(new Guid("208257c1-9be6-4c32-97b4-cc7ec5b0a69f"), tournamentId, year, division,  13, "BC", "MB", 7, BowlingCentre.Coronation), 
                     new SaveMatch(new Guid("1097fa30-bc2c-48f6-8583-2658c486126f"), tournamentId, year, division,  14, "AB", "SO", 1, BowlingCentre.Coronation), new SaveMatch(new Guid("58c44992-23f6-4074-83f3-46a5bef06ee2"), tournamentId, year, division,  14, "MB", "NO", 3, BowlingCentre.Coronation), new SaveMatch(new Guid("50b6b896-20a4-4871-b444-62209ef39251"), tournamentId, year, division,  14, "NL", "BC", 5, BowlingCentre.Coronation), new SaveMatch(new Guid("dba4caf5-7cac-4818-a0f0-09915b50d781"), tournamentId, year, division,  14, "SK", "QC", 7, BowlingCentre.Coronation),  
                     new SaveMatch(new Guid("687c2a6c-773f-4599-a84f-dcdb5e04f9ca"), tournamentId, year, division,  15, "SK", "AB", 23, BowlingCentre.Academy),   new SaveMatch(new Guid("de19eb86-2917-4747-a8fb-614b24e7508f"), tournamentId, year, division,  15, "MB", "NL", 25, BowlingCentre.Academy),   new SaveMatch(new Guid("e7ef62c1-b578-4e45-bdff-9d0536cd039c"), tournamentId, year, division,  15, "QC", "SO", 27, BowlingCentre.Academy),   new SaveMatch(new Guid("742ebf23-6172-44ab-9efe-360e3d9d4b52"), tournamentId, year, division,  15, "BC", "NO", 29, BowlingCentre.Academy), 
                     new SaveMatch(new Guid("bc13fba1-7fd5-437b-b86d-7f07f2b0ccb5"), tournamentId, year, division,  16, "SO", "BC", 23, BowlingCentre.Academy),   new SaveMatch(new Guid("b520d183-c7e6-4e70-afbb-ee0fd60b53f1"), tournamentId, year, division,  16, "QC", "NO", 25, BowlingCentre.Academy),   new SaveMatch(new Guid("54c445e5-2257-47cd-b903-0f14a3f00595"), tournamentId, year, division,  16, "MB", "SK", 27, BowlingCentre.Academy),   new SaveMatch(new Guid("9b17c243-e2f4-4319-ab5c-408ea5aa5117"), tournamentId, year, division,  16, "NL", "AB", 29, BowlingCentre.Academy), 
                     new SaveMatch(new Guid("e30344fd-802a-4982-8eef-f6e45630e8d1"), tournamentId, year, division,  17, "NO", "MB", 23, BowlingCentre.Academy),   new SaveMatch(new Guid("2bc2cec3-23f4-4305-9259-7ae51d9f25e8"), tournamentId, year, division,  17, "SO", "AB", 25, BowlingCentre.Academy),   new SaveMatch(new Guid("538f4733-c480-4499-9b25-6c41efe39c26"), tournamentId, year, division,  17, "BC", "NL", 27, BowlingCentre.Academy),   new SaveMatch(new Guid("8882b4cc-9b0b-41cb-bbe4-e52b72c1c14c"), tournamentId, year, division,  17, "SK", "QC", 29, BowlingCentre.Academy), 
                     new SaveMatch(new Guid("7858e184-eb08-47f5-a044-eb8fe5a900dd"), tournamentId, year, division,  18, "NL", "SK", 23, BowlingCentre.Academy),   new SaveMatch(new Guid("290cb5f9-b5a4-42ab-8912-27259ea3f607"), tournamentId, year, division,  18, "BC", "QC", 25, BowlingCentre.Academy),   new SaveMatch(new Guid("b759df83-6f07-43a1-bc0a-0e55bd39b805"), tournamentId, year, division,  18, "AB", "MB", 27, BowlingCentre.Academy),   new SaveMatch(new Guid("49552007-2853-4813-bc07-fb7ed613ec6e"), tournamentId, year, division,  18, "NO", "SO", 29, BowlingCentre.Academy), 
                     new SaveMatch(new Guid("707b6c37-e79c-4a00-a461-946c33fa635b"), tournamentId, year, division,  19, "AB", "BC", 23, BowlingCentre.Academy),   new SaveMatch(new Guid("8ae80205-c93e-4aa5-82a1-a7fccbfdca6c"), tournamentId, year, division,  19, "SK", "NO", 25, BowlingCentre.Academy),   new SaveMatch(new Guid("3237f288-bd82-431d-94d3-763e1466c1c0"), tournamentId, year, division,  19, "NL", "SO", 27, BowlingCentre.Academy),   new SaveMatch(new Guid("6a4dd345-07ed-4f22-bb2f-2f2a9d395155"), tournamentId, year, division,  19, "QC", "MB", 29, BowlingCentre.Academy), 
                     new SaveMatch(new Guid("4e2511f3-1251-4ab9-9ae1-79bd381be3b8"), tournamentId, year, division,  20, "NO", "NL", 23, BowlingCentre.Academy),   new SaveMatch(new Guid("542b2d1d-6450-4393-a196-4f0a1802831e"), tournamentId, year, division,  20, "MB", "BC", 25, BowlingCentre.Academy),   new SaveMatch(new Guid("b1e1d892-ba60-4f92-ba93-e80518588f7d"), tournamentId, year, division,  20, "QC", "AB", 27, BowlingCentre.Academy),   new SaveMatch(new Guid("4bcb4a97-a1e6-41c6-9ef8-87473b0b01af"), tournamentId, year, division,  20, "SO", "SK", 29, BowlingCentre.Academy), 
                     new SaveMatch(new Guid("4c81e4e2-a010-4635-a714-e15ee04fc44e"), tournamentId, year, division,  21, "MB", "SO", 23, BowlingCentre.Academy),   new SaveMatch(new Guid("d9a3d812-1e31-461f-8fe4-dadf0042a193"), tournamentId, year, division,  21, "NL", "QC", 25, BowlingCentre.Academy),   new SaveMatch(new Guid("8cd0b7b9-29fb-435d-9fc2-59e30424182e"), tournamentId, year, division,  21, "BC", "SK", 27, BowlingCentre.Academy),   new SaveMatch(new Guid("b1ee9924-7b1f-4ebc-8f9a-a17519e7690a"), tournamentId, year, division,  21, "AB", "NO", 29, BowlingCentre.Academy), 
                };

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }

        public static void TournamentLadiesSingle(MessageDispatcher dispatcher)
        {
            var scheduleId = new Guid("fee09860-a9e9-4e89-86b5-7c62735f9236");
            var division = "Tournament Ladies Single";

            var commands = new List<SaveMatch>
                {
                     new SaveMatch(new Guid("b096ace7-ea86-4350-8238-e0175b469f33"), tournamentId, year, division,  01, "SO", "AB", 1, BowlingCentre.Rossmere),   new SaveMatch(new Guid("5b1aa1c0-0e86-4dd7-a2b8-f1e6ff36e867"), tournamentId, year, division,  01, "NO", "MB", 3, BowlingCentre.Rossmere),   new SaveMatch(new Guid("e9368614-9144-46c6-97cb-2a0db6320179"), tournamentId, year, division,  01, "BC", "NL", 5, BowlingCentre.Rossmere),   new SaveMatch(new Guid("5a8de460-8f61-4cd1-82e9-18866c1dbb19"), tournamentId, year, division,  01, "QC", "SK", 7, BowlingCentre.Rossmere), 
                     new SaveMatch(new Guid("6559c941-45db-409d-a597-f4ccaf098d8e"), tournamentId, year, division,  02, "BC", "SK", 1, BowlingCentre.Rossmere),   new SaveMatch(new Guid("a121ea1c-eeb0-4057-8094-5bf46ca33e75"), tournamentId, year, division,  02, "NL", "QC", 3, BowlingCentre.Rossmere),   new SaveMatch(new Guid("1b9488bf-6f77-4d6f-85c8-5d62dca79f34"), tournamentId, year, division,  02, "MB", "SO", 5, BowlingCentre.Rossmere),   new SaveMatch(new Guid("b3ac5fbc-7c44-471b-a722-e924bf022735"), tournamentId, year, division,  02, "AB", "NO", 7, BowlingCentre.Rossmere), 
                     new SaveMatch(new Guid("7296699d-bb58-48df-92b8-ae5c1d0997d0"), tournamentId, year, division,  03, "NL", "NO", 1, BowlingCentre.Rossmere),   new SaveMatch(new Guid("fe7c24ad-56ad-491b-95b4-84c282b6e9ff"), tournamentId, year, division,  03, "SK", "SO", 3, BowlingCentre.Rossmere),   new SaveMatch(new Guid("a7bac241-8a72-49b1-8fcb-2fc9c11cf063"), tournamentId, year, division,  03, "QC", "AB", 5, BowlingCentre.Rossmere),   new SaveMatch(new Guid("0a179f36-4f78-480b-b637-8ddecaa25bb4"), tournamentId, year, division,  03, "MB", "BC", 7, BowlingCentre.Rossmere), 
                     new SaveMatch(new Guid("fa4a1443-7991-4af5-a3ff-ad11066f6176"), tournamentId, year, division,  04, "QC", "MB", 1, BowlingCentre.Rossmere),   new SaveMatch(new Guid("e8f54c39-7694-4583-85e8-fff9c0fb415a"), tournamentId, year, division,  04, "AB", "BC", 3, BowlingCentre.Rossmere),   new SaveMatch(new Guid("cb1ea9f5-daa1-4dc6-beef-9916008c2fd1"), tournamentId, year, division,  04, "NO", "SK", 5, BowlingCentre.Rossmere),   new SaveMatch(new Guid("300c2d21-93a3-435d-a859-0d2e267896e5"), tournamentId, year, division,  04, "SO", "NL", 7, BowlingCentre.Rossmere), 
                     new SaveMatch(new Guid("e6865484-aaae-4cad-871b-1e1af1e63f8c"), tournamentId, year, division,  05, "SK", "AB", 1, BowlingCentre.Rossmere),   new SaveMatch(new Guid("a73c5f70-0c15-46b2-9155-c1c173c60bc4"), tournamentId, year, division,  05, "MB", "NL", 3, BowlingCentre.Rossmere),   new SaveMatch(new Guid("ff154974-27d4-4e4b-903d-701f662c1bc1"), tournamentId, year, division,  05, "SO", "QC", 5, BowlingCentre.Rossmere),   new SaveMatch(new Guid("95256f2c-6f9a-4393-816e-71d27cf812ed"), tournamentId, year, division,  05, "BC", "NO", 7, BowlingCentre.Rossmere), 
                     new SaveMatch(new Guid("8b8597be-ee95-4c4f-902f-9b820e67c317"), tournamentId, year, division,  06, "NO", "SO", 1, BowlingCentre.Rossmere),   new SaveMatch(new Guid("73de1f25-4e7f-4f9b-9d46-7f30758beae7"), tournamentId, year, division,  06, "BC", "QC", 3, BowlingCentre.Rossmere),   new SaveMatch(new Guid("a584f54e-422f-4f42-a23b-3c4386d07798"), tournamentId, year, division,  06, "NL", "SK", 5, BowlingCentre.Rossmere),   new SaveMatch(new Guid("78bdf7a4-d31d-4e03-9616-7367a66919f4"), tournamentId, year, division,  06, "AB", "MB", 7, BowlingCentre.Rossmere), 
                     new SaveMatch(new Guid("820c22c3-0240-40b2-a789-af89dfbb226d"), tournamentId, year, division,  07, "AB", "NL", 1, BowlingCentre.Rossmere),   new SaveMatch(new Guid("a3651ecc-92fa-46a7-8366-18feeb416865"), tournamentId, year, division,  07, "SK", "MB", 3, BowlingCentre.Rossmere),   new SaveMatch(new Guid("94825e67-fe36-4cc9-a0eb-32513ee300fe"), tournamentId, year, division,  07, "QC", "NO", 5, BowlingCentre.Rossmere),   new SaveMatch(new Guid("c8363082-cc86-40bf-ac70-eeae506cda48"), tournamentId, year, division,  07, "SO", "BC", 7, BowlingCentre.Rossmere), 
                     new SaveMatch(new Guid("23933fdf-8ea7-43cc-863b-f71ffeac1203"), tournamentId, year, division,  08, "SO", "NL", 1, BowlingCentre.Coronation), new SaveMatch(new Guid("30e67c5f-201f-4ada-8b1b-12faade4d4b4"), tournamentId, year, division,  08, "MB", "QC", 3, BowlingCentre.Coronation), new SaveMatch(new Guid("cf52d711-d6b0-4222-a1f6-ddf33c74243e"), tournamentId, year, division,  08, "BC", "AB", 5, BowlingCentre.Coronation), new SaveMatch(new Guid("06bf3c5d-f266-4a8b-8f86-02d1e318910f"), tournamentId, year, division,  08, "SK", "NO", 7, BowlingCentre.Coronation), 
                     new SaveMatch(new Guid("e79857d4-8c06-451c-a6a4-0bc94e85caba"), tournamentId, year, division,  09, "SK", "BC", 1, BowlingCentre.Coronation), new SaveMatch(new Guid("6f8587b5-0142-43bd-86f6-7d546b0521e9"), tournamentId, year, division,  09, "NO", "AB", 3, BowlingCentre.Coronation), new SaveMatch(new Guid("479f8ee8-3148-4fa7-9051-7a4dc66f68db"), tournamentId, year, division,  09, "QC", "NL", 5, BowlingCentre.Coronation), new SaveMatch(new Guid("84b5e32a-cc9c-4e37-9c51-6d5e5639c505"), tournamentId, year, division,  09, "SO", "MB", 7, BowlingCentre.Coronation), 
                     new SaveMatch(new Guid("bc780a72-cfb1-4215-b5a3-7885102f96dd"), tournamentId, year, division,  10, "NO", "QC", 1, BowlingCentre.Coronation), new SaveMatch(new Guid("dc9021e9-f4d5-447c-80d5-2ff791ba4999"), tournamentId, year, division,  10, "BC", "SO", 3, BowlingCentre.Coronation), new SaveMatch(new Guid("36313faa-8803-4c8a-9251-7ad80bbf6770"), tournamentId, year, division,  10, "MB", "SK", 5, BowlingCentre.Coronation), new SaveMatch(new Guid("e46a43d4-4e46-4513-b227-562ab1350430"), tournamentId, year, division,  10, "NL", "AB", 7, BowlingCentre.Coronation), 
                     new SaveMatch(new Guid("2236b743-23e7-44dc-ae71-6746820b7906"), tournamentId, year, division,  11, "MB", "AB", 1, BowlingCentre.Coronation), new SaveMatch(new Guid("8c2fd200-73a4-4002-864d-45f5b801c107"), tournamentId, year, division,  11, "SK", "NL", 3, BowlingCentre.Coronation), new SaveMatch(new Guid("54e54f6c-0ec9-4825-9ad0-ba911745b8c5"), tournamentId, year, division,  11, "SO", "NO", 5, BowlingCentre.Coronation), new SaveMatch(new Guid("71ef4d76-0427-425c-b36f-132b3f162c54"), tournamentId, year, division,  11, "QC", "BC", 7, BowlingCentre.Coronation), 
                     new SaveMatch(new Guid("d542d7ea-3e8e-4813-b51e-5563ddff3d5e"), tournamentId, year, division,  12, "QC", "SO", 1, BowlingCentre.Coronation), new SaveMatch(new Guid("ba9d9228-fff6-434f-aabd-17ecbfd42dfc"), tournamentId, year, division,  12, "NO", "BC", 3, BowlingCentre.Coronation), new SaveMatch(new Guid("23290cc1-597e-44d1-8de7-efa2ab493dcd"), tournamentId, year, division,  12, "NL", "MB", 5, BowlingCentre.Coronation), new SaveMatch(new Guid("445b49c2-fe34-47f5-912d-d1fc70c93eeb"), tournamentId, year, division,  12, "AB", "SK", 7, BowlingCentre.Coronation), 
                     new SaveMatch(new Guid("6778e8a8-f77c-475f-92a3-7b924722f972"), tournamentId, year, division,  13, "NO", "NL", 1, BowlingCentre.Coronation), new SaveMatch(new Guid("f7d73a90-f977-46d1-926d-4fcf0997cb78"), tournamentId, year, division,  13, "SO", "SK", 3, BowlingCentre.Coronation), new SaveMatch(new Guid("4904a811-426b-475d-8a95-6aa88f8299b0"), tournamentId, year, division,  13, "AB", "QC", 5, BowlingCentre.Coronation), new SaveMatch(new Guid("dd4e9904-7b80-4c6a-bf45-6d3209b01b92"), tournamentId, year, division,  13, "BC", "MB", 7, BowlingCentre.Coronation), 
                     new SaveMatch(new Guid("caf977db-12c3-4348-b4b0-0fb857282e1a"), tournamentId, year, division,  14, "AB", "SO", 1, BowlingCentre.Coronation), new SaveMatch(new Guid("2e860e99-503d-469b-87ef-3756801cc74c"), tournamentId, year, division,  14, "MB", "NO", 3, BowlingCentre.Coronation), new SaveMatch(new Guid("1618953f-13f3-4485-8933-f4f477f37532"), tournamentId, year, division,  14, "NL", "BC", 5, BowlingCentre.Coronation), new SaveMatch(new Guid("93396c94-930c-4bae-b40e-7c8a11ba3cbe"), tournamentId, year, division,  14, "SK", "QC", 7, BowlingCentre.Coronation),  
                     new SaveMatch(new Guid("b46c8aa9-d665-4726-91df-ceb113fcaa8a"), tournamentId, year, division,  15, "SK", "AB", 23, BowlingCentre.Academy),   new SaveMatch(new Guid("9239e540-27a9-4ca6-aaf6-a7a1b9afd442"), tournamentId, year, division,  15, "MB", "NL", 25, BowlingCentre.Academy),   new SaveMatch(new Guid("b552a8bd-291e-4072-8080-e58e7407d4fc"), tournamentId, year, division,  15, "QC", "SO", 27, BowlingCentre.Academy),   new SaveMatch(new Guid("f48b7417-d0fb-4d68-a5ad-e779823fbae6"), tournamentId, year, division,  15, "BC", "NO", 29, BowlingCentre.Academy), 
                     new SaveMatch(new Guid("96582b3a-271b-49cd-932f-e71d1b5f522d"), tournamentId, year, division,  16, "SO", "BC", 23, BowlingCentre.Academy),   new SaveMatch(new Guid("cc75b845-e13f-482d-b48e-9b34c6f41eb5"), tournamentId, year, division,  16, "QC", "NO", 25, BowlingCentre.Academy),   new SaveMatch(new Guid("971b50c9-7a3a-4bef-a429-c8b6ae59518b"), tournamentId, year, division,  16, "MB", "SK", 27, BowlingCentre.Academy),   new SaveMatch(new Guid("09e26df5-e275-4a71-87c0-6698f9a24c24"), tournamentId, year, division,  16, "NL", "AB", 29, BowlingCentre.Academy), 
                     new SaveMatch(new Guid("bd86fa80-c588-4bd5-82b1-606466d343d9"), tournamentId, year, division,  17, "NO", "MB", 23, BowlingCentre.Academy),   new SaveMatch(new Guid("d4a924cc-f285-4042-a5a6-57ef2e888d02"), tournamentId, year, division,  17, "SO", "AB", 25, BowlingCentre.Academy),   new SaveMatch(new Guid("8487a7b1-eac3-489f-a8d1-ae2887eb115f"), tournamentId, year, division,  17, "BC", "NL", 27, BowlingCentre.Academy),   new SaveMatch(new Guid("a0c30e3d-968a-4d95-986f-17c1e3938295"), tournamentId, year, division,  17, "SK", "QC", 29, BowlingCentre.Academy), 
                     new SaveMatch(new Guid("c898a3ec-b4c1-444b-a504-078b155f1c40"), tournamentId, year, division,  18, "NL", "SK", 23, BowlingCentre.Academy),   new SaveMatch(new Guid("6ea7e219-b3e4-4a50-ab6d-9d481f19a026"), tournamentId, year, division,  18, "BC", "QC", 25, BowlingCentre.Academy),   new SaveMatch(new Guid("53394cec-430c-4fef-82d8-bd3730fbd246"), tournamentId, year, division,  18, "AB", "MB", 27, BowlingCentre.Academy),   new SaveMatch(new Guid("f80c6265-b30b-4dda-9aa2-3ff2cf3aac47"), tournamentId, year, division,  18, "NO", "SO", 29, BowlingCentre.Academy), 
                     new SaveMatch(new Guid("76215c4a-b57b-47b0-bd08-4bc1eb12dcb8"), tournamentId, year, division,  19, "AB", "BC", 23, BowlingCentre.Academy),   new SaveMatch(new Guid("b22f1ef3-353e-4794-be1f-4a13224ebb8b"), tournamentId, year, division,  19, "SK", "NO", 25, BowlingCentre.Academy),   new SaveMatch(new Guid("d8a5f84c-d8a7-4c9b-b210-e21a94725df6"), tournamentId, year, division,  19, "NL", "SO", 27, BowlingCentre.Academy),   new SaveMatch(new Guid("6ca88d1a-d031-4f3b-b096-b89285dba72e"), tournamentId, year, division,  19, "QC", "MB", 29, BowlingCentre.Academy), 
                     new SaveMatch(new Guid("43e20909-84ee-4510-ace9-290fe3f8e3ca"), tournamentId, year, division,  20, "NO", "NL", 23, BowlingCentre.Academy),   new SaveMatch(new Guid("0583d000-189f-41d6-ad89-4e925fcef6f6"), tournamentId, year, division,  20, "MB", "BC", 25, BowlingCentre.Academy),   new SaveMatch(new Guid("7f5cdafe-bad8-4d9f-81b8-376167f01249"), tournamentId, year, division,  20, "QC", "AB", 27, BowlingCentre.Academy),   new SaveMatch(new Guid("edc0854d-0399-4f53-9aa1-3fc695c37976"), tournamentId, year, division,  20, "SO", "SK", 29, BowlingCentre.Academy), 
                     new SaveMatch(new Guid("f06eb5ba-a782-4577-a4b1-9b1ba5cb7d28"), tournamentId, year, division,  21, "MB", "SO", 23, BowlingCentre.Academy),   new SaveMatch(new Guid("41dbe216-b145-4132-acfa-64874c844693"), tournamentId, year, division,  21, "NL", "QC", 25, BowlingCentre.Academy),   new SaveMatch(new Guid("4f217e0a-00c4-44b1-a7e9-598d15c3f6c5"), tournamentId, year, division,  21, "BC", "SK", 27, BowlingCentre.Academy),   new SaveMatch(new Guid("f583f9bd-1f9c-43f7-81d3-9d52d90e760f"), tournamentId, year, division,  21, "AB", "NO", 29, BowlingCentre.Academy), 
                };

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }

        public static void TournamentLadies(MessageDispatcher dispatcher)
        {
            var scheduleId = new Guid("8927e212-81f6-4f42-8015-a5a3a8727819");
            var division = "Tournament Ladies";

            var commands = new List<SaveMatch>
                {
                     new SaveMatch(new Guid("c0ed9430-e503-467b-91e0-7413c5ee3687"), tournamentId, year, division,  01, "MB", "AB", 01, BowlingCentre.Academy),  new SaveMatch(new Guid("c099a39e-c4ee-4140-9dad-607dc6e89eca"), tournamentId, year, division,  01, "NO", "BC", 05, BowlingCentre.Academy),  new SaveMatch(new Guid("f6304a83-2c9e-406c-a723-b19eaa901db4"), tournamentId, year, division,  01, "NL", "SO", 09, BowlingCentre.Academy),
                     new SaveMatch(new Guid("d7036f45-b891-4875-9fbe-a640da91c11f"), tournamentId, year, division,  02, "NL", "AB", 05, BowlingCentre.Academy),  new SaveMatch(new Guid("ff03b7f0-11a9-4136-ab6a-499b55c68219"), tournamentId, year, division,  02, "SO", "MB", 07, BowlingCentre.Academy),  new SaveMatch(new Guid("e00f1269-5241-4cf5-931b-c5af516dfb52"), tournamentId, year, division,  02, "SK", "NO", 09, BowlingCentre.Academy),
                     new SaveMatch(new Guid("f082a094-13a2-47e2-a306-4a51700d782e"), tournamentId, year, division,  03, "SO", "NO", 01, BowlingCentre.Academy),  new SaveMatch(new Guid("71e1f625-5fc2-4936-a58a-7689619f2390"), tournamentId, year, division,  03, "MB", "SK", 03, BowlingCentre.Academy),  new SaveMatch(new Guid("6280b64b-a7e6-4916-8ee8-74e9fc7d7309"), tournamentId, year, division,  03, "BC", "NL", 07, BowlingCentre.Academy),
                     new SaveMatch(new Guid("1cf8c661-c0f4-4022-b2e7-7b26ce30a73e"), tournamentId, year, division,  04, "NO", "NL", 03, BowlingCentre.Academy),  new SaveMatch(new Guid("11cd58d8-eb12-4e73-b2ec-d4c31a80979e"), tournamentId, year, division,  04, "AB", "SK", 07, BowlingCentre.Academy),  new SaveMatch(new Guid("2c7a6549-fa20-4ee8-9400-7cd614869179"), tournamentId, year, division,  04, "BC", "SO", 11, BowlingCentre.Academy),
                     new SaveMatch(new Guid("5f87c84a-af9a-456f-a48a-b6937a440663"), tournamentId, year, division,  05, "BC", "AB", 03, BowlingCentre.Academy),  new SaveMatch(new Guid("a620a305-3e9d-40c6-88fe-0b6d68520725"), tournamentId, year, division,  05, "SO", "SK", 05, BowlingCentre.Academy),  new SaveMatch(new Guid("93ff18aa-ea28-4b67-bdc2-e15e4457f2ce"), tournamentId, year, division,  05, "NO", "MB", 13, BowlingCentre.Academy),
                     new SaveMatch(new Guid("0271f181-93c2-496e-a9ac-7f49c04342f0"), tournamentId, year, division,  06, "MB", "BC", 09, BowlingCentre.Academy),  new SaveMatch(new Guid("883451c0-5bc0-4fa5-bc40-c99f64ea5c24"), tournamentId, year, division,  06, "AB", "NO", 11, BowlingCentre.Academy),  new SaveMatch(new Guid("26b30af0-7795-47c9-b71d-1ee62ccd3096"), tournamentId, year, division,  06, "SK", "NL", 13, BowlingCentre.Academy),
                     new SaveMatch(new Guid("d1e9be1e-02ca-44be-9517-780643ac3111"), tournamentId, year, division,  07, "SK", "BC", 01, BowlingCentre.Academy),  new SaveMatch(new Guid("eb152667-a412-4f58-a673-ef8422b62b80"), tournamentId, year, division,  07, "NL", "MB", 11, BowlingCentre.Academy),  new SaveMatch(new Guid("91ae8019-5ba3-498c-8c50-f1144bdf536b"), tournamentId, year, division,  07, "AB", "SO", 13, BowlingCentre.Academy),                                                                                                                                              
                     new SaveMatch(new Guid("a2bcead0-fb2c-42a9-9b30-ceaccb1e0687"), tournamentId, year, division,  08, "NO", "SO", 15, BowlingCentre.Academy),  new SaveMatch(new Guid("ea0175c3-cc5e-41b1-a016-74ac0ed403ca"), tournamentId, year, division,  08, "NL", "BC", 19, BowlingCentre.Academy),  new SaveMatch(new Guid("78558724-3441-4994-a28c-c0a73074f8a5"), tournamentId, year, division,  08, "SK", "MB", 21, BowlingCentre.Academy), 
                     new SaveMatch(new Guid("cf5cb6af-3394-47f5-9eb3-093e099f1032"), tournamentId, year, division,  09, "SK", "AB", 15, BowlingCentre.Academy),  new SaveMatch(new Guid("93c2a398-a53e-43a4-bf5a-9766be2edc5e"), tournamentId, year, division,  09, "NL", "NO", 17, BowlingCentre.Academy),  new SaveMatch(new Guid("438e8d18-31f0-40bf-91fb-938d885c7cef"), tournamentId, year, division,  09, "SO", "BC", 21, BowlingCentre.Academy), 
                     new SaveMatch(new Guid("a6659a50-a16b-4805-9ce4-9223f16982d5"), tournamentId, year, division,  10, "MB", "SO", 17, BowlingCentre.Academy),  new SaveMatch(new Guid("0c3503bb-375d-449b-9aee-36281dc1db56"), tournamentId, year, division,  10, "NO", "SK", 19, BowlingCentre.Academy),  new SaveMatch(new Guid("2d5862c6-8e17-4507-8ee4-6e78114c5302"), tournamentId, year, division,  10, "NL", "AB", 21, BowlingCentre.Academy), 
                     new SaveMatch(new Guid("538a7c35-e8b2-4a88-883a-1395c6911ff0"), tournamentId, year, division,  11, "MB", "NL", 15, BowlingCentre.Academy),  new SaveMatch(new Guid("efb2c962-0707-4b6f-b3ab-e4772ce60ff9"), tournamentId, year, division,  11, "BC", "SK", 17, BowlingCentre.Academy),  new SaveMatch(new Guid("adc8271c-bd83-4c44-b672-2a0b49cb9188"), tournamentId, year, division,  11, "SO", "AB", 19, BowlingCentre.Academy), 
                     new SaveMatch(new Guid("858b2460-77a9-4308-a25c-d65e918a74dd"), tournamentId, year, division,  12, "AB", "MB", 23, BowlingCentre.Academy),  new SaveMatch(new Guid("dfc04d8b-76c8-4c67-8f7c-d8a29103068c"), tournamentId, year, division,  12, "BC", "NO", 25, BowlingCentre.Academy),  new SaveMatch(new Guid("aebdc47d-91b5-4beb-9b60-97113573f251"), tournamentId, year, division,  12, "SO", "NL", 29, BowlingCentre.Academy), 
                     new SaveMatch(new Guid("f4e8869b-29db-4075-8c53-c94299c8e682"), tournamentId, year, division,  13, "SK", "SO", 23, BowlingCentre.Academy),  new SaveMatch(new Guid("4e6ad444-339f-4bbc-a30c-ab01e2ecacba"), tournamentId, year, division,  13, "AB", "BC", 27, BowlingCentre.Academy),  new SaveMatch(new Guid("14367bb9-aead-4b4d-ae89-27a619b9320a"), tournamentId, year, division,  13, "MB", "NO", 29, BowlingCentre.Academy),
                     new SaveMatch(new Guid("26ac3e7a-911a-4817-8ccd-4be805d6b8fd"), tournamentId, year, division,  14, "SK", "NL", 03, BowlingCentre.Rossmere), new SaveMatch(new Guid("c4dd67e0-2fec-4ca7-a067-48faf3b39d3e"), tournamentId, year, division,  14, "AB", "NO", 07, BowlingCentre.Rossmere), new SaveMatch(new Guid("a39a13eb-cc27-4c2f-b832-cbda93aefac4"), tournamentId, year, division,  14, "MB", "BC", 09, BowlingCentre.Rossmere), 
                     new SaveMatch(new Guid("c02afe28-e2f7-46e9-931b-2b100bbdba85"), tournamentId, year, division,  15, "AB", "SO", 03, BowlingCentre.Rossmere), new SaveMatch(new Guid("59abcefb-926b-4b71-86b7-cb19d27cd083"), tournamentId, year, division,  15, "MB", "NL", 05, BowlingCentre.Rossmere), new SaveMatch(new Guid("6d34ed80-ae82-4608-838b-316a2555c047"), tournamentId, year, division,  15, "BC", "SK", 07, BowlingCentre.Rossmere),
                     new SaveMatch(new Guid("0061d208-383e-4a74-9cef-571a5a1f3903"), tournamentId, year, division,  16, "NO", "MB", 03, BowlingCentre.Rossmere), new SaveMatch(new Guid("6e84c214-7554-4005-a6bc-d7e8d285b0bc"), tournamentId, year, division,  16, "BC", "AB", 05, BowlingCentre.Rossmere), new SaveMatch(new Guid("a909b872-763e-4686-b4c6-3c21c5b35972"), tournamentId, year, division,  16, "SO", "SK", 09, BowlingCentre.Rossmere),
                     new SaveMatch(new Guid("61373b4f-c3ef-4de6-b6b1-6ea6891cb4f2"), tournamentId, year, division,  17, "SO", "NO", 15, BowlingCentre.Rossmere), new SaveMatch(new Guid("61d0603a-2f1d-4e29-8282-26d428916c49"), tournamentId, year, division,  17, "NL", "BC", 17, BowlingCentre.Rossmere), new SaveMatch(new Guid("019e4118-b027-45cc-a09c-3b1bddf2af1b"), tournamentId, year, division,  17, "SK", "MB", 19, BowlingCentre.Rossmere),
                     new SaveMatch(new Guid("fa0b9473-1381-4da5-8682-d8909b586835"), tournamentId, year, division,  18, "BC", "SO", 13, BowlingCentre.Rossmere), new SaveMatch(new Guid("5e99bd4b-e9a8-4299-89f7-b5bebd64a688"), tournamentId, year, division,  18, "AB", "SK", 17, BowlingCentre.Rossmere), new SaveMatch(new Guid("0c38079a-129c-44b5-9d90-ac39f33dee34"), tournamentId, year, division,  18, "NO", "NL", 19, BowlingCentre.Rossmere),                                                                                                                                                  
                     new SaveMatch(new Guid("5ffc5a40-2456-439b-9294-22261e41570b"), tournamentId, year, division,  19, "SO", "MB", 23, BowlingCentre.Academy),  new SaveMatch(new Guid("3720cabe-174f-4955-ba1b-282051af04f9"), tournamentId, year, division,  19, "SK", "NO", 27, BowlingCentre.Academy),  new SaveMatch(new Guid("06449775-549b-4278-a0da-0f1a65e47c4b"), tournamentId, year, division,  19, "AB", "NL", 29, BowlingCentre.Academy),
                     new SaveMatch(new Guid("c916151e-06cf-4d2a-8d50-a4f4e39388dd"), tournamentId, year, division,  20, "MB", "AB", 25, BowlingCentre.Academy),  new SaveMatch(new Guid("0ec9ec5b-1d3b-444d-b85a-3b483f6a1db4"), tournamentId, year, division,  20, "NL", "SO", 27, BowlingCentre.Academy),  new SaveMatch(new Guid("c3eb2c5a-bab1-4d8b-9015-25a1f8ba49a6"), tournamentId, year, division,  20, "NO", "BC", 29, BowlingCentre.Academy),
                     new SaveMatch(new Guid("bf750114-9f59-4743-82ee-a8d242b47025"), tournamentId, year, division,  21, "NO", "AB", 23, BowlingCentre.Academy),  new SaveMatch(new Guid("cabe33a7-c8a3-420b-a1c2-df08e5b29e17"), tournamentId, year, division,  21, "NL", "SK", 25, BowlingCentre.Academy),  new SaveMatch(new Guid("7323548c-ea07-42fe-b3a1-44a784a84889"), tournamentId, year, division,  21, "BC", "MB", 27, BowlingCentre.Academy),
                };

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }

        public static void TournamentMen(MessageDispatcher dispatcher)
        {
            var scheduleId = new Guid("3ab4cdc0-be00-4391-ba53-ec95ce0a318a");
            var division = "Tournament Men";

            var commands = new List<SaveMatch>
                {
                     new SaveMatch(new Guid("35622ef1-fe65-4384-84ba-debd3368dcfb"), tournamentId, year, division,  01, "NO", "BC", 09, BowlingCentre.Rossmere),  new SaveMatch(new Guid("e8b04e20-7c9c-4f86-bd02-44e6da6608aa"), tournamentId, year, division, 01, "MB", "AB", 11, BowlingCentre.Rossmere),  new SaveMatch(new Guid("9c4875b2-09e9-424e-b656-fb6f692e35dd"), tournamentId, year, division,  01, "QC", "SK", 13, BowlingCentre.Rossmere),  new SaveMatch(new Guid("8cf043fd-7c24-4ec3-84c0-649e680446c2"), tournamentId, year, division,  01, "NL", "SO", 19, BowlingCentre.Rossmere),
                     new SaveMatch(new Guid("15aeaa82-5dcd-49b1-a59b-44440b400a08"), tournamentId, year, division,  02, "SO", "NO", 13, BowlingCentre.Rossmere),  new SaveMatch(new Guid("d0ddb4e4-f715-4ba7-8ca6-9ca0fd546f3f"), tournamentId, year, division, 02, "AB", "QC", 15, BowlingCentre.Rossmere),  new SaveMatch(new Guid("cd5871f6-03f8-498b-ac1c-cb4aa5ce11ab"), tournamentId, year, division,  02, "BC", "NL", 17, BowlingCentre.Rossmere),  new SaveMatch(new Guid("e0fac3c0-c1f8-466f-a79a-d1fb6954abf7"), tournamentId, year, division,  02, "MB", "SK", 19, BowlingCentre.Rossmere),
                     new SaveMatch(new Guid("1fd78993-7ecf-46af-9ef9-9b7087096f56"), tournamentId, year, division,  03, "AB", "SK", 09, BowlingCentre.Rossmere),  new SaveMatch(new Guid("d5ca0ccc-c032-4608-95c7-7765e7f98f9b"), tournamentId, year, division, 03, "BC", "SO", 11, BowlingCentre.Rossmere),  new SaveMatch(new Guid("2adf882d-186e-47f7-8c6a-7a575cc32d86"), tournamentId, year, division,  03, "NO", "NL", 15, BowlingCentre.Rossmere),  new SaveMatch(new Guid("4722af0f-0ffc-420f-afa8-66a86e905356"), tournamentId, year, division,  03, "QC", "MB", 17, BowlingCentre.Rossmere),
                     new SaveMatch(new Guid("01cd834a-f9fa-428f-860e-21806fcd96c3"), tournamentId, year, division,  04, "NL", "AB", 13, BowlingCentre.Rossmere),  new SaveMatch(new Guid("59d3d535-801e-4780-950a-1b9041a987d2"), tournamentId, year, division, 04, "MB", "SO", 15, BowlingCentre.Rossmere),  new SaveMatch(new Guid("97e6f977-8d85-4c03-838a-064b2da0cd7e"), tournamentId, year, division,  04, "SK", "NO", 17, BowlingCentre.Rossmere),  new SaveMatch(new Guid("516a7558-7cc5-498d-a43d-4a60f5a7ee5b"), tournamentId, year, division,  04, "QC", "BC", 19, BowlingCentre.Rossmere),
                     new SaveMatch(new Guid("7877c4cf-9419-4a49-ac8b-bb5a03f9559e"), tournamentId, year, division,  05, "SO", "QC", 09, BowlingCentre.Rossmere),  new SaveMatch(new Guid("ed290581-c2ff-4760-8fe4-212f3ae6f56e"), tournamentId, year, division, 05, "SK", "NL", 11, BowlingCentre.Rossmere),  new SaveMatch(new Guid("fbe87711-d30d-421d-b084-7e587872a6ff"), tournamentId, year, division,  05, "MB", "BC", 13, BowlingCentre.Rossmere),  new SaveMatch(new Guid("16f2da58-df22-4faf-b561-eb326c354274"), tournamentId, year, division,  05, "AB", "NO", 19, BowlingCentre.Rossmere),
                     new SaveMatch(new Guid("7f8cb775-fee5-4c10-b886-80629953dee8"), tournamentId, year, division,  06, "NL", "MB", 09, BowlingCentre.Rossmere),  new SaveMatch(new Guid("ffcbe33b-d566-4b5d-99a1-fae50bf78e2d"), tournamentId, year, division, 06, "NO", "QC", 11, BowlingCentre.Rossmere),  new SaveMatch(new Guid("16821cd4-5440-4c03-aa75-a63407c696ae"), tournamentId, year, division,  06, "SK", "BC", 15, BowlingCentre.Rossmere),  new SaveMatch(new Guid("8080fd93-d8d9-4b4e-bb9b-6035574f3407"), tournamentId, year, division,  06, "AB", "SO", 17, BowlingCentre.Rossmere),
                     new SaveMatch(new Guid("2ae33883-8304-49da-9320-32112153aaf5"), tournamentId, year, division,  07, "BC", "AB", 11, BowlingCentre.Rossmere),  new SaveMatch(new Guid("36303dac-6d08-4fcd-a737-e9428a2394ed"), tournamentId, year, division, 07, "SO", "SK", 13, BowlingCentre.Rossmere),  new SaveMatch(new Guid("9271b16a-af20-4af4-8d5a-7c43b038364f"), tournamentId, year, division,  07, "NO", "MB", 15, BowlingCentre.Rossmere),  new SaveMatch(new Guid("a3856418-719a-4f0a-8554-58205ec77cdf"), tournamentId, year, division,  07, "QC", "NL", 17, BowlingCentre.Rossmere),                     
                     new SaveMatch(new Guid("b359f528-cad8-43cf-be0d-188255d0d0c7"), tournamentId, year, division,  08, "BC", "QC", 23, BowlingCentre.Academy),   new SaveMatch(new Guid("4835540c-d8d7-46c4-8896-c3aa40a81b6f"), tournamentId, year, division, 08, "SO", "MB", 25, BowlingCentre.Academy),   new SaveMatch(new Guid("4af689e5-31c3-4acd-8f50-aa8669b14a14"), tournamentId, year, division,  08, "NO", "SK", 27, BowlingCentre.Academy),   new SaveMatch(new Guid("ba2a3ed7-c30a-491c-899d-05737e37a7ad"), tournamentId, year, division,  08, "AB", "NL", 29, BowlingCentre.Academy), 
                     new SaveMatch(new Guid("9aa8f533-90a5-4d77-b6f0-1b1e0933465a"), tournamentId, year, division,  09, "SK", "AB", 23, BowlingCentre.Academy),   new SaveMatch(new Guid("5743bdcb-5191-48e2-ad6a-b0aba3bd8269"), tournamentId, year, division, 09, "NL", "NO", 25, BowlingCentre.Academy),   new SaveMatch(new Guid("2adfb0f9-838e-438a-b7de-b8777031dc94"), tournamentId, year, division,  09, "MB", "QC", 27, BowlingCentre.Academy),   new SaveMatch(new Guid("5e33f57a-5555-46d5-b02a-2278a3de85ac"), tournamentId, year, division,  09, "SO", "BC", 29, BowlingCentre.Academy), 
                     new SaveMatch(new Guid("87e46ca2-65d0-4ba6-b9d1-1ea756b293bc"), tournamentId, year, division,  10, "NO", "SO", 23, BowlingCentre.Academy),   new SaveMatch(new Guid("61d1fcec-c2d7-4a99-8f40-4bf47ef2903c"), tournamentId, year, division, 10, "QC", "AB", 25, BowlingCentre.Academy),   new SaveMatch(new Guid("92ab1358-30b0-41a2-bb01-c5dea7a06b0d"), tournamentId, year, division,  10, "NL", "BC", 27, BowlingCentre.Academy),   new SaveMatch(new Guid("21671a94-51a3-4ebe-818c-02767d229ac7"), tournamentId, year, division,  10, "SK", "MB", 29, BowlingCentre.Academy), 
                     new SaveMatch(new Guid("e548bf2f-e878-4bd6-b804-e82673afe24a"), tournamentId, year, division,  11, "MB", "NL", 23, BowlingCentre.Academy),   new SaveMatch(new Guid("5dbd2303-2c4f-413d-b6ca-dfa0ef95cdd4"), tournamentId, year, division, 11, "BC", "SK", 25, BowlingCentre.Academy),   new SaveMatch(new Guid("5d29361d-ea90-46f0-8c9c-70ba86e3bdd3"), tournamentId, year, division,  11, "SO", "AB", 27, BowlingCentre.Academy),   new SaveMatch(new Guid("11951172-9ec1-4b46-a466-27d5615f9889"), tournamentId, year, division,  11, "QC", "NO", 29, BowlingCentre.Academy), 
                     new SaveMatch(new Guid("cce6126e-3535-48db-90cb-2b50e9bf0a62"), tournamentId, year, division,  12, "QC", "SK", 15, BowlingCentre.Academy),   new SaveMatch(new Guid("a4b32939-70e8-41ae-a59f-a9f7ceea6035"), tournamentId, year, division, 12, "SO", "NL", 17, BowlingCentre.Academy),   new SaveMatch(new Guid("e332da06-d7b7-4030-9a3f-cbb971fa1455"), tournamentId, year, division,  12, "BC", "NO", 19, BowlingCentre.Academy),   new SaveMatch(new Guid("cf5cfdf3-0f31-490f-bcb1-9fab377eba86"), tournamentId, year, division,  12, "AB", "MB", 21, BowlingCentre.Academy), 
                     new SaveMatch(new Guid("7ef0c7f0-7a31-45d0-a448-9b2cdbae0f88"), tournamentId, year, division,  13, "MB", "NO", 15, BowlingCentre.Academy),   new SaveMatch(new Guid("0de796c7-5f21-4e78-91d0-b63f20cc97fe"), tournamentId, year, division, 13, "AB", "BC", 17, BowlingCentre.Academy),   new SaveMatch(new Guid("c94dc520-1342-4f00-9645-c159e72c182d"), tournamentId, year, division,  13, "NL", "QC", 19, BowlingCentre.Academy),   new SaveMatch(new Guid("8565044c-256c-4dfd-b916-e26642e87857"), tournamentId, year, division,  13, "SK", "SO", 21, BowlingCentre.Academy), 
                     new SaveMatch(new Guid("76a5f239-b508-4787-b4cb-616ef6df07dc"), tournamentId, year, division,  14, "NL", "SK", 1, BowlingCentre.Coronation), new SaveMatch(new Guid("e52f75f3-382a-4105-aab2-b8001486bead"), tournamentId, year, division, 14, "BC", "MB", 3, BowlingCentre.Coronation), new SaveMatch(new Guid("62cd98b2-a8ce-439b-8195-6b494c96759d"), tournamentId, year, division,  14, "SO", "QC", 5, BowlingCentre.Coronation), new SaveMatch(new Guid("a70ff17c-64fb-4fea-b296-ff60d3002728"), tournamentId, year, division,  14, "AB", "NO", 7, BowlingCentre.Coronation), 
                     new SaveMatch(new Guid("b465233f-5598-499d-9d37-403cfd948284"), tournamentId, year, division,  15, "QC", "MB", 1, BowlingCentre.Coronation), new SaveMatch(new Guid("ed465244-5917-478f-8e55-9fac33840fc9"), tournamentId, year, division, 15, "AB", "SK", 3, BowlingCentre.Coronation), new SaveMatch(new Guid("9a3a26da-8014-414e-ab5e-02cd4df15029"), tournamentId, year, division,  15, "NO", "NL", 5, BowlingCentre.Coronation), new SaveMatch(new Guid("30a4386b-cda4-4c5a-8d14-58582453f6ff"), tournamentId, year, division,  15, "BC", "SO", 7, BowlingCentre.Coronation),
                     new SaveMatch(new Guid("c52bf196-a2de-44a4-a774-bb72b2129d15"), tournamentId, year, division,  16, "NO", "BC", 1, BowlingCentre.Coronation), new SaveMatch(new Guid("c3edf7f1-bef0-474a-80ea-2373c1c22069"), tournamentId, year, division, 16, "NL", "SO", 3, BowlingCentre.Coronation), new SaveMatch(new Guid("64875dca-79d7-4751-a7ff-86d63e8015ff"), tournamentId, year, division,  16, "MB", "AB", 5, BowlingCentre.Coronation), new SaveMatch(new Guid("a908e129-114f-4190-8ef6-09b382fd4003"), tournamentId, year, division,  16, "SK", "QC", 7, BowlingCentre.Coronation),
                     new SaveMatch(new Guid("a64516ab-f01f-4de7-bc4d-a5bc506b69e6"), tournamentId, year, division,  17, "SO", "AB", 1, BowlingCentre.Coronation), new SaveMatch(new Guid("d7f14a8e-6cb8-43f8-8566-42f5f02ee161"), tournamentId, year, division, 17, "QC", "NO", 3, BowlingCentre.Coronation), new SaveMatch(new Guid("7eefb94b-79be-4d45-b99b-d39f4135e423"), tournamentId, year, division,  17, "SK", "BC", 5, BowlingCentre.Coronation), new SaveMatch(new Guid("f1cb4776-1ef3-4da8-9d19-ccec2b803418"), tournamentId, year, division,  17, "NL", "MB", 7, BowlingCentre.Coronation),
                     new SaveMatch(new Guid("255c95ba-c90b-45c1-8e58-e3d77170693e"), tournamentId, year, division,  18, "BC", "NL", 1, BowlingCentre.Coronation), new SaveMatch(new Guid("9d9e60e2-f611-45e8-b832-7bacf32a2f1a"), tournamentId, year, division, 18, "MB", "SK", 3, BowlingCentre.Coronation), new SaveMatch(new Guid("1a4287b4-7cf2-4b2b-bdb6-a723d192bafa"), tournamentId, year, division,  18, "SO", "NO", 5, BowlingCentre.Coronation), new SaveMatch(new Guid("6d1a3579-ac34-4d59-bf1d-7980886173da"), tournamentId, year, division,  18, "AB", "QC", 7, BowlingCentre.Coronation),
                     new SaveMatch(new Guid("27915c1f-d025-47f4-bb22-1a801c0a6ea2"), tournamentId, year, division,  19, "MB", "SO", 15, BowlingCentre.Academy),   new SaveMatch(new Guid("310a60fb-af79-4bb3-833e-2a4ac54e0f91"), tournamentId, year, division, 19, "SK", "NO", 17, BowlingCentre.Academy),   new SaveMatch(new Guid("2eb9f68e-c92b-4d44-b593-d814e202cb72"), tournamentId, year, division,  19, "QC", "BC", 19, BowlingCentre.Academy),   new SaveMatch(new Guid("a5983cec-799d-4159-bb9f-4a7f1e3c8254"), tournamentId, year, division,  19, "AB", "NL", 21, BowlingCentre.Academy),
                     new SaveMatch(new Guid("7780cf7e-bb23-4e93-96c1-d80035200d4d"), tournamentId, year, division,  20, "BC", "AB", 15, BowlingCentre.Academy),   new SaveMatch(new Guid("701b8bf4-3ab9-4700-9160-b09de79b53d4"), tournamentId, year, division, 20, "NL", "QC", 17, BowlingCentre.Academy),   new SaveMatch(new Guid("c0f126e5-3e96-4cbb-b087-e2e9d8be4c59"), tournamentId, year, division,  20, "SO", "SK", 19, BowlingCentre.Academy),   new SaveMatch(new Guid("8c8f3231-f486-4e6e-b310-e1595fcb2261"), tournamentId, year, division,  20, "NO", "MB", 21, BowlingCentre.Academy),
                     new SaveMatch(new Guid("780be30f-d854-474f-83e3-467589b2a1bd"), tournamentId, year, division,  21, "SK", "NL", 15, BowlingCentre.Academy),   new SaveMatch(new Guid("efeec6fe-f4ff-49ce-bd06-315ef8264aea"), tournamentId, year, division, 21, "MB", "BC", 17, BowlingCentre.Academy),   new SaveMatch(new Guid("bf35c15b-8e0a-4071-8bbc-c5d1bed9a824"), tournamentId, year, division,  21, "NO", "AB", 19, BowlingCentre.Academy),   new SaveMatch(new Guid("36f134db-d1a3-4af3-ada0-a09df69c82ed"), tournamentId, year, division,  21, "QC", "SO", 21, BowlingCentre.Academy)
                };

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }

        public static void TeachingLadies(MessageDispatcher dispatcher)
        {
            var scheduleId = new Guid("8573961f-f203-4e39-b6a8-2d9de9f82534");
            var division = "Teaching Ladies";

            var commands = new List<SaveMatch>
                {
                     new SaveMatch(new Guid("ba35ffcb-0a1e-4ac7-9b37-6e8278099cfc"), tournamentId, year, division,  01, "MB", "NO", 15, BowlingCentre.Academy, true),  new SaveMatch(new Guid("d65587d6-e17a-47d2-ad98-6cb2dc146a34"), tournamentId, year, division,  01, "SK", "AB", 17, BowlingCentre.Academy, true),  new SaveMatch(new Guid("0dabc7b9-588b-41d3-a2e6-32af5c8ad7ef"), tournamentId, year, division,  01, "BC", "SO", 19, BowlingCentre.Academy, true),  new SaveMatch(new Guid("adc53323-c123-4162-90fd-c2fcd6987a36"), tournamentId, year, division,  01, "QC", "NL", 21, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("44b256a5-71bd-43d1-b24a-6e379bdfbba8"), tournamentId, year, division,  02, "BC", "QC", 15, BowlingCentre.Academy, true),  new SaveMatch(new Guid("2a4649d5-edf8-4b82-bb64-ee9992ded5cc"), tournamentId, year, division,  02, "SO", "NL", 17, BowlingCentre.Academy, true),  new SaveMatch(new Guid("77cba391-83a1-4ced-b772-2d90f048c70c"), tournamentId, year, division,  02, "AB", "MB", 19, BowlingCentre.Academy, true),  new SaveMatch(new Guid("08d0c40c-8089-491f-945c-a9fba3e66fda"), tournamentId, year, division,  02, "NO", "SK", 21, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("afd76742-f583-4fcf-997d-c6aaed58ec63"), tournamentId, year, division,  03, "SO", "SK", 15, BowlingCentre.Academy, true),  new SaveMatch(new Guid("3ad2acbd-b9bf-4721-8085-a264443c757c"), tournamentId, year, division,  03, "QC", "MB", 17, BowlingCentre.Academy, true),  new SaveMatch(new Guid("ef76b1bf-c69c-4751-a02f-89b8d5878ec2"), tournamentId, year, division,  03, "NL", "NO", 19, BowlingCentre.Academy, true),  new SaveMatch(new Guid("1cc43434-5c78-4c74-8939-b23e9f184119"), tournamentId, year, division,  03, "AB", "BC", 21, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("5e68eef3-8315-4179-8b8d-ecc117119c38"), tournamentId, year, division,  04, "NL", "AB", 15, BowlingCentre.Academy, true),  new SaveMatch(new Guid("583efdec-88db-4777-97b8-563c8d4d66a8"), tournamentId, year, division,  04, "NO", "BC", 17, BowlingCentre.Academy, true),  new SaveMatch(new Guid("a10bd7f1-240c-46f1-a8e1-43e763de5ba4"), tournamentId, year, division,  04, "SK", "QC", 19, BowlingCentre.Academy, true),  new SaveMatch(new Guid("1f8f4ac7-2c27-408c-bf4e-8ac7eeac4e9f"), tournamentId, year, division,  04, "MB", "SO", 21, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("a775eeaf-bb2d-4074-8f54-ec49e1ab7cea"), tournamentId, year, division,  05, "QC", "NO", 23, BowlingCentre.Academy, true),  new SaveMatch(new Guid("b0fe3b6c-bba6-43cf-9a59-49fbff568834"), tournamentId, year, division,  05, "AB", "SO", 25, BowlingCentre.Academy, true),  new SaveMatch(new Guid("df324190-7d40-4e58-bc4b-2a40a7d02f9c"), tournamentId, year, division,  05, "MB", "NL", 27, BowlingCentre.Academy, true),  new SaveMatch(new Guid("62a8f201-db91-42cd-bd28-a75bc9dbb3f0"), tournamentId, year, division,  05, "BC", "SK", 29, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("c2584bf7-7252-4587-be58-e1db503fcfa4"), tournamentId, year, division,  06, "NL", "BC", 23, BowlingCentre.Academy, true),  new SaveMatch(new Guid("4cd01041-3754-4aed-9a7f-02976187094c"), tournamentId, year, division,  06, "SK", "MB", 25, BowlingCentre.Academy, true),  new SaveMatch(new Guid("e0ffdde7-2164-4707-bd88-0a4ef81c75fb"), tournamentId, year, division,  06, "SO", "QC", 27, BowlingCentre.Academy, true),  new SaveMatch(new Guid("49308d38-1563-420a-8209-ba0f312ab4c6"), tournamentId, year, division,  06, "NO", "AB", 29, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("fdcc4304-9066-416c-8462-0a8fc27ce064"), tournamentId, year, division,  07, "NO", "SO", 23, BowlingCentre.Academy, true),  new SaveMatch(new Guid("cb85279c-53ea-40af-a07e-ff92c2b66f05"), tournamentId, year, division,  07, "QC", "AB", 25, BowlingCentre.Academy, true),  new SaveMatch(new Guid("8a3b543c-5368-487a-80f8-07324ddb9425"), tournamentId, year, division,  07, "NL", "SK", 27, BowlingCentre.Academy, true),  new SaveMatch(new Guid("a57eb097-3cae-4e11-94e2-f1f4a538c3c1"), tournamentId, year, division,  07, "MB", "BC", 29, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("fd4a5efd-6b83-40c8-a017-61c9c4d7c14c"), tournamentId, year, division,  08, "SO", "MB", 03, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("b5c18a8c-744e-4051-a698-cd112c5f1425"), tournamentId, year, division,  08, "QC", "SK", 05, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("9c0b0919-514d-4e89-a95e-325c17ec5aa3"), tournamentId, year, division,  08, "BC", "NO", 07, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("db0169ae-7ef1-4e09-a74a-01bed4651554"), tournamentId, year, division,  08, "AB", "NL", 09, BowlingCentre.Rossmere, true), 
                     new SaveMatch(new Guid("df01483a-699f-496c-9018-f6f939506fad"), tournamentId, year, division,  09, "BC", "NL", 03, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("b303a63c-5036-41ec-adb2-9367a68c3846"), tournamentId, year, division,  09, "AB", "NO", 05, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("8c0de229-4697-40fe-9f79-4476cdfb35f9"), tournamentId, year, division,  09, "MB", "SK", 07, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("7c504342-701b-46d4-8e25-e11b55dee546"), tournamentId, year, division,  09, "QC", "SO", 09, BowlingCentre.Rossmere, true), 
                     new SaveMatch(new Guid("72e79259-640b-4251-a4af-04e4f4f4d40a"), tournamentId, year, division,  10, "NO", "QC", 03, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("cf1a0059-0f54-473e-a5d3-fb0387e2790f"), tournamentId, year, division,  10, "NL", "MB", 05, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("504efb2d-7d6f-4725-9cbf-6055c2d6d79e"), tournamentId, year, division,  10, "SO", "AB", 07, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("c5d8430a-5e8f-44be-a503-925f11bb69b9"), tournamentId, year, division,  10, "SK", "BC", 09, BowlingCentre.Rossmere, true), 
                     new SaveMatch(new Guid("06916fee-be82-40d9-b5bd-8fde7b46d2d2"), tournamentId, year, division,  11, "AB", "SK", 03, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("116d1944-61c6-4393-8e03-92647cf00414"), tournamentId, year, division,  11, "SO", "BC", 05, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("086ccf3f-f8e1-46ed-bd30-63e1a2986be2"), tournamentId, year, division,  11, "NL", "QC", 07, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("302d01ab-daeb-4f20-b51a-b71860acd613"), tournamentId, year, division,  11, "NO", "MB", 09, BowlingCentre.Rossmere, true), 
                     new SaveMatch(new Guid("5fda8fbf-4c89-4c7c-b1dd-2e56f6ebcb1f"), tournamentId, year, division,  12, "NL", "SO", 11, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("c856b6b9-9fec-41be-826d-64e2b7aefe81"), tournamentId, year, division,  12, "SK", "NO", 15, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("667f36f1-2ebb-42ef-be5a-63c38428107b"), tournamentId, year, division,  12, "QC", "BC", 17, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("f826f0db-726b-452c-97ec-787588bdb88b"), tournamentId, year, division,  12, "MB", "AB", 19, BowlingCentre.Rossmere, true), 
                     new SaveMatch(new Guid("ed9f12fe-2ced-4d45-bbf0-1148712f1fd5"), tournamentId, year, division,  13, "AB", "QC", 11, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("81f37da8-2f3e-480b-a4e3-78f7b43f1dc0"), tournamentId, year, division,  13, "SO", "NO", 13, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("1b1014b4-a4fa-4f6b-9641-657414c7a0bf"), tournamentId, year, division,  13, "BC", "MB", 15, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("a1c0c3e9-5972-4f84-b37c-d32b6ec8b471"), tournamentId, year, division,  13, "SK", "NL", 17, BowlingCentre.Rossmere, true), 
                     new SaveMatch(new Guid("bb638807-cd28-4ee8-9246-f0109a1b6aec"), tournamentId, year, division,  14, "BC", "AB", 03, BowlingCentre.Academy, true),  new SaveMatch(new Guid("c43670c2-ead4-4137-a402-e9bf947c90cc"), tournamentId, year, division,  14, "NO", "NL", 05, BowlingCentre.Academy, true),  new SaveMatch(new Guid("09ee005f-5bb8-48c7-a4f3-a50839303b49"), tournamentId, year, division,  14, "MB", "QC", 09, BowlingCentre.Academy, true),  new SaveMatch(new Guid("6334b7e3-2b44-4f06-81dc-9dfb86501310"), tournamentId, year, division,  14, "SK", "SO", 13, BowlingCentre.Academy, true), 
                     new SaveMatch(new Guid("67dc9db6-a539-44e5-854a-a48804d3692d"), tournamentId, year, division,  15, "NO", "SK", 03, BowlingCentre.Academy, true),  new SaveMatch(new Guid("668917d7-9301-4cce-ab3d-38b6f39c9686"), tournamentId, year, division,  15, "AB", "MB", 07, BowlingCentre.Academy, true),  new SaveMatch(new Guid("5b2ba535-b0ff-4264-a893-1e6d94a77ce0"), tournamentId, year, division,  15, "SO", "NL", 11, BowlingCentre.Academy, true),  new SaveMatch(new Guid("a172cc10-a62b-4f7d-be2d-8f88bdd8ae57"), tournamentId, year, division,  15, "BC", "QC", 13, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("f35b10ee-29e6-4644-9a02-e8c0abdd4061"), tournamentId, year, division,  16, "QC", "NL", 03, BowlingCentre.Academy, true),  new SaveMatch(new Guid("f7cc6580-fbf9-465e-beac-86880b824aca"), tournamentId, year, division,  16, "BC", "SO", 05, BowlingCentre.Academy, true),  new SaveMatch(new Guid("be9f5745-a9f0-447c-a28c-d1d27e0867e8"), tournamentId, year, division,  16, "SK", "AB", 09, BowlingCentre.Academy, true),  new SaveMatch(new Guid("e4dc2601-248d-479c-a8b2-66b8bc977422"), tournamentId, year, division,  16, "MB", "NO", 13, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("8372a493-6a37-44c7-a8b9-db9d9153d0fe"), tournamentId, year, division,  17, "SO", "MB", 03, BowlingCentre.Academy, true),  new SaveMatch(new Guid("f5e2f9c5-fcd1-4295-a714-2083006faed9"), tournamentId, year, division,  17, "NO", "BC", 07, BowlingCentre.Academy, true),  new SaveMatch(new Guid("96b961f5-5994-41d1-a096-62cab65ae1ad"), tournamentId, year, division,  17, "SK", "QC", 11, BowlingCentre.Academy, true),  new SaveMatch(new Guid("71f007c0-b0b0-48c9-a5e5-a82fababbaa2"), tournamentId, year, division,  17, "NL", "AB", 13, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("ef260b19-d868-4132-b95d-e530751721ba"), tournamentId, year, division,  18, "QC", "AB", 05, BowlingCentre.Academy, true),  new SaveMatch(new Guid("e9b8423b-5f16-421d-b78f-1527f1818445"), tournamentId, year, division,  18, "NL", "SK", 07, BowlingCentre.Academy, true),  new SaveMatch(new Guid("606b3063-ffbf-437f-964a-1cf1b305038e"), tournamentId, year, division,  18, "NO", "SO", 09, BowlingCentre.Academy, true),  new SaveMatch(new Guid("6c7d70bd-7c1a-4b2f-99e5-50978e1c8d3b"), tournamentId, year, division,  18, "MB", "BC", 11, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("886aadd9-1896-4111-8cb3-a48e2eb64f4a"), tournamentId, year, division,  19, "NO", "AB", 13, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("8cd5fd29-fb6a-4a66-955f-66ca19537d62"), tournamentId, year, division,  19, "SO", "QC", 15, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("a11c4e37-3af9-41e3-966a-48d45e0d45b8"), tournamentId, year, division,  19, "SK", "MB", 17, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("da5a9fe2-b69b-4fdc-8a9d-93d2f365e495"), tournamentId, year, division,  19, "NL", "BC", 19, BowlingCentre.Rossmere, true),
                     new SaveMatch(new Guid("881f837d-ca32-41f5-9f7f-4c54c981a8f7"), tournamentId, year, division,  20, "QC", "MB", 13, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("33476778-b3f9-498d-a81f-449e868cd425"), tournamentId, year, division,  20, "AB", "BC", 15, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("ee5ec77c-6e4b-46b7-aeb4-26c83bc85683"), tournamentId, year, division,  20, "NL", "NO", 17, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("bcb5320e-02ba-4599-87d3-a8a89c0d281c"), tournamentId, year, division,  20, "SK", "SO", 19, BowlingCentre.Rossmere, true),
                     new SaveMatch(new Guid("cf03f4ef-c832-4048-9538-76272700474e"), tournamentId, year, division,  21, "BC", "SK", 13, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("ba30d979-818e-4031-b1a6-0371bbbd951c"), tournamentId, year, division,  21, "MB", "NL", 15, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("945c0213-5bff-45d7-bce3-39375088fb77"), tournamentId, year, division,  21, "AB", "SO", 17, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("e945c02f-0a92-4b3c-bacf-6d70b394094e"), tournamentId, year, division,  21, "QC", "NO", 19, BowlingCentre.Rossmere, true),
                };

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }

        public static void TeachingMen(MessageDispatcher dispatcher)
        {
            var scheduleId = new Guid("b47282f0-b6a2-4dc0-aee1-7a99d5e0ad68");
            var division = "Teaching Men";

            var commands = new List<SaveMatch>
                {
                     new SaveMatch(new Guid("1541e3a3-d08d-41c4-a749-ad266f662d3a"), tournamentId, year, division,  01,  "MB", "NO",  23, BowlingCentre.Academy, true),  new SaveMatch(new Guid("36eaa554-b775-429a-954c-e4932eddcf40"),  division, 01,  "SK", "AB",  25, BowlingCentre.Academy, true),  new SaveMatch(new Guid("379329cc-fb8d-4dfd-9376-934e464c708c"), tournamentId, year, division,  01,  "BC", "SO",  27, BowlingCentre.Academy, true),  new SaveMatch(new Guid("6de17e83-9310-4e9f-831e-037b0920efd6"), tournamentId, year, division,  01,  "QC", "NL",  29, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("07e3dad9-39a1-4e39-bf43-3a2f762c522e"), tournamentId, year, division,  02,  "BC", "QC",  23, BowlingCentre.Academy, true),  new SaveMatch(new Guid("6a2de1b7-c42b-4abe-9549-48d4fc03d58a"),  division, 02,  "SO", "NL",  25, BowlingCentre.Academy, true),  new SaveMatch(new Guid("043d9a27-de80-4838-81c5-43acf474b878"), tournamentId, year, division,  02,  "AB", "MB",  27, BowlingCentre.Academy, true),  new SaveMatch(new Guid("75ba7d7b-b526-47e3-9e58-4cf3d45d748a"), tournamentId, year, division,  02,  "NO", "SK",  29, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("a3ccafac-9626-4d3a-b229-752cdccda4d1"), tournamentId, year, division,  03,  "SO", "SK",  23, BowlingCentre.Academy, true),  new SaveMatch(new Guid("c26eec29-3bf5-4bdc-8614-0ae64caf9e28"),  division, 03,  "QC", "MB",  25, BowlingCentre.Academy, true),  new SaveMatch(new Guid("8a620190-1d27-4b93-9028-626f7d27510c"), tournamentId, year, division,  03,  "NL", "NO",  27, BowlingCentre.Academy, true),  new SaveMatch(new Guid("54ed9bd9-e599-4c23-897c-cc2e86d25c21"), tournamentId, year, division,  03,  "AB", "BC",  29, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("57b4fa75-2d2f-4f36-b897-cd946abe0105"), tournamentId, year, division,  04,  "NL", "AB",  23, BowlingCentre.Academy, true),  new SaveMatch(new Guid("367fa605-ef12-4e2f-bb8d-b4fb0a142ce5"),  division, 04,  "NO", "BC",  25, BowlingCentre.Academy, true),  new SaveMatch(new Guid("946b0016-57d6-463c-9b09-acb064ccf387"), tournamentId, year, division,  04,  "SK", "QC",  27, BowlingCentre.Academy, true),  new SaveMatch(new Guid("508e1669-0af7-4e73-82e4-8f72763fc4be"), tournamentId, year, division,  04,  "MB", "SO",  29, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("8297ae0f-d497-401c-851d-310ad5adbe2e"), tournamentId, year, division,  05,  "QC", "NO",  15, BowlingCentre.Academy, true),  new SaveMatch(new Guid("3bdee99d-479d-4c6f-99df-3b4cf079f7ba"),  division, 05,  "AB", "SO",  17, BowlingCentre.Academy, true),  new SaveMatch(new Guid("aea11ef3-88bd-4767-a3ce-a7eccf1d6b86"), tournamentId, year, division,  05,  "MB", "NL",  19, BowlingCentre.Academy, true),  new SaveMatch(new Guid("de7baca2-adce-40ef-b378-8eb5bc11793e"), tournamentId, year, division,  05,  "BC", "SK",  21, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("43260892-d0d5-41ed-b0d5-6f8531df9724"), tournamentId, year, division,  06,  "NL", "BC",  15, BowlingCentre.Academy, true),  new SaveMatch(new Guid("dbeef02a-5c83-41f8-8439-8b80fef7c7fe"),  division, 06,  "SK", "MB",  17, BowlingCentre.Academy, true),  new SaveMatch(new Guid("ef2e827f-5931-4d02-98ea-9fbb121a40d7"), tournamentId, year, division,  06,  "SO", "QC",  19, BowlingCentre.Academy, true),  new SaveMatch(new Guid("ff69b1c5-3519-42c2-804a-2df8137e638b"), tournamentId, year, division,  06,  "NO", "AB",  21, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("5fa6e3fa-2b98-4d7c-8d10-5f7e243e6e4a"), tournamentId, year, division,  07,  "NO", "SO",  15, BowlingCentre.Academy, true),  new SaveMatch(new Guid("90de26fa-85a3-4253-9fd5-b76fa74ffde5"),  division, 07,  "AB", "QC",  17, BowlingCentre.Academy, true),  new SaveMatch(new Guid("6baf6917-f3e4-49e1-9464-16133d89ce03"), tournamentId, year, division,  07,  "NL", "SK",  19, BowlingCentre.Academy, true),  new SaveMatch(new Guid("40bd8da6-c37d-439a-8d85-2988d6440e32"), tournamentId, year, division,  07,  "BC", "MB",  21, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("6537303c-a02b-43d2-9236-a7582fe67b35"), tournamentId, year, division,  08,  "BC", "AB",  3, BowlingCentre.Academy, true),   new SaveMatch(new Guid("38376d6c-bf37-4078-93a0-909dd24993ad"),  division, 08,  "NO", "NL",  5, BowlingCentre.Academy, true),   new SaveMatch(new Guid("21d3d356-12fa-41c2-bf15-6bdbc2a27126"), tournamentId, year, division,  08,  "MB", "QC",  09, BowlingCentre.Academy, true),  new SaveMatch(new Guid("4fcf5522-5a19-4888-967a-d0d86b5c7cc0"), tournamentId, year, division,  08,  "SK", "SO",  13, BowlingCentre.Academy, true), 
                     new SaveMatch(new Guid("6358abb0-2996-424f-9bd7-1e3be4bc9f5f"), tournamentId, year, division,  09,  "NO", "SK",  3, BowlingCentre.Academy, true),   new SaveMatch(new Guid("435e0a64-9c3e-4c3a-9aa8-1137371600f6"),  division, 09,  "AB", "MB",  7, BowlingCentre.Academy, true),   new SaveMatch(new Guid("1e17d1bd-4fb6-4c10-bdd2-5d4a35411d98"), tournamentId, year, division,  09,  "SO", "NL",  11, BowlingCentre.Academy, true),  new SaveMatch(new Guid("e54fc7e3-a182-4070-8942-2d772c563e7d"), tournamentId, year, division,  09,  "BC", "QC",  13, BowlingCentre.Academy, true), 
                     new SaveMatch(new Guid("916527bc-74bd-47a5-b6f8-4078b6504a3c"), tournamentId, year, division,  10,  "QC", "NL",  3, BowlingCentre.Academy, true),   new SaveMatch(new Guid("df42bc96-c8f3-4882-a2fd-bb2d86d07b70"),  division, 10,  "SO", "BC",  5, BowlingCentre.Academy, true),   new SaveMatch(new Guid("52a13b0f-fa19-479c-b0a1-78407e4bf2ef"), tournamentId, year, division,  10,  "SK", "AB",  09, BowlingCentre.Academy, true),  new SaveMatch(new Guid("783dfb45-8e2b-419f-8231-67f346b8be30"), tournamentId, year, division,  10,  "MB", "NO",  13, BowlingCentre.Academy, true), 
                     new SaveMatch(new Guid("e8ecea6a-5f06-4205-b1e6-fb33b2b6d15b"), tournamentId, year, division,  11,  "SO", "MB",  3, BowlingCentre.Academy, true),   new SaveMatch(new Guid("fc6f0752-33f9-4a9b-85ab-300452c34445"),  division, 11,  "NO", "BC",  7, BowlingCentre.Academy, true),   new SaveMatch(new Guid("3654abb0-9f26-420e-800f-d9b7431d336b"), tournamentId, year, division,  11,  "SK", "QC",  11, BowlingCentre.Academy, true),  new SaveMatch(new Guid("746bb43f-12b1-4261-b527-f86718a36811"), tournamentId, year, division,  11,  "NL", "AB",  13, BowlingCentre.Academy, true), 
                     new SaveMatch(new Guid("678ee20a-49cf-44da-bcd1-cdb280fa4352"), tournamentId, year, division,  12,  "QC", "AB",  5, BowlingCentre.Academy, true),   new SaveMatch(new Guid("5f5aeb0b-7cc7-4cae-bfef-fdf154772693"),  division, 12,  "NL", "SK",  7, BowlingCentre.Academy, true),   new SaveMatch(new Guid("a310c35f-eb01-4fd8-bfcf-24816a452218"), tournamentId, year, division,  12,  "NO", "SO",  09, BowlingCentre.Academy, true),  new SaveMatch(new Guid("39949ffc-8ee9-4fd1-9810-295ecb82e9df"), tournamentId, year, division,  12,  "MB", "BC",  11, BowlingCentre.Academy, true), 
                     new SaveMatch(new Guid("bb3271db-8c52-474a-9e16-f253816605e3"), tournamentId, year, division,  13,  "MB", "SK",  5, BowlingCentre.Academy, true),   new SaveMatch(new Guid("df2472d3-90b1-4722-b9e2-ab8f11bdaca1"),  division, 13,  "QC", "SO",  7, BowlingCentre.Academy, true),   new SaveMatch(new Guid("3c2f1ae9-6d83-4d7a-8194-efa610b8b0eb"), tournamentId, year, division,  13,  "BC", "NL",  09, BowlingCentre.Academy, true),  new SaveMatch(new Guid("e8c25294-45c3-4e8a-bfd9-88dac22f7c32"), tournamentId, year, division,  13,  "AB", "NO",  11, BowlingCentre.Academy, true), 
                     new SaveMatch(new Guid("9cf6020a-303c-4ead-ae4c-a3db3e0583f9"), tournamentId, year, division,  14,  "NO", "QC",  13, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("21e6280d-10c5-43ee-8de7-6b9500ba1cf4"),  division, 14,  "NL", "MB",  15, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("24dc14f2-0ca5-4bcd-9b1d-c7dbb129f13d"), tournamentId, year, division,  14,  "SO", "AB",  17, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("508250f3-2129-4efd-b745-01ad694ceaed"), tournamentId, year, division,  14,  "SK", "BC",  19, BowlingCentre.Rossmere, true), 
                     new SaveMatch(new Guid("8de5459f-dbfe-495b-9819-367dacfc223c"), tournamentId, year, division,  15,  "SO", "MB",  13, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("1e1848bf-0538-4e67-9f84-175972d2d512"),  division, 15,  "QC", "SK",  15, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("c57c1ea6-1290-4ac1-a672-9109885f9bd3"), tournamentId, year, division,  15,  "BC", "NO",  17, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("7a787380-3898-43ff-87c8-aa3b37ff61af"), tournamentId, year, division,  15,  "AB", "NL",  19, BowlingCentre.Rossmere, true),
                     new SaveMatch(new Guid("80ceefba-1dfd-4a54-b7b3-d4fcd2b9d59d"), tournamentId, year, division,  16,  "AB", "SK",  13, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("4659c6aa-6e53-4bad-b59a-f76e4980a5d0"),  division, 16,  "BC", "SO",  15, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("5c2d8564-2bf1-4946-9559-915ab2bcda4e"), tournamentId, year, division,  16,  "NL", "QC",  17, BowlingCentre.Rossmere, true), new SaveMatch(new Guid("69fdbaab-427c-4052-b046-9724700b8f13"), tournamentId, year, division,  16,  "NO", "MB",  19, BowlingCentre.Rossmere, true),
                     new SaveMatch(new Guid("9c7d6f00-08d3-49d4-80a3-1b8b90d112be"), tournamentId, year, division,  17,  "NL", "SO",  1, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("3d98f3f7-b1b4-4981-ba72-69a5a022ed66"),  division, 17,  "SK", "NO",  3, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("b3a34a23-8b54-4206-81db-1c2039708abf"), tournamentId, year, division,  17,  "QC", "BC",  5, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("1cc21500-5d9c-40bb-85f8-2f641aadc057"), tournamentId, year, division,  17,  "MB", "AB",  7, BowlingCentre.Rossmere, true),
                     new SaveMatch(new Guid("4a359adf-f7f6-4aa9-87b9-99cad7635793"), tournamentId, year, division,  18,  "QC", "AB",  3, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("cbdebfec-276b-43c7-a931-6c009c7c700f"),  division, 18,  "SO", "NO",  5, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("863e89d2-53bb-4345-b84b-f4fe809a2857"), tournamentId, year, division,  18,  "SK", "NL",  7, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("d8575789-82a1-4f84-9177-bdeb795786b1"), tournamentId, year, division,  18,  "MB", "BC",  9, BowlingCentre.Rossmere, true),
                     new SaveMatch(new Guid("e3cb377c-afd3-41cd-bc26-f002bac1d8e2"), tournamentId, year, division,  19,  "NO", "AB",  1, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("42ab9d40-8066-4aea-977b-5174b68b4ad8"),  division, 19,  "SK", "MB",  5, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("8d75384e-a734-4811-bd6b-226125b3d799"), tournamentId, year, division,  19,  "SO", "QC",  7, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("4e1d446a-5e1c-4e1f-827e-5e58e94b9752"), tournamentId, year, division,  19,  "NL", "BC",  9, BowlingCentre.Rossmere, true),
                     new SaveMatch(new Guid("b3963fde-c4f6-4f4a-906b-7c69f5101fae"), tournamentId, year, division,  20,  "QC", "MB",  1, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("b4712c0c-3d18-4f09-8a0c-a21da8dc1654"),  division, 20,  "NL", "NO",  5, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("719b3ac0-5837-42cb-8538-ffda79291225"), tournamentId, year, division,  20,  "AB", "BC",  7, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("4cf70eff-b56e-4ec9-b938-ef2fa8242301"), tournamentId, year, division,  20,  "SK", "SO",  9, BowlingCentre.Rossmere, true),
                     new SaveMatch(new Guid("e39d4df1-c171-4b97-a6b8-f5ca46a4b5c9"), tournamentId, year, division,  21,  "BC", "SK",  1, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("2460fd8d-4542-44d2-8d08-6157a5449b63"),  division, 21,  "MB", "NL",  3, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("2268556f-a3cd-44b3-afaf-341fa901e7ac"), tournamentId, year, division,  21,  "AB", "SO",  5, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("5de7e183-16d3-400d-99d2-8b2713b1ef18"), tournamentId, year, division,  21,  "QC", "NO",  9, BowlingCentre.Rossmere, true),
                };

            foreach (var command in commands)
                try
                {
                    dispatcher.SendCommand(command);
                }
                catch (MBACNationals.Scores.MatchAlreadyCreated e)
                {
                }
        }

        public static void Seniors(MessageDispatcher dispatcher)
        {
            var scheduleId = new Guid("934315dd-f51d-4ee5-b53b-a7cefde960d0");
            var division = "Seniors";

            var commands = new List<SaveMatch>
                {
                     new SaveMatch(new Guid("f189e07b-8492-43b1-9f39-96a357800418"), tournamentId, year, division, 01,  "BC", "SK",  1, BowlingCentre.Coronation, true), new SaveMatch(new Guid("a92009cf-fb7e-4497-a37d-1fa6ce6341d1"), tournamentId, year, division,  01,  "NO", "AB",  3, BowlingCentre.Coronation, true), new SaveMatch(new Guid("f12183be-f591-46d8-a03f-f091f023d5c1"), tournamentId, year, division,  01,  "QC", "SO",  5, BowlingCentre.Coronation, true), new SaveMatch(new Guid("98ada3ae-1e85-4cdc-b89f-c8f0a06b5403"), tournamentId, year, division,  01,  "NL", "MB",  7, BowlingCentre.Coronation, true),
                     new SaveMatch(new Guid("906be187-e639-414d-a28b-8f204018ccf9"), tournamentId, year, division, 02,  "QC", "NL",  1, BowlingCentre.Coronation, true), new SaveMatch(new Guid("22847ae0-e2ab-40dd-be7c-7b3c376e2bd4"), tournamentId, year, division,  02,  "SO", "MB",  3, BowlingCentre.Coronation, true), new SaveMatch(new Guid("452c3363-4054-449a-8dc1-61b51ac1cf2f"), tournamentId, year, division,  02,  "AB", "BC",  5, BowlingCentre.Coronation, true), new SaveMatch(new Guid("ed7506a9-7499-4cad-96d0-a28203c26158"), tournamentId, year, division,  02,  "SK", "NO",  7, BowlingCentre.Coronation, true),
                     new SaveMatch(new Guid("a45e27e2-07f1-459f-9c32-e2d51e072fd9"), tournamentId, year, division, 03,  "SO", "NO",  1, BowlingCentre.Coronation, true), new SaveMatch(new Guid("ce38cf3c-d5b4-4842-a054-e632a3ace6cf"), tournamentId, year, division,  03,  "NL", "BC",  3, BowlingCentre.Coronation, true), new SaveMatch(new Guid("d9bd8145-de6b-482a-b5e9-631d398a3cc6"), tournamentId, year, division,  03,  "MB", "SK",  5, BowlingCentre.Coronation, true), new SaveMatch(new Guid("72703047-b250-4ad6-a455-e218ee5aad36"), tournamentId, year, division,  03,  "AB", "QC",  7, BowlingCentre.Coronation, true),
                     new SaveMatch(new Guid("d831cacb-5c28-426b-829a-b0c865331737"), tournamentId, year, division, 04,  "MB", "AB",  1, BowlingCentre.Coronation, true), new SaveMatch(new Guid("ab6e196c-74cf-4e9b-a71e-68321135b739"), tournamentId, year, division,  04,  "SK", "QC",  3, BowlingCentre.Coronation, true), new SaveMatch(new Guid("fad4ca09-158a-4451-ad43-23fbb710d096"), tournamentId, year, division,  04,  "NO", "NL",  5, BowlingCentre.Coronation, true), new SaveMatch(new Guid("21bb3fab-391b-4792-9a74-4b70904cefff"), tournamentId, year, division,  04,  "BC", "SO",  7, BowlingCentre.Coronation, true),
                     new SaveMatch(new Guid("d7699a57-09b9-42ea-b00b-ada02c1ca7e1"), tournamentId, year, division, 05,  "NL", "SK",  1, BowlingCentre.Coronation, true), new SaveMatch(new Guid("77c76147-1dc5-402a-8dbe-8100a2ae4cc0"), tournamentId, year, division,  05,  "AB", "SO",  3, BowlingCentre.Coronation, true), new SaveMatch(new Guid("bef619ac-6e85-413b-9ac1-94be6d6adbae"), tournamentId, year, division,  05,  "BC", "MB",  5, BowlingCentre.Coronation, true), new SaveMatch(new Guid("17061c1e-f377-41a8-9168-cc70bdf1d3b9"), tournamentId, year, division,  05,  "QC", "NO",  7, BowlingCentre.Coronation, true),
                     new SaveMatch(new Guid("c58a6712-3f55-4af4-96a2-728eb4845609"), tournamentId, year, division, 06,  "MB", "QC",  1, BowlingCentre.Coronation, true), new SaveMatch(new Guid("e16af3e3-c55a-4843-9378-8d508b26a7b0"), tournamentId, year, division,  06,  "NO", "BC",  3, BowlingCentre.Coronation, true), new SaveMatch(new Guid("404a4c61-e2ac-47f8-aa84-6be6c7ad5b91"), tournamentId, year, division,  06,  "SO", "NL",  5, BowlingCentre.Coronation, true), new SaveMatch(new Guid("fde41198-ed1a-4427-83ac-a4d7e32454a5"), tournamentId, year, division,  06,  "SK", "AB",  7, BowlingCentre.Coronation, true),
                     new SaveMatch(new Guid("c09fe1fc-1bca-4439-8952-edf4e65d78f0"), tournamentId, year, division, 07,  "SK", "SO",  1, BowlingCentre.Coronation, true), new SaveMatch(new Guid("efdacb72-667a-4429-983c-d800044f0cac"), tournamentId, year, division,  07,  "NL", "AB",  3, BowlingCentre.Coronation, true), new SaveMatch(new Guid("d8e94ad7-d5e5-48b7-aaf6-108671e07944"), tournamentId, year, division,  07,  "MB", "NO",  5, BowlingCentre.Coronation, true), new SaveMatch(new Guid("ae153256-a02d-459d-9cd7-6df64a13b0cd"), tournamentId, year, division,  07,  "BC", "QC",  7, BowlingCentre.Coronation, true),
                     new SaveMatch(new Guid("fe156713-7abf-44ba-9cb5-6a08d30d3256"), tournamentId, year, division, 08,  "SO", "BC",  13, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("256efacc-c54f-4790-8ee4-eac8d94dc7a9"), tournamentId, year, division,  08,  "NL", "NO",  15, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("6399cfbc-e707-43ad-ae30-890aca375421"), tournamentId, year, division,  08,  "QC", "SK",  17, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("722e88d4-1007-40e8-ab52-ee4f74e5143c"), tournamentId, year, division,  08,  "AB", "MB",  19, BowlingCentre.Rossmere, true), 
                     new SaveMatch(new Guid("c36248b6-b823-4876-ba5c-e5a88e3e8214"), tournamentId, year, division, 09,  "QC", "MB",  13, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("8ab1b6f9-6593-4725-8466-156af71d3cf4"), tournamentId, year, division,  09,  "AB", "SK",  15, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("7f16c223-dc6c-4f1f-b991-6e2d0af01ac7"), tournamentId, year, division,  09,  "BC", "NO",  17, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("c66ac46f-b6d5-4aff-8c55-cc65c1b08354"), tournamentId, year, division,  09,  "NL", "SO",  19, BowlingCentre.Rossmere, true), 
                     new SaveMatch(new Guid("f14676bf-7efb-4446-a35c-99745c8c076a"), tournamentId, year, division, 10,  "SK", "NL",  13, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("dbfeed14-3ee1-4d20-b65f-91fad93572b2"), tournamentId, year, division,  10,  "MB", "BC",  15, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("bc1227df-0161-4825-9307-cb126d59597f"), tournamentId, year, division,  10,  "SO", "AB",  17, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("76f231f8-e3da-415d-8fe1-cda6b48e9f53"), tournamentId, year, division,  10,  "NO", "QC",  19, BowlingCentre.Rossmere, true), 
                     new SaveMatch(new Guid("d6e7a548-bac1-4a43-adce-7b335ef3f3aa"), tournamentId, year, division, 11,  "AB", "NO",  13, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("7404813d-30d2-4240-92df-1dc0bf62afbb"), tournamentId, year, division,  11,  "QC", "SO",  15, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("ebbd50f1-3d54-4d44-9f80-88c80470c0f9"), tournamentId, year, division,  11,  "MB", "NL",  17, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("cab46263-4c21-49b9-8b4c-d7ce8c07d258"), tournamentId, year, division,  11,  "SK", "BC",  19, BowlingCentre.Rossmere, true), 
                     new SaveMatch(new Guid("b6d024bd-9055-4109-bed2-31c9bb0e4e57"), tournamentId, year, division, 12,  "MB", "SO",  03, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("a5e7efdd-8f3e-48bc-b4e9-cadb1cdde038"), tournamentId, year, division,  12,  "BC", "AB",  05, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("a8561be7-7ec1-4d27-9613-e599e45a9a2c"), tournamentId, year, division,  12,  "NO", "SK",  07, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("c26e89da-0db1-4b1f-a103-4454a833419d"), tournamentId, year, division,  12,  "NL", "QC",  09, BowlingCentre.Rossmere, true), 
                     new SaveMatch(new Guid("8f37a055-ec62-4030-a1f5-59c5e2aa6ddf"), tournamentId, year, division, 13,  "AB", "NL",  03, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("34bacd39-f4b1-468b-9a1a-5e6a1d49fb3d"), tournamentId, year, division,  13,  "SO", "SK",  05, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("d455ff08-fdad-4389-a974-74d14d0cc387"), tournamentId, year, division,  13,  "QC", "BC",  07, BowlingCentre.Rossmere, true),  new SaveMatch(new Guid("ec12e59b-3631-42ff-87b9-17efaae07018"), tournamentId, year, division,  13,  "NO", "MB",  09, BowlingCentre.Rossmere, true), 
                     new SaveMatch(new Guid("557c6d59-fc6a-4668-8373-c460f9e4f943"), tournamentId, year, division, 14,  "QC", "AB",  15, BowlingCentre.Academy, true),   new SaveMatch(new Guid("13f78321-a2bd-42fe-b6df-c16e932f2c76"), tournamentId, year, division,  14,  "NO", "SO",  17, BowlingCentre.Academy, true),   new SaveMatch(new Guid("0fe72887-7e34-4a88-be6d-cc42326f6f63"), tournamentId, year, division,  14,  "BC", "NL",  19, BowlingCentre.Academy, true),   new SaveMatch(new Guid("095d6417-ea4a-408d-9fa6-df6d379a0886"), tournamentId, year, division,  14,  "SK", "MB",  21, BowlingCentre.Academy, true), 
                     new SaveMatch(new Guid("13465706-3f6a-47a1-af2d-feb7ed07918b"), tournamentId, year, division, 15,  "SK", "NO",  15, BowlingCentre.Academy, true),   new SaveMatch(new Guid("9002509d-f7fa-492e-a8c0-996ec43f57f7"), tournamentId, year, division,  15,  "QC", "NL",  17, BowlingCentre.Academy, true),   new SaveMatch(new Guid("4669ae87-720b-4f88-bb00-783c4da803e1"), tournamentId, year, division,  15,  "SO", "MB",  19, BowlingCentre.Academy, true),   new SaveMatch(new Guid("67fd4d34-d96c-4d0c-8f3c-2f9800bd7c5d"), tournamentId, year, division,  15,  "AB", "BC",  21, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("3faad66d-ed24-483c-a020-fee6d97ff37c"), tournamentId, year, division, 16,  "BC", "SO",  15, BowlingCentre.Academy, true),   new SaveMatch(new Guid("8ca24b7e-940a-46bf-b08a-5b4d02946cde"), tournamentId, year, division,  16,  "MB", "AB",  17, BowlingCentre.Academy, true),   new SaveMatch(new Guid("4b7206a0-ce77-448b-a312-77d8d5f17dc4"), tournamentId, year, division,  16,  "SK", "QC",  19, BowlingCentre.Academy, true),   new SaveMatch(new Guid("e6dfbbc0-1046-49dd-b356-7f62336c16fd"), tournamentId, year, division,  16,  "NO", "NL",  21, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("b845110a-9c0f-4e45-9d58-0d4a2d2c649f"), tournamentId, year, division, 17,  "NL", "MB",  15, BowlingCentre.Academy, true),   new SaveMatch(new Guid("bd42032e-4d08-40e0-8508-50e8b1872c04"), tournamentId, year, division,  17,  "BC", "SK",  17, BowlingCentre.Academy, true),   new SaveMatch(new Guid("2c3d2ef0-5bbe-4696-9afc-346765ad6e8c"), tournamentId, year, division,  17,  "NO", "AB",  19, BowlingCentre.Academy, true),   new SaveMatch(new Guid("40662652-da9b-4c03-b8e0-63e525d354a4"), tournamentId, year, division,  17,  "SO", "QC",  21, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("0ab2b483-9fc8-4481-9e9d-654e1437f3de"), tournamentId, year, division, 18,  "NO", "BC",  15, BowlingCentre.Academy, true),   new SaveMatch(new Guid("affdd9ab-cafd-46bc-ab7b-3dbac6a399ff"), tournamentId, year, division,  18,  "SO", "NL",  17, BowlingCentre.Academy, true),   new SaveMatch(new Guid("f706e837-15ba-4a28-af0b-fc3a2e945533"), tournamentId, year, division,  18,  "MB", "QC",  19, BowlingCentre.Academy, true),   new SaveMatch(new Guid("c6110011-163d-410c-a30f-1505bc52ff60"), tournamentId, year, division,  18,  "SK", "AB",  21, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("7a0daf36-350e-4515-a244-d93fdfa71ba0"), tournamentId, year, division, 19,  "SK", "SO",  05, BowlingCentre.Academy, true),   new SaveMatch(new Guid("0b6ac538-8bc8-445e-814f-93d226aa5089"), tournamentId, year, division,  19,  "NO", "MB",  07, BowlingCentre.Academy, true),   new SaveMatch(new Guid("c4db9027-747a-497e-94b5-62a5ae8ef464"), tournamentId, year, division,  19,  "NL", "AB",  09, BowlingCentre.Academy, true),   new SaveMatch(new Guid("33120f47-b5c7-49fb-80a1-ddadec8d5dd1"), tournamentId, year, division,  19,  "BC", "QC",  11, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("00ff67bd-4f63-43e7-9182-b5bae40a49ec"), tournamentId, year, division, 20,  "QC", "NO",  05, BowlingCentre.Academy, true),   new SaveMatch(new Guid("baf44246-f262-4ad7-b136-fdc98d238245"), tournamentId, year, division,  20,  "SK", "NL",  07, BowlingCentre.Academy, true),   new SaveMatch(new Guid("0e99712d-2ee4-4559-9f1a-3ab957165fa6"), tournamentId, year, division,  20,  "BC", "MB",  09, BowlingCentre.Academy, true),   new SaveMatch(new Guid("3d62bf68-fe69-4b19-be36-59943f65e5f6"), tournamentId, year, division,  20,  "AB", "SO",  11, BowlingCentre.Academy, true),
                     new SaveMatch(new Guid("993dec21-76e6-4c2b-9d15-9909f82bd7c7"), tournamentId, year, division, 21,  "NL", "BC",  05, BowlingCentre.Academy, true),   new SaveMatch(new Guid("2d688c4d-87f5-4744-a666-7c1d6cce46a1"), tournamentId, year, division,  21,  "AB", "QC",  07, BowlingCentre.Academy, true),   new SaveMatch(new Guid("085e8eda-b48b-4bde-98c3-e9c8c7c7e1e2"), tournamentId, year, division,  21,  "SO", "NO",  09, BowlingCentre.Academy, true),   new SaveMatch(new Guid("4b0d6239-5826-41a6-937a-1b0b1e80ffb7"), tournamentId, year, division,  21,  "MB", "SK",  11, BowlingCentre.Academy, true),
                };

            foreach (var command in commands)
            try
            {
                dispatcher.SendCommand(command);
            }
            catch (MBACNationals.Scores.MatchAlreadyCreated e)
            {
            }
        }
    }
     * */
}
