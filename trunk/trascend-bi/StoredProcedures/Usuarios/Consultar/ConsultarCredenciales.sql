-- =============================================
-- Author:		<Daniel Trejo, Dinangela Rojas>
-- Create date: <10/01/2010>
-- Description:	<Consulta de Credenciales de Usuario>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarCredenciales]

	-- Add the parameters for the stored procedure here

	@LoginUsuario varchar(20),
	@Password varchar(20)

AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;
	
	SELECT * from dbo.Usuario
	WHERE ((LoginUsuario=@LoginUsuario) and (Password=@Password))

END
GO
