use RESIDENT_SYSTEM

-- TRIGGER
CREATE TRIGGER ASSIGN_ROL_AFTER_INSERT
ON AspNetUsers AFTER INSERT
AS
BEGIN
	INSERT INTO AspNetUserRoles(UserId, RoleId)
	select Id, 2 from inserted
END


-- Consultar Rol el usuario
select AspNetUsers.UserName, AspNetRoles.Name as 'Rol' from AspNetUsers
	inner join AspNetUserRoles on AspNetUserRoles.UserId = AspNetUsers.Id
	inner join AspNetRoles on AspNetRoles.Id = AspNetUserRoles.RoleId

select * from AspNetRoles
select * from AspNetUserRoles

insert into AspNetRoles(Id, Name) 
	values (1, 'Administrador'),
	       (2, 'Estudiante'),
	       (3, 'Empleado'),
	       (4, 'Empleado mantenimiento')