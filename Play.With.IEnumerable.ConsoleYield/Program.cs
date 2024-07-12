// See https://aka.ms/new-console-template for more information
int EntryCount = 0;

Console.WriteLine("Hello, World!");

var src = Get(); //dont start execution
                 //-> it is just source
                 //-> deferred execution
Console.WriteLine($"EntryCount: {EntryCount}");//0

src.Count();
Console.WriteLine($"EntryCount: {EntryCount}");//1

IEnumerable<int> list = Get().ToList(); //start execution
                           //-> when want to get result atomic value or Array/List/Dictionary(create collection based on src)
                           //-> immediate execution
Console.WriteLine($"EntryCount: {EntryCount}");//2

list.Count();
Console.WriteLine($"EntryCount: {EntryCount}");//2

IEnumerable<int> Get()
{
    EntryCount++;
    Console.WriteLine("Start");
    Console.WriteLine("1");
    yield return 1;
    Console.WriteLine("2");
    yield return 2;
    Console.WriteLine("End");
}