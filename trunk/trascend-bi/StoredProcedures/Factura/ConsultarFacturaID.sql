CREATE PROCEDURE [dbo].[ConsultarFacturaID]
@NumeroFactura int
AS
BEGIN
SELECT f.* From Factura f where f.IdFactura = @NumeroFactura
END