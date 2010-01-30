set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarTelefono]

	@Tlf int,
	@codTlf int,
	@tipoTelf int,
	@idCliente int
	             
AS

BEGIN

	update telefono set codigoarea = @codTlf, numero = @Tlf
	where IdCliente = @idCliente and IdTipoTelefono = @tipoTelf;

END