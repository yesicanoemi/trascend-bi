USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[ConsultarUsuario]    Fecha de la secuencia de comandos: 01/16/2010 15:30:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarPermisoUsuario]

@LoginUsuario varchar(20),
@IdPermiso int

AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

INSERT INTO PermisoUsuario
VALUES (@LoginUsuario,@IdPermiso)

END