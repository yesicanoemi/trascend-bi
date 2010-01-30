USE [BddProy2]
GO
/****** Object:  StoredProcedure [dbo].[IngresarFactura]    Script Date: 01/29/2010 23:18:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[IngresarFactura]
	-- Add the parameters for the stored procedure here
	@Titulo varchar(50),
	@Descripcion varchar(100),
	@Porcentaje float,
	@Fecha smalldatetime,
	@FechaIngreso smalldatetime,
	@Estado varchar(50),
	@TituloPropuesta varchar(100)
AS

DECLARE @IdEstado int,
		@IdPropuesta int;

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT @IdEstado = ID FROM dbo.EstadoFactura WHERE Nombre = @Estado;
	SELECT @IdPropuesta = IdPropuesta FROM dbo.Propuesta WHERE Titulo = @TituloPropuesta;

	INSERT INTO Factura (Titulo, Descripcion, Porcentaje, Fecha, FechaIngreso, 
				Estado, IdPropuesta)
	VALUES (@Titulo, @Descripcion, @Porcentaje, @Fecha, @FechaIngreso,
			@IdEstado,
			@IdPropuesta)

END