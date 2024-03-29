USE [BaseDatosSCADA]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 16/6/2016 17:31:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ElementoSCADA]    Script Date: 16/6/2016 17:31:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ElementoSCADA](
	[ID] [uniqueidentifier] NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[CantidadAlarmasActivas] [int] NOT NULL,
	[CantidadAdvertenciasActivas] [int] NOT NULL,
	[Direccion] [nvarchar](max) NULL,
	[Ciudad] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
	[ElementoPadre_ID] [uniqueidentifier] NULL,
	[Tipo_ID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.ElementoSCADA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Incidente]    Script Date: 16/6/2016 17:31:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incidente](
	[ID] [uniqueidentifier] NOT NULL DEFAULT (newsequentialid()),
	[IdElementoAsociado] [uniqueidentifier] NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Fecha] [datetime] NOT NULL,
	[NivelGravedad] [tinyint] NOT NULL,
 CONSTRAINT [PK_dbo.Incidente] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Medicion]    Script Date: 16/6/2016 17:31:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicion](
	[ID] [uniqueidentifier] NOT NULL DEFAULT (newsequentialid()),
	[Fecha] [datetime] NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[Variable_ID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.Medicion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tipo]    Script Date: 16/6/2016 17:31:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo](
	[ID] [uniqueidentifier] NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Tipo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Variable]    Script Date: 16/6/2016 17:31:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Variable](
	[ID] [uniqueidentifier] NOT NULL DEFAULT (newsequentialid()),
	[FueSeteada] [bit] NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[AlarmaActiva] [bit] NOT NULL,
	[AdvertenciaActiva] [bit] NOT NULL,
	[ValorActual] [decimal](18, 2) NOT NULL,
	[FechaUltimaModificacion] [datetime] NOT NULL,
	[MinimoAlarma] [decimal](18, 2) NOT NULL,
	[MinimoAdvertencia] [decimal](18, 2) NOT NULL,
	[MaximoAdvertencia] [decimal](18, 2) NOT NULL,
	[MaximoAlarma] [decimal](18, 2) NOT NULL,
	[ElementoPadre_ID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.Variable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[ElementoSCADA]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ElementoSCADA_dbo.ElementoSCADA_ElementoPadre_ID] FOREIGN KEY([ElementoPadre_ID])
REFERENCES [dbo].[ElementoSCADA] ([ID])
GO
ALTER TABLE [dbo].[ElementoSCADA] CHECK CONSTRAINT [FK_dbo.ElementoSCADA_dbo.ElementoSCADA_ElementoPadre_ID]
GO
ALTER TABLE [dbo].[ElementoSCADA]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ElementoSCADA_dbo.Tipo_Tipo_ID] FOREIGN KEY([Tipo_ID])
REFERENCES [dbo].[Tipo] ([ID])
GO
ALTER TABLE [dbo].[ElementoSCADA] CHECK CONSTRAINT [FK_dbo.ElementoSCADA_dbo.Tipo_Tipo_ID]
GO
ALTER TABLE [dbo].[Medicion]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Medicion_dbo.Variable_Variable_ID] FOREIGN KEY([Variable_ID])
REFERENCES [dbo].[Variable] ([ID])
GO
ALTER TABLE [dbo].[Medicion] CHECK CONSTRAINT [FK_dbo.Medicion_dbo.Variable_Variable_ID]
GO
ALTER TABLE [dbo].[Variable]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Variable_dbo.ElementoSCADA_ElementoPadre_ID] FOREIGN KEY([ElementoPadre_ID])
REFERENCES [dbo].[ElementoSCADA] ([ID])
GO
ALTER TABLE [dbo].[Variable] CHECK CONSTRAINT [FK_dbo.Variable_dbo.ElementoSCADA_ElementoPadre_ID]
GO
