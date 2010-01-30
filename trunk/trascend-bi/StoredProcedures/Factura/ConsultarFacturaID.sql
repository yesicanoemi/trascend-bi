USE [BddProy2]
GO
/****** Object:  StoredProcedure [dbo].[ConsultarFacturaID]    Script Date: 01/29/2010 23:17:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[ConsultarFacturaID]
	-- Add the parameters for the stored procedure here
	@IdFactura int
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
	WHERE F.IdFactura = @IdFactura AND
		F.Estado = E.ID AND
		F.IdPropuesta = P.IdPropuesta
END