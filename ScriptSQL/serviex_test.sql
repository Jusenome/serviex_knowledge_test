USE [master]
GO
/****** Object:  Database [Serviex_test]    Script Date: 14/12/2022 9:59:13 p. m. ******/
CREATE DATABASE [Serviex_test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Serviex_test', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Serviex_test.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Serviex_test_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Serviex_test_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Serviex_test] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Serviex_test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Serviex_test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Serviex_test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Serviex_test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Serviex_test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Serviex_test] SET ARITHABORT OFF 
GO
ALTER DATABASE [Serviex_test] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Serviex_test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Serviex_test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Serviex_test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Serviex_test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Serviex_test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Serviex_test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Serviex_test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Serviex_test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Serviex_test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Serviex_test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Serviex_test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Serviex_test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Serviex_test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Serviex_test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Serviex_test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Serviex_test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Serviex_test] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Serviex_test] SET  MULTI_USER 
GO
ALTER DATABASE [Serviex_test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Serviex_test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Serviex_test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Serviex_test] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Serviex_test] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Serviex_test] SET QUERY_STORE = OFF
GO
USE [Serviex_test]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Serviex_test]
GO
/****** Object:  Table [dbo].[User_test]    Script Date: 14/12/2022 9:59:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_test](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL,
	[date_of_birth] [datetime] NULL,
	[gender] [char](1) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_user_create]    Script Date: 14/12/2022 9:59:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_user_create]
(
	@name varchar(100),
	@date_of_birth datetime,
	@gender char(1),
	@id int output
)
as
begin
INSERT INTO [dbo].[User_test]
           ([name]
           ,[date_of_birth]
           ,[gender])
     VALUES
           (@name, @date_of_birth, @gender)

	 set @id = SCOPE_IDENTITY()
	 return @id
end
GO
/****** Object:  StoredProcedure [dbo].[sp_user_delete]    Script Date: 14/12/2022 9:59:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[sp_user_delete]
(
	@id int
)
as
begin
	 delete [dbo].[User_test]
     where id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[sp_user_getuser]    Script Date: 14/12/2022 9:59:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_user_getuser]
(
	@id int
)
as
begin
SELECT id
      ,name
      ,date_of_birth
      ,gender
  FROM dbo.User_test
  where id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[sp_user_list]    Script Date: 14/12/2022 9:59:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_user_list]
as
begin
SELECT [id]
      ,[name]
      ,[date_of_birth]
      ,[gender]
  FROM [dbo].[User_test]
end
GO
/****** Object:  StoredProcedure [dbo].[sp_user_update]    Script Date: 14/12/2022 9:59:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[sp_user_update]
(
	@id int,
	@name varchar(100),
	@date_of_birth datetime,
	@gender char(1)
)
as
begin
update [dbo].[User_test]
           set name = @name
           ,date_of_birth = @date_of_birth
           ,gender = @gender
     where id = @id
end
GO
USE [master]
GO
ALTER DATABASE [Serviex_test] SET  READ_WRITE 
GO
