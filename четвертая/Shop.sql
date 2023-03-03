use Shops

create table Role
(
id int Primary key,
role nvarchar(20),
deleted bit 
)


create table Status
(
id int Primary key,
status bit,
deleted bit 
)


create table DeliveryType
(
id int Primary key,
delivery_type nvarchar(20),
deleted bit 
)


create table Users
(
id int Primary key,
surname nvarchar(20),
name nvarchar(20),
login nvarchar(20),
password nvarchar(20),
address nvarchar(100),
roleID int,
deleted bit, 
Foreign key (roleID) references Role(id)
on update cascade
on delete cascade
)

create table Category
(
id int Primary key,
name nvarchar(20),
deleted bit 
)

create table Specification
(
id int Primary key,
name nvarchar(20),
categoryID int
Foreign key (categoryID) references Category(id)
on update cascade
on delete cascade
)


create table Product
(
id int Primary key,
count int,
categoryID int,
price money,
deleted bit,
Foreign key (categoryID) references Category(id)
on update cascade 
on delete cascade
)


create table ProductSpecification
(
productID int,
specificationID int,
value int
Foreign key (productID) references Product(id),
Foreign key (specificationID) references Specification(id)
on update cascade
on delete cascade
)

create table Orders
(
id int Primary key ,
statusID int,
userID int ,
date_order date,
delivery_typeID int,
deleted bit
Foreign key (userID) references Users(id),
Foreign key (statusID) references Status(id),
Foreign key (delivery_typeID) references DeliveryType(id)
on update cascade
on delete cascade
)


create table ProductOrder
(
userID int,
productID int,
value int
Foreign key (userID) references Users(id),
Foreign key (productID) references Product(id)
on update cascade
on delete cascade
)


create table Cart
(
id int Primary key,
productID int,
count int,
userID int,
date_cart date,
deleted bit
Foreign key (productID) references Product(id),
Foreign key (userID) references Users(id)
on update cascade
on delete cascade
)