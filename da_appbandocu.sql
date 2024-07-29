/*
 Navicat Premium Data Transfer

 Source Server         : localhost
 Source Server Type    : MySQL
 Source Server Version : 80039
 Source Host           : localhost:3306
 Source Schema         : da_appbandocu

 Target Server Type    : MySQL
 Target Server Version : 80039
 File Encoding         : 65001

 Date: 29/07/2024 21:27:49
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for __efmigrationshistory
-- ----------------------------
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE `__efmigrationshistory`  (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of __efmigrationshistory
-- ----------------------------
INSERT INTO `__efmigrationshistory` VALUES ('20240721132723_FirstInit', '6.0.31');
INSERT INTO `__efmigrationshistory` VALUES ('20240724165503_Update', '6.0.31');

-- ----------------------------
-- Table structure for carts
-- ----------------------------
DROP TABLE IF EXISTS `carts`;
CREATE TABLE `carts`  (
  `CartID` int NOT NULL AUTO_INCREMENT,
  `UserID` int NOT NULL,
  `ProductID` int NOT NULL,
  `Quantity` int NOT NULL,
  `CreatedDate` datetime(6) NULL DEFAULT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ModifiedDate` datetime(6) NULL DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`CartID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 7 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of carts
-- ----------------------------
INSERT INTO `carts` VALUES (3, 1, 1, 6, NULL, NULL, NULL, NULL);
INSERT INTO `carts` VALUES (5, 1, 3, 1, NULL, NULL, NULL, NULL);
INSERT INTO `carts` VALUES (6, 1, 2, 1, NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for categorys
-- ----------------------------
DROP TABLE IF EXISTS `categorys`;
CREATE TABLE `categorys`  (
  `CategoryID` int NOT NULL AUTO_INCREMENT,
  `CategoryName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `CreatedDate` datetime(6) NULL DEFAULT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ModifiedDate` datetime(6) NULL DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`CategoryID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of categorys
-- ----------------------------

-- ----------------------------
-- Table structure for chats
-- ----------------------------
DROP TABLE IF EXISTS `chats`;
CREATE TABLE `chats`  (
  `ChatID` int NOT NULL AUTO_INCREMENT,
  `FromID` int NOT NULL,
  `ToID` int NOT NULL,
  `Message` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreatedDate` datetime(6) NULL DEFAULT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ModifiedDate` datetime(6) NULL DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`ChatID`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of chats
-- ----------------------------

-- ----------------------------
-- Table structure for orderdetails
-- ----------------------------
DROP TABLE IF EXISTS `orderdetails`;
CREATE TABLE `orderdetails`  (
  `ID` int NOT NULL AUTO_INCREMENT,
  `OrderID` int NOT NULL,
  `OrderCode` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductID` int NOT NULL,
  `ProductName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Quantity` int NOT NULL,
  `Price` int NOT NULL,
  `TotalPrice` int NOT NULL,
  `CreatedDate` datetime(6) NULL DEFAULT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ModifiedDate` datetime(6) NULL DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`ID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 13 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of orderdetails
-- ----------------------------
INSERT INTO `orderdetails` VALUES (7, 1, 'DH00001', 1, 'Mountain Warehouse for Women', 6, 420, 0, NULL, NULL, NULL, NULL);
INSERT INTO `orderdetails` VALUES (8, 1, 'DH00001', 3, 'FS - Nike Air Max 270 Really React', 1, 390, 0, NULL, NULL, NULL, NULL);
INSERT INTO `orderdetails` VALUES (9, 1, 'DH00001', 2, 'Mountain Beta Warehouse', 1, 800, 0, NULL, NULL, NULL, NULL);
INSERT INTO `orderdetails` VALUES (10, 2, 'DH00002', 1, 'Mountain Warehouse for Women', 6, 420, 0, NULL, NULL, NULL, NULL);
INSERT INTO `orderdetails` VALUES (11, 2, 'DH00002', 3, 'FS - Nike Air Max 270 Really React', 1, 390, 0, NULL, NULL, NULL, NULL);
INSERT INTO `orderdetails` VALUES (12, 2, 'DH00002', 2, 'Mountain Beta Warehouse', 1, 800, 0, NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for orders
-- ----------------------------
DROP TABLE IF EXISTS `orders`;
CREATE TABLE `orders`  (
  `OrderID` int NOT NULL AUTO_INCREMENT,
  `OrderCode` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UserID` int NOT NULL,
  `MerchanID` int NOT NULL,
  `TotalPrice` int NOT NULL,
  `Address` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProvinceID` int NOT NULL,
  `DistrictID` int NOT NULL,
  `WardID` int NOT NULL,
  `IsDefault` int NOT NULL,
  `Note` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Status` int NOT NULL,
  `CreatedDate` datetime(6) NULL DEFAULT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ModifiedDate` datetime(6) NULL DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`OrderID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of orders
-- ----------------------------
INSERT INTO `orders` VALUES (1, 'DH00001', 1, 0, 3710, '', 0, 0, 0, 0, NULL, 0, NULL, NULL, NULL, NULL);
INSERT INTO `orders` VALUES (2, 'DH00002', 1, 0, 3710, '', 0, 0, 0, 0, NULL, 0, NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for productfavorites
-- ----------------------------
DROP TABLE IF EXISTS `productfavorites`;
CREATE TABLE `productfavorites`  (
  `ProductFavoriteID` int NOT NULL AUTO_INCREMENT,
  `UserID` int NOT NULL,
  `ProductID` int NOT NULL,
  `CreatedDate` datetime(6) NULL DEFAULT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ModifiedDate` datetime(6) NULL DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`ProductFavoriteID`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of productfavorites
-- ----------------------------

-- ----------------------------
-- Table structure for products
-- ----------------------------
DROP TABLE IF EXISTS `products`;
CREATE TABLE `products`  (
  `ProductID` int NOT NULL AUTO_INCREMENT,
  `ProductName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `TotalAmount` int NOT NULL,
  `TotalSold` int NOT NULL,
  `Vote` float NOT NULL,
  `Price` int NOT NULL,
  `PriceSale` int NOT NULL,
  `PercentSale` int NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ImageUrl` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreatedDate` datetime(6) NULL DEFAULT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ModifiedDate` datetime(6) NULL DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `CategoryID` int NOT NULL DEFAULT 0,
  PRIMARY KEY (`ProductID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 7 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of products
-- ----------------------------
INSERT INTO `products` VALUES (1, 'Mountain Warehouse for Women', 1, 1, 1, 540, 420, 20, '1', 'https://i.imgur.com/CGCyp1d.png', NULL, NULL, NULL, NULL, 0);
INSERT INTO `products` VALUES (2, 'Mountain Beta Warehouse', 1, 0, 1, 800, 800, 0, NULL, 'https://i.imgur.com/AkzWQuJ.png', NULL, NULL, NULL, NULL, 0);
INSERT INTO `products` VALUES (3, 'FS - Nike Air Max 270 Really React', 1, 0, 1, 650, 390, 40, NULL, 'https://i.imgur.com/J7mGZ12.png', NULL, NULL, NULL, NULL, 0);
INSERT INTO `products` VALUES (4, 'Green Poplin Ruched Front', 1, 0, 1, 1260, 1200, 5, NULL, 'https://i.imgur.com/q9oF9Yq.png', NULL, NULL, NULL, NULL, 0);
INSERT INTO `products` VALUES (5, 'Mountain Beta Warehouse', 1, 0, 1, 800, 800, 0, NULL, 'https://i.imgur.com/MsppAcx.png', NULL, NULL, NULL, NULL, 0);
INSERT INTO `products` VALUES (6, 'Mountain Beta Warehouse', 1, 0, 1, 800, 800, 0, NULL, 'https://i.imgur.com/JfyZlnO.png', NULL, NULL, NULL, NULL, 0);

-- ----------------------------
-- Table structure for roles
-- ----------------------------
DROP TABLE IF EXISTS `roles`;
CREATE TABLE `roles`  (
  `RoleID` int NOT NULL AUTO_INCREMENT,
  `RoleName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreatedDate` datetime(6) NULL DEFAULT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ModifiedDate` datetime(6) NULL DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`RoleID`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of roles
-- ----------------------------

-- ----------------------------
-- Table structure for useraddresses
-- ----------------------------
DROP TABLE IF EXISTS `useraddresses`;
CREATE TABLE `useraddresses`  (
  `UserAddressID` int NOT NULL AUTO_INCREMENT,
  `UserID` int NOT NULL,
  `Address` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProvinceID` int NOT NULL,
  `DistrictID` int NOT NULL,
  `WardID` int NOT NULL,
  `IsDefault` int NOT NULL,
  `CreatedDate` datetime(6) NULL DEFAULT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ModifiedDate` datetime(6) NULL DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`UserAddressID`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of useraddresses
-- ----------------------------

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users`  (
  `UserID` int NOT NULL AUTO_INCREMENT,
  `Username` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Password` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Fullname` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `RoleID` int NOT NULL,
  `CreatedDate` datetime(6) NULL DEFAULT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ModifiedDate` datetime(6) NULL DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`UserID`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of users
-- ----------------------------

SET FOREIGN_KEY_CHECKS = 1;
