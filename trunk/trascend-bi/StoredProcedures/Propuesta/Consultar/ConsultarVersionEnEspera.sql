USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[ConsultarVersionEnEspera]    Fecha de la secuencia de comandos: 01/29/2010 14:58:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[ConsultarVersionEnEspera] 
	-- Add the parameters for the stored procedure here
	@IdPropuesta as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT E.Nombre FROM Empleado E, Equipo Eq, Version V, Propuesta P 
WHERE (E.IdEmpleado = Eq.IdEmpleado)AND(Eq.IdVersion = V.IdVersion)AND(V.IdPropuesta = P.IdPropuesta)AND(V.Status = 2)AND(P.IdPropuesta = @IdPropuesta)
END
