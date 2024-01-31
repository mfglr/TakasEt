using Models.Extentions;
using Models.Extentions;
using Newtonsoft.Json;
using System.Drawing;
using System.Reflection;
using System.Text;
using WebApi.Controllers;

namespace Test.cs.CreateDumyData
{
	public class Generator
	{

		private static string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
		private static string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
		private static bool[] boolValues = { true, false };
		private static string[] mailSufixes = { "@outlook.com", "@hotmail.com", "@gmail.com" };


		private List<int>[] followers;
		private List<int>[] followeds;
		
		private FileStream usersFile;
		private FileStream userImagesFile;
		private FileStream postsFile;
		private FileStream postImagesFile;
		private FileStream commentsFile;
		private FileStream followingsFile;
		private FileStream userRolesFile;

		private int numberOfUser;
		private int maxNumberOfFollowers;
		private int maxNumberOfFolloweds;
		private int maxNumberOfPosts;
		private int maxNumberOfPostImages;
		private int maxNumberOfParentComments;
		private int maxNumberOfChildComments;

		private int userId = 1;
		private int userImageId = 1;
		private int postId = 1;
		private int postImageId = 1;
		private int commentId = 1;
		private int followingId = 1;
		private int userRoleId = 1;

		private string GenerateRandomPhone()
		{
			var random = new Random();
			string r = "";
			for (int i = 0; i < 10; i++)
				r += random.Next(10);
			return r;
		}
		private bool GenerateRandomBool()
		{
			Random random = new Random();
			return boolValues[random.Next(2)];
		}
		private string GenerateRandomString()
		{
			Random r = new Random();
			int len = r.Next(2, 7);
			string str = "";
			for (int i = 0; i < len; i++)
			{
				str += consonants[r.Next(consonants.Length)];
				str += vowels[r.Next(vowels.Length)];
			}
			return str;
		}
		private string GenerateRandomParagraph(int countOfWord)
		{
			string paragraph = "";
			for (int i = 0; i < countOfWord; i++)
			{
				paragraph += GenerateRandomString();
				paragraph += " ";
			}
			return paragraph;
		}
		private DateTime? GenerateRandomDateTime()
		{
			Random random = new Random();
			return new DateTime(
				random.Next(1970, 2022),
				random.Next(1, 13),
				random.Next(1, 28),
				random.Next(0, 24),
				random.Next(0, 60),
				random.Next(0, 60),
				random.Next(0, 1000)
			);
		}
		private string GenarateRandomMail(string userName)
		{
			Random random = new Random();
			return $"{userName}{mailSufixes[random.Next(3)]}";
		}
		private void GenerateRandomImage(string target, string destination, int id)
		{
			Bitmap bitmap = new Bitmap(Image.FromFile(target));
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				using (Font arialFont = new Font("Arial", 50))
				{
					var size = graphics.MeasureString($"{id}", arialFont);
					var x = (bitmap.Width - size.Width) / 2;
					var y = (bitmap.Height - size.Height) / 2;
					graphics.DrawString(id + "", arialFont, Brushes.Blue, new PointF(x, y));
				}
			}
			bitmap.Save(destination);
			bitmap.Dispose();
		}
		private string GenarateUserName(string name, string lastName, int id)
		{
			return $"{name}_{lastName}_user{id}";
		}

		private void initializeJsonFile(FileStream file)
		{
			file.WriteByte(Convert.ToByte('['));
			file.WriteByte(Convert.ToByte('\n'));
			file.WriteByte(Convert.ToByte('\t'));
		}
		private void separateJsonObject(FileStream file)
		{
			file.WriteByte(Convert.ToByte(','));
			file.WriteByte(Convert.ToByte('\n'));
			file.WriteByte(Convert.ToByte('\t'));
		}
		private void finalizeJsonFile(FileStream file)
		{
			file.Position = file.Position - 3;
			file.WriteByte(Convert.ToByte('\n'));
			file.WriteByte(Convert.ToByte(']'));
		}

		public Generator(
			int numberOfUser,
			int maxNumberOfFollowers,
			int maxNumberOfFolloweds,
			int maxNumberOfPosts,
			int maxNumberOfPostImages,
			int maxNumberOfParentComments,
			int maxNumberOfChildComments
		)
		{

			this.numberOfUser = numberOfUser;
			this.maxNumberOfFollowers = maxNumberOfFollowers;
			this.maxNumberOfFolloweds = maxNumberOfFolloweds;
			this.maxNumberOfPosts = maxNumberOfPosts;
			this.maxNumberOfPostImages = maxNumberOfPostImages;
			this.maxNumberOfParentComments = maxNumberOfParentComments;
			this.maxNumberOfChildComments = maxNumberOfChildComments;

			followers = new List<int>[numberOfUser];
			followeds = new List<int>[numberOfUser];
			for(int i = 0; i < numberOfUser; i++)
			{
				followers[i] = new();
				followeds[i] = new();
			}
		}

		public void Open()
		{
			usersFile = File.Create(Directory.GetCurrentDirectory() + "/data/users.json");
			userImagesFile = File.Create(Directory.GetCurrentDirectory() + "/data/userImages.json");
			postsFile = File.Create(Directory.GetCurrentDirectory() + "/data/posts.json");
			postImagesFile = File.Create(Directory.GetCurrentDirectory() + "/data/postImages.json");
			commentsFile = File.Create(Directory.GetCurrentDirectory() + "/data/comments.json");
			followingsFile = File.Create(Directory.GetCurrentDirectory() + "/data/followings.json");
			userRolesFile = File.Create(Directory.GetCurrentDirectory() + "/data/userRoles.json");
		}
		public void Close()
		{
			usersFile.Close();
			userImagesFile.Close();
			postsFile.Close();
			postImagesFile.Close();
			commentsFile.Close();
			followingsFile.Close();
			userRolesFile.Close();
		}

		private void WriteRandomUser(int numberOfPost)
		{
			var name = GenerateRandomString();
			var lastName = GenerateRandomString();
			var userName = GenarateUserName(name, lastName, userId);
			var email = GenarateRandomMail(userName);
			var createdDate = GenerateRandomDateTime();

			var user = new
			{
				Id = userId,
				Name = name,
				LastName = lastName,
				NormalizedFullName = $"{name} {lastName}".CustomNormalize(),
				DateOfBirth = GenerateRandomDateTime(),
				Gender = GenerateRandomBool(),
				CreatedDate = createdDate,
				UpdatedDate = createdDate,
				UserName = userName,
				NormalizedUserName = userName.CustomNormalize(),
				Email = email,
				NormalizedEmail = email.CustomNormalize(),
				EmailConfirmed = false,
				PasswordHash = "AQAAAAIAAYagAAAAED6NMviLL2arHtiYhoWGr4sgZ8Fshn5Zle16j09bcR35MFXSGYpE0wskAKdEiV6LYw==",
				SecurityStamp = "MJ3TWU3F4CA3YUYFWTJMO3GXQUXGWT4F",
				ConcurrencyStamp = "605095b2-c70f-4f4d-b85c-b2adde79c0ec",
				PhoneNumber = GenerateRandomPhone(),
				PhoneNumberConfirmed = false,
				TwoFactorEnabled = false,
				LockoutEnd = DateTimeOffset.Now,
				LockoutEnabled = true,
				AccessFailedCount = 0,
				CountOfPost = numberOfPost
			};

			var bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(user));
			usersFile.Write(bytes, 0, bytes.Length);
		}
		private void WriteRandomUserImage() {
			string cDirectory = Directory.GetCurrentDirectory();
			string blobName = $"{userId}_{userImageId}.jpg";
			GenerateRandomImage($"{cDirectory}/images/p.jpg",$"{cDirectory}/user-image/{blobName}",userImageId);
			var userImage = new {
				Id = userImageId,
				IsActive = true,
				UserId = userId,
				BlobName = blobName,
				ContainerName = "user-image",
				Extention = "jpg",
				CreatedDate = GenerateRandomDateTime()
			};
			var bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(userImage));
			userImagesFile.Write(bytes, 0, bytes.Length);
		}
		private void WriteRandomUserRole()
		{
			var userRole = new
			{
				Id = userRoleId,
				UserId = userId,
				RoleId = 2,
				CreatedDate = GenerateRandomDateTime()
			};
			var bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(userRole));
			userRolesFile.Write(bytes, 0, bytes.Length);
		}
		private void WriteRandomPost(int numberOfPostImages)
		{
			Random random = new Random();
			string title = GenerateRandomParagraph(random.Next(1, 6));
			int categoryId = random.Next(1, 9);
			var post = new
			{
				Id = postId,
				UserId = userId,
				CategoryId = categoryId,
				Title = title,
				NormalizedTitle = title.CustomNormalize(),
				Content = GenerateRandomParagraph(random.Next(5, 21)),
				CountOfImages = numberOfPostImages,
				CreatedDate = GenerateRandomDateTime(),
			};

			var bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(post));
			postsFile.Write(bytes, 0, bytes.Length);
		}
		private void WriteRandomPostImage(int index)
		{
			string cDirectory = Directory.GetCurrentDirectory();
			string blobName = $"{postId}_{postImageId}.jpg";
			GenerateRandomImage($"{cDirectory}/images/a.jpg", $"{cDirectory}/post-image/{blobName}",postImageId);
			var postImage = new
			{
				Id = postImageId,
				PostId = postId,
				Index = index,
				BlobName = blobName,
				ContainerName = "post-image",
				Extention = "jpg",
				CreatedDate = GenerateRandomDateTime()
			};

			var bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(postImage));
			postImagesFile.Write(bytes, 0, bytes.Length);
		}
		private void WriteRandomFollower(int followedId)
		{
			Random r = new Random();
			int followerId;
			bool control;

			do
			{
				control = false;
				followerId = r.Next(1, numberOfUser + 1);
				foreach (var item in followers[followedId - 1])
					if (item == followerId)
					{
						control = true;
						break;
					}
			} while (control);

			followers[followedId - 1].Add(followerId);
			var following = new
			{
				Id = followingId,
				FollowerId = followerId,
				FollowedId = followedId,
				CreatedDate = GenerateRandomDateTime()
			};

			var bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(following));
			followingsFile.Write(bytes, 0, bytes.Length);

		}
		private void WriteRandomFollowed(int followerId)
		{
			Random r = new Random();
			int followedId;
			bool control;

			do
			{
				control = false;
				followedId = r.Next(1, numberOfUser + 1);
				foreach (var item in followeds[followerId - 1])
					if (item == followedId)
					{
						control = true;
						break;
					}
			} while (control);

			followeds[followerId - 1].Add(followedId);

			var following = new
			{
				Id = followingId,
				FollowerId = followerId,
				FollowedId = followedId,
				CreatedDate = GenerateRandomDateTime()
			};

			var bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(following));
			followingsFile.Write(bytes, 0, bytes.Length);

		}
		private void WriteRandomComment(int userId, int? postId,int? parentId)
		{
			Random random = new Random();
			var comment = new
			{
				Id = commentId,
				UserId = userId,
				PostId = postId,
				ParentId = parentId,
				Content = GenerateRandomParagraph(random.Next(1, 11)),
				CreatedDate = GenerateRandomDateTime()
			};

			var bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(comment));
			commentsFile.Write(bytes, 0, bytes.Length);
		}
		private void WriteRandomProfile()
		{
			Random r = new Random();

			int numberOfPosts = r.Next(11);
			int numberOfFolowers = r.Next(maxNumberOfFollowers + 1);
			int numberOfFolloweds = r.Next(maxNumberOfFolloweds + 1);
			int numberOfPostImages;
			int numberOfParentComments;
			int numberOfChildComments;
			int parentCommentId;

			//create a user
			WriteRandomUser(numberOfPosts);
			separateJsonObject(usersFile);
			
			//create profile image of the user
			WriteRandomUserImage();
			separateJsonObject(userImagesFile);
			userImageId++;

			//create role of the user
			WriteRandomUserRole();
			separateJsonObject(userRolesFile);
			userRoleId++;

			//create followers of the user
			for (int i = 0; i < numberOfFolowers; i++)
			{
				WriteRandomFollower(userId);
				separateJsonObject(followingsFile);
				followingId++;
			}
			//create followeds of the user
			for (int i = 0; i < numberOfFolloweds; i++)
			{
				WriteRandomFollowed(userId);
				separateJsonObject(followingsFile);
				followingId++;
			}

			//create posts of the user
			for (int i = 0; i < numberOfPosts; i++)
			{
				
				numberOfPostImages = r.Next(1, maxNumberOfPostImages + 1);
				numberOfParentComments = r.Next(maxNumberOfParentComments + 1);

				WriteRandomPost(numberOfPostImages);
				separateJsonObject(postsFile);
				
				//create images of the post
				for(int j = 0; j < numberOfPostImages; j++)
				{
					WriteRandomPostImage(j);
					separateJsonObject(postImagesFile);
					postImageId++;
				}

				//create comments of the post
				for(int j = 0;j < numberOfParentComments; j++)
				{
					WriteRandomComment(userId, postId, null);
					separateJsonObject(commentsFile);
					commentId++;

					parentCommentId = commentId - 1;
					numberOfChildComments = r.Next(maxNumberOfChildComments + 1);
					for(int k = 0; k < numberOfChildComments; k++)
					{
						WriteRandomComment(userId, null, parentCommentId);
						separateJsonObject(commentsFile);
						commentId++;
					}
				}
				postId++;
			}
			userId++;
		}

		public void GenerateJsonFiles()
		{
			Random r = new Random();

			initializeJsonFile(usersFile);
			initializeJsonFile(userImagesFile);
			initializeJsonFile(postsFile);
			initializeJsonFile(postImagesFile);
			initializeJsonFile(commentsFile);
			initializeJsonFile(followingsFile);
			initializeJsonFile(userRolesFile);

			for (int i = 0; i < numberOfUser; i++)
				WriteRandomProfile();

			finalizeJsonFile(usersFile);
			finalizeJsonFile(userImagesFile);
			finalizeJsonFile(postsFile);
			finalizeJsonFile(postImagesFile);
			finalizeJsonFile(commentsFile);
			finalizeJsonFile(followingsFile);
			finalizeJsonFile(userRolesFile);
		}
	
	}

}
