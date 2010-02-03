set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[ConsultarFacturasPorCobrar]
	-- Add the parameters for the stored procedure here
	@Fecha1 smalldatetime,
	@Fecha2 smalldatetime
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT F.IdFactura, F.Titulo, F.Descripcion,F.Porcentaje,EF.Nombre AS Estado, F.Fecha, F.FechaIngreso, P.Titulo AS NombrePropuesta,P.Monto 
	FROM dbo.Factura F, dbo.Propuesta P,dbo.EstadoFactura EF
	WHERE (F.Fecha BETWEEN @Fecha1 AND @Fecha2) AND (F.Estado = 2) AND (F.IdPropuesta = P.IdPropuesta) AND (EF.ID = F.Estado)

END

