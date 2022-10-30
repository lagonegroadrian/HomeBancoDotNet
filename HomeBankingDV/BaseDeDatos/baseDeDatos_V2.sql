﻿USE [master]
GO
/****** Object:  Database [BancoDB]    Script Date: 30/10/2022 08:27:41 ******/
CREATE DATABASE [BancoDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BancoDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLSERVERLOCAL\MSSQL\DATA\BancoDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BancoDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLSERVERLOCAL\MSSQL\DATA\BancoDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BancoDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BancoDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BancoDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BancoDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BancoDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BancoDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BancoDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BancoDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BancoDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BancoDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BancoDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BancoDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BancoDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BancoDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BancoDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BancoDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BancoDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BancoDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BancoDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BancoDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BancoDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BancoDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BancoDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BancoDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BancoDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BancoDB] SET  MULTI_USER 
GO
ALTER DATABASE [BancoDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BancoDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BancoDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BancoDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BancoDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BancoDB', N'ON'
GO
ALTER DATABASE [BancoDB] SET QUERY_STORE = OFF
GO
USE [BancoDB]
GO
/****** Object:  Table [dbo].[cajaAhorro]    Script Date: 30/10/2022 08:27:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cajaAhorro](
	[idCajaDeAhorro] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NULL,
	[idMovimiento] [int] NULL,
	[cbu] [int] NULL,
	[saldo] [float] NULL,
 CONSTRAINT [PK_cajaAhorro] PRIMARY KEY CLUSTERED 
(
	[idCajaDeAhorro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cajaAhorro_v2]    Script Date: 30/10/2022 08:27:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cajaAhorro_v2](
	[idCajaDeAhorro] [int] IDENTITY(1,1) NOT NULL,
	[cbuCajaDeAhorro] [int] NULL,
	[saldoCajaDeAhorro] [float] NULL,
 CONSTRAINT [PK_cajaAhorro_v2] PRIMARY KEY CLUSTERED 
(
	[idCajaDeAhorro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Domicilio]    Script Date: 30/10/2022 08:27:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Domicilio](
	[idDomicilio] [int] IDENTITY(1,1) NOT NULL,
	[calle] [varchar](50) NULL,
	[altura] [int] NULL,
	[ciudad] [varchar](50) NULL,
	[provincia] [varchar](50) NULL,
	[userId] [int] NULL,
 CONSTRAINT [PK_Domicilio] PRIMARY KEY CLUSTERED 
(
	[idDomicilio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[movimiento]    Script Date: 30/10/2022 08:27:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movimiento](
	[idMovimiento] [int] IDENTITY(1,1) NOT NULL,
	[monto] [float] NULL,
	[idCajaDeAhorro] [int] NULL,
	[detalle] [varchar](50) NULL,
	[fecha] [date] NULL,
 CONSTRAINT [PK_movimiento] PRIMARY KEY CLUSTERED 
(
	[idMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pago]    Script Date: 30/10/2022 08:27:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pago](
	[idPago] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NULL,
	[nombre] [varchar](50) NULL,
	[monto] [float] NULL,
	[pagado] [bit] NULL,
	[metodo] [varchar](50) NULL,
 CONSTRAINT [PK_Pago] PRIMARY KEY CLUSTERED 
(
	[idPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlazoFijo]    Script Date: 30/10/2022 08:27:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlazoFijo](
	[idPlazoFijo] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NULL,
	[monto] [float] NULL,
	[fechaIni] [date] NULL,
	[fechaFin] [date] NULL,
	[tasa] [float] NULL,
	[pagado] [bit] NULL,
 CONSTRAINT [PK_PlazoFijo] PRIMARY KEY CLUSTERED 
(
	[idPlazoFijo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TarjetaDeCredito]    Script Date: 30/10/2022 08:27:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TarjetaDeCredito](
	[idTarjetaDeCredito] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NULL,
	[numero] [int] NULL,
	[codigV] [int] NULL,
	[limite] [float] NULL,
	[consumos] [float] NULL,
 CONSTRAINT [PK_TarjetaDeCredito] PRIMARY KEY CLUSTERED 
(
	[idTarjetaDeCredito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[titular_CA]    Script Date: 30/10/2022 08:27:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[titular_CA](
	[idTitular] [int] NULL,
	[idCA] [int] NULL,
	[idUser] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[titulares_v2]    Script Date: 30/10/2022 08:27:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[titulares_v2](
	[idtitular] [int] IDENTITY(1,1) NOT NULL,
	[idCAtitular] [int] NULL,
	[idUstitular] [int] NULL,
 CONSTRAINT [PK_titulares_v2] PRIMARY KEY CLUSTERED 
(
	[idtitular] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 30/10/2022 08:27:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[userDni] [int] NOT NULL,
	[userNombre] [varchar](50) NULL,
	[userApellido] [varchar](50) NULL,
	[userMail] [varchar](50) NULL,
	[userPassword] [varchar](50) NULL,
	[userIsAdmin] [bit] NULL,
	[userBloqueado] [bit] NULL,
	[idCajaAhorro] [int] NULL,
	[idPlazoFijo] [int] NULL,
	[idTarjetaDeCredito] [int] NULL,
	[idPago] [int] NULL,
	[idDomicilio] [int] NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[cajaAhorro]  WITH CHECK ADD  CONSTRAINT [FK_cajaAhorro_usuario] FOREIGN KEY([userId])
REFERENCES [dbo].[usuario] ([userId])
GO
ALTER TABLE [dbo].[cajaAhorro] CHECK CONSTRAINT [FK_cajaAhorro_usuario]
GO
ALTER TABLE [dbo].[Domicilio]  WITH CHECK ADD  CONSTRAINT [FK_Domicilio_usuario] FOREIGN KEY([userId])
REFERENCES [dbo].[usuario] ([userId])
GO
ALTER TABLE [dbo].[Domicilio] CHECK CONSTRAINT [FK_Domicilio_usuario]
GO
ALTER TABLE [dbo].[movimiento]  WITH CHECK ADD  CONSTRAINT [FK_movimiento_cajaAhorro] FOREIGN KEY([idCajaDeAhorro])
REFERENCES [dbo].[cajaAhorro] ([idCajaDeAhorro])
GO
ALTER TABLE [dbo].[movimiento] CHECK CONSTRAINT [FK_movimiento_cajaAhorro]
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_usuario1] FOREIGN KEY([userId])
REFERENCES [dbo].[usuario] ([userId])
GO
ALTER TABLE [dbo].[Pago] CHECK CONSTRAINT [FK_Pago_usuario1]
GO
ALTER TABLE [dbo].[PlazoFijo]  WITH CHECK ADD  CONSTRAINT [FK_PlazoFijo_usuario] FOREIGN KEY([userId])
REFERENCES [dbo].[usuario] ([userId])
GO
ALTER TABLE [dbo].[PlazoFijo] CHECK CONSTRAINT [FK_PlazoFijo_usuario]
GO
ALTER TABLE [dbo].[TarjetaDeCredito]  WITH CHECK ADD  CONSTRAINT [FK_TarjetaDeCredito_usuario] FOREIGN KEY([userId])
REFERENCES [dbo].[usuario] ([userId])
GO
ALTER TABLE [dbo].[TarjetaDeCredito] CHECK CONSTRAINT [FK_TarjetaDeCredito_usuario]
GO
ALTER TABLE [dbo].[titular_CA]  WITH CHECK ADD  CONSTRAINT [FK_titularCA_CajaAhorro] FOREIGN KEY([idCA])
REFERENCES [dbo].[cajaAhorro_v2] ([idCajaDeAhorro])
GO
ALTER TABLE [dbo].[titular_CA] CHECK CONSTRAINT [FK_titularCA_CajaAhorro]
GO
ALTER TABLE [dbo].[titular_CA]  WITH CHECK ADD  CONSTRAINT [FK_titularCA_usuario] FOREIGN KEY([idTitular])
REFERENCES [dbo].[usuario] ([userId])
GO
ALTER TABLE [dbo].[titular_CA] CHECK CONSTRAINT [FK_titularCA_usuario]
GO
ALTER TABLE [dbo].[titulares_v2]  WITH CHECK ADD  CONSTRAINT [FK_titulares_CA] FOREIGN KEY([idCAtitular])
REFERENCES [dbo].[cajaAhorro_v2] ([idCajaDeAhorro])
GO
ALTER TABLE [dbo].[titulares_v2] CHECK CONSTRAINT [FK_titulares_CA]
GO
ALTER TABLE [dbo].[titulares_v2]  WITH CHECK ADD  CONSTRAINT [FK_titulares_usuario] FOREIGN KEY([idUstitular])
REFERENCES [dbo].[usuario] ([userId])
GO
ALTER TABLE [dbo].[titulares_v2] CHECK CONSTRAINT [FK_titulares_usuario]
GO
USE [master]
GO
ALTER DATABASE [BancoDB] SET  READ_WRITE 
GO
