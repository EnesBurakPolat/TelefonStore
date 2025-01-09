CREATE DATABASE TelefonStore;

DROP DATABASE TelefonStore;

USE TelefonStore;

-- Urunler Tablosu
CREATE TABLE Urunler (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Marka NVARCHAR(100), 
    Model NVARCHAR(100),
    Kamera NVARCHAR(50),
    Batarya NVARCHAR(50),
    Fiyat DECIMAL(10,2),
    imei BIGINT UNIQUE,
    Aktiflik BIT 
);
-- Satislar Tablosu
CREATE TABLE Satislar (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    UrunID INT,
    SatisTarihi DATETIME DEFAULT GETDATE(),
    ToplamTutar DECIMAL(10,2)
);
-- SinyalDurumu Tablosu
CREATE TABLE SinyalDurumu (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    UrunID INT FOREIGN KEY REFERENCES Urunler(ID),
    SonSinyalTarihi DATETIME,
    Durum NVARCHAR(10),
    KalanSure INT
);

--yetkili
-- Giriş oluştur
CREATE LOGIN yetkili WITH PASSWORD = '123';
-- Veritabanı kullanıcıyı girişle ilişkilendirerek oluştur
CREATE USER yetkili FOR LOGIN yetkili
-- Yetkileri ver
GRANT SELECT, INSERT, UPDATE, DELETE ON Urunler TO yetkili;
GRANT SELECT, INSERT, UPDATE, DELETE ON Satislar TO yetkili;
GRANT SELECT, INSERT, UPDATE, DELETE ON SinyalDurumu TO yetkili;

--calisan
-- Giriş oluştur
CREATE LOGIN calisan WITH PASSWORD = '123';
-- Veritabanı kullanıcıyı girişle ilişkilendirerek oluştur
CREATE USER calisan FOR LOGIN calisan;
-- Yetkileri ver
-- Yetkileri ver
GRANT SELECT, UPDATE ON Urunler TO calisan;
GRANT SELECT, UPDATE ON Satislar TO calisan;
GRANT SELECT, UPDATE ON SinyalDurumu TO calisan;


SELECT * FROM Urunler;
SELECT * FROM Satislar;
SELECT * FROM SinyalDurumu;