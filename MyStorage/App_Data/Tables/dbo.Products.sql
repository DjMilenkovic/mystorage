CREATE TABLE [dbo].[Products]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Description] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Category] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Manufacturer] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Supplier] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Price] [float] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products] ADD CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
