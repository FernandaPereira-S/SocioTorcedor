CREATE DATABASE socio_torcedor
    CHARACTER SET 'latin1'
    COLLATE 'latin1_swedish_ci';

USE socio_torcedor;

CREATE TABLE Time (
    idTime INTEGER PRIMARY KEY AUTO_INCREMENT NOT NULL,
    nome VARCHAR(60) NOT NULL,
    treinador VARCHAR(60),
    campeonatos VARCHAR(100),
    estadoOrigem VARCHAR(60)
);

INSERT INTO Time(nome, treinador, campeonatos, estadoOrigem) VALUES('Flamengo', 'Jorge Sampaoli', 'Brasileirão Série A, Copa Libertadores da América, Copa do Brasil', 'Rio de Janeiro');
INSERT INTO Time(nome, treinador, campeonatos, estadoOrigem) VALUES('Fluminense', 'Fernando Diniz', 'Brasileirão Série A, Copa Libertadores da América, Campeonato Carioca de Futebol', 'Rio de Janeiro');
INSERT INTO Time(nome, treinador, campeonatos, estadoOrigem) VALUES('Palmeiras', 'Abel Ferreira', 'Brasileirão Série A, Copa Libertadores da América, Copa do Brasil', 'São Paulo');

CREATE TABLE Categoria (
    idCategoria INTEGER PRIMARY KEY AUTO_INCREMENT NOT NULL,
    nome VARCHAR(60) NOT NULL,
    preco FLOAT NOT NULL,
    beneficios VARCHAR(200) NOT NULL
);

INSERT INTO Categoria(nome, preco, beneficios) VALUES('Premium', '149.90', 'Desconto no ingresso; Compra de ingresso online; Direito à compra de 3 ingressos adicionais; Promoção em produtos oficiais com prioridade 1.');
INSERT INTO Categoria(nome, preco, beneficios) VALUES('Padrão', '99.90', 'Desconto no ingresso; Compra de ingresso online; Direito à compra de 2 ingressos adicionais; Promoção em produtos oficiais com prioridade 2.');
INSERT INTO Categoria(nome, preco, beneficios) VALUES('Básico', '49.90', 'Desconto no ingresso; Compra de ingresso online; Direito à compra de 1 ingresso adicional.');

CREATE TABLE Torcedor (
    idTorcedor INTEGER PRIMARY KEY AUTO_INCREMENT NOT NULL,
    nome VARCHAR(60) NOT NULL,
    telefone VARCHAR(11),
    email VARCHAR(60),
    CPF VARCHAR(11),
    idTime INTEGER NOT NULL,
	idCategoria INTEGER NOT NULL,
    CONSTRAINT fk_Torcedor_Time FOREIGN KEY(idTime) REFERENCES Time(idTime),
	CONSTRAINT fk_Torcedor_Categoria FOREIGN KEY(idCategoria) REFERENCES Categoria(idCategoria)
);

INSERT INTO Torcedor(nome, telefone, email, CPF, idTime, idCategoria) VALUES('Breno Barreto', '12345678901', 'breno@gmail.com', '1231231231', '1', '1');
INSERT INTO Torcedor(nome, telefone, email, CPF, idTime, idCategoria) VALUES('Ana Bomfim', '23456789012', 'ana@gmail.com', '2342342342', '2', '3');
INSERT INTO Torcedor(nome, telefone, email, CPF, idTime, idCategoria) VALUES('Fernanda Pereira', '34567890123', 'fernanda@gmail.com', '3453453453', '3', '2');