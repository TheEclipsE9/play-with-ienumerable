// See https://aka.ms/new-console-template for more information

int enterCount = 0;

Console.WriteLine("Hello, World!");

IEnumerable<User> users = GetUsers();

foreach (var user in users)
{
	System.Console.WriteLine($"{user.Id} {user.Name}");
}

System.Console.WriteLine($"Users count: {users.Count()}");

System.Console.WriteLine($"Enter count: {enterCount}");

IEnumerable<User> GetUsers()
{
	enterCount++;
	var lines = File.ReadAllLines("../DataSource.csv");
	
	foreach	(var line in lines)
	{
		var splited = line.Split(';');
		
		yield return new User(Int32.Parse(splited[0]), splited[1]);
	}
}

public record User(int Id, string Name);