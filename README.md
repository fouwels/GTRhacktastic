GTRhacktastic
=============
RCUK hack


#API - scrapped
http://gtrtastic.eu01.aws.af.cm/

/ => http://gtrtastic.eu01.aws.af.cm/api.php
/test/ => http://gtrtastic.eu01.aws.af.cm/api.php/test/

#Findler - Windows RT App
Imports Libs
-Json.net

Sequence:
GET /gtr/api/projects?q=turtles
For each project id
GET /gtr/api/persons/:project-id
Process ALL GETs -> ReportCard template for each user

###From Hack Page:
>Provides a platform for a researcher to rapidly search for other researcher based on their field of interest.

>Queries a couple of the endpoints of the GTR api to get projects relevant to the search, then iterated through, querying for the data of each contributor to said project, and finally collates the data together into a list of key-value pairs for each user, which can then be fed back to the user.

>For each contributor, we generate an object (the "value") containing their first name, last name, and a nested object of all the projects they have contributed to. This is then assigned to their unique id, which serves as the Key.

>From this, we can then extract any data we want regarding their projects, in this case however, just the title.

>Example: http://imgur.com/0BBJy9U,qQQGhDs#0
