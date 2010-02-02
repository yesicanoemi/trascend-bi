set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Maria Salazar, Manuel Vargas>
-- Create date: <30/01/2010>
-- Description:	<Consulta Todos los Usuario>
-- =============================================
ALTER PROCEDURE [dbo].[ConsultarUsuarioTodos]

AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

SELECT     Usuario.LoginUsuario AS LoginUsuario, EstadoUsuario.Nombre AS Status, Empleado.Apellido AS Apellido, Empleado.Nombre AS Nombre, Usuario.IdUsuario AS IdUsuario
FROM         Empleado INNER JOIN
                      Usuario ON Empleado.IdEmpleado = Usuario.IdEmpleado INNER JOIN
                      EstadoUsuario ON Usuario.Status = EstadoUsuario.ID


END

