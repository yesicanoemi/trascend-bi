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
-- Description:	<Insertar la direccion del empleado>
-- =============================================
CREATE PROCEDURE InsertarDireccionEmpleado 
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
	INSERT INTO dbo.Direccion (Calle,Avenida,Urbanizacion,EdifCasa,PisoApto,Ciudad,IdEmpleado) VALUES (@calle,@avenida,@urbanizacion,@edif,@piso,@ciudad,@cedula)
END
GO
