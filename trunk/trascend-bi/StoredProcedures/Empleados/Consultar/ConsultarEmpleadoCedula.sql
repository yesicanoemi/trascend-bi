ALTER PROCEDURE dbo.ConsultarEmpleadoCI(@ced int)
AS SELECT     A.Nombre, A.Apellido, A.CIEmpleado, A.NumCuenta, A.FechaNac, A.Estado, b.Nombre AS Expr1, c.Calle, c.Avenida, c.Urbanizacion, c.EdifCasa, 
                      c.PisoApto, c.Ciudad
FROM         Empleado A, Cargo b, Direccion c
WHERE       b.IdCargo = A.IdCargo AND
            c.IdDireccion = A.IdDireccion
            AND A.CIEmpleado = @ced
	/* SET NOCOUNT ON */
	RETURN