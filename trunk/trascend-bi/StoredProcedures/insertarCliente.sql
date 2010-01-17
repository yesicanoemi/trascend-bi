set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[InsertarCliente]

	@rif varchar(20),
	@nombre varchar(20),
	@calleAv varchar(10),
	@urb varchar(15),
	@EdiCas varchar(15),
	@PisoApto varchar(15),
	@Ciudad varchar(15),
	@AreaNeg varchar(15),
	@Tlf int,
	@codTlf int
	             
AS

declare @direccionId int;
declare @clienteId int;


BEGIN

	insert into direccion (calle, avenida, urbanizacion, edifcasa, pisoapto, ciudad) 

	values(@CalleAv,@CalleAv,@Urb,@EdiCas,@PisoApto,@Ciudad);


	select @direccionId = (Select @@IDENTITY);

	insert into cliente (RifCliente,nombre,areanegocio,iddireccion) 
	values(@rif,@nombre,@AreaNeg,@direccionId);

	select @clienteId = (Select @@IDENTITY);

	insert into telefono (codigoarea,numero,tipo,idCliente,idContacto)
	values (@codTlf,@Tlf,'Trabajo',@clienteId,null);

END

