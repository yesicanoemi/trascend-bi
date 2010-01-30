set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[InsertarTelefono]

	@Tlf int,
	@codTlf int,
	@tipoTelf int,
	@clienteId int
	             
AS

BEGIN

	insert into telefono (codigoarea,numero,IdTipoTelefono,idCliente,idContacto)
	values (@codTlf,@Tlf,@tipoTelf,@clienteId,null);

END
