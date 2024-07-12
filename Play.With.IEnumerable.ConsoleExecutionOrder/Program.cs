// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var src = Get();

var where = src.Where(x =>
{
    Console.WriteLine($"Where for {x}");
    return true;
});

var select = where.Select(x =>
{
    Console.WriteLine($"Select for {x}");
    return x;
});

Console.WriteLine("\t List 1");
var list1 = select.ToList();

Console.WriteLine("\t List 2");
var list2 = select.ToList();

// So it just source generator
// every time make request
// it will again and again generate(iterate) from the start to the end

IEnumerable<int> Get()
{
    Console.WriteLine("Start");
    Console.WriteLine("yield 1");
    yield return 1;
    Console.WriteLine("yield 2");
    yield return 2;
    Console.WriteLine("End");
}