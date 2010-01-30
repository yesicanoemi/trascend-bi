set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: <Dinangela Rojas, Daniel Trejo>
-- Create date: <29/01/2010>
-- Description: <Consulta de Contacto por Id>
-- =============================================

CREATE PROCEDURE [dbo].[ConsultarContactoxId_3]

@IdContacto int

AS
BEGIN

SET NOCOUNT ON;
SELECT C.NOMBRE, C.APELLIDO, C.AREANEGOCIO, C.CARGO, CL.Nombre, C.IdContacto
FROM dbo.contacto C, dbo.cliente CL
WHERE ((C.IdCliente = CL.IdCliente) and (C.IdContacto = @IdContacto))
END
