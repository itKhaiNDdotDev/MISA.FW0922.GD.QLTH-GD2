﻿--
-- Script was generated by Devart dbForge Studio 2020 for MySQL, Version 9.0.338.0
-- Product home page: http://www.devart.com/dbforge/mysql/studio
-- Script date 12/19/2022 4:52:45 PM
-- Server version: 8.0.31
-- Client version: 4.1
--

-- 
-- Disable foreign keys
-- 
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;

-- 
-- Set SQL mode
-- 
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- 
-- Set character set the client will use to send SQL statements to the server
--
SET NAMES 'utf8';

--
-- Set default database
--
USE `misa.fw0922.gd.qlth.khoanthu`;

--
-- Drop table `studentexemption`
--
DROP TABLE IF EXISTS studentexemption;

--
-- Drop table `exemption`
--
DROP TABLE IF EXISTS exemption;

--
-- Drop table `fee`
--
DROP TABLE IF EXISTS fee;

--
-- Drop table `student`
--
DROP TABLE IF EXISTS student;

--
-- Drop table `class`
--
DROP TABLE IF EXISTS class;

--
-- Set default database
--
USE `misa.fw0922.gd.qlth.khoanthu`;

--
-- Create table `class`
--
CREATE TABLE class (
  ClassID int NOT NULL AUTO_INCREMENT COMMENT 'ID của lớp',
  ClassName varchar(255) NOT NULL DEFAULT '' COMMENT 'Tên lớp',
  CreatedDate datetime DEFAULT NULL COMMENT 'Thời gian tạo bản ghi',
  CreatedBy varchar(100) DEFAULT NULL COMMENT 'Người tạo bản ghi',
  ModifiedDate datetime DEFAULT NULL COMMENT 'Thời gian chỉnh sửa bản ghi lần gần nhất',
  ModifiedBy varchar(100) DEFAULT NULL COMMENT 'Người chỉnh sửa bản ghi lần gần nhất',
  PRIMARY KEY (ClassID)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci,
COMMENT = 'Bảng lưu trữ thông tin danh sách lớp của trường';

--
-- Create table `student`
--
CREATE TABLE student (
  StudentID char(36) NOT NULL DEFAULT '' COMMENT 'ID của học sinh',
  StudentCode varchar(20) NOT NULL DEFAULT '' COMMENT 'Mã định danh học sinh',
  StudentName varchar(100) NOT NULL DEFAULT '' COMMENT 'Họ và tên học sinh',
  StudentDateOfBirth date DEFAULT NULL COMMENT 'Ngày sinh của học sinh',
  ClassID int DEFAULT NULL COMMENT 'Khóa ngoại đến ID của Lớp tưng ứng trong bảng Class',
  CreatedDate datetime DEFAULT NULL COMMENT 'Thời gian tạo bản ghi',
  CreatedBy varchar(100) DEFAULT NULL COMMENT 'Người tạo bản ghi',
  ModifiedDate datetime DEFAULT NULL COMMENT 'Thời gian chỉnh sửa bản ghi lần gần nhất',
  ModifiedBy varchar(100) DEFAULT NULL COMMENT 'Người chỉnh sửa bản ghi lần gần nhất',
  PRIMARY KEY (StudentID)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci,
COMMENT = 'Bảng lưu trữ thông tin học sinh';

--
-- Create index `IX_Student_StudentName` on table `student`
--
ALTER TABLE student
ADD INDEX IX_Student_StudentName (StudentName);

--
-- Create index `StudentCode` on table `student`
--
ALTER TABLE student
ADD UNIQUE INDEX StudentCode (StudentCode);

--
-- Create foreign key
--
ALTER TABLE student
ADD CONSTRAINT FK_Student_Class_ClassID FOREIGN KEY (ClassID)
REFERENCES class (ClassID);

--
-- Create table `fee`
--
CREATE TABLE fee (
  FeeID int NOT NULL COMMENT 'ID của khoản thu',
  FeeName varchar(255) NOT NULL DEFAULT '' COMMENT 'Tên khoản thu',
  FeePrice decimal(10, 0) DEFAULT 0 COMMENT 'Đơn giá (tính theo đơn vị VNĐ)',
  CreatedDate datetime DEFAULT NULL COMMENT 'Thời gian tạo bản ghi',
  CreatedBy varchar(100) DEFAULT NULL COMMENT 'Người tạo bản ghi',
  ModifiedDate datetime DEFAULT NULL COMMENT 'Thời gian chỉnh sửa bản ghi lần gần nhất',
  ModifiedBy varchar(100) DEFAULT NULL COMMENT 'Người chỉnh sửa bản ghi lần gần nhất',
  PRIMARY KEY (FeeID)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci,
COMMENT = 'Bảng lưu trữ thông tin các Khoản thu';

--
-- Create index `IX_Fee_FeeName` on table `fee`
--
ALTER TABLE fee
ADD INDEX IX_Fee_FeeName (FeeName);

--
-- Create table `exemption`
--
CREATE TABLE exemption (
  ExemptionID int NOT NULL COMMENT 'ID của diện miễn giảm',
  ExemptionName varchar(255) NOT NULL DEFAULT '' COMMENT 'Tên diện miễn giảm',
  ExemptionDescription varchar(255) DEFAULT NULL COMMENT 'Mô tả diện miễn giảm',
  ExemptionFixLevel decimal(18, 4) DEFAULT 0.0000 COMMENT 'Mức miễn giảm gợi ý',
  ExemptionFixLevelUnitByPercent tinyint DEFAULT 1 COMMENT 'Đơn vị tính mức miễn giảm gợi ý: Giá trị TRUE: mức miễn giảm tính theo %, FALSE: mức miễn giảm tính theo VNĐ',
  CreatedDate datetime DEFAULT NULL COMMENT 'Thời gian tạo bản ghi',
  CreatedBy varchar(100) DEFAULT NULL COMMENT 'Người tạo bản ghi',
  ModifiedDate datetime DEFAULT NULL COMMENT 'Thời gian chỉnh sửa bản ghi lần gần nhất',
  ModifiedBy varchar(100) DEFAULT NULL COMMENT 'Người chỉnh sửa bản ghi lần gần nhất',
  PRIMARY KEY (ExemptionID)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci,
COMMENT = 'Bảng lưu trữ thông tin các Diện miễn giảm';

--
-- Create index `IX_Exemption_ExemptionDescription` on table `exemption`
--
ALTER TABLE exemption
ADD INDEX IX_Exemption_ExemptionDescription (ExemptionDescription);

--
-- Create index `IX_Exemption_ExemptionName` on table `exemption`
--
ALTER TABLE exemption
ADD INDEX IX_Exemption_ExemptionName (ExemptionName);

--
-- Create table `studentexemption`
--
CREATE TABLE studentexemption (
  StudentExemptionID char(36) NOT NULL DEFAULT '' COMMENT 'ID của bản ghi thông tin miễn giảm tương ứng học sinh',
  StudentID char(36) NOT NULL DEFAULT '' COMMENT 'Khóa ngoại đến StudentID của Học sinh tương ứng ở bảng Student',
  FeeID int NOT NULL COMMENT 'Khóa ngoại đến FeeID của Khoản thu tương ứng ở bảng Fee',
  ExemptionID int NOT NULL COMMENT 'Khóa ngoại đến ExemptionID của Diện miễn giảm tương ứng ở bảng Exemption',
  StudentExemptionFixLevel decimal(18, 4) DEFAULT 0.0000 COMMENT 'Mức miễn giảm',
  StudentExemptionLevelIsUnitByPercent tinyint DEFAULT 1 COMMENT 'Đơn vị tính mức miễn giảm: Giá trị TRUE: mức miễn giảm tính theo %, FALSE: mức miễn giảm tính theo VNĐ',
  StudentExemptionTime varchar(255) DEFAULT NULL COMMENT 'Thời gian áp dụng miễn giảm - Giá trị: "Cả năm", "Học kỳ I", "Học kỳ II", hoặc tùy chọn tương ứng từ tháng - đến tháng ví dụ: "10/2021 - 03/2022"',
  CreatedDate datetime DEFAULT NULL COMMENT 'Thời gian tạo bản ghi',
  CreatedBy varchar(100) DEFAULT NULL COMMENT 'Người tạo bản ghi',
  ModifiedDate datetime DEFAULT NULL COMMENT 'Thời gian chỉnh sửa bản ghi lần gần nhất',
  ModifiedBy varchar(100) DEFAULT NULL COMMENT 'Người chỉnh sửa bản ghi lần gần nhất',
  PRIMARY KEY (StudentExemptionID)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci,
COMMENT = 'Bảng Danh sách thông tin miễn giảm của các học sinh';

--
-- Create foreign key
--
ALTER TABLE studentexemption
ADD CONSTRAINT FK_StudentExemption_Exemption_ExemptionID FOREIGN KEY (ExemptionID)
REFERENCES exemption (ExemptionID);

--
-- Create foreign key
--
ALTER TABLE studentexemption
ADD CONSTRAINT FK_StudentExemption_Fee_FeeID FOREIGN KEY (FeeID)
REFERENCES fee (FeeID);

--
-- Create foreign key
--
ALTER TABLE studentexemption
ADD CONSTRAINT FK_StudentExemption_Student_StudentID FOREIGN KEY (StudentID)
REFERENCES student (StudentID);

-- 
-- Dumping data for table class
--
-- Table `misa.fw0922.gd.qlth.khoanthu`.class does not contain any data (it is empty)

-- 
-- Dumping data for table student
--
-- Table `misa.fw0922.gd.qlth.khoanthu`.student does not contain any data (it is empty)

-- 
-- Dumping data for table fee
--
-- Table `misa.fw0922.gd.qlth.khoanthu`.fee does not contain any data (it is empty)

-- 
-- Dumping data for table exemption
--
-- Table `misa.fw0922.gd.qlth.khoanthu`.exemption does not contain any data (it is empty)

-- 
-- Dumping data for table studentexemption
--
-- Table `misa.fw0922.gd.qlth.khoanthu`.studentexemption does not contain any data (it is empty)

-- 
-- Restore previous SQL mode
-- 
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;

-- 
-- Enable foreign keys
-- 
/*!40014 SET FOREIGN_KEY_CHECKS = @OLD_FOREIGN_KEY_CHECKS */;