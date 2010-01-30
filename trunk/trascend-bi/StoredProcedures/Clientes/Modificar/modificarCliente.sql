set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarCliente]

	@rif varchar(50),
	@nombre varchar(50),
	@calleAv varchar(50),
	@urb varchar(50),
	@EdiCas varchar(50),
	@PisoApto varchar(50),
	@Ciudad varchar(50),
	@AreaNeg varchar(50),
	@IdCliente int
	             
AS


declare @clienteId int;


BEGIN

	update Cliente set RifCliente = @rif, nombre = @nombre, areanegocio = @AreaNeg
	where IdCliente = @IdCliente;

	update direccion set calle = @calleAv, avenida = @calleAv, urbanizacion = @urb, 
							edifcasa = @EdiCas, pisoapto = @PisoApto, ciudad = @Ciudad
	where IdCliente = @IdCliente; 

END
