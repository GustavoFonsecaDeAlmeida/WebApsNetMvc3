CREATE TABLE [dbo].Emprestimo
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [dataEmprestimo] NVARCHAR(150) NULL, 
    [dataDevolucao] NVARCHAR(150) NULL, 
    [idLivro] INT NULL, 
    CONSTRAINT [FK_idLivro] FOREIGN KEY ([idlivro]) REFERENCES [livro]([id])
	
)

