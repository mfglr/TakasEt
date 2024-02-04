
string getGroupName( Guid senderId,Guid receiverId)
{
	return string.Join(
		"_",
		new List<string> {
					senderId.ToString(),
					receiverId.ToString()
		}
		.OrderBy(x => x)
	);

}

var a = Guid.NewGuid();
var b = Guid.NewGuid();

Console.WriteLine(getGroupName(a, b));
Console.WriteLine(getGroupName(b,a));