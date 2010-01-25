-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
alter PROCEDURE [dbo].[ConsultarClienteParametroNombre]
	-- Add the parameters for the stored procedure here
@Nombre varchar(20)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT  c.IdCliente as clienteId,c.RifCliente,c.Nombre,c.AreaNegocio, d.Calle as CalleAvenidad,d.Urbanizacion,d.EdifCasa as EdificioCasa, 
		d.Ciudad,d.PisoApto as PisoApartamento, convert(varchar,t.Numero) as TelefonoTrabajo, convert(varchar,t.codigoArea) as CodigoTelefonoTrabajo
		from [bddproy2].[dbo].[cliente] c, [bddproy2].[dbo].[direccion] d, [bddproy2].[dbo].[telefono] t
		where c.IdCliente=d.IdCliente and c.IdCliente=t.IdCliente and c.Nombre like '%'+@Nombre+'%' and c.Estatus=1;
END
GO