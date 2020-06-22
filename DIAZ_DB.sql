USE [DIAZ_DB]
GO
/****** Object:  Table [dbo].[CATEGORIAS]    Script Date: 15/6/2020 19:23:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIAS](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Eliminado] [int] NULL
) ON [PRIMARY]
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
CREATE PROCEDURE spListarMateriales as
select M.IdMaterial, M.Nombre, M.Descripcion, M.IdCategoria, M.Imagen, M.Cantidad, M.Eliminado, 
C.Nombre as NombreCat, C.IdCategoria as IdCat, C.Eliminado as Eliminado 
From MATERIALES as M 
Inner join CATEGORIAS as C on C.IdCategoria = M.IdCategoria
go
exec spListarMateriales
select * FROM MATERIALES 
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