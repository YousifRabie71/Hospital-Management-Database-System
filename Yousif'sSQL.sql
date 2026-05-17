CREATE DATABASE  IF NOT EXISTS `hosdb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `hosdb`;
-- MySQL dump 10.13  Distrib 8.0.45, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: hosdb
-- ------------------------------------------------------
-- Server version	8.0.45

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `accounting`
--

DROP TABLE IF EXISTS `accounting`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `accounting` (
  `AccID` int NOT NULL,
  `AccountantName` varchar(45) DEFAULT NULL,
  `AccountantWorknights` varchar(45) DEFAULT NULL,
  `AcountantEmail` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`AccID`),
  UNIQUE KEY `AcountantEmail_UNIQUE` (`AcountantEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `accounting`
--

LOCK TABLES `accounting` WRITE;
/*!40000 ALTER TABLE `accounting` DISABLE KEYS */;
INSERT INTO `accounting` VALUES (1,'Sami Zeid','2','sami.z@hospital.com'),(2,'Huda Omar','1','huda.o@hospital.com'),(3,'Kareem Ali','3','kareem.a@hospital.com');
/*!40000 ALTER TABLE `accounting` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `appointment`
--

DROP TABLE IF EXISTS `appointment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `appointment` (
  `AppointmentID` int NOT NULL,
  `AppNo` int DEFAULT NULL,
  `AppDate` date DEFAULT NULL,
  `AppFees` int DEFAULT NULL,
  `DoctorID` int DEFAULT NULL,
  `PatientID` int DEFAULT NULL,
  PRIMARY KEY (`AppointmentID`),
  KEY `AppDoCFK_idx` (`DoctorID`),
  KEY `AppPatient_idx` (`PatientID`),
  CONSTRAINT `AppDoCFK` FOREIGN KEY (`DoctorID`) REFERENCES `doctors` (`DoctorID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `AppPatient` FOREIGN KEY (`PatientID`) REFERENCES `patient` (`PatientID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `appointment`
--

LOCK TABLES `appointment` WRITE;
/*!40000 ALTER TABLE `appointment` DISABLE KEYS */;
INSERT INTO `appointment` VALUES (1,1,'2026-03-10',250,1,4),(2,2,'2026-03-10',150,2,3),(3,3,'2026-03-11',300,3,1),(4,4,'2026-03-11',200,4,2),(5,5,'2026-03-12',250,5,5),(6,6,'2026-10-10',270,2,2),(7,7,'2000-02-02',222,1,2);
/*!40000 ALTER TABLE `appointment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `department`
--

DROP TABLE IF EXISTS `department`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `department` (
  `DepaID` int NOT NULL,
  `DepaName` varchar(45) DEFAULT NULL,
  `DepaHead` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`DepaID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `department`
--

LOCK TABLES `department` WRITE;
/*!40000 ALTER TABLE `department` DISABLE KEYS */;
INSERT INTO `department` VALUES (1,'cardiology','YousifElkhouly'),(2,'Emergncy','MohamedAlassad'),(3,'Surgery','HayaAhmed'),(4,'Pharmacy','Hala Mohamed'),(5,'admin','Youssef Ahmed');
/*!40000 ALTER TABLE `department` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `doctors`
--

DROP TABLE IF EXISTS `doctors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `doctors` (
  `DoctorID` int NOT NULL,
  `DoctorName` varchar(45) DEFAULT NULL,
  `DoctorAge` int DEFAULT NULL,
  `DoctorEmail` varchar(45) DEFAULT NULL,
  `DoctorSalary` int DEFAULT NULL,
  `DoctorOfficesHrs` int DEFAULT NULL,
  `DepaID` int DEFAULT NULL,
  PRIMARY KEY (`DoctorID`),
  KEY `FkDoctor_idx` (`DepaID`),
  CONSTRAINT `FkDoctor` FOREIGN KEY (`DepaID`) REFERENCES `department` (`DepaID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `doctors`
--

LOCK TABLES `doctors` WRITE;
/*!40000 ALTER TABLE `doctors` DISABLE KEYS */;
INSERT INTO `doctors` VALUES (1,'Yousif',20,'ysf@gmail.com',99000,5,1),(2,'Mohamed',41,'moh@gmail.com',80000,7,1),(3,'Fatma',34,'fat@gmail.com',7000,7,2),(4,'Karema',19,'k@gmail.com',1000,2,2),(5,'Ahmed',90,'Ahmed@gmail.com',17000,9,3),(6,'Ahmedoooo',90,'Ahmed@gmail.com',17000,9,3),(7,'Aged_SpiderMan',80,'Spider@gmail.com',155,2,1);
/*!40000 ALTER TABLE `doctors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lab`
--

DROP TABLE IF EXISTS `lab`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lab` (
  `LabID` int NOT NULL,
  `LabManager` varchar(45) DEFAULT NULL,
  `LabWorknights` varchar(45) DEFAULT NULL,
  `DoctorID` int DEFAULT NULL,
  PRIMARY KEY (`LabID`),
  KEY `DOCLAb_idx` (`DoctorID`),
  CONSTRAINT `DOCLAb` FOREIGN KEY (`DoctorID`) REFERENCES `doctors` (`DoctorID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lab`
--

LOCK TABLES `lab` WRITE;
/*!40000 ALTER TABLE `lab` DISABLE KEYS */;
INSERT INTO `lab` VALUES (1,'YousifRA','9 to 11 AM',1),(2,'Ahmedo','11 to 1 PM',2),(3,'Medo','12 to 3 PM',3),(4,'Hasan','1 to 4 PM',1),(5,'Fathy','5 to 12 Am',4);
/*!40000 ALTER TABLE `lab` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nurse`
--

DROP TABLE IF EXISTS `nurse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nurse` (
  `NurseID` int NOT NULL,
  `NurseName` varchar(45) DEFAULT NULL,
  `NurseAge` int DEFAULT NULL,
  `NurseWorknights` varchar(45) DEFAULT NULL,
  `NurseSalary` int DEFAULT NULL,
  `RoomID` int DEFAULT NULL,
  PRIMARY KEY (`NurseID`),
  KEY `NurseRoomFK_idx` (`RoomID`),
  CONSTRAINT `NurseRoomFK` FOREIGN KEY (`RoomID`) REFERENCES `rooms` (`RoomID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nurse`
--

LOCK TABLES `nurse` WRITE;
/*!40000 ALTER TABLE `nurse` DISABLE KEYS */;
INSERT INTO `nurse` VALUES (1,'Fatima',29,'3',12000,1),(2,'Elena',34,'5',14500,2),(3,'Grace',27,'2',11000,3),(4,'Jia',40,'5',16000,4),(5,'Haya',3,'1',100001,2);
/*!40000 ALTER TABLE `nurse` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `patient`
--

DROP TABLE IF EXISTS `patient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `patient` (
  `PatientID` int NOT NULL AUTO_INCREMENT,
  `PatientName` varchar(45) DEFAULT NULL,
  `PatientTelphone` varchar(45) DEFAULT NULL,
  `PatientAddress` varchar(45) DEFAULT NULL,
  `PatientAge` int unsigned DEFAULT NULL,
  `PatientGender` varchar(45) DEFAULT NULL,
  `PatientBloodgrp` varchar(45) DEFAULT NULL,
  `DeparmentID` int DEFAULT NULL,
  `DoctorID` int DEFAULT NULL,
  `RoomID` int DEFAULT NULL,
  `NurseID` int DEFAULT NULL,
  PRIMARY KEY (`PatientID`),
  KEY `PatientFK_idx` (`DoctorID`),
  KEY `PatientFK2_idx` (`RoomID`),
  KEY `PatientFK3_idx` (`DeparmentID`),
  KEY `PatientFK4_idx` (`NurseID`),
  CONSTRAINT `PatientFK1` FOREIGN KEY (`DoctorID`) REFERENCES `doctors` (`DoctorID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `PatientFK2` FOREIGN KEY (`RoomID`) REFERENCES `rooms` (`RoomID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `PatientFK3` FOREIGN KEY (`DeparmentID`) REFERENCES `department` (`DepaID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `PatientFK4` FOREIGN KEY (`NurseID`) REFERENCES `nurse` (`NurseID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `patient`
--

LOCK TABLES `patient` WRITE;
/*!40000 ALTER TABLE `patient` DISABLE KEYS */;
INSERT INTO `patient` VALUES (1,'Omar Ali','0501112233','Dubai',25,'Male','A+',1,1,1,1),(2,'Sara Khan','0554445566','Sharjah',30,'Female','O-',1,2,2,2),(3,'Zayed Ahmed','0527778899','Abu Dhabi',45,'Male','B+',2,3,3,3),(4,'Maryam J.','0564445556','Ajman',19,'Female','AB+',3,5,4,4),(5,'John Smith','0583332211','Dubai',72,'Male','O+',1,4,1,3);
/*!40000 ALTER TABLE `patient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rooms`
--

DROP TABLE IF EXISTS `rooms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rooms` (
  `RoomID` int NOT NULL,
  `RoomNo` int DEFAULT NULL,
  `RoomFloor` varchar(45) DEFAULT NULL,
  `RoomSize` int DEFAULT NULL,
  PRIMARY KEY (`RoomID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rooms`
--

LOCK TABLES `rooms` WRITE;
/*!40000 ALTER TABLE `rooms` DISABLE KEYS */;
INSERT INTO `rooms` VALUES (1,101,'first floor',15),(2,102,'First floor',20),(3,201,'Second Floor',25),(4,301,'Third Floor',35);
/*!40000 ALTER TABLE `rooms` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-08 21:03:01
