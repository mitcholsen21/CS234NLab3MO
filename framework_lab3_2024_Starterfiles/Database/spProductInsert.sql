DELIMITER //
CREATE PROCEDURE spProductInsert(
    IN pCode VARCHAR(10),
    IN pDescription VARCHAR(50),
    IN pUnitPrice DECIMAL(10,2),
    IN pOnHandQuantity INT
)
BEGIN
    INSERT INTO Products (ProductCode, Description, UnitPrice, OnHandQuantity, ConcurrencyID)
    VALUES (pCode, pDescription, pUnitPrice, pOnHandQuantity, 1);
END //
DELIMITER ;
