CREATE PROCEDURE [dbo].[ConsultarFacturaIDPro]
@idpropuesta int
AS
BEGIN
SELECT f.* From Factura f where f.idpropuesta = @idpropuesta
END