USE [BddProy2]
GO
/****** Object:  StoredProcedure [dbo].[ConsultarFacturasCobradas]    Script Date: 01/16/2010 23:09:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarFacturasCobradas]
	-- Add the parameters for the stored procedure here
	@Fecha1 smalldatetime,
	@Fecha2 smalldatetime
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT F.IdFactura, F.Titulo, F.Descripcion, F.Fecha, F.FechaIngreso, P.Titulo AS NombrePropuesta 
	FROM dbo.Factura F, dbo.Propuesta P
	WHERE (F.Fecha BETWEEN @Fecha1 AND @Fecha2) AND (F.Estado = 'cobrada') AND (F.IdPropuesta = P.IdPropuesta)

END
