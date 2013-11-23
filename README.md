GTRhacktastic
=============
RCUK hack


#API
http://gtrtastic.eu01.aws.af.cm/

/ => http://gtrtastic.eu01.aws.af.cm/api.php
/test/ => http://gtrtastic.eu01.aws.af.cm/api.php/test/

#Findler - Windows RT App
Imporsts Libs
> Json.net

Sequence:
GET /gtr/api/projects?q=turtles
For each project id
GET /gtr/api/persons/:project-id
Process ALL GETs -> ReportCard template for each user

Output final ReportCard?
