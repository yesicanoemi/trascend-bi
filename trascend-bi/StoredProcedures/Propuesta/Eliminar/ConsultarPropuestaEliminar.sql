USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[ConsultarPropuestaEliminar]    Fecha de la secuencia de comandos: 01/17/2010 18:25:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarPropuestaEliminar] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT P.Titulo
FROM Version V, Propuesta P
WHERE (P.IdPropuesta =V.IdPropuesta)AND(P.Estado = 'Activo')AND(V.NumeroVersion = (SELECT max(NumeroVersion) FROM Version WHERE ((V.Status<>'En Espera')AND(V.Status<>'Aprobada'))))
END
