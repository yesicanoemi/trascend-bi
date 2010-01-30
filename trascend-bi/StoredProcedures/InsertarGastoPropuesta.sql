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
CREATE PROCEDURE [dbo].[InsertarGastoPropuesta]
	-- Add the parameters for the stored procedure here

	@estado varchar(50),
	@monto float,
	@fechaGasto datetime,
	@fechaIngreso datetime,
	@tipo varchar(50),
	@descripcion varchar(60),
	@propuesta int,
	@version int	

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT NumeroVersion into version FROM dbo.Version where IdPropuesta = @propuesta;

	insert into dbo.Gasto (Tipo,Descripcion,Fecha,FechaIngreso,Monto,Estado,NumeroVersion)
	values(@tipo,@descripcion,@fechaGasto,@fechaIngreso,@monto,@estado,@version);

END
GO
