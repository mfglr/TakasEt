using Application.Entities;
using Application.Extentions;
using Newtonsoft.Json;
using System.Text;

namespace Test.cs.CreateDumyData
{
	public class Generator
	{

		private static string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
		private static string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
		private static bool[] boolValues = { true, false };
		private static string[] mailSufixes = { "@outlook.com", "@hotmail.com", "@gmail.com" };
		private static Guid categoryId = Guid.Parse("e17dac4e-3930-457e-858b-96de54391aec");
		
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
			for (int i = 0; i < len;i++)
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
		private string GenarateUserName(string name, string lastName, int index)
		{
			return $"{name}_{lastName}_user{index}";
		}

		public Object GenerateRandomUser(int index,int countOfPosts)
		{
			var userId = Guid.NewGuid();
			var name = GenerateRandomString();
			var lastName = GenerateRandomString();
			var userName = GenarateUserName(name, lastName, index);
			var email = GenarateRandomMail(userName);
			var normUserName = userName.CustomNormalize();
			var normEmail = email.CustomNormalize();
			var createdDate = GenerateRandomDateTime();

			return new
			{
				NormalizedUserName = normUserName,
				NormalizedEmail = normEmail,
				PasswordHash = "AQAAAAIAAYagAAAAED6NMviLL2arHtiYhoWGr4sgZ8Fshn5Zle16j09bcR35MFXSGYpE0wskAKdEiV6LYw==",
				EmailConfirmed = false,
				PhoneNumberConfirmed = false,
				TwoFactorEnabled = false,
				AccessFailedCount = 0,
				LockoutEnabled = true,
				SecurityStamp = "MJ3TWU3F4CA3YUYFWTJMO3GXQUXGWT4F",
				ConcurrencyStamp = "605095b2-c70f-4f4d-b85c-b2adde79c0ec",
				CreatedDate = createdDate,
				Id = userId,
				Email = email,
				UserName = userName,
				Gender = GenerateRandomBool(),
				Name = name,
				LastName = lastName,
				DateOfBirth = GenerateRandomDateTime(),
				Roles = new[] { 
					new {
						Id = Guid.NewGuid(),
						UserId = userId,
						RoleId = Guid.Parse("4dec4e47-9808-4fea-b6e9-a54b2da571cf"),
						CreatedDate = createdDate,
					}
				},
				Posts = GenerateRandomPosts(userId,countOfPosts)
			};
		}

		public Object[] GenerateRandomPosts(Guid userId,int countOfPosts)
		{
			Object[] posts = new Object[countOfPosts];
			for (int i = 0; i < countOfPosts; i++)
				posts[i] = GenerateRandomPost(userId);
			return posts;
		}

		public Object GenerateRandomPost(Guid userId)
		{
			return new
			{
				Id = Guid.NewGuid(),
				CreatedDate = GenerateRandomDateTime(),
				UserId = userId,
				CategoryId = categoryId,
				Title = GenerateRandomParagraph(5),
				Content = GenerateRandomParagraph(20),
				CountOfImages = 0,
			};
		}

		public void GenerateJsonFile(int count)
		{
			//string pathUsers = Directory.GetCurrentDirectory() + "/usersJsonFile.json";
			//FileStream file = File.Create(pathUsers);
			//byte[] bytes;
			//for (int i = 0; i < count; i++) {
			//	bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(GenerateRandomUser(i)));
			//	file.Write(bytes, 0, bytes.Length);
			//	file.WriteByte(Convert.ToByte('\n'));
			//}
			//file.Close();
		}


	}
}
