CREATE TABLE [dbo].[livres] (
    [Id]     INT              IDENTITY (1, 1) NOT NULL,
    [Titre]  NVARCHAR (50)    NOT NULL,
    [Auteur] NVARCHAR (250)   NOT NULL,
	[Categorie] NVARCHAR (50) NOT NULL,
    CONSTRAINT [livres_idLivres_PK] PRIMARY KEY CLUSTERED ([Id] ASC)
);
