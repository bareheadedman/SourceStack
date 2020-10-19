--使用SQL语句（以后所有作业均是要求使用SQL语句完成，不再额外声明）
--新建一个数据库：17bang，能指定/查看该数据库存放位置
--依次备份/删除/恢复该数据库

 CREATE DATABASE [17BANG];
 --新建一个数据库：17bang，能指定/查看该数据库存放位置

 BACKUP DATABASE [17BANG] TO DISK = 'D:\\17BANG.BAK'
 RESTORE DATABASE [17BANG] FROM DISK = 'D:\\17BANG.BAK'
--依次备份/删除/恢复该数据库







--观察“一起帮”的注册和发布求助功能，试着建立表User：包含UserName（用户名），Password（密码）……
--为User表添加一列：邀请人（InvitedBy），类型为INT
--将InvitedBy类型修改为NVARCHAR(10)
--删除列InvitedBy

CREATE TABLE [User]
(
[UserName] NVARCHAR(20) NOT NULL,
[PassWord] VARCHAR(20)  NOT NULL,
);
--观察“一起帮”的注册和发布求助功能，试着建立表User：包含UserName（用户名），Password（密码）……

ALTER TABLE [User]
ADD [InvitedBy] INT ;
--为User表添加一列：邀请人（InvitedBy），类型为INT

ALTER TABLE [User]
ALTER COLUMN [InvitedBy] NVARCHAR(10);
--将InvitedBy类型修改为NVARCHAR(10)

ALTER TABLE [User]
DROP COLUMN [InvitedBy];
--删除列InvitedBy









--观察“一起帮”的发布求助功能，试着建立表Problem，包含：
--Id
--Title（标题）
--Content（正文）
--NeedRemoteHelp（需要远程求助）
--Reward（悬赏）
--PublishDateTime（发布时间）……
--请为这些列选择合适的数据类型。


CREATE TABLE [Problem]
(
 Id INT NOT NULL ,
 Title NVARCHAR(30) NOT NULL ,
 Content NTEXT NOT NULL ,
 NeedRamoteHelp BIT  ,
 Reward INT NOT NULL ,
 PublishDateTime DATETIME NOT NULL,
);
--观察“一起帮”的发布求助功能，试着建立表Problem，









--在User表中插入以下四行数据：
--UserName    Password
--17bang      1234
--Admin       NULL
--Admin-1
--SuperAdmin  123456

--将Problem表中的Reward全部更新为0
--使用事务，
--删除User表中的全部数据，
--回滚事务，撤销之前的删除行为

INSERT [User] ([UserName],[PassWord]) VALUES (N'17bang','1234')
--UserName    Password

INSERT [User] ([UserName],[PassWord]) VALUES (N'Admin','NULL')
--Admin       NULL

INSERT [User] ([UserName],[PassWord]) VALUES (N'Admin-1','')
--Admin-1

INSERT [User] ([UserName],[PassWord]) VALUES (N'SuperAdmin','123456')
--SuperAdmin  123456

SELECT * FROM [User]

BEGIN TRANSACTION
--使用事务，

TRUNCATE TABLE [User]
--删除User表中的全部数据，
ROLLBACK

--回滚事务，撤销之前的删除行为




--在User表中：
--查找没有录入密码的用户
--删除用户名（UserName）中包含“管理员”或者“17bang”字样的用户

SELECT * FROM [User] WHERE [Password] = '' ;
--查找没有录入密码的用户

DELETE [User]  WHERE [UserName] LIKE (N'%管理员%') OR  [UserName] LIKE (N'%17bang%')
--删除用户名（UserName）中包含“管理员”或者“17bang”字样的用户












--在Problem表中：

--给所有悬赏（Reward）大于10的求助标题加前缀：【推荐】
--给所有悬赏大于20且发布时间（Created）在2019年10月10日之后的求助标题加前缀：【加急】
--删除所有标题以中括号【】开头（无论其中有什么内容）的求助
--查找Title中第5个起，字符不为“数据库”且包含了百分号（%）的求助

INSERT [Problem] (Id,Title,Content,NeedRamoteHelp,Reward,PublishDateTime) VALUES (1,N'随数据库的箭！！坤就888黛拉',N'正文1',0,5,'2025/1/1');
INSERT [Problem] (Id,Title,Content,NeedRamoteHelp,Reward,PublishDateTime) VALUES (2,N'阿数据库法法师SFSEAFAS(%)水电费',N'正文2',1,30,'2010/1/1');
INSERT [Problem] (Id,Title,Content,NeedRamoteHelp,Reward,PublishDateTime) VALUES (3,N'阿法法师SFSEAFA数据库S水电费',N'正文3',0,20,'2016/1/1');
INSERT [Problem] (Id,Title,Content,NeedRamoteHelp,Reward,PublishDateTime) VALUES (4,N'阿法(%)法师SFSEAF数据库AS水电费',N'正文4',0,30,'2022/1/1');
INSERT [Problem] (Id,Title,Content,NeedRamoteHelp,Reward,PublishDateTime) VALUES (5,N'阿法法师SFSEA数据库FA(%)S水电费',N'正文5',0,40,'2017/1/1');
INSERT [Problem] (Id,Title,Content,NeedRamoteHelp,Reward,PublishDateTime) VALUES (6,N'阿法法师SFSEAFAS水电费',N'正文6',0,100,'2020/1/1');
INSERT [Problem] (Id,Title,Content,NeedRamoteHelp,Reward,PublishDateTime) VALUES (7,N'阿法法师SFSEAFAS水电费',N'正文8887',0,200,'2020/1/1');


UPDATE [Problem] SET Title=(N'【推荐】')+Title WHERE Reward > 10;
--给所有悬赏（Reward）大于10的求助标题加前缀：【推荐】

UPDATE [Problem] SET Title=(N'【加急】')+Title WHERE Reward > 20 AND PublishDateTime > ('2019/10/10');
--给所有悬赏大于20且发布时间（Created）在2019年10月10日之后的求助标题加前缀：【加急】

UPdate [Problem] SET Content = (N'')  WHERE Title LIKE (N'%【%】%') ;
--删除所有标题以中括号【】开头（无论其中有什么内容）的求助

SELECT * FROM [Problem]
WHERE  Title  NOT LIKE N'_____%数据库%'
AND Title LIKE N'%#%%' ESCAPE '#';
--查找Title中第5个起，字符不为“数据库”且包含了百分号（%）的求助






--在Keyword表中：

--找出所有被使用次数（Used）大于10小于50的关键字名称（Name）
--如果被使用次数（Used）小于等于0，或者是NULL值，或者大于100的，将其更新为1
--删除所有使用次数为奇数的Keyword

CREATE TABLE [Keyword]
(
[Used] int ,
[Name] NVARCHAR(20),
);

INSERT [Keyword] ( [Used],[Name]) VALUES (5,N'速度');
INSERT [Keyword] ( [Used],[Name]) VALUES (NULL,N'多个');
INSERT [Keyword] ( [Used],[Name]) VALUES (10,N'文化');
INSERT [Keyword] ( [Used],[Name]) VALUES (50,N'垃圾');
INSERT [Keyword] ( [Used],[Name]) VALUES (100,N'哪有');
INSERT [Keyword] ( [Used],[Name]) VALUES (0,N'空调');
INSERT [Keyword] ( [Used],[Name]) VALUES (1,N'不看');
INSERT [Keyword] ( [Used],[Name]) VALUES (500,N'便宜');


SELECT * FROM [Keyword] WHERE Used BETWEEN 10 AND 50 ;
--找出所有被使用次数（Used）大于10小于50的关键字名称（Name）

UPDATE [Keyword] SET  Used = '1' WHERE  Used <= 0  or Used is NULL or Used > 100 ;
--如果被使用次数（Used）小于等于0，或者是NULL值，或者大于100的，将其更新为1

DELETE [Keyword]  WHERE Used%2=1 ;
--删除所有使用次数为奇数的Keyword








--在User表上的基础上：

--添加Id列，让Id成为主键
--添加约束，让UserName不能重复



ALTER TABLE [User]
ADD  Id INT NOT NULL  CONSTRAINT PK_User_Id  PRIMARY KEY  ;
--添加Id列，让Id成为主键

ALTER TABLE [User]
ADD CONSTRAINT UQ_User_UserName UNIQUE (UserName);
--添加约束，让UserName不能重复







--在Problem表的基础上：

--为NeedRemoteHelp添加NOT NULL约束，再删除NeedRemoteHelp上NOT NULL的约束
--添加自定义约束，让Reward不能小于10



ALTER TABLE [Problem]
ALTER COLUMN [NeedRamoteHelp] BIT NOT NULL ;
--为NeedRemoteHelp添加NOT NULL约束

ALTER TABLE [Problem]
ALTER COLUMN [NeedRamoteHelp] BIT NULL ;
--再删除NeedRemoteHelp上NOT NULL的约束

ALTER TABLE [Problem]
ADD CONSTRAINT CK_Problem_Reward check (Reward>10) ;
--添加自定义约束，让Reward不能小于10







--观察一起帮的“关键字”功能，新建Keyword表，要求带一个自增的主键Id，起始值为10，步长为5；并存入若干条数据
--给User表中添加一个GUID的Id列，并存入若干条数据
--Problem表已有Id列，如何给该列加上IDENTITY属性？


CREATE TABLE [Keyword]
(
  Id INT IDENTITY(10,5) NOT NULL ,
  [Name] NVARCHAR(20) ,
);

INSERT Keyword VALUES(N'飞飞飞');
--观察一起帮的“关键字”功能，新建Keyword表，要求带一个自增的主键Id，起始值为10，步长为5；并存入若干条数据

ALTER TABLE [User]
ADD  Id VARCHAR (50)  ; 

INSERT [User]  VALUES(N'中飞','1234',NEWID())
--给User表中添加一个GUID的Id列，并存入若干条数据

SET IDENTITY_INSERT  ProblemOne ON ;
CREATE TABLE [ProblemOne]
(
 Id INT IDENTITY NOT NULL,
 Title NVARCHAR (30),
 Content Ntext ,
 NeedRamoteHelp  BIT ,
 Reward  INT ,
 PublishDateTime DATETIME ,
);
SET IDENTITY_INSERT ProblemOne OFF ;

INSERT ProblemOne( Id,Title,Content,NeedRamoteHelp,Reward,PublishDateTime)
SELECT Id,Title,Content,NeedRamoteHelp,Reward,PublishDateTime  FROM Problem ;



SET IDENTITY_INSERT  Problem ON ;

INSERT Problem( Id,Title,Content,NeedRamoteHelp,Reward,PublishDateTime)
SELECT Id,Title,Content,NeedRamoteHelp,Reward,PublishDateTime  FROM ProblemOne ;

SET IDENTITY_INSERT Problem OFF ;

DELETE [Problem]

SELECT * FROM [Problem]

ALTER TABLE [Problem]
DROP COLUMN Id ;

DROP TABLE [ProblemOne] ;

ALTER TABLE [Problem]
ADD  [Id] INT IDENTITY  ;
--Problem表已有Id列，如何给该列加上IDENTITY属性？












--在Problem中插入不同作者（Author）不同悬赏（Reward）的若干条数据，以便能完成以下操作： 
--查找出Author为“飞哥”的、Reward最多的3条求助
--所有求助，先按作者“分组”，然后在“分组”中按悬赏从大到小排序
--查找并统计出每个作者的：求助数量、悬赏总金额和平均值
--找出平均悬赏值少于10的作者并按平均值从小到大排序
--以Problem中的数据为基础，使用SELECT INTO，新建一个Author和Reward都没有NULL值的新表：NewProblem （把原Problem里Author或Reward为NULL值的数据删掉）
--使用INSERT SELECT, 将Problem中Reward为NULL的行再次插入到NewProblem中


ALTER TABLE [Problem]
ADD  Author NVARCHAR(30) ;

UPDATE Problem SET Author = (N'飞哥')
UPDATE Problem SET Author = (N'小飞') WHERE Id=7 OR Id = 9 ;



INSERT [Problem] (Author,Title,Content) VALUES (N'飞飞飞', N'随便标题',N'正文854') ;



SELECT TOP 3 * FROM [Problem]
WHERE Author = (N'飞哥')
ORDER BY  Reward DESC  
--查找出Author为“飞哥”的、Reward最多的3条求助





SELECT Author,Reward FROM [Problem]
ORDER BY Author , Reward DESC ;
--所有求助，先按作者“分组”，然后在“分组”中按悬赏从大到小排序





SELECT Author, COUNT(*) AS [求助数量] ,SUM (Reward) AS [悬赏总金额] , AVG (Reward) AS [平均值]  FROM [Problem]
GROUP BY Author
--查找并统计出每个作者的：求助数量、悬赏总金额和平均值

	

ALTER TABLE [Problem]
DROP CONSTRAINT CK_Problem_Reward ;

DELETE Problem WHERE Reward >10 ;


SELECT   Author, COUNT(*) AS [求助数量] , AVG (Reward) AS [平均值] FROM Problem
GROUP BY Author
HAVING AVG (Reward) <10 
ORDER BY AVG (Reward)  

--找出平均悬赏值少于10的作者并按平均值从小到大排序






SELECT *
INTO NewProblem
FROM Problem  WHERE Author IS NOT NULL AND Reward IS NOT NULL ; 
--以Problem中的数据为基础，使用SELECT INTO，新建一个Author和Reward都没有NULL值的新表：NewProblem （把原Problem里Author或Reward为NULL值的数据删掉）





INSERT NewProblem
SELECT [Title],[Content],[NeedRamoteHelp],[Reward],[PublishDateTime],[Author]  FROM Problem 
WHERE Author IS NULL OR Reward IS NULL ;
--使用INSERT SELECT, 将Problem中Reward为NULL的行再次插入到NewProblem中


SELECT * FROM NewProblem
SELECT * FROM Problem




SELECT * FROM Student

INSERT Student ([Id],[Name],[Age],[Score],[Subject]) VALUES (9,N'百万',25,91,N'HTML');

ALTER TABLE Student
ALTER COLUMN [Subject] NVARCHAR(50) ;


UPDATE Student SET [Subject] = N'SQL'

SELECT * FROM Student ;
SELECT * FROM Student OS
WHERE Score =
(
 SELECT AVG(Score) FROM Student NS
  WHERE OS.[Subject] = NS.[Subject]
 
)
















--观察并模拟17bang项目中的：

--用户资料，新建用户资料（Profile）表，和User形成1:1关联（有无约束？）。用SQL语句演示：
--新建一个填写了用户资料的注册用户
--通过Id查找获得某注册用户及其用户资料
--删除某个Id的注册用户
--帮帮点说明：新建Credit表，可以记录用户的每一次积分获得过程，即：某个用户，在某个时间，因为某某原因，获得若干积分
--发布求助，在Problem和User之间建立1:n关联（含约束）。用SQL语句演示：
--某用户发布一篇求助，
--将该求助的作者改成另外一个用户
--删除该用户
--求助列表：新建Keyword表，和Problem形成n:n关联（含约束）。用SQL语句演示：
--查询获得：某求助使用了多少关键字，某关键字被多少求助使用
--发布了一个使用了若干个关键字的求助
--该求助不再使用某个关键字
--删除该求助
--删除某关键字







SELECT * FROM [User];
DROP TABLE [User]
CREATE TABLE [User]
(
  Id INT  IDENTITY CONSTRAINT PK_User_Id PRIMARY KEY NOT NULL ,
  UserName varchar (20) CONSTRAINT UQ_User_UserName UNIQUE NOT NULL ,
  [PassWord] varchar (20) NOT NULL,
  [ProfileId] INT CONSTRAINT UQ_User_ProfileId UNIQUE CONSTRAINT FK_UserProfile_Id  FOREIGN KEY (ProfileId) REFERENCES [Profile](Id),
);

SELECT * FROM [Profile]
DROP TABLE [profile]
CREATE TABLE [Profile]
(
  Id INT IDENTITY CONSTRAINT pk_Profile_Id PRIMARY KEY NOT NULL,
  Photo VARCHAR (50) ,
  Gender BIT NOT NULL,
  Birthday DATETIME NOT NULL,
  KeyWord NVARCHAR(50),
  SelfDescription NVARCHAR(300),
);

INSERT [User](UserName,[PassWord])  VALUES ('wei','1234')
INSERT [Profile](Photo,Gender,Birthday,KeyWord,SelfDescription) VALUES ('',1,'1999/7/27','C#',N'喜欢唱跳RAP不喜欢篮球')
UPDATE [User] SET ProfileId = 1004 WHERE Id = 1006
--用户资料，新建用户资料（Profile）表，和User形成1:1关联（有无约束？）。用SQL语句演示：


SELECT * FROM [User] 
JOIN [Profile]
ON [User].ProfileId = [Profile].Id 
Where [User].Id = 1003 ;
--通过Id查找获得某注册用户及其用户资料

DELETE  [Profile]
Where Id = 2 ;

DELETE  Problem

ALTER TABLE Problem
ADD  CONSTRAINT PK_Problem_Id PRIMARY KEY(Id) ;

INSERT [Problem](Title,Content,Reward,PublishDateTime,Author) VALUES (N'PHP的入门书籍',N'从入门到入土',20,'2018/7/7',N'9527')


DELETE [User] 
FROM [User] U JOIN [Profile] p 
on U.ProfileId = P.Id
WHERE U.ID=2 ;
--删除某个Id的注册用户





--帮帮点说明：新建Credit表，可以记录用户的每一次积分获得过程，即：某个用户，在某个时间，因为某某原因，获得若干积分
CREATE TABLE [Credit]
(
 Id INT IDENTITY CONSTRAINT PK_Credit_Id PRIMARY KEY NOT NULL ,
 [DateTime] DATETIME NOT NULL ,
 [Cause] NVARCHAR(50) NOT NULL,
 PlusOrMinus NVARCHAR(50) NOT NULL ,
 Surplus INT NULL ,
 Remarks NVARCHAR(100) ,
);

SELECT * FROM [Credit]



ALTER TABLE [Credit]
ADD UserId INT CONSTRAINT FK_Credit_UserId  FOREIGN KEY(UserId) REFERENCES[User](Id);

INSERT Credit ([DateTime],Cause,PlusOrMinus,Surplus,Remarks,UserId) VALUES('2019/8/7',N'注册','10',10,N'注册赠送',1006)
INSERT Credit ([DateTime],Cause,PlusOrMinus,Surplus,Remarks,UserId) VALUES('2019/9/1',N'发布','5',10,N'发布文章',1006)
INSERT Credit ([DateTime],Cause,PlusOrMinus,Remarks,UserId) VALUES('2018/7/9',N'发布','5',N'发布文章',1003)
--某用户发布一篇求助，





--将该求助的作者改成另外一个用户
UPDATE [Credit] SET UserId = 1004
WHERE ID=6 ;




--删除该用户
DELETE [User]  WHERE [UserName] = 'feifeifei999'







--求助列表：新建Keyword表，和Problem形成n:n关联（含约束）。用SQL语句演示：
CREATE TABLE [keyword]
(
 Id INT IDENTITY CONSTRAINT PK_Keyword_Id PRIMARY key ,
 [Word] NVARCHAR(20) 
)


INSERT Keyword(Word) VALUES(N'java')


CREATE TABLE [Keyword2Problem]
(
 KeywordId INT CONSTRAINT FK_Keyword2Problem_KeywordId FOREIGN KEY(KeywordId) REFERENCES[Keyword](Id) ,
 ProblemId INT CONSTRAINT FK_Keyword2Problem_ProblemId FOREIGN KEY(ProblemId) REFERENCES[Problem](Id),
 );

INSERT Keyword2Problem(KeywordId,ProblemId) VALUES(2,3012)

SELECT * FROM Keyword2Problem


--查询获得：某求助使用了多少关键字，某关键字被多少求助使用
SELECT * FROM keyword2Problem K2P
JOIN Keyword K
ON K2P.KeywordId = K.Id
JOIN problem P
ON K2P.ProblemId = P.Id
WHERE Author = '9527'

SELECT * FROM Keyword2Problem K2P
JOIN keyword K
ON K2P.KeywordId = K.Id
where [Word] = N'PHP'



--该求助不再使用某个关键字
DELETE Keyword2Problem
WHERE KeywordId = 3 AND ProblemId = 3012 ;




--删除该求助
DELETE Keyword2Problem
WHERE ProblemId = 3013

DELETE Problem
WHERE Id = 3013



--删除某关键字
DELETE Keyword2Problem
WHERE KeywordId = 4

DELETE Keyword
WHERE Id = 4

GO
SELECT * FROM [Keyword2Problem]
SELECT * FROM [User]
SELECT * FROM [keyword]
SELECT * FROM [Problem]
SELECT * FROM [Profile]
SELECT * FROM [Credit]







--以Problem中的数据为基础，使用SELECT INTO，新建一个Author和Reward都没有NULL值的新表：NewProblem （把原Problem里Author或Reward为NULL值的数据删掉）
--使用INSERT SELECT, 将Problem中Reward为NULL的行再次插入到NewProblem中
--使用OVER，统计出求助里每个Author悬赏值的平均值、最大值和最小值，然后用新表ProblemStatus存放上述数据
--使用CASE...WHEN，颠倒Problem中的NeedRemote（以前是1的，现在变成0；以前是0的，现在变成1）
--使用CASE...WHEN，用一条SQL语句，完成SQL入门-7：函数中第4题第3小题

INSERT Problem(Title,Content,NeedRamoteHelp,PublishDateTime) VALUES(N'标题党',N'正文没有内容',0,'2015/9/7')


--以Problem中的数据为基础，使用SELECT INTO，新建一个Author和Reward都没有NULL值的新表：NewProblem （把原Problem里Author或Reward为NULL值的数据删掉
SELECT *
INTO NewProblem
FROM Problem
WHERE Author IS NOT NULL AND Reward IS NOT NULL ;


--使用INSERT SELECT, 将Problem中Reward为NULL的行再次插入到NewProblem中
INSERT NewProblem
SELECT Title,Content,NeedRamoteHelp,Reward,PublishDateTime,Author FROM Problem
WHERE Author IS NULL OR Reward IS NULL ;


--使用OVER，统计出求助里每个Author悬赏值的平均值、最大值和最小值，然后用新表ProblemStatus存放上述数据
SELECT AuthorId,
AVG(Reward) OVER(PARTITION BY AuthorId) AS 平均值,
MAX(Reward) OVER(PARTITION BY AuthorId) AS 最大值,
MIN(Reward) OVER(PARTITION BY AuthorId) AS 最小值
INTO ProblemStatus
FROM Problem


--使用CASE...WHEN，颠倒Problem中的NeedRemote（以前是1的，现在变成0；以前是0的，现在变成1）
UPDATE Problem SET NeedRamoteHelp = (
CASE NeedRamoteHelp 
  WHEN 1 THEN 0 ELSE 0 
END
)







--找到从未成为邀请人的用户（当心NULL值）
--查出这些文章：其作者总共只发布过这一篇文章
--为求助添加一个发布时间（PublishTime），查找每个作者最近发布的一篇求助
--查出每个作者悬赏最多的3篇求助
--删除悬赏相同的求助（只要相同的全部删除一个不留）
--删除每个作者悬赏最低的求助



--********************************************************************************************************找到从未成为邀请人的用户（当心NULL值）

SELECT * FROM [User]
WHERE UserName NOT IN
(SELECT InviterName FROM [User] 
WHERE InviterName IS NOT  NULL)




--*****************************************************************************************************查出这些文章：其作者总共只发布过这一篇文章
SELECT * FROM [User] U
JOIN [Problem] p
ON  U.Id = P.AuthorId
WHERE U.Id IN
(
SELECT AuthorId FROM Problem P
GROUP BY P.AuthorId
HAVING COUNT(*) = 1
)





--***************************************************************************为求助添加一个发布时间（PublishTime），查找每个作者最近发布的一篇求助
SELECT * FROM [User] U
JOIN [Problem] OP
ON  U.Id = OP.AuthorId
WHERE OP.PublishDateTime =(
  SELECT MAX(PublishDateTime) FROM Problem [IP]
  WHERE  Op.AuthorId = [IP].AuthorId
  )





--*********************************************************************************************************************查出每个作者悬赏最多的3篇求助
SELECT * FROM 
(
SELECT ROW_NUMBER()      
OVER(PARTITION BY AuthorId    
     ORDER BY Reward DESC)    
AS GID,
*    
FROM Problem 
)P
JOIN [User] U
ON  U.Id = P.AuthorId
WHERE GID <=3



SELECT * FROM [Problem] OP
WHERE OP.Id IN(
  SELECT TOP 3 Id FROM Problem [IP]
  WHERE  Op.AuthorId = [IP].AuthorId
  ORDER BY Reward DESC
  )
  ORDER BY AuthorId ,Reward DESC



--删除悬赏相同的求助（只要相同的全部删除一个不留）

DELETE p1
--SELECT P1.id,P2.Id,P1.Reward,P1.Title
FROM Problem P1
JOIN Problem P2
ON P1.Reward = P2.Reward
WHERE P1.Id > p2.Id

--************************************************************************************************方法2  删除悬赏相同的求助（只要相同的全部删除一个不留）
DELETE Problem
WHERE Id
NOT IN
(SELECT MIN(Id) FROM Problem GROUP BY Reward)



--**********************************************************************************************************************删除每个作者悬赏最低的求助
DELETE OP
FROM Problem OP WHERE Reward = 
(
   SELECT MIN(Reward) FROM Problem [IP]
   WHERE [IP].AuthorId = OP.AuthorId
)





--分别使用派生表和CTE，查询求助表（表中只有一列整体的发布时间，没有年月的列），以获得：

--一起帮每月各发布了求助多少篇
--每月发布的求助中，悬赏最多的3篇
--每个作者，每月发布的，悬赏最多的3篇
--分别按发布时间和悬赏数量进行分页查询的结果





--一起帮每月各发布了求助多少篇
SELECT P1.PublishYear,P1.PublishMonth, COUNT(*) AS [Count] FROM
(
  SELECT YEAR(PublishDateTime) AS PublishYear,MONTH(PublishDateTime) AS PublishMonth FROM Problem
)P1
GROUP BY P1.PublishYear,P1.PublishMonth

--/////////////////////////////////////////////////////////////////////////////////////////////////////////////

  SELECT 
  PublishDateTime,
  YEAR(PublishDateTime) AS PublishYear,
  MONTH(PublishDateTime) AS PublishMonth, 
  COUNT(*) AS [Count] 
  FROM Problem
  GROUP BY PublishDateTime

--//////////////////////////////////////////////////////////////////////////////////////////////////////////////
go

WITH P1 AS
(  SELECT YEAR(PublishDateTime) AS PublishYear,
   MONTH(PublishDateTime) AS PublishMonth
   FROM Problem
)
SELECT *, COUNT(*) AS [Count] FROM P1
GROUP BY P1.PublishYear,P1.PublishMonth



--每月发布的求助中，悬赏最多的3篇
SELECT * FROM 
(
  SELECT 
  ROW_NUMBER() OVER(PARTITION BY PublishDateTime ORDER BY Reward DESC)AS GID,
  YEAR(PublishDateTime) AS PublishYear,
  MONTH(PublishDateTime) AS PublishMonth,* FROM Problem
)P1
WHERE GID <=3

--////////////////////////////////////////////////////////////////////////////////////////////////////////////////

WITH P1 AS
( SELECT
  ROW_NUMBER() OVER(PARTITION BY PublishDateTime ORDER BY Reward DESC)AS GID,
  YEAR(PublishDateTime) AS PublishYear,
  MONTH(PublishDateTime) AS PublishMonth,* FROM Problem
)
SELECT * FROM P1
WHERE GID <= 3





--每个作者，每月发布的，悬赏最多的3篇

SELECT * FROM 
(
  SELECT 
  ROW_NUMBER() OVER(PARTITION BY AuthorId,PublishDateTime ORDER BY Reward DESC)AS GID,
  YEAR(PublishDateTime) AS PublishYear,
  MONTH(PublishDateTime) AS PublishMonth,* FROM Problem
)P1
WHERE GID <=3

--////////////////////////////////////////////////////////////////////////////////////////////////////////////////

WITH P1 AS
( SELECT
  ROW_NUMBER() OVER(PARTITION BY AuthorId,PublishDateTime ORDER BY Reward DESC)AS GID,
  YEAR(PublishDateTime) AS PublishYear,
  MONTH(PublishDateTime) AS PublishMonth,* FROM Problem
)
SELECT * FROM P1
WHERE GID <= 3




--***********************************************************************************************************分别按发布时间和悬赏数量进行分页查询的结果

SELECT TOP 2 * FROM Problem 
WHERE ID NOT IN
(SELECT TOP 2 Id FROM Problem ORDER BY PublishDateTime)
ORDER BY PublishDateTime


SELECT TOP 2 * FROM Problem
WHERE Id NOT IN 
(SELECT TOP 2 Id FROM Problem ORDER BY Reward)
ORDER BY Reward



--///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

SELECT * FROM 
(
  SELECT ROW_NUMBER() OVER(ORDER BY PublishDateTime) AS Pid, * FROM Problem
)P
WHERE P.Pid BETWEEN 3 AND 4 ;


SELECT * FROM
(
 SELECT ROW_NUMBER() OVER (ORDER BY Reward) AS Pid, * FROM Problem
)P
WHERE P.Pid BETWEEN 3 AND 4 ;



--////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


SELECT * FROM Problem 
ORDER BY PublishDateTime
OFFSET 2 ROWS
FETCH NEXT 2 ROWS ONLY


SELECT * FROM Problem
ORDER BY Reward 
OFFSET 2 ROWS
FETCH NEXT 2 ROWS ONLY






--联表查出求助的标题和作者用户名
--查找并删除从未发布过求助的用户
--用一句SELECT显示出用户和他的邀请人用户名
--17bang的关键字有“一级”“二级”和其他“普通（三）级”的区别：
--请在表Keyword中添加一个字段，记录这种关系
--然后用一个SELECT语句查出所有普通关键字的上一级、以及上上一级的关键字名称，比如：

--17bang中除了求助（Problem），还有意见建议（Suggest）和文章（Article），他们都包含Title、Content、PublishTime和Auhthor四个字段，但是：
--建议和文章没有悬赏（Reward）
--建议多一个类型：Kind NVARCHAR(20)）
--文章多一个分类：Category INT）
--请按上述描述建表。然后，用一个SQL语句显示某用户发表的求助、建议和文章的Title、Content，并按PublishTime降序排列





--联表查出求助的标题和作者用户名

SELECT * FROM [User] U
JOIN Problem P
ON  U.Id = P.AuthorId



--查找并删除从未发布过求助的用户

DELETE [User] FROM [User] U
LEFT JOIN Problem P
ON U.Id = p.AuthorId
WHERE P.AuthorId IS NULL;


--用一句SELECT显示出用户和他的邀请人用户名

SELECT U1.Id,U1.UserName,U2.UserName AS'邀请人' FROM [User] U1
LEFT JOIN [User] U2
ON U1.InviterName = U2.UserName



--请在表Keyword中添加一个字段，记录这种关系

ALTER TABLE Keyword
ADD Parent INT ;	



--然后用一个SELECT语句查出所有普通关键字的上一级、以及上上一级的关键字名称,

SELECT K1.Word AS '关键字',K2.Word AS '下一级',k3.Word AS '下下一级' FROM  keyword K1
LEFT JOIN keyword K2
ON K1.Id = k2.Parent
LEFT JOIN Keyword K3
ON K2.Id = k3.Parent





--17bang中除了求助（Problem），还有意见建议（Suggest）和文章（Article），他们都包含Title、Content、PublishTime和Auhthor四个字段，但是：
--建议和文章没有悬赏（Reward）
--建议多一个类型：Kind NVARCHAR(20)）
--文章多一个分类：Category INT）
--请按上述描述建表。然后，用一个SQL语句显示某用户发表的求助、建议和文章的Title、Content，并按PublishTime降序排列

CREATE TABLE [Suggest]
(
  Id INT IDENTITY CONSTRAINT PK_Suggest_Id PRIMARY KEY ,
  Title NVARCHAR(50) ,
  Content NTEXT ,
  AuthorId INT CONSTRAINT FK_Suggest_AuthorId FOREIGN KEY REFERENCES [USER](Id),
  DiscussId INT ,
  Up INT,
  Down INT,
  PublishDateTime DATETIME,
  Kind NVARCHAR(20) ,
);


CREATE TABLE [Article]
(
  Id INT IDENTITY CONSTRAINT PK_Article_Id PRIMARY KEY ,
  Title NVARCHAR(50) ,
  Content NTEXT ,
  AuthorId INT CONSTRAINT FK_Article_AuthorId  FOREIGN KEY REFERENCES [User](Id) ,
  PublishDateTime DATETIME ,
  Up INT ,
  Down INT ,
  Category INT ,
);

CREATE TABLE [Discuss]
(
  Id INT IDENTITY CONSTRAINT PK_Discuss_Id PRIMARY KEY ,
  Conent NVARCHAR(100) ,
  AuthorId INT CONSTRAINT FK_Discuss_AuthorId FOREIGN KEY REFERENCES [USER](Id),
  SuggestId INT CONSTRAINT FK_Discuss_SuggestId FOREIGN KEY REFERENCES Suggest(Id),
  PublishDateTime DATETIME,
);
	


SELECT U1.UserName,U1.[PassWord],A1.AuthorId,A1.Title,A1.Content,2,A1.PublishDateTime,A1.Category FROM [User] U1 JOIN Article A1 ON U1.Id = A1.AuthorId WHERE A1.AuthorId = 1005
UNION
SELECT U2.UserName,U2.[PassWord],P2.AuthorId,P2.Title,P2.Content,P2.Reward,P2.PublishDateTime,NULL FROM [User] U2 JOIN Problem P2 ON U2.Id = P2.AuthorId WHERE P2.AuthorId = 1005
UNION
SELECT U3.UserName,U3.[PassWord],S3.AuthorId,S3.Title,S3.Content,0,S3.PublishDateTime,S3.Kind FROM [User] U3 JOIN Suggest S3 ON U3.Id = S3.AuthorId WHERE S3.AuthorId = 1005
ORDER BY PublishDateTime DESC



SELECT * FROM Discuss





--创建求助的应答表 Response(Id, Content, AuthorId, ProblemId, CreateTime)
--然后生成一个视图 VResponse(ResponseId, Content, ResponseAuthorId，ReponseAuthorName, ProblemId, ProblemAuthorName, ProblemTitle, CreateTime)，要求该视图：
--能展示应答作者的用户名、应答对应求助的标题和作者用户名 （JOIN）
--只显示应答时间在2020年5月27日之后的数据 （JOIN）
--已被加密
--保证其使用的基表结构无法更改
--演示：在VResponse中插入一条数据（注意业务逻辑正确性），却不能在视图中显示
--修改VResponse，让其能避免上述情形
--创建视图VProblemKeyword(ProblemId, ProblemTitle, ProblemReward, KeywordAmount)，要求该视图：
--能反映求助的标题、使用关键字数量和悬赏
--在ProblemId上有一个唯一聚集索引
--在ProblemReward上有一个非聚集索引
--在基表中插入/删除数据，观察VProblemKeyword是否相应的发生变化



--用户发布一篇悬赏币若干的求助（TProblem），他（TReigister）的帮帮币（BMoney）也会相应减少，但他的帮帮币总额不能少于0分：
--请综合使用TRY...CATCH和事务完成上述需求。
 


SELECT * FROM [User]

CREATE TABLE [BMoney]
(
  Id INT IDENTITY ,
  UserId INT CONSTRAINT FK_BMoney_UserId FOREIGN KEY REFERENCES [User](Id),
  [Money] INT CONSTRAINT CK_BMoney_Money CHECK ([Money]> 0),
);

SELECT * FROM BMoney

INSERT BMoney(UserId,[Money])  VALUES(1005,30) 

SELECT * FROM Problem
BEGIN TRAN
  BEGIN TRY
    INSERT Problem(Title,Content,Reward,AuthorId) VALUES (N'标题标题8412',N'正文123',666,1005);
	UPDATE BMoney SET[Money] -= 20 WHERE UserId = 1005;
	COMMIT TRAN
  END TRY
  BEGIN CATCH
   ROLLBACK;
   THROW;
  END CATCH





--利用循环，打印如下所示的等腰三角形：
--      1

--    333

--  55555

--7777777

DECLARE @i INT
SET @i = 1
WHILE @i<5
BEGIN
     PRINT  REPLICATE(' ',4-@i)+ REPLICATE(2*@i-1,2*@i-1)
     SET @i += 1
END






--定义一个函数GetBigger(INT a, INT b)，可以取a和b之间的更大的一个值
--创建一个单行表值函数GetLatestPublish(INT n)，返回最近发布的n篇求助
--创建一个多行表值函数GetByReward(INT n, BIT asc)，如果asc为1，返回悬赏最少的n位同学；否则，返回悬赏最多的n位同学。
--在表TProblem中：
--找出所有周末发布的求助（添加CreateTime列，如果还没有的话）
--找出每个作者所有求助悬赏的平均值，精确到小数点后两位
--有一些标题以test、[test]后者Test-开头的求助，找到他们并把这些前缀都换成大写



--定义一个函数GetBigger(INT a, INT b)，可以取a和b之间的更大的一个值

GO

CREATE FUNCTION GetBigger(@A INT, @B INT)
RETURNS @t TABLE (Bigger INT) 
AS
BEGIN
   IF @A>@B
      BEGIN
	     INSERT @t VALUES(@A) 
      END
   ELSE
      BEGIN
         INSERT @t VALUES(@B)
      END
    RETURN 
END

GO

SELECT * FROM GetBigger(2,7)



--创建一个单行表值函数GetLatestPublish(INT n)，返回最近发布的n篇求助

GO

CREATE FUNCTION GetLatestPublish(@A INT)
RETURNS TABLE
RETURN  SELECT TOP(@A)* FROM Problem 
        ORDER BY PublishDateTime DESC

GO

SELECT * FROM GetLatestPublish(4)


--创建一个多行表值函数GetByReward(INT n, BIT asc)，如果asc为1，返回悬赏最少的n位同学；否则，返回悬赏最多的n位同学。

GO

CREATE FUNCTION GetByReward(@N INT,@ASC BIT)
RETURNS @T TABLE (Author NVARCHAR(50))	
AS
  BEGIN
      IF(@ASC = 1)
         BEGIN
           INSERT INTO @T 
           SELECT TOP(@N)AuthorId FROM Problem ORDER BY Reward DESC
         END
       ELSE
         BEGIN
           INSERT INTO @T
           SELECT TOP(@N)AuthorId FROM Problem ORDER BY Reward
         END
       RETURN
  END

GO

SELECT * FROM GetByReward(4,0)

--在表TProblem中：
--找出所有周末发布的求助（添加CreateTime列，如果还没有的话）



   set language N'Simplified Chinese'

   set language N'English'

SELECT @@DATEFIRST

SELECT * FROM 
(
   SELECT *,DATENAME(WEEKDAY,PublishDateTime) AS 'Week' FROM Problem  
)p

WHERE P.[Week] = 'Saturday' OR p.[Week] = 'Sunday'

--找出每个作者所有求助悬赏的平均值，精确到小数点后两位

SELECT AuthorId,ROUND(AVG(reward),2) FROM Problem  GROUP BY AuthorId


--有一些标题以test、[test]后者Test-开头的求助，找到他们并把这些前缀都换成大写

SELECT * FROM Problem

UPDATE Problem SET Title=
(
     CASE 
         WHEN SUBSTRING(Title,1,4) = N'test' 
             THEN N'TEST'+ SUBSTRING(Title,5,LEN(Title)-4)
         WHEN SUBSTRING(Title,1,6) = N'[test]'
             THEN N'[TEST]' + SUBSTRING(Title,7,LEN(Title)-6)
         WHEN SUBSTRING(Title,1,4) = N'Test'
             THEN N'TEST'+SUBSTRING(Title,5,LEN(Title)-4)
    END
)
WHERE Title LIKE (N'test%') OR Title LIKE(N'_test]%') OR Title LIKE (N'Test-%')

















--编写存储过程“一起帮用户注册”，包含以下逻辑：

--检查用户名是否重复。如果重复，返回错误代码：1

--检查用户名密码是否符合“长度不小于4位”的要求。如果不符合，返回错误代码：2

--如果有邀请人：

--检查邀请人是否存在，如果不存在，返回错误代码：10
--检查邀请码是否正确，如果邀请码不正确，返回错误代码：11
--将用户名、密码和邀请人存入数据库（TRegister）
--给邀请人增加10个帮帮点积分
--通知邀请人（TMessage中生成一条数据）某人使用了他作为邀请人。



DECLARE @r INT 
EXECUTE @r = UserRegister asdKK,999999,1005,666
PRINT @r


SELECT UserName FROM [User] WHERE  UserName = N'asdKK'

SELECT * FROM [User]

GO

ALTER PROCEDURE UserRegister
@UserName NVARCHAR(20) ,
@PassWord NVARCHAR(20) ,
@Inviter INT ,
@InviterCode INT 
AS
IF(EXISTS (SELECT UserName FROM [User] WHERE UserName != @UserName ))
BEGIN
     IF (LEN(@Password)>4 AND LEN(@UserName)>4)
     BEGIN
            IF (EXISTS (SELECT Id FROM [User] WHERE Id = @Inviter))
            BEGIN
                   IF (EXISTS (SELECT Id , InviterCode FROM [User] WHERE Id = @Inviter AND  InviterCode = @InviterCode))
                   BEGIN
                          BEGIN TRAN
                                BEGIN TRY
                                      INSERT [User](UserName,[PassWord],Inviter) VALUES(@UserName,@PassWord,@Inviter)
                                      INSERT [TMessage](Content,ReceiveId) VALUES (@UserName+ N'使用了他作为邀请人',@Inviter)
                                      COMMIT
                                END TRY
                                BEGIN CATCH
                                      THROW;
                                      ROLLBACK;
                                END CATCH
                     END
                     ELSE
                     BEGIN
                     RETURN 11
                     END
              END
              ELSE
              BEGIN
              RETURN 10
              END
       END
       ELSE
       BEGIN
       RETURN 2
       END 
END
ELSE
BEGIN
RETURN 1
END

GO

SELECT * FROM [User]
































--通知邀请人（TMessage中生成一条数据）某人使用了他作为邀请人。
CREATE TABLE [TMessage]
(
   Id INT IDENTITY ,
   Content NVARCHAR (MAX) ,
   ReceiveId INT CONSTRAINT FK_TMessage_ReceiveId FOREIGN KEY REFERENCES [User](Id) ,
)





--********!!!!!!!!!!!!!!!!!去重!!!!!!!!!!!!!!!!!!!!!***************
--DELETE K1
SELECT k1.Id,k2.Id,k1.Word,k2.Word 
FROM Keyword K1
JOIN Keyword K2
ON K1.Word = k2.Word
WHERE K1.Id > K2.Id





GO

CREATE FUNCTION DateTimePagin(@Page INT,@Count INT)
RETURNS TABLE                               -- 直接使用TABLE关键字
RETURN 
SELECT * FROM 
(
  SELECT ROW_NUMBER() OVER(ORDER BY PublishDateTime) AS Pid, * FROM Problem
)P
WHERE P.Pid BETWEEN ((@Page*@Count)+1) AND ((@Page*@Count)+@Count) ;

GO


SELECT * FROM DateTimePagin(2,3)


DROP FUNCTION DateTimePagin

GO








SELECT TOP 2 * FROM Problem 
WHERE ID NOT IN
(SELECT TOP 2 Id FROM Problem ORDER BY PublishDateTime)
ORDER BY PublishDateTime


SELECT TOP 2 * FROM Problem
WHERE Id NOT IN 
(SELECT TOP 2 Id FROM Problem ORDER BY Reward)
ORDER BY Reward


DECLARE @sql NVARCHAR(200) = N'SELECT TOP 2 Id FROM dbo.Problem';
EXEC(@sql)

