USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[ConsultarPropuestaEliminar]    Fecha de la secuencia de comandos: 01/29/2010 14:49:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[ConsultarPropuestaEliminar] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT P.Titulo
FROM Version V, Propuesta P
WHERE (P.IdPropuesta =V.IdPropuesta)AND(P.Estado = 1)AND(V.NumeroVersion = (SELECT max(NumeroVersion) FROM Version V2 WHERE ((V2.Status<>2)AND(V2.Status<>1)AND(V2.IdPropuesta=P.IdPropuesta))))
END
