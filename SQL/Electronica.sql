create database TiendaElectronica;

use TiendaElectronica;
select * from Categorias;
select * from Productos;
drop table Productos;
drop table Categorias;

create table Categorias (
    Id int primary key identity(1,1),
    Nombre nvarchar(20)
);


create table Productos (
    Id int primary key identity(1,1),
    Nombre nvarchar(50),
    Descripcion nvarchar(200),
    Precio decimal(18,2),
    Categoria_Id int,
    foreign key (Categoria_Id) references Categorias(Id)
);

INSERT INTO Categorias (Nombre) VALUES
('Computadoras'),
('Celulares'),
('Auriculares');

INSERT INTO Productos (Nombre, Descripcion, Precio, Categoria_Id) VALUES
('Laptop Ultrabook', 'Laptop delgada y potente para uso diario.', 1200.00, 1),
('Smartphone de �ltima generaci�n', 'Tel�fono con c�mara de alta resoluci�n.', 850.50, 1),
('Jeans Slim Fit', 'Pantalones de mezclilla para hombre.', 45.99, 2),
('Vestido de verano', 'Vestido casual y ligero.', 30.25, 2),
('Juego de sartenes de tefl�n', 'Set de sartenes antiadherentes.', 75.00, 3),
('L�mpara de pie moderna', 'L�mpara de dise�o minimalista.', 50.75, 3);