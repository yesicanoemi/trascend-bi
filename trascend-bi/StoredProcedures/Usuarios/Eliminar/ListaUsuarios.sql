set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Manuel Vargas, Maria Salazar>
-- Create date: <30/01/2010>
-- Description:	<Lista de todos los usuarios activos>
-- =============================================
ALTER PROCEDURE [dbo].[ListaUsuarios]

	-- Add the parameters for the stored procedure here
	@IdEstadoUsuario int

AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;
	
	SELECT @IdEstadoUsuario=E.ID
	FROM dbo.EstadoUsuario.E
	WHERE E.Nombre='Activo' 	

	SELECT LoginUsuario FROM Usuario WHERE Status=@IdEstadoUsuario

END

