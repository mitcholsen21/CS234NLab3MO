DELIMITER //
CREATE PROCEDURE spProductDelete(
    IN pCode VARCHAR(10),
    IN pOldConcurrencyID INT
)
BEGIN
    DELETE FROM Products
    WHERE ProductCode = pCode
      AND ConcurrencyID = pOldConcurrencyID;

    SELECT ROW_COUNT() AS RowsDeleted;
END //
DELIMITER ;
