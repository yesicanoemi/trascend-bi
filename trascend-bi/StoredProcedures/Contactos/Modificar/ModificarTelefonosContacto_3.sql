set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: <Dinangela Rojas, Daniel Trejo>
-- Create date: <31/01/2010>
-- Description: <Modificar Teléfonos de Contacto>
-- =============================================

CREATE PROCEDURE [dbo].[ModificarTelefonosContacto_3]

@IdContacto int,
@Codigo int,
@Numero int,
@Tipo int

AS
BEGIN

SET NOCOUNT ON;

INSERT INTO dbo.telefono (CodigoArea,Numero,IdTipoTelefono,IdCliente,IdContacto)

values (@Codigo,@Numero,@Tipo,null,@IdContacto);

END

