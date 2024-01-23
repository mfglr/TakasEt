	Declare @JSON varchar(max)
	SELECT @JSON = BulkColumn
	FROM OPENROWSET (
		BULK 'C:\Users\MFGGL\source\repos\mfgglr\TakasEt\Iss_Api\bin\Debug\net7.0\data\jsons\users.json',
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
		[NumberOfPost],
		[RemovedDate],
		[IsRemoved]
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
		NumberOfPost int,
		RemovedDate datetime2(7),
		IsRemoved bit
	)
	SET IDENTITY_INSERT  [TakasEt].[dbo].[user] OFF;


	SELECT @JSON = BulkColumn
	FROM OPENROWSET (
		BULK 'C:\Users\MFGGL\source\repos\mfgglr\TakasEt\Iss_Api\bin\Debug\net7.0\data\jsons\roles.json',
		SINGLE_CLOB
	) as j
	SET IDENTITY_INSERT  [TakasEt].[dbo].[Role] ON;
	insert into [TakasEt].[dbo].[Role] (
		[Id],
		[Name],
		[CreatedDate],
		[UpdatedDate],
		[RemovedDate],
		[IsRemoved]
	)
	SELECT * from OPENJSON (@JSON) with (
		Id int,
		[Name] nvarchar(max),
		CreatedDate datetime2(7),
		UpdatedDate datetime2(7),
		RemovedDate datetime2(7),
		IsRemoved bit
	)
	SET IDENTITY_INSERT  [TakasEt].[dbo].[Role] OFF;


	SELECT @JSON = BulkColumn
	FROM OPENROWSET (
		BULK 'C:\Users\MFGGL\source\repos\mfgglr\TakasEt\Iss_Api\bin\Debug\net7.0\data\jsons\userRoles.json',
		SINGLE_CLOB
	) as j

	insert into [TakasEt].[dbo].[userRole] (
		[RoleId],
		[UserId],
		[CreatedDate],
		[UpdatedDate]
	)
	SELECT * from OPENJSON (@JSON) with (
		RoleId int,
		UserId int,
		CreatedDate datetime2(7),
		UpdatedDate datetime2(7)
	)

	SELECT @JSON = BulkColumn
	FROM OPENROWSET (
		BULK 'C:\Users\MFGGL\source\repos\mfgglr\TakasEt\Iss_Api\bin\Debug\net7.0\data\jsons\userImages.json',
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
		[UpdatedDate],
		[RemovedDate],
		[IsRemoved],
		[Height],
		[Width],
		[AspectRatio]
	)
	SELECT * from OPENJSON (@JSON) with (
		Id int,
		UserId int,
		BlobName nvarchar(max),
		ContainerName nvarchar(max),
		Extention nvarchar(max),
		IsActive bit,
		CreatedDate datetime2(7),
		UpdatedDate datetime2(7),
		RemovedDate datetime2(7),
		IsRemoved bit,
		Height int,
		Width int,
		AspectRatio real
	)
	SET IDENTITY_INSERT  [TakasEt].[dbo].[userImage] OFF;

	SELECT @JSON = BulkColumn
	FROM OPENROWSET (
		BULK 'C:\Users\MFGGL\source\repos\mfgglr\TakasEt\Iss_Api\bin\Debug\net7.0\data\jsons\followings.json',
		SINGLE_CLOB
	) as j
	insert into [TakasEt].[dbo].[Following] (
		[FollowerId],
		[FollowingId],
		[CreatedDate],
		[UpdatedDate]
	)
	SELECT * from OPENJSON (@JSON) with (
		FollowerId int,
		FollowingId int,
		CreatedDate datetime2(7),
		UpdatedDate datetime2(7)
	)

	SELECT @JSON = BulkColumn
	FROM OPENROWSET (
		BULK 'C:\Users\MFGGL\source\repos\mfgglr\TakasEt\Iss_Api\bin\Debug\net7.0\data\jsons\categories.json',
		SINGLE_CLOB
	) as j
	SET IDENTITY_INSERT  [TakasEt].[dbo].[Category] ON;
	insert into [TakasEt].[dbo].[Category] (
		[Id],
		[Name],
		[NormalizedName],
		[CreatedDate],
		[UpdatedDate],
		[RemovedDate],
		[IsRemoved]
	)
	SELECT * from OPENJSON (@JSON) with (
		Id int,
		[Name] nvarchar(max),
		NormalizedName nvarchar(max),
		CreatedDate datetime2(7),
		UpdatedDate datetime2(7),
		RemovedDate datetime2(7),
		IsRemoved bit
	)
	SET IDENTITY_INSERT  [TakasEt].[dbo].[Category] OFF;

	SELECT @JSON = BulkColumn
	FROM OPENROWSET (
		BULK 'C:\Users\MFGGL\source\repos\mfgglr\TakasEt\Iss_Api\bin\Debug\net7.0\data\jsons\posts.json',
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
		[NumberOfImages], 
		[CreatedDate],
		[UpdatedDate],
		[RemovedDate],
		[IsRemoved]
	)
	SELECT * from OPENJSON (@JSON) with (
		Id int,
		UserId int,
		CategoryId int,
		Title varchar(256),
		NormalizedTitle varchar(256),
		Content nvarchar(max),
		NumberOfImages int,
		CreatedDate datetime2(7),
		UpdatedDate datetime2(7),
		RemovedDate datetime2(7),
		IsRemoved bit
	)
	SET IDENTITY_INSERT  [TakasEt].[dbo].[Post] OFF;

	SELECT @JSON = BulkColumn
	FROM OPENROWSET (
		BULK 'C:\Users\MFGGL\source\repos\mfgglr\TakasEt\Iss_Api\bin\Debug\net7.0\data\jsons\postImages.json',
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
		[UpdatedDate],
		[RemovedDate],
		[IsRemoved],
		[Height],
		[Width],
		[AspectRatio]
	)
	SELECT * from OPENJSON (@JSON) with (
		Id int,
		BlobName nvarchar(max),
		ContainerName nvarchar(max),
		Extention nvarchar(max),
		PostId int,
		[Index] int,
		CreatedDate datetime2(7),
		UpdatedDate datetime2(7),
		RemovedDate datetime2(7),
		IsRemoved bit,
		Height int,
		Width int,
		AspectRatio real
	)
	SET IDENTITY_INSERT  [TakasEt].[dbo].[PostImage] OFF;
