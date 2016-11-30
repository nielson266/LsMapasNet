-- MySqlBackup.NET 2.0.9.2
-- Dump Time: 2016-11-30 13:31:09
-- --------------------------------------
-- Server version 10.1.16-MariaDB mariadb.org binary distribution


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES latin1 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of mapas
-- 

DROP TABLE IF EXISTS `mapas`;
CREATE TABLE IF NOT EXISTS `mapas` (
  `id` int(11) NOT NULL,
  `desc_mapa` varchar(50) DEFAULT NULL,
  `obs` varchar(100) DEFAULT NULL,
  `centromapa_lat` varchar(15) DEFAULT NULL,
  `centromapa_long` varchar(15) DEFAULT NULL,
  `id_surdo` int(11) NOT NULL,
  `zoommapa` decimal(7,2) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table mapas
-- 

/*!40000 ALTER TABLE `mapas` DISABLE KEYS */;
INSERT INTO `mapas`(`id`,`desc_mapa`,`obs`,`centromapa_lat`,`centromapa_long`,`id_surdo`,`zoommapa`) VALUES
(1,'Grilo Nº 1','','-372713','-3866229',78,16.00),
(2,'Araturi Nº 2','','-376694','-3863772',3,16.00),
(3,'Araturi Nº 3','','-37650544','-386406146',1,17.00),
(4,'PQ.SOLEDADE Nº 4','','-373858','-3865116',172,16.00),
(6,'SÃO GERARDO Nº 6','','-374187','-3863869',177,16.00),
(8,'Itambé Nº 8','','-372862','-3865132',196,15.00),
(9,'Itambé Nº 9','','-372642','-3864602',199,16.00),
(11,'Capuan Nº 11','','-373473','-3869829',96,15.00),
(12,'Capuan Nº 12','','-373013','-3869913',99,15.00),
(13,'Capuan Nº 13','','-373259','-3870427',101,15.00),
(14,'Planalto Nº 14','','-374549','-3866475',106,18.00),
(15,'Planalto Nº 15','','-37420315','-386656232',276,16.00),
(16,'Pe. Julio Maria Nº 16','','-374011','-3867042',107,16.00),
(17,'Pe. Julio Maria Nº 17','','-373801','-3866888',109,15.00),
(18,'Marechal Rondon Nº 18','Antigo 6','-376944','-3862507',16,15.00),
(19,'Marechal Rondon Nº 19','Antigo 7','-377726','-3863030',71,16.00),
(20,'Marechal Rondon Nº 20','Antigo 8','-377165','-3861919',17,15.00),
(21,'Marechal Rondon Nº 21','Antigo 19','-37743337','-386248875',285,16.00),
(25,'ICARAI Nº 25','','0','0',281,15.00),
(26,'CUMBUCO Nº 26','','0','0',278,15.00),
(28,'Curicaca Nº 28','','0','0',283,15.00),
(29,'MESTRE ANTÔNIO Nº 11','','-370851','-3866415',211,15.00),
(30,'PQ. POTIRA 30','Antigo 1','-375899','-3862358',45,15.00),
(31,'PQ. POTIRA 31','','-376451','-3862797',41,15.00),
(32,'PQ. POTIRA 32','','-375916','-3863576',26,15.00),
(33,'PQ. POTIRA 33','','-375436','-3862425',36,15.00),
(34,'PQ. POTIRA 34','','-374862','-3862310',52,15.00),
(44,'Araturi Nº 44','Antigo 4 Araturi','-376909','-3863339',21,15.00),
(55,'Araturi Nº 55','Antigo 5','-376763','-3863121',24,16.00),
(56,'Araturi Nº 56','Antigo 18','-376989','-3863064',55,16.00),
(57,'Arianopoles Nº 57','Antigo 16','-376329','-3864960',61,16.00),
(58,'Araturi Nº 58','Arienopoles','-376548','-3864637',141,15.00),
(60,'AÇUDE','','-373986','-3865447',207,17.00),
(70,'Porteiras N° 70','','-373770','-3876230',124,15.00),
(71,'JARDIM DO AMOR N° 71','','-373997','-3871163',121,15.00),
(80,'METRÓPOLE 5','','-377276','-3865693',112,16.00),
(81,'METRÓPOLE (ELDORADO) N° 81','','-37720321','-386502917',120,16.00),
(82,'METRÓPOLE N° 82','','-376505','-3865692',82,15.00),
(83,'METROPOLITANO N° 83','','-375802','-3865838',89,16.00),
(84,'PQ. DAS NAÇOES N° 84','','-374922','-3860731',182,15.00),
(85,'PQ. ALBANO N° 85','','-376047','-3861572',184,16.00),
(86,'TABAPUÁ N° 86','','-374059','-3861351',171,15.00),
(200,'Cigana Nº 200','','-373893','-3865824',136,15.00),
(300,'Teste300','dasddas',NULL,NULL,0,15.00);
/*!40000 ALTER TABLE `mapas` ENABLE KEYS */;

-- 
-- Definition of mapasurdo
-- 

DROP TABLE IF EXISTS `mapasurdo`;
CREATE TABLE IF NOT EXISTS `mapasurdo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idMapa` int(11) NOT NULL,
  `idSurdo` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id` (`id`),
  KEY `idMapa` (`idMapa`),
  KEY `idSurdo` (`idSurdo`),
  CONSTRAINT `MapaSurdo_id_mapa` FOREIGN KEY (`idMapa`) REFERENCES `mapas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `MapaSurdo_id_surdo` FOREIGN KEY (`idSurdo`) REFERENCES `surdo` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=169 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table mapasurdo
-- 

/*!40000 ALTER TABLE `mapasurdo` DISABLE KEYS */;
INSERT INTO `mapasurdo`(`id`,`idMapa`,`idSurdo`) VALUES
(1,60,208),
(2,60,207),
(3,60,209),
(4,60,206),
(5,9,200),
(6,8,194),
(7,13,101),
(8,13,205),
(9,70,124),
(10,71,122),
(11,71,121),
(12,8,197),
(13,1,163),
(14,1,78),
(15,1,162),
(16,1,167),
(17,29,212),
(18,8,203),
(19,8,196),
(20,8,190),
(21,8,189),
(22,9,198),
(23,9,199),
(24,29,211),
(25,14,127),
(26,14,106),
(27,14,129),
(28,14,105),
(29,14,126),
(30,15,102),
(31,15,104),
(32,15,192),
(33,15,276),
(34,16,193),
(35,16,108),
(36,16,107),
(37,16,128),
(38,17,131),
(39,17,109),
(40,17,130),
(41,17,277),
(42,200,133),
(43,200,132),
(44,200,136),
(45,26,279),
(46,26,278),
(47,28,283),
(48,28,284),
(49,29,166),
(50,29,269),
(51,80,114),
(52,25,280),
(53,25,281),
(54,25,282),
(55,4,172),
(56,4,173),
(57,6,174),
(58,6,175),
(59,6,177),
(60,6,178),
(61,18,19),
(62,18,16),
(63,18,14),
(64,80,110),
(65,19,71),
(66,19,138),
(67,20,15),
(68,80,112),
(69,20,17),
(70,20,69),
(71,21,13),
(72,21,67),
(73,2,3),
(74,2,2),
(75,2,4),
(76,3,1),
(77,3,7),
(78,3,6),
(79,3,5),
(80,2,22),
(81,44,21),
(82,44,57),
(83,55,23),
(84,55,11),
(85,55,24),
(86,55,9),
(87,18,56),
(88,56,55),
(89,56,54),
(90,56,77),
(91,57,60),
(92,57,62),
(93,57,61),
(94,57,59),
(95,58,63),
(96,58,141),
(97,21,285),
(98,21,286),
(99,21,18),
(100,20,287),
(101,80,115),
(102,30,43),
(103,30,45),
(104,30,50),
(105,31,48),
(106,31,47),
(107,31,41),
(108,32,26),
(109,32,29),
(110,32,28),
(111,32,272),
(112,2,289),
(113,11,93),
(114,11,96),
(115,11,95),
(116,11,94),
(117,81,118),
(118,12,97),
(119,12,99),
(120,12,98),
(121,12,204),
(122,12,100),
(123,81,120),
(124,81,275),
(125,80,111),
(126,82,117),
(127,82,82),
(128,82,81),
(129,83,90),
(130,83,92),
(131,83,89),
(132,83,87),
(133,83,91),
(134,83,88),
(135,84,180),
(136,84,182),
(137,84,183),
(138,85,186),
(139,85,185),
(140,85,184),
(141,85,181),
(142,85,187),
(143,85,188),
(144,86,169),
(145,86,171),
(146,86,170),
(147,34,74),
(148,34,52),
(149,34,72),
(150,34,73),
(151,34,51),
(152,33,36),
(153,33,25),
(154,33,35),
(158,300,123),
(163,300,44),
(168,300,176);
/*!40000 ALTER TABLE `mapasurdo` ENABLE KEYS */;

-- 
-- Definition of surdo
-- 

DROP TABLE IF EXISTS `surdo`;
CREATE TABLE IF NOT EXISTS `surdo` (
  `id` int(11) NOT NULL,
  `nome` varchar(100) DEFAULT NULL,
  `endereco` varchar(100) DEFAULT NULL,
  `perimetro` varchar(100) DEFAULT NULL,
  `classe` varchar(1) DEFAULT NULL,
  `latitude` varchar(15) DEFAULT NULL,
  `longitude` varchar(15) DEFAULT NULL,
  `bairro` varchar(30) DEFAULT NULL,
  `status` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table surdo
-- 

/*!40000 ALTER TABLE `surdo` DISABLE KEYS */;
INSERT INTO `surdo`(`id`,`nome`,`endereco`,`perimetro`,`classe`,`latitude`,`longitude`,`bairro`,`status`) VALUES
(1,'Lucas Yago','Rua Nw vinte e três, bl 17, ap 22a','','1','-37650544','-386406146','CONJ. ARATURI','A'),
(2,'Alisson','Rua C, 52, 3.76788-38.63883','Perto da Av, São Vicente de Paula, perto NW 15','1','-376788','-3863883','CONJ. ARATURI','A'),
(3,'Cleide','Rua W 13, 166, -376694-3863772','Oralizada; Casada, Filha Edcléia','3','-376694','-3863772','CONJ. ARATURI','A'),
(4,'Isabel','Rua W 12, 39,  -376745-3863737','Oralizada, Não sabe sinais, Faculdade de Jornalismo, Mãe Duce','3','-376745','-3863737','CONJ. ARATURI','A'),
(5,'Natali Mce','Rua Nw 6, bl 37, ap 11d, -376487 -3863960','Natali oralizada, não se aceita como surda','3','-376487','-3863960','CONJ. ARATURI','A'),
(6,'Graca','Rua Nw 6, bl 42, ap 22b, -3765555-3863935','Trabalha na Guararapes','3','-376555','-3863935','CONJ. ARATURI','A'),
(7,'Caca','Rua Nw 9, bl 63','','1','-376558','-3863963','CONJ. ARATURI','A'),
(8,'Salco do Reino','Av. São Vicente de Paula, 1551, -376737-3864006','','7','-376737','-3864006','CONJ. ARATURI','T'),
(9,'Wevison','Rua 7, ultima casa, -376701-3863049','Estuda de tarde, sabe sinais','1','-376701','-3863049','ESPLANADA ARATURI (JUREMA)','A'),
(10,'Camila e Dulcimara','Rua 16,  841, -376624-3863038','Atrás de Ponto dos Estofados na Av. de Contorno Leste-Norte','3','-376624','-3863038','ARATURI  COND. VERDE (JUREMA)','A'),
(11,'Carlos Andre','Travessa 5, 840,-376725-3862935','','2','-376725','-3862935','ESPLANADA ARATURI (JUREMA)','A'),
(12,'Salco do Reino','Rua Catoche -3.76966 -38.62475','','7','-376966','-3862475','MARECHAL RONDON (JUREMA)','T'),
(13,'Virna ','Rua Canavieira, 671, -377616-3862864','Sabe sinais','3','-377616','-3862864','MARECHAL RONDON (JUREMA)','A'),
(14,'SEBASTIAO','Rua Canavieira, 230, -3.77107 -38.62433','UMA RUA DEPOIS DO TRILHO PRÓX A FEIRA; ADULTO;','1','-377107','-3862433','MARECHAL RONDON (JUREMA)','A'),
(15,'Jane','Rua Carpina, 227, -3.77282  -38.62074','Estuda com Neide','4','-377282','-3862074','MARECHAL RONDON (JUREMA)','A'),
(16,'Ana Paula','Rua Catoche , 311, -3.76944 -38.62507','Não sabe sinais; Irmã Juliete; Mãe Maria','3','-376944','-3862507','MARECHAL RONDON (JUREMA)','A'),
(17,'Camila','Rua Cocal, entre o 87 e 91 -3.77165 -38.61919','','4','-377165','-3861919','MARECHAL RONDON (JUREMA)','A'),
(18,'Erderson','Rua Ilha Grande, 377,  -3.77309 -38.62336','','1','-377309','-3862336','MARECHAL RONDON (JUREMA)','A'),
(19,'Crysleiane','Rua Joao Rocha, 296,  -3.76797-3862621','','3','-376797','-3862621','MARECHAL RONDON (JUREMA)','A'),
(21,'Flaudson','Rua Pedestre E 16, 139,  -376909-3863339','Entre Av. São Vicente de Paula x Rua Central, Sabe sinais, Casado','1','-376909','-3863339','PARQUE ARATURI (JUREMA)','A'),
(22,'Kassiandra','Rua A, 63,  -3.768002 -38.6398807','Sabe sinais, tem irmã ouvinte gêmea: Kessiandra, Mãe Katy, Entre RNw 23 x Av. Central Oeste','4','-376553','-3863630','ARATURI (JUREMA)','A'),
(23,'Keure','Av. de Contorno Leste- Norte, 1238, -3767121-3863226','Casada, ','3','-376712','-3863226','PARQUE ARATURI (JUREMA)','A'),
(24,'Natanael','Av. de Contorno Leste- Norte, 1260, -376763-3863121','Oralizado, sabe sinais','1','-376763','-3863121','PARQUE ARATURI (JUREMA)','A'),
(25,'Paulo Vitor','CONDOMINIO JURIPARI II BLOCO 33 AP 201','Entre R. Anagé x  R. Sacy,Oralizado,Não sabe sinais,Mãe Cimeir','1','-375898','-3861915','PARQUE GUADAJARA (JUREMA)','A'),
(26,'Marlene','Rua Consulmel, 1058. LA -375.916 LO -3.863.576','Oralizada; trabalha na semana; estudante;','3','-375916','-3863576','PARQUE POTIRA (JUREMA)','A'),
(27,'Ivania','Rua Consulmel, 402. LA -376.293 LO -3.863.133','Entre R. Guará x Colibri; estudante','3','-376293','-3863133','PARQUE POTIRA (JUREMA)','A'),
(28,'Celina','Rua Consulmel, 640 LA -376.157 LO -3.863.295','Entre R. Anhagá x Colibri; Mãe Célia; Estuda a tarde no M. Dourado; Mental Leve;','3','-376157','-3863295','PARQUE POTIRA (JUREMA)','A'),
(29,'Janaina','Rua Torreon, 1270 LA -376.083 LO -3.863.224','Entre R. Anhagá x Colibri; Não sabe sinais; Casada; Viciada em drogas;','3','-376083','-3863224','PARQUE POTIRA (JUREMA)','A'),
(30,'Lopes Junior & Andrea','Rua Irapua Vidal, 3558, -3.76204 -38.63370','PUBLICADORES','0','-376204','-3863370','PARQUE POTIRA (JUREMA)','T'),
(31,'Jarderson','R ua Acapulco, 1947 -3.75536 -38.62943','PUBLICADOR SURDO','0','-375536','-3862943','PARQUE POTIRA (JUREMA)','A'),
(32,'Zeneide --Mudou-se--','Travessa Taina,  51 -','Entre Consulmel x Torreon, perto da Anhanga, estudante','3','-376098','-3863337','PARQUE POTIRA (JUREMA)','A'),
(33,'Yasmim -- Mudou-se','Rua Guara, 1279 altos','Entre Torreon x Consumel, perto da Colibri, estudante. Mora com Rafael','3','-37633','-3862963','PARQUE POTIRA (JUREMA)','A'),
(34,'Raquel','Rua Acapulco, 1539','Entre R. Guará x Colibri; ','3','-375788','-3862643','PARQUE POTIRA (JUREMA)','A'),
(35,'Maria Cega  Surda','Rua Araquem, 220, -375291-3861934','','3','-375291','-3861934','PARQUE POTIRA (JUREMA)','A'),
(36,'Bruna','Rua Jarupary, 1500,','Entre R. Guará x Morelia','4','-375436','-3862425','PARQUE POTIRA (JUREMA)','A'),
(37,'Veridiana','Rua Poebla, 1415,','Entre R.Colibri x R. Guara','3','-376138','-3863011','PARQUE POTIRA (JUREMA)','A'),
(38,'Felipe','CONDOMINIO VERDE','Entre R, Araquém x Anagé, Não se aceita como Surdo','1','-376538','-3862552','ARATURI (JUREMA)','A'),
(39,'Raimundo Nonato','Rua Galiente, 2404','Entre R. Catumby x R. Paracatu','1','-375455','-3863177','PARQUE POTIRA (JUREMA)','A'),
(40,'Anderson Rodrigues','Rua Vera Cruz, 2220','Entre R. Catumby x R. Paracatu','1','-375597','-3863320','PARQUE POTIRA (JUREMA)','A'),
(41,'Rafael','Rua Torreon, 726,   -3.76451 -38.62797','Entre Heribaldo Rodrigues x  R. Araquem','1','-376451','-3862797','PARQUE POTIRA (JUREMA)','A'),
(42,'Salco do Reino','Rua Jorge Guimaraes, 490-3.76081 -38.61842','','7','-376081','-3861842','PARQUE POTIRA (JUREMA)','T'),
(43,'Davi & Nivea','Rua Padre Alfredo Nes, 1290 A','Mãe Zélia não aceita visista','5','-376183','-3862497','PARQUE POTIRA (JUREMA)','A'),
(44,'Ana Cristina Nogueira Lima','Rua Pedestre C , 105 -3.75780 -38.61889','Mãe Alzira; Surda sabe pouco sinais','3','-375780','-3861889','PARQUE POTIRA (JUREMA)','A'),
(45,'Gleicy Kelly','Rua Araré, 1139 -3.75899 -38.62358','Já foi publicadora;','3','-375899','-3862358','PARQUE POTIRA (JUREMA)','A'),
(46,'Michaelle -- Mudou-se --','Rua Araré, 878 -3.76067 -38.62156','','3','-376067','-3862156','PARQUE POTIRA (JUREMA)','A'),
(47,'Regis','Rua Campeche, 726 B -3.76591 -38.62336','','1','-376591','-3862336','PARQUE POTIRA (JUREMA)','A'),
(48,'Lindenberg','Rua Nova Iguacu, 2505 3.76575 -38.62724','','1','-376575','-3862724','PARQUE POTIRA (JUREMA)','A'),
(49,'Rafaela --Mudou-se Prox Katia','Travessa Araré, 301 -3.76404 -38.61779','','3','-376404','-3861779','PARQUE POTIRA (JUREMA)','A'),
(50,'Glaucia','Rua Tampico, 1066, -3.76233 -38.62400','','3','-376233','-3862400','PARQUE POTIRA (JUREMA)','A'),
(51,'Maria Katia','Avenida Giselda Magalhaes Bezerra, 386. -374827 -3862155','Mãe Maria','3','-374827','-3862155','PARQUE POTIRA (JUREMA)','A'),
(52,'ELIS','Rua Rodolfo Teofilo, 426, -3.74862 -38.62310','Mãe Maria de Jesus fone 3285-6070','1','-374862','-3862310','PARQUE POTIRA (JUREMA)','A'),
(53,'Andreza --Mudou-se','Rped E 22, 167, -377091-3863137','Sabe sinais','3','-377091','-3863137','RES. ARATURI (JUREMA)','A'),
(54,'Jonatas','Rped E 21, 113, -377159-3863220','Sabe sinais, oralizado, estuda a tarde, Irmã Jamile criança','1','-377159','-3863220','RES. ARATURI (JUREMA)','A'),
(55,'Marilia','Rped E 22, 27 altos, -376989-3863064','Sabe sinais, oralizado, estuda com a Neide, Mãe Socorro','3','-376989','-3863064','RES. ARATURI (JUREMA)','A'),
(56,'Adriano e Josi','Av. Dom Almeida Lustosa,3 904, altos ap 3, -377363-3862719','Com Av. São Vicente de Paula, Sabem sinais. Irmã Josiane. Em cima da Fármacia Lopes','5','-377363','-3862719','RES. ARATURI (JUREMA)','A'),
(57,'Benicio','Rua Pedestre E 18, 10,  -376865-3863203','Trabalha na Padaria','1','-376865','-3863203','RES. ARATURI (JUREMA)','A'),
(58,'Salco do Reino','Rua Tobias Correia, 1171, -373097-3866116','','7','-373097','-3866116','CENTRO CAUCAIA','T'),
(59,'Wagner','Rua Monte Sinai, 243, -3.76233 -38.64636','Oaralizado, sabe sinais','1','-376233','-3864636','CONJ. ARATURI (ARIANOPOLIS)','A'),
(60,'Andrea','Rua Sete Quedas,219,--3.76220 -38.64997','','3','-376220','-3864997','CONJ. ARATURI (ARIANOPOLIS)','A'),
(61,'Neta','Rua Dourados,715, -3.76329 -38.64960','Oralizada,não sabe sinais','3','-376329','-3864960','CONJ. ARATURI (ARIANOPOLIS)','A'),
(62,'Roberto','Rua Jacaranda,587,-3.76344 -38.64851','Não sabe sinais','2','-376344','-3864851','CONJ. ARATURI (ARIANOPOLIS)','A'),
(63,'Joao Carlos e Vanessa','Rua Orquides,249, -3.76567 -38.64805','','5','-376567','-3864805','CONJ. ARATURI (ARIANOPOLIS)','A'),
(64,'Lucivania -- Mudou-se --','Rua Flores,163 B,  -3.76624 -38.64783','','3','-376624','-3864783','CONJ. ARATURI (ARIANOPOLIS)','A'),
(65,'Amanda Castro','Rua Dourados,69, -3.76107 -38.64512  ','','0','-376107','-3864512','CONJ. ARATURI (ARIANOPOLIS)','T'),
(66,'Rita -- Mudou-se--','Rua Saramandaia, 593, -377697,-3862878','','3','-377697','-3862878','MARECHAL RONDON (JUREMA)','A'),
(67,'Raquel','Rua Saramandaia, 594,-377659-3862849','','4','-377659','-3862849','MARECHAL RONDON (JUREMA)','A'),
(68,'Girlane -- NAO VISITAR --','Rua Teodoro de Castro, 2819,-377722-3862254','Mãe Odete','3','-377722','-3862254','JUREMA','A'),
(69,'Erialdo','Rua Mirador,492, -377575-3862159','Sabe sinais, Trabalha na Guararapes','1','-377575','-3862159','MARECHAL RONDON (JUREMA)','A'),
(70,'Vanessa -- MUDOU-SE --','Rua São Francisco, 128, -37763-3863094','perto da capeme','3','-37763','-3863094','JUREMA','A'),
(71,'Flaviene','AV Dom Lustosa,4470,-377726-3863030','perto do capene','3','-377726','-3863030','JUREMA','A'),
(72,'Carlos Eduardo','Rua Quintino Cunha Com Ouro Preto , 3658, -374862-3862772','','1','-374862','-3862772','PARQUE POTIRA (JUREMA)','A'),
(73,'Raimundo ','Rua Joao Cordeiro, 182, -375050-3862504','','1','-375050','-3862504','PARQUE POTIRA (JUREMA)','A'),
(74,'Vania','Rua Oswaldo Cruz, 3363, -374841-3862453','','3','-374841','-3862453','PARQUE POTIRA (JUREMA)','A'),
(75,'SR LS Caucaia','','','7','','','CENTRO','T'),
(77,'Kezia','Rua Pedestre E 26, 107, -377156-3862958','Trabalha, folga só na segunda','3','-377156','-3862958','RES. ARATURI (JUREMA)','A'),
(78,'Bruno e thais','Rua Joaquim Bento Cavalcante, 734','Esquina com Félix Gomes da Rocha ','5','-372713','-3866229','GRILO','A'),
(79,'Junior e Andrca','Rua Irapuan Vidal, 3558','Esquina Haianga','0','-376209','-3863362','PQ. POTIRA','A'),
(80,'Maria Katia','Rua Giselda Magalhões Bezerra','Esquina Acarau','4','-374827','-3862155','PQ. POTIRA','A'),
(81,'Susana','Av. A  BL 29, Apt 21 A','Esquina 147 e 149 ','3','-376787','-3865429','METROPOLE ','A'),
(82,'Sandra','Rua 202,  138','Esquina 210, Contorno Norte','3','-376505','-3865692','METROPOLE ','A'),
(83,'Adrilene Maria --Mudou-se','Rua 256, BL 08, Apt 22 C','Esquina 254, Contorno Oeste','3','-376937','-3865861','METROPOLE','A'),
(84,'Bernado -- Mudou-se','Av, A BL 30 Apt 12B','Esquina 147 e 149 ','1','-376837','-3865423','METROPOLE','A'),
(87,'Josc Soares','Rua São Jerônimo 518','Esquina Ribeiro Bezerra','1','-375744','-3865830','METROPOLITANO','A'),
(88,'Sebastico','Rua Ribeiro Bezerra','Esquina São Jerônimo e Francisco Cordeiro','1','-375762','-3865851','METROPOLITANO','A'),
(89,'Edcarlos','Rua São Jerônimo 1868','Esquina Ribeiro Bezerra e Maestro Ozires do Nordeste','1','-375802','-3865838','METROPOLITANO','A'),
(90,'Alexa','Rua Ulisses Guimarães','Esquina Ribeiro Bezerra e Maestro Ozires do Nordeste','4','-375773','-3865727','METROPOLITANO','A'),
(91,'Remedio','Rua Camilo F. Da Silva','Esquina Francisco de Lima e Pedro Alves de Menezes','3','-376103','-3866032','METROPOLITANO','A'),
(92,'Cintia','Rua Manoel Claudino Sales 453','Esquina Maestro Osiris','3','-375688','-3866406','METROPOLITANO','A'),
(93,'Valdir','Rua Da Salgadeira 87','Esquina Carlos Ribeiro e Coronel Alfredo Miranda','1','-373457','-3869848','CAPUAN','A'),
(94,'Valderina','Rua Cresostomo Guimarães 757','Esquina Senhora Genoveva e Da Salgadeira ','3','-373971','-3869916','CAPUAN','A'),
(95,'Josiel','Rua Senhora Genoveva 461','Esquina Carlos Ribeiro ','1','-373733','-3869776','CAPUAN','A'),
(96,'Rudson','Rua Da Salgadeira , 149','Duas depois da 149','1','-373473','-3869829','CAPUAN','A'),
(97,'Nagela','BR 222     1770','Esquina Chagas Miguel','3','-373291','-3869552','CAPUAN','A'),
(98,'Kaelly','BR   222    2018','Esquina José Holanda Nogueira','3','-373340','-3869790','CAPUAN','A'),
(99,'Rogerio','Travessa do Trilho 186','Esquina do Trilho e 15 de Outubro','1','-373013','-3869913','JANDAIGUABA','A'),
(100,'Thamiris','Rua Clube de Campo  270','Travessa Santa Rita ','3','-372614','-3869945','JANDAIGUABA','A'),
(101,'Carlos Andrc','Rua Luiz Alberto 39','Esquina BR 222','1','-373259','-3870427','CAPUAN','A'),
(102,'Victor','Rua 111, 164','Esquina com rua 106','1','-374343','-3866397','PLANALTO CAUCAIA','A'),
(103,'Paulo Roberto','Rua 100, 409','Entre as Ruas 109 e 119','1','-374252','-3866491','PLANALTO CAUCAIA','A'),
(104,'Raimundo','Rua 104, 497','Esquina com a rua 119','1','-374300','-3866565','PLANALTO CAUCAIA','A'),
(105,'Fco Glauber','Rua 114, 495','Esquina com rua 119','1','-374485','-3866558','PLANALTO CAUCAIA','A'),
(106,'Jimmy e Cintia','Rua 115, 386','Entre as ruas 114 e contorno norte','5','-374549','-3866475','PLANALTO CAUCAIA','A'),
(107,'Roberio','Tv Juberto Gadelha, 28','Próx. À rua Dutra','1','-374011','-3867042','PE. JULIO MARIA','A'),
(108,'Rossiclcia','Rua do Grupo, 510','Esquina Juberto Gadelha','3','-374003','-3867015','PE. JULIO MARIA','A'),
(109,'Reginaldo','Rua da Liberdade, 286','Esquina com Santo Antonio','1','-373801','-3866888','PE. JULIO MARIA','A'),
(110,'Elenir','Rua X, 92','','','-377575','-3865529','METROPOLE 5','A'),
(111,'Marilaque','Rua Q, 88','Esquina com rua S','3','-377485','-3865610','METROPOLE 5','A'),
(112,'Danizio','Rua 123, 325','Entre as ruas M e Q','2','-377276','-3865693','METROPOLE 5','A'),
(113,'Evertony','Rua 3, 3','','1','-377365','-3865870','METROPOLE 5 ','A'),
(114,'Cristiane','Rua 2, 47','','3','-377155','-3865875','METROPOLE 5','A'),
(115,'Darlisson','Rua C, 24','Esquina com a Rua F','1','-377150','-3866026','METROPOLE 5','A'),
(116,'Vitoria -Atualizar Endereco','Av. A  BL 34, Apt 21 A','','3','-376807','-3865372','METROPOLE','A'),
(117,'Luciano','Av. Contorno Leste, BL 19, AP 12B','Entre a rua 147 e o giradouro do Araturi','1','-37664765','-386527101','METROPOLE','A'),
(118,'Vanessa','Rua C, 98','','3','-377002','-3864968','METROPOLE (ELDORADO)','A'),
(120,'Jose','Rua a,32','','1','-37720321','-386502917','METROPOLE (ELDORADO)','A'),
(121,'Roberia','Rua São Raimundo, 24','','3','-373997','-3871163','JARDIM DO AMOR','A'),
(122,'Francisca','Rua Vicente Ribeiro, 5 ','Próx. À BR 222','3','-373997','-3871163','JARDIM DO AMOR','A'),
(123,'Alfredo','Rua Dona Mazé, 26','Próx. Ao haras','1','-372231','-3872135','GENIPABU','A'),
(124,'Daiane','Rua Porteiras','Obs: rua principal. Quase no final de rua. A casa é um comércio.','3','-373770','-3876230','PORTEIRAS','A'),
(125,'Paulo Ccsar','CONDOMINIO VERDE','Esquina com rua 112','1','-374367','-3866116','ARATURI (JUREMA)','A'),
(126,'Rafael','Rua 116, 283','Esquina com rua 113','1','-374513','-3866393','PLANALTO CAUCAIA','A'),
(127,'Marcos','Rua 120, 347','Esquina com rua 113','1','-374564','-3866416','PLANALTO CAUCAIA','A'),
(128,'Reginara','Rua da Liberdade 524','Esquina com rua 114','4','-37401733','-386692004','PE. JULIO MARIA','A'),
(129,'Solange','Rua 118, 568','Esquina com rua 117','3','-3745288','-38667006','PLANALTO CAUCAIA','A'),
(130,'Carla','Rua Raimundo Ricardo, 343','Esquina com rua Pe. Julio Maria','3','-373621','-3866992','PE. JULIO MARIA','A'),
(131,'Aline','Rua Albino Nogueira Sales, 256','Atraz da Rua da Liberdade ','3','-373897','-3866855','PE. JULIO MARIA','A'),
(132,'Jameson','Travessa Quintino, 24','','1','-374101','-3865672','CIGANA','A'),
(133,'Dalila','Rua Fco Escócia Soares, 551','Próx ao açude','3','-374000','-3865823','CIGANA','A'),
(134,'Jacqueline','Rua Joacir Sampaio Pontes, 3225','','3','-374336','-3865975','NOVA CIGANA','T'),
(135,'Luciana','Rua das Flores, 287','','3','-374657','-3865826','NOVA CIGANA','A'),
(136,'Jailson','Rua Joacir Sampaio Pontes, 2697','','1','-373893','-3865824','CIGANA','A'),
(137,'Elder e Flavia','Rua NS Dois, 265','Esquina com Coronel Correa','0','-373685','-3867451','PALMIRIM','T'),
(138,'Valdenisio','Rua Teodoro de Castro, 4495,-377782-3863038','','1','-377782','-3863038','CARIOCAS(JUREMA)','A'),
(139,'Larissa e Edson -- Mudou-se','Rua Três, n?, depois da 114, 2 casas, -376919-3862814','','5','-376919','-3862814','MARECHAL RONDON','A'),
(140,'Fernando','Rua Três, n?, depois da 114, 2 casas, -376919-3862814','','1','','','MARECHAL RONDON (JUREMA)','A'),
(141,'Diego e Katia','PEGAR ENDERECO','','5','-376548','-3864637','METROPOLE 5','A'),
(142,'Lucia','Rua A G M Araujo, 22','Vila Canindé','3','','','PENTECOSTE','A'),
(143,'Elinete Souza','Rua Jonas Alcântara, 44','','3','-379149','-3926612','PENTECOSTE','A'),
(144,'Vasco','Rua José Sales Mota, 30','próximo a AABB','1','','','PENTECOSTE','A'),
(145,'Vando','Rua Marechal Hermes, 734','Senharão; Próx a Travessa Marechal Hermes;PAIS>JOSE E FRANCISCA','1','-350549','-3958270','ITAPIPOCA','A'),
(146,'Leirijane','Rua Vicente Siebra, 2174','Violete; Casa do mercadinho Aguiar; PAI> LIBERATO','3','-348172','-3957315','ITAPIPOCA','A'),
(147,'Valeria','Avenida Mosenhor Tabosa, 2313','Violete; Enfrente a Faculdade; Perto da fábrica DASS; MÃE> VANI','3','-350000','-3957707','ITAPIPOCA','A'),
(148,'Adriana','Rua Severiano Moreira, 2864','Violete; tem dois filhos','3','-348428','-3957433','ITAPIPOCA','A'),
(149,'Valeria (2) e Reginaldo','Rua Severiano Moreira, 2902','Violete; Casal de surdos','5','-348388','-3957548','ITAPIPOCA','A'),
(150,'Gisele','Rua Dom Aureliano Matos, 2461','Cruzeiro; Tem Filho, Riam; MÃE> ZENIR','3','-348583','-3957648','ITAPIPOCA','A'),
(151,'Miriam','Rua Antonio Barroso Neto, 2494','Violete; surdez parcial, oralizada','3','-348632','-3957329','ITAPIPOCA','A'),
(152,'Josy','Rua Osmundo Cordeiro, 983','Cacimbas; Jovem, mãe Eliene fone, 88 9219-3059 ','3','-349546','-3960128','ITAPIPOCA','A'),
(153,'Valreciane','Rua Antonio Carvalho, 417','Cacimbas; família evangélica, TER MUITO TATO; MÃE>LIDUÍNA','3','-349872','-3959904','ITAPIPOCA','A'),
(154,'Samara','Rua Pontes Neto, 42','Cacimbas; jovem, fone 3432-0394 MÃE> NEIDE','3','-349638','-3959882','ITAPIPOCA','A'),
(155,'Madela','Rua Duzinho Montenegro, 174 (R. Venisceslau C Dutra)','Cacimbas; 88 9965-9888 MÃE> JOANA','3','-349706','-3959970','ITAPIPOCA','A'),
(156,'Rosa Aline','Travessa Luiz Carvalho, 1132','Mourão; PAIS> ALDER e JOSÉ; IRMÃ> CAMILA','3','-350023','-3959547','ITAPIPOCA','A'),
(157,'Taina','Rua Francisco Jose do Monte 827, (casa 2)','Mourão; MARIDO> MATEUS; casas da Vanessa','3','-350145','-3959575','ITAPIPOCA','A'),
(158,'Kaylane','Rua Maria Vidal dos Santos, 1004 ','Ladeira: criança; irmão surdo Oscar mudou p/Fortaleza;PAIS>JOÃOeELIANE','4','-350882','-3958574','ITAPIPOCA','A'),
(159,'Rivelino e Sheila','Rua Horacio Bastos, 1071','Ladeira; Casal, filhas Taíla e Thalia','5','-350845','-3958361','ITAPIPOCA','A'),
(161,'Davi  ','Rua Marechal Hermes, 614 (apto)','Senharão; Criança; MÃE> MERCÊ','2','-350451','-3958501','ITAPIPOCA','A'),
(162,'Josue','Rua julia silva, 1063','','1','-372748','-3866598','GRILO','A'),
(163,'Tiago','Rua Joaquim Bento Cavalcante, 302','MãeShirley','2','-372851','-3866368','GRILO','A'),
(164,'Rodrigo ','Rua São Joao,217','','1','-372733','-3867088','GRILO','A'),
(165,'Vinicius','Rua Santa Rita, 1135','','2','-372876','-3866415','GRILO','A'),
(166,'jessica','Rua raimundoNonato alenxandre,','','4','-370376','-3866469','MESTRE ANTONIO','A'),
(167,'Liliane','Rua Joaquim Bento Cavalcante, 420','','3','-372794','-3865908','GRILO','A'),
(169,'Francisco','Rua Santa Lucia, 1009','Proximo ao deposito betel','1','-373808','-3861700','TABAPUA','A'),
(170,'Rafael','Rua ipu, 1929','Oralizado, sabe sinais, mãe TJ','1','-373890','-3861731','TABAPUA','A'),
(171,'Franscisco (TOTA)','Rua 1-D, 151','Em frente a rua 10.','1','-374059','-3861351','TABAPUA','A'),
(172,'Nivan e Joana','Rua Vereador Gilberto Gadelha, 226/B ','proximo a escola coralha.','5','-373858','-3865116','PQ. SOLEDADE','A'),
(173,'Gilclecio','Rua Santa Helena, 2100','','1','-373868','-3864875','PQ. SOLEDADE','A'),
(174,'Neide','Rua Terra Rica, 264','','3','-374145','-3864176','SÃO GERARDO','A'),
(175,'Fernando','Rua Terra Rica, 394','','1','-374308','-3864207','SÃO GERARDO','A'),
(176,'Patrick','Rua Padre Cicero, 416 A','','1','-374065','-3865019','SÃO GERARDO','A'),
(177,'Samuel','Rua Manoel Bandeira, 283','','1','-374187','-3863869','SÃO GERARDO','A'),
(178,'Valdiane','Rua Cacique Alberto, 300','','3','-374109','-3863525','SÃO GERARDO','A'),
(179,'Jessica --Mudou-se','Rua Francisco Nogueira, 500, Bloco 6 Ap 104','','3','0','0','PLANALTO CAUCAIA','A'),
(180,'Abraao','Rua Espanha, 118','irmã conceição','1','-374576','-3861029','PQ. DAS NAÇOES','A'),
(181,'Edson Feijco','Rua Passo a Passo, 225','','1','-375993','-3861466','PQ. ALBANO','A'),
(182,'Lucilene','Rua França, 539','','3','-374922','-3860731','PQ. DAS NAÇOES','A'),
(183,'Manoel','Rua Espanha, 1077','','1','-375206','-3860838','PQ. DAS NAÇOES','A'),
(184,'Edson','Rua Lago Verde, 267','','1','-376047','-3861572','PQ. ALBANO','A'),
(185,'Carliane','Rua Socorro França, 284','','3','-376012','-3861415','PQ. ALBANO','A'),
(186,'Carla','Rua Socorro França, 267','','4','-376002','-3861404','PQ. ALBANO','A'),
(187,'Liandra','Rua Parana, 80','','3','-375480','-3861359','PQ. ALBANO','A'),
(188,'Telma','Rua Porto Velho, qd  55, bl 4, Ap 203','','3','-375430','-3861374','PQ. ALBANO','A'),
(189,'Mateus','Rua da Paz, 486','','2','-372922','-3864921','ITAMBE','A'),
(190,'Josinaldo','Rua da Paz, 514','','1','-372875','-3864913','ITAMBE','A'),
(191,'Jessica --Mudou-se','Rua Contorno Norte,  500, Bloco 6 Ap 104 (Cond Novo pabussu)','Condominio Novo Pabssu','3','-374192','-3866384','PLANALTO CAUCAIA','A'),
(192,'Elenice','Rua Rua Contorno Norte,  500, Bloco18Ap 203 (com Novo Pabussu)','Condominio Novo Pabssu','3','-374190','-3866412','PLANALTO CAUCAIA','A'),
(193,'LUIZ e JORDANIA','RUA SANTA LUZIA, 57','','5','-374404','-3867034','PE. JULIO MARIA','A'),
(194,'Samuel','Rua João forte, 196','','1','-372530','-3865326','ITAMBE','A'),
(195,'Camila','Rua Tres de maio, 361','','3','-372673','-3865191','ITAMBE','A'),
(196,'Carminha','Rua São Francisco, 76','','3','-372862','-3865132','ITAMBE','A'),
(197,'Eduardo','Rua nestor Barbosa, 196','','1','-372594','-3865063','ITAMBE','A'),
(198,'Douglas','Rua Santa Cecilia, 177','','1','-372637','-3864650','ITAMBE','A'),
(199,'Paulo Sergio','Rua Santiago do Chile, 154','','1','-372642','-3864602','ITAMBE','A'),
(200,'Junior','Rua São Jose do Ribamar, 312','','1','-372859','-3864622','ITAMBE','A'),
(201,'Alzenira--Mudou-se','Rua São Raimundo, 483','','3','-373031','-3864620','ITAMBE','A'),
(202,'Emili--Mudou-se','Rua São Raimundo, 510','','4','-373046','-3864625','ITAMBE','A'),
(203,'Daiane','Rua Jose Matias de Brito, AP 201','','4','-372980','-3865229','ITAMBE','A'),
(204,'Tatiana','Rua Barbosa Freitas, 41','','4','-372893','-3869168','CAPUAN','A'),
(205,'Katia','Rua josé da Silva, 730','','3','-373393','-3870239','CAPUAN','A'),
(206,'Vanira','Rua Luiz Andre de Souza, 89','','3','-373958','-3865494','AÇUDE','A'),
(207,'Braguilene','Rua Valdevino Fernandes, 101','','3','-373986','-3865447','AÇUDE','A'),
(208,'Berenice','Rua Jose Rocha Sales, 747','','3','-374138','-3865506','AÇUDE','A'),
(209,'Flavio','Rua C, 1798','','1','-374078','-3865577','AÇUDE','A'),
(211,'Gabriel','Rua  Raimundo Nonato Alexandre, 1630','','2','-370851','-3866415','MESTRE ANTONIO','A'),
(212,'Elizangela','Rua Valdeniza P da Silva, 290','','3','-370840','-3866861','MESTRE ANTONIO','A'),
(213,'Danilo','Rua luiz balbino, 102','','1','-436058','-3930304','BOA VISTA','A'),
(214,'Jose Geronimo','Rua francisco Vieira, 1451','','1','-433823','-3928290','BOA VISTA','A'),
(215,'Roger ','Rua Abel mulato, SN','','1','-434295','-3929610','BOA VISTA','A'),
(216,'Jmaile','Rua Paralela Norte,164','','3','-434853','-3930514','C. HABITACIONAL','A'),
(217,'Maria de Jesus','Rua Fortaleza, 749','','3','-434393','-3930811','CAMPINAS','A'),
(218,'Alessandra','Rua Francisco Chagas Barros, SN','','3','-434209','-3930671','CAMPINAS','A'),
(219,'Francisco de Assis','Rua HonorioPereira, 1207','','1','-434056','-3930572','CAMPINAS','A'),
(220,'Dini Keuly','Rua Celio Martins, 613','','3','-435090','-3931351','IMACULADA CONC.','A'),
(221,'Geovane','Rua Geroncio Brigido Neto, 1181','','1','-435149','-3930994','IMACULADA CONC.','A'),
(222,'Heloisa','Rua Raimunda Alves, 1178','','3','-434957','-3931909','SANTA LUZIA','A'),
(223,'Rayane','Rua Raimunda Alves, 1201','','3','-434982','-3931889','SANTA LUZIA','A'),
(224,'ivanilza','Rua Joaquim da Rocha, 985','','3','-435451','-435451','SANTA LUZIA','A'),
(225,'Bismarck','Rua Candido Couto, 1828','','1','-435435','-3932153','SANTA LUZIA','A'),
(226,'Millena','Rua nemesio cordeiro, 1655','','3','-435422','-3931583','SANTA CLARA','A'),
(227,'Fco. Junior','Rua Sitonio monteiro,791','','1','-435386','-3931770','SANTA CLARA','A'),
(228,'Fco.Mauro','Rua Sitonio monteiro,791','','1','-435386','-3931770','SANTA CLARA','A'),
(229,'Camilly','Rua Jose Paixao, 1998','','3','-435687','-3932514','CAN','A'),
(230,'Pedro Jorge','Rua Jose Paixao, 2333','','1','-435687','-3932514','CAN','A'),
(231,'Ivoneide','Rua Doutor Firmino, 1586','Não visitar','3','-435859','-3932427','CAN','A'),
(232,'Estanislau','Rua Romeu Martns, 1235','','1','-435808','-3931339','CAN','A'),
(233,'Joco Batista','Rua Romeu Martns, 1235','','1','-435808','-3931326','CAN','A'),
(234,'Maria Aparecida','Rua Odilon Macambira, 1318','','3','-435833','-3932372','CAN','A'),
(235,'Luiz Jorge','Rua Ramundo Ourives, 1887','','1','-435643','-3932688','S','A'),
(236,'Celia','Rua Zuil Vieira, 1767','','3','-436008','-3932701','S','A'),
(237,'israel','Rua paulo Uchoa, 2275','','1','-436810','-3931816','SÃO MATEUS','A'),
(238,'Luciano','Rua doutor Bianor Pinto, 2534','','1','-436884','-3932048','SÃO MATEUS','A'),
(239,'Patricia','Rua Padre Leitao, 460','','3','-436734','-3932170','SÃO MATEUS','A'),
(240,'Luiz','Rua Simao Barbosa, 1880','','1','-436542','-3931641','SÃO MATEUS','A'),
(241,'Adelaide','Rua Altina Ferreira','','3','-436201','-3932429','MONTE','A'),
(242,'Silvana','Rua Jose Cordeiro da Cruz, 2312','','3','-435943','-3931842','MONTE','A'),
(243,'rock','Rua Luiz Fabiano III, 2654 ','','1','-436078','-3932232','MONTE','A'),
(244,'wagner','Rua Luiz Fabiano III, 2735','','1','-436078','-3932226','MONTE','A'),
(245,'Valmir','Rua Dom Henrique, 2481','','1','-436278','-3932220','MONTE','A'),
(246,'Helena','Rua Dom Henrique, 2687 e 2697','Entre 2687 e 2697','3','-436272','-3932232','MONTE','A'),
(247,'Laiza','Trav. Luiz Fabiano III, 1311','','3','-435764','-3932170','MONTE','A'),
(248,'Yarlei','Rua Luiz Fabiano III, 2560 ','','1','-436078','-3932232','MONTE','A'),
(249,'Junior','AV Padre cicero, 867','','1','-436525','-3932138','JOAO PAULO II','A'),
(250,'Italo Gean','Rua Alaim Carneiro sampaio, 596','','1','-436324','-3932157','JOAO PAULO II','A'),
(251,'Laura Stefany','Rua Raimundo da Costa Ribeiro, 521','','3','-435841','-3931586','JOAO PAULO II','A'),
(252,'Ana Kelly','Rua Doutor Peixoto, 308','','3','-436057','-3930808','ALTO GUARAMIRANGA','A'),
(253,'Kegiane','Rua Jose veloso Juca, 181','','3','-435816','-3930718','ALTO GUARAMIRANGA','A'),
(254,'Neilane','Rua Jose veloso Juca, 2358  (alto)','oralizada','3','-437706','-3930873','ALTO GUARAMIRANGA','A'),
(255,'Aline','Rua Agapito Sampaio, 331','','3','-436133','-3930743','ALTO GUARAMIRANGA','A'),
(256,'Luciana','Rua Agapito Sampaio, 182','','3','-436069','-3930937','ALTO GUARAMIRANGA','A'),
(257,'Maria Gomes (Picoca)','Rua Joaquim macaro, 353','','3','-436194','-3930824','ALTO GUARAMIRANGA','A'),
(258,'Roberio','Rua Barros Leal, 458','','1','-436423','-3930611','ALTO GUARAMIRANGA','A'),
(259,'Jamille e Erivelton (irmaos)','Rua Luiz vieira, 549','','6','-436531','-3930712','PALESTINA','A'),
(260,'Paulo','Rua Carlos, 627','','1','-436987','-3930962','PALESTINA','A'),
(261,'Missilene e Gildo','Tv. São Joao batista, 1960','','5','-434336','-3932397','RIACHO SUJO','A'),
(262,'Alex ','Rua são Joao Batista, ','','1','-434308','-3932388','RIACHO SUJO','A'),
(263,'Antonio','Rua Homero Martins, 2234','','','-435103','-3932894','CANIDEZINHO','A'),
(264,'Paula','Rua Frei Juvencio, 1881','','3','-434876','-3933151','CANIDEZINHO','A'),
(265,'janiele','Rua Jose karan, 1749','','','-435263','-3932096','CANIDEZINHO','A'),
(266,'claudio','rua jose karan, 1172','','1','-435265','-3932087','SANTA LUZIA','A'),
(269,'Pedro','Rua Monsenhor Custodio, 1091','','','-370951','-3866323','MESTRE ANTONIO','A'),
(271,'Jardeson','Rua 1008, 149, 4º Etapa','','','0','0','CONJ. CEARÁ','T'),
(272,'VINICIOS','Rua Irapuan Vidal, 1265','','','-37588989','-386380948','PARQUE POTIRA (JUREMA)','A'),
(273,'Miliane','Rua C, Perto dos Campos dos Cariocas, Residencial Cecilia Meireles, 270, BL 4b ap 103','','','0','0','CARIOCAS (JUREMAS)','A'),
(274,'NECESSARIO CONFIRMACAO','Rua João 23, BL D, 104','','','0','0','CARIOCAS (JUREMAS)','A'),
(275,'Silveline','Terrenos Invadidos','','','-37737508','-38646135','METROPOLE SUL (ELDORADO)','A'),
(276,'CHRISTIANO DIAS','Av. Contorno Norte, 486','','','-37420315','-386656232','PLANALTO CAUCAIA','A'),
(277,'JENNIFER','Rua Raimundo Ricardo, 288','','','-37361992','-386692011','PE. JULIO MARIA','A'),
(278,'Jana','Av. dos Coqueiros, S/N','','','0','0','CUMBUCO','A'),
(279,'Mauricio','Av. dos Coqueiros, 1595','','','0','0','CUMBUCO','A'),
(280,'Bruna & Daniele','R. Idelzuite Garcia, 472','','','-36738408','-386752622','ICARAÍ','A'),
(281,'João  Carlos & Claudiana','R. Raimundo Nonato, 148','','','0','0','ICARAÍ','A'),
(282,'Carlos','R. Berlamino José, 25','','','-36800246','-386610168','ICARAÍ','A'),
(283,'Erinardo','R. São José, 12','','','0','0','CURICACA','A'),
(284,'Geany','R. Da. Ramy, 559','','','0','0','CURICACA','A'),
(285,'Lisandra','Travesa Ponte Nova, 209, Altos','','','-37743337','-386248875','MARECHAL RONDON (JUREMA)','A'),
(286,'Antonio Ucho','Rua Nova Granada, 892','','','-37752969','-386249547','MARECHAL RONDON (JUREMA)','A'),
(287,'Casal de Surdo','Rua Colina, 545 B','','','-37759439','-386224172','MARECHAL RONDON (JUREMA)','A'),
(288,'Surdo -','Rua Santa Terezinha, 493 Altos','','','-37748138','-386237417','MARECHAL RONDON (JUREMA)','A'),
(289,'VANDER','R. NW OITO','','','-37647958','-386378342','ARATURI (JUREMA)','A');
/*!40000 ALTER TABLE `surdo` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2016-11-30 13:31:12
-- Total time: 0:0:0:3:73 (d:h:m:s:ms)