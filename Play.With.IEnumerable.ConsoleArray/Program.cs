// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

IEnumerable<int> src = GetSrc();

Console.WriteLine($"1st call on array count {src.CustomCountForInt()}"); 
Console.WriteLine($"2st call on array count {src.CustomCountForInt()}"); 

Console.WriteLine($"TimesAskedForEnumerator: {CustomIEnumerableExtensions.TimesAskedForEnumerator}");

IEnumerable<int> GetSrc()
{
    return new int[] { 1, 2, 3 }; //0;
    //return new List<int>() { 1, 2, 3 }; //0
    //return Enumerable.Range(1, 3); //2
    //return Enumerable.Range(1, 3).ToList(); //0
}

public static class CustomIEnumerableExtensions
{
    public static int TimesAskedForEnumerator = 0;

    public static int CustomCountForInt<T>(this IEnumerable<T> source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (source is ICollection<int> array)
        {
            return array.Count;
        }

        int count = 0;
        TimesAskedForEnumerator++;
        using (IEnumerator<T> enumerator = source.GetEnumerator())
        {
            checked
            {
                while (enumerator.MoveNext())
                {
                    count++;
                }
            }
        }

        return count;
    }
}
