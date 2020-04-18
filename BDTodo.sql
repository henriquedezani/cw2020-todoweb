create database BDTodo
go

create table Todo
(
    Id      int             primary key     identity,
    Title   varchar(200)    not null,
    Done    bit             not null
)

insert into Todo values ('Lavar o carro', 0)
insert into Todo values ('Passear com o cachorro', 0)

select * from Todo