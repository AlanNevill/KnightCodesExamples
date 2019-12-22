--_useful.sql

-- git folder
-- cd C:/Users/Ben/source/repos/AlanNevill/KnightCodesExamples

use pops;

-- test spCheckSum_ins
exec spCheckSum_ins	@SHA			= '1a-3b-5c-7d-9e-0f',
					@Folder			= 'c:\logs\nlog\',
					@TheFileName	= 'file1.txt',
					@FileExt		= '.php',
					@FileSize		= 22,
					@FileCreateDt	= '2019-12-22',
					@TimerMs		= 9900034,
					@Notes			= 'Notes 1'

-- test data
insert into CheckSum(SHA,Folder,TheFileName) values	('1a-b5-f9-c7-92-00',	'C:\test',	'testFileName.txt'),
													('2b-3c-4d-5e-9f-11',	'C:\test2',	'testName2.txt')
						
select * from CheckSum;

--find duplicate SHA values
select SHA, count(*) as SHAcount
from CheckSum
group by SHA
having count(*) > 1
--order by 1


-- select the files with duplicate SHA values
select id, SHA, TheFileName, FileCreateDt
from CheckSum
where SHA in (
	select SHA
	from CheckSum
	group by SHA
	having count(*) > 1
)
order by 2,1
