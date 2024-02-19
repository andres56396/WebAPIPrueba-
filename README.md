-- Tabla Estudiantes
CREATE TABLE Estudiantes
(
 IDEstudiante Int identity (100,1), 
 EstuNombre Varchar(100)NOT NULL,
 Estuemail varchar(100) NULL
)
go
ALTER TABLE Estudiantes ADD CONSTRAINT PK_Estudiante PRIMARY KEY (IDEstudiante)
go

-- Tabla Asignaturas
CREATE TABLE Asignaturas
(
 IDAsignatura Int identity (1,1) NOT NULL,
 AsigNombre Varchar(80) NULL, 
 AsigDescripcion Varchar(150) NULL
)
go
ALTER TABLE Asignaturas ADD CONSTRAINT PK_Asignatura PRIMARY KEY (IDAsignatura)
go

-- Tabla Asignaciones
CREATE TABLE Asignaciones
(
 IDAsignacion Int identity (1,1) NOT NULL primary key,
 Detalle varchar(100),
 IDEstudiante int not null,
 IDAsignatura int not null, 
 CONSTRAINT fk_Plan FOREIGN KEY (IDEstudiante) REFERENCES Estudiantes (IDEstudiante),
CONSTRAINT fk_Usuarios FOREIGN KEY (IDAsignatura) REFERENCES Asignaturas (IDAsignatura)
)

INSERT INTO Estudiantes VALUES ('Andres Herrera','andres@gmnail.com')
INSERT INTO Estudiantes VALUES ('Felipe hernandez','felipe@gmnail.com')
INSERT INTO Estudiantes VALUES ('Andrea Gomez','andrea@gmnail.com')
INSERT INTO Estudiantes VALUES ('Omaira Velazques','omaira@gmnail.com')

select * from Estudiantes
select * from Asignatura

INSERT INTO Asignaturas VALUES ('Matematicas 1','Sumas,restas etc..')
INSERT INTO Asignaturas VALUES ('Ingles 3','Verbo to-be, presente simple etc..')
INSERT INTO Asignaturas VALUES ('Algebra','Suma de matrices etc...')

INSERT INTO Asignaciones VALUES ('',100,1)
INSERT INTO Asignaciones VALUES ('',100,2)
INSERT INTO Asignaciones VALUES ('',100,3)
INSERT INTO Asignaciones VALUES ('',101,1)
INSERT INTO Asignaciones VALUES ('',102,3)
INSERT INTO Asignaciones VALUES ('',103,1)
INSERT INTO Asignaciones VALUES ('',103,2)

INSERT INTO Asignaciones VALUES ('',104,2)

-- Creacion de la VISTA vista_Estudiante_Asignaturas 
CREATE VIEW vista_Estudiante_Asignaturas AS
SELECT IDAsignacion,e.EstuNombre as Estudiante,e.IDEstudiante,a.IDAsignatura, a.AsigNombre as Asignatura,Detalle
    FROM Estudiantes e
    INNER JOIN Asignaciones ag ON e.IDEstudiante = ag.IDEstudiante
    INNER JOIN Asignaturas a ON ag.IDAsignatura = a.IDAsignatura

-- Creacion del Procedimiento ObtenerAsignaturasXEstudiante(NOS muestra las Asignaturas registradas por estudiantes)
	CREATE PROCEDURE ObtenerAsignaturasXEstudiante
    @IdEstudiante INT
AS
BEGIN
    select * from vista_Estudiante_Asignaturas
	where IDEstudiante = @IdEstudiante;
END

-- Creacion del Procedimiento ObtenerAsignaturasNoIncritaXEstudiante(NOS muestra las Asignaturas NO registradas por estudiantes)
	CREATE PROCEDURE ObtenerAsignaturasNoIncritaXEstudiante
    @IdEstudiante INT
AS
BEGIN
select * from Asignaturas where IDAsignatura not in 
(select IDAsignatura from vista_Estudiante_Asignaturas where IDEstudiante= @IdEstudiante)    
END

-- Creacion del Procedimiento RegistrarAsignacion(NOS Permite crear una nueva asignacion)
create procedure RegistrarAsignacion(  
  
     @Detalle Varchar(100) null,
    @IDEstudiante INT,
	@IDAsignatura INT
)
as
begin
INSERT INTO Asignaciones VALUES (@Detalle, @IDEstudiante,@IDAsignatura)
end

-- Creacion del Procedimiento RegistrarAsignacion(NOS Permite Eliminar una asignacion)
create procedure EliminarRegistroAsignacion(  
     @IDAsignacion INT
)
as
begin
DELETE FROM Asignaciones 
    WHERE IDAsignacion = @IDAsignacion
end

--exec RegistrarAsignacion '',104,1
exec ObtenerAsignaturasXEstudiante 100
exec    ObtenerAsignaturasNoIncritaXEstudiante 102

exec EliminarRegistroAsignacion 1013

select * from Asignaciones
