USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[ModificarPropuesta]    Fecha de la secuencia de comandos: 01/29/2010 15:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[ModificarPropuesta]
	-- Add the parameters for the stored procedure here
	@IdPropuesta int,
	@IdVersion int,
	@titulo varchar(100),
	@Monto float,
	@Estado int,
    @NumeroVersion int,
	@Status int,
	@FechaFirma datetime,
	@FechaIngreso datetime,
	@FechaInicio datetime,
	@FechaFin datetime
AS

BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.Propuesta
	SET Titulo = @Titulo,
		Monto = @Monto,
		Estado = @Estado
	WHERE IdPropuesta = @IdPropuesta

    UPDATE dbo.Version
	SET NumeroVersion = @NumeroVersion,
		Status = @Status,
		FechaFirma = @FechaFirma,
		FechaIngreso = @FechaIngreso,
		FechaInicio = @FechaInicio,
		FechaFin = @FechaFin
    WHERE (IdPropuesta = @IdPropuesta) AND (IdVersion = @IdVersion)

END
