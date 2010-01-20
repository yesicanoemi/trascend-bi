ALTER PROCEDURE [dbo].[InsertarCliente]

	@rif varchar(20),
	@nombre varchar(20),
	@calleAv varchar(50),
	@urb varchar(15),
	@EdiCas varchar(15),
	@PisoApto varchar(15),
	@Ciudad varchar(15),
	@AreaNeg varchar(15),
	@Tlf int,
	@codTlf int,
	@tipoTelf varchar(10)
	             
AS


declare @clienteId int;


BEGIN

	insert into cliente (RifCliente,nombre,areanegocio) 
	values(@rif,@nombre,@AreaNeg);

	select @clienteId = (Select @@IDENTITY);
	
	insert into direccion (calle, avenida, urbanizacion, edifcasa, pisoapto, ciudad,IdCliente,IdEmpleado) 

	values(@CalleAv,@CalleAv,@Urb,@EdiCas,@PisoApto,@Ciudad,@clienteId,null);


	insert into telefono (codigoarea,numero,tipo,idCliente,idContacto)
	values (convert (int, @codTlf),convert(int,@Tlf),@tipoTelf,@clienteId,null);

END


