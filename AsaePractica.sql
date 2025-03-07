USE [AsaePractica]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 08/08/2024 12:56:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 08/08/2024 12:56:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[Telefono] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacto]    Script Date: 08/08/2024 12:56:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacto](
	[IdContacto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
	[Correo] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Precio]    Script Date: 08/08/2024 12:56:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Precio](
	[IdPrecio] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NOT NULL,
	[IdTipoPrecio] [int] NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[FechaInicio] [date] NOT NULL,
	[FechaFin] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPrecio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 08/08/2024 12:56:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](255) NULL,
	[IdCategoria] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPrecio]    Script Date: 08/08/2024 12:56:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPrecio](
	[IdTipoPrecio] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipoPrecio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 08/08/2024 12:56:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[FechaVenta] [datetime] NOT NULL,
	[IdCliente] [int] NULL,
	[IdTipoPrecio] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Venta] ADD  DEFAULT (getdate()) FOR [FechaVenta]
GO
ALTER TABLE [dbo].[Venta] ADD  CONSTRAINT [DF_Venta_IdPrecio]  DEFAULT ((0)) FOR [IdTipoPrecio]
GO
ALTER TABLE [dbo].[Precio]  WITH CHECK ADD  CONSTRAINT [FK_Precio_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[Precio] CHECK CONSTRAINT [FK_Precio_Producto]
GO
ALTER TABLE [dbo].[Precio]  WITH CHECK ADD  CONSTRAINT [FK_Precio_TipoPrecio] FOREIGN KEY([IdTipoPrecio])
REFERENCES [dbo].[TipoPrecio] ([IdTipoPrecio])
GO
ALTER TABLE [dbo].[Precio] CHECK CONSTRAINT [FK_Precio_TipoPrecio]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
/****** Object:  StoredProcedure [dbo].[spSetProduct]    Script Date: 08/08/2024 12:56:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSetProduct]
@Accion int = 1,
    @IdProducto INT=0,
    @Cantidad INT=0,
	@IdVenta int=0,
    @Precio DECIMAL(18, 2)=0.0,
    @IdCliente INT = NULL,
	@IdTipoPrecio INT=0
AS
BEGIN
if @Accion=1
begin
    SELECT distinct v.IdVenta,v.Cantidad,v.Precio, p.IdProducto, p.Nombre, p.Descripcion, c.Nombre AS Categoria,isnull(v.Cantidad,0) * isnull(v.Precio,0) AS Total
    FROM Venta v
	INNER JOIN Producto p ON v.IdProducto=p.IdProducto
    INNER JOIN Categoria c ON p.IdCategoria = c.IdCategoria
    INNER JOIN Precio pr ON p.IdProducto = pr.IdProducto
    --WHERE p.IdProducto = @IdProducto AND pr.FechaFin IS NULL
end
if @Accion=2
begin
    SELECT distinct v.IdVenta,v.Cantidad,v.Precio, p.IdProducto, p.Nombre, p.Descripcion, c.Nombre AS Categoria,isnull(v.Cantidad,0) * isnull(v.Precio,0) AS Total
    FROM Venta v
	INNER JOIN Producto p ON v.IdProducto=p.IdProducto
    INNER JOIN Categoria c ON p.IdCategoria = c.IdCategoria
    INNER JOIN Precio pr ON p.IdProducto = pr.IdProducto
    WHERE v.IdVenta = @IdVenta
	--AND pr.FechaFin IS NULL
end
if @Accion=3
begin

	if isnull(@IdVenta,0)=0
		begin
			INSERT INTO Venta (IdProducto, Cantidad, Precio, FechaVenta, IdCliente,IdTipoPrecio) VALUES (@IdProducto, @Cantidad, @Precio, GETDATE(), 1,@IdTipoPrecio);	
			  SELECT SCOPE_IDENTITY() AS IdVenta;
		end
	else
		begin
			UPDATE [Venta]
				   SET [IdProducto] = @IdProducto,
					  [Cantidad] = @Cantidad,
					  [Precio] = @Precio,
					  [IdCliente] = @IdCliente,
					  [IdTipoPrecio] = @IdTipoPrecio
				where IdVenta=@IdVenta
				select @IdVenta AS IdVenta
		end
end
if @Accion=4
begin
  delete from Venta where IdVenta=@IdVenta
end
if @Accion=5
begin
	UPDATE [Venta]
	   SET [IdProducto] = @IdProducto,
		  [Cantidad] = @Cantidad,
		  [Precio] = @Precio,
		  [IdCliente] = @IdCliente,
		  [IdTipoPrecio] = @IdTipoPrecio
	where IdVenta=@IdVenta
end
if @Accion=6
begin
    SELECT P.IdProducto, P.Nombre, P.Descripcion, C.Nombre AS Categoria FROM Producto AS P INNER JOIN Categoria AS C ON P.IdCategoria = C.IdCategoria order by P.Descripcion
end
END
GO



-- Datos de ejemplo para Categoria
INSERT INTO Categoria (Nombre, Descripcion) VALUES 
('Electrónica', 'Dispositivos electrónicos y gadgets'),
('Ropa', 'Vestimenta y accesorios de moda'),
('Alimentos', 'Productos alimenticios y bebidas');

-- Datos de ejemplo para Producto
INSERT INTO Producto (Nombre, Descripcion, IdCategoria) VALUES 
('Televisor', 'Televisor LED 40 pulgadas', 1),
('Camiseta', 'Camiseta de algodón talla M', 2),
('Cereal', 'Caja de cereal de 500g', 3);

-- Datos de ejemplo para TipoPrecio
INSERT INTO TipoPrecio (Nombre, Descripcion) VALUES 
('Distribuidor', 'Precio para distribuidores'),
('Público', 'Precio para el público en general'),
('Mayorista', 'Precio para compras al por mayor');

-- Datos de ejemplo para Precio
INSERT INTO Precio (IdProducto, IdTipoPrecio, Precio, FechaInicio, FechaFin) VALUES 
(1, 1, 300.00, '2023-01-01', NULL),
(1, 2, 350.00, '2023-01-01', NULL),
(2, 1, 10.00, '2023-01-01', NULL),
(2, 2, 15.00, '2023-01-01', NULL),
(3, 1, 2.50, '2023-01-01', NULL),
(3, 2, 3.00, '2023-01-01', NULL);