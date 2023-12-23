
create procedure sp_importJsonFiles
as
begin

	Declare @JSON varchar(max)
	SELECT @JSON = BulkColumn
	FROM OPENROWSET (
		BULK 'C:\Users\MFGGL\source\repos\mfgglr\TakasEt\Iss_Api\bin\Debug\net7.0\data\users.json',
		SINGLE_CLOB
	) as j
	SET IDENTITY_INSERT  [TakasEt].[dbo].[user] ON;
	insert into [TakasEt].[dbo].[user] (
		[Id],
		[Name],
		[LastName],
		[NormalizedFullName],
		[DateOfBirth],
		[Gender],
		[CreatedDate],
		[UpdatedDate],
		[UserName],
		[NormalizedUserName],
		[Email],
		[NormalizedEmail],
		[EmailConfirmed],
		[PasswordHash],
		[SecurityStamp],
		[ConcurrencyStamp],
		[PhoneNumber],
		[PhoneNumberConfirmed],
		[TwoFactorEnabled],
		[LockoutEnd],
		[LockoutEnabled],
		[AccessFailedCount],
		[CountOfPost]
	)
	SELECT * from OPENJSON (@JSON) with (
		Id int,
		Name varchar(50),
		LastName nvarchar(max),
		NormalizedFullName varchar(100),
		DateOfBirth datetime2(7),
		Gender bit,
		CreatedDate datetime2(7),
		UpdatedDate datetime2(7),
		UserName varchar(50),
		NormalizedUserName varchar(50),
		Email varchar(100),
		NormalizedEmail varchar(100),
		EmailConfirmed bit,
		PasswordHash nvarchar(max),
		SecurityStamp nvarchar(max),
		ConcurrencyStamp nvarchar(max),
		PhoneNumber nvarchar(max),
		PhoneNumberConfirmed bit,
		TwoFactorEnabled bit,
		LockoutEnd datetimeoffset(7),
		LockoutEnabled bit,
		AccessFailedCount int,
		CountOfPost int
	)
	SET IDENTITY_INSERT  [TakasEt].[dbo].[user] OFF;

	SELECT @JSON = BulkColumn
	FROM OPENROWSET (
		BULK 'C:\Users\MFGGL\source\repos\mfgglr\TakasEt\Iss_Api\bin\Debug\net7.0\data\userRoles.json',
		SINGLE_CLOB
	) as j
	SET IDENTITY_INSERT  [TakasEt].[dbo].[userRole] ON;
	insert into [TakasEt].[dbo].[userRole] (
		[Id],
		[RoleId],
		[UserId],
		[CreatedDate],
		[UpdatedDate]
	)
	SELECT * from OPENJSON (@JSON) with (
		Id int,
		RoleId int,
		UserId int,
		CreatedDate datetime2(7),
		UpdatedDate datetime2(7)
	)
	SET IDENTITY_INSERT  [TakasEt].[dbo].[userRole] OFF;

	SELECT @JSON = BulkColumn
	FROM OPENROWSET (
		BULK 'C:\Users\MFGGL\source\repos\mfgglr\TakasEt\Iss_Api\bin\Debug\net7.0\data\userImages.json',
		SINGLE_CLOB
	) as j
	SET IDENTITY_INSERT  [TakasEt].[dbo].[userImage] ON;
	insert into [TakasEt].[dbo].[userImage] (
		[Id],
		[UserId],
		[BlobName],
		[ContainerName],
		[Extention],
		[IsActive],
		[CreatedDate],
		[UpdatedDate]
	)
	SELECT * from OPENJSON (@JSON) with (
		Id int,
		UserId int,
		BlobName nvarchar(max),
		ContainerName nvarchar(max),
		Extention nvarchar(max),
		IsActive bit,
		CreatedDate datetime2(7),
		UpdatedDate datetime2(7)
	)
	SET IDENTITY_INSERT  [TakasEt].[dbo].[userImage] OFF;

	SELECT @JSON = BulkColumn
	FROM OPENROWSET (
		BULK 'C:\Users\MFGGL\source\repos\mfgglr\TakasEt\Iss_Api\bin\Debug\net7.0\data\followings.json',
		SINGLE_CLOB
	) as j
	SET IDENTITY_INSERT  [TakasEt].[dbo].[UserUserFollowing] ON;
	insert into [TakasEt].[dbo].[UserUserFollowing] (
		[Id],
		[FollowerId],
		[FollowedId],
		[CreatedDate],
		[UpdatedDate]
	)
	SELECT * from OPENJSON (@JSON) with (
		Id int,
		FollowerId int,
		FollowedId int,
		CreatedDate datetime2(7),
		UpdatedDate datetime2(7)
	)
	SET IDENTITY_INSERT  [TakasEt].[dbo].[UserUserFollowing] OFF;

	SELECT @JSON = BulkColumn
	FROM OPENROWSET (
		BULK 'C:\Users\MFGGL\source\repos\mfgglr\TakasEt\Iss_Api\bin\Debug\net7.0\data\posts.json',
		SINGLE_CLOB
	) as j
	SET IDENTITY_INSERT  [TakasEt].[dbo].[post] ON;
	insert into [TakasEt].[dbo].[Post] (
		[Id],
		[UserId],
		[CategoryId],
		[Title],
		[NormalizedTitle],
		[Content],
		[CountOfImages], 
		[CreatedDate],
		[UpdatedDate]
	)
	SELECT * from OPENJSON (@JSON) with (
		Id int,
		UserId int,
		CategoryId int,
		Title varchar(256),
		NormalizedTitle varchar(256),
		Content nvarchar(max),
		CountOfImages int,
		CreatedDate datetime2(7),
		UpdatedDate datetime2(7)
	)
	SET IDENTITY_INSERT  [TakasEt].[dbo].[Post] OFF;

	SELECT @JSON = BulkColumn
	FROM OPENROWSET (
		BULK 'C:\Users\MFGGL\source\repos\mfgglr\TakasEt\Iss_Api\bin\Debug\net7.0\data\postImages.json',
		SINGLE_CLOB
	) as j
	SET IDENTITY_INSERT  [TakasEt].[dbo].[PostImage] ON;
	insert into [TakasEt].[dbo].[PostImage] (
		[Id],
		[BlobName],
		[ContainerName],
		[Extention],
		[PostId],
		[Index],
		[CreatedDate],
		[UpdatedDate]
	)
	SELECT * from OPENJSON (@JSON) with (
		Id int,
		BlobName nvarchar(max),
		ContainerName nvarchar(max),
		Extention nvarchar(max),
		PostId int,
		[Index] int,
		CreatedDate datetime2(7),
		UpdatedDate datetime2(7)
	)
	SET IDENTITY_INSERT  [TakasEt].[dbo].[PostImage] OFF;

	SELECT @JSON = BulkColumn
	FROM OPENROWSET (
		BULK 'C:\Users\MFGGL\source\repos\mfgglr\TakasEt\Iss_Api\bin\Debug\net7.0\data\comments.json',
		SINGLE_CLOB
	) as j
	SET IDENTITY_INSERT  [TakasEt].[dbo].[Comment] ON;
	insert into [TakasEt].[dbo].[Comment] (
		[Id],
		[PostId],
		[UserId],
		[Content],
		[ParentId],
		[CreatedDate],
		[UpdatedDate]
	)
	SELECT * from OPENJSON (@JSON) with (
		Id int,
		PostId int,
		UserId int,
		Content nvarchar(max),
		ParentId int,
		CreatedDate datetime2(7),
		UpdatedDate datetime2(7)
	)
	SET IDENTITY_INSERT  [TakasEt].[dbo].[Comment] OFF;

end
