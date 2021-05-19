/*TABLES*/

CREATE TABLE `BerletTipusok` (
	
	`berlet_id` int(5) NOT NULL AUTO_INCREMENT,
	`megnevezes` varchar(50) NOT NULL,
	`ar` int(5) NOT NULL,
	`hanynapigervenyes` int(5) NOT NULL,
	`hanybelepeservenyes` int(5) NOT NULL,
	`torolve` varchar(10) NOT NULL,
	`terem_id` int(5) NOT NULL,
	`hanyoratol` TIME(6) NOT NULL,
	`hanyoraig` TIME(6) NOT NULL,
	`napontahanyszorhasznalhato` int(5) NOT NULL,
    PRIMARY KEY (`berlet_id`)
    );
    
CREATE TABLE `Kliensek` (
	
	`kliens_id` int(5) NOT NULL AUTO_INCREMENT,
	`nev` varchar(50) NOT NULL,
	`telefon` int(10) NOT NULL,
	`email` varchar(50) NOT NULL,
	`is_deleted` varchar(50) NOT NULL,
	`photo` varchar(50) NOT NULL,
	`inserted_date` date NOT NULL,
	`szemelyi` varchar(50) NOT NULL,
	`cim` varchar(50) NOT NULL,
	`vonalkod` varchar(50) NOT NULL,
	`megjegyzesek` varchar(50) NOT NULL,
    PRIMARY KEY (`kliens_id`)
    );
    
CREATE TABLE `Belepesek` (
	
	`belepes_id` int(5) NOT NULL AUTO_INCREMENT,
	`kliens_id` int(5) NOT NULL,
	`berlet_id` int(5) NOT NULL,
	`datum` date NOT NULL,
	`insertedby_uid` varchar(50) NOT NULL,
	`barcode` varchar(50) NOT NULL,
	`terem_id` int(5) NOT NULL,
    PRIMARY KEY (`belepes_id`)
    );
    
CREATE TABLE `KliensBerletei` (
	
	`kliens_berletei_id` int(5) NOT NULL AUTO_INCREMENT,
	`kliens_id` int(5) NOT NULL,
	`berlet_id` int(5) NOT NULL,
	`vasarlasi_datum` date NOT NULL,
	`vonalkod` varchar(50) NOT NULL,
	`eddigibelepesszam` int(15) NOT NULL,
	`eladasiar` int(10) NOT NULL,
	`ervenyes` varchar(50) NOT NULL,
	`elsohasznalati_datum` date NOT NULL,
	`terem_id` int(5) NOT NULL,
    PRIMARY KEY (`kliens_berletei_id`)
    );
    
CREATE TABLE `FTermek` (
	
	`terem_id` int(5) NOT NULL AUTO_INCREMENT,
	`nev` varchar(50) NOT NULL,
	`is_deleted` varchar(50) NOT NULL,
    PRIMARY KEY (`terem_id`)
    );
    
/*INSERTS*/

INSERT INTO `BerletTipusok` (`megnevezes`, `ar`, `hanynapigervenyes`, `hanybelepeservenyes`, `torolve`, `terem_id`, `hanyoratol`,
`hanyoraig`, `napontahanyszorhasznalhato`) VALUES
('Fitness Only','200','30','30','NEM','1','06:00','21:00','1'),
('FitnessWellness','500','30','30','NEM','2','06:00','21:00',1),
('Student Ticket','150','30','30','NEM','1','06:00','14:00','1'),
('VIP Ticket','2000','365','365','NEM','1','06:00','21:00',1),
('TeamFit','130','30','30','NEM','2','18:00','21:00',1);

INSERT INTO `Kliensek` (`nev`,`telefon`,`email`,`is_deleted`,`photo`,`inserted_date`,`szemelyi`,`cim`,`vonalkod`,`megjegyzesek`) VALUES
('Nagy Andrea','0746025612','andinagy@yahoo.com','NEM',' ','2021-04-10','2940125670020','Cornisa 10','1523456789',' '),
('Sandor Jozsef','0745673643','jozsef@gmail.com','NEM',' ','2021-03-25','1950225270021','Prieteniei 10','0987654321',' '),
('Kiss Alpar','0757832467','alparkiss@gmail.com','NEM',' ','2021-04-08','1980130210015','Pandurilor 15','0246857953','magas vernyomas'),
('Kedves Lorand','0756784324','lorik@yahoo.com','NEM',' ','2021-01-15','1930542670020','Horea 14','03245629872',' '),
('Abraham Imola','0746345632','imolaabr@gmail.com','NEM',' ','2021-02-05','2940125670020','Padurii 12','0021347856',' ');

INSERT INTO `Belepesek` (`kliens_id`,`berlet_id`,`datum`,`insertedby_uid`,`barcode`,`terem_id`) VALUES
('1','1','2021-03-12','1','123456789','1'),
('2','2','2021-02-15','2','987654321','2'),
('3','3','2021-05-05','3','246857953','2'),
('4','4','2021-01-08','4','3245629872','1'),
('5','5','2021-05-10','5','021347856','2');

INSERT INTO `KliensBerletei` (`kliens_id`,`berlet_id`,`vasarlasi_datum`,`vonalkod`,`eddigibelepesszam`,`eladasiar`,`ervenyes`,`elsohasznalati_datum`,`terem_id`) VALUES
('1','1','2021-04-10','123456789','10','160','IGEN','2021-04-10','1'),
('2','2','2021-03-25','987654321','25','140','IGEN','2021-03-27','2'),
('3','3','2021-04-08','246857953','2','120','IGEN','2021-04-08','2'),
('4','4','2021-01-15','3245629872','30','1300','IGEN','2021-01-16','1'),
('5','5','2021-02-05','021347856','5','125','IGEN','2021-02-05','3');

INSERT INTO `ftermek`(`nev`,`is_deleted`) VALUES
('FitGym','NEM'),
('NewGym','NEM');

/*LEKERDEZESEK*/

SELECT * FROM BerletTipusok;

SELECT * FROM Kliensek;

SELECT * FROM Belepesek;

SELECT * FROM KliensBerletei;

SELECT * FROM FTermek;

INSERT INTO `BerletTipusok` (`megnevezes`, `ar`, `hanynapigervenyes`, `hanybelepesreervenyes`, `torolve`, `terem_id`, `hanyoratol`,
`hanyoraig`, `napontahanyszorhasznalhato`) VALUES
('FitForYou','100','30','30','NEM','1','06:00','21:00','1');

SELECT * FROM BerletTipusok;

DELETE FROM BerletTipusok WHERE berlet_id = 6;

SELECT * FROM BerletTipusok;

INSERT INTO `Kliensek` (`nev`,`telefon`,`email`,`is_deleted`,`photo`,`inserted_date`,`szemelyi`,`cim`,`vonalkod`,`megjegyzesek`) VALUES
('Benedek Andras','0746325125','andrasbenedek@gmail.com','NEM',' ','2021-01-27','1524789650025','Armoniei 10','187634586',' ');

SELECT * FROM Kliensek;

DELETE FROM Kliensek WHERE kliens_id = 6;

SELECT * FROM KliensBerletei;

SELECT * FROM FTermek;

DROP TABLE BerletTipusok;
DROP TABLE Kliensek;
DROP TABLE Belepesek;
DROP TABLE KliensBerletei;
DROP TABLE FTermek;

SELECT * FROM BerletTipusok;