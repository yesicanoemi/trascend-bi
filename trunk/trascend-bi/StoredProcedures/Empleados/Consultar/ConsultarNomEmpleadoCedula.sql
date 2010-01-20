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
-- Description:	<Consultar un empleado por su cedula y nombre>
-- =============================================
alter PROCEDURE ConsultarNomEmpleadoCedula 
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT CIEmpleado,Nombre,Apellido,NumCuenta,FechaNac,Estado,IdCargo,Sueldo from dbo.Empleado where IdEmpleado = @id
END
GO
