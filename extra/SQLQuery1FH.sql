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
CREATE PROCEDURE GetByIdUsuario
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



create procedure GetEquipos
as
begin
select Equipo.IdEquipo,Equipo.Modelo,ClaveInventario,TipoEquipo.IdTipoEquipo,TipoEquipo.NombreTipo from Equipo inner join TipoEquipo on TipoEquipo.IdTipoEquipo=Equipo.IdTipoEquipo

end;


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
FechaAsignada date
);

create procedure AddAsignar
@IdEquipo int, @IdUsuario int
as
begin
insert into Asignacion (IdEquipo,IdUsuario,FechaAsignada)values(@IdEquipo,@IdUsuario,GETDATE())
end

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



SELECT * FROM Equipo
SELECT * FROM Asignacion

select * from Area

truncate table Asignacion








CREATE PROCEDURE EquiposSinAsignar
AS
BEGIN
    SELECT Equipo.IdEquipo,Equipo.Modelo,Equipo.ClaveInventario
    FROM Equipo 
    LEFT JOIN Asignacion  ON Equipo.IdEquipo = Asignacion.IdEquipo
    WHERE Asignacion.IdEquipo IS NULL;
END;

select * from Equipo

create procedure DeleteAsignacion
@IdAsignacion int
as
begin
DELETE FROM Asignacion where IdAsignacion=@IdAsignacion
end