USE [master]
GO
/****** Object:  Database [UniPaTask]    Script Date: 29.06.2022 04:42:42 ******/
CREATE DATABASE [UniPaTask]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniPaTask', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\UniPaTask.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniPaTask_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\UniPaTask_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniPaTask] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniPaTask].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniPaTask] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniPaTask] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniPaTask] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniPaTask] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniPaTask] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniPaTask] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniPaTask] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniPaTask] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniPaTask] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniPaTask] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniPaTask] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniPaTask] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniPaTask] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniPaTask] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniPaTask] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniPaTask] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniPaTask] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniPaTask] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniPaTask] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniPaTask] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniPaTask] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniPaTask] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniPaTask] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniPaTask] SET  MULTI_USER 
GO
ALTER DATABASE [UniPaTask] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniPaTask] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniPaTask] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniPaTask] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [UniPaTask] SET DELAYED_DURABILITY = DISABLED 
GO
USE [UniPaTask]
GO
/****** Object:  User [sa]    Script Date: 29.06.2022 04:42:42 ******/
CREATE USER [sa] FOR LOGIN [sa] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 29.06.2022 04:42:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TR_IdentificationNumber] [nvarchar](11) NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[BirthDay] [date] NULL,
	[MotherName] [nvarchar](50) NULL,
	[FatherName] [nvarchar](50) NULL,
	[BirthPlace] [nvarchar](250) NULL,
	[RecidanceCity] [nvarchar](250) NULL,
	[IsApproved] [bit] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Verification]    Script Date: 29.06.2022 04:42:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Verification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TR_IdentificationNumber] [nvarchar](11) NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[BirthDay] [date] NULL,
	[MotherName] [nvarchar](50) NULL,
	[FatherName] [nvarchar](50) NULL,
	[BirthPlace] [nvarchar](250) NULL,
	[RecidanceCity] [nvarchar](250) NULL,
	[IsApproved] [bit] NULL,
	[VerificationDate] [datetime] NULL,
 CONSTRAINT [PK_Verification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[usp_StudentCreate]    Script Date: 29.06.2022 04:42:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_StudentCreate] 
@Id int=NULL,
    @TR_IdentificationNumber char(11) = NULL,
    @Name nvarchar(50) = NULL,
    @Surname nvarchar(50) = NULL,
    @BirthDay date = NULL,
    @MotherName nvarchar(50) = NULL,
    @FatherName nvarchar(50) = NULL,
    @BirthPlace nvarchar(250) = NULL,
    @RecidanceCity nvarchar(250) = NULL,
	@IsApproved bit = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[Student] ([TR_IdentificationNumber], [Name], [Surname], [BirthDay], [MotherName], [FatherName], [BirthPlace], [RecidanceCity], [IsApproved])
	SELECT @TR_IdentificationNumber, @Name, @Surname, @BirthDay, @MotherName, @FatherName, @BirthPlace, @RecidanceCity, @IsApproved

	-- Begin Return Select <- do not remove
	SELECT *
	FROM   [dbo].[Student]
	WHERE  [Id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_StudentDelete]    Script Date: 29.06.2022 04:42:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_StudentDelete] 
    @Id int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[Student]
	WHERE  ([Id] = @Id OR @Id IS NULL) 

	COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_StudentSelect]    Script Date: 29.06.2022 04:42:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_StudentSelect] 
    @Id int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT *
	FROM   [dbo].[Student] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

	COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_StudentUpdate]    Script Date: 29.06.2022 04:42:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_StudentUpdate] 
    @Id int,
    @TR_IdentificationNumber char(11) = NULL,
    @Name nvarchar(50) = NULL,
    @Surname nvarchar(50) = NULL,
    @BirthDay date = NULL,
    @MotherName nvarchar(50) = NULL,
    @FatherName nvarchar(50) = NULL,
    @BirthPlace nvarchar(250) = NULL,
    @RecidanceCity nvarchar(250) = NULL,
	@IsApproved bit = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[Student]
	SET    [TR_IdentificationNumber] = @TR_IdentificationNumber, [Name] = @Name, [Surname] = @Surname, [BirthDay] = @BirthDay, [MotherName] = @MotherName, [FatherName] = @FatherName, [BirthPlace] = @BirthPlace, [RecidanceCity] = @RecidanceCity, [IsApproved] = @IsApproved
	WHERE  [Id] = @Id
	
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   [dbo].[Student]
	WHERE  [Id] = @Id	
	-- End Return Select <- do not remove

	COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_VerificationCreate]    Script Date: 29.06.2022 04:42:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_VerificationCreate] 
@Id int=NULL,
    @TR_IdentificationNumber char(11) = NULL,
    @Name nvarchar(50) = NULL,
    @Surname nvarchar(50) = NULL,
    @BirthDay date = NULL,
    @MotherName nvarchar(50) = NULL,
    @FatherName nvarchar(50) = NULL,
    @BirthPlace nvarchar(250) = NULL,
    @RecidanceCity nvarchar(250) = NULL,
	@IsApproved bit = NULL,
	@VerificationDate datetime = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[Verification] ([TR_IdentificationNumber], [Name], [Surname], [BirthDay], [MotherName], [FatherName], [BirthPlace], [RecidanceCity], [IsApproved], [VerificationDate])
	SELECT @TR_IdentificationNumber, @Name, @Surname, @BirthDay, @MotherName, @FatherName, @BirthPlace, @RecidanceCity, @IsApproved, @VerificationDate

	-- Begin Return Select <- do not remove
	SELECT *
	FROM   [dbo].[Verification]
	WHERE  [Id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_VerificationDelete]    Script Date: 29.06.2022 04:42:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_VerificationDelete] 
    @Id int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[Verification]
	WHERE  ([Id] = @Id OR @Id IS NULL) 

	COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_VerificationSelect]    Script Date: 29.06.2022 04:42:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_VerificationSelect] 
    @Id int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT *
	FROM   [dbo].[Verification] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

	COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_VerificationUpdate]    Script Date: 29.06.2022 04:42:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_VerificationUpdate] 
    @Id int,
    @TR_IdentificationNumber char(11) = NULL,
    @Name nvarchar(50) = NULL,
    @Surname nvarchar(50) = NULL,
    @BirthDay date = NULL,
    @MotherName nvarchar(50) = NULL,
    @FatherName nvarchar(50) = NULL,
    @BirthPlace nvarchar(250) = NULL,
    @RecidanceCity nvarchar(250) = NULL,
	@IsApproved bit = NULL,
	@VerificationDate datetime = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[Verification]
	SET    [TR_IdentificationNumber] = @TR_IdentificationNumber, [Name] = @Name, [Surname] = @Surname, [BirthDay] = @BirthDay, [MotherName] = @MotherName, [FatherName] = @FatherName, [BirthPlace] = @BirthPlace, [RecidanceCity] = @RecidanceCity, [IsApproved] = @IsApproved, [VerificationDate] = @VerificationDate
	WHERE  [Id] = @Id
	
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   [dbo].[Verification]
	WHERE  [Id] = @Id	
	-- End Return Select <- do not remove

	COMMIT

GO
USE [master]
GO
ALTER DATABASE [UniPaTask] SET  READ_WRITE 
GO
