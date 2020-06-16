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
