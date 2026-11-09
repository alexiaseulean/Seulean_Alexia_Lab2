INSERT INTO AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp)
VALUES ('1', 'Admin', 'ADMIN', NEWID()),
       ('2', 'User',  'USER',  NEWID());

SELECT * FROM AspNetRoles;