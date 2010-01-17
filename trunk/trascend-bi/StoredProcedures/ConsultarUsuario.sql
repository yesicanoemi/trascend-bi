-- =============================================
-- Author:		<Dinangela Rojas>
-- Create date: <14/01/2010>
-- Description:	<Consulta de Usuario por Nombre>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarUsuario]

@LoginUsuario varchar(20)
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

SELECT U.LoginUsuario, U.Status, E.Nombre, E.Apellido from dbo.Usuario U, dbo.Empleado E
WHERE ((LoginUsuario like @LoginUsuario) and (E.IdEmpleado=U.IdEmpleado))

END
