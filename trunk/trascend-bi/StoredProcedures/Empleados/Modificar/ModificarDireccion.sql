-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE ModificarDireccion
	-- Add the parameters for the stored procedure here
	@cedula int,
	@avenida varchar(50),
	@calle varchar(10),
	@ciudad varchar(50),
	@edif varchar(15),
	@piso varchar(15),
	@urbanizacion varchar(15)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.Direccion 
    SET Calle=@calle,
    Avenida=@avenida,
    Urbanizacion=@urbanizacion,
    EdifCasa=@edif,
    PisoApto=@piso,
    Ciudad=@ciudad 
    WHERE IdEmpleado = (SELECT IdEmpleado from Empleado where Empleado.CIEmpleado=@cedula)
END