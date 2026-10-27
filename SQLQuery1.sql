DELETE FROM BookCategory
WHERE ID NOT IN (
    SELECT MIN(ID) FROM BookCategory GROUP BY BookID, CategoryID
);

SELECT c.CategoryName, b.Title
FROM BookCategory bc
JOIN Book b ON b.ID = bc.BookID
JOIN Category c ON c.ID = bc.CategoryID
ORDER BY c.CategoryName;