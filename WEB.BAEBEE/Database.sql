CREATE DATABASE [WEB.BAEBEE];

USE [WEB.BAEBEE];
CREATE TABLE dbo.REPOSITORY (
	ID uniqueidentifier DEFAULT newid() NOT NULL,
	CODE varchar(100) COLLATE Latin1_General_CI_AS NOT NULL,
	MODUL varchar(150) COLLATE Latin1_General_CI_AS NOT NULL,
	FILE_NAME varchar(150) COLLATE Latin1_General_CI_AS NOT NULL,
	DESCRIPTION varchar(MAX) COLLATE Latin1_General_CI_AS NULL,
	EXTENSION varchar(20) COLLATE Latin1_General_CI_AS NOT NULL,
	MIME_TYPE nvarchar(100) COLLATE Latin1_General_CI_AS NOT NULL,
	IS_PUBLIC bit NOT NULL,
	CREATE_BY varchar(250) COLLATE Latin1_General_CI_AS NOT NULL,
	CREATE_DATE datetime DEFAULT getdate() NOT NULL,
	CONSTRAINT PK_REPOSITORY PRIMARY KEY (ID)
);

CREATE TABLE dbo.[ROLE] (
	ID varchar(50) COLLATE Latin1_General_CI_AS NOT NULL,
	NAME varchar(100) COLLATE Latin1_General_CI_AS NOT NULL,
	ACTIVE bit NOT NULL,
	CREATE_BY varchar(250) COLLATE Latin1_General_CI_AS NOT NULL,
	CREATE_DATE datetime DEFAULT getdate() NOT NULL,
	UPDATE_BY varchar(250) COLLATE Latin1_General_CI_AS NULL,
	UPDATE_DATE datetime NULL,
	CONSTRAINT PK_ROLE PRIMARY KEY (ID)
);

CREATE TABLE dbo.[USER] (
	ID uniqueidentifier DEFAULT newid() NOT NULL,
	USERNAME nvarchar(80) COLLATE Latin1_General_CI_AS NOT NULL,
	PASSWORD nvarchar(50) COLLATE Latin1_General_CI_AS NOT NULL,
	FULLNAME varchar(MAX) COLLATE Latin1_General_CI_AS NULL,
	MAIL nvarchar(150) COLLATE Latin1_General_CI_AS NOT NULL,
	PHONE_NUMBER nvarchar(50) COLLATE Latin1_General_CI_AS NULL,
	TOKEN nvarchar(250) COLLATE Latin1_General_CI_AS NULL,
	IS_LOCKOUT bit NOT NULL,
	ACCESS_FAILED_COUNT int NOT NULL,
	ACTIVE bit NOT NULL,
	CREATE_BY varchar(250) COLLATE Latin1_General_CI_AS NOT NULL,
	CREATE_DATE datetime DEFAULT getdate() NOT NULL,
	UPDATE_BY varchar(250) COLLATE Latin1_General_CI_AS NULL,
	UPDATE_DATE datetime NULL,
	CONSTRAINT PK_USER PRIMARY KEY (ID)
);

CREATE TABLE dbo.NOTIFICATION (
	ID uniqueidentifier DEFAULT newid() NOT NULL,
	ID_USER uniqueidentifier NOT NULL,
	USER_FULLNAME varchar(150) COLLATE Latin1_General_CI_AS NOT NULL,
	USER_MAIL nvarchar(150) COLLATE Latin1_General_CI_AS NULL,
	USER_PHONE nvarchar(50) COLLATE Latin1_General_CI_AS NULL,
	SUBJECT varchar(50) COLLATE Latin1_General_CI_AS NOT NULL,
	DESCRIPTION varchar(250) COLLATE Latin1_General_CI_AS NOT NULL,
	NAVIGATION varchar(250) COLLATE Latin1_General_CI_AS NOT NULL,
	IS_OPEN bit NOT NULL,
	CREATE_BY varchar(250) COLLATE Latin1_General_CI_AS NOT NULL,
	CREATE_DATE datetime DEFAULT getdate() NOT NULL,
	CONSTRAINT PK_NOTIFICATION PRIMARY KEY (ID),
	CONSTRAINT NOTIFICATION_FK FOREIGN KEY (ID_USER) REFERENCES dbo.[USER](ID) ON DELETE CASCADE
);

CREATE TABLE dbo.USER_ROLE (
	ID uniqueidentifier DEFAULT newid() NOT NULL,
	ID_USER uniqueidentifier NOT NULL,
	ID_ROLE varchar(50) COLLATE Latin1_General_CI_AS NOT NULL,
	CREATE_BY varchar(250) COLLATE Latin1_General_CI_AS NOT NULL,
	CREATE_DATE datetime DEFAULT getdate() NOT NULL,
	CONSTRAINT PK_USER_ROLE PRIMARY KEY (ID),
	CONSTRAINT FK_USER_ROLE_ROLE FOREIGN KEY (ID_ROLE) REFERENCES dbo.[ROLE](ID) ON DELETE CASCADE,
	CONSTRAINT FK_USER_ROLE_USER FOREIGN KEY (ID_USER) REFERENCES dbo.[USER](ID) ON DELETE CASCADE
);

INSERT INTO dbo.[ROLE] (ID,NAME,ACTIVE,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE) VALUES
	 (N'ADM',N'Admin',1,N'SYSTEM',getdate(),N'SYSTEM',getdate()),
	 (N'MBR',N'Member',1,N'SYSTEM',getdate(),N'SYSTEM',getdate());

INSERT INTO dbo.[USER] (ID,USERNAME,PASSWORD,FULLNAME,MAIL,PHONE_NUMBER,TOKEN,IS_LOCKOUT,ACCESS_FAILED_COUNT,ACTIVE,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE) VALUES
	 (N'491874CE-92C0-4CFD-83B7-F916DF7C219B',N'Admin',N'5F4DCC3B5AA765D61D8327DEB882CF99',N'Administrator',N'admin@mail.com',N'0000000',null,0,0,1,N'SYSTEM',getdate(),N'SYSTEM',getdate());

INSERT INTO dbo.USER_ROLE (ID,ID_USER,ID_ROLE,CREATE_BY,CREATE_DATE) VALUES
	 (N'2DA981E5-B0EE-4630-B755-2A10CA0F15BF',N'491874CE-92C0-4CFD-83B7-F916DF7C219B',N'ADM',N'SYSTEM',getdate());
