USE [master]
GO
/****** Object:  Database [DirectAxisGame]    Script Date: 2021/01/31 16:28:38 ******/
CREATE DATABASE [DirectAxisGame]
GO
ALTER DATABASE [DirectAxisGame] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DirectAxisGame] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DirectAxisGame] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DirectAxisGame] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DirectAxisGame] SET ARITHABORT OFF 
GO
ALTER DATABASE [DirectAxisGame] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DirectAxisGame] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DirectAxisGame] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DirectAxisGame] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DirectAxisGame] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DirectAxisGame] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DirectAxisGame] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DirectAxisGame] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DirectAxisGame] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DirectAxisGame] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DirectAxisGame] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DirectAxisGame] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DirectAxisGame] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DirectAxisGame] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DirectAxisGame] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DirectAxisGame] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DirectAxisGame] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DirectAxisGame] SET RECOVERY FULL 
GO
ALTER DATABASE [DirectAxisGame] SET  MULTI_USER 
GO
ALTER DATABASE [DirectAxisGame] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DirectAxisGame] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DirectAxisGame] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DirectAxisGame] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DirectAxisGame] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DirectAxisGame', N'ON'
GO
ALTER DATABASE [DirectAxisGame] SET QUERY_STORE = OFF
GO
USE [DirectAxisGame]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 2021/01/31 16:28:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[CarID] [int] IDENTITY(1,1) NOT NULL,
	[CarName] [varchar](50) NOT NULL,
	[Acceleration] [int] NOT NULL,
	[Braking] [int] NOT NULL,
	[Cornering] [int] NOT NULL,
	[TopSpeed] [int] NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[CarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tracks]    Script Date: 2021/01/31 16:28:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tracks](
	[TrackID] [int] IDENTITY(1,1) NOT NULL,
	[TrackName] [varchar](50) NOT NULL,
	[TrackValues] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 

INSERT [dbo].[Cars] ([CarID], [CarName], [Acceleration], [Braking], [Cornering], [TopSpeed], [TimeStamp]) VALUES (1, N'Journey', 10, 4, 7, 8, CAST(N'2020-01-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Cars] ([CarID], [CarName], [Acceleration], [Braking], [Cornering], [TopSpeed], [TimeStamp]) VALUES (2, N'CORV', 8, 3, 4, 9, CAST(N'2020-01-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Cars] ([CarID], [CarName], [Acceleration], [Braking], [Cornering], [TopSpeed], [TimeStamp]) VALUES (3, N'GTR', 6, 7, 9, 8, CAST(N'2020-01-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Cars] ([CarID], [CarName], [Acceleration], [Braking], [Cornering], [TopSpeed], [TimeStamp]) VALUES (4, N'Hyundai', 5, 8, 3, 9, CAST(N'2020-01-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Cars] ([CarID], [CarName], [Acceleration], [Braking], [Cornering], [TopSpeed], [TimeStamp]) VALUES (5, N'KOUP', 7, 7, 7, 7, CAST(N'2020-01-31T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Cars] OFF
SET IDENTITY_INSERT [dbo].[Tracks] ON 

INSERT [dbo].[Tracks] ([TrackID], [TrackName], [TrackValues]) VALUES (1, N'Straight Track', N'11110011100011001110011101')
INSERT [dbo].[Tracks] ([TrackID], [TrackName], [TrackValues]) VALUES (2, N'Cornering Track', N'11111111001111110111100001')
INSERT [dbo].[Tracks] ([TrackID], [TrackName], [TrackValues]) VALUES (3, N'Custom Track', N'10101110110110101101101111101')
INSERT [dbo].[Tracks] ([TrackID], [TrackName], [TrackValues]) VALUES (4, N'Custom Track 2', N'0011100011010')
INSERT [dbo].[Tracks] ([TrackID], [TrackName], [TrackValues]) VALUES (5, N'Open Road', N'100111111110100011111111111')
SET IDENTITY_INSERT [dbo].[Tracks] OFF
/****** Object:  StoredProcedure [dbo].[procInsertNewTrack]    Script Date: 2021/01/31 16:28:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[procInsertNewTrack]
	@TrackName					varchar(50),
	@TrackValues				varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Tracks(TrackName,TrackValues)
	VALUES(@TrackName,@TrackValues)
END
GO
/****** Object:  StoredProcedure [dbo].[procSelectCars]    Script Date: 2021/01/31 16:28:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kagiso Mahlobogoane
-- Create date: 2021-01-31
-- Description:	Procedure to select all the cars.
-- =============================================
CREATE PROCEDURE [dbo].[procSelectCars]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT CarID,CarName,Acceleration,Braking,Cornering,TopSpeed,[TimeStamp]
	FROM Cars
	ORDER BY CarID ASC
END
GO
/****** Object:  StoredProcedure [dbo].[procSelectTracks]    Script Date: 2021/01/31 16:28:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kagiso Mahlobogoane
-- Create date: 2021-01-31
-- Description:	Procedure to select the tracks
-- =============================================
CREATE PROCEDURE [dbo].[procSelectTracks]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TrackID,TrackName,TrackValues
	FROM Tracks
	ORDER BY TrackID ASC
END
GO
USE [master]
GO
ALTER DATABASE [DirectAxisGame] SET  READ_WRITE 
GO
