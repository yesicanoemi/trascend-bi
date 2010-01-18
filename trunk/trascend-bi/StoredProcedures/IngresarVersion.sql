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
CREATE PROCEDURE [dbo].[IngresarVersion]
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
values (@Version, 'En espera', @FechaFirma, @FechaIngreso,@FechaInicio,@FechaFin,'J-64738296-7',1,@IdPropuesta)

END
GO
