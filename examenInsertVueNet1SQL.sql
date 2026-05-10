-- DESKTOP-JJ9DM3F\SQLEXPRESS
create database examenInsertVueNet1
use examenInsertVueNet1

create TABLE Departamento
(
	idDepartamento int identity(1,1),
	NombreDepartamento varchar(100),
	CONSTRAINT PK_Departamento primary key (idDepartamento)
)
CREATE TABLE Empleado
(
	idEmpleado int identity(1,1),
	NombreEmpleado varchar(100),
	idDepartamento int,
	CONSTRAINT PK_Empleado PRIMARY KEY (idEmpleado),
	CONSTRAINT FK_EmpleadoDepartamento FOREIGN KEY (idDepartamento) 
										REFERENCES Departamento(idDepartamento)
)

insert into Departamento(NombreDepartamento)values('IT'),('Marketing'),('Redes'),('RRHH')
insert into Empleado(nombreEmpleado,idDepartamento)values('Liz',4),('Adrian',1)


create procedure sp_ListarEmpleadosPorIdDep
(
	@idDepartamento int
)
as
begin
	select e.idEmpleado,e.NombreEmpleado,d.idDepartamento,d.NombreDepartamento
	from Empleado e
	inner join Departamento d
	on d.idDepartamento = e.idDepartamento
	where d.idDepartamento = @idDepartamento
end