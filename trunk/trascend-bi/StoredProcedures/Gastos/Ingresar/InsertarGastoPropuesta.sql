USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[InsertarGastoPropuesta]    Fecha de la secuencia de comandos: 01/17/2010 01:01:18 ******/
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
	@version int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	insert into dbo.Gasto (Tipo,Descripcion,Fecha,FechaIngreso,Monto,Estado,IdVersion)
	values(@tipo,@descripcion,@fechaGasto,@fechaIngreso,@monto,@estado,@version);

END
