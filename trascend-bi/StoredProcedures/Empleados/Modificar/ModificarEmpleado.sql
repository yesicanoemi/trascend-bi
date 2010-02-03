-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE ModificarEmpleado
	-- Add the parameters for the stored procedure here
	@id int,
	@nombreEmpleado varchar(50),
	@apellidoEmpleado varchar(50),
	@numeroCta varchar(50),
	@fechaNac datetime,
	@sueldo float,
	@cargo int,
    @Estado int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.Empleado 
    SET Nombre = @nombreEmpleado,
    Apellido = @apellidoEmpleado,
    NumCuenta = @numeroCta,
    IdCargo = @cargo,
    FechaNac = @fechaNac,
    Sueldo =  @sueldo,
    Estado = @Estado
    where CIEmpleado = @id
    
END