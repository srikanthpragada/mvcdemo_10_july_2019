
create table Users
( Username  varchar(10) primary key,
  Password  varchar(10) not null,
  Email     varchar(30) not null unique
)

insert into users values('scott','scott','scott@gmail.com')


alter table Contacts add Username varchar(10) references Users(username)
update contacts set username = 'scott'