CREATE TABLE [dbo].[Uyelerr] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Kullanici]  NVARCHAR (50) NULL,
    [Sifre]      NVARCHAR (50) NULL,
    [Email]      NVARCHAR (50) NULL,
    [TelefonNo]  NVARCHAR (50) NULL,
    [Adi_Soyadi] NVARCHAR (50) NULL,
    [Unvan]      NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

