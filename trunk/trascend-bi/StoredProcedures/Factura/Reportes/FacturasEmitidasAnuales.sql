USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[FacturasEmitidasAnuales]    Fecha de la secuencia de comandos: 02/02/2010 17:52:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[FacturasEmitidasAnuales]
	-- Add the parameters for the stored procedure here

	@yearFecha Datetime

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT IdFactura, Titulo, Descripcion, FechaIngreso, Estado, Fecha, Porcentaje
	FROM dbo.Factura F , EstadoFactura EF 
	WHERE DATEPART(year, F.Fecha) = DATEPART(year, @yearFecha)and(F.Estado = EF.Id)

END
