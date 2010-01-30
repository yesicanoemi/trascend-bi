USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[CPCliente]    Fecha de la secuencia de comandos: 01/29/2010 17:25:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[CPCliente] 
	-- Add the parameters for the stored procedure here
	@Parametro varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT P.*,V.*
FROM Propuesta P, Version V, Cliente C
WHERE (C.RifCliente like '%'+@Parametro+'%')AND(V.IdCliente = C.IdCliente)AND(P.IdPropuesta = V.IdPropuesta)AND(P.Estado=1)AND(V.IdVersion = (SELECT MAX(Ve.IdVersion)FROM Version Ve WHERE (Ve.IdPropuesta = P.IdPropuesta)))
END
