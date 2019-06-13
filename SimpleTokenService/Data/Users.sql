
-------------------------
-- Delete Data
-------------------------

DELETE FROM [UserRole]
GO
DELETE FROM [Role]
GO
DELETE FROM [User]
GO

-------------------------
-- Create Roles
-------------------------

SET IDENTITY_INSERT [Role] ON
GO

INSERT INTO [Role] 
	(Id, Name, NormalizedName)
values 
	(1, 'User', 'USER')

INSERT INTO [Role] 
	(Id, Name, NormalizedName)
values 
	(2, 'Admin', 'ADMIN')

INSERT INTO [Role] 
	(Id, Name, NormalizedName)
values 
	(3, 'SystemAdmin', 'SYSTEMADMIN')

SET IDENTITY_INSERT [Role] OFF
GO

-------------------------
-- Create User
-------------------------

SET IDENTITY_INSERT [User] ON
GO

INSERT [dbo].[User] 
	(Id, [UserName], [NormalizedUserName], [Email], [EmailConfirmed], [NormalizedEmail], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
VALUES 
	(1, N'johnmmoss@gmail.com', 'JOHNMMOSS@GMAIL.COM', N'johnmmoss@gmail.com', 1, 'JOHNMMOSS@GMAIL.COM', N'ADbCom4SGXj48MvTVjSQv/x0D68YQAJusz8qPIjLC8hhyn1YaftQ51UwlnLffRfOhA==', N'cdd6ba76-385f-492e-b291-b6db55b3f2af', NULL, 0, 0, NULL, 0, 0)

INSERT [dbo].[User] 
	(Id, [UserName], [NormalizedUserName], [Email], [EmailConfirmed], [NormalizedEmail], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
VALUES 
	(2, N'alice@email.com', 'ALICE@EMAIL.COM', N'alice@email.com', 1, 'ALICE@EMAIL.COM', N'ADbCom4SGXj48MvTVjSQv/x0D68YQAJusz8qPIjLC8hhyn1YaftQ51UwlnLffRfOhA==', N'7cef8aa7-e23c-4d15-9b51-05808c17238b', NULL, 0, 0, NULL, 0, 0)
	
INSERT [dbo].[User] 
	(Id, [UserName], [NormalizedUserName], [Email], [EmailConfirmed], [NormalizedEmail], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
VALUES 
	(3, N'bob@email.com', 'BOB@EMAIL.COM', N'bob@email.com', 1, 'BOB@EMAIL.COM', N'ADbCom4SGXj48MvTVjSQv/x0D68YQAJusz8qPIjLC8hhyn1YaftQ51UwlnLffRfOhA==', N'2f088023-16dd-4c89-a522-ddc9fa7c8718', NULL, 0, 0, NULL, 0, 0)

SET IDENTITY_INSERT [User] OFF
GO

-------------------------
-- Create UserRole
-------------------------

INSERT INTO [UserRole] 
	(UserId, RoleId)
Values
	(1, 3)

INSERT INTO [UserRole] 
	(UserId, RoleId)
Values
	(2, 2)

INSERT INTO [UserRole] 
	(UserId, RoleId)
Values
	(3, 1)
