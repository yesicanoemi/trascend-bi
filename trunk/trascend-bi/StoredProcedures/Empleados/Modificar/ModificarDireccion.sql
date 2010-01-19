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
	UPDATE dbo.Direccion SET Calle=@calle,Avenida=@avenida,Urbanizacion=@urbanizacion,EdifCasa=@edif,PisoApto=@piso,Ciudad=@ciudad WHERE IdEmpleado = @cedula
END
GO
