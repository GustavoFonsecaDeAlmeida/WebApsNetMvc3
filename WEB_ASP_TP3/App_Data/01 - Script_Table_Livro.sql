CREATE TABLE [dbo].[Livro] (
    [Id]      INT       NOT NULL IDENTITY,
    [Titulo]  CHAR (50) NOT NULL,
    [Autor]   CHAR (50) NOT NULL,
    [Editora] CHAR (50) NOT NULL,
    [Ano]     INT       NOT NULL,
    [Anotacao] CHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
