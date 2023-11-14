using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using Test.cs.CreateDumyData;

Generator generator = new Generator();
Importer importer = new Importer();

var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyBlogDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

var context = new AppDbContext(optionsBuilder.Options);

generator.GenerateUsers(1000);
await importer.importFile<User>(Directory.GetCurrentDirectory() + "/users", context);

generator.GeneratePosts(10000,1000);
await importer.importFile<Post>(Directory.GetCurrentDirectory() + "/posts", context);

generator.GenerateUserUserFollowings(10000, 1000);
await importer.importFile<UserUserFollowing>(Directory.GetCurrentDirectory() + "/userUserFollowings",context);



