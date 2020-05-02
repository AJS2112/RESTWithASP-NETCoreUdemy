-- rest_with_asp_net_udemy.persons definition

CREATE TABLE `persons` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(50) DEFAULT NULL,
  `LastName` varchar(50) DEFAULT NULL,
  `Address` varchar(50) DEFAULT NULL,
  `Gender` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `books` (
  `Id` varchar(127) NOT NULL,
  `Author` longtext DEFAULT NULL,
  `LaunchDate` datetime(6) DEFAULT NULL,
  `Price` decimal(65,2) DEFAULT NULL,
  `Title` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;