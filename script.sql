USE [master]
GO
/****** Object:  Database [BangRevolution]    Script Date: 08/17/2016 09:58:22 ******/
CREATE DATABASE [BangRevolution] ON  PRIMARY 
( NAME = N'BangRevolution', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\BangRevolution.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BangRevolution_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\BangRevolution_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BangRevolution] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BangRevolution].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BangRevolution] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [BangRevolution] SET ANSI_NULLS OFF
GO
ALTER DATABASE [BangRevolution] SET ANSI_PADDING OFF
GO
ALTER DATABASE [BangRevolution] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [BangRevolution] SET ARITHABORT OFF
GO
ALTER DATABASE [BangRevolution] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [BangRevolution] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [BangRevolution] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [BangRevolution] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [BangRevolution] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [BangRevolution] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [BangRevolution] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [BangRevolution] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [BangRevolution] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [BangRevolution] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [BangRevolution] SET  DISABLE_BROKER
GO
ALTER DATABASE [BangRevolution] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [BangRevolution] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [BangRevolution] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [BangRevolution] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [BangRevolution] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [BangRevolution] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [BangRevolution] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [BangRevolution] SET  READ_WRITE
GO
ALTER DATABASE [BangRevolution] SET RECOVERY FULL
GO
ALTER DATABASE [BangRevolution] SET  MULTI_USER
GO
ALTER DATABASE [BangRevolution] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [BangRevolution] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'BangRevolution', N'ON'
GO
USE [BangRevolution]
GO
/****** Object:  Table [dbo].[Games]    Script Date: 08/17/2016 09:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Games](
	[ID] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Time] [bigint] NOT NULL,
 CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Characters]    Script Date: 08/17/2016 09:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Characters](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Desc] [nvarchar](max) NOT NULL,
	[SkillID] [int] NOT NULL,
	[HP] [int] NOT NULL,
	[Img] [nvarchar](50) NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_Characters] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Characters] ON
INSERT [dbo].[Characters] ([ID], [Name], [Desc], [SkillID], [HP], [Img], [Price]) VALUES (1, N'SUZY LAFAYETTE', N'As soon as she has no cards in and, she draw one', 1, 4, N'1', 0)
INSERT [dbo].[Characters] ([ID], [Name], [Desc], [SkillID], [HP], [Img], [Price]) VALUES (2, N'PAUL REGRET', N'All players see him at a distance increased by 1', 2, 3, N'link', 0)
INSERT [dbo].[Characters] ([ID], [Name], [Desc], [SkillID], [HP], [Img], [Price]) VALUES (3, N'BLACK JACK', N'During phase 1 of his turn, he must show the second card he draws: if it’s Heart or Diamonds (just like a ''draw!''), he draws one additional card (without revealing it)', 12, 4, N'a', 50)
INSERT [dbo].[Characters] ([ID], [Name], [Desc], [SkillID], [HP], [Img], [Price]) VALUES (4, N'PEDRO RAMIREZ', N'He may draw his first card from the discard pile ', 3, 4, N'link', 0)
INSERT [dbo].[Characters] ([ID], [Name], [Desc], [SkillID], [HP], [Img], [Price]) VALUES (5, N'CALAMITY JANET', N'She can play BANG! cards as Missed! cards and vice versa', 4, 4, N'LINK', 100)
INSERT [dbo].[Characters] ([ID], [Name], [Desc], [SkillID], [HP], [Img], [Price]) VALUES (6, N'EL GRINGO ', N'Each time he is hit by a player, he draws a card from the hand of that player', 5, 3, N'LINK', 0)
INSERT [dbo].[Characters] ([ID], [Name], [Desc], [SkillID], [HP], [Img], [Price]) VALUES (7, N'JOURDONNAIS', N'Whenever he is the target of a BANG!, he may "draw!": on a Heart, he is missed ', 6, 4, N'L', 0)
INSERT [dbo].[Characters] ([ID], [Name], [Desc], [SkillID], [HP], [Img], [Price]) VALUES (8, N'LUCKY DUKE', N'Each time he "draws!", he flips the top two cards and chooses one ', 7, 4, N'L', 0)
INSERT [dbo].[Characters] ([ID], [Name], [Desc], [SkillID], [HP], [Img], [Price]) VALUES (9, N'SLAB THE KILLER', N'Player needs 2 Missed! Card to cancel his BANG! card', 8, 4, N'L', 0)
INSERT [dbo].[Characters] ([ID], [Name], [Desc], [SkillID], [HP], [Img], [Price]) VALUES (10, N'WILLY THE KID ', N'He can play any number of BANG! cards.', 9, 4, N'L', 100)
INSERT [dbo].[Characters] ([ID], [Name], [Desc], [SkillID], [HP], [Img], [Price]) VALUES (11, N'JESSE JONES', N'He may draw his first card from the hand of a player ', 10, 4, N'L', 50)
INSERT [dbo].[Characters] ([ID], [Name], [Desc], [SkillID], [HP], [Img], [Price]) VALUES (12, N'BART CASSIDY', N'Each time he is hit, he draws a card', 11, 4, N'L', 0)
INSERT [dbo].[Characters] ([ID], [Name], [Desc], [SkillID], [HP], [Img], [Price]) VALUES (13, N'KIT CARLSON', N'He looks at the top three cards of the deck and chooses the 2 to draw', 13, 4, N'L', 0)
INSERT [dbo].[Characters] ([ID], [Name], [Desc], [SkillID], [HP], [Img], [Price]) VALUES (14, N'ROSE DOOLAN ', N'She sees all players at a distance decreased by 1', 14, 4, N'L', 0)
INSERT [dbo].[Characters] ([ID], [Name], [Desc], [SkillID], [HP], [Img], [Price]) VALUES (15, N'SID KETCHUM', N'He may discard 2 cards to regain one life point', 15, 4, N'L', 0)
INSERT [dbo].[Characters] ([ID], [Name], [Desc], [SkillID], [HP], [Img], [Price]) VALUES (16, N'VULTURE SAM', N'Whenever a  player is eliminated from play he takes in hand all the cards of the player ', 16, 4, N'L', 0)
SET IDENTITY_INSERT [dbo].[Characters] OFF
/****** Object:  Table [dbo].[Roles]    Script Date: 08/17/2016 09:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Desc] [nvarchar](50) NOT NULL,
	[Img] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Roles] ([ID], [Name], [Desc], [Img]) VALUES (1, N'SCERIFFO', N'Kill all the Outlaws and the Renegade', N'1')
INSERT [dbo].[Roles] ([ID], [Name], [Desc], [Img]) VALUES (2, N'Vice', N'Protect the sceriffo, kill the outlaws, renegade', N'2')
INSERT [dbo].[Roles] ([ID], [Name], [Desc], [Img]) VALUES (3, N'Outlaws', N'kill the sceriffo', N'3')
INSERT [dbo].[Roles] ([ID], [Name], [Desc], [Img]) VALUES (4, N'Renegade', N'Be the last one in play', N'4')
/****** Object:  Table [dbo].[Items]    Script Date: 08/17/2016 09:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[isBg] [bit] NOT NULL,
	[Price] [float] NOT NULL,
	[Img] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Items] ON
INSERT [dbo].[Items] ([ID], [Name], [isBg], [Price], [Img]) VALUES (1, N'Default Background', 1, 0, N'l')
INSERT [dbo].[Items] ([ID], [Name], [isBg], [Price], [Img]) VALUES (2, N'Default Back card', 0, 0, N'1')
INSERT [dbo].[Items] ([ID], [Name], [isBg], [Price], [Img]) VALUES (3, N'Cowboy Back card', 0, 50, N'1')
INSERT [dbo].[Items] ([ID], [Name], [isBg], [Price], [Img]) VALUES (4, N'Cowboy Background', 1, 50, N'1')
SET IDENTITY_INSERT [dbo].[Items] OFF
/****** Object:  Table [dbo].[Cards]    Script Date: 08/17/2016 09:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cards](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Type] [int] NOT NULL,
	[Desc] [nvarchar](max) NOT NULL,
	[Img] [nvarchar](50) NOT NULL,
	[EffectID] [int] NULL,
	[Range] [int] NULL,
	[Suit] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cards] ON
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (1, N'VOLCANIC', 1, N'You can play any number of BANG!', N'l', 1, 10, 4)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (2, N'VOLCANIC', 1, N'You can play any number of BANG!', N'L', 1, 10, 1)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (3, N'SCHOFIELD', 1, N'', N'L', 2, 11, 1)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (4, N'SCHOFIELD', 1, N'', N'L', 2, 12, 1)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (5, N'SCHOFIELD', 1, N'', N'L', 2, 13, 4)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (6, N'REMINGTON', 1, N'', N'l', 3, 13, 1)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (7, N'REV. CARABINE', 1, N'', N'l', 4, 1, 1)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (8, N'WINCHESTER', 1, N'', N'l', 5, 8, 4)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (9, N'Bang', 0, N'', N'l', 6, 2, 1)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (10, N'BANG', 0, N'', N'l', 6, 3, 1)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (11, N'BANG', 0, N'', N'l', 6, 4, 1)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (12, N'BANG', 0, N'', N'l', 6, 5, 1)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (13, N'BANG', 0, N'', N'l', 6, 6, 1)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (14, N'BANG', 0, N'', N'l', 6, 7, 1)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (15, N'BANG', 0, N'', N'l', 6, 8, 1)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (16, N'BANG', 0, N'', N'l', 6, 9, 1)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (17, N'BANG', 0, N'', N'l', 6, 2, 2)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (18, N'BANG', 0, N'', N'l', 6, 3, 2)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (19, N'BANG', 0, N'', N'l', 6, 4, 2)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (20, N'BANG', 0, N'', N'l', 6, 5, 2)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (21, N'BANG', 0, N'', N'l', 6, 6, 2)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (22, N'BANG', 0, N'', N'l', 6, 7, 2)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (23, N'BANG', 0, N'', N'l', 6, 8, 2)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (24, N'BANG', 0, N'', N'l', 6, 9, 2)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (25, N'BANG', 0, N'', N'l', 6, 10, 2)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (26, N'BANG', 0, N'', N'l', 6, 11, 2)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (27, N'BANG', 0, N'', N'l', 6, 12, 2)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (28, N'BANG', 0, N'', N'l', 6, 13, 2)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (29, N'BANG', 0, N'', N'l', 6, 1, 2)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (30, N'BANG', 0, N'', N'l', 6, 12, 3)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (31, N'BANG', 0, N'', N'l', 6, 13, 3)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (32, N'BANG', 0, N'', N'l', 6, 1, 3)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (33, N'BANG', 0, N'', N'l', 6, 1, 4)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (34, N'MISSED', 0, N'', N'l', 7, 10, 1)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (35, N'MISSED', 0, N'', N'l', 7, 11, 1)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (36, N'MISSED', 0, N'', N'l', 7, 12, 1)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (37, N'MISSED', 0, N'', N'l', 7, 13, 1)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (38, N'MISSED', 0, N'', N'l', 7, 1, 1)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (39, N'MISSED', 0, N'', N'l', 7, 2, 4)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (40, N'MISSED', 0, N'', N'l', 7, 3, 4)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (41, N'MISSED', 0, N'', N'l', 7, 4, 4)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (42, N'MISSED', 0, N'', N'l', 7, 5, 4)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (43, N'MISSED', 0, N'', N'l', 7, 6, 4)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (44, N'MISSED', 0, N'', N'l', 7, 7, 4)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (45, N'MISSED', 0, N'', N'l', 7, 8, 4)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (46, N'BEER', 0, N'', N'l', 8, 6, 3)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (47, N'BEER', 0, N'', N'l', 8, 7, 3)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (48, N'BEER', 0, N'', N'l', 8, 8, 3)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (49, N'BEER', 0, N'', N'l', 8, 9, 3)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (50, N'BEER', 0, N'', N'l', 8, 10, 3)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (51, N'BEER', 0, N'', N'l', 8, 11, 3)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (52, N'PANIC', 0, N'', N'l', 9, 11, 3)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (53, N'PANIC', 0, N'', N'l', 9, 12, 3)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (54, N'PANIC', 0, N'', N'l', 9, 1, 3)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (55, N'PANIC', 0, N'', N'l', 9, 8, 2)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (56, N'CAT BLOU', 0, N'', N'l', 10, 9, 2)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (57, N'CAT BLOU', 0, N'', N'l', 10, 10, 2)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (58, N'CAT BLOU', 0, N'', N'l', 10, 11, 2)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (59, N'CAT BLOU', 0, N'', N'l', 10, 13, 3)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (60, N'STAGECOACH', 0, N'', N'l', 11, 9, 4)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (61, N'STAGECOACH', 0, N'', N'l', 11, 9, 4)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (62, N'WELLS FARGO', 0, N'', N'l', 12, 3, 3)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (63, N'GATLING', 0, N'', N'l', 13, 10, 3)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (64, N'DUEL', 0, N'A target player discards a BANG!, then you, etc. First player failing to discard a BANG! lose 1 life point.', N'l', 14, 12, 2)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (65, N'DUEL', 0, N'A target player discards a BANG!, then you, etc. First player failing to discard a BANG! lose 1 life point.', N'l', 14, 11, 4)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (66, N'DUEL', 0, N'A target player discards a BANG!, then you, etc. First player failing to discard a BANG! lose 1 life point.', N'l', 14, 8, 1)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (67, N'INDIANS', 0, N'All other players discard a Bang! or lose 1 life point', N'l', 15, 13, 2)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (68, N'INDIANS', 0, N'All other players discard a Bang! or lose 1 life point', N'l', 15, 1, 2)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (69, N'GENERAL STORE', 0, N'Reveal as many cards as players. Each player draws one.', N'l', 16, 9, 1)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (70, N'GENERAL STORE', 0, N'Reveal as many cards as players. Each player draws one.', N'l', 16, 12, 4)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (71, N'SALOON', 0, N'', N'l', 17, 5, 3)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (72, N'JAIL', 0, N'Discard tha Jail, play normally. Else discard the Jail and skip your turn', N'l', 18, 10, 4)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (73, N'JAIL', 0, N'Discard tha Jail, play normally. Else discard the Jail and skip your turn', N'l', 18, 11, 4)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (74, N'JAIL', 0, N'Discard tha Jail, play normally. Else discard the Jail and skip your turn', N'l', 18, 4, 3)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (75, N'Dynamite', 0, N'Lose 3 life points. Else pass the Dynamite on your left', N'l', 19, 2, 3)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (76, N'BARREL', 0, N'', N'l', 20, 12, 4)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (77, N'BARREL', 0, N'', N'l', 20, 13, 4)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (78, N'MIRINO', 0, N'You view other at distance -1', N'l', 21, 1, 4)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (79, N'MUSTANG', 0, N'Other view you at distance +1', N'l', 22, 8, 3)
INSERT [dbo].[Cards] ([ID], [Name], [Type], [Desc], [Img], [EffectID], [Range], [Suit]) VALUES (80, N'MUSTANG', 0, N'Other view you at distance +1', N'l', 22, 9, 3)
SET IDENTITY_INSERT [dbo].[Cards] OFF
/****** Object:  Table [dbo].[Users]    Script Date: 08/17/2016 09:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Pass] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([ID], [Name], [Pass], [Email]) VALUES (1, N'sonnt', N'123456', N'sonnt@fpt.edu.vn')
INSERT [dbo].[Users] ([ID], [Name], [Pass], [Email]) VALUES (2, N'tu', N'123a', N'tu@fpt.edu.vn')
INSERT [dbo].[Users] ([ID], [Name], [Pass], [Email]) VALUES (3, N'at', N'123a', N'at@fpt.edu.vn')
INSERT [dbo].[Users] ([ID], [Name], [Pass], [Email]) VALUES (4, N'97', N'123a', N'97@fpt.edu.vn')
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Table [dbo].[UserData]    Script Date: 08/17/2016 09:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserData](
	[User ID] [int] NOT NULL,
	[Exp] [bigint] NOT NULL,
	[Win] [bigint] NOT NULL,
	[Lose] [bigint] NOT NULL,
	[Money] [bigint] NOT NULL,
	[CurrentBg] [int] NOT NULL,
	[CurrentBackCard] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[UserData] ([User ID], [Exp], [Win], [Lose], [Money], [CurrentBg], [CurrentBackCard]) VALUES (1, 8000, 100, 0, 9999999, 1, 1)
INSERT [dbo].[UserData] ([User ID], [Exp], [Win], [Lose], [Money], [CurrentBg], [CurrentBackCard]) VALUES (2, 2500, 1, 1, 5000, 1, 1)
INSERT [dbo].[UserData] ([User ID], [Exp], [Win], [Lose], [Money], [CurrentBg], [CurrentBackCard]) VALUES (3, 2500, 1, 1, 5000, 1, 1)
INSERT [dbo].[UserData] ([User ID], [Exp], [Win], [Lose], [Money], [CurrentBg], [CurrentBackCard]) VALUES (4, 2500, 1, 1, 5000, 1, 1)
/****** Object:  Table [dbo].[ItemPurchase]    Script Date: 08/17/2016 09:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemPurchase](
	[Item ID] [int] NOT NULL,
	[User ID] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[ItemPurchase] ([Item ID], [User ID]) VALUES (1, 1)
INSERT [dbo].[ItemPurchase] ([Item ID], [User ID]) VALUES (2, 1)
INSERT [dbo].[ItemPurchase] ([Item ID], [User ID]) VALUES (3, 1)
INSERT [dbo].[ItemPurchase] ([Item ID], [User ID]) VALUES (4, 1)
INSERT [dbo].[ItemPurchase] ([Item ID], [User ID]) VALUES (1, 2)
INSERT [dbo].[ItemPurchase] ([Item ID], [User ID]) VALUES (1, 3)
INSERT [dbo].[ItemPurchase] ([Item ID], [User ID]) VALUES (1, 4)
INSERT [dbo].[ItemPurchase] ([Item ID], [User ID]) VALUES (2, 2)
INSERT [dbo].[ItemPurchase] ([Item ID], [User ID]) VALUES (2, 3)
INSERT [dbo].[ItemPurchase] ([Item ID], [User ID]) VALUES (2, 4)
/****** Object:  Table [dbo].[GamesHistory]    Script Date: 08/17/2016 09:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GamesHistory](
	[User ID] [int] NOT NULL,
	[Game ID] [int] NOT NULL,
	[isWinner] [bit] NOT NULL,
	[Role ID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CharacterPuchase]    Script Date: 08/17/2016 09:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CharacterPuchase](
	[Char ID] [int] NOT NULL,
	[User ID] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[CharacterPuchase] ([Char ID], [User ID]) VALUES (1, 1)
INSERT [dbo].[CharacterPuchase] ([Char ID], [User ID]) VALUES (2, 1)
INSERT [dbo].[CharacterPuchase] ([Char ID], [User ID]) VALUES (3, 1)
INSERT [dbo].[CharacterPuchase] ([Char ID], [User ID]) VALUES (4, 1)
INSERT [dbo].[CharacterPuchase] ([Char ID], [User ID]) VALUES (5, 1)
INSERT [dbo].[CharacterPuchase] ([Char ID], [User ID]) VALUES (6, 1)
INSERT [dbo].[CharacterPuchase] ([Char ID], [User ID]) VALUES (7, 1)
INSERT [dbo].[CharacterPuchase] ([Char ID], [User ID]) VALUES (8, 1)
INSERT [dbo].[CharacterPuchase] ([Char ID], [User ID]) VALUES (9, 1)
INSERT [dbo].[CharacterPuchase] ([Char ID], [User ID]) VALUES (10, 1)
INSERT [dbo].[CharacterPuchase] ([Char ID], [User ID]) VALUES (11, 1)
INSERT [dbo].[CharacterPuchase] ([Char ID], [User ID]) VALUES (12, 1)
INSERT [dbo].[CharacterPuchase] ([Char ID], [User ID]) VALUES (13, 1)
INSERT [dbo].[CharacterPuchase] ([Char ID], [User ID]) VALUES (14, 1)
INSERT [dbo].[CharacterPuchase] ([Char ID], [User ID]) VALUES (15, 1)
INSERT [dbo].[CharacterPuchase] ([Char ID], [User ID]) VALUES (16, 1)
/****** Object:  ForeignKey [FK_Users_Items]    Script Date: 08/17/2016 09:58:22 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Items] FOREIGN KEY([CurrentBackCard])
REFERENCES [dbo].[Items] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Items]
GO
/****** Object:  ForeignKey [FK_Users_Items1]    Script Date: 08/17/2016 09:58:22 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Items1] FOREIGN KEY([CurrentBg])
REFERENCES [dbo].[Items] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Items1]
GO
/****** Object:  ForeignKey [FK_UserData_Users]    Script Date: 08/17/2016 09:58:22 ******/
ALTER TABLE [dbo].[UserData]  WITH CHECK ADD  CONSTRAINT [FK_UserData_Users] FOREIGN KEY([User ID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[UserData] CHECK CONSTRAINT [FK_UserData_Users]
GO
/****** Object:  ForeignKey [FK_ItemPurchase_Items]    Script Date: 08/17/2016 09:58:22 ******/
ALTER TABLE [dbo].[ItemPurchase]  WITH CHECK ADD  CONSTRAINT [FK_ItemPurchase_Items] FOREIGN KEY([Item ID])
REFERENCES [dbo].[Items] ([ID])
GO
ALTER TABLE [dbo].[ItemPurchase] CHECK CONSTRAINT [FK_ItemPurchase_Items]
GO
/****** Object:  ForeignKey [FK_ItemPurchase_Users]    Script Date: 08/17/2016 09:58:22 ******/
ALTER TABLE [dbo].[ItemPurchase]  WITH CHECK ADD  CONSTRAINT [FK_ItemPurchase_Users] FOREIGN KEY([User ID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[ItemPurchase] CHECK CONSTRAINT [FK_ItemPurchase_Users]
GO
/****** Object:  ForeignKey [FK_GamesHistory_Games]    Script Date: 08/17/2016 09:58:22 ******/
ALTER TABLE [dbo].[GamesHistory]  WITH CHECK ADD  CONSTRAINT [FK_GamesHistory_Games] FOREIGN KEY([Game ID])
REFERENCES [dbo].[Games] ([ID])
GO
ALTER TABLE [dbo].[GamesHistory] CHECK CONSTRAINT [FK_GamesHistory_Games]
GO
/****** Object:  ForeignKey [FK_GamesHistory_Roles]    Script Date: 08/17/2016 09:58:22 ******/
ALTER TABLE [dbo].[GamesHistory]  WITH CHECK ADD  CONSTRAINT [FK_GamesHistory_Roles] FOREIGN KEY([Role ID])
REFERENCES [dbo].[Roles] ([ID])
GO
ALTER TABLE [dbo].[GamesHistory] CHECK CONSTRAINT [FK_GamesHistory_Roles]
GO
/****** Object:  ForeignKey [FK_GamesHistory_Users]    Script Date: 08/17/2016 09:58:22 ******/
ALTER TABLE [dbo].[GamesHistory]  WITH CHECK ADD  CONSTRAINT [FK_GamesHistory_Users] FOREIGN KEY([User ID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[GamesHistory] CHECK CONSTRAINT [FK_GamesHistory_Users]
GO
/****** Object:  ForeignKey [FK_CharaterPuchase_Characters]    Script Date: 08/17/2016 09:58:22 ******/
ALTER TABLE [dbo].[CharacterPuchase]  WITH CHECK ADD  CONSTRAINT [FK_CharaterPuchase_Characters] FOREIGN KEY([Char ID])
REFERENCES [dbo].[Characters] ([ID])
GO
ALTER TABLE [dbo].[CharacterPuchase] CHECK CONSTRAINT [FK_CharaterPuchase_Characters]
GO
/****** Object:  ForeignKey [FK_CharaterPuchase_Users]    Script Date: 08/17/2016 09:58:22 ******/
ALTER TABLE [dbo].[CharacterPuchase]  WITH CHECK ADD  CONSTRAINT [FK_CharaterPuchase_Users] FOREIGN KEY([User ID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[CharacterPuchase] CHECK CONSTRAINT [FK_CharaterPuchase_Users]
GO
