USE RadarDB

CREATE TABLE Radar
(
    id INT IDENTITY(1,1) NOT NULL,
    concessionaria VARCHAR(100) NOT NULL,
    ano_do_pnv_snv VARCHAR(4) NOT NULL,
    rodovia VARCHAR(10) NOT NULL,
    uf VARCHAR(2) NOT NULL,
    km_m VARCHAR(10) NOT NULL,
    municipio VARCHAR(50) NOT NULL,
    tipo_pista VARCHAR(20) NOT NULL,
    sentido VARCHAR(20) NOT NULL,
    data_da_inativacao DATE,
    latitude VARCHAR(10) NOT NULL,
    velocidade_leve VARCHAR(3) NOT NULL,

    CONSTRAINT PkRadar PRIMARY KEY (id)
)
