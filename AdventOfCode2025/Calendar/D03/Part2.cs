namespace AdventOfCode2025.Calendar.D03
{
    internal class Part2 : Part
    {
        public override async Task<string> GetResultAsync(string inputFile)
        {
            var input = (await ReadFileLinesAsync(inputFile))
                .Select(x => x.Select(y => int.Parse(y.ToString())).ToList());

            List<long> result = [];
            foreach (var bank in input)
            {
                List<int> values = [];
                int lastIndex = -1;
                for (int i = 11; i >= 0; i--)
                {
                    var skip = lastIndex + 1;
                    var highestValue = bank.Skip(skip).Take(bank.Count - skip - i).Max();
                    lastIndex = bank.IndexOf(highestValue, lastIndex + 1);
                    values.Add(highestValue);
                }
                result.Add(long.Parse(string.Join("", values)));
            }

            return result.Sum().ToString();
        }
    }
}
