IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Guild] (
    [GuildId] int NOT NULL IDENTITY,
    [GuildName] nvarchar(max) NULL,
    CONSTRAINT [PK_Guild] PRIMARY KEY ([GuildId])
);

GO

CREATE TABLE [Player] (
    [PlayerId] int NOT NULL IDENTITY,
    [Name] nvarchar(20) NOT NULL,
    [GuildId] int NULL,
    CONSTRAINT [PK_Player] PRIMARY KEY ([PlayerId]),
    CONSTRAINT [FK_Player_Guild_GuildId] FOREIGN KEY ([GuildId]) REFERENCES [Guild] ([GuildId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Item] (
    [ItemId] int NOT NULL IDENTITY,
    [SoftDeleted] bit NOT NULL,
    [TemplateId] int NOT NULL,
    [CreateDate] datetime2 NOT NULL DEFAULT (GETDATE()),
    [OwnerId] int NOT NULL,
    [Discriminator] nvarchar(max) NOT NULL,
    [DestroyDate] datetime2 NULL,
    CONSTRAINT [PK_Item] PRIMARY KEY ([ItemId]),
    CONSTRAINT [FK_Item_Player_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [Player] ([PlayerId]) ON DELETE CASCADE
);

GO

CREATE UNIQUE INDEX [IX_Item_OwnerId] ON [Item] ([OwnerId]);

GO

CREATE INDEX [IX_Player_GuildId] ON [Player] ([GuildId]);

GO

CREATE UNIQUE INDEX [Index_Person_Name] ON [Player] ([Name]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230711072534_HelloMigration', N'3.1.24');

GO

ALTER TABLE [Item] ADD [ItemGrade] int NOT NULL DEFAULT 0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230711074946_ItemGrade', N'3.1.24');

GO

