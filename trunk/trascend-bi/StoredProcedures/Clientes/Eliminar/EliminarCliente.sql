USE [BddProy2]
GO
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
ALTER PROCEDURE [dbo].[EliminarCliente] 
	-- Add the parameters for the stored procedure here
	@Nombre Varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [BddProy2].[dbo].[Direccion]
	WHERE IdCliente = (Select Idcliente
                           from [BddProy2].[dbo].[Cliente] 
                           where nombre = @Nombre )

	DELETE FROM [BddProy2].[dbo].[Telefono]
	WHERE IdCliente = (Select Idcliente
                           from [BddProy2].[dbo].[Cliente] 
                           where Nombre = @Nombre) 


	DELETE FROM [BddProy2].[dbo].[Telefono]
	WHERE IdContacto  in   (Select o.IdContacto
			      from [BddProy2].[dbo].[Cliente] c,[BddProy2].[dbo].[Contacto]o
			      where c.IdCliente = o.IdCliente and c.Nombre = @Nombre)

	DELETE FROM [BddProy2].[dbo].[Contacto]
	WHERE IdCliente = (Select Idcliente
                           from [BddProy2].[dbo].[Cliente] 
                           where Nombre = @Nombre) 

	DELETE FROM [BddProy2].[dbo].[Equipo]
	WHERE IdVersion  =  (Select v.IdVersion
			     from [BddProy2].[dbo].[Version] v,[BddProy2].[dbo].[Cliente] c
			     where v.IdCliente = c.IdCliente and c.Nombre = @Nombre)

	DELETE FROM [BddProy2].[dbo].[Version]
	WHERE IdCliente = (Select Idcliente
                           from [BddProy2].[dbo].[Cliente] 
                           where Nombre = @Nombre) 

	DELETE FROM [BddProy2].[dbo].[Cliente]
	WHERE Nombre = @Nombre
END
GO
