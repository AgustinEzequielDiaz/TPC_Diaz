CREATE DATABASE DIAZ_DB
GO
USE [DIAZ_DB]
go
USE master
go
DROP DATABASE DIAZ_DB
GO

--//////////////////////////////////////////TABLAS////////////////////////////////////////////////////////

CREATE TABLE CATEGORIAS(
	IdCategoria int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Nombre varchar(50) NULL,
	Eliminado int NOT NULL
) 
GO
CREATE TABLE MATERIALES(
	IdMaterial int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	IdCategoria int FOREIGN KEY REFERENCES CATEGORIAS(IdCategoria),
	Nombre varchar(50) NULL,
	Descripcion varchar(150) NULL,
	Imagen varchar(1000) NULL,
	Cantidad int NULL,
	Eliminado int NULL,
)
GO

CREATE TABLE DIRECCION(
	IdDireccion int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Calle varchar(50) NOT NULL,
	Numero int NOT NULL,
	CP int NOT NULL,
	Localidad varchar(50) NOT NULL,
	Provincia varchar(50) NOT NULL
)
GO
CREATE TABLE CONTACTO(
	IdContacto int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Email varchar(50) NOT NULL,
	Telefono bigint NOT NULL
)

go
CREATE TABLE VEHICULO(
	IdAuto int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Patente varchar(10) NOT NULL,
	Modelo varchar(50) NOT NULL,
	Eliminado int NOT NULL
)
GO
CREATE TABLE TIPOUSUARIO(
	IdTipo int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Nombre varchar(50) NOT NULL,
	Eliminado int NOT NULL,
	--Permisos int NOT NULL
)
GO

CREATE TABLE PERSONA(
	IdPersona int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Nombre varchar(50) NOT NULL,
	Apellido varchar(50) NOT NULL,
	Imagen varchar(50),
	DNI bigint NOT NULL,
	IdDireccion int NOT NULL FOREIGN KEY REFERENCES DIRECCION(IdDireccion),
	IdContacto int NOT NULL foreign key references CONTACTO(IdContacto),
	--FechaNac time NOT NULL,
	--FechaReg time NOT NULL,
	Eliminado int NOT NULL
)

GO

CREATE TABLE USUARIO(
	IdUsuario int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	IdPersona int NOT NULL FOREIGN KEY REFERENCES PERSONA(IdPersona),
	IdTipo int NOT NULL FOREIGN KEY REFERENCES TIPOUSUARIO(IdTipo),
	Clave varchar(50) NOT NULL,
	Idauto int NOT NULL foreign key references VEHICULO(IdAuto),
	Eliminado int NOT NULL
)

GO

CREATE TABLE ASIGNACIONXAUTO(
	IdAsignar int IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	IdUsuario int NOT NULL FOREIGN KEY REFERENCES VEHICULO(IdAuto),
	Cantidad int NOT NULL,
	FechaAsignacion DateTime NOT NULL
)

go

CREATE TABLE STOCKAUTO(
	IdAsignar int IDENTITY(1,1) FOREIGN KEY REFERENCES ASIGNACIONXAUTO(IdAsignar) NOT NULL, 
	IdAuto int NOT NULL FOREIGN KEY REFERENCES VEHICULO(IdAuto),
	IdMaterial int NOT NULL FOREIGN KEY REFERENCES MATERIALES(IdMaterial),
	Cantidad int NOT NULL,
	Eliminado int NOT NULL,
	PRIMARY KEY (IdAsignar, IdAuto)
)

GO

--CREATE TABLE STOCKXAUTO(
--	IdStock int NOT NULL FOREIGN KEY REFERENCES STOCK (idStock),
--	IdAuto int NOT NULL FOREIGN KEY REFERENCES VEHICULO (IdAuto)
--	PRIMARY KEY (IdStock, IdAuto)
--)

GO

--CREATE TABLE MATERIALXAUTO(
--	IdMaterial int NOT NULL FOREIGN KEY REFERENCES MATERIALES(IdMaterial),
--	IdAuto int NOT NULL FOREIGN KEY REFERENCES VEHICULO(IdAuto)
--)

--GO


--CREATE TABLE ASIGNACIONXMATERIAL(
--	IdAsignar int NOT NULL FOREIGN KEY REFERENCES ASIGNAR(IdAsignar),
--	IdMaterial int NOT NULL FOREIGN KEY REFERENCES MATERIALES(IdMaterial)
--)

--CREATE TABLE ASIGNACIONXUSUARIO(
--	IdUsuario int NOT NULL FOREIGN KEY REFERENCES USUARIO(IdUsuario),
--	IdAsignar int NOT NULL FOREIGN KEY REFERENCES ASIGNAR(IdAsignar)
--)

GO

--////////////////////////////////////////////////INSERTS////////////////////////////////////////////

---INSERTS DE MATERIALES
INSERT into MATERIALES values ('Spider COM', 'cerradura', ' ',1, 20, 0)
INSERT into MATERIALES values ('Retractil','equipo comando retractil',' ', 2, 5, 0)
INSERT into MATERIALES values ('Minicaf','equipo BBVA',' ', 2, 5, 0)
INSERT into MATERIALES values ('Cableado comun','equipo BBVA',' ', 2, 5, 0)

---INSERTS DE CATEGORIAS
INSERT into CATEGORIAS VALUES (1, N'Componente', 0)
INSERT into CATEGORIAS VALUES (2, N'Equipo', 0)

--///////////////////////////////////////////////////////////////////////////////////////STORE PROCEDURE ABML///////////////////////////////////////////////////////////////////////////////////--
-------------------------------------STORE PROCEDURES DE MATERIALES---------------------------------------------
go
---LISTADO
CREATE PROCEDURE spListarMaterial as
select M.IdMaterial, M.Nombre, M.Descripcion, M.IdCategoria, M.Imagen, M.Cantidad, M.Eliminado, 
C.Nombre as NombreCat, C.IdCategoria as IdCat, C.Eliminado as Eliminado 
From MATERIALES as M 
Inner join CATEGORIAS as C on C.IdCategoria = M.IdCategoria
Where M.Eliminado != 1

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

---ELIMINAR
CREATE PROCEDURE spEliminarMaterial
@IdMaterial int
as
Update MATERIALES set Eliminado = 1 where IdMaterial = @IdMaterial

go
------------------------------------------STORE PROCEDURES DE CATEGORIAS----------------------------------------------------

---LISTADO
CREATE PROCEDURE spListarCategorias as
select C.IdCategoria, C.Nombre, C.Eliminado 
From CATEGORIAS as C 
Where C.Eliminado != 1

go

---ALTA
CREATE PROCEDURE spAgregarCategorias 
	@Nombre varchar(50), 		
	@Eliminado int 
as
insert into CATEGORIAS(Nombre, Eliminado) 
Values (@Nombre,@Eliminado)

go

---MODIFICACION
CREATE PROCEDURE spModificarCategoria 
	@IdCategoria int,
	@Nombre varchar(50) 
as 
Update CATEGORIAS set Nombre=@Nombre where IdCategoria=@idCategoria

go

--ELIMINAR
CREATE PROCEDURE spEliminarCategoria
@IdCategoria int
as
Update CATEGORIAS set Eliminado = 1 where IdCategoria = @IdCategoria

go

----------------------------------------STORE PROCEDURES DE PERSONA----------------------------------------------------

CREATE PROCEDURE spListarPersona as
select P.IdPersona, P.Nombre, P.Apellido, P.Imagen, P.DNI,
D.Calle as CalleDireccion, D.Numero as NumeroDireccion, D.CP as CPDireccion, D.Localidad as LocalidadDireccion, D.Provincia as ProvinciaDireccion, 
C.Email as EmailContacto, C.Telefono as TelefonoContacto
From PERSONA as P
Inner Join DIRECCION as D on D.IdDireccion = P.IdDireccion
Inner Join CONTACTO as C on C.IdContacto = P.IdContacto
Where P.Eliminado != 1


go

CREATE PROCEDURE spAgregarPersona
	@Nombre varchar(50),
	@Apellido varchar(50),
	@Imagen varchar(50),
	@DNI bigint,
	@IdDireccion int,
	@IdContacto int,
	--@FechaNac time,
	--@FechaReg time,
	@Eliminado int 
as
insert into PERSONA(Nombre, Apellido,Imagen,DNI, IdDireccion, IdContacto, Eliminado) 
Values (@Nombre,@Apellido,@Imagen,@DNI,@IdDireccion,@IdContacto,@Eliminado)

go

---MODIFICACION
CREATE PROCEDURE spModificarPersona
	@IdPersona int,
	@Nombre varchar(50),
	@Apellido varchar(50),
	@Imagen varchar(50),
	@DNI bigint,
	@IdDireccion int,
	@IdContacto int,
	@Eliminado int
	
as 
Update PERSONA set Nombre=@Nombre, Apellido=@Apellido, Imagen=@Imagen, DNI=@DNI, IdDireccion=@IdDireccion, IdContacto=@IdContacto where IdPersona=@IdPersona


--CREATE PROCEDURE spEliminarPersona
--@IdCategoria int
--as
--Update CATEGORIAS set Eliminado = 1 where IdCategoria = @IdCategoria

go


------------------------------------- STORE PROCEDURES DE AUTOS------------------------------------------

--LISTAR
CREATE PROCEDURE spListarVehiculo as
select A.IdAuto, A.Patente, A.Modelo, A.Eliminado
From VEHICULO as A
Where A.Eliminado != 1

go

--AGREGAR
CREATE PROCEDURE spAgregarVehiculo
	@Patente varchar(50),
	@Modelo varchar(50),
	@Eliminado int 
as
insert into VEHICULO(Patente, Modelo, Eliminado) 
Values (@Patente,@Modelo,@Eliminado)

go

--ELIMINAR
CREATE PROCEDURE spEliminarVehiculo
@IdAuto int
as
Update VEHICULO set Eliminado = 1 where IdAuto = @IdAuto

go

--MODIFICAR
CREATE PROCEDURE spModificarVehiculo
	@Patente varchar(20),
	@IdAuto int,
	@Modelo varchar(20),
	@Eliminado int 
as 
Update VEHICULO set Patente=@Patente, Modelo=@Modelo, Eliminado=@Eliminado where IdAuto=@IdAuto
go

---------------------------------------STORE PROCEDURES DE DIRECCION---------------------------------------------------

--LISTAR
CREATE PROCEDURE spListarDireccion as
select D.IdDireccion, D.Calle, D.Numero, D.CP, D.Localidad, D.Provincia
From DIRECCION as D

go

--AGREGAR
CREATE PROCEDURE spAgregarDireccion
	@Calle varchar(20),
	@Numero int,
	@CP int,
	@Localidad varchar(50),
	@Provincia varchar(50)
as
insert into DIRECCION(Calle, Numero, CP, Localidad, Provincia) 
Values (@Calle, @Numero, @CP, @Localidad, @Provincia)

go

--MODIFICAR
CREATE PROCEDURE spModificarDireccion
	@IdDireccion int,
	@Calle varchar(20),
	@Numero int,
	@CP int,
	@Localidad varchar(50),
	@Provincia varchar(50)
as 
Update DIRECCION set Calle=@Calle, Numero=@Numero, CP=@CP, Localidad=@Localidad, Provincia=@Provincia   
where IdDireccion=@IdDireccion
go

--ELIMINAR

----------------------------------------------STORE PROCEDURES DE CONTACTO--------------------------------------------------

--LISTAR
CREATE PROCEDURE spListarContacto as
select C.IdContacto, C.Email, C.Telefono
From CONTACTO as C

go

--AGREGAR
CREATE PROCEDURE spAgregarContacto
	@Email varchar(20),
	@Telefono bigint
as
insert into CONTACTO(Email, Telefono) 
Values (@Email, @Telefono)

go

--MODIFICAR
CREATE PROCEDURE spModificarContacto
	@IdContacto int,
	@Email varchar(20),
	@Telefono int
as 
Update CONTACTO set Email = @Email, Telefono = @Telefono   
where IdContacto=@IdContacto
go

----------------------------------------------STORE PROCEDURES DE STOCKxAUTO--------------------------------------------------

--LISTAR
CREATE PROCEDURE spListarStockAuto as
select S.IdStock, S.IdMaterial, S.IdAuto, S.Cantidad, S.Eliminado
From STOCK as S

go

--AGREGAR
CREATE PROCEDURE spAgregarStockAuto
	@IdMaterial int,
	@IdAuto int,
	@Cantidad varchar(50),
	@Eliminado int
as
insert into STOCK(IdMaterial, IdAuto, Cantidad, Eliminado) 
Values (@IdMaterial, @IdAuto, @Cantidad,@Eliminado)

go

--MODIFICAR
CREATE PROCEDURE spModificarStockAuto
	@IdStock int,
	@IdAuto int,
	@IdMaterial int,
	@Cantidad int,
	@Eliminado int
as 
Update STOCK set IdMaterial = @IdMaterial, IdAuto = @IdAuto, Cantidad = @Cantidad   
where IdStock=@IdStock
go

--ELIMINAR
CREATE PROCEDURE spEliminarStockAuto
@IdStockAuto int
as
Update STOCK set Eliminado = 1 where IdStock = @IdStockAuto

--------------------------------------------SP AGREGAR STOCK X AUTO-----------------------------------
go
CREATE PROCEDURE spAsignacionStockXAuto
	@IdStock int,
	@IdAuto int
	as
	insert into STOCKXAUTO(IdStock,IdAuto) values (@IdStock,@IdAuto)
go

--------------------------------------------SP AGREGAR MATERIAL X AUTO-----------------------------------
go
CREATE PROCEDURE spAsignacionMaterialXAuto
	@IdMaterial int,
	@IdAuto int
	as
	insert into MATERIALXAUTO(IdMaterial,IdAuto) values (@IdMaterial,@IdAuto)
go

--------------------------------------------SP TIPOS DE USUARIO---------------------------------------

CREATE PROCEDURE spListarTipoUsuario as
select TU.IdTipo, TU.Nombre, TU.Eliminado 
From TipoUsuario AS TU
Where TU.Eliminado != 1

go

---ALTA
CREATE PROCEDURE spAgregarTipoUsuario 
	@Nombre varchar(50), 		
	@Eliminado int 
as
insert into TipoUsuario(Nombre, Eliminado) 
Values (@Nombre,@Eliminado)

go

---MODIFICACION
CREATE PROCEDURE spModificarTipoUsuario
	@IdTipo int,
	@Nombre varchar(50) 
as 
Update TipoUsuario set Nombre=@Nombre where IdTipo=@IdTipo

go

--ELIMINAR
CREATE PROCEDURE spEliminarTipoUsuario
@IdTipoUsuario int
as
Update TipoUsuario set Eliminado = 1 where IdTipo = @IdTipoUsuario

--------------------------------------------SP ASIGNACION----------------------------------
GO 

CREATE PROCEDURE spAgregarAsignacion
	@IdUsuario int,
	@fecha datetime
as
Insert Into ASIGNACIONXAUTO(IdUsuario, FechaAsignacion)
Values (@IdUsuario, @fecha)

GO

CREATE PROCEDURE spAsignacionMaterialXAuto
	@IdMaterial int,
	@IdAuto int,
	@IdAsignar int,
	@Cantidad int,
	@Eliminar int
as
Insert Into STOCKAUTO(IdMaterial, IdAuto, IdAsignar, Cantidad, Eliminado)
Values (@IdMaterial, @IdAuto, @IdAsignar, @Cantidad, @Eliminar)

GO
--CREATE PROCEDURE spAgregarAsignacionxMaterial
--	@IdAsignar int,
--	@IdMaterial int
--as
--Insert Into ASIGNACIONXMATERIAL(IdMaterial, IdAsignar)
--Values (@IdMaterial, @IdAsignar)

GO

CREATE PROCEDURE spAgregarAsignacionxUsuarios
	@IdUsuario int,
	@IdAsignar int
as
Insert Into ASIGNACIONXUSUARIO(IdUsuario, IdAsignar)
Values (@IdUsuario,@IdAsignar)

GO

CREATE PROCEDURE spListarAsignacion AS
	select A.IdAsignar, A.IdUsuario, A.FechaAsignacion
	From ASIGNACIONXAUTO as A

GO

CREATE PROCEDURE spListarAsignacionxProductos as
	select A.IdAsignar, M.IdMaterial, U.IdUsuario, P.IdPersona, P.Nombre, P.Apellido
	From ASIGNAR as A
	Inner Join MATERIALES as M on M.IdMaterial = A.IdMaterial
	Inner Join USUARIO as U on U.IdUsuario = A.IdUsuario
	Inner Join PERSONA as P on P.IdPersona = U.IdPersona

GO

CREATE PROCEDURE spListarAsignacionxUsuarios as
	select A.IdAsignar, M.Nombre, M.Cantidad, C.Nombre, A.FechaAsignacion, M.Imagen
	From ASIGNAR as A
	Inner Join MATERIALES as M on M.IdMaterial = A.IdMaterial
	Inner Join CATEGORIAS as C on C.IdCategoria =  M.IdCategoria
