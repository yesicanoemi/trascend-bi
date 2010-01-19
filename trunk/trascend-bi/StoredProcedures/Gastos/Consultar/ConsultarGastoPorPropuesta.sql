USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[ConsultarGastoPorPropuesta]    Fecha de la secuencia de comandos: 01/16/2010 20:39:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[ConsultarGastoPorPropuesta]

	-- Add the parameters for the stored procedure here
	@Titulo Varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT G.IdGasto, G.Tipo, G.Descripcion, G.Fecha, G.FechaIngreso, G.Monto, G.Estado
	FROM Gasto AS G
	WHERE (G.IdVersion = (SELECT V.IdVersion
							  FROM Version AS V
							  WHERE V.Status Like 'Aprobada' and V.IdPropuesta = (SELECT P.IdPropuesta 
												     FROM Propuesta AS P
							                         WHERE  P.Titulo like @Titulo)))	
END
