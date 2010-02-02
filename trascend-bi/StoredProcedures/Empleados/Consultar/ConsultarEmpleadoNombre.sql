alter PROCEDURE dbo.ConsultarEmpleadoNombre

@nombre varchar(20)
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

SELECT     A.Nombre, A.Apellido, A.CIEmpleado, A.IdEmpleado,
		   
			A.NumCuenta, A.FechaNac, A.Estado, b.Nombre AS Expr1, 

			c.Calle, c.Avenida, c.Urbanizacion, c.EdifCasa, 
                      
			c.PisoApto, c.Ciudad

FROM         [BddProy2].[dbo].[Empleado] A, 
			 [BddProy2].[dbo].[Cargo] b, 
			 [BddProy2].[dbo].[Direccion] c

WHERE        b.IdCargo = A.IdCargo AND
            c.IdEmpleado = A.IdEmpleado
            AND A.Nombre LIKE '%'+@nombre+'%'
							
END

     