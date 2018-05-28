# Reminder-V1.2
A reminder app that will help on daily events. App can notify you on exact time of the event via message pop up box / message box also store your daily events for the year.

# View events for the day , get notifications and much more
![Alt text](https://image.ibb.co/iBbB0y/wo.png "Screenshot")

# Input
- Time in (hh.mm.ss) format.
- You have to select from AM/PM.
- Date in (dd.MM.yy) format.
- Custom Message.

# Save to database

- Database name : data
- feilds : date - varchar (50) , time - varchar(50) , msg - varchar(MAX)
- Save to database option let you save input date , time , message in the database

# Minimize to tray

- Let you minimize the Reminder app v1.2 to the system tray with a custom notification
- Reminds you about the event on time even when running on the system tray.

# Show events button

- click on a date 
- Then click on show events button 
- This will show all the events on that day

# Requirements

- ASP.NET
- Language : c#
- Microsoft sql express 2012 ( anyway it is just a simple table with 3 columns as mentioned above)
- You can find databasefile.sql is in the root dir.
