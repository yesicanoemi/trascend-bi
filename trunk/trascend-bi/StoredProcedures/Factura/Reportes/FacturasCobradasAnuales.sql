USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[FacturasCobradasAnuales]    Fecha de la secuencia de comandos: 02/02/2010 17:51:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[FacturasCobradasAnuales]
	-- Add the parameters for the stored procedure here

	@yearFecha Datetime

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT F.IdFactura, F.Titulo, F.Descripcion, F.FechaIngreso, EF.Nombre, F.Fecha, F.Porcentaje
	FROM dbo.Factura F, EstadoFactura EF
	WHERE DATEPART(year, F.Fecha) = DATEPART(year, @yearFecha) and F.Estado = 1 and F.estado = EF.Id

END
