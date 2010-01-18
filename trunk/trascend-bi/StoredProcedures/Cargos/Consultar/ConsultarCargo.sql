USE [BddProy2]
GO
/****** Object:  StoredProcedure [dbo].[ConsultarCargo]    Script Date: 01/16/2010 23:07:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarCargo]
	-- Add the parameters for the stored procedure here
	@NombreCargo varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT C.IdCargo, C.Nombre, C.Descripcion, C.SueldoMinimo, C.SueldoMaximo, C.VigenciaAnual
	FROM dbo.Cargo C
	WHERE C.Nombre = @NombreCargo
END
