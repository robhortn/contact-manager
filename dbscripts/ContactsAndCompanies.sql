
USE [ContactManager]
GO

USE [ContactManager]
GO

INSERT INTO [dbo].[Company]
           ([CompanyName]
           ,[Address1]
           ,[Address2]
           ,[City]
           ,[StateId]
           ,[PostalCode]
           ,[PhoneNumber]
           ,[FaxNumber]
           ,[CategoryId]
           ,[IsActive])
     VALUES
           (
		   'Code12Studios',	
		   '18306 Royal Drive',
		   NULL,
		   'Warrenton',
		   25,
		   '63383',
		   '3145705675',
		   NULL,
		   3,
		   1
		   )

INSERT INTO [dbo].[Company]
           ([CompanyName]
           ,[Address1]
           ,[Address2]
           ,[City]
           ,[StateId]
           ,[PostalCode]
           ,[PhoneNumber]
           ,[FaxNumber]
           ,[CategoryId]
           ,[IsActive])
     VALUES
           (
		   'Blue Collar Development',	
		   '1300 Winghaven Blvd',
		   NULL,
		   'OFallon',
		   25,
		   '63368',
		   '6365551212',
		   '6365551213',
		   3,
		   1
		   )

INSERT INTO [dbo].[Contact]
           ([NameFirst]
           ,[NameLast]
           ,[PhoneDirectLine]
           ,[PhoneExtension]
           ,[PhoneHome]
           ,[EmailAddress]
           ,[CompanyId])
     VALUES
           (
		   'Rob',	
		   'Horton',
		   '3145551212',	
		   '1111',
		   '6365556789',
		   'robhorton@outlook.com',
		   1
		   )
GO

INSERT INTO [dbo].[Contact]
           ([NameFirst]
           ,[NameLast]
           ,[PhoneDirectLine]
           ,[PhoneExtension]
           ,[PhoneHome]
           ,[EmailAddress]
           ,[CompanyId])
     VALUES
           (
		   'Frank',	
		   'Jones',
		   '6365559876',	
		   '2222',
		   '6365556534',
		   'frankjones@gmail.com',
		   2
		   )
GO


