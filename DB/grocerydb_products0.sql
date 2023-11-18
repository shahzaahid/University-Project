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
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Price` decimal(10,2) NOT NULL,
  `Unit` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PackSize` int NOT NULL,
  `VendorId` int NOT NULL,
  `AddedBy` int NOT NULL,
  `StockQty` double NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,'Onion','wani shops','vegetables','Fresh Home Grown Onions',40.00,'kg',1,1,1,10),(2,'Potato','wani shops','vegetables','Fresh Home Grown potato',30.00,'kg',1,1,1,10),(3,'Apple','wani shops','Fruits','Kashmiri Apples',100.00,'kg',1,1,1,10),(4,'Kiwi','wani shops','Fruits','Imported Kiwi',150.00,'kg',1,1,1,10),(5,'chilli ','wani shops','vegetables','Fresh Home Grown chilli ',60.00,'kg',1,1,1,10),(6,'Brinjal','wani shops','vegetables','Fresh Home Grown Brinjal',45.00,'kg',1,1,1,10),(7,'Orange','wani shops','Fruits','Imported Orange Sweet In Taste',120.00,'kg',1,1,1,10),(8,'Tomato','wani shops','vegetables','Fresh Home Grown tomato',60.00,'kg',1,1,1,10),(9,'Capsicum','wani shops','vegetables','Fresh Home Grown Shimla',60.00,'kg',1,1,1,10),(10,'Lemon','wani shops','vegetables','New Sour Lemons',70.00,'kg',1,1,1,10),(11,'Brocli','wani shops','vegetables','New Fresh Brocli',90.00,'kg',1,1,1,10),(12,'Red Bull','wani shops','Drink','Energy Drink',110.00,'Ml',250,1,1,10),(13,'Ginger ','wani shops','Drink','Ginger Drink',60.00,'Ml',250,1,1,10),(14,'Spike','wani shops','Drink','All New Refreshing Drink',80.00,'Ml',250,1,1,10),(15,'Monoster','wani shops','Drink','Energy Drink',110.00,'Ml',250,1,1,10),(16,'Fanta','wani shops','Drink','Juice',110.00,'Ml',250,1,1,10),(17,'Coca Cola','wani shops','Drink','Juice',110.00,'Ml',250,1,1,10),(18,'Sprite','wani shops','Drink','Juice',110.00,'Ml',250,1,1,10),(19,'Strawberry','wani shops','Fruits','Imported Strawberry',90.00,'kg',1,1,1,10),(20,'Papaya','wani shops','Fruits','Fresh Papaya',80.00,'kg',1,1,1,10),(21,'Cocunut','wani shops','Fruits','Cocunut',40.00,'gm',1,1,1,10),(22,'Banana','wani shops','Fruits','Banana',72.00,'dozen',12,1,1,120),(23,'Egg','wani shops','Animal Product','Eggs',60.00,'dozen',12,1,1,120),(24,'Meat','wani shops','Meat','Fresh Sheep Meat',650.00,'Kg',1,1,1,5),(25,'Walnut','wani shops','Dry Fruits','Kashmiri Walnut',700.00,'Kg',1,1,1,5),(26,'Mong Dal','wani shops','Spices','Mong Dal',130.00,'Kg',1,1,1,5),(27,'Neiva','wani shops','Personal Care','Face wash',190.00,'Bottle',1,1,1,5),(28,'Bajag','wani shops','Personal Care','Hair Oil',110.00,'Bottle',1,1,1,5),(29,'Dye','wani shops','Personal Care','Hair Dye',90.00,'1',1,1,1,5),(30,'Whisper','wani shops','Personal Care','Sanitary Pads',80.00,'1',1,1,1,5),(31,'Tooth bresh','wani shops','Personal Care','Oral B Tooth Brush',50.00,'1',1,1,1,5),(32,'Hand Wash','wani shops','Personal Care','Dettol hand Wash',120.00,'Bottle',1,1,1,5),(33,'Shampoo','wani shops','Personal Care','Santoor',155.00,'Bottle',1,1,1,5),(34,'Shampoo','wani shops','Personal Care','Dove',195.00,'Bottle',1,1,1,5),(35,'Ear Buds','wani shops','Chemist','Johnson Ear Buds',400.00,'Bottle',1,1,1,5),(36,'Eno','wani shops','Cehmist','Lemon Taste Eno',37.00,'Bottle',1,1,1,5),(37,'Anticaptic','wani shops','Cehmist','Salvon Anticaptic',89.00,'Bottle',1,1,1,5),(38,'Iodex','wani shops','Cehmist','Pain Relief Iodex',105.00,'Bottle',1,1,1,5),(39,'Anticaptic','wani shops','Cehmist','Dettol Anticaptic',79.00,'Bottle',1,1,1,5),(40,'Vapo Rub','wani shops','Cehmist','Viks Vapo Rub',95.00,'Bottle',1,1,1,5);
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

-- Dump completed on 2023-10-29 11:40:49
