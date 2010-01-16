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
CREATE PROCEDURE [dbo].[FacturasEmitidas]

	@FechaIngreso1 smalldatetime,
	@FechaIngreso2 smalldatetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SELECT F.NumeroFactura, F.Titulo, F.Descripcion, F.FechaIngreso, F.Estado, P.Titulo  
	from dbo.Factura F, dbo.Propuesta P
	WHERE ((P.IdPropuesta = F.IdPropuesta) and (F.FechaIngreso BETWEEN @FechaIngreso1 AND @FechaIngreso2))

END

GO
