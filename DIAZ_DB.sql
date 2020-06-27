CREATE DATABASE DIAZ_DB
GO
USE [DIAZ_DB]
go
USE master
go
DROP DATABASE DIAZ_DB
GO
/****** Object:  Table [dbo].[CATEGORIAS]    Script Date: 15/6/2020 19:23:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIAS](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Eliminado] [int] NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PERSONA](
	IdPersona smallint IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Nombre varchar(50) NOT NULL,
	Apellido varchar(50) NOT NULL,
	Imagen varchar(50),
	DNI bigint NOT NULL,
	FechaNac datetime NOT NULL,
	FechaReg datetime NOT NULL,
	Eliminado int NOT NULL
)
GO
CREATE TABLE [dbo].[DIRECCION](
	IdDireccion smallint IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Calle varchar(50) NOT NULL,
	Numero smallint NOT NULL,
	CP smallint NOT NULL,
	Localidad varchar(50) NOT NULL,
	Provincia varchar(50) NOT NULL
)
GO
CREATE TABLE [dbo].[CONTACTO](
	IdContacto smallint IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Email varchar(50) NOT NULL,
	Telefono smallint NOT NULL
)
go
CREATE TABLE [dbo].[AUTO](
	IdAuto int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Patente varchar(10) NOT NULL,
	Modelo varchar(50) NOT NULL,
	Eliminado int NOT NULL
)
Select * from AUTO
GO
CREATE TABLE [dbo].[Usuario](
	IdUsuario smallint IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Tipo varchar(50) NOT NULL,
	Clave varchar(50) NOT NULL,
	Idauto int NOT NULL foreign key references AUTO(IdAuto),
)
GO

GO
/****** Object:  Table [dbo].[MATERIALES]    Script Date: 15/6/2020 19:23:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MATERIALES](
	[IdMaterial] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](150) NULL,
	[Imagen] [varchar](1000) NULL,
	[IdCategoria] [int] NULL,
	[Cantidad] [int] NULL,
	[Eliminado] [int] NULL,
 CONSTRAINT [PK_ARTICULOS] PRIMARY KEY CLUSTERED 
(
	[IdMaterial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CATEGORIAS] ON 

INSERT [dbo].[CATEGORIAS] ([IdCategoria], [Nombre], [Eliminado]) VALUES (1, N'Componente', 0)
INSERT [dbo].[CATEGORIAS] ([IdCategoria], [Nombre], [Eliminado]) VALUES (2, N'Equipo', 0)
SET IDENTITY_INSERT [dbo].[CATEGORIAS] OFF
SET IDENTITY_INSERT [dbo].[MATERIALES] ON 

INSERT [dbo].[MATERIALES] ([IdMaterial], [Nombre], [Descripcion], [Imagen], [IdCategoria], [Cantidad], [Eliminado]) VALUES (1, N'MIO', N'Control de acceso', N'Image/MIO.jpg', 2, 10, 0)
SET IDENTITY_INSERT [dbo].[MATERIALES] OFF

---INSERTS DE MATERIALES
INSERT into MATERIALES values ('Spider COM', 'cerradura', ' ',1, 20, 0)
INSERT into MATERIALES values ('Retractil','equipo comando retractil',' ', 2, 5, 0)
INSERT into MATERIALES values ('Minicaf','equipo BBVA',' ', 2, 5, 0)
INSERT into MATERIALES values ('Cableado comun','equipo BBVA',' ', 2, 5, 0)

---INSERTS DE CATEGORIAS

---STORE PROCEDURES DE MATERIALES
go
---LISTADO
CREATE PROCEDURE spListarMaterial as
select M.IdMaterial, M.Nombre, M.Descripcion, M.IdCategoria, M.Imagen, M.Cantidad, M.Eliminado, 
C.Nombre as NombreCat, C.IdCategoria as IdCat, C.Eliminado as Eliminado 
From MATERIALES as M 
Inner join CATEGORIAS as C on C.IdCategoria = M.IdCategoria
Where M.Eliminado != 1

go
exec spListarMateriales
select * FROM MATERIALES 
select * FROM CATEGORIAS
go

---ALTA
CREATE PROCEDURE spAgregarMaterial 
	@Nombre varchar(50), 
	@Descripcion varchar(150),
	@Imagen varchar(1000),
	@IdCategoria int, 
	@Cantidad int,
	@Eliminado int 
as
insert into MATERIALES(Nombre, Descripcion, Imagen, IdCategoria, Cantidad, Eliminado) 
Values (@Nombre,@Descripcion,@Imagen,@IdCategoria,@Cantidad,@Eliminado)
go
exec spAgregarMaterial 'Cable 3','santander',' ',1,100,0
select * from MATERIALES
go

---MODIFICACION
CREATE PROCEDURE spModificarMaterial 
	@IdMaterial int,
	@Nombre varchar(50), 
	@Descripcion varchar(150),
	@Imagen varchar(1000),
	@IdCategoria int, 
	@Cantidad int,
	@Eliminado int 
as select * from MATERIALES
Update MATERIALES set Nombre=@Nombre, Descripcion=@Descripcion, Imagen=@Imagen, IdCategoria=@IdCategoria, Cantidad=@Cantidad, Eliminado=@Eliminado where IdMaterial=@IdMaterial
go
exec spModificarMaterial
go

---ELIMINAR
CREATE PROCEDURE spEliminarMaterial
@IdMaterial int
as
Update MATERIALES set Eliminado = 1 where IdMaterial = @IdMaterial
go
exec spEliminarMaterial

go
------STORE PROCEDURES DE CATEGORIAS

---LISTADO
CREATE PROCEDURE spListarCategoria as
select  C.Nombre, C.IdCategoria, C.Eliminado 
From CATEGORIAS as C 
exec spListarCategoria

go

---ALTA
CREATE PROCEDURE spAgregarCategorias 
	@Nombre varchar(50), 		
	@Eliminado int 
as
insert into CATEGORIAS(Nombre, Eliminado) 
Values (@Nombre,@Eliminado)

go

exec spAgregarCategorias'SpiderCOM',0
select * from CATEGORIAS
go

---MODIFICACION
CREATE PROCEDURE spModificarCategoria 
	@IdCategoria int,
	@Nombre varchar(50) 
as 
Update CATEGORIAS set Nombre=@Nombre where IdCategoria=@idCategoria

go

CREATE PROCEDURE spEliminarCategoria
@IdCategoria int
as
Update CATEGORIAS set Eliminado = 1 where IdCategoria = @IdCategoria

go

exec spEliminarCategoria

go 

CREATE PROCEDURE spListarPersona as
select P.IdPersona, P.Nombre, P.Apellido, P.Imagen, P.DNI, P.FechaNac, P.FechaReg, P.Eliminado
From PERSONA as P
Where P.Eliminado != 1

exec spListarPersona

go

CREATE PROCEDURE spAgregarCategorias 
	@Nombre varchar(50), 		
	@Eliminado int 
as
insert into CATEGORIAS(Nombre, Eliminado) 
Values (@Nombre,@Eliminado)

go

exec spAgregarCategorias'SpiderCOM',0
select * from CATEGORIAS
go

---MODIFICACION
CREATE PROCEDURE spModificarCategoria 
	@IdCategoria int,
	@Nombre varchar(50) 
as 
Update CATEGORIAS set Nombre=@Nombre where IdCategoria=@idCategoria

go

CREATE PROCEDURE spEliminarCategoria
@IdCategoria int
as
Update CATEGORIAS set Eliminado = 1 where IdCategoria = @IdCategoria

go

CREATE PROCEDURE spListarAuto as
select A.IdAuto, A.Patente, A.Modelo, A.Eliminado
From AUTO as A
Where A.Eliminado != 1

exec spListarAuto

go

CREATE PROCEDURE spAgregarAuto
	@Patente varchar(50),
	@Modelo varchar(50),
	@Eliminado int 
as
insert into AUTO(Patente, Modelo, Eliminado) 
Values (@Patente,@Modelo,@Eliminado)