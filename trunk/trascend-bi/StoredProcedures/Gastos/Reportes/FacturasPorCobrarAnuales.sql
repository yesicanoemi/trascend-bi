USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[FacturasPorCobrarAnuales]    Fecha de la secuencia de comandos: 01/18/2010 21:25:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[FacturasPorCobrarAnuales]
	-- Add the parameters for the stored procedure here

	@yearFecha Datetime

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT IdFactura, Titulo, Descripcion, FechaIngreso, Estado, Fecha, Porcentaje
	FROM dbo.Factura
	WHERE DATEPART(year, Fecha) = DATEPART(year, @yearFecha) and Estado like 'Por Cobrar'

END
