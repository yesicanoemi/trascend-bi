USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[ConsultarHorasRol]    Fecha de la secuencia de comandos: 01/17/2010 05:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[ConsultarHorasRol] 
	-- Add the parameters for the stored procedure here
	@Rol Varchar(50) 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT SUM(HorasParticipadas) as TotalHoras FROM Equipo  WHERE (Rol = @Rol)
END
