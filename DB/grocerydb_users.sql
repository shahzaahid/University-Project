-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: grocerydb
-- ------------------------------------------------------
-- Server version	8.0.34

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
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` int NOT NULL,
  `FirstName` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `MiddleName` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `LastName` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Parentage` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Gender` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Dob` date NOT NULL,
  `MobileNo` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `EmailId` varchar(60) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Password` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `AddedBy` int DEFAULT NULL,
  `AddedOn` datetime(6) DEFAULT NULL,
  `UpdatedOn` datetime(6) DEFAULT NULL,
  `Status` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `EmailLogger` (`EmailId`),
  UNIQUE KEY `MobileLogger` (`MobileNo`),
  KEY `IX_Users_AddedBy` (`AddedBy`),
  KEY `IX_Users_RoleId` (`RoleId`),
  CONSTRAINT `FK_Users_Roles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Users_Users_AddedBy` FOREIGN KEY (`AddedBy`) REFERENCES `users` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,1,'ZAHID','RASHID','SHAH','ABDUL RASHID SHAH ','M','1999-01-03','7006379218','SHAHZAAHID038@GMAIL.COM','Zahid@123',1,'2000-03-05 00:00:00.000000','0200-03-05 00:00:00.000000','ACTIVE'),(2,2,'Jane','Doe','Sarah',' Doe','F','1985-08-23','1234567890','jane.doe@example.com','secret456',1,'2023-09-09 08:05:00.000000','2023-09-09 08:05:00.000000','Active'),(3,3,'Michael','Johnson','Robert',' Johnson','M','1985-08-23','12347890','michael.j@example.com','mypass789',1,'2023-09-09 08:10:00.000000','2023-09-09 08:10:00.000000','Inactive'),(4,4,'Emily','Williams','Susan','Williams','F','1985-08-23','123456790','emily.w@example.com','secure321',1,'2023-09-09 08:15:00.000000','2023-09-09 08:15:00.000000','Active'),(5,5,'danish','yousuf','wani','mohd yousuf','M','1990-01-15','7006606066','danish@gmail.com','danish@123',1,'2023-09-10 12:42:59.000000','2023-09-10 12:42:59.000000','Active'),(6,6,'mudasir','gul','rather','ghulam mohd','M','1985-05-20','9876543210','mudasir@gmail.com','mudasir@123',1,'2023-09-10 12:42:59.000000','2023-09-10 12:42:59.000000','Active'),(9,1,'rouf','','ahmad','mohd yousuf','M','2023-09-23','9086598809','rouf@gmail.com','rouf',1,NULL,NULL,NULL),(10,1,'akif','','bhat','mohd','M','2023-09-10','7009876547','akif@gmail.com','akif',1,NULL,NULL,'active'),(11,1,'sajad','','ahangar','mohd','M','2016-02-08','6006545678','sajad@gmail.com','sajad',1,NULL,NULL,'Deleted'),(12,1,'naseer','','reshi','ahmad','M','2016-06-05','7009876543','nasser@gmail.com','naseer',1,NULL,NULL,'Deleted'),(14,1,'nusrat','','reshi','mohd','F','2023-09-12','7009876555','nusrat@gmail.com','nusrat',1,NULL,NULL,'Deleted');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-10-19 17:16:43
