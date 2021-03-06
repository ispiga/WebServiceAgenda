USE [Agenda]
GO
/****** Object:  StoredProcedure [dbo].[sp_Insertar_Actualizar_Contacto]    Script Date: 28/11/2017 13:55:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_Insertar_Actualizar_Contacto] 
	-- Add the parameters for the stored procedure here
	@Operacion varchar(1),
	@Id int,
	@Nombre varchar(50),
	@Apellidos varchar(100),
	@Telefono varchar(15),
	@Correo varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @Operacion = 'I' /*Insertar*/
	insert into tbAgenda(Nombre, Apellidos, Telefono, Correo) values (@Nombre, @Apellidos, @Telefono, @Correo)
	else if @Operacion = 'A' /*Actualizar*/
	update tbAgenda set Nombre = @Nombre, Apellidos = @Apellidos, Telefono = @Telefono, Correo = @Correo
	where Id = @Id
END
