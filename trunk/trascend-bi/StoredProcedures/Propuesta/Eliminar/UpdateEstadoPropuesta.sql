USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[UpdateEstadoPropuesta]    Fecha de la secuencia de comandos: 01/29/2010 15:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[UpdateEstadoPropuesta] 
	-- Add the parameters for the stored procedure here
	@Titulo Varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Propuesta SET Estado = 2 WHERE (Titulo = @Titulo)
END
