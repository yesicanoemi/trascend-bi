USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[ConsultarGastoPorTipo]    Fecha de la secuencia de comandos: 01/18/2010 14:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[ConsultarGastoPorTipo]

	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  G.IdGasto, G.Tipo, G.Descripcion, G.Fecha, G.FechaIngreso, G.Monto, G.Estado, G.IdVersion
	FROM Gasto AS G
	
END
