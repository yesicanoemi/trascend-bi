set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: <Dinangela Rojas, Daniel Trejo>
-- Create date: <31/01/2010>
-- Description: <Modificar Contacto>
-- =============================================

CREATE PROCEDURE [dbo].[ModificarContacto_3]

@IdContacto int,
@IdCliente int,
@Area varchar(100),
@Cargo varchar(100),
@Apellido varchar(100),
@Nombre varchar(100)

AS
BEGIN

SET NOCOUNT ON;

UPDATE dbo.Contacto

SET Nombre = @Nombre,
Apellido = @Apellido,
AreaNegocio = @Area,
Cargo = @Cargo,
IdCliente = @IdCliente

WHERE IdContacto = @IdContacto

END