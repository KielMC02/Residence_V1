
create database RESIDENT_SYSTEM
go
use RESIDENT_SYSTEM

go
create table TIPO_USUARIO
(
	id_tipo_usuario int not null identity primary key,
	nombre varchar(100) null unique 
)

go

create table EDIFICIOS
(
	id_edificio int not null primary key,
	cantidad_pisos int not null,
	estado_edificio varchar(20) not null default 'activo'
)
insert into EDIFICIOS(id_edificio,cantidad_pisos) values(1,3)
go

create table HABITACIONES
(
	id_habitacion int not null identity primary key,
	id_edificio int not null,
	piso int not null,
	habitacion varchar(10) not null,
	estado_habitacion varchar(20) not null default 'activa',

	foreign key(id_edificio) references EDIFICIOS(id_edificio)
)
insert into HABITACIONES(id_edificio,numero,planta) values (1,1,'A')
go 
create table USUARIOS
(
	id_usuario int not null identity primary key,
	id_tipo_usuario int not null,
	id_habitacion int,
	nombres varchar(100) not null,
	apellidos varchar(100) not null,
	matricula varchar(9) not null unique,
	cedula varchar(13) not null unique,
	telefono varchar(12),
	--correo varchar(100) not null unique,
	--password varchar(100) not null,
	estado_usuario varchar(20) not null default 'activo',
	fecha_nac datetime not null,
	sexo char not null,
	check(sexo = 'M' or sexo = 'F'),
	direccion text,

	foreign key(id_tipo_usuario) references TIPO_USUARIO(id_tipo_usuario),
	foreign key(id_habitacion) references HABITACIONES(id_habitacion)
)
alter table USUARIOS add id_Net_Users nvarchar(128) null ;
alter table USUARIOS add constraint FK_USUARIOS_ASPNetUsers FOREIGN KEY(id_Net_Users) references AspNetUsers(Id)
go

create table SOLICITUD_ESTANCIA
(
	id_solicitud int not null identity primary key,
	id_usuario int not null,
	motivo_solicitud text,
	seguro_medico varchar(25) not null,
	carta_conducta varchar(25) not null,
	cedula varchar(50) not null,
	fecha_solicitud datetime not null default GETDATE(),
	fecha_respuesta datetime null,
	estado_solicitud varchar(20) not null default 'Pendiente',

	foreign key(id_usuario) references USUARIOS(id_usuario)
)
insert into SOLICITUD_ESTANCIA(id_usuario,motivo,fecha_solicitud,seguro_medico,carta_conducta,cedula) values(1,'No tengo donde vivir, nadie me quiere',GETDATE(),'Palic','Me Porto Bien', '40239991959')
go
create table REPORTES_AVERIAS
(
	id_averia int not null identity primary key,
	id_usuario int not null,
	descripcion_averia text not null,
	status varchar(20) not null default 'pendiente',
	fecha_solicitud datetime default getdate() not null,
	fecha_respuesta datetime null,

	foreign key(id_usuario) references USUARIOS(id_usuario)
)

go
create table SOLICITUD_SALIDA
(
	id_salida int not null identity primary key,
	id_usuario int not null,
	tipo_solicitud varchar(20) not null,
	fecha_inicio datetime not null,
	fecha_fin datetime not null,
	motivo text,
	status varchar(20) not null default 'activo',

	foreign key(id_usuario) references USUARIOS(id_usuario)
)





