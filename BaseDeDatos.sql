
create database EmpresaTRBA

use EmpresaTRBA

create table TRBA(
	ID int primary key identity(1,1),
	PromocionCodigo varchar(50),
	Estado varchar(70),
	Edad int

)

insert into TRBA values ('MT-5','Desactivo',10);
insert into TRBA values ('MT-10','Activo',15);
insert into TRBA values ('MT-11','Activo',20);

--STORE PROCEDURE PARA EL LISTADO
CREATE PROCEDURE sp_Listar_TRBA
as
begin
	select * from TRBA
end



--PLUSS:
--CREACION DE UN Middleware 
--PARA EL MANEJO DE ERRORES

CREATE TABLE ErrorLog (
    ErrorId INT PRIMARY KEY IDENTITY,
    Timestamp DATETIME,
    ExceptionType NVARCHAR(255),
    Message NVARCHAR(MAX),
    StackTrace NVARCHAR(MAX)
);


select * from ErrorLog

