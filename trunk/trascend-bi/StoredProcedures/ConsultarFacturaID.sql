CREATE PROCEDURE [dbo].[ConsultarFacturaID]
@NumeroFactura int
AS
BEGIN
SELECT f.* From Factura f where f.NumeroFactura = @NumeroFactura
END