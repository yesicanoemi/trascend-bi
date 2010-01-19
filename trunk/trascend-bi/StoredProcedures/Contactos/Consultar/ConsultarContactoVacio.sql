-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[ConsultarContacto]    Fecha de la secuencia de comandos: 01/15/2010 16:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarContactoVacio]

@nombre		varchar(100),
@apellido	varchar(100),
@codigoArea int,
@Numero     int

AS
BEGIN

SET NOCOUNT ON;

	SELECT C.NOMBRE AS NOMBRE, C.APELLIDO AS APELLIDO, C.AREANEGOCIO AS AREA, C.CARGO AS CARGO, T.CODIGOAREA AS CODIGOAREA, T.NUMERO AS NUMERO, T.TIPO AS TIPO
		FROM dbo.Contacto C, dbo.Telefono T
        WHERE T.IdContacto=C.IdContacto
		order by C.IdContacto;

END;
