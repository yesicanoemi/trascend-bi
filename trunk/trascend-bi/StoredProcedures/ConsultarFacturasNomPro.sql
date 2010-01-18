set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ConsultarFacturaNomPro]
@titulo varchar(50)
AS
BEGIN
SELECT f.* From Factura f where f.IdPropuesta in (select p.idpropuesta from propuesta p where p.titulo = @titulo )
END
