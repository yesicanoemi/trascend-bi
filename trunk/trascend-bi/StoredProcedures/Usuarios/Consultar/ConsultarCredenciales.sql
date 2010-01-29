set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Maria Salazar, Manuel Vargas>
-- Create date: <10/01/2010>
-- Description:	<Consulta de Credenciales de Usuario>
-- =============================================
ALTER PROCEDURE [dbo].[ConsultarCredenciales]

	-- Add the parameters for the stored procedure here

	@LoginUsuario varchar(20),
	@Password varchar(20)

AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;
	
	SELECT     Usuario.IdUsuario AS IdUsuario, Usuario.LoginUsuario AS LoginUsuario, Usuario.Password AS Password, Usuario.IdEmpleado AS IdEmpleado, EstadoUsuario.Nombre AS Status
	FROM         EstadoUsuario INNER JOIN
                      Usuario ON EstadoUsuario.ID = Usuario.Status
	WHERE ((Usuario.LoginUsuario=@LoginUsuario) and (Usuario.Password=@Password));

END



