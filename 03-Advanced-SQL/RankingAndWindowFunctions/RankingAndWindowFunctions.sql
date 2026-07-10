-- IF DB_ID('OnlineRetailStore') IS NULL
-- BEGIN
--     CREATE DATABASE OnlineRetailStore;
-- END
-- GO

-- USE OnlineRetailStore;
-- GO


-- IF OBJECT_ID('Products', 'U') IS NOT NULL
-- DROP TABLE Products;
-- GO


-- CREATE TABLE Products
-- (
--     ProductID INT PRIMARY KEY,
--     ProductName VARCHAR(100),
--     Category VARCHAR(50),
--     Price DECIMAL(10,2)
-- );
-- GO

-- INSERT INTO Products VALUES
-- (1,'Laptop','Electronics',65000),
-- (2,'Phone','Electronics',65000),
-- (3,'Keyboard','Electronics',2500),
-- (4,'Mouse','Electronics',1200),
-- (5,'Rice','Groceries',900),
-- (6,'Oil','Groceries',1800),
-- (7,'Milk','Groceries',60),
-- (8,'Sugar','Groceries',900),
-- (9,'Shirt','Fashion',1500),
-- (10,'Jeans','Fashion',2500),
-- (11,'Shoes','Fashion',4200),
-- (12,'Jacket','Fashion',4200);
-- GO



-- SELECT
--     ProductID,
--     ProductName,
--     Category,
--     Price,
--     ROW_NUMBER() OVER
--     (
--         PARTITION BY Category
--         ORDER BY Price DESC
--     ) AS RowNumber
-- FROM Products;
-- GO

-- SELECT
--     ProductID,
--     ProductName,
--     Category,
--     Price,
--     RANK() OVER
--     (
--         PARTITION BY Category
--         ORDER BY Price DESC
--     ) AS RankNumber
-- FROM Products;
-- GO


-- SELECT
--     ProductID,
--     ProductName,
--     Category,
--     Price,
--     DENSE_RANK() OVER
--     (
--         PARTITION BY Category
--         ORDER BY Price DESC
--     ) AS DenseRank
-- FROM Products;
-- GO



-- WITH RankedProducts AS
-- (
--     SELECT
--         ProductID,
--         ProductName,
--         Category,
--         Price,
--         ROW_NUMBER() OVER
--         (
--             PARTITION BY Category
--             ORDER BY Price DESC
--         ) AS RN
--     FROM Products
-- )
-- SELECT *
-- FROM RankedProducts
-- WHERE RN <= 3;
-- GO
WITH RankedProducts AS
(
    SELECT
        ProductID,
        ProductName,
        Category,
        Price,
        ROW_NUMBER() OVER
        (
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS RN
    FROM Products
)
SELECT *
FROM RankedProducts
WHERE RN <= 3;