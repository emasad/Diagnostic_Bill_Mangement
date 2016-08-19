USE [master]
GO
/****** Object:  Database [DiagnosticDB]    Script Date: 8/19/2016 8:50:33 AM ******/
CREATE DATABASE [DiagnosticDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DiagnosticDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DiagnosticDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DiagnosticDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DiagnosticDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DiagnosticDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DiagnosticDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DiagnosticDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DiagnosticDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DiagnosticDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DiagnosticDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DiagnosticDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DiagnosticDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DiagnosticDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DiagnosticDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DiagnosticDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DiagnosticDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DiagnosticDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DiagnosticDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DiagnosticDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DiagnosticDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DiagnosticDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DiagnosticDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DiagnosticDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DiagnosticDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DiagnosticDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DiagnosticDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DiagnosticDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DiagnosticDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DiagnosticDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DiagnosticDB] SET RECOVERY FULL 
GO
ALTER DATABASE [DiagnosticDB] SET  MULTI_USER 
GO
ALTER DATABASE [DiagnosticDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DiagnosticDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DiagnosticDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DiagnosticDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DiagnosticDB', N'ON'
GO
USE [DiagnosticDB]
GO
/****** Object:  Table [dbo].[t_billdetail]    Script Date: 8/19/2016 8:50:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_billdetail](
	[Id] [int] NOT NULL,
	[BillNumber] [int] NOT NULL,
	[Date] [datetime] NULL,
	[PaidBill] [numeric](18, 3) NULL,
	[TotalBill] [numeric](18, 3) NULL,
 CONSTRAINT [PK_t_billdetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_requestsetup]    Script Date: 8/19/2016 8:50:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_requestsetup](
	[TestRequestId] [int] NOT NULL,
	[TestSetupId] [int] NOT NULL,
 CONSTRAINT [PK_t_requestsetup] PRIMARY KEY CLUSTERED 
(
	[TestRequestId] ASC,
	[TestSetupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_testrequest]    Script Date: 8/19/2016 8:50:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_testrequest](
	[Id] [int] NOT NULL,
	[PatientName] [varchar](50) NULL,
	[MobileNo] [varchar](50) NULL,
	[SelectTestId] [int] NULL,
	[BillId] [int] NULL,
 CONSTRAINT [PK_t_testrequest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_testsetup]    Script Date: 8/19/2016 8:50:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_testsetup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TestName] [varchar](50) NULL,
	[Fee] [numeric](18, 3) NULL,
	[TestTypeId] [int] NULL,
 CONSTRAINT [PK_t_testsetup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_typename]    Script Date: 8/19/2016 8:50:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_typename](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_t_typename] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Index [IX_t_billdetail]    Script Date: 8/19/2016 8:50:34 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_t_billdetail] ON [dbo].[t_billdetail]
(
	[BillNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_t_testsetup]    Script Date: 8/19/2016 8:50:34 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_t_testsetup] ON [dbo].[t_testsetup]
(
	[TestName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_t_typename]    Script Date: 8/19/2016 8:50:34 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_t_typename] ON [dbo].[t_typename]
(
	[TypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[t_requestsetup]  WITH CHECK ADD  CONSTRAINT [FK_t_requestsetup_t_testrequest] FOREIGN KEY([TestRequestId])
REFERENCES [dbo].[t_testrequest] ([Id])
GO
ALTER TABLE [dbo].[t_requestsetup] CHECK CONSTRAINT [FK_t_requestsetup_t_testrequest]
GO
ALTER TABLE [dbo].[t_requestsetup]  WITH CHECK ADD  CONSTRAINT [FK_t_requestsetup_t_testsetup] FOREIGN KEY([TestSetupId])
REFERENCES [dbo].[t_testsetup] ([Id])
GO
ALTER TABLE [dbo].[t_requestsetup] CHECK CONSTRAINT [FK_t_requestsetup_t_testsetup]
GO
ALTER TABLE [dbo].[t_testrequest]  WITH CHECK ADD  CONSTRAINT [FK_t_testrequest_t_billdetail] FOREIGN KEY([BillId])
REFERENCES [dbo].[t_billdetail] ([Id])
GO
ALTER TABLE [dbo].[t_testrequest] CHECK CONSTRAINT [FK_t_testrequest_t_billdetail]
GO
ALTER TABLE [dbo].[t_testsetup]  WITH CHECK ADD  CONSTRAINT [FK_t_testsetup_t_typename] FOREIGN KEY([TestTypeId])
REFERENCES [dbo].[t_typename] ([Id])
GO
ALTER TABLE [dbo].[t_testsetup] CHECK CONSTRAINT [FK_t_testsetup_t_typename]
GO
USE [master]
GO
ALTER DATABASE [DiagnosticDB] SET  READ_WRITE 
GO
