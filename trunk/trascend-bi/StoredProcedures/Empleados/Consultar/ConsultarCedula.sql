ALTER PROCEDURE dbo.ConsultarCedula
@ced int
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

SELECT     Count(A.IdEmpleado)

FROM         [BddProy2].[dbo].[Empleado] A 			 

WHERE       A.CIEmpleado = @ced 
END