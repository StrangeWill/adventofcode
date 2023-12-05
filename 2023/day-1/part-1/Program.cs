var input = await File.ReadAllLinesAsync("../input.txt");
var sum = input
    .Select(line =>
    {
        var numbers = line
            .Where(c => int.TryParse(c.ToString(), out var _))
            .Select(c =>
            {
                int.TryParse(c.ToString(), out var num);
                return num;
            });
        return $"{numbers.First()}{numbers.Last()}";
    })
    .Sum(int.Parse);
Console.WriteLine(sum);