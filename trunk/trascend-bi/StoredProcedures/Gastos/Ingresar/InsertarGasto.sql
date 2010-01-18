USE [BddProy2]
GO
/****** Objeto:  StoredProcedure [dbo].[InsertarGasto]    Fecha de la secuencia de comandos: 01/16/2010 02:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertarGasto] 
	-- Add the parameters for the stored procedure here

	@estado varchar(50),
	@monto float,
	@fechaGasto datetime,
	@fechaIngreso datetime,
	@tipo varchar(50),
	@descripcion varchar(60)
	--@propuesta int,
	--@version int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--SELECT NumeroVersion into version FROM dbo.Version where IdPropuesta = @propuesta;

	insert into dbo.Gasto (Tipo,Descripcion,Fecha,FechaIngreso,Monto,Estado,IdVersion)
	values(@tipo,@descripcion,@fechaGasto,@fechaIngreso,@monto,@estado,null);

END
