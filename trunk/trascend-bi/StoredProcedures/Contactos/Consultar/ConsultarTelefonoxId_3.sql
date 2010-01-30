set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: <Dinangela Rojas, Daniel Trejo>
-- Create date: <29/01/2010>
-- Description: <Consulta Telefono por Id de Contacto>
-- =============================================

CREATE PROCEDURE [dbo].[ConsultarTelefonoxId_3]

@IdContacto int

AS
BEGIN

SET NOCOUNT ON;
SELECT T.CodigoArea, T.Numero, TT.Nombre
FROM dbo.Telefono T, dbo.TipoTelefono TT
WHERE ((T.IdTipoTelefono = TT.ID) and (T.IdContacto = @IdContacto ))
END