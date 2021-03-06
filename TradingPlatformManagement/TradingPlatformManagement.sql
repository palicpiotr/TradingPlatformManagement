USE [master]
GO
/****** Object:  Database [TradingPlatformManagement]    Script Date: 13.06.2018 0:16:46 ******/
CREATE DATABASE [TradingPlatformManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TradingPlatformManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\TradingPlatformManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TradingPlatformManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\TradingPlatformManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TradingPlatformManagement] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TradingPlatformManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TradingPlatformManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TradingPlatformManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TradingPlatformManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TradingPlatformManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TradingPlatformManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [TradingPlatformManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TradingPlatformManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TradingPlatformManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TradingPlatformManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TradingPlatformManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TradingPlatformManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TradingPlatformManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TradingPlatformManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TradingPlatformManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TradingPlatformManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TradingPlatformManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TradingPlatformManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TradingPlatformManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TradingPlatformManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TradingPlatformManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TradingPlatformManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TradingPlatformManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TradingPlatformManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TradingPlatformManagement] SET  MULTI_USER 
GO
ALTER DATABASE [TradingPlatformManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TradingPlatformManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TradingPlatformManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TradingPlatformManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TradingPlatformManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TradingPlatformManagement] SET QUERY_STORE = OFF
GO
USE [TradingPlatformManagement]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [TradingPlatformManagement]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 13.06.2018 0:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Biddings]    Script Date: 13.06.2018 0:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Biddings](
	[BiddingId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[LotId] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
	[DocumentationId] [int] NULL,
	[BiddingTypeId] [int] NOT NULL,
	[TenderTypeId] [int] NOT NULL,
	[ProtocolId] [int] NULL,
	[CountryId] [int] NULL,
 CONSTRAINT [PK_Biddings] PRIMARY KEY CLUSTERED 
(
	[BiddingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BiddingTypes]    Script Date: 13.06.2018 0:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BiddingTypes](
	[BiddingTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_BiddingTypes] PRIMARY KEY CLUSTERED 
(
	[BiddingTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 13.06.2018 0:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[FoundationDate] [datetime] NULL,
	[INN] [int] NULL,
	[KPP] [int] NULL,
	[OGRN] [int] NULL,
	[AkkreditationDate] [datetime] NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 13.06.2018 0:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ISO] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerBiddings]    Script Date: 13.06.2018 0:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerBiddings](
	[CustomerBiddingsId] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NULL,
	[BiddingId] [int] NULL,
 CONSTRAINT [PK_CustomerBiddings] PRIMARY KEY CLUSTERED 
(
	[CustomerBiddingsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documents]    Script Date: 13.06.2018 0:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documents](
	[DocumentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[URL] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED 
(
	[DocumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lots]    Script Date: 13.06.2018 0:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lots](
	[LotId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Status] [int] NOT NULL,
	[DateOfEndRegistration] [datetime] NULL,
	[DateOfStartRegistration] [datetime] NULL,
	[DateOfPub] [datetime] NULL,
	[DateOfSummarizing] [datetime] NULL,
	[DateOfBidding] [datetime] NULL,
	[DeliveryAddress] [varchar](100) NULL,
 CONSTRAINT [PK_Lots] PRIMARY KEY CLUSTERED 
(
	[LotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 13.06.2018 0:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[SurnamName] [nvarchar](100) NOT NULL,
	[Patron] [nvarchar](100) NULL,
	[PersonTypeId] [int] NOT NULL,
	[CompanyId] [int] NULL,
	[CountryId] [int] NULL,
	[UserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonTypes]    Script Date: 13.06.2018 0:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonTypes](
	[PersonTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_PersonTypes] PRIMARY KEY CLUSTERED 
(
	[PersonTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Protocols]    Script Date: 13.06.2018 0:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Protocols](
	[ProtocolId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](300) NULL,
	[Description] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Protocols] PRIMARY KEY CLUSTERED 
(
	[ProtocolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProviderBiddings]    Script Date: 13.06.2018 0:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProviderBiddings](
	[ProviderBiddingsId] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NULL,
	[BiddingId] [int] NULL,
 CONSTRAINT [PK_ProviderBiddings] PRIMARY KEY CLUSTERED 
(
	[ProviderBiddingsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TenderTypes]    Script Date: 13.06.2018 0:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TenderTypes](
	[TenderTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_TenderTypes] PRIMARY KEY CLUSTERED 
(
	[TenderTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Biddings]  WITH CHECK ADD  CONSTRAINT [FK_Biddings_BiddingTypes] FOREIGN KEY([BiddingTypeId])
REFERENCES [dbo].[BiddingTypes] ([BiddingTypeId])
GO
ALTER TABLE [dbo].[Biddings] CHECK CONSTRAINT [FK_Biddings_BiddingTypes]
GO
ALTER TABLE [dbo].[Biddings]  WITH CHECK ADD  CONSTRAINT [FK_Biddings_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryId])
GO
ALTER TABLE [dbo].[Biddings] CHECK CONSTRAINT [FK_Biddings_Countries]
GO
ALTER TABLE [dbo].[Biddings]  WITH CHECK ADD  CONSTRAINT [FK_Biddings_Documents] FOREIGN KEY([DocumentationId])
REFERENCES [dbo].[Documents] ([DocumentId])
GO
ALTER TABLE [dbo].[Biddings] CHECK CONSTRAINT [FK_Biddings_Documents]
GO
ALTER TABLE [dbo].[Biddings]  WITH CHECK ADD  CONSTRAINT [FK_Biddings_Lots] FOREIGN KEY([LotId])
REFERENCES [dbo].[Lots] ([LotId])
GO
ALTER TABLE [dbo].[Biddings] CHECK CONSTRAINT [FK_Biddings_Lots]
GO
ALTER TABLE [dbo].[Biddings]  WITH CHECK ADD  CONSTRAINT [FK_Biddings_Persons] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Persons] ([PersonId])
GO
ALTER TABLE [dbo].[Biddings] CHECK CONSTRAINT [FK_Biddings_Persons]
GO
ALTER TABLE [dbo].[Biddings]  WITH CHECK ADD  CONSTRAINT [FK_Biddings_Protocols] FOREIGN KEY([ProtocolId])
REFERENCES [dbo].[Protocols] ([ProtocolId])
GO
ALTER TABLE [dbo].[Biddings] CHECK CONSTRAINT [FK_Biddings_Protocols]
GO
ALTER TABLE [dbo].[Biddings]  WITH CHECK ADD  CONSTRAINT [FK_Biddings_TenderTypes] FOREIGN KEY([TenderTypeId])
REFERENCES [dbo].[TenderTypes] ([TenderTypeId])
GO
ALTER TABLE [dbo].[Biddings] CHECK CONSTRAINT [FK_Biddings_TenderTypes]
GO
ALTER TABLE [dbo].[CustomerBiddings]  WITH CHECK ADD  CONSTRAINT [FK_CustomerBiddings_Biddings] FOREIGN KEY([BiddingId])
REFERENCES [dbo].[Biddings] ([BiddingId])
GO
ALTER TABLE [dbo].[CustomerBiddings] CHECK CONSTRAINT [FK_CustomerBiddings_Biddings]
GO
ALTER TABLE [dbo].[CustomerBiddings]  WITH CHECK ADD  CONSTRAINT [FK_CustomerBiddings_Persons] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Persons] ([PersonId])
GO
ALTER TABLE [dbo].[CustomerBiddings] CHECK CONSTRAINT [FK_CustomerBiddings_Persons]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Companies] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([CompanyId])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Companies]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryId])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Countries]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_PersonTypes] FOREIGN KEY([PersonTypeId])
REFERENCES [dbo].[PersonTypes] ([PersonTypeId])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_PersonTypes]
GO
ALTER TABLE [dbo].[ProviderBiddings]  WITH CHECK ADD  CONSTRAINT [FK_ProviderBiddings_Biddings] FOREIGN KEY([BiddingId])
REFERENCES [dbo].[Biddings] ([BiddingId])
GO
ALTER TABLE [dbo].[ProviderBiddings] CHECK CONSTRAINT [FK_ProviderBiddings_Biddings]
GO
ALTER TABLE [dbo].[ProviderBiddings]  WITH CHECK ADD  CONSTRAINT [FK_ProviderBiddings_Persons] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Persons] ([PersonId])
GO
ALTER TABLE [dbo].[ProviderBiddings] CHECK CONSTRAINT [FK_ProviderBiddings_Persons]
GO
USE [master]
GO
ALTER DATABASE [TradingPlatformManagement] SET  READ_WRITE 
GO
