USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[ConsultarPropuestasVersiones]    Fecha de la secuencia de comandos: 01/29/2010 14:56:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[ConsultarPropuestasVersiones] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

SELECT  P.IdPropuesta,P.Titulo, V.NumeroVersion, V.FechaFirma, R.Nombre, R.Apellido, C.Nombre AS Cargo, V.FechaInicio, V.FechaFin, P.Monto
FROM Receptor AS R INNER JOIN
                      Version AS V ON R.IdReceptor = V.IdReceptor INNER JOIN
                      Cargo AS C ON R.IdCargo = C.IdCargo CROSS JOIN
                      Propuesta AS P
WHERE ( P.IdPropuesta = V.IdPropuesta ) AND (P.Estado = 1) AND 
( V.NumeroVersion = ( SELECT max(VE.NumeroVersion) FROM Version VE WHERE ( VE.Status=2 ) AND (VE.IdPropuesta=P.IdPropuesta)))

END

                    