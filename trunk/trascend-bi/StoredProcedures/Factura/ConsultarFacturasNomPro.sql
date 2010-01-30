USE [BddProy2]
GO
/****** Object:  StoredProcedure [dbo].[ConsultarFacturaNomPro]    Script Date: 01/29/2010 23:18:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ConsultarFacturaNomPro]
	-- Add the parameters for the stored procedure here
	@Titulo varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT F.IdFactura, F.Titulo, F.Descripcion, F.Porcentaje, F.Fecha, F.FechaIngreso,
		E.Nombre AS EstadoFactura,
		P.Titulo AS TituloPropuesta, P.Monto AS Monto
	FROM dbo.Factura F, dbo.EstadoFactura E, dbo.Propuesta P 
	WHERE P.Titulo LIKE '%'+@Titulo+'%' AND
		P.IdPropuesta = F.IdPropuesta AND
		F.Estado = E.ID
END