CREATE DATABASE IF NOT EXISTS bd_bugaomotos;
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
-- TABELA PRODUTO
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
-- (Venda pode ter cliente, produto e/ou serviço)
-- ===========================
CREATE TABLE venda (
    id_ven INT PRIMARY KEY AUTO_INCREMENT,
    id_clie_fk INT,
    id_prod_fk INT NULL,
    id_ser_fk INT NULL,
    quantidade INT DEFAULT 1,
    valor_total DECIMAL(10,2),
    data_venda DATETIME DEFAULT NOW(),

    CONSTRAINT fk_venda_cliente FOREIGN KEY (id_clie_fk) REFERENCES cliente(id_clie),
    CONSTRAINT fk_venda_produto FOREIGN KEY (id_prod_fk) REFERENCES produto(id_prod),
    CONSTRAINT fk_venda_servico FOREIGN KEY (id_ser_fk) REFERENCES servico(id_ser)
);

-- ===========================
-- TABELA CAIXA
-- (Registra entrada e saída ligada a uma venda)
-- ===========================
CREATE TABLE caixa (
    id_caixa INT PRIMARY KEY AUTO_INCREMENT,
    id_ven_fk INT,
    tipo_movimento ENUM('ENTRADA','SAIDA'),
    valor_movimento DECIMAL(10,2),
    descricao VARCHAR(300),
    data_movimento DATETIME DEFAULT NOW(),

    CONSTRAINT fk_caixa_venda FOREIGN KEY (id_ven_fk) REFERENCES venda(id_ven)
);
