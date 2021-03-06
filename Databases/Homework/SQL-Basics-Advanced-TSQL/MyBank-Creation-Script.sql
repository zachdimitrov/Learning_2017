USE [master]
GO
/****** Object:  Database [MyBank]    Script Date: 2017-05-30 8:15:43 PM ******/
CREATE DATABASE [MyBank]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyBank', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\MyBank.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyBank_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\MyBank_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MyBank] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyBank].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyBank] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyBank] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyBank] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyBank] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyBank] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyBank] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MyBank] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyBank] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyBank] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyBank] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyBank] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyBank] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyBank] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyBank] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyBank] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MyBank] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyBank] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyBank] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyBank] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyBank] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyBank] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyBank] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyBank] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MyBank] SET  MULTI_USER 
GO
ALTER DATABASE [MyBank] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyBank] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyBank] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyBank] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyBank] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyBank] SET QUERY_STORE = OFF
GO
USE [MyBank]
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
USE [MyBank]
GO
/****** Object:  UserDefinedFunction [dbo].[ufn_CalcInterest]    Script Date: 2017-05-30 8:15:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ufn_CalcInterest](@sum money = 100, @yearInterest numeric(4) = 5.0000, @months int = 1)
	RETURNS money
AS
BEGIN
	IF (@sum <= 0 OR @months <= 0 OR @yearInterest < 0) RETURN @sum
	ELSE RETURN @sum + @sum*(@yearInterest / 1200)*@months
	RETURN @sum
END
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 2017-05-30 8:15:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NULL,
	[Balance] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 2017-05-30 8:15:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[SSN] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([Id], [PersonID], [Balance]) VALUES (1, 1, 345.7800)
INSERT [dbo].[Accounts] ([Id], [PersonID], [Balance]) VALUES (2, 2, 2000.0000)
INSERT [dbo].[Accounts] ([Id], [PersonID], [Balance]) VALUES (3, 2, 1000000.0000)
INSERT [dbo].[Accounts] ([Id], [PersonID], [Balance]) VALUES (4, 3, 123.5600)
INSERT [dbo].[Accounts] ([Id], [PersonID], [Balance]) VALUES (5, 4, 3443.0000)
INSERT [dbo].[Accounts] ([Id], [PersonID], [Balance]) VALUES (6, 5, 20000.0000)
INSERT [dbo].[Accounts] ([Id], [PersonID], [Balance]) VALUES (7, 5, 2322.3400)
INSERT [dbo].[Accounts] ([Id], [PersonID], [Balance]) VALUES (8, 6, 44.9000)
INSERT [dbo].[Accounts] ([Id], [PersonID], [Balance]) VALUES (9, 6, 0.0000)
INSERT [dbo].[Accounts] ([Id], [PersonID], [Balance]) VALUES (10, 6, 34500.0000)
INSERT [dbo].[Accounts] ([Id], [PersonID], [Balance]) VALUES (11, 7, 1.5000)
INSERT [dbo].[Accounts] ([Id], [PersonID], [Balance]) VALUES (12, 8, 12.0000)
INSERT [dbo].[Accounts] ([Id], [PersonID], [Balance]) VALUES (13, 8, 230.5000)
INSERT [dbo].[Accounts] ([Id], [PersonID], [Balance]) VALUES (14, 8, 333.3300)
INSERT [dbo].[Accounts] ([Id], [PersonID], [Balance]) VALUES (15, 8, 300000.0000)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (1, N'Ivan', N'Ivanov', N'8512319594')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (2, N'Petar', N'Georgiev', N'7602243345')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (3, N'Georgi', N'Stoyanov', N'4504234566')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (4, N'Martin', N'Kulov', N'8103032330')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (5, N'George', N'Denchev', N'6511234455')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (6, N'Jose', N'Saraiva', N'8709115698')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (7, N'John', N'Smith', N'9107124575')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (8, N'Guy', N'Gilberts', N'3901234566')
SET IDENTITY_INSERT [dbo].[Persons] OFF
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[usp_HaveMoreThan]    Script Date: 2017-05-30 8:15:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_HaveMoreThan] 
	@amount money
AS 
 SELECT p.FirstName, p.LastName, a.Balance
 FROM Persons p JOIN Accounts a ON p.Id = a.PersonID 
 WHERE Balance > @amount
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectFullNames]    Script Date: 2017-05-30 8:15:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_SelectFullNames] 
	@tableName nvarchar(50)
AS
	DECLARE @query varchar(100) = 'SELECT FirstName + '' '' + LastName AS [Full Name] FROM ' + @tableName
	EXEC(@query)
GO
USE [master]
GO
ALTER DATABASE [MyBank] SET  READ_WRITE 
GO
