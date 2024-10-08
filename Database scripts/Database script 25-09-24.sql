USE [master]
GO
/****** Object:  Database [Filmanmeldelse]    Script Date: 25-09-2024 13:03:21 ******/
CREATE DATABASE [Filmanmeldelse]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Filmanmeldelse', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Filmanmeldelse.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Filmanmeldelse_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Filmanmeldelse_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Filmanmeldelse] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Filmanmeldelse].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Filmanmeldelse] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Filmanmeldelse] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Filmanmeldelse] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Filmanmeldelse] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Filmanmeldelse] SET ARITHABORT OFF 
GO
ALTER DATABASE [Filmanmeldelse] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Filmanmeldelse] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Filmanmeldelse] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Filmanmeldelse] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Filmanmeldelse] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Filmanmeldelse] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Filmanmeldelse] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Filmanmeldelse] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Filmanmeldelse] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Filmanmeldelse] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Filmanmeldelse] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Filmanmeldelse] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Filmanmeldelse] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Filmanmeldelse] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Filmanmeldelse] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Filmanmeldelse] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Filmanmeldelse] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Filmanmeldelse] SET RECOVERY FULL 
GO
ALTER DATABASE [Filmanmeldelse] SET  MULTI_USER 
GO
ALTER DATABASE [Filmanmeldelse] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Filmanmeldelse] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Filmanmeldelse] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Filmanmeldelse] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Filmanmeldelse] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Filmanmeldelse] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Filmanmeldelse', N'ON'
GO
ALTER DATABASE [Filmanmeldelse] SET QUERY_STORE = ON
GO
ALTER DATABASE [Filmanmeldelse] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Filmanmeldelse]
GO
/****** Object:  User [Remote]    Script Date: 25-09-2024 13:03:21 ******/
CREATE USER [Remote] FOR LOGIN [Remote] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Remote]
GO
/****** Object:  Table [dbo].[Anmeldelser]    Script Date: 25-09-2024 13:03:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Anmeldelser](
	[FilmID] [int] NOT NULL,
	[AnmelderID] [int] NOT NULL,
	[Titel] [varchar](42) NULL,
	[Begrundelse] [varchar](1000) NULL,
	[Bedømmelse] [int] NULL,
	[Anmeldsdato] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FilmID] ASC,
	[AnmelderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Film]    Script Date: 25-09-2024 13:03:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Film](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Titel] [varchar](120) NOT NULL,
	[Plakat] [image] NOT NULL,
	[Synopse] [varchar](500) NOT NULL,
	[Aldersgrænse] [varchar](5) NOT NULL,
	[Udgivelsesdato] [date] NOT NULL,
	[Spilletid] [time](7) NOT NULL,
	[Gennemsnitsanmeldelse] [decimal](2, 1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilmGenre]    Script Date: 25-09-2024 13:03:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilmGenre](
	[FilmID] [int] NOT NULL,
	[Genre] [nchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FilmID] ASC,
	[Genre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilmInstruktør]    Script Date: 25-09-2024 13:03:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilmInstruktør](
	[FilmID] [int] NOT NULL,
	[InstruktørID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FilmID] ASC,
	[InstruktørID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilmProducer]    Script Date: 25-09-2024 13:03:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilmProducer](
	[FilmID] [int] NOT NULL,
	[ProducerID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProducerID] ASC,
	[FilmID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 25-09-2024 13:03:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[Genre] [nchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Genre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Instruktør]    Script Date: 25-09-2024 13:03:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instruktør](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Fuldenavn] [nvarchar](64) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kommentar]    Script Date: 25-09-2024 13:03:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kommentar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Kommentar] [varchar](1000) NOT NULL,
	[kommentatorID] [int] NOT NULL,
	[AnmeldelsensAnmelderID] [int] NOT NULL,
	[AnmeldelsensFilmID] [int] NOT NULL,
	[KommentarDato] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producer]    Script Date: 25-09-2024 13:03:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Fuldenavn] [nvarchar](64) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rolle]    Script Date: 25-09-2024 13:03:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rolle](
	[FilmID] [int] NOT NULL,
	[Rollenavn] [varchar](31) NOT NULL,
	[Beskrivelse] [varchar](120) NULL,
PRIMARY KEY CLUSTERED 
(
	[FilmID] ASC,
	[Rollenavn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skuespiller]    Script Date: 25-09-2024 13:03:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skuespiller](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Fuldenavn] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SkuespillerRolle]    Script Date: 25-09-2024 13:03:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SkuespillerRolle](
	[FilmID] [int] NOT NULL,
	[Rollenavn] [varchar](31) NOT NULL,
	[SkuespillerID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FilmID] ASC,
	[Rollenavn] ASC,
	[SkuespillerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 25-09-2024 13:03:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Brugernavn] [nvarchar](64) NOT NULL,
	[Billede] [image] NULL,
	[Adgangskode] [nvarchar](30) NOT NULL,
	[Oprettelsesdato] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Brugere__6BE4ADA07DFE2509]    Script Date: 25-09-2024 13:03:21 ******/
ALTER TABLE [dbo].[User] ADD UNIQUE NONCLUSTERED 
(
	[Brugernavn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Anmeldelser] ADD  DEFAULT (getdate()) FOR [Anmeldsdato]
GO
ALTER TABLE [dbo].[Film] ADD  DEFAULT ((0)) FOR [Gennemsnitsanmeldelse]
GO
ALTER TABLE [dbo].[Kommentar] ADD  DEFAULT (getdate()) FOR [KommentarDato]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (getdate()) FOR [Oprettelsesdato]
GO
ALTER TABLE [dbo].[Anmeldelser]  WITH CHECK ADD FOREIGN KEY([AnmelderID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Anmeldelser]  WITH CHECK ADD FOREIGN KEY([FilmID])
REFERENCES [dbo].[Film] ([ID])
GO
ALTER TABLE [dbo].[FilmGenre]  WITH CHECK ADD FOREIGN KEY([FilmID])
REFERENCES [dbo].[Film] ([ID])
GO
ALTER TABLE [dbo].[FilmGenre]  WITH CHECK ADD FOREIGN KEY([Genre])
REFERENCES [dbo].[Genre] ([Genre])
GO
ALTER TABLE [dbo].[FilmInstruktør]  WITH CHECK ADD FOREIGN KEY([FilmID])
REFERENCES [dbo].[Film] ([ID])
GO
ALTER TABLE [dbo].[FilmInstruktør]  WITH CHECK ADD FOREIGN KEY([InstruktørID])
REFERENCES [dbo].[Instruktør] ([ID])
GO
ALTER TABLE [dbo].[FilmProducer]  WITH CHECK ADD FOREIGN KEY([FilmID])
REFERENCES [dbo].[Film] ([ID])
GO
ALTER TABLE [dbo].[FilmProducer]  WITH CHECK ADD FOREIGN KEY([ProducerID])
REFERENCES [dbo].[Producer] ([ID])
GO
ALTER TABLE [dbo].[Kommentar]  WITH CHECK ADD FOREIGN KEY([AnmeldelsensAnmelderID], [AnmeldelsensFilmID])
REFERENCES [dbo].[Anmeldelser] ([FilmID], [AnmelderID])
GO
ALTER TABLE [dbo].[Kommentar]  WITH CHECK ADD FOREIGN KEY([kommentatorID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Rolle]  WITH CHECK ADD FOREIGN KEY([FilmID])
REFERENCES [dbo].[Film] ([ID])
GO
ALTER TABLE [dbo].[SkuespillerRolle]  WITH CHECK ADD FOREIGN KEY([SkuespillerID])
REFERENCES [dbo].[Skuespiller] ([ID])
GO
ALTER TABLE [dbo].[SkuespillerRolle]  WITH CHECK ADD FOREIGN KEY([FilmID], [Rollenavn])
REFERENCES [dbo].[Rolle] ([FilmID], [Rollenavn])
GO
ALTER TABLE [dbo].[Anmeldelser]  WITH CHECK ADD CHECK  (([Bedømmelse]>=(1) AND [Bedømmelse]<=(5)))
GO
USE [master]
GO
ALTER DATABASE [Filmanmeldelse] SET  READ_WRITE 
GO
