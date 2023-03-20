CREATE TABLE [dbo].[Ville]
(
	[Id] INT NOT NULL IDENTITY,
	[CodePostal] NVARCHAR(20) NOT NULL,
	[Nom] NVARCHAR(255) NOT NULL, 
    [CodePays] NCHAR(2) NOT NULL, 
    CONSTRAINT [PK_Ville] PRIMARY KEY ([Id]), 
    CONSTRAINT [UK_Ville_CP_Nom] UNIQUE ([CodePostal], [Nom]), 
    CONSTRAINT [FK_Ville_Pays] FOREIGN KEY ([CodePays]) REFERENCES [Pays]([Code]),

)
