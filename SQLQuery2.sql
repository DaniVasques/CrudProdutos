CREATE TABLE PRODUTO(
 ID                      UNIQUEIDENTIFIER       PRIMARY KEY,
 NOME                    VARCHAR(100)           NOT NULL,
 PRECO                   DECIMAL(10,2)          NOT NULL,
 QUANTIDADE              INTEGER                NOT NULL,
 DATAHORACADASTRO        DATETIME               NOT NULL,
 DATAHORAULTIMAALTERACAO DATETIME               NOT NULL);
 GO


