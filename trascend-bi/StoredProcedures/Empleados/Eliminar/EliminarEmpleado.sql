alter PROCEDURE dbo.EliminarEmpleado

@id int
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

UPDATE [BddProy2].[dbo].[Empleado]
   SET Estado = 2
 WHERE IdEmpleado = @id

							
END

     