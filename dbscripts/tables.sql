

use ContactManager

drop table Contact
drop table Company
drop table [State]
drop table CompanyCategory


if not exists (select * from sysobjects where name='State' and xtype='U')

	CREATE TABLE [State](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[StateCode] [varchar](10) NOT NULL,
		[StateName] [varchar](50) NOT NULL,
	PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	GO
go

if not exists (select * from sysobjects where name='CompanyCategory' and xtype='U')
	CREATE TABLE CompanyCategory(
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Category] [varchar](50) NOT NULL,
	PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	GO
go


if not exists (select * from sysobjects where name='Company' and xtype='U')
	  CREATE TABLE [dbo].[Company](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[CompanyName] [varchar](50) NOT NULL,
		[Address1] [varchar](100) NULL,
		[Address2] [varchar](100) NULL,
		[City] [varchar](50) NULL,
		[StateId] [int] NOT NULL,
		[PostalCode] [varchar](5) NULL,
		[PhoneNumber] [varchar](10) NULL,
		[FaxNumber] [varchar](10) NULL,
		[CategoryId] [int] NULL,
	 CONSTRAINT [PK__Company__3214EC071D4FC8DD] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	GO

	ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_CompanyCategory] FOREIGN KEY([CategoryId])
	REFERENCES [dbo].[CompanyCategory] ([Id])
	GO

	ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_CompanyCategory]
	GO

	ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_State] FOREIGN KEY([StateId])
	REFERENCES [dbo].[State] ([Id])
	GO

	ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_State]
	GO
go

if not exists(select * from sysobjects where name = 'Contact' and xtype = 'U')
	create table Contact (
		Id int IDENTITY(1,1) not null,
		NameFirst varchar(50) not null, 
		NameLast varchar(50) not null,
		PhoneDirectLine varchar(10) not null,
		PhoneExtension varchar(10) not null,
		PhoneHome varchar(10) not null,
		EmailAddress varchar(100) not null,
		CompanyId int not null
	)

	ALTER TABLE [dbo].[Contact]  WITH CHECK ADD  CONSTRAINT [FK_Contact_Company] FOREIGN KEY([CompanyId])
	REFERENCES [dbo].[Company] ([Id])
	GO

	ALTER TABLE [dbo].[Contact] CHECK CONSTRAINT [FK_Contact_Company]
	GO

go


