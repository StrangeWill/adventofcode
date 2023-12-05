using System.Text.Json;
using System.Text.Json.Serialization;

var input = await File.ReadAllLinesAsync("../input.txt");
var words = new Dictionary<string, int>()
{
    { "one", 1 },
    { "two", 2 },
    { "three", 3 },
    { "four", 4 },
    { "five", 5 },
    { "six", 6 },
    { "seven", 7 },
    { "eight", 8 },
    { "nine", 9 },
    { "zero", 0 }
};
var sum = input
    .Select(line =>
    {
        var lineNumbers = new List<int>();
        for (var i = 0; i < line.Length; i++)
        {
            var c = line[i];
            if (int.TryParse(c.ToString(), out var num))
            {
                lineNumbers.Add(num);
            }
            else
            {
                var number = words.Keys.ToList().Where(s => line.Length - i < s.Length ? false : s == line.Substring(i, s.Length)).FirstOrDefault();
                if (number != null)
                {
                    lineNumbers.Add(words[number]);
                }
            }

        }

        return $"{lineNumbers.First()}{lineNumbers.Last()}";
    })
    .Sum(int.Parse);
Console.WriteLine(sum);