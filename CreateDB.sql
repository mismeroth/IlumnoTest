USE [master]
GO
/*
	CREACION DE BD
	*CAMBIAR LAS RUTAS PARA LOS ARCHIVOS DE DATOS Y LOGS ANTES DE EJECUTAR ESTE SCRIPT
*/

IF EXISTS(SELECT * FROM master.sys.sysdatabases WHERE NAME='Directorio_1')
BEGIN
	DROP DATABASE Directorio_1
END	

CREATE DATABASE [Directorio_1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Directorio', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Directorio_1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Directorio_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Directorio_log_1.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

USE [Directorio_1]
GO

/****** Object:  Table [dbo].[Personas]    Script Date: 12/08/2018 10:12:28 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Personas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](100) NOT NULL,
	[Apellidos] [nvarchar](100) NOT NULL,
	[CorreoE] [nvarchar](50) NOT NULL,
	[TelefonoFijo] [nvarchar](20) NOT NULL,
	[TelefonoMovil] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

