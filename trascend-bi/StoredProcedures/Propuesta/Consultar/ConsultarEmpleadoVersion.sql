USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[ConsultarEmpleadoVersion]    Fecha de la secuencia de comandos: 02/02/2010 02:11:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[ConsultarEmpleadoVersion] 
	-- Add the parameters for the stored procedure here
	@IdPropuesta as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT E.Nombre, Eq.HorasParticipadas FROM Empleado E, Equipo Eq, Version V, Propuesta P 
WHERE (E.IdEmpleado = Eq.IdEmpleado)AND(Eq.IdVersion = V.IdVersion)AND(V.IdPropuesta = P.IdPropuesta)AND(V.Status = 2)AND(P.IdPropuesta = @IdPropuesta)
END
