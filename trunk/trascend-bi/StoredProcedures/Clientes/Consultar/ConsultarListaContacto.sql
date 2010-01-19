USE [BddProy2]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[ConsultarListaContacto]
@IdCliente int

	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT  c.Nombre, c.Apellido		
		from [bddproy2].[dbo].[contacto] c, [bddproy2].[dbo].[cliente] cl
		where c.IdCliente=Cl.idCliente and cl.IdCliente = @IdCliente;
END