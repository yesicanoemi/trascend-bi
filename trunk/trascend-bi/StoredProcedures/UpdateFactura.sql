CREATE PROCEDURE [dbo].[UpdateFactura]
@NumeroFactura int
AS
BEGIN
UPDATE Factura
SET Estado = 'Cobrada', Fecha = GETDATE() 
WHERE NumeroFactura = @NumeroFactura
END