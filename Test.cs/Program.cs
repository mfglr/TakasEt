


using Newtonsoft.Json;


var a = new Person { Name = "ali", LastName = "guler" };
var text = JsonConvert.SerializeObject(a);

var obje = JsonConvert.DeserializeObject(text);

var person = (Person)obje;

Console.WriteLine(person.Name);


class Person
{
    public string Name { get; set; }
    public string LastName { get; set; }
}