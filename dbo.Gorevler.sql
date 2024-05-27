CREATE TABLE [dbo].[Gorevler] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [GorevAdi]      NVARCHAR (100) NULL,
    [GorevAciklama] NVARCHAR (255) NULL,
    [KullaniciId]   INT            NOT NULL,
    [Tarih]         DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([KullaniciId]) REFERENCES [dbo].[Uyelerr] ([Id])
);

