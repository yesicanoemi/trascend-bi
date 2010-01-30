set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[ConsultarTelefonosCliente]
	-- Add the parameters for the stored procedure here
	@clienteId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT  t.CodigoArea, t.Numero, ti.Nombre from telefono t, tipotelefono ti where t.IdCliente = @clienteId and t.IdTipoTelefono = ti.ID;
END


