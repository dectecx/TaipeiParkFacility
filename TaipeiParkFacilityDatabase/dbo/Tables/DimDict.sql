CREATE TABLE [dbo].[DimDict] (
    [Id]         INT           NOT NULL,
    [Name]       NVARCHAR (50) NULL,
    [IsDelete]   BIT           CONSTRAINT [DF_DimDict_IsDelete] DEFAULT ((0)) NOT NULL,
    [CreateTime] DATETIME      CONSTRAINT [DF_DimDict_CreateTime] DEFAULT (getdate()) NOT NULL,
    [CreateBy]   NVARCHAR (50) NULL,
    [UpdateTime] DATETIME      CONSTRAINT [DF_DimDict_UpdateTime] DEFAULT (getdate()) NOT NULL,
    [UpdateBy]   NVARCHAR (50) NULL,
    CONSTRAINT [PK_DimDict] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'識別碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DimDict', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'行政區', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DimDict', @level2type = N'COLUMN', @level2name = N'Name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否刪除', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DimDict', @level2type = N'COLUMN', @level2name = N'IsDelete';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'建立時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DimDict', @level2type = N'COLUMN', @level2name = N'CreateTime';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'建立者', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DimDict', @level2type = N'COLUMN', @level2name = N'CreateBy';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'更新時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DimDict', @level2type = N'COLUMN', @level2name = N'UpdateTime';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'更新者', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DimDict', @level2type = N'COLUMN', @level2name = N'UpdateBy';

