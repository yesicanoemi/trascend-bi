CREATE PROCEDURE [dbo].[ConsultarFacturaNomPro]
@titulo varchar(20)
AS
BEGIN
SELECT f.* From Factura f where f.IdPropuesta in (select p.idpropuesta from propuesta p where p.titulo = @titulo )
END