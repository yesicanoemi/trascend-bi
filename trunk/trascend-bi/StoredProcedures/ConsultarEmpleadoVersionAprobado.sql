USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[ConsultarEmpleadoVersionAprobado]    Fecha de la secuencia de comandos: 01/16/2010 20:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[ConsultarEmpleadoVersionAprobado] 
	-- Add the parameters for the stored procedure here
@IdPropuesta int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT E.Nombre FROM Empleado E, Equipo Eq, Version V, Propuesta P 
WHERE (E.IdEmpleado = Eq.IdEmpleado)AND(Eq.IdVersion = V.IdVersion)AND(V.IdPropuesta = P.IdPropuesta)AND(V.Status = 'Aprobada')AND(P.IdPropuesta = @IdPropuesta)
END
