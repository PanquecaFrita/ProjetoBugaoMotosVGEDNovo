CREATE DATABASE bd_bugaomotos;
USE bd_bugaomotos;

-- ===========================
-- TABELA CLIENTE
-- ===========================
CREATE TABLE cliente (
    id_clie INT PRIMARY KEY AUTO_INCREMENT,
    nome_clie VARCHAR(300),
    telefone_clie VARCHAR(200),
    estado_clie VARCHAR(100),
    cpf_clie VARCHAR(100),
    cidade_clie VARCHAR(100),
    complemento_clie VARCHAR(100),
    bairro_clie VARCHAR(100),
    rua_clie VARCHAR(100),
    cep_clie VARCHAR(200)
);

-- ===========================
-- TABELA FORNECEDOR
-- ===========================
CREATE TABLE fornecedor (
    id_forne INT PRIMARY KEY AUTO_INCREMENT,
    nome_forne VARCHAR(300),
    nome_responsa_forne VARCHAR(300),
    telefone_respon_forne VARCHAR(200),
    telefone_forne VARCHAR(200),
    numero_forne VARCHAR(200),
    complemento_forne VARCHAR(100),
    cep_forne VARCHAR(200),
    cnpj_forne VARCHAR(200),
    rua_forne VARCHAR(100),
    estado_forne VARCHAR(100),
    cidade_forne VARCHAR(100),
    bairro_forne VARCHAR(100),
    razao_social_forne VARCHAR(100)
);

-- ===========================
-- TABELA PRODUTO (FK CORRIGIDA)
-- ===========================
CREATE TABLE produto (
    id_prod INT PRIMARY KEY AUTO_INCREMENT,
    nome_prod VARCHAR(300),
    codigo_prod VARCHAR(300),
    quantidade_prod INT,
    valor_prod INT,
    id_forne_fk INT,
    CONSTRAINT fk_produto_fornecedor 
        FOREIGN KEY (id_forne_fk) REFERENCES fornecedor(id_forne)
);

-- ===========================
-- TABELA SERVIÇO
-- ===========================
CREATE TABLE servico (
    id_ser INT PRIMARY KEY AUTO_INCREMENT,
    nome_ser VARCHAR(300),
    codigo_ser VARCHAR(300),
    prestador_ser VARCHAR(300),
    valor_ser INT
);

-- ===========================
-- TABELA VENDA
-- ===========================
CREATE TABLE venda (
    id_ven INT PRIMARY KEY AUTO_INCREMENT,
    nome_ser VARCHAR(300),
    codigo_ser VARCHAR(300),
    prestador_ser VARCHAR(300),
    valor_ser INT
);
