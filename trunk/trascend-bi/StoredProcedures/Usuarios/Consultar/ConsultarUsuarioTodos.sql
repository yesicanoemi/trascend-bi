-- =============================================
-- Author:		<Dinangela Rojas>
-- Create date: <17/01/2010>
-- Description:	<Consulta de Usuario por Nombre>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarUsuarioTodos]
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

SELECT U.LoginUsuario, U.Status, E.Nombre, E.Apellido from dbo.Usuario U, dbo.Empleado E
WHERE (E.IdEmpleado=U.IdEmpleado)

END
