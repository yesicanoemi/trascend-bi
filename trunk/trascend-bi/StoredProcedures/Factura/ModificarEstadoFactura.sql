USE [BddProy2]
GO
/****** Object:  StoredProcedure [dbo].[ModificarEstadoFactura]    Script Date: 01/29/2010 23:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModificarEstadoFactura]
	-- Add the parameters for the stored procedure here
	@IdFactura int,
	@Estado varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.Factura
	SET Estado = (SELECT ID FROM dbo.EstadoFactura WHERE Nombre = @Estado),
		Fecha = GETDATE()
	WHERE IdFactura = @IdFactura
END