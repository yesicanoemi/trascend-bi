USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[ConsultarIdCargo]    Fecha de la secuencia de comandos: 01/17/2010 15:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarIdCargo]
	-- Add the parameters for the stored procedure here
	@Nombre Varchar(20)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT IDCARGO FROM CARGO WHERE Nombre = @Nombre
END
