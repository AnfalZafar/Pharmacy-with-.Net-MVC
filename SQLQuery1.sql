use pharmacy;
select * from orders;
drop table orders;
delete from user_resume Where c_id = 0;
create table Role(
Id int primary key identity(1,1),
Name varchar(255)
);

create table Users(
user_id int primary key identity(1,1),
user_name varchar(255),
user_email varchar(255),
user_password varchar(255),
user_phone varchar(255),
id int 
);

create table categare(
c_id int primary key identity(1,1),
c_name varchar(255),
c_img varchar(255)
);

create table Sub_Categare(
sub_c_id int primary key identity(1,1),
sub_c_name varchar(255),
sub_c_description varchar(max),
sub_c_price varchar(255),
sub_c_img varchar(255),
cat_id int
);

create table About(
about_id int primary key identity(1,1), 
about_title varchar(255),
about_description varchar(max),
about_img varchar(255),
cheak_one varchar(255),
cheak_two varchar(255),
cheak_three varchar(255)

);

create table Doctor(
doctor_id int primary key identity(1,1), 
doctor_name varchar(255),
doctor_position varchar(255),
doctor_img varchar(255)
);

create table Why_Choose(
w_id int primary key identity(1,1), 
w_title varchar(255),
w_description varchar(255),
w_img varchar(255)
);

create table Quote(
Quote_id int primary key identity(1,1),
Quote_name varchar(255),
Quote_email varchar(255), 
Quote_phone varchar(255),
Quote_address varchar(255),
Quote_post varchar(255),
Quote_country varchar(255),
Quote_message varchar(max)
);

create table Contact(
contact_id int primary key identity(1,1),
contact_name varchar(255),
contact_email varchar(255), 
contact_phone varchar(255),
contact_address varchar(255),
contact_message varchar(max)
);

create table Carrer(

carrer_id int primary key identity(1,1),
 carrer_name varchar(255),
 carrer_description varchar(max),
 carrer_location varchar(255)
);

create table user_resume(
r_id int primary key identity(1,1),
r_name varchar(255),
r_email  varchar(255),
r_location varchar(255),
r_phone varchar(255),
r_edu  varchar(255),
r_country  varchar(255),
r_resume  VARBINARY(max),
c_id int
);

create table orders(

o_id int primary key identity(1,1),
o_price varchar(255),
DateTime varchar(255),
user_id int
);