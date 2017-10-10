CREATE TABLE [SWIFT].[ImportedMessages]
(
    [SendersReference] NVARCHAR(16) NOT NULL, 
    [SwiftFileName] NVARCHAR(50) NOT NULL, 
	[Type] VARCHAR(10) NOT NULL, 
	[RawContent] NCHAR(2000) NOT NULL, 
	[SenderBankName] NVARCHAR(50) NOT NULL, 
	[B6UserId] NVARCHAR(50) NOT NULL, 
    [ImportDateTime] DATETIME2 NOT NULL, 
    [UploadDateTime] DATETIME2 NULL, 
    CONSTRAINT [PK_ImportedMessages] PRIMARY KEY ([SendersReference])
)
