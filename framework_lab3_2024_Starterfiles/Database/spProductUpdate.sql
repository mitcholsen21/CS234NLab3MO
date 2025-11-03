DELIMITER //
CREATE PROCEDURE spProductUpdate(
    IN pCode VARCHAR(10),
    IN pDescription VARCHAR(50),
    IN pUnitPrice DECIMAL(10,2),
    IN pOnHandQuantity INT,
    IN pOldConcurrencyID INT
)
BEGIN
    UPDATE Products
    SET 
        Description = pDescription,
        UnitPrice = pUnitPrice,
        OnHandQuantity = pOnHandQuantity,
        ConcurrencyID = ConcurrencyID + 1
    WHERE ProductCode = pCode
      AND ConcurrencyID = pOldConcurrencyID;

    SELECT ROW_COUNT() AS RowsAffected;
END //
DELIMITER ;
