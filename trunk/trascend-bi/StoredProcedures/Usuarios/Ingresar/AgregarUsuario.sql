USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[ConsultarUsuario]    Fecha de la secuencia de comandos: 01/17/2010 17:47:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarUsuario]

@LoginUsuario varchar(20),
@Password varchar(20),
@Status varchar(20),
@IdEmpleado int

AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

INSERT INTO usuario
VALUES (@LoginUsuario,@Password,@Status,@IdEmpleado)

END