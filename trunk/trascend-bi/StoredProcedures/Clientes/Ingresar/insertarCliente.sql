set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[InsertarCliente]

	@rif varchar(50),
	@nombre varchar(50),
	@calleAv varchar(50),
	@urb varchar(50),
	@EdiCas varchar(50),
	@PisoApto varchar(50),
	@Ciudad varchar(50),
	@AreaNeg varchar(50),
	@Tlf varchar(50),
	@codTlf varchar(50),
	@tipoTelf varchar(50)
	             
AS


declare @clienteId int;


BEGIN

	insert into cliente (RifCliente,nombre,areanegocio) 
	values(@rif,@nombre,@AreaNeg);

	select @clienteId = (Select @@IDENTITY);
	
	insert into direccion (calle, avenida, urbanizacion, edifcasa, pisoapto, ciudad,IdCliente,IdEmpleado) 

	values(@CalleAv,@CalleAv,@Urb,@EdiCas,@PisoApto,@Ciudad,@clienteId,null);


	insert into telefono (codigoarea,numero,tipo,idCliente,idContacto)
	values (@codTlf,@Tlf,@tipoTelf,@clienteId,null);

END


