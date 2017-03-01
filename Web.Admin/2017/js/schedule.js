﻿
$(window).scroll(function () {
    if ($(this).scrollTop() > 100) {
        $('.navbar-fixed-top').addClass('opaque');
    } else {
        $('.navbar-fixed-top').removeClass('opaque');
    }
});
function schedule() {
    var now = new Date();
    var date = now.getDate();
    var month = now.getMonth();
    var month = month + 1;
    var yyyy = now.getFullYear(); //yields year

    var msg;

    //Day 1 at bottom, because it's the default
    if (yyyy == 2017 && month == 6 && date == 29)
        msg = "<h3 id='day2' class='day'>Day 2 - Thursday, June 29th</h3><h4 class='time'>8:00 am - 4:00 pm</h4><p class='details'><span class='location'>Delta/Mariott</span><br />Registrations for Early Arrivals<br />Participants & Guests<br /></p><h4 class='time'>11:30 am - 3:00 pm</h4><p class='details'><span class='location'>TBD</span><br />Practice Lanes Available<br /></p><h4 class='time'>4:00 pm - 5:00 pm</h4><p class='details'><span class='location'>Delta/Mariott</span><br />Officials Meeting - Judges of Play<br /></p><h4 class='time'>5:00 pm - 6:00 pm</h4><p class='details'><span class='location'>Delta/Mariott</span><br />Coaches/Managers Meeting<br />All Divisions<br /></p><h4 class='time'>6:00 pm - 7:30 pm</h4><p class='details'><span class='location'>Delta/Mariott</span><br />Team & Provincial Photos<br /></p><h4 class='time'>8:00 pm - Midnight</h4><p class='details'><span class='location'>Delta/Mariott</span><br />Opening Ceremonies & Meet & Greet<br /></p>";
    else if (yyyy == 2017 && month == 6 && date == 30)
        msg = "<h3 id='day3' class='day'>Day 3 - Friday, June 30th</h3><h4 class='time'>All Day</h4><p class='details'><span class='location'>TODO: Location</span><br /></p><h4 class='time'>7:30 am</h4><p class='details'><span class='location'>Delta/Mariott</span><br />Buses Depart<br />All Teams</p><h4 class='time'>8:00 am - 8:30 am</h4><p class='details'><span class='location'>TBD</span><br />Lanes on for Practice</p><h4 class='time'>8:30 am - 6:00 pm</h4><p class='details'><span class='location'>TBD</span><br />Bowling - 7 Games<br />All Teams</p><h4 class='time'>11:30 am</h4><p class='details'><span class='location'>Delta/Mariott</span><br />Buses Depart<br />Tournament Singles</p><h4 class='time'>12:15 - 12:30 pm</h4><p class='details'><span class='location'>TBD</span><br />Lanes on for Practice<br />Tournament Singles</p><h4 class='time'>12:30 pm - 4:00 pm</h4><p class='details'><span class='location'>TBD</span><br />Bowling - 7 games<br />Tournament Singles</p><h4 class='time'>12:20 - 1:25 pm</h4><p class='details'><span class='location'>TBD</span><br />Lunch Break<br />Senior Teams</p><h4 class='time'>1:30 - 2:15pm</h4><p class='details'><span class='location'>TBD</span><br />Lunch Break - Teaching Teams</p><h4 class='time'>6:30 pm</h4><p class='details'><span class='location'>Lanes to Delta/Mariott</span><br />Buses depart from Lanes to Hotel<br />All Teams & Singles</p><h4 class='time'>7:00 pm - 1:00 am</h4><p class='details'><span class='location'>Delta/Mariott</span><br />Free Night</p>";
    else if (yyyy == 2017 && month == 7 && date == 1)
        msg = "<h3 id='day4' class='day'>Day 4 - Saturday, July 1st</h3><h4 class='time'>All Day</h4><p class='details'><span class='location'>TODO: Location</span><br /></p><h4 class='time'>8:00 am</h4><p class='details'><span class='location'>Delta/Mariott</span><br />Buses Depart<br />All Teams/Singles</p><h4 class='time'>8:30 am - 9:00 am</h4><p class='details'><span class='location'>TBD</span><br />Lanes on for Practice</p><h4 class='time'>9:00 am - 4:00 pm</h4><p class='details'><span class='location'>TBD</span><br />Bowling - 5 Games<br />All Teams</p><h4 class='time'>8:30 am - Noon</h4><p class='details'><span class='location'>TBD</span><br />Bowling - 7 Games<br />Tournament Singles</p><h4 class='time'>Noon - 12:45 pm</h4><p class='details'><span class='location'>TBD</span><br />Lunch Break<br />Senior Teams</p><h4 class='time'>1:10 pm - 1:55 pm</h4><p class='details'><span class='location'>TBD</span><br />Lunch Break<br />Teaching Teams</p><h4 class='time'>4:15 pm</h4><p class='details'><span class='location'>Lanes to Delta/Mariott</span><br />Buses Depart from Lanes for Hotel<br />Tournament Singles & Teams</p><h4 class='time'>4:20 pm</h4><p class='details'><span class='location'>Lanes to Delta/Mariott</span><br />Buses Depart from Lanes for Hotel<br />Teaching & Seniors Teams</p><h4 class='time'>5:00 - 6:00 pm</h4><p class='details'><span class='location'>Delta/Mariott</span><br />Saskatchewan Night - Cocktails</p><h4 class='time'>6:00 pm - 1:00 am</h4><p class='details'><span class='location'>Delta/Mariott</span><br />Saskatchewan Night - Grammy Theme</p>";
    else if (yyyy == 2017 && month == 7 && date == 2)
        msg = "<h3 id='day5' class='day'>Day 5 - Sunday, July 2nd</h3><h4 class='time'>All Day</h4><p class='details'><span class='location'>TODO: Location</span><br /></p><h4 class='time'>8:00 am</h4><p class='details'><span class='location'>Delta/Mariott</span><br />Buses Depart<br />All Teams/Singles</p><h4 class='time'>8:30 am - 9:00 am</h4><p class='details'><span class='location'>TBD</span><br />Lanes on for Practice</p><h4 class='time'>9:00 am - 1:30 pm</h4><p class='details'><span class='location'>TBD</span><br />Bowling - 6 Games<br />All Teams</p><h4 class='time'>10:30 am - 2:00 pm</h4><p class='details'><span class='location'>TBD</span><br />Bowling - 7 Games<br />Tournament Singles</p><h4 class='time'>2:30 pm - 3:30 pm</h4><p class='details'><span class='location'>TBD</span><br />Bowling - Tie Breakers - If Necessary</p><h4 class='time'>11:50 am - 12:35 pm</h4><p class='details'><span class='location'>TBD</span><br />Lunch Break<br />Teaching Teams</p><h4 class='time'>1:00 pm - 1:45 pm</h4><p class='details'><span class='location'>TBD</span><br />Lunch Break<br />Senior Teams</p><h4 class='time'>4:30 pm</h4><p class='details'><span class='location'>Lanes to Delta/Mariott</span><br />Buses Depart from Lanes for Hotel<br />Tournament Singles & Teams</p><h4 class='time'>5:30 pm</h4><p class='details'><span class='location'>Lanes to Delta/Mariott</span><br />Buses Depart from Lanes for Hotel<br />Teaching & Seniors Teams</p><h4 class='time'>9:00 pm</h4><p class='details'><span class='location'>Delta/Mariott</span><br />Canada's 150th Cake Celebration</p><h4 class='time'>10:00 pm</h4><p class='details'><span class='location'>Delta/Mariott</span><br />Elimination Draw</p>";
    else if (yyyy == 2017 && month == 7 && date == 3)
        msg = "<h3 id='day6' class='day'>Day 6 - Monday, July 3rd</h3><h4 class='time'>8:00 am</h4><p class='details'><span class='location'>Delta/Mariott</span><br />Buses Depart<br />All teams</p><h4 class='time'>8:45 am - 9:00 am</h4><p class='details'><span class='location'>TBD</span><br />Lanes on for Practice</p><h4 class='time'>9:00 am - 1:00 pm</h4><p class='details'><span class='location'>TBD</span><br />Bowling - 3 Games<br />All Teams</p><h4 class='time'>Noon</h4><p class='details'><span class='location'>Delta/Mariott</span><br />Buses Depart<br />Tournament Singles</p><h4 class='time'>2:00 pm</h4><p class='details'><span class='location'>Lanes to Delta/Mariott</span><br />Buses Depart from Lanes to Hotel</p><h4 class='time'>1:30 pm - 4:00 pm</h4><p class='details'><span class='location'>TBD</span><br />Bowling - Stepladder Finals<br />Tournament Singles</p><h4 class='time'>4:00 pm - 4:30 pm</h4><p class='details'><span class='location'>Lanes to Delta/Mariott</span><br />Buses Depart from Lanes to Hotel</p><h4 class='time'>5:00 pm - 6:00 pm</h4><p class='details'><span class='location'>Delta/Mariott</span><br />Victory Banquet - Cocktails</p><h4 class='time'>6:00 pm - 6:30 pm</h4><p class='details'><span class='location'>Delta/Mariott</span><br />Victory Banquet - Parade of Provinces & Head Table Introductions</p>        <h4 class='time'>6:30 pm - 7:30 pm</h4><p class='details'><span class='location'>Delta/Mariott</span><br />Victory Banquet - Dinner</p>        <h4 class='time'>7:30 pm - 9:30 pm</h4><p class='details'><span class='location'>Delta/Mariott</span><br />Victory Banquet - Awards Presentations</p><h4 class='time'>9:30 pm - 1:00 am</h4><p class='details'><span class='location'>Delta/Mariott</span><br />Victory Banquet - Dance</p>";
    else if (yyyy == 2017 && month == 7 && date == 4)
        msg = "<h3 id='day7' class='day'>Day 7 - Tuesday, July 4th</h3><h4 class='time'>All Day</h4><p class='details'><span class='location'>Delta/Mariott</span><br />Departures<br />All Participants & Guests</p><h4 class='time'>10:00 am - 5:00 pm</h4><p class='details'><span class='location'>Delta/Marriott</span><br />Provincial Delegates Meetings</p>";
    else
        msg = "<h3 id='day1' class='day'>Day 1 - Wednesday, June 28th</h3><h4 class='time'>All Day</h4><p class='details'><span class='location'>Delta/Mariott</span><br />Registrations for Early Arrivals<br />Participants & Guests<br /></p>";

    $('.message').html(msg);  //add message to the element with class message
}
schedule();