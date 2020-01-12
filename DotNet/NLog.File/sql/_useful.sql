--_useful.sql

-- git folder
-- cd C:/Users/Ben/source/repos/AlanNevill/KnightCodesExamples

use pops;

-- test spCheckSum_ins
exec spCheckSum_ins	@SHA			= '1a-3b-5c-7d-9e-0f',
					@Folder			= 'c:\logs\nlog\',
					@TheFileName	= 'c:\logs\nlog\file1.txt',
					@FileExt		= '.txt',
					@FileSize		= 22,
					@FileCreateDt	= '2019-12-22',
					@TimerMs		= 9900034,
					@Notes			= 'Notes 1'

-- test spDupesAction_ins
exec spDupesAction_ins	
					@TheFileName			= 'c:\logs\nlog\file1.txt',
					@Folder					= 'c:\logs\nlog\',
					@SHA					= '1a-3b-5c-7d-9e-0f',
					@FileExt				= '.txt',
					@FileSize				= 0,
					@FileCreateDt			= '2019-12-22',
					@OneDriveRemoved		= 'N',
					@GooglePhotosRemoved	= 'N'

-- test data
insert into CheckSum(SHA,Folder,TheFileName) values	('1a-b5-f9-c7-92-00',	'C:\test',	'testFileName.txt'),
													('2b-3c-4d-5e-9f-11',	'C:\test2',	'testName2.txt')
						
select * from CheckSum where id=4796;
select count(*) from CheckSum;
select Timer=sum(timerMs)/1000 from Checksum;


--find duplicate SHA values
select SHA, count(*) as SHAcount
from CheckSum
group by SHA
having count(*) > 1
--order by 1


-- select the files with duplicate SHA values
select id, SHA, TheFileName, FileCreateDt, FileSize
from CheckSum
where SHA in (
	select SHA
	from CheckSum
	group by SHA
	having count(*) > 1
)
order by 2,1

truncate table CheckSumDups;
-- insert the files with duplicate SHA values into CheckSumDups
insert CheckSumDups(Id, SHA)
select Id, SHA
from CheckSum
where SHA in (
	select SHA
	from CheckSum
	group by SHA
	having count(*) > 1
)

--update CheckSumDups set ToDelete='N';

select count(*) from CheckSumDups;

select * from DupesAction;

--truncate table DupesAction;

--update DupesAction set OneDriveRemoved='Y';

select * from DupesAction where LEN(TheFileName) = 100 and SUBSTRING(TheFileName,100,1) != 'G';

update DupesAction set GooglePhotosRemoved = 'Y' from DupesAction where TheFileName  = 'C:\Users\User\OneDrive\Photos\1968\01\ben01 (1).jpg';

