USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[ConsultarUsuario]    Fecha de la secuencia de comandos: 01/14/2010 09:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarUsuario]

@LoginUsuario varchar(20)
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

SELECT U.LoginUsuario, U.Status, E.Nombre, E.Apellido from dbo.Usuario U, dbo.Empleado E
WHERE ((LoginUsuario like @LoginUsuario) and (E.CIEmpleado=U.CIEmpleado))

END