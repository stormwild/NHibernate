IF NOT EXISTS (SELECT * FROM [dbo].[Customer])
BEGIN
	SET IDENTITY_INSERT [dbo].[Customer] ON
	INSERT INTO [dbo].[Customer] ([Id], [FirstName], [LastName]) VALUES (1, N'Harry', N'Potter')
	INSERT INTO [dbo].[Customer] ([Id], [FirstName], [LastName]) VALUES (2, N'Ron', N'Weasley')
	INSERT INTO [dbo].[Customer] ([Id], [FirstName], [LastName]) VALUES (3, N'Hermione', N'Granger')
	SET IDENTITY_INSERT [dbo].[Customer] OFF
END
