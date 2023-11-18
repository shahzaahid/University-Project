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
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Brand` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Category` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Price` decimal(10,2) NOT NULL,
  `Unit` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PackSize` int NOT NULL,
  `VendorId` int NOT NULL,
  `AddedBy` int NOT NULL,
  `StockQty` double NOT NULL,
  `AddedOn` datetime(6) DEFAULT NULL,
  `UpdatedOn` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Products_AddedBy` (`AddedBy`),
  KEY `IX_Products_VendorId` (`VendorId`),
  CONSTRAINT `FK_Products_Users_AddedBy` FOREIGN KEY (`AddedBy`) REFERENCES `users` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Products_Vendor_VendorId` FOREIGN KEY (`VendorId`) REFERENCES `vendor` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,'onion','organic','Vegetables','Fresh Onion',40.00,'kg',1,1,1,3,'2000-02-02 00:00:00.000000',NULL),(2,'Milk','Amul','Dairy','Fresh whole milk',50.00,'litre',1,1,1,5,'2023-09-09 08:05:00.000000','2023-09-09 08:05:00.000000'),(3,'Apples','Delicious','Fruits','Red apples',100.00,'lb',2,1,1,5,'2023-09-09 08:10:00.000000','2023-09-09 08:10:00.000000'),(4,'Ghee','organic','Ghee','Pure Cow Ghee',150.00,'kg',1,1,1,5,'2023-09-09 08:15:00.000000','2023-09-09 08:15:00.000000'),(5,'Sugar','Tata','Spices','Tata Sugar',30.00,'kg',1,1,1,5,'2023-09-09 08:20:00.000000','2023-09-09 08:20:00.000000'),(6,'Rice','Red Apple','Grains','Long-grain white rice',900.00,'kg',100,2,1,5,'2023-09-09 08:00:00.000000','2023-09-09 08:00:00.000000'),(7,'Masala','kashmir','Spices','Home Made',350.00,'kg',1,2,1,5,'2023-09-25 00:00:00.000000','2023-09-25 00:00:00.000000'),(8,'Tomato','kashmir','Vegetable','Red Fresh Tomato',55.00,'kg',1,2,1,5,'2023-09-25 00:00:00.000000','2023-09-25 00:00:00.000000'),(9,'Brinjal','Punjabi','Vegetable',' Fresh Tomato',60.00,'kg',1,2,1,5,'2023-09-25 00:00:00.000000','2023-09-25 00:00:00.000000'),(10,'Tea','Classic','Drink','Lipton Tea',500.00,'kg',1,2,1,5,'2023-09-25 00:00:00.000000','2023-09-25 00:00:00.000000'),(11,'Bread','Mughal Darbar','Bread','Brown Bread',25.99,'pack',1,3,1,5,'2023-09-25 00:00:00.000000','2023-09-25 00:00:00.000000'),(12,'Potato','kashmir','Vegetable','Fresh Potato',30.00,'kg',1,3,1,5,'2023-09-25 00:00:00.000000','2023-09-25 00:00:00.000000'),(13,'Chillies','kashmir','Vegetable','Green chillies',45.00,'kg',1,3,1,5,'2023-09-25 00:00:00.000000','2023-09-25 00:00:00.000000'),(14,'kiwi','kashmir','Fruit','Imported kiwi',120.00,'kg',1,3,1,5,'2023-09-25 00:00:00.000000','2023-09-25 00:00:00.000000'),(16,'Fanta','Coke','Drink','New Refreshing Drink',30.00,'Ml',500,4,1,5,'2023-09-25 00:00:00.000000','2023-09-25 00:00:00.000000'),(17,'Coca Cola','Coke','Drink','New Refereshing Drink',35.00,'ML',500,4,1,5,'2023-09-25 00:00:00.000000','2023-09-25 00:00:00.000000'),(18,'Sprite','Coke','Drink','New Refereshing Drink',35.00,'Ml',500,4,1,5,'2023-09-25 00:00:00.000000','2023-09-25 00:00:00.000000'),(19,'RedBull','Coke','Drink','New Refereshing Drink',100.00,'Ml',500,4,1,5,'2023-09-25 00:00:00.000000','2023-09-25 00:00:00.000000'),(29,'bread','jan bakers','bread','brown bread',50.00,'Gram',1,4,2,1,NULL,NULL);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-10-19 17:16:42
