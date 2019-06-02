/***********************************************************************************************************************************
** Procedure Name	: [dbo].[proc_GetData]
** Description		: Retrieving the buyers and admin data
** Author	        : dileep.siddi
** Date		        : 02-06-2019
************************************************************************************************************************************
** Test Call(s)		: EXEC[dbo].[proc_GetData] "admin"		
                          EXEC[dbo].[proc_GetData] "buyer"	
************************************************************************************************************************************
*** Change History
************************************************************************************************************************************
** PR/SNO	Date			Author								Description 
** ------	-----------		--------------------------------	--------------------------------------------------------------------
** 00001	 02-06-2019      dileep.siddi       		        Retrieving the buyers and admin data					
** 00002		
***********************************************************************************************************************************/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_GetData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[proc_GetData] AS' 
END
GO

ALTER PROCEDURE [dbo].[proc_GetData](@p_type varchar(20))
AS  
BEGIN

SET XACT_ABORT ON;
SET NOCOUNT ON;

		/* BEGIN */
if(@p_type = 'admin')

begin
      select [user_id] 
	       , first_nm
		   , last_nm           
           , is_admin 
        from dbo.tbl_oms_users
       where is_active <> 0  and is_admin is not Null
end

else if(@p_type = 'buyer')

begin
     select [user_id] 
	       , order_id
	       , first_nm
		   , last_nm           
           , is_admin 
        from dbo.tbl_oms_users
       where is_active <> 0  and is_admin is Null
end
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