USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[ConsultarPropuesta]    Fecha de la secuencia de comandos: 01/29/2010 14:45:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[ConsultarPropuesta] 
	-- Add the parameters for the stored procedure here
	@Estado int
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
WHERE     (V.Status = @Estado) AND (P.Estado = 1) AND (V.IdPropuesta = P.IdPropuesta)
END