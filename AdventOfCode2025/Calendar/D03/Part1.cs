namespace AdventOfCode2025.Calendar.D03
{
    internal class Part1 : Part
    {
        public override async Task<string> GetResultAsync(string inputFile)
        {
            var input = (await ReadFileLinesAsync(inputFile))
                .Select(x => x.Select(y => int.Parse(y.ToString())).ToList());

            List<int> result = [];
            foreach (var bank in input)
            {
                var highestValue = bank.Take(bank.Count - 1).Max();
                var index = bank.IndexOf(highestValue);
                result.Add(int.Parse($"{highestValue}{bank.Skip(index+1).Max()}"));
            }

            return result.Sum().ToString();
        }
    }
}
