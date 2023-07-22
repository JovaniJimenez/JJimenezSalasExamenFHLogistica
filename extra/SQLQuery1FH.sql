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
IdTipo int references Tipo(IdTipo),
ClaveInventario varchar(100) unique,
IdTipoEquipo int references TipoEquipoArea(IdTipoEquipo),
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
NombreTipoArea varchar(100)
);



CREATE TABLE Asignacion(
IdAsignacion int primary key identity(1,1),
IdUsuario int references Usuario(IdUsuario),
IdEquipo int references Equipo(IdEquipo),
FechaAsignada date
);


Create procedure GetAllAsignaciones
As
begin
select IdAsignacion,Usuario.IdUsuario, Equipo.IdEquipo, Usuario.Nombre,Equipo.IdMarca,Equipo.Modelo,Asignacion.FechaAsignada from Asignacion inner join Usuario on Asignacion.IdUsuario= Usuario.IdUsuario
inner join Equipo on Equipo.IdEquipo = Asignacion.IdEquipo
end;

CREATE PROCEDURE EquiposSinAsignar
AS
BEGIN
    SELECT e.IdEquipo, e.Modelo, e.ClaveInventario
    FROM Equipo e
    LEFT JOIN Asignacion a ON e.IdEquipo = a.IdEquipo
    WHERE a.IdEquipo IS NULL;
END;


SELECT * FROM Asignacion




