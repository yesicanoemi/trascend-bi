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
CREATE PROCEDURE [dbo].[ConsultarReceptorVersion] 
	-- Add the parameters for the stored procedure here
	@IdPropuesta int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT R.Nombre, R.Apellido, C.Nombre 
FROM   Receptor R, Cargo C, Version V
WHERE  (V.IdPropuesta = @IdPropuesta)AND(V.IdReceptor = R.IdReceptor)AND(R.IdCargo = C.IdCargo)
END
GO
