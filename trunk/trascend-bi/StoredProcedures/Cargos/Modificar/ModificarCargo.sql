USE [BddProy2]
GO
/****** Object:  StoredProcedure [dbo].[ModificarCargo]    Script Date: 01/16/2010 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModificarCargo]
	-- Add the parameters for the stored procedure here
	@IdCargo int,
	@NombreCargo varchar(20),
	@Descripcion varchar(100),
	@SueldoMinimo float,
	@SueldoMaximo float,
	@VigenciaAnual smalldatetime
AS

BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.Cargo
	SET Nombre = @NombreCargo, 
		Descripcion = @Descripcion,
		SueldoMinimo = @SueldoMinimo,
		SueldoMaximo = @SueldoMaximo,
		VigenciaAnual = @VigenciaAnual
	WHERE IdCargo = @IdCargo
END
