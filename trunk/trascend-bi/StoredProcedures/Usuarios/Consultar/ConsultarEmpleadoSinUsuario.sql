set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Maria Salazar, Manuel Vargas>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[ConsultarEmpleadoSinUsuario]

@nombre varchar(20)
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

SELECT Distinct(A.IdEmpleado), A.CIEmpleado, A.Nombre, A.Apellido, A.NumCuenta, A.FechaNac
FROM EMPLEADO A,USUARIO B, ESTADOEMPLEADO C
WHERE A.IDEMPLEADO NOT IN (SELECT IdEmpleado FROM Usuario) AND
C.ID = A.ESTADO AND
C.NOMBRE = 'Activo'
AND A.IDEMPLEADO IN (SELECT IDEMPLEADO FROM EMPLEADO WHERE NOMBRE LIKE @nombre)

END

