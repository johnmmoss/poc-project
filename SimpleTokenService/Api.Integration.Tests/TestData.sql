INSERT [dbo].[User] 
	([UserName], [NormalizedUserName], [Email], [EmailConfirmed], [NormalizedEmail], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
VALUES 
	( N'johnmmoss@gmail.com', 'JOHNMMOSS@GMAIL.COM', N'johnmmoss@gmail.com', 1, 'JOHNMMOSS@GMAIL.COM', N'ADbCom4SGXj48MvTVjSQv/x0D68YQAJusz8qPIjLC8hhyn1YaftQ51UwlnLffRfOhA==', N'cdd6ba76-385f-492e-b291-b6db55b3f2af', NULL, 0, 0, NULL, 0, 0)
