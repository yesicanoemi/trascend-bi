set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[ConsultarClienteNombre]
	-- Add the parameters for the stored procedure here
@nombre varchar(20)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT  c.IdCliente,c.RifCliente,c.Nombre,c.AreaNegocio, d.Calle as CalleAvenidad,d.Urbanizacion,d.EdifCasa as EdificioCasa, 
		d.Ciudad,d.PisoApto as PisoApartamento
		from [bddproy2].[dbo].[cliente] c, [bddproy2].[dbo].[direccion] d
		where c.IdCliente=d.IdCliente and c.Nombre like @nombre+'%' and c.Estatus = 1;
END