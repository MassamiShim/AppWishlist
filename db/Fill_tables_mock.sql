Insert Into ProductStatus
Values('Finished'),
('To Do'),
('Wishlist')

Insert Into TypeProduct
Values('Book', 'Amazon'),
('Game', 'Steam'),
('Movie', 'Netflix'),
('Serie', 'Netflix')

Insert Into Product
Values('Game 1', 2),
('Game 2', 2),
('Book 1', 1),
('Movie 1', 3),
('Movie 2', 3),
('Movie 3', 3)

Insert Into UserApp
Values('User 1', 'email@mail.com', 'Password')

Insert Into UserList
Values(1, 'List 1')

Insert Into ListProduct
Values(1,1,1),
(1,2,3),
(1,3,2)

select * from ProductStatus
select * from TypeProduct
select * from Product
Select * from UserApp
select * from UserList
Select  *from ListProduct