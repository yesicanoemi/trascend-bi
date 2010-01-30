USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[ConsultarGastoPorFecha]    Fecha de la secuencia de comandos: 01/19/2010 23:59:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarGastoPorEstado]

	-- Add the parameters for the stored procedure here
	@Estado varchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  G.IdGasto, G.Tipo, G.Descripcion, G.Fecha, G.FechaIngreso, G.Monto, G.Estado, G.IdVersion
	FROM Gasto AS G
	WHERE G.Estado <= @Estado
	
END