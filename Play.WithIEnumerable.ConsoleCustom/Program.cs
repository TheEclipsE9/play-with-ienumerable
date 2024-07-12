// See https://aka.ms/new-console-template for more information
using System.Collections;
using static CSVReader;

Console.WriteLine("Hello, World!");

//var reader = new CSVReader("../DataSource.csv"); //created = 2
var reader = new CSVReader("../DataSource.csv").ToList();//created = 1

foreach (var line in reader)
{
	var splited = line.Split(';');
	Console.WriteLine($"{splited[0]} {splited[1]}");
}
Console.WriteLine($"Lines count: {reader.Count()}");

Console.WriteLine($"Enumerator times created: {CSVReaderEnumerator.TimesCreated}");

public class CSVReader : IEnumerable<string>
{
	private readonly string _filePath;

	public CSVReader(string filePath)
	{
		_filePath = filePath;
	}

	public IEnumerator<string> GetEnumerator()
	{
		return new CSVReaderEnumerator(_filePath);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
	public class CSVReaderEnumerator : IEnumerator<string>
	{
		private StreamReader _reader;
		private string _currentLine;
		private string _filePath;
		public static int TimesCreated = 0;
		
		public CSVReaderEnumerator(string filePath)
		{
			_filePath = filePath;
			_reader = new StreamReader(_filePath);
			TimesCreated++;
        }
		
		public string Current => _currentLine;

		object IEnumerator.Current => Current;

		public void Dispose()
		{
			if (_reader is null) return;
			
			_reader.Close();
			_reader = null;
		}

		public bool MoveNext()
		{
			if (_reader is null) return false;
			
			_currentLine = _reader.ReadLine();
			if (_currentLine is null)
			{
				Dispose();
				return false;
			}
			
			return true;
		}

		public void Reset()
		{
			Dispose();
			_reader = new StreamReader(_filePath);
		}
	}
}