create database MineSweeper

go

use MineSweeper

go

create table HighScore
(
ID int identity primary key not null,
PlayerName varchar(20) not null,
Score nvarchar(max) not null,
Difficulty nvarchar(6) not null,
)

go

insert into HighScore values ('Testman', '20', 'Hard')

go

CREATE PROCEDURE sp_AddHighScore
	@PlayerName varchar(20),
	@Score nvarchar(max),
	@Difficulty varchar(6),
	@ID int out
AS
BEGIN

	insert into HighScore(PlayerName, Score, Difficulty) values (@PlayerName, @Score, @Difficulty)

	set @ID = SCOPE_IDENTITY()

END

go

declare @ID int
execute sp_AddHighScore 'testwomen','10','Hard', @ID

go

CREATE PROCEDURE sp_ReadHighScore
	@Difficulty varchar(6)
AS
BEGIN

	select top 10 * from HighScore where Difficulty = @Difficulty order by Score

END

go

execute sp_ReadHighScore 'Hard'

go
