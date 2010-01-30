set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[EliminarCliente]

	@IdCliente int
	             
AS

BEGIN

	update Cliente set Estatus = 0
	where IdCliente = @IdCliente;

END
