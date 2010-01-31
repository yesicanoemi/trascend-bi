-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Eduardo Rotundo>
-- Create date: <19/01/10>
-- Description:	<Ingresar Empleado>
-- =============================================
ALTER PROCEDURE InsertarEmpleado 
	-- Add the parameters for the stored procedure here
	@cedula int,
	@nombreEmpleado varchar(50),
	@apellidoEmpleado varchar(50),
	@numeroCta varchar(50),
	@fechaNac datetime,
	@estado int,
	@sueldo varchar(50),
	@cargo int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.Empleado (CIEmpleado,Nombre,Apellido,NumCuenta,FechaNac,Estado,Sueldo,IdCargo) VALUES (@cedula,@nombreEmpleado,@apellidoEmpleado,@numeroCta,@fechaNac,@estado,@sueldo,@cargo)
	SELECT @@identity
END
GO
