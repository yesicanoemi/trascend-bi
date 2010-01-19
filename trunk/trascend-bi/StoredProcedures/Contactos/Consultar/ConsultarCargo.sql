USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[ConsultarContacto]    Fecha de la secuencia de comandos: 01/15/2010 16:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarCargo]


AS
BEGIN

SET NOCOUNT ON;
	
	SELECT C.NOMBRE AS NOMBRE
    FROM dbo.cargo C;
	
	
END;