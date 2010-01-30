-- =============================================
-- Author:		<Dinangela Rojas>
-- Create date: <15/01/2010>
-- Description:	<Facturas emitidas en un rango de fecha>
-- =============================================
CREATE PROCEDURE [dbo].[FacturasEmitidas]

	@FechaIngreso1 smalldatetime,
	@FechaIngreso2 smalldatetime
AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT F.IdFactura, F.Titulo, F.Descripcion, F.FechaIngreso, F.Estado, P.Titulo  
	from dbo.Factura F, dbo.Propuesta P
	WHERE ((P.IdPropuesta = F.IdPropuesta) and (F.FechaIngreso BETWEEN @FechaIngreso1 AND @FechaIngreso2))

END

GO
