USE [master]
GO
/****** Object:  Database [Buscaminas]    Script Date: 22/11/2022 13:13:14 ******/
CREATE DATABASE [Buscaminas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Buscaminas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Buscaminas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Buscaminas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Buscaminas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Buscaminas] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Buscaminas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Buscaminas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Buscaminas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Buscaminas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Buscaminas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Buscaminas] SET ARITHABORT OFF 
GO
ALTER DATABASE [Buscaminas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Buscaminas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Buscaminas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Buscaminas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Buscaminas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Buscaminas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Buscaminas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Buscaminas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Buscaminas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Buscaminas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Buscaminas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Buscaminas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Buscaminas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Buscaminas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Buscaminas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Buscaminas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Buscaminas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Buscaminas] SET RECOVERY FULL 
GO
ALTER DATABASE [Buscaminas] SET  MULTI_USER 
GO
ALTER DATABASE [Buscaminas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Buscaminas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Buscaminas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Buscaminas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Buscaminas] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Buscaminas] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Buscaminas', N'ON'
GO
ALTER DATABASE [Buscaminas] SET QUERY_STORE = OFF
GO
USE [Buscaminas]
GO
/****** Object:  Table [dbo].[Board]    Script Date: 22/11/2022 13:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Board](
	[id] [int] NOT NULL,
	[width] [int] NOT NULL,
	[height] [int] NOT NULL,
	[numberOfMines] [int] NOT NULL,
	[numberOfMinesFlagged] [int] NOT NULL,
	[numberOfCellsFlagged] [int] NOT NULL,
 CONSTRAINT [PK_Board] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cell]    Script Date: 22/11/2022 13:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cell](
	[id] [int] NOT NULL,
	[boardId] [int] NOT NULL,
	[typeId] [int] NOT NULL,
	[number] [int] NULL,
	[flagged] [char](10) NOT NULL,
	[selected] [char](10) NOT NULL,
	[x] [int] NOT NULL,
	[y] [int] NOT NULL,
 CONSTRAINT [PK_Cell] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[boardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CellType]    Script Date: 22/11/2022 13:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CellType](
	[id] [int] NOT NULL,
	[type] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CellType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Game]    Script Date: 22/11/2022 13:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game](
	[id] [int] NOT NULL,
	[gameStateId] [int] NOT NULL,
	[timePlayedInSeconds] [int] NOT NULL,
 CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GameResult]    Script Date: 22/11/2022 13:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameResult](
	[id] [int] NOT NULL,
	[result] [varchar](50) NOT NULL,
 CONSTRAINT [PK_GameResult] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GameState]    Script Date: 22/11/2022 13:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameState](
	[id] [int] NOT NULL,
	[state] [varchar](50) NOT NULL,
 CONSTRAINT [PK_GameState] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MultiplayerGame]    Script Date: 22/11/2022 13:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MultiplayerGame](
	[id] [int] NOT NULL,
	[multiplayerResultId] [int] NULL,
 CONSTRAINT [PK_MultiplayerGame] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MultiplayerGameResult]    Script Date: 22/11/2022 13:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MultiplayerGameResult](
	[id] [int] NOT NULL,
	[resultId] [int] NOT NULL,
	[winner] [int] NULL,
 CONSTRAINT [PK_MultiplayerGameResult] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 22/11/2022 13:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[userId] [int] NOT NULL,
	[gameId] [int] NOT NULL,
	[score] [int] NOT NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[userId] ASC,
	[gameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinglePlayerGame]    Script Date: 22/11/2022 13:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinglePlayerGame](
	[id] [int] NOT NULL,
	[userId] [int] NOT NULL,
	[resultId] [int] NULL,
 CONSTRAINT [PK_SinglePlayerGame] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turn]    Script Date: 22/11/2022 13:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turn](
	[id] [int] NOT NULL,
	[currentPlayerId] [int] NULL,
	[number] [int] NOT NULL,
 CONSTRAINT [PK_Turn] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 22/11/2022 13:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[lastLogin] [bigint] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CellType] ([id], [type]) VALUES (0, N'Empty cell')
INSERT [dbo].[CellType] ([id], [type]) VALUES (1, N'Mine')
INSERT [dbo].[CellType] ([id], [type]) VALUES (2, N'Number')
GO
INSERT [dbo].[GameResult] ([id], [result]) VALUES (0, N'Win')
INSERT [dbo].[GameResult] ([id], [result]) VALUES (1, N'Lost')
INSERT [dbo].[GameResult] ([id], [result]) VALUES (2, N'Tie')
GO
INSERT [dbo].[GameState] ([id], [state]) VALUES (0, N'Pending')
INSERT [dbo].[GameState] ([id], [state]) VALUES (1, N'Looking for rival')
INSERT [dbo].[GameState] ([id], [state]) VALUES (2, N'In progress')
INSERT [dbo].[GameState] ([id], [state]) VALUES (3, N'Finished')
GO
ALTER TABLE [dbo].[Board]  WITH CHECK ADD  CONSTRAINT [FK_Board_Game] FOREIGN KEY([id])
REFERENCES [dbo].[Game] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Board] CHECK CONSTRAINT [FK_Board_Game]
GO
ALTER TABLE [dbo].[Cell]  WITH CHECK ADD  CONSTRAINT [FK_Cell_Board] FOREIGN KEY([boardId])
REFERENCES [dbo].[Board] ([id])
GO
ALTER TABLE [dbo].[Cell] CHECK CONSTRAINT [FK_Cell_Board]
GO
ALTER TABLE [dbo].[Cell]  WITH CHECK ADD  CONSTRAINT [FK_Cell_CellType] FOREIGN KEY([typeId])
REFERENCES [dbo].[CellType] ([id])
GO
ALTER TABLE [dbo].[Cell] CHECK CONSTRAINT [FK_Cell_CellType]
GO
ALTER TABLE [dbo].[Game]  WITH CHECK ADD  CONSTRAINT [FK_Game_GameState] FOREIGN KEY([gameStateId])
REFERENCES [dbo].[GameState] ([id])
GO
ALTER TABLE [dbo].[Game] CHECK CONSTRAINT [FK_Game_GameState]
GO
ALTER TABLE [dbo].[MultiplayerGame]  WITH CHECK ADD  CONSTRAINT [FK_MultiplayerGame_Game] FOREIGN KEY([id])
REFERENCES [dbo].[Game] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MultiplayerGame] CHECK CONSTRAINT [FK_MultiplayerGame_Game]
GO
ALTER TABLE [dbo].[MultiplayerGame]  WITH CHECK ADD  CONSTRAINT [FK_MultiplayerGame_MultiplayerGameResult] FOREIGN KEY([multiplayerResultId])
REFERENCES [dbo].[MultiplayerGameResult] ([id])
GO
ALTER TABLE [dbo].[MultiplayerGame] CHECK CONSTRAINT [FK_MultiplayerGame_MultiplayerGameResult]
GO
ALTER TABLE [dbo].[MultiplayerGameResult]  WITH CHECK ADD  CONSTRAINT [FK_MultiplayerGameResult_GameResult] FOREIGN KEY([resultId])
REFERENCES [dbo].[GameResult] ([id])
GO
ALTER TABLE [dbo].[MultiplayerGameResult] CHECK CONSTRAINT [FK_MultiplayerGameResult_GameResult]
GO
ALTER TABLE [dbo].[MultiplayerGameResult]  WITH CHECK ADD  CONSTRAINT [FK_MultiplayerGameResult_User] FOREIGN KEY([winner])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[MultiplayerGameResult] CHECK CONSTRAINT [FK_MultiplayerGameResult_User]
GO
ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [FK_Player_MultiplayerGame] FOREIGN KEY([gameId])
REFERENCES [dbo].[MultiplayerGame] ([id])
GO
ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [FK_Player_MultiplayerGame]
GO
ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [FK_Player_User] FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [FK_Player_User]
GO
ALTER TABLE [dbo].[SinglePlayerGame]  WITH CHECK ADD  CONSTRAINT [FK_SinglePlayerGame_Game] FOREIGN KEY([id])
REFERENCES [dbo].[Game] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SinglePlayerGame] CHECK CONSTRAINT [FK_SinglePlayerGame_Game]
GO
ALTER TABLE [dbo].[SinglePlayerGame]  WITH CHECK ADD  CONSTRAINT [FK_SinglePlayerGame_GameResult] FOREIGN KEY([resultId])
REFERENCES [dbo].[GameResult] ([id])
GO
ALTER TABLE [dbo].[SinglePlayerGame] CHECK CONSTRAINT [FK_SinglePlayerGame_GameResult]
GO
ALTER TABLE [dbo].[SinglePlayerGame]  WITH CHECK ADD  CONSTRAINT [FK_SinglePlayerGame_User] FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[SinglePlayerGame] CHECK CONSTRAINT [FK_SinglePlayerGame_User]
GO
ALTER TABLE [dbo].[Turn]  WITH CHECK ADD  CONSTRAINT [FK_Turn_MultiplayerGame] FOREIGN KEY([id])
REFERENCES [dbo].[MultiplayerGame] ([id])
GO
ALTER TABLE [dbo].[Turn] CHECK CONSTRAINT [FK_Turn_MultiplayerGame]
GO
ALTER TABLE [dbo].[Turn]  WITH CHECK ADD  CONSTRAINT [FK_Turn_User1] FOREIGN KEY([currentPlayerId])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Turn] CHECK CONSTRAINT [FK_Turn_User1]
GO
/****** Object:  StoredProcedure [dbo].[CHECK_USER_EXISTS]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CHECK_USER_EXISTS]
@email varchar(50)
as
begin
	SELECT COUNT(ID) FROM [User] WHERE email = @email
end

GO
/****** Object:  StoredProcedure [dbo].[CREATE_BASE_GAME]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[CREATE_BASE_GAME] 
@gameStateId int,
@timePlayed int
as
begin
	declare @id int
	set @id = (select isnull(max(id), 0) + 1 from game)

	insert into Game values (@id,@gameStateId,@timePlayed)

	return @id
end
GO
/****** Object:  StoredProcedure [dbo].[CREATE_BOARD]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CREATE_BOARD]
@id int, 
@width int,
@height int,
@numberOfMines int,
@numberOfMinesFlagged int,
@numberOfCellsFlagged int
as
begin
	insert into Board values(@id,@width,@height,@numberOfMines,@numberOfMinesFlagged,@numberOfCellsFlagged)
end

GO
/****** Object:  StoredProcedure [dbo].[CREATE_CELL]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CREATE_CELL]
@boardId int,
@typeId int,
@number int = NULL,
@flagged char,
@selected char,
@x int,
@y int
as
begin
	declare @id int
	set @id = (select isnull(max(id),0) + 1 from Cell)

	insert into Cell values (@id,@boardId,@typeId,@number,@flagged,@selected,@x,@y)

	return @id
end

GO
/****** Object:  StoredProcedure [dbo].[CREATE_MULTIPLAYER_GAME]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[CREATE_MULTIPLAYER_GAME]
@gameId int,
@ownerId int
as
begin
	insert into MultiplayerGame values(@gameId, null)
	insert into Player values(@ownerId,@gameId,0)
	insert into Turn values(@gameId,@ownerId,0)
end
GO
/****** Object:  StoredProcedure [dbo].[CREATE_SINGLE_P_GAME]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[CREATE_SINGLE_P_GAME]
@id int,
@userId int,
@resultId int = NULL
as 
begin
	insert into SinglePlayerGame values(@id,@userId,@resultId)

end

GO
/****** Object:  StoredProcedure [dbo].[CREATE_USER]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[CREATE_USER]
@name varchar(50),
@email varchar(50),
@password varchar(50),
@lastLoging bigint
as
begin
	
	declare @id int
	set @id = (SELECT ISNULL(MAX(id), -1) + 1 FROM [User])
	
	INSERT INTO [User] values (@id,@name,@email,@password,@lastLoging)

	return @id
end

GO
/****** Object:  StoredProcedure [dbo].[GET_GAMES_STATISTICS]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GET_GAMES_STATISTICS]
@userId int
as
begin
	 select 
	 g.id as id,
	 spg.resultId as singlePlayerResult,
	 mpgr.resultId as multiPlayerResult,
	 b.height as boardHeight,
	 b.width as boardWidth,
	 b.numberOfMines as numberOfMines,
	 g.timePlayedInSeconds as timePlayed,
	 mpgr.winner as winner
	 from Game g
	 join GameState gs on g.gameStateId = gs.id
	 join Board b on g.id = b.id
	 left join SinglePlayerGame spg on g.id = spg.id
	 left join MultiplayerGame mpg on g.id = mpg.id
	 left join MultiplayerGameResult mpgr on mpg.multiplayerResultId = mpgr.id
	 left join Player p on p.gameId = mpg.id
	 where gs.state = 'Finished'
	 and (spg.userId = @userId or p.userId = @userId)

end
GO
/****** Object:  StoredProcedure [dbo].[GET_PLAYERS_COUNT]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[GET_PLAYERS_COUNT] 
@gameId int
as
begin
	select COUNT(*) from Player where gameId = @gameId
end
GO
/****** Object:  StoredProcedure [dbo].[GET_USER]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GET_USER]
@email varchar(50),
@password varchar(50)
as
begin
	SELECT * FROM [User] WHERE email = @email AND password = @password
end

GO
/****** Object:  StoredProcedure [dbo].[JOIN_PLAYER_INTO_ROOM]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[JOIN_PLAYER_INTO_ROOM]
@userId int,
@gameId int
as
begin
	insert into Player values (@userId,@gameId,0)
	update Game set gameStateId = 2 where id = @gameId

	declare @currentPlayerTurn int
	set @currentPlayerTurn = (select currentPlayerId from Turn t where t.id = @gameId)

	if @currentPlayerTurn IS NULL
	begin
		update Turn set currentPlayerId = @userId where id = @gameId
	end
end
GO
/****** Object:  StoredProcedure [dbo].[LOAD_GAME_BOARD]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[LOAD_GAME_BOARD]
@gameId int
as 
begin
 select * from Board where id = @gameId
end

GO
/****** Object:  StoredProcedure [dbo].[LOAD_GAME_CELLS]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[LOAD_GAME_CELLS]
@boardId int
as 
begin
	select * from Cell c 
	JOIN CellType ct on c.typeId = ct.id
	where c.boardId = @boardId
end

GO
/****** Object:  StoredProcedure [dbo].[LOAD_INPROGRESS_SPG]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LOAD_INPROGRESS_SPG]
@userId int
as 
begin
	select g.id as gameId, 
	b.width as boardWidth,
	b.height as boardHeight,
	b.numberOfMines as totalMines,
	(b.numberOfMines - b.numberOfCellsFlagged) as remainingMines
	from SinglePlayerGame spg
	JOIN Game g on spg.id = g.id
	JOIN Board b on spg.id = b.id
	JOIN GameState s on g.gameStateId = s.id
	where spg.userId = @userId
	and s.state = 'In progress'
end

GO
/****** Object:  StoredProcedure [dbo].[LOAD_MPG_IN_PROGRESS]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[LOAD_MPG_IN_PROGRESS]
@userId int
as
begin
	select g.id as gameId,
	b.width as boardWidth,
	b.height as boardHeight,
	b.numberOfMines as totalMines,
	(b.numberOfMines - b.numberOfCellsFlagged) as remainingMines,
	u.name as gameOwnerName
	from MultiplayerGame mpg
	join Game g on mpg.id = g.id
	join GameState gs on g.gameStateId = gs.id
	join Player p on mpg.id = gameId
	join Board b on mpg.id = b.id
	join Turn t on mpg.id = t.id
	left join [User] u  on t.currentPlayerId = u.id
	where gs.state != 'Finished'
	and p.userId = @userId
end

GO
/****** Object:  StoredProcedure [dbo].[LOAD_MULTIPLAYER_GAME]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LOAD_MULTIPLAYER_GAME]
@gameId int
as
begin
	select mpg.id,
	mpg.multiplayerResultId,
	g.gameStateId,
	g.timePlayedInSeconds,
	t.currentPlayerId,
	t.number
	from MultiplayerGame mpg
	join Game g on mpg.id = g.id
	join Turn t on mpg.id = t.id
	where mpg.id = @gameId
end
GO
/****** Object:  StoredProcedure [dbo].[LOAD_OPEN_ROOMS]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LOAD_OPEN_ROOMS]
@userId int
as
begin
	select g.id as gameId,
	b.width as boardWidth,
	b.height as boardHeight,
	b.numberOfMines as totalMines,
	(b.numberOfMines - b.numberOfCellsFlagged) as remainingMines
	from MultiplayerGame mpg
	join Game g on mpg.id = g.id
	join GameState gs on g.gameStateId = gs.id
	join Player p on mpg.id = gameId
	join Board b on mpg.id = b.id
	join Turn t on mpg.id = t.id
	where gs.state = 'Looking for rival'
	and p.userId != @userId
	and t.currentPlayerId is null
end

GO
/****** Object:  StoredProcedure [dbo].[LOAD_PLAYERS]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LOAD_PLAYERS]
@gameId int
as
begin
	select p.userId as userId,
	p.gameId as gameId,
	p.score as score,
	u.name as name
	from Player p
	join [User] u on p.userId = u.id
	where gameId = @gameId
end
GO
/****** Object:  StoredProcedure [dbo].[LOAD_SINGLE_PLAYER_GAME]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[LOAD_SINGLE_PLAYER_GAME]
@gameId int
as 
begin
	select * from SinglePlayerGame spg
	join Game g on spg.id = g.id
	where spg.id = @gameId
end

GO
/****** Object:  StoredProcedure [dbo].[SET_MPG_RESULT]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SET_MPG_RESULT]
@gameId int,
@resultId int,
@winner int = null
as
begin
	declare @id int
	set @id = (SELECT ISNULL(MAX(id), -1) + 1 FROM MultiplayerGameResult)

	insert into MultiplayerGameResult values (@id,@resultId,@winner)
	update MultiplayerGame set multiplayerResultId = @id where id = @gameId
	update Game set gameStateId = 3 where id = @gameId
end
GO
/****** Object:  StoredProcedure [dbo].[UPDATE_BASE_GAME]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UPDATE_BASE_GAME]
@gameId int,
@gameStateId int,
@timePlayed int
as
begin
	update Game set 
	gameStateId = @gameStateId, 
	timePlayedInSeconds = @timePlayed 
	where id = @gameId
end
GO
/****** Object:  StoredProcedure [dbo].[UPDATE_BOARD]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UPDATE_BOARD]
@boardId int,
@numberOfMinesFlagged int,
@numberOfCellsFlagged int
as
begin
	update Board set
	numberOfMinesFlagged = @numberOfMinesFlagged,
	numberOfCellsFlagged = @numberOfCellsFlagged
	where id = @boardId
end

GO
/****** Object:  StoredProcedure [dbo].[UPDATE_CELL_FLAGGED]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UPDATE_CELL_FLAGGED]
@cellId int,
@flagged char
as
begin
	update Cell set
	flagged = @flagged
	where id = @cellId
end

GO
/****** Object:  StoredProcedure [dbo].[UPDATE_CELL_SELECTED]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UPDATE_CELL_SELECTED]
@cellId int,
@selected char,
@flagged char
as
begin
	update Cell set
	selected = @selected,
	flagged = @flagged
	where id = @cellId
end

GO
/****** Object:  StoredProcedure [dbo].[UPDATE_LAST_LOGIN]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UPDATE_LAST_LOGIN]
@userId int,
@lastLogin bigint
as
begin

	update [User] set lastLogin = @lastLogin where id = @userId

end

GO
/****** Object:  StoredProcedure [dbo].[UPDATE_PLAYER_SCORE]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[UPDATE_PLAYER_SCORE]
@userId int,
@gameId int,
@score int
as
begin
	UPDATE Player set score = @score where userId = @userId and gameId = @gameId
end
GO
/****** Object:  StoredProcedure [dbo].[UPDATE_SINGLE_PLAYER_GAME]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UPDATE_SINGLE_PLAYER_GAME]
@id int,
@resultId int
as
begin
	update SinglePlayerGame set
	resultId = @resultId
	where id = @id
end

GO
/****** Object:  StoredProcedure [dbo].[UPDATE_TIME_PLAYED]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UPDATE_TIME_PLAYED]
@gameId int,
@timePlayed int
as
begin
	update Game set
	timePlayedInSeconds = @timePlayed
	where id = @gameId
end

GO
/****** Object:  StoredProcedure [dbo].[UPDATE_TURN]    Script Date: 22/11/2022 13:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UPDATE_TURN]
@turnId int,
@turnNumber int,
@currentPlayerId int = null
as
begin
	update turn set currentPlayerId = @currentPlayerId, number = @turnNumber where id = @turnId
end
GO
USE [master]
GO
ALTER DATABASE [Buscaminas] SET  READ_WRITE 
GO
