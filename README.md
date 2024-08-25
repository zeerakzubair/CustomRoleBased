1) Change connection string.
2) Run command -> update-database
3) Run following commands in sql Server
   
INSERT INTO Pages([Name], [Description])
VALUES ('Dummy Page 1','Dummy Description'), ('Dummy Page 2','Dummy Description'),('Dummy Page 3','Dummy Description'),('Dummy Page 4','Dummy Description'),('Dummy Page 5','Dummy Description')

INSERT INTO Roles([Name], [Description])
VALUES ('Admin','Can view all pages'), ('Customer','Can view some pages'),('Supplier','Can view some pages')

INSERT INTO Users(Id,[Name],[Email],[Password])
VALUES ('49A56516-4ADB-497C-F6A0-08DCC47C6B55','Admin','admin@gmail.com','admin123'),('49A56516-4ADB-457C-F6A0-08DCC47C6B45','Customer','customer@gmail.com','customer123'),
('49A56526-4ADB-457C-F6A0-08DCC43C6B45','Supplier','supplier@gmail.com','supplier123')

INSERT INTO UserRoles(RoleId,UserId)
VALUES (1,'49A56516-4ADB-497C-F6A0-08DCC47C6B55'),(2,'49A56516-4ADB-457C-F6A0-08DCC47C6B45'),(3,'49A56526-4ADB-457C-F6A0-08DCC43C6B45')

INSERT INTO RolePermissions(RoleId,PageId)
VALUES (1,1),(1,2),(1,3),(1,4),(1,5),(2,1),(2,2),(3,3),(3,4),(3,5)
