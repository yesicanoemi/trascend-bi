set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[AgregarUsuario]

@LoginUsuario varchar(20),
@Password varchar(20),
@Status varchar(20),
@IdEmpleado int

AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;


INSERT INTO usuario(LoginUsuario,Password,IdEmpleado,Status)
SELECT @LoginUsuario,@Password,@IdEmpleado,E.ID
FROM dbo.EstadoUsuario E 
WHERE E.Nombre=@Status

END

