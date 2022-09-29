START TRANSACTION;

DROP TABLE IF EXISTS `Command`;
DROP TABLE IF EXISTS `Platform`;
DROP TABLE IF EXISTS `Category`;

COMMIT;




CREATE TABLE `Platform` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(256) NOT NULL,
  PRIMARY KEY (`ID`)
);

CREATE TABLE `Category` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(256) NOT NULL,
  PRIMARY KEY (`ID`)
);

CREATE TABLE `Command` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `PlatformID` int,
  `CategoryID` int,
  `Tittle` varchar(256) NOT NULL,
  `CommandText` varchar(256) NOT NULL,
  `Note` varchar(256) NOT NULL,
  `Description` varchar(256) NOT NULL,
  `FileLocation` varchar(256) NOT NULL,
  `MakeDate` DATE NOT NULL,
  `UpdateDate` DATE NOT NULL,
  PRIMARY KEY (`ID`),
  FOREIGN KEY (PlatformID) REFERENCES Platform(ID) ON DELETE CASCADE,
  FOREIGN KEY (CategoryID) REFERENCES Category(ID) ON DELETE CASCADE
);

COMMIT;
/*------------------------------------------------------------------------------------------------------*/
/* Insert Test Data */
/*------------------------------------------------------------------------------------------------------*/

INSERT INTO `Command` (`PlatformID`, `CategoryID`, `Tittle`, `CommandText`, `Note`, `Description`, `FileLocation`, `MakeDate`, `UpdateDate`) VALUES
(1, 1, 'test Command', 'ls', 'this is a test note', 'this is a test description', 'somelocation', '2019-06-05', '2019-06-05');

INSERT INTO `Platform` (`Name`) VALUES
('Linux'),
('Mac'),
('Windows');

INSERT INTO `Category` (`Name`) VALUES
('Command'),
('Setup'),
('install');