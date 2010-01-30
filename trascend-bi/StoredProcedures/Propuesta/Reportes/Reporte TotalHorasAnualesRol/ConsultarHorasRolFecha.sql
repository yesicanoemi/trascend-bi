USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[ConsultarHorasRolFecha]    Fecha de la secuencia de comandos: 01/19/2010 05:44:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarHorasRolFecha] 
	-- Add the parameters for the stored procedure here
	@FechaI DateTime,
	@FechaF DateTime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Eq.Rol, Eq.HorasParticipadas 
FROM EQUIPO Eq, Version V 
WHERE (Eq.IdVersion  = V.IdVersion)AND(V.FechaInicio BETWEEN @FechaI AND @FechaF)AND(V.FechaFin BETWEEN @FechaI AND @FechaF)
END
