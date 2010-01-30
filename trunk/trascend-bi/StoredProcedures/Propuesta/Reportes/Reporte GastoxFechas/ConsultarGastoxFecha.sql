-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarGastoxFecha]
	-- Parametros
	@FechaInicio DateTime,
	@FechaFin DateTime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Se busca la entidad gasto comprendida entre la Fecha de Inicio y Fin
	Select G.Tipo AS Tipo,G.Descripcion AS Descripcion,G.Fecha AS Fecha,G.Monto AS Monto
	from Gasto G
	where G.Fecha Between @FechaInicio and @FechaFin
END
GO
