-- =============================================
-- Author:		<@Harold Bracho, Antonio Ibarra>
-- Create date: <2/2/10>
-- Description:	<Todos Los estados>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarEstado]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT C.Nombre, C.ID
	FROM dbo.EstadoUsuario C
END