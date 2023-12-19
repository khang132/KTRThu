CREATE DATABASE QLGV;
go
USE QLGV
go
CREATE TABLE QuanLy (
  magv VARCHAR(255),
  HoTen VARCHAR(255),
  sdt VARCHAR(255),
  ghichu VARCHAR(255),
  madonvi VARCHAR(255),
  coso VARCHAR(255)
);
INSERT INTO QuanLy (magv, HoTen,sdt,ghichu,madonvi,coso) VALUES ('1', 'thanhao','123456789','kgsao','123','1');
INSERT INTO QuanLy (magv, HoTen,sdt,ghichu,madonvi,coso ) VALUES ('2', 'thanhao2','123456780','kgsao','1234','2');