USE [master]
GO
/****** Object:  Database [DiagnosticDB]    Script Date: 8/20/2016 9:35:00 AM ******/
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
/****** Object:  Table [dbo].[t_requestsetup]    Script Date: 8/20/2016 9:35:00 AM ******/
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
/****** Object:  Table [dbo].[t_testrequest]    Script Date: 8/20/2016 9:35:00 AM ******/
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
	[BillNumber] [int] NULL,
	[Date] [datetime] NULL,
	[PaidBill] [numeric](18, 3) NULL,
	[DateOfBirth] [date] NULL,
 CONSTRAINT [PK_t_testrequest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_testsetup]    Script Date: 8/20/2016 9:35:00 AM ******/
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
/****** Object:  Table [dbo].[t_typename]    Script Date: 8/20/2016 9:35:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_typename](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](50) NULL,
 CONSTRAINT [PK_t_typename] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[ViewTestSetupWithTypeName]    Script Date: 8/20/2016 9:35:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewTestSetupWithTypeName]
AS
SELECT        dbo.t_testsetup.TestName, dbo.t_testsetup.Fee, dbo.t_typename.TypeName
FROM            dbo.t_testsetup INNER JOIN
                         dbo.t_typename ON dbo.t_testsetup.TestTypeId = dbo.t_typename.Id

GO
/****** Object:  Index [IX_t_testrequest]    Script Date: 8/20/2016 9:35:01 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_t_testrequest] ON [dbo].[t_testrequest]
(
	[BillNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_t_testsetup]    Script Date: 8/20/2016 9:35:01 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_t_testsetup] ON [dbo].[t_testsetup]
(
	[TestName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_t_typename]    Script Date: 8/20/2016 9:35:01 AM ******/
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
ALTER TABLE [dbo].[t_testsetup]  WITH CHECK ADD  CONSTRAINT [FK_t_testsetup_t_typename] FOREIGN KEY([TestTypeId])
REFERENCES [dbo].[t_typename] ([Id])
GO
ALTER TABLE [dbo].[t_testsetup] CHECK CONSTRAINT [FK_t_testsetup_t_typename]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "t_testsetup"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "t_typename"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 102
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewTestSetupWithTypeName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewTestSetupWithTypeName'
GO
USE [master]
GO
ALTER DATABASE [DiagnosticDB] SET  READ_WRITE 
GO
