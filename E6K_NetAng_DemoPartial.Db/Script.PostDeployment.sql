/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO Pays ([Code], [Nom]) VALUES 
  (N'BE', N'Belgique')
, (N'FR', N'France');

SET IDENTITY_INSERT Ville ON
INSERT INTO Ville ([Id], [CodePostal], [Nom], [CodePays]) VALUES 
  (1, N'B-1000', N'Bruxelles', N'BE')
, (2, N'B-4000', N'Liège', N'BE')
, (3, N'B-5000', N'Namur', N'BE')
, (4, N'B-6000', N'Charleroi', N'BE')
, (5, N'B-7000', N'Mons', N'BE')
, (6, N'F-57000', N'Lille', N'FR')
, (7, N'F-58000', N'Paris', N'FR')
, (8, N'F-59000', N'Marseille', N'FR')
, (9, N'F-33200', N'Nice', N'FR')
SET IDENTITY_INSERT Ville OFF
