USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[ConsultarGastoPorFecha]    Fecha de la secuencia de comandos: 01/31/2010 01:36:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarGastoPorFecha]

	-- Add the parameters for the stored procedure here
	@Fecha smalldatetime

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  G.IdGasto, G.Tipo, G.Descripcion, G.Fecha, G.FechaIngreso, G.Monto, G.Estado, G.IdVersion
	FROM Gasto AS G
	WHERE (DATEPART (year,G.Fecha) = DATEPART (year,@Fecha)) AND (DATEPART (month,G.Fecha) = DATEPART (month,@Fecha))AND(DATEPART (day,G.Fecha) = DATEPART (day,@Fecha))
	
END