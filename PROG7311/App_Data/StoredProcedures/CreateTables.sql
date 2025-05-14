CREATE PROCEDURE GenerateTables
AS
BEGIN

DROP TABLE ForumMessage;
DROP TABLE ForumCategory;
DROP TABLE EducationalContent;
DROP TABLE Products;
DROP TABLE Users;

CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50),
    PasswordHash NVARCHAR(256),
    Role NVARCHAR(10) CHECK (Role IN ('Farmer', 'Employee')),
    ContactInfo NVARCHAR(100) NULL,
    Location NVARCHAR(100)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY,
    FarmerID INT FOREIGN KEY REFERENCES USERS(UserID),
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    ProductionDate DATE,
    ProductPrice INT,
    ProductImage VARBINARY(MAX) NULL
);

CREATE TABLE EducationalContent (
    EducationalContentID INT PRIMARY KEY IDENTITY,
    UserID INT FOREIGN KEY REFERENCES USERS(UserID),
    EducationalContentShortSummary NVARCHAR(50),
    EducationalContentFullDetails NVARCHAR(700),
    EducationalContentImage VARBINARY(MAX)
);

CREATE TABLE ForumCategory (
    ForumCategoryID INT PRIMARY KEY IDENTITY,
    ForumCategory INT,
    ForumCategoryDetails VARCHAR
);

CREATE TABLE ForumMessage (
    ForumMessageID INT PRIMARY KEY IDENTITY,
    ForumCategoryID INT REFERENCES ForumCategory(ForumCategoryID),
    AuthorName NVARCHAR(100),
    ForumMessageDetails NVARCHAR(MAX),
    ForumMessageDate DATETIME
);
END