USE [BddProy2]
GO
/****** Object:  StoredProcedure [dbo].[EliminarCargo]    Script Date: 01/16/2010 23:10:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EliminarCargo]
	-- Add the parameters for the stored procedure here
	@IdCargo int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE 
	FROM dbo.Cargo
	WHERE IdCargo = @IdCargo
END
