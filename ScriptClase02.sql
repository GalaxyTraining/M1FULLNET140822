USE [BDEmpresa]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 27/08/2022 18:00:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Tipo] [varchar](100) NULL,
	[Precio] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([Id], [Nombre], [Tipo], [Precio]) VALUES (1, N'Coca Cola', N'Gaseosa', CAST(0.50 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
