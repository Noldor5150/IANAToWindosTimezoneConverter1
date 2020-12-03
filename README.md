# IANAToWindosTimezoneConverter1
### ABOUT

###### It is a lightweight API to convert quickly between IANA and Windows time zone names.
######  Also it converts DateTime value form one time zone to another.

### How to use (test) it

###### It works via JSON requests/response, different endpoints via GET method (you can use e.g. POSTMAN).
####   endpoint  : "/iana"
###### Converts an IANA time zone name to the best fitting Windows time zone ID. 
###### JSON request example : {"name":"America/New_York"}
####   endpoint  : "/windows"
###### Convert a Windows time zone name to the best fitting IANA time zone name.
###### JSON request example : {"name":"Eastern Standard Time"}
####   endpoint  : "/dateTime"
###### Converts DateTime value form one time zone to another in both o mixed IANA/Windows time zone versions. 
###### JSON request example : {"date":"2019-01-06T17:16:40","timezonenamefrom":"Eastern Standard Time","timezonenameto":"Europe/Minsk"}
