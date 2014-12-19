DELETE FROM CustomerType

SET IDENTITY_INSERT [dbo].[CustomerType] ON
INSERT INTO [dbo].[CustomerType] ([CustomerTypeId], [TypeName]) VALUES (1, N'Corporation')
INSERT INTO [dbo].[CustomerType] ([CustomerTypeId], [TypeName]) VALUES (2, N'Individual')
INSERT INTO [dbo].[CustomerType] ([CustomerTypeId], [TypeName]) VALUES (3, N'Educator')
INSERT INTO [dbo].[CustomerType] ([CustomerTypeId], [TypeName]) VALUES (4, N'Government')
SET IDENTITY_INSERT [dbo].[CustomerType] OFF
