USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[IngresarPropuesta]    Fecha de la secuencia de comandos: 01/29/2010 15:08:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[IngresarPropuesta] 
	-- Add the parameters for the stored procedure here
	@Titulo Varchar(50),
	@MontoTotal float
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;
	
	
	
    -- Insert statements for procedure here
	INSERT INTO Propuesta (Titulo,Monto,Estado) values (@Titulo,@MontoTotal,1)

END
