USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[ConsultarGastoNomCli]    Fecha de la secuencia de comandos: 01/30/2010 21:15:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarGastoNomCli] 
	-- Add the parameters for the stored procedure here
	@Parametro varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT G.IdGasto, G.Tipo, G.Descripcion, G.Fecha, G.FechaIngreso, G.Monto, G.Estado, G.IdVersion
FROM Gasto G
WHERE (G.IdVersion = (SELECT V.IdVersion
							  FROM Version AS V
							  WHERE V.Status = 1 and V.IdCliente = (SELECT C.IdCliente 
												     FROM Cliente C
							                         WHERE  C.Nombre like '%'+@Parametro+'%')))
END
