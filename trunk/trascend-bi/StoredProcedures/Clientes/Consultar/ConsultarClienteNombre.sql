
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[ConsultarClienteNombre]
	-- Add the parameters for the stored procedure here
	@NombreCliente varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT  c.IdCliente,c.RifCliente,c.Nombre,c.AreaNegocio, d.Calle as CalleAvenidad,d.Urbanizacion,d.EdifCasa as EdificioCasa, 
		d.Ciudad,d.PisoApto as PisoApartamento, convert(varchar,t.Numero) as TelefonoTrabajo, convert(varchar,t.codigoArea) as CodigoTelefonoTrabajo, t.Tipo
		from [bddproy2].[dbo].[cliente] c, [bddproy2].[dbo].[direccion] d, [bddproy2].[dbo].[telefono] t
		where c.IdCliente=d.IdCliente and c.IdCliente=t.IdCliente
		and c.Nombre like '%'+@NombreCliente+'%';
END

