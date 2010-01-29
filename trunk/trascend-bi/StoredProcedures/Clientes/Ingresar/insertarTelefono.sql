set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarTelefono]

	@Tlf varchar(50),
	@codTlf varchar(50),
	@tipoTelf int,
	@clienteId int
	             
AS

BEGIN

	insert into telefono (codigoarea,numero,IdTipoTelefono,idCliente,idContacto)
	values (@codTlf,@Tlf,@tipoTelf,@clienteId,null);

END