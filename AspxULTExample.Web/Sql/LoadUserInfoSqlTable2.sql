
    USE [ULTExampleDb]
    GO

    DELETE FROM [dbo].[UserInfo];
    DELETE FROM [dbo].[UserInfoAccessLevel];
    DELETE FROM [dbo].[UserInfoUserInfoAccessLevelXref];
    DELETE FROM [dbo].[UserInfoCountries];
    DELETE FROM [dbo].[UserInfoCompany];
    DELETE FROM [dbo].[UserInfoUserInfoCompanyXref];
    DELETE FROM [dbo].[UserInfoStatus];

    DECLARE @CreateDate datetime = GETDATE();
    DECLARE @ActiveYesNo bit = 1;
    DECLARE @UpdateUserName [nvarchar](50) = 'EARLWILKERSONJR\earlw';
    DECLARE @UpdateFullName [nvarchar](50) = 'Earl L. Wilkerson Jr.';
    /*
    DECLARE @UserInfoStatusID int = 10;
    DECLARE @UserInfoCompanyID int = 1;
    */

    INSERT INTO [dbo].[UserInfo]
    ([UserInfoUserIdentityName]
    ,[UserInfoUserName]
    ,[UserInfoFullName]
    ,[UserInfoEmailAddress]
    ,[UserInfoJobTitle]
    ,[UserInfoActiveYesNo]
    ,[CreateUserName]
    ,[CreateFullName]
    ,[CreateDate]
    ,[UpdateUserName]
    ,[UpdateFullName])
    VALUES
    ('earlw'
    ,'EARLWILKERSONJR\earlw'
    ,'Earl L. Wilkerson Jr.'
    ,'earl.wilkerson.jr@gmail.com'
    ,'Software Engineering'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    ('blakler1'
    ,'UNI\blakler1'
    ,'Ricky Blakley'
    ,'blakler1@universalleaf.com'
    ,'Software Engineering - Director, Applications'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    ('campose1'
    ,'UNI\campose1'
    ,'Ezequiel Campos'
    ,'emcampos@gmail.com'
    ,'Software Engineering - Technical Lead'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    ('smithc1'
    ,'UNI\smithc1'
    ,'Chad Smith'
    ,'punkrockguy@outlook.com'
    ,'Vice President & Chief Information Officer'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    ('earlw1'
    ,'EARLWILKERSONJR\earlw1'
    ,'Earl L. Wilkerson Jr.'
    ,'ewilkerson@gmail.com'
    ,'Software Engineering'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName);

    INSERT INTO [dbo].[UserInfoAccessLevel]
    ([UserInfoAccessLevelID]
    ,[UserInfoAccessLevelName]
    ,[UserInfoAccessLevelNum]
    ,[UserInfoAccessLevelActiveYesNo]
    ,[CreateUserName]
    ,[CreateFullName]
    ,[CreateDate]
    ,[UpdateUserName]
    ,[UpdateFullName])
    VALUES
    (1
    ,'Super Access Level Sr.'
    ,999999999
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (2
    ,'Super Access Level Jr.'
    ,888888888
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (4
    ,'Access Level'
    ,10
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (3
    ,'Approve Access Level'
    ,20
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName);

    INSERT INTO [dbo].[UserInfoUserInfoAccessLevelXref]
    ([UserInfoID]
    ,[UserInfoAccessLevelID]
    ,[UserInfoUserInfoAccessLevelXrefActiveYesNo]
    ,[CreateUserName]
    ,[CreateFullName]
    ,[CreateDate]
    ,[UpdateUserName]
    ,[UpdateFullName])
    VALUES
    (1
    ,1
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (2
    ,1
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (3
    ,1
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (4
    ,1
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (5
    ,4
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName);


    INSERT INTO [dbo].[UserInfoCountries]
    ([UserInfoCountriesID]
    ,[UserInfoCountriesName]
    ,[UserInfoCountriesActiveYesNo]
    ,[CreateUserName]
    ,[CreateFullName]
    ,[CreateDate]
    ,[UpdateUserName]
    ,[UpdateFullName])
    VALUES
    (1
    ,'Brazil'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (2
    ,'Bulgaria'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (3
    ,'Dominican Republic'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (4
    ,'Ecuador'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (5
    ,'Germany'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (6
    ,'Greece'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (7
    ,'Guatemala'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (8
    ,'Hong Kong'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (9
    ,'Hungary'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (10
    ,'India'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (11
    ,'Indonesia'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (12
    ,'Italy'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (13
    ,'Malawi'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (14
    ,'Mexico'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (15
    ,'Mozambique'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (16
    ,'Netherlands'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (17
    ,'North Macedonia'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (18
    ,'Paraguay'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (19
    ,'People''s Republic of China'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (20
    ,'Philippines'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (21
    ,'Poland'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (22
    ,'Russia'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (23
    ,'Singapore'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (24
    ,'South Africa'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (25
    ,'Spain'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (26
    ,'Switzerland'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (27
    ,'Türkiye'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (28
    ,'United States'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (29
    ,'Zimbabwe'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName);



    INSERT INTO [dbo].[UserInfoCompany]
    ([UserInfoCompanyID]
    ,[UserInfoCompanyName]
    ,[UserInfoCompanyAddress1]
    ,[UserInfoCompanyAddress2]
    ,[UserInfoCompanyCityStateZip]
    ,[UserInfoCompanyTelephone]
    ,[UserInfoCompanyEmailAddress]
    ,[UserInfoCountriesID]
    ,[UserInfoCompanyActiveYesNo]
    ,[CreateUserName]
    ,[CreateFullName]
    ,[CreateDate]
    ,[UpdateUserName]
    ,[UpdateFullName])
    VALUES
    (1
    ,'Universal Leaf Tabacos Ltda.'
    ,'Rodovia BR 471–KM 129,800'
    ,'Caixa Postal 1025'
    ,'96835-642 Santa Cruz do Sul, Rio Grande do Sul, Brazil'
    ,'(+55 51) 3719 8300'
    ,'info@universalleaf.com'
    ,1
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (2
    ,'Ermor Tabarama Tabacos do Brasil Ltda.'
    ,'Av. Santos Dumont 1883 - Centro'
    ,'Edifício Aero Empresarial - Sala 930'
    ,'42702-400 Lauro de Freitas, Bahia, Brazil'
    ,'(+55) 71 3025 4708'
    ,'info@universalleaf.com'
    ,1
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (3
    ,'Socotab Bulgaria EOOD'
    ,'4202 Radinovo'
    ,'Plovdiv District'
    ,'Bulgaria'
    ,'(+359 32) 904 140'
    ,'info@universalleaf.com'
    ,2
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (4
    ,'INETAB-KAUBECK, SRL'
    ,'Altos de Virella'
    ,'Apartado Postal 800'
    ,'Santiago, Dominican Republic'
    ,'(+1 809) 575 3251'
    ,'info@universalleaf.com'
    ,3
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (5
    ,'Tabacalera San Castillo Tabacastillo S.A.'
    ,'Recinto Castillo, Parroquia Catarama, Hacienda San Castillo'
    ,'Canton Urdaneta'
    ,'Los Rios, Ecuador'
    ,'(+593) 99 719 6431'
    ,'info@universalleaf.com'
    ,4
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (6
    ,'DHT - Deutsch-Holländische Tabakgesellschaft mbH &amp; Co. KG'
    ,'2. Industriestraße 6'
    ,''
    ,'68766 Hockenheim, Germany'
    ,'(+49 0) 6205-379100'
    ,'info@universalleaf.com'
    ,5
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (7
    ,'Gebrüder Kulenkampff GmbH'
    ,'PO Box 103869'
    ,''
    ,'28038 Bremen, Germany'
    ,'(+49 421) 365 90'
    ,'info@universalleaf.com'
    ,5
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (8
    ,'Deutsch-Holländische Tabakgesellschaft mbH &amp; Co. KG'
    ,'2. Industriestraße 6'
    ,''
    ,'68766 Hockenheim, Germany'
    ,'(+49 0) 6205-379100'
    ,'info@universalleaf.com'
    ,5
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (9
    ,'Socotab EOOD Greek Branch'
    ,'Location Tria Pigadia'
    ,''
    ,'60 100 Katerini, Greece'
    ,'(+30 2) 3510 49 970'
    ,'info@universalleaf.com'
    ,6
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (10
    ,'Casa Export, Limited'
    ,'15 Calle 17 - 17, Zona 1'
    ,''
    ,'Guatemala City, Guatemala 01001'
    ,'(+1 502) 2490 7200'
    ,'info@universalleaf.com'
    ,7
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (11
    ,'Universal Leaf (Asia) Pte Ltd'
    ,'Block A 12/F Winbase Centre'
    ,'208 Queen’s Road Central'
    ,'Hong Kong'
    ,'(+852) 361 93821'
    ,'info@universalleaf.com'
    ,8
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (12
    ,'ULT Hungary Limited (ULT Magyarorszàg Kft.)'
    ,'P.O. Box 146'
    ,''
    ,'Kinizsi utca 6/A, H - 4400 Nyíregyháza, Hungary'
    ,'(+36 30) 709 8216'
    ,'info@universalleaf.com'
    ,9
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (13
    ,'ULT Support Services India Private Limited'
    ,'Door No 3-28-244/A'
    ,'Nalanda Nagar, 3rd Lane, Ring Road'
    ,'Guntur 522 006, Andhra Pradesh, South India'
    ,'(+91 863) 226 5460'
    ,'info@universalleaf.com'
    ,10
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (14
    ,'PT Tempu Rejo'
    ,'Jalan Panglima Besar Sudirman no. 110'
    ,'Kecamatan Pakusari'
    ,'Jember 68181, East Java, Indonesia'
    ,'(+62 331) 336 933'
    ,'info@universalleaf.com'
    ,11
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (15
    ,'Deltafina S.r.l.'
    ,'Via Monte delle Gioie 1/c'
    ,''
    ,'00199 Rome, Italy'
    ,'(+39 06) 8530 3354'
    ,'info@universalleaf.com'
    ,12
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (16
    ,'L''Agricola S.r.l.'
    ,'Viale Europa 1/5'
    ,''
    ,'06080 Ospedalicchio di Bastia Umbra (Pg), Italy'
    ,''
    ,'info@universalleaf.com'
    ,12
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (17
    ,'Limbe Leaf Tobacco Company Limited'
    ,'Plot no. 29/125-126'
    ,'Kanengo Industrial Sites'
    ,'Lilongwe 4, Lilongwe, Malawi'
    ,'(+265 1) 710 355 / 100'
    ,'info@universalleaf.com'
    ,13
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (18
    ,'Tabacos Del Pacifico Norte, S.A. De C.V.'
    ,'Predio Los Sauces S/N Int. 1'
    ,'Col. Los Sauces'
    ,'Tepic, Nayarit 63195, Mexico'
    ,'(+52 311) 219 4872 / 75'
    ,'info@universalleaf.com'
    ,14
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (19
    ,'Moçambique Leaf Tobacco Limitada'
    ,'P.O. Box 633'
    ,''
    ,'50100 Tete, Mozambique'
    ,'(+258 2) 522 7000'
    ,'info@universalleaf.com'
    ,15
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (20
    ,'HTL-DHT'
    ,'Kanaaldijk Noord 123'
    ,''
    ,'5642 JA Eindhoven, The Netherlands'
    ,'(+31 0 40) 281 0275'
    ,'info@universalleaf.com'
    ,16
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (21
    ,'Socotab DOOEL Bitola'
    ,'Village of Dragozhani'
    ,'7000 Bitola'
    ,'North Macedonia'
    ,'(+389 47) 212 400'
    ,'info@universalleaf.com'
    ,17
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (22
    ,'Tabacalera San Fernando S.R.L.'
    ,'Fernando de la Mora KM7'
    ,'Avda Mcal Estigarribia 315'
    ,'Casilla de Correo 1020, Asuncion, Paraguay'
    ,'(+595 21) 500 227'
    ,'info@universalleaf.com'
    ,18
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (23
    ,'Universal Leaf Tobacco Company, Inc.'
    ,'No. 16 Guangshun South Avenue'
    ,'Wangjing Chao Yang District'
    ,'Beijing, China P.C. 100102'
    ,'(+86 10) 6438 9661 /2 /3 /4'
    ,'info@universalleaf.com'
    ,19
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (24
    ,'Universal Leaf Philippines, Inc.'
    ,'Unit 2405 Discovery Centre'
    ,'25 ADB Avenue, Ortigas Centre'
    ,'1600 Pasig City, Philippines'
    ,'(+63 2) 910-5050 / 1 / 2'
    ,'info@universalleaf.com'
    ,20
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (25
    ,'Universal Leaf Tobacco Poland Sp. z o.o.'
    ,'ul. Przemyslowa 20'
    ,'28-300 Jędrzejów'
    ,'Poland'
    ,'(+48 41) 380 1100'
    ,'info@universalleaf.com'
    ,21
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (26
    ,'CJSC "Universal Tabak"'
    ,'57-A Vavilova str., 3rd floor'
    ,'(+7 495) 989 7639'
    ,'Moscow 117292, The Russian Federation'
    ,''
    ,'info@universalleaf.com'
    ,22
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (27
    ,'Universal Leaf (Asia) Pte Ltd'
    ,'240 MacPherson Road'
    ,'#02-04 Pines Industrial Building'
    ,'Singapore 348574'
    ,'(+65) 6324 7750'
    ,'info@universalleaf.com'
    ,23
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (28
    ,'Universal Leaf South Africa (Proprietary) Limited'
    ,'Postnet Suite # 414'
    ,'Private Bag X51, Bryanston 2021'
    ,'Johannesburg, South Africa'
    ,'(+27 11) 361 2600'
    ,'info@universalleaf.com'
    ,24
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (29
    ,'TAES S.L.'
    ,'C/.Ronda Sur , n° 50 - Local 4'
    ,'Apartado 91'
    ,'10300 Navalmoral de la Mata (Cáceres), Spain'
    ,'(+34 927) 533 794'
    ,'info@universalleaf.com'
    ,25
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (30
    ,'Socotab Frana S.A.'
    ,'82 rue de Lausanne'
    ,'1202 Geneva'
    ,'Switzerland'
    ,'(+41 22) 908 3500'
    ,'info@universalleaf.com'
    ,26
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (31
    ,'ULTOCO S.A.'
    ,'82 rue de Lausanne'
    ,'1202 Geneva'
    ,'Switzerland'
    ,'(+41 22) 319 7188'
    ,'info@universalleaf.com'
    ,26
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (32
    ,'Continental Tobacco S.A.'
    ,'82 rue de Lausanne'
    ,'1202 Geneva'
    ,'Switzerland'
    ,'(+41 22) 319 7188'
    ,'info@universalleaf.com'
    ,26
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (33
    ,'Socotab Yaprak Tütün Sanayi ve Ticaret a.s.'
    ,'Mustafa Kemal Atatürk Mahallesi'
    ,'Ulucak Izmir Caddesi No. 87'
    ,'35735 Kemalpasa, Izmir, Türkiye'
    ,'(+90 232) 877 0255'
    ,'info@universalleaf.com'
    ,27
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (34
    ,'Universal Leaf Tobacco Company, Inc.'
    ,'P.O. Box 25099'
    ,'(+ 1 804) 359 9311'
    ,'Richmond, Virginia 23260, United States'
    ,''
    ,'info@universalleaf.com'
    ,28
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (35
    ,'Universal Leaf North America U.S., Inc.'
    ,'P.O. Box 519'
    ,''
    ,'Nashville, North Carolina 27856 USA'
    ,'(+1 252) 462-4500'
    ,'info@universalleaf.com'
    ,28
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (36
    ,'J. P. Taylor Company, L.L.C.'
    ,'P.O. Box 246'
    ,''
    ,'Oxford, NC 27565 USA'
    ,'(+1 919) 693 1116'
    ,'info@universalleaf.com'
    ,28
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (37
    ,'Lancaster Leaf Tobacco Company of Pennsylvania, Inc.'
    ,'PO Box 897'
    ,''
    ,'Lancaster, Pennsylvania 17608-0897, United States'
    ,'(+1 717) 394 2676'
    ,'info@universalleaf.com'
    ,28
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (38
    ,'AmeriNic, Inc.'
    ,'P. O. Box 25099'
    ,''
    ,'Richmond, Virginia 23260 USA'
    ,'(804) 254 1355'
    ,'info@universalleaf.com'
    ,28
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (39
    ,'Zimbabwe Leaf Tobacco Company (Private) Limited'
    ,'P. O. Box 1597'
    ,'1 Foundry Road, Aspindale Park'
    ,'Harare, Zimbabwe'
    ,'(+263 242) 621821-35 / 621811-9'
    ,'info@universalleaf.com'
    ,29
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName);

    DECLARE @b INT = 1;

    WHILE @b <= 4
    BEGIN

    DECLARE @a INT = 1;
    WHILE @a <= 39
    BEGIN

    INSERT INTO [dbo].[UserInfoUserInfoCompanyXref]
    ([UserInfoID]
    ,[UserInfoCompanyID]
    ,[UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo]
    ,[UserInfoUserInfoCompanyXrefActiveYesNo]
    ,[CreateUserName]
    ,[CreateFullName]
    ,[CreateDate]
    ,[UpdateUserName]
    ,[UpdateFullName])
    VALUES
    (@b
    ,@a
    ,@ActiveYesNo
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName);

    SET @a = @a + 1
    END
    SET @b = @b + 1
    END

    INSERT INTO [dbo].[UserInfoUserInfoCompanyXref]
    ([UserInfoID]
    ,[UserInfoCompanyID]
    ,[UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo]
    ,[UserInfoUserInfoCompanyXrefActiveYesNo]
    ,[CreateUserName]
    ,[CreateFullName]
    ,[CreateDate]
    ,[UpdateUserName]
    ,[UpdateFullName])
    VALUES
    (5
    ,1
    ,@ActiveYesNo
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (5
    ,10
    ,@ActiveYesNo
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (5
    ,34
    ,@ActiveYesNo
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName);

    INSERT INTO [dbo].[UserInfoStatus]
    ([UserInfoStatusID]
    ,[UserInfoStatusName]
    ,[UserInfoStatusActiveYesNo]
    ,[CreateUserName]
    ,[CreateFullName]
    ,[CreateDate]
    ,[UpdateUserName]
    ,[UpdateFullName])
    VALUES
    (0
    ,'NotCreated'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (10
    ,'Created'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (20
    ,'Signed'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (30
    ,'Approved'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (40
    ,'Complete'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (50
    ,'Unsigned'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (60
    ,'Rejected'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (70
    ,'Revoked'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName),
    (80
    ,'Deleted'
    ,@ActiveYesNo
    ,@UpdateUserName
    ,@UpdateFullName
    ,@CreateDate
    ,@UpdateUserName
    ,@UpdateFullName);

    GO

  