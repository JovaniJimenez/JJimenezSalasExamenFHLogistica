create database InventarioComputoFH

use InventarioComputoFH

create table Usuario(
IdUsuario int primary key identity(1,1),
IdSupervisor int references Supervisor(IdSupervisor),
Nombre varchar(100),
ApellidoPaterno varchar(100),
ApellidoMaterno varchar(100),
FechaIngreso date,
);

create table Area(
IdArea int primary key identity(1,1),
Descripccion varchar(100)

)

create table Supervisor(
IdSupervisor int primary key identity(1,1),
NombreSupervisor varchar(100)
);

create table Equipo(
IdEquipo int primary key identity(1,1),
Modelo varchar(100),
IdMarca int references Marca(IdMarca),
ClaveInventario varchar(100) unique,
IdTipoEquipo int references TipoEquipo(IdTipoEquipo),
IdArea int references Area(IdArea)
);


create table Tipo(
IdTipo int primary key identity(1,1),
NombreTipo varchar(100)
);

create table Marca(
IdMarca int primary key identity(1,1),
NombreMarca varchar(100)
);

create table TipoEquipo(
IdTipoEquipo int primary key identity(1,1),
NombreTipo varchar(100)
);



CREATE TABLE Asignacion(
IdAsignacion int primary key identity(1,1),
IdUsuario int references Usuario(IdUsuario),
IdEquipo int references Equipo(IdEquipo),
FechaAsignada date,
Comentario varchar(50)
);



--Procedure


create procedure UpdateUsuario
@IdUsuario int,@IdSupervisor int ,@Nombre varchar(20),@ApellidoPaterno varchar(20), @ApellidoMaterno varchar(20),
@FechaIngreso date
as
begin
UPDATE Usuario SET  IdSupervisor=@IdSupervisor,Nombre=@Nombre,ApellidoPaterno=@ApellidoPaterno,ApellidoMaterno=@ApellidoMaterno,FechaIngreso=@FechaIngreso where IdUsuario=@IdUsuario
end;

create procedure UsuarioAdd
@IdSupervisor int, @Nombre varchar(20),@ApellidoPaterno varchar(20),@ApellidoMaterno varchar(20),@FechaIngreso date
as
begin
	INSERT INTO Usuario (IdSupervisor,Nombre,ApellidoPaterno,ApellidoMaterno,FechaIngreso)values(@IdSupervisor,@Nombre,@ApellidoPaterno,@ApellidoMaterno,@FechaIngreso)
end;



CREATE PROCEDURE GetByIdUsuario 1
@IdUsuario int
as 
begin
select IdUsuario,IdSupervisor,Nombre,ApellidoPaterno,ApellidoMaterno,FechaIngreso from Usuario where IdUsuario=@IdUsuario
end;


create procedure GetSupervisor
as
begin
select IdSupervisor,NombreSupervisor from Supervisor
end;

create procedure GetEquipos
as
begin
select Equipo.IdEquipo,Equipo.Modelo,ClaveInventario,TipoEquipo.IdTipoEquipo,TipoEquipo.NombreTipo from Equipo inner join TipoEquipo on TipoEquipo.IdTipoEquipo=Equipo.IdTipoEquipo

end;



CREATE PROCEDURE AddAsignar
    @IdEquipo INT,
    @IdUsuario INT,
    @Comentario VARCHAR(50)
AS
BEGIN
    -- Verificar si el usuario ya está asignado al equipo
    IF NOT EXISTS (SELECT 1 FROM Asignacion WHERE IdUsuario = @IdUsuario)
    BEGIN
        -- Si el usuario no está asignado, realizar la inserción
        INSERT INTO Asignacion (IdEquipo, IdUsuario, FechaAsignada, Comentario)
        VALUES (@IdEquipo, @IdUsuario, GETDATE(), @Comentario);
        SELECT 'Asignación exitosa.' AS Message;
    END
    ELSE
    BEGIN
        -- Si el usuario ya está asignado, retornar un mensaje de error o manejarlo según tus necesidades
        SELECT 'El usuario ya está asignado a un equipo.' AS Message;
    END
END




CREATE PROCEDURE GetAllUsuario
as 
begin
select IdUsuario,IdSupervisor,Nombre,ApellidoPaterno,ApellidoMaterno,FechaIngreso from Usuario
end;


Create procedure GetAllAsignaciones
As
begin
select IdAsignacion,Usuario.IdUsuario, Equipo.IdEquipo, Usuario.Nombre,Area.IdArea,Area.Descripccion,Marca.IdMarca,Marca.NombreMarca,Equipo.IdMarca,Equipo.Modelo,Asignacion.FechaAsignada from Asignacion inner join Usuario on Asignacion.IdUsuario= Usuario.IdUsuario
inner join Equipo on Equipo.IdEquipo = Asignacion.IdEquipo
inner join Area on Equipo.IdArea=Area.IdArea
inner join Marca on Equipo.IdMarca=Marca.IdMarca
end;



CREATE PROCEDURE EquiposSinAsignar
AS
BEGIN
    SELECT Equipo.IdEquipo,Equipo.Modelo,Equipo.ClaveInventario
    FROM Equipo 
    LEFT JOIN Asignacion  ON Equipo.IdEquipo = Asignacion.IdEquipo
    WHERE Asignacion.IdEquipo IS NULL;
END;



create procedure DeleteAsignacion
@IdAsignacion int
as
begin
DELETE FROM Asignacion where IdAsignacion=@IdAsignacion
end
select * from TipoEquipo


--Add
INSERT INTO TipoEquipo (NombreTipo)values('Escritorio')

INSERT INTO TipoEquipo (NombreTipo)values('Laptop')


INSERT INTO Marca(NombreMarca)values('ACER')

INSERT INTO Marca(NombreMarca)values('HP')

INSERT INTO Marca(NombreMarca)values('LENOVO')

INSERT INTO Marca(NombreMarca)values('ASUS')

INSERT INTO Area(Descripccion)values('Despartamento de sistemas')

INSERT INTO Area(Descripccion)values('Despartamento de Mantenimiento')

INSERT INTO Area(Descripccion)values('Despartamento de Recursos Humanos')



INSERT INTO Equipo(Modelo,IdMarca,ClaveInventario,IdTipoEquipo,IdArea)VALUES('Laptop-HP01',2,'ERD2342',1,1)

INSERT INTO Equipo(Modelo,IdMarca,ClaveInventario,IdTipoEquipo,IdArea)VALUES('Laptop-Acer02',1,'ERD234255',1,1)

INSERT INTO Equipo(Modelo,IdMarca,ClaveInventario,IdTipoEquipo,IdArea)VALUES('Laptop-LENOVO03',3,'ERD2342gf',2,3)

INSERT INTO Equipo(Modelo,IdMarca,ClaveInventario,IdTipoEquipo,IdArea)VALUES('Laptop-HP04',2,'ERD2342rew2',2,2)

INSERT INTO Equipo(Modelo,IdMarca,ClaveInventario,IdTipoEquipo,IdArea)VALUES('Laptop-ASUS05',4,'ERD2342we',1,3)




INSERT INTO Supervisor (NombreSupervisor)values('Jose')
INSERT INTO Supervisor (NombreSupervisor)values('Maria')


INSERT INTO Usuario(IdSupervisor,Nombre,ApellidoPaterno,ApellidoMaterno,FechaIngreso)VALUES(1,'Jovani','Salas','Salas','01-02-2023')
