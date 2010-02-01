USE [BddProy2]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Dinangela Rojas, Daniel Trejo>
-- Create date: <30/01/2010> 
-- Description:	<Elimina el contacto por IdContacto>
-- =============================================

CREATE PROCEDURE [dbo].[EliminarContacto_3]

@IdContacto int

AS
BEGIN

SET NOCOUNT ON;

	DELETE FROM dbo.Contacto
	WHERE IdContacto = @IdContacto

END 