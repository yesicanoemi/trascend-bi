set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sofia Ostos>
-- Create date: <30/01/2010>
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
@IdCliente int,
@ID int


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into [BddProy2].[dbo].[Contacto] (Nombre,Apellido,AreaNegocio,Cargo,IdCliente) values
	(@Nombre,@Apellido,@AreaNegocio,@Cargo,@IdCliente);

Select @ID=IdContacto 
from [BddProy2].[dbo].[Contacto] as C
where C.Nombre=@Nombre and C.Apellido=@Apellido and C.Cargo=@Cargo;


INSERT INTO [BddProy2].[dbo].[Telefono] (CodigoArea,Numero,IdTipoTelefono,IdContacto)
     VALUES
           (@CodigoCel,@TelefonoCelular,2,@ID);


INSERT INTO [BddProy2].[dbo].[Telefono] (CodigoArea,Numero,IdTipoTelefono,IdContacto)
     VALUES
           (@CodigoArea,@TelefonoTrabajo,1,@ID);

END


