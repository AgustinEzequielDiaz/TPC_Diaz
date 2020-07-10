CREATE DATABASE DIAZ_DB	
GO
USE DIAZ_DB
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
	Provincia varchar(50) NOT NULL,
)
GO
CREATE TABLE CONTACTO(
	IdContacto int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Email varchar(50) NOT NULL,
	Telefono bigint NOT NULL,
)

GO

CREATE TABLE USUARIO(
	IdUsuario int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	IdTipo int NOT NULL, --PERMISO
	--Imagen varchar(50) NOT NULL,
	Clave varchar(50) NOT NULL,
	Eliminado int NOT NULL,
	-----------------------------------
	Nombre varchar(50) NOT NULL,
	Apellido varchar(50) NOT NULL,
	Imagen varchar(50),
	DNI bigint NOT NULL,
	IdDireccion int NOT NULL FOREIGN KEY REFERENCES DIRECCION(IdDireccion),
	IdContacto int NOT NULL foreign key references CONTACTO(IdContacto),
	FechaReg date 
)

go
CREATE TABLE VEHICULO(
	IdVehiculo int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	IdUsuario int NOT NULL foreign key references USUARIO(IdUsuario),
	Patente varchar(10) NOT NULL,
	Modelo varchar(50) NOT NULL,
	Eliminado int NOT NULL
)

GO

CREATE TABLE ASIGNACION(
	IdAsignacion int IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	IdMaterial int NOT NULL FOREIGN KEY REFERENCES MATERIALES(IdMaterial),
	IdUsuario int NOT NULL FOREIGN KEY REFERENCES USUARIO(IdUsuario),
	Cantidad int NOT NULL,
	FechaAsignacion date NOT NULL
)

GO 

CREATE TABLE MATERIALXASIGNACION(
	IdAsignacion int NOT NULL FOREIGN KEY REFERENCES ASIGNACION(IdAsignacion),
	IdMaterial int NOT NULL FOREIGN KEY REFERENCES MATERIALES(IdMaterial),
	Cantidad int NOT NULL
)

GO

SELECT * FROM USUARIO

CREATE PROCEDURE spUsuarioRegistrado
	@Usuario varchar(50),
	@Clave varchar(50)
as select * from MATERIALES




--CREATE TABLE PERSONA(
--	IdPersona int IDENTITY(1,1) PRIMARY KEY NOT NULL,
--	Nombre varchar(50) NOT NULL,
--	Apellido varchar(50) NOT NULL,
--	Imagen varchar(50),
--	DNI bigint NOT NULL,
--	IdDireccion int NOT NULL FOREIGN KEY REFERENCES DIRECCION(IdDireccion),
--	IdContacto int NOT NULL foreign key references CONTACTO(IdContacto),
--	FechaReg date NOT NULL
--)

--GO

--CREATE TABLE TIPOUSUARIO(
--	IdTipo int NOT NULL IDENTITY(1,1) PRIMARY KEY,
--	Nombre varchar(50) NOT NULL,
--	Eliminado int NOT NULL,
--)

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

create procedure spListarAsignacionXMaterial
as
select A.IdAsignacion,MxA.IdMaterial,M.Nombre as NombreMaterial, MxA.Cantidad, C.Nombre as NombreCategoria, A.FechaAsignacion 
from ASIGNACION as A
inner join MATERIALXASIGNACION as MxA on MxA.IdAsignacion = A.IdAsignacion
inner join MATERIALES as M on M.IdMaterial = MxA.IdMaterial
inner join CATEGORIAS as C on C.IdCategoria = M.IdCategoria
--inner join VEHICULO as V on V.IdUsuario = A.IdUsuario
go

create procedure spAsignacionStockXAuto
	@IdAsignacion int,
	@IdMaterial int,
	@Cantidad int
as
insert into MATERIALXASIGNACION (IdAsignacion, IdMaterial, Cantidad)
values (@IdAsignacion, @IdMaterial, @Cantidad)

GO

create procedure spAgregarAsignacion
@IdMaterial int,
@Cantidad int
as
insert into ASIGNACION(IdMaterial, Cantidad)
values (@IdMaterial, @Cantidad)

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



------------------------------------- STORE PROCEDURES DE AUTOS------------------------------------------

--LISTAR
CREATE PROCEDURE spListarVehiculo as
select A.IdVehiculo, A.IdUsuario, A.Patente, A.Modelo, A.Eliminado
From VEHICULO as A
Where A.Eliminado != 1

go

--AGREGAR
CREATE PROCEDURE spAgregarVehiculo
	@IdUsuario int,
	@Patente varchar(50),
	@Modelo varchar(50),
	@Eliminado int 
as
insert into VEHICULO(IdUsuario, Patente, Modelo, Eliminado) 
Values (@IdUsuario,@Patente,@Modelo,@Eliminado)

go

--ELIMINAR
CREATE PROCEDURE spEliminarVehiculo
@IdAuto int
as
Update VEHICULO set Eliminado = 1 where IdVehiculo = @IdAuto

go

--MODIFICAR
CREATE PROCEDURE spModificarVehiculo
	@Patente varchar(20),
	@IdAuto int,
	@Modelo varchar(20),
	@Eliminado int 
as 
Update VEHICULO set Patente=@Patente, Modelo=@Modelo, Eliminado=@Eliminado where IdVehiculo=@IdAuto
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

----ELIMINAR
--CREATE PROCEDURE spEliminarDireccion
--	@IdDireccion int
--	as
--Update DIRECCION set Eliminado = 1 where IdStock = @IdStockAuto
GO

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
----------------------------------------------STORE PROCEDURES DE USUARIOS--------------------------------------------------
--LISTAR
CREATE PROCEDURE spListarUsuario as
select U.IdUsuario, U.Nombre, U.Clave, U.Apellido, U.DNI, U.IdTipo
FROM USUARIO as U
where U.Eliminado = 0;

DROP PROCEDURE spListarUsuario
GO

CREATE PROCEDURE spListaUsuario as 
select U.IdUsuario, U.Nombre, U.Clave, U.Apellido, U.DNI, U.IdTipo
FROM USUARIO as U
where U.Eliminado = 0;

exec spListarUsuario

GO

CREATE PROCEDURE spListarUsuarioDetalle as
select U.DNI, D.Calle, D.Numero, D.CP, D.Localidad, D.Provincia, C.Email, C.Telefono 
From USUARIO as U
Inner Join DIRECCION as D on D.IdDireccion = U.IdUsuario
Inner Join CONTACTO as C on C.IdContacto =  U.IdUsuario

GO

CREATE PROCEDURE spAgregarUsuario 
	@Nombre varchar(50),
	@Clave varchar(20),
	@Apellido varchar(50),
	@DNI int,
	@FechaReg date,
	@Imagen varchar(50),
	@IdTipo int,
	@IdContacto int,
	@IdDireccion int,
	@Eliminado int
as
insert into USUARIO(Clave, IdTipo, Nombre, Apellido, DNI, Imagen, IdDireccion, IdContacto, FechaReg, Eliminado) 
Values (@Clave, @IdTipo, @Nombre, @Apellido, @DNI, @Imagen, @IdDireccion, @IdContacto, @FechaReg, @Eliminado)




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

--------------------------------------------SP ASIGNACION----------------------------------

CREATE PROCEDURE spAgregarAsignacion
	@IdMaterial int ,
	@IdUsuario int,
	@Cantidad int,
	@fecha datetime
as
Insert Into ASIGNACION(IdMaterial, IdUsuario, Cantidad, FechaAsignacion)
Values (@IdMaterial, @IdUsuario, @Cantidad, @fecha)

GO

CREATE PROCEDURE spAgregarAsignacionxMaterial
	@IdAsignar int,
	@IdMaterial int
as
Insert Into ASIGNACIONXMATERIAL(IdMaterial, IdAsignar)
Values (@IdMaterial, @IdAsignar)


GO

CREATE PROCEDURE spListarAsignacion AS
	select A.IdAsignar, M.Cantidad, A.FechaAsignacion
	From ASIGNAR as A
	Inner Join MATERIALES as M on M.IdMaterial = A.IdMaterial




--------------------------------------------SP TIPOS DE USUARIO---------------------------------------
--go

--CREATE PROCEDURE spListarTipoUsuario as
--select TU.IdTipo, TU.Nombre, TU.Eliminado 
--From TipoUsuario AS TU
--Where TU.Eliminado != 1

--go

-----ALTA
--CREATE PROCEDURE spAgregarTipoUsuario 
--	@Nombre varchar(50), 		
--	@Eliminado int 
--as
--insert into TipoUsuario(Nombre, Eliminado) 
--Values (@Nombre,@Eliminado)

--go

-----MODIFICACION
--CREATE PROCEDURE spModificarTipoUsuario
--	@IdTipo int,
--	@Nombre varchar(50) 
--as 
--Update TipoUsuario set Nombre=@Nombre where IdTipo=@IdTipo

--go

----ELIMINAR
--CREATE PROCEDURE spEliminarTipoUsuario
--@IdTipoUsuario int
--as
--Update TipoUsuario set Eliminado = 1 where IdTipo = @IdTipoUsuario

----------------------------------------STORE PROCEDURES DE PERSONA----------------------------------------------------

--CREATE PROCEDURE spListarPersona as
--select P.IdPersona, P.Nombre, P.Apellido, P.Imagen, P.DNI, P.FechaReg,
--D.Calle as CalleDireccion, D.Numero as NumeroDireccion, D.CP as CPDireccion, D.Localidad as LocalidadDireccion, D.Provincia as ProvinciaDireccion, 
--C.Email as EmailContacto, C.Telefono as TelefonoContacto
--From PERSONA as P
--Inner Join DIRECCION as D on D.IdDireccion = P.IdDireccion
--Inner Join CONTACTO as C on C.IdContacto = P.IdContacto


--go

--CREATE PROCEDURE spAgregarPersona
--	@Nombre varchar(50),
--	@Apellido varchar(50),
--	@Imagen varchar(50),
--	@DNI bigint,
--	@IdDireccion int,
--	@IdContacto int,
--	@FechaReg date
--as
--insert into PERSONA(Nombre, Apellido,Imagen,DNI, IdDireccion, IdContacto,FechaReg) 
--Values (@Nombre,@Apellido,@Imagen,@DNI,@IdDireccion,@IdContacto,@FechaReg)

--go

-----MODIFICACION
--CREATE PROCEDURE spModificarPersona
--	@IdPersona int,
--	@Nombre varchar(50),
--	@Apellido varchar(50),
--	@Imagen varchar(50),
--	@DNI bigint,
--	@IdDireccion int,
--	@IdContacto int
	
--as 
--Update PERSONA set Nombre=@Nombre, Apellido=@Apellido, Imagen=@Imagen, DNI=@DNI, IdDireccion=@IdDireccion, IdContacto=@IdContacto where IdPersona=@IdPersona


--go
