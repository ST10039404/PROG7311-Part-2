DROP TABLE ForumMessage;
DROP TABLE ForumCategory;




CREATE TABLE ForumCategory (
    ForumCategoryId INT PRIMARY KEY IDENTITY,
    ForumCategory INT,
    ForumCategoryDetails VARCHAR
);

CREATE TABLE ForumMessage (
    ForumMessageId INT PRIMARY KEY IDENTITY,
    AuthorName NVARCHAR(100),
    ForumMessageDetails NVARCHAR(MAX),
    ForumMessageDate DATETIME,
    ForumCategoryId INT,
    FOREIGN KEY (ForumCategoryId) REFERENCES ForumCategory(ForumCategoryId)
);
