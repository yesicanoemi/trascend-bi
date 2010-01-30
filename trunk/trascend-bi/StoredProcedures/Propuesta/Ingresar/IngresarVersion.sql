USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[IngresarVersion]    Fecha de la secuencia de comandos: 01/29/2010 15:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[IngresarVersion]
	-- Add the parameters for the stored procedure here
	@Version int,
	@FechaFirma DateTime,
	@FechaIngreso DateTime,
	@FechaInicio DateTime,
	@FechaFin DateTime,
	@IdPropuesta Int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Version
values (@Version, 2, @FechaFirma, @FechaIngreso,@FechaInicio,@FechaFin,1,1,@IdPropuesta)

END
