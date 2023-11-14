using Application.Extentions;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Test.cs.CreateDumyData
{
	public class Generator
	{

		private static string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
		private static string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
		private static bool[] boolValues = { true, false };
		private static string[] mailSufixes = { "@outlook.com", "@hotmail.com", "@gmail.com" };
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
		private string GenarateUserName(string name, string lastName, int id)
		{
			return $"{name}_{lastName}_user{id}";
		}

		private Object GenerateRandomUser(int id)
		{
			var name = GenerateRandomString();
			var lastName = GenerateRandomString();
			var userName = GenarateUserName(name, lastName, id);
			var email = GenarateRandomMail(userName);
			var normUserName = userName.CustomNormalize();
			var normEmail = email.CustomNormalize();
			var createdDate = GenerateRandomDateTime();

			return new
			{
				Name = name,
				LastName = lastName,
				DateOfBirth = GenerateRandomDateTime(),
				Gender = GenerateRandomBool(),
				CreatedDate = createdDate,
				UpdatedDate = createdDate,
				UserName = userName,
				NormalizedUserName = normUserName,
				Email = email,
				NormalizedEmail = normEmail,
				EmailConfirmed = false,
				PasswordHash = "AQAAAAIAAYagAAAAED6NMviLL2arHtiYhoWGr4sgZ8Fshn5Zle16j09bcR35MFXSGYpE0wskAKdEiV6LYw==",
				SecurityStamp = "MJ3TWU3F4CA3YUYFWTJMO3GXQUXGWT4F",
				ConcurrencyStamp = "605095b2-c70f-4f4d-b85c-b2adde79c0ec",
				PhoneNumberConfirmed = false,
				TwoFactorEnabled = false,
				LockoutEnd = DateTimeOffset.Now,
				LockoutEnabled = true,
				AccessFailedCount = 0,
				Roles = new[]
				{
					new {UserId = id, RoleId = 2,CreatedDate = createdDate}
				}
			};
		}
		private Object GenerateRandomPost(int userId, int categoryId)
		{
			Random random = new Random();
			return new
			{
				UserId = userId,
				CategoryId = categoryId,
				Title = GenerateRandomParagraph(random.Next(1, 6)) + $"\n***\ncategor id : {categoryId}\nuser id : {userId}",
				Content = GenerateRandomParagraph(random.Next(5,21)),
				CountOfImages = 0,
				CreatedDate = GenerateRandomDateTime()
			};
		}
		private Object GenerateRandomParentComment(int userId, int postId)
		{
			Random random = new Random();
			return new
			{
				PostId = postId,
				UserId = userId,
				Content = GenerateRandomParagraph(random.Next(1, 11)) + $"\n***\nuser id : {userId}\npost id : {postId}",
				CreatedDate = GenerateRandomDateTime()
			};
		}
		private Object GenerateRandomChildComment(int userId, int parentId)
		{
			Random random = new Random();
			return new
			{
				ParentId = parentId,
				UserId = userId,
				Content = GenerateRandomParagraph(random.Next(1, 11)) + $"\n***\nuser id : {userId}\nparent id : {parentId}",
				CreatedDate = GenerateRandomDateTime()
			};
		}
		private Object GenerateRandomUserUserFollowing(int followerId, int followedId)
		{
			Random random = new Random();
			return new
			{
				FollowerId = followerId,
				FollowedId = followedId,
				CreatedDate = GenerateRandomDateTime()
			};
		}

		public void GenerateUsers(int count)
		{
			string pathUsers = Directory.GetCurrentDirectory() + "/users";
			FileStream file = File.Create(pathUsers);
			byte[] bytes;
			for (int i = 0; i < count; i++)
			{
				bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(GenerateRandomUser(i)));
				file.Write(bytes, 0, bytes.Length);
				file.WriteByte(Convert.ToByte('\n'));
			}
			file.Close();
		}
		public void GeneratePosts(int count, int countOfUsers)
		{
			Random random = new Random();
			string pathOfPosts = Directory.GetCurrentDirectory() + "/posts";
			FileStream file = File.Create(pathOfPosts);
			byte[] bytes;
			for (int i = 0; i < count; i++)
			{
				var userId = random.Next(1, countOfUsers + 1);
				var ctegoryId = random.Next(1, 9);
				bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(GenerateRandomPost(userId, ctegoryId)));
				file.Write(bytes, 0, bytes.Length);
				file.WriteByte(Convert.ToByte('\n'));
			}
			file.Close();
		}
		public void GenerateParentComments(int count, int countOfUsers, int countOfPosts)
		{
			Random random = new Random();
			string parentComments = Directory.GetCurrentDirectory() + "/parentComments";
			FileStream file = File.Create(parentComments);
			byte[] bytes;
			for (int i = 0; i < count; i++)
			{
				var userId = random.Next(1, countOfUsers + 1);
				var postId = random.Next(1, countOfPosts + 1);
				bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(GenerateRandomParentComment(userId, postId)));
				file.Write(bytes, 0, bytes.Length);
				file.WriteByte(Convert.ToByte('\n'));
			}
			file.Close();
		}
		public void GenerateChildComments(int count, int countOfUsers, int countOfParents)
		{
			Random random = new Random();
			string path = Directory.GetCurrentDirectory() + "/childComments";
			FileStream file = File.Create(path);
			byte[] bytes;
			for (int i = 0; i < count; i++)
			{
				var userId = random.Next(1, countOfUsers + 1);
				var parentId = random.Next(1, countOfParents + 1);
				bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(GenerateRandomChildComment(userId, parentId)));
				file.Write(bytes, 0, bytes.Length);
				file.WriteByte(Convert.ToByte('\n'));
			}
			file.Close();
		}
		public void GenerateUserUserFollowings(int count,int countOfUsers)
		{
			MemoryStream stream = new MemoryStream();
			byte trigger = Convert.ToByte(1);
			Random random = new Random();
			string path = Directory.GetCurrentDirectory() + "/userUserFollowings";
			FileStream file = File.Create(path);
			byte[] bytes;
			long followerId, followedId;
			for (int i = 0; i < count; i++)
			{
				do
				{
					followerId = random.Next(1, countOfUsers + 1);
					followedId = random.Next(1, countOfUsers + 1);
					stream.Position = followerId * countOfUsers + followerId;
				} while (followerId == followedId && stream.ReadByte() != trigger);

				stream.Position = followerId * countOfUsers + followerId;
				stream.WriteByte(trigger);

				bytes = Encoding.ASCII.GetBytes(
					JsonConvert.SerializeObject(GenerateRandomUserUserFollowing((int)followerId,(int)followedId))
				);
				file.Write(bytes, 0, bytes.Length);
				file.WriteByte(Convert.ToByte('\n'));
			}
			file.Close();
		}
	}

}
