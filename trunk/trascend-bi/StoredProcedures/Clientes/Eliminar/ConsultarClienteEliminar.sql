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
CREATE PROCEDURE [dbo].[ConsultarClienteEliminar] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT [Nombre]
FROM [BddProy2].[dbo].[Cliente]
END