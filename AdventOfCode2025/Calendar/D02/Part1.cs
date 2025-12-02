namespace AdventOfCode2025.Calendar.D02
{
    internal class Part1 : Part
    {
        public override async Task<string> GetResultAsync(string inputFile)// 8576933996
        {
            var input = (await ReadFileTextAsync(inputFile))
                .Split(',')
                .Select(x =>
                {
                    var values = x.Split('-');
                    if (values.Any(y => y.StartsWith('0')))
                        return (0, 0);

                    var startRange = long.Parse(values[0]);
                    var endRange = long.Parse(values[1]);
                    return (startRange, endRange);
                });

            var values = new List<long>();
            foreach (var v in input)
            {
                for (long i = v.startRange; i < v.endRange + 1; i++)
                {
                    var s = i.ToString();
                    if (s.Length % 2 != 0) continue;
                    var hl = s.Length / 2;
                    if (s[..hl] != s[hl..]) continue;
                    values.Add(long.Parse(s));
                }
            }
            return values.Sum().ToString();
        }
    }
}
