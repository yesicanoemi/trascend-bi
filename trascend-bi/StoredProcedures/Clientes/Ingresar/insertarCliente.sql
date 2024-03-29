set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarCliente]

	@rif varchar(50),
	@nombre varchar(50),
	@calleAv varchar(50),
	@urb varchar(50),
	@EdiCas varchar(50),
	@PisoApto varchar(50),
	@Ciudad varchar(50),
	@AreaNeg varchar(50)
	             
AS


declare @clienteId int;


BEGIN

	insert into cliente (RifCliente,nombre,areanegocio,Estatus) 
	values(@rif,@nombre,@AreaNeg,1);

	select @clienteId = (Select @@IDENTITY);
	
	insert into direccion (calle, avenida, urbanizacion, edifcasa, pisoapto, ciudad,IdCliente,IdEmpleado) 

	values(@CalleAv,@CalleAv,@Urb,@EdiCas,@PisoApto,@Ciudad,@clienteId,null);
	
	select * from cliente cli where cli.IdCliente = @clienteId;

END