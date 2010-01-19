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
-- ===============================================
USE [BddProy2]
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Claudio Melcón/Edgar Ruiz>
-- Create date: <15/01/2010>
-- Description:	<Insert Contacto>
-- =============================================
CREATE PROCEDURE [dbo].[InsertarContacto] 
	-- Add the parameters for the stored procedure here
	

@Nombre varchar(20),
@Apellido varchar(20),
@AreaNegocio varchar(15),
@Cargo varchar(30),
@TelefonoTrabajo int,
@TelefonoCelular int,
@CodigoCel int,
@CodigoArea int,
@Tipo varchar (50),
@IdCliente int,
@ID int


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into [BddProy2].[dbo].[Contacto] (Nombre,Apellido,AreaNegocio,Cargo,IdCliente) values
	(@Nombre,@Apellido,@AreaNegocio,@Cargo,1);

Select @ID=IdContacto 
from [BddProy2].[dbo].[Contacto] as C
where C.Nombre=@Nombre and C.Apellido=@Apellido and C.Cargo=@Cargo;


INSERT INTO [BddProy2].[dbo].[Telefono] (CodigoArea,Numero,Tipo,IdContacto)
     VALUES
           (@CodigoCel,@TelefonoCelular,'Celular',@ID);


INSERT INTO [BddProy2].[dbo].[Telefono] (CodigoArea,Numero,Tipo,IdContacto)
     VALUES
           (@CodigoArea,@TelefonoTrabajo,@Tipo,@ID);


END
GO
