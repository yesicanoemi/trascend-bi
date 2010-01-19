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
CREATE PROCEDURE [dbo].[ModificarContacto] 
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
@ID int,
@NombreM varchar(20),
@ApellidoM varchar(20),
@AreaNegocioM varchar(15),
@CargoM varchar(30),
@TelefonoTrabajoM int,
@TelefonoCelularM int,
@CodigoCelM int,
@CodigoAreaM int,
@TipoM varchar (50),
@IdClienteM int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


Select @ID=IdContacto 
from [BddProy2].[dbo].[Contacto] as C
where C.Nombre=@Nombre and C.Apellido=@Apellido and C.Cargo=@Cargo;


UPDATE [BddProy2].[dbo].[Contacto]
SET Nombre=@NombreM, Apellido=@ApellidoM,AreaNegocio=@AreaNegocioM,Cargo=@CargoM
WHERE IdContacto=@ID;

UPDATE [BddProy2].[dbo].[Telefono]
SET CodigoArea=@CodigoAreaM, Numero=@TelefonoTrabajoM,Tipo=@TipoM
WHERE IdContacto=@ID and Tipo='Trabajo';

UPDATE [BddProy2].[dbo].[Telefono]
SET CodigoArea=@CodigoAreaM, Numero=@TelefonoTrabajoM,Tipo=@TipoM
WHERE IdContacto=@ID and Tipo='Fax';

UPDATE [BddProy2].[dbo].[Telefono]
SET CodigoArea=@CodigoCelM, Numero=@TelefonoCelularM,Tipo=@TipoM
WHERE IdContacto=@ID and Tipo='Celular';

END
GO
