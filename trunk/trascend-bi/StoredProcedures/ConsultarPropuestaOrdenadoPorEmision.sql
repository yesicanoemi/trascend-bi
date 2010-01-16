set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarPropuestaOrdenadoPorEmision] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT    P.IdPropuesta, P.Titulo, V.NumeroVersion, V.FechaFirma, R.Nombre, R.Apellido, C.Nombre AS Cargo, V.FechaInicio, V.FechaFin, P.Monto
FROM         Receptor AS R INNER JOIN
                      Version AS V ON R.IdReceptor = V.IdReceptor INNER JOIN
                      Cargo AS C ON R.IdCargo = C.IdCargo CROSS JOIN
                      Propuesta AS P
WHERE     (V.Status = 'Aprobada') AND (P.Estado = 'Activo') AND (V.IdPropuesta = P.IdPropuesta) ORDER BY V.FechaInicio
END
