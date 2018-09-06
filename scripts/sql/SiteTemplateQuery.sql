declare @schoolid int
, @schoolname varchar
, @layoutid int;

set @schoolid = 0;
set @schoolname = '';
set @layoutid = 8;

select top 10 s.id as 'School ID'
, s.schoolname as 'School Name'
, st.domainname as 'Production Domain'
, st.stagingdomainname as 'Stage Domain'
, st.devdomainname as 'Dev Domain'
, t.templatename as 'Template Name'
, l.layoutname as 'Template Layout'
, l.indexpagename as 'Template Index'

from school s
join site st on st.schoolid = s.id
join siteconfiguration sc on sc.siteid = st.id
join template t on t.id = sc.templateid
join layout l on l.id = t.layoutid

where s.schoolname like @schoolname or s.id = @schoolid or l.id = @layoutid