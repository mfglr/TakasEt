using Test.cs.CreateDumyData;

Generator generator = new Generator(100,10,10,10,5,10,5);
generator.Open();
generator.GenerateJsonFiles();
generator.Close();
