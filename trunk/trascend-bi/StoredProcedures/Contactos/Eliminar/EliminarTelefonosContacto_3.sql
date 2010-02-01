USE [BddProy2]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Dinangela Rojas, Daniel Trejo>
-- Create date: <30/01/2010> 
-- Description:	<Elimina telefonos del contacto a eliminar por IdContacto>
-- =============================================

CREATE PROCEDURE [dbo].[EliminarTelefonosContacto_3]

@IdContacto int

AS
BEGIN

SET NOCOUNT ON;

	DELETE FROM dbo.Telefono
	WHERE IdContacto = @IdContacto

END 