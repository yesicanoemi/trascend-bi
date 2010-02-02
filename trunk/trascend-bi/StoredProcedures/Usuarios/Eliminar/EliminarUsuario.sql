set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Manuel Vargas, Maria Salazar>
-- Create date: <30/01/2010>
-- Description:	<Desactivar usuario>
-- =============================================
ALTER PROCEDURE [dbo].[EliminarUsuario]

	-- Add the parameters for the stored procedure here

	@LoginUsuario varchar(20),
	@Status varchar(20)

AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;

	UPDATE Usuario SET  Status = (SELECT ID
									FROM EstadoUsuario
									WHERE Nombre=@Status)
    WHERE LoginUsuario=@LoginUsuario

END

