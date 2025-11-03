DELIMITER //
CREATE PROCEDURE spProductSelect(IN pCode VARCHAR(10))
BEGIN
    SELECT ProductCode, Description, UnitPrice, OnHandQuantity, ConcurrencyID
    FROM Products
    WHERE ProductCode = pCode;
END //
DELIMITER ;
