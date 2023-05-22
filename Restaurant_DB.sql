go
create database Restaurant_DB
go
use Restaurant_DB

create table Restaurant(
restaurant_id int IDENTITY PRIMARY KEY NOT NULL,
restaurant_name varchar(100),
schedule varchar(150),
minimum_order float,
maximum_distance float,
delivery_price float,
extra_delivery_fee float
);

create table Users(
users_id int IDENTITY PRIMARY KEY NOT NULL,
username varchar(50),
pass varchar(50),
actual_name varchar(100)

);

create table Food(
food_id int IDENTITY PRIMARY KEY NOT NULL,
food_name varchar(100),
food_description varchar(200),
food_price float,
restaurant_id int FOREIGN KEY references Restaurant(restaurant_id)
on update cascade
on delete cascade
);


create table Orders(
users_id int FOREIGN KEY references Users(users_id)
on update cascade
on delete cascade,
food_id int FOREIGN KEY references Food(food_id)
on update cascade
on delete cascade,
constraint PK_Orders PRIMARY KEY(users_id,food_id),
users_name varchar(100),
user_location varchar(200),
distance float,
order_mentions varchar(500),
order_status varchar(50)
);

SELECT * FROM Users;
SELECT * FROM Restaurant;
INSERT INTO Restaurant VALUES ('McDonalds','09:00 - 21:00', 40, 15, 5.99, 1.20);
SELECT * FROM Food;
INSERT INTO Food VALUES('Nuggets', 'Fried', 18.99, 1);