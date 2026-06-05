USE StyleXDB;
GO


IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' AND xtype='U')
BEGIN
    CREATE TABLE Users
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Username NVARCHAR(50) NOT NULL,
        Password NVARCHAR(100) NOT NULL,
        Email NVARCHAR(100)
    )
END
GO


IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ClothingItems' AND xtype='U')
BEGIN
    CREATE TABLE ClothingItems
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        UserId INT NOT NULL,
        ItemName NVARCHAR(200),
        Category NVARCHAR(100),
        Color NVARCHAR(100),
        ImagePath NVARCHAR(500)
    )
END
GO

IF NOT EXISTS (SELECT * FROM Users WHERE Username = 'nurrkocc')
BEGIN
    INSERT INTO Users (Username, Password, Email)
    VALUES ('nurrkocc', '123456', 'fatma@example.com')
END
GO