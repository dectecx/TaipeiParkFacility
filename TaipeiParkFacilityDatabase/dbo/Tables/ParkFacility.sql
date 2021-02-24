CREATE TABLE [dbo].[ParkFacility] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [ParkId]     INT           NOT NULL,
    [FacilityId] INT           NOT NULL,
    [Cnt]        INT           CONSTRAINT [DF_ParkFacility_Cnt] DEFAULT ((0)) NOT NULL,
    [IsDelete]   BIT           CONSTRAINT [DF_ParkFacility_IsDelete] DEFAULT ((0)) NOT NULL,
    [CreateTime] DATETIME      CONSTRAINT [DF_ParkFacility_CreateTime] DEFAULT (getdate()) NOT NULL,
    [CreateBy]   NVARCHAR (50) NULL,
    [UpdateTime] DATETIME      CONSTRAINT [DF_ParkFacility_UpdateTime] DEFAULT (getdate()) NOT NULL,
    [UpdateBy]   NVARCHAR (50) NULL,
    CONSTRAINT [PK_ParkFacility] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ParkFacility_DimFacility] FOREIGN KEY ([FacilityId]) REFERENCES [dbo].[DimFacility] ([Id]),
    CONSTRAINT [FK_ParkFacility_Park] FOREIGN KEY ([ParkId]) REFERENCES [dbo].[Park] ([Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'識別碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ParkFacility', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'公園Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ParkFacility', @level2type = N'COLUMN', @level2name = N'ParkId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'設施Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ParkFacility', @level2type = N'COLUMN', @level2name = N'FacilityId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'設施數量', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ParkFacility', @level2type = N'COLUMN', @level2name = N'Cnt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否刪除', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ParkFacility', @level2type = N'COLUMN', @level2name = N'IsDelete';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'建立時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ParkFacility', @level2type = N'COLUMN', @level2name = N'CreateTime';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'建立者', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ParkFacility', @level2type = N'COLUMN', @level2name = N'CreateBy';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'更新時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ParkFacility', @level2type = N'COLUMN', @level2name = N'UpdateTime';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'更新者', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ParkFacility', @level2type = N'COLUMN', @level2name = N'UpdateBy';

