/***********************************************************************************************************************************
** Table Name      	: tbl_orders
** Description		: Orders table
** Author		: dileep.siddi
** Date			: 02-06-2019
************************************************************************************************************************************
** PR/SNO	Date			Author								Description 
** ------	-----------		--------------------------------	--------------------------------------------------------------------
** 00001	 02-06-2019              dileep.siddi       		                   Orders table					
** 00002		
***********************************************************************************************************************************/
IF NOT EXISTS (
              SELECT * 
              FROM Tesseract.INFORMATION_SCHEMA.TABLES                    
                       WHERE TABLE_SCHEMA = 'dbo' and TABLE_NAME='tbl_orders'                      
                       )
	
print 'Creating "tbl_orders" Table in dbo Schema '

begin

CREATE TABLE [tbl_orders](
	OrderId int IDENTITY(1,1) NOT NULL,
	BuyerId nvarchar(max) NOT NULL,
	OrderDate [datetime]  DEFAULT (getdate()),
	ShippingDate [datetime]  DEFAULT (getdate()),
	TransactionStatus  nvarchar(max),
	PaymentDate [datetime]  DEFAULT (getdate()),
	TotalAmount int,
	BillingAddress  nvarchar(max),
	ShippingAddress nvarchar(max),
	PhoneNumber int,
	EmailId nvarchar(max),

 CONSTRAINT [PK_tbl_orders] PRIMARY KEY CLUSTERED 
(
	OrderId ASC
),

)

		/* END */
	  
END
GO
 /*******************************************************************************************************************************************
 * N A V T E C H   C O N F I D E N T I A L 
 ********************************************************************************************************************************************
 * Copyright (C) 2019
 * NavTech (Navaratan Technologies).
 * All Rights Reserved.
 ********************************************************************************************************************************************
 * NOTICE:  All information contained herein is, and remains the property of NAVTECH and its suppliers, if any.
 * The intellectual and technical concepts contained herein are proprietary to NAVTECH.
 * Dissemination of this information or reproduction of this material is strictly forbidden unless prior written permission is obtained from
 * NAVTECH.
 ********************************************************************************************************************************************
 */