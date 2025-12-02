namespace AdventOfCode2025.Calendar.D01
{
    internal class Part1 : Part
    {
        public override async Task<string> GetResultAsync(string inputFile)
        {
            var input = (await ReadFileLinesAsync(inputFile))
                .Select(x =>
                {
                    var value = int.Parse(x[1..]);
                    return x[0] == 'L' ? -value : value;
                });
            int currentVal = 50;
            int result = 0;
            foreach (var v in input)
            {
                currentVal += v;
                while (currentVal < 0) currentVal += 100;
                while (currentVal > 99) currentVal -= 100;
                if (currentVal == 0) result++;
            }
            return result.ToString();
        }
    }
}
