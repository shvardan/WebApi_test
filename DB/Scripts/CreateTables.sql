IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE [Name] = 'Product')
BEGIN
	CREATE TABLE [dbo].[Product](
	[ID] [BIGINT] IDENTITY(1,1) NOT NULL,
	[Name] [NVARCHAR](15) NOT NULL,
	[Price] [DECIMAL] NOT NULL,
	[Barcode] [NVARCHAR](13) NULL,
	[PLU] [INT] NOT NULL,
	[ImageUrl] [NVARCHAR](400) NULL,
	[DateCreated] [DATETIMEOFFSET] NOT NULL,
	[DateModified] [DATETIMEOFFSET] NULL,

	CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ID] ASC)
	)
END