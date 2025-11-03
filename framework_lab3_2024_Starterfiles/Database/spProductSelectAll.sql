DELIMITER //
CREATE PROCEDURE spProductSelectAll()
BEGIN
    SELECT ProductCode, Description, UnitPrice, OnHandQuantity, ConcurrencyID
    FROM Products
    ORDER BY Description;
END //
DELIMITER ;
