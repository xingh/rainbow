﻿IF NOT EXISTS (SELECT * FROM sysobjects where id = object_id(N'[rb_EcommerceMerchants]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [rb_EcommerceMerchants] (
	[MerchantID] [nvarchar] (25) NOT NULL ,
	[PortalID] [int] NULL ,
	[GatewayName] [nvarchar] (50) NULL ,
	[Name] [nvarchar] (50) NOT NULL ,
	[MerchantEmail] [nvarchar] (50) NULL ,
	[TechnicalEmail] [nvarchar] (50) NULL ,
	[MetadataXml] [nvarchar] (3000) NULL ,
	[MerchantType] [char] (1) NOT NULL CONSTRAINT [DF__rb_EcommerceMerchants_MerchantType] DEFAULT ('G'),
	CONSTRAINT [PK_rb_EcommerceMerchants] PRIMARY KEY  CLUSTERED 
	(
		[MerchantID]
	),
	CONSTRAINT [CK_rb_EcommerceMerchants] CHECK ([MerchantID] <> '')
)
END
GO


ALTER TABLE [rb_EcommerceMerchants] 
ALTER COLUMN
	[Name] [nvarchar] (50) NOT NULL
GO

IF NOT EXISTS (SELECT name FROM syscolumns WHERE id = OBJECT_ID('rb_EcommerceMerchants') AND name='PortalID')
BEGIN
ALTER TABLE [rb_EcommerceMerchants] ADD
	[PortalID] [int] NOT NULL DEFAULT 0
PRINT 'Column PortalID created'
END
GO

IF NOT EXISTS (SELECT name FROM syscolumns WHERE id = OBJECT_ID('rb_EcommerceMerchants') AND COLUMNPROPERTY(OBJECT_ID('rb_EcommerceMerchants'), 'MerchantType', 'AllowsNull') = 0)
BEGIN
ALTER TABLE [rb_EcommerceMerchants] ADD
	[MerchantType] [char] (1) NOT NULL DEFAULT 'G'
PRINT 'Column MerchantType created'
END
GO

--Data Sample 
IF EXISTS (SELECT * FROM sysobjects where id = object_id(N'[rb_EcommerceMer_IU]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [rb_EcommerceMer_IU]
GO

Create Proc rb_EcommerceMer_IU 	@MerchantID	nvarchar(25),  	@PortalID	int,  	@GatewayName	nvarchar(50),  	@Name	nvarchar(50),  	@MerchantEmail	nvarchar(50),  	@TechnicalEmail	nvarchar(50),  	@MetadataXml	nvarchar(3000),  	@MerchantType	char(1)  AS  SET nocount ON  	UPDATE "rb_EcommerceMerchants" 	SET PortalID = @PortalID,  		GatewayName = @GatewayName,  		Name = @Name,  		MerchantEmail = @MerchantEmail,  		TechnicalEmail = @TechnicalEmail,  		MetadataXml = @MetadataXml,  		MerchantType = @MerchantType 	WHERE MerchantID	=	@MerchantID  	IF @@rowcount = 0 	BEGIN 	INSERT "rb_EcommerceMerchants" (MerchantID,  		PortalID,  		GatewayName,  		Name,  		MerchantEmail,  		TechnicalEmail,  		MetadataXml,  		MerchantType) 	VALUES (@MerchantID,  		@PortalID,  		@GatewayName,  		@Name,  		@MerchantEmail,  		@TechnicalEmail,  		@MetadataXml,  		@MerchantType) 	END  Return 
GO

--	@MerchantID	,	@PortalID	,	@GatewayName	,	@Name	,	@MerchantEmail	,	@TechnicalEmail	,	@MetadataXml	,	@MerchantType
exec rb_EcommerceMer_IU 	N'001'	,	0	,	N'CreditTransfer'	,	N'Credit Transfer DEMO'		,	N'testemail@testsite.com'	,	N'testemail@testsite.com'	,	N'<Metadata CreditInstitute="MyBank" BankCode="11222" FaxNumber="0005555-000000"/>'	,	'G'
exec rb_EcommerceMer_IU 	N'100'	,	0	,	N'FixedShipping'			,	N'Shipping DEMO (Euros)'	,	N'testemail@testsite.com'	,	N'testemail@testsite.com'	,	N'<Metadata Rate="1" MinValue="€ 10" />'	,	'S'
exec rb_EcommerceMer_IU 	N'150'	,	0	,	N'FixedShipping'			,	N'Shipping DEMO (Dollars)'	,	N'testemail@testsite.com'	,	N'testemail@testsite.com'	,	N'<Metadata Rate="1" MinValue="$ 10" />'	,	'S'
exec rb_EcommerceMer_IU 	N'200'	,	0	,	N'ElectronicDelivery'			,	N'Electronic Delivery DEMO'	,	N'testemail@testsite.com'	,	N'testemail@testsite.com'	,	N'<Metadata />'	,	'S'
exec rb_EcommerceMer_IU 	N'300'	,	0	,	N'SimpleShipping'			,	N'My simple shipping'		,	N'testemail@testsite.com'	,	N'testemail@testsite.com'	,	N'<Metadata Rates="IT;3000;€ 15|AD,AL,AT,BA,BE,BG,BY,CH,CZ,DE,DK,EE,ES,FI,FO,FR,GB,GI,GR,HR,HU,IE,IS,IT,LI,LT,LU,LV,MC,MD,MK,MT,NL,NO,PL,PT,RO,RU,SE,SI,SK,SM,UA,VA,YU;2000;€ 75|US,CA;2000;€ 150|AE;2000;€ 120" />'	,	'S'
GO

IF EXISTS (SELECT * FROM sysobjects where id = object_id(N'[rb_EcommerceMer_IU]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [rb_EcommerceMer_IU]
GO

--7 rows scripted

IF EXISTS (SELECT * FROM sysobjects where id = object_id(N'[rb_EcommerceGetMerchant]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [rb_EcommerceGetMerchant]
GO

CREATE PROCEDURE rb_EcommerceGetMerchant
(
	@MerchantID nvarchar(25)
)
AS

SELECT     *
FROM         rb_EcommerceMerchants
WHERE     (MerchantID = @MerchantID)
GO

----------------------------------------------------------------------------------
-- 
-- This code has been generated by KickStarter :- http://kickstarter.net
-- 
-- Version :- 2.0.30.18519
-- Date    :- 04/11/2003
-- Time    :- 13.22
-- 
----------------------------------------------------------------------------------
-- 
-- Copyright (C) 2002 - 2003 KickStarter
-- 
-- THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
-- OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
-- LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
-- FITNESS FOR A PARTICULAR PURPOSE.
-- 
----------------------------------------------------------------------------------


IF EXISTS (SELECT name FROM sysobjects WHERE name = 'rb_EcommerceMerchantsSelect' AND type = 'P')
	DROP PROCEDURE rb_EcommerceMerchantsSelect
go


CREATE PROCEDURE rb_EcommerceMerchantsSelect

@MerchantID nvarchar(25)

AS

SET NOCOUNT ON

SELECT	rb_EcommerceMerchants.MerchantID,
	rb_EcommerceMerchants.PortalID,
	rb_EcommerceMerchants.GatewayName,
	rb_EcommerceMerchants.Name,
	rb_EcommerceMerchants.MerchantEmail,
	rb_EcommerceMerchants.TechnicalEmail,
	rb_EcommerceMerchants.MetadataXml,
	rb_EcommerceMerchants.MerchantType,
	BINARY_CHECKSUM(rb_EcommerceMerchants.MerchantID, rb_EcommerceMerchants.PortalID, rb_EcommerceMerchants.GatewayName, rb_EcommerceMerchants.Name, rb_EcommerceMerchants.MerchantEmail, rb_EcommerceMerchants.TechnicalEmail, rb_EcommerceMerchants.MetadataXml, rb_EcommerceMerchants.MerchantType) As BINARY_CHECKSUM
FROM	rb_EcommerceMerchants
WHERE 	rb_EcommerceMerchants.MerchantID = @MerchantID

SET NOCOUNT OFF

go


IF EXISTS (SELECT name FROM sysobjects WHERE name = 'rb_EcommerceMerchantsSelectAll' AND type = 'P')
	DROP PROCEDURE rb_EcommerceMerchantsSelectAll
go


CREATE PROCEDURE rb_EcommerceMerchantsSelectAll

AS

SET NOCOUNT ON

SELECT	rb_EcommerceMerchants.MerchantID,
	rb_EcommerceMerchants.PortalID,
	rb_EcommerceMerchants.GatewayName,
	rb_EcommerceMerchants.Name,
	rb_EcommerceMerchants.MerchantEmail,
	rb_EcommerceMerchants.TechnicalEmail,
	rb_EcommerceMerchants.MetadataXml,
	rb_EcommerceMerchants.MerchantType,
	BINARY_CHECKSUM(rb_EcommerceMerchants.MerchantID, rb_EcommerceMerchants.PortalID, rb_EcommerceMerchants.GatewayName, rb_EcommerceMerchants.Name, rb_EcommerceMerchants.MerchantEmail, rb_EcommerceMerchants.TechnicalEmail, rb_EcommerceMerchants.MetadataXml, rb_EcommerceMerchants.MerchantType) As BINARY_CHECKSUM
FROM	rb_EcommerceMerchants

SET NOCOUNT OFF
go


IF EXISTS (SELECT name FROM sysobjects WHERE name = 'rb_EcommerceMerchantsSelectAllGateways' AND type = 'P')
	DROP PROCEDURE rb_EcommerceMerchantsSelectAllGateways
go

CREATE PROCEDURE rb_EcommerceMerchantsSelectAllGateways

AS

SET NOCOUNT ON

SELECT	rb_EcommerceMerchants.MerchantID,
	rb_EcommerceMerchants.PortalID,
	rb_EcommerceMerchants.GatewayName,
	rb_EcommerceMerchants.Name,
	rb_EcommerceMerchants.MerchantEmail,
	rb_EcommerceMerchants.TechnicalEmail,
	rb_EcommerceMerchants.MetadataXml,
	rb_EcommerceMerchants.MerchantType,
	BINARY_CHECKSUM(rb_EcommerceMerchants.MerchantID, rb_EcommerceMerchants.PortalID, rb_EcommerceMerchants.GatewayName, rb_EcommerceMerchants.Name, rb_EcommerceMerchants.MerchantEmail, rb_EcommerceMerchants.TechnicalEmail, rb_EcommerceMerchants.MetadataXml, rb_EcommerceMerchants.MerchantType) As BINARY_CHECKSUM
FROM	rb_EcommerceMerchants
WHERE rb_EcommerceMerchants.MerchantType = 'G'

SET NOCOUNT OFF

go


IF EXISTS (SELECT name FROM sysobjects WHERE name = 'rb_EcommerceMerchantsSelectAllShipping' AND type = 'P')
	DROP PROCEDURE rb_EcommerceMerchantsSelectAllShipping
go

CREATE PROCEDURE rb_EcommerceMerchantsSelectAllShipping

AS

SET NOCOUNT ON

SELECT	rb_EcommerceMerchants.MerchantID,
	rb_EcommerceMerchants.PortalID,
	rb_EcommerceMerchants.GatewayName,
	rb_EcommerceMerchants.Name,
	rb_EcommerceMerchants.MerchantEmail,
	rb_EcommerceMerchants.TechnicalEmail,
	rb_EcommerceMerchants.MetadataXml,
	rb_EcommerceMerchants.MerchantType,
	BINARY_CHECKSUM(rb_EcommerceMerchants.MerchantID, rb_EcommerceMerchants.PortalID, rb_EcommerceMerchants.GatewayName, rb_EcommerceMerchants.Name, rb_EcommerceMerchants.MerchantEmail, rb_EcommerceMerchants.TechnicalEmail, rb_EcommerceMerchants.MetadataXml, rb_EcommerceMerchants.MerchantType) As BINARY_CHECKSUM
FROM	rb_EcommerceMerchants
WHERE rb_EcommerceMerchants.MerchantType = 'S'

SET NOCOUNT OFF

go


-- Unable to generate Search Stored Procedure
-- rb_EcommerceMerchants does not have any Search Attributes Defined.go


IF EXISTS (SELECT name FROM sysobjects WHERE name = 'rb_EcommerceMerchantsInsert' AND type = 'P')
	DROP PROCEDURE rb_EcommerceMerchantsInsert
go


CREATE PROCEDURE rb_EcommerceMerchantsInsert

@MerchantID nvarchar(25),
@PortalID int = NULL,
@GatewayName nvarchar(50) = NULL,
@Name nvarchar(50) = NULL,
@MerchantEmail nvarchar(50) = NULL,
@TechnicalEmail nvarchar(50) = NULL,
@MetadataXml nvarchar(3000) = NULL,
@MerchantType char(1)

AS

SET NOCOUNT ON

DECLARE @ROWCOUNT int

INSERT INTO rb_EcommerceMerchants (
	MerchantID,
	PortalID,
	GatewayName,
	Name,
	MerchantEmail,
	TechnicalEmail,
	MetadataXml,
	MerchantType )
VALUES (
	@MerchantID,
	@PortalID,
	@GatewayName,
	@Name,
	@MerchantEmail,
	@TechnicalEmail,
	@MetadataXml,
	@MerchantType )


SELECT @ROWCOUNT = @@ROWCOUNT


IF @ROWCOUNT = 0 BEGIN
	RAISERROR ('rb_EcommerceMerchants Record failed to insert.', 16, 1)
END

SET NOCOUNT OFF

go


IF EXISTS (SELECT name FROM sysobjects WHERE name = 'rb_EcommerceMerchantsUpdate' AND type = 'P')
	DROP PROCEDURE rb_EcommerceMerchantsUpdate
go


CREATE PROCEDURE rb_EcommerceMerchantsUpdate

@MerchantID nvarchar(25),
@PortalID int = NULL,
@GatewayName nvarchar(50) = NULL,
@Name nvarchar(50) = NULL,
@MerchantEmail nvarchar(50) = NULL,
@TechnicalEmail nvarchar(50) = NULL,
@MetadataXml nvarchar(3000) = NULL,
@MerchantType char(1),
@BINARY_CHECKSUM int OUTPUT

AS

SET NOCOUNT ON

UPDATE 	rb_EcommerceMerchants
SET	PortalID = @PortalID,
	GatewayName = @GatewayName,
	Name = @Name,
	MerchantEmail = @MerchantEmail,
	TechnicalEmail = @TechnicalEmail,
	MetadataXml = @MetadataXml,
	MerchantType = @MerchantType
WHERE	MerchantID = @MerchantID
AND	BINARY_CHECKSUM(rb_EcommerceMerchants.MerchantID, rb_EcommerceMerchants.PortalID, rb_EcommerceMerchants.GatewayName, rb_EcommerceMerchants.Name, rb_EcommerceMerchants.MerchantEmail, rb_EcommerceMerchants.TechnicalEmail, rb_EcommerceMerchants.MetadataXml, rb_EcommerceMerchants.MerchantType) = @BINARY_CHECKSUM

IF @@ROWCOUNT = 0 BEGIN
	RAISERROR ('rb_EcommerceMerchants Record failed to update, it may have been updated by another user.', 16, 1)
END

SELECT	@BINARY_CHECKSUM = BINARY_CHECKSUM(rb_EcommerceMerchants.MerchantID, rb_EcommerceMerchants.PortalID, rb_EcommerceMerchants.GatewayName, rb_EcommerceMerchants.Name, rb_EcommerceMerchants.MerchantEmail, rb_EcommerceMerchants.TechnicalEmail, rb_EcommerceMerchants.MetadataXml, rb_EcommerceMerchants.MerchantType)
FROM	rb_EcommerceMerchants
WHERE	MerchantID = @MerchantID

SET NOCOUNT OFF

go


IF EXISTS (SELECT name FROM sysobjects WHERE name = 'rb_EcommerceMerchantsDelete' AND type = 'P')
	DROP PROCEDURE rb_EcommerceMerchantsDelete
go


CREATE PROCEDURE rb_EcommerceMerchantsDelete

@MerchantID nvarchar(25)

AS

SET NOCOUNT ON

DELETE	FROM rb_EcommerceMerchants
WHERE 	MerchantID = @MerchantID


IF @@ERROR = 547 BEGIN
	RAISERROR ('Unable to delete the rb_EcommerceMerchants record, it is referenced by another record.', 16, 1)
	RETURN 0
END

SET NOCOUNT OFF

go