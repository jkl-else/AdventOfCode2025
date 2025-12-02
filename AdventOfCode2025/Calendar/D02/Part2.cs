namespace AdventOfCode2025.Calendar.D02
{
    internal class Part2 : Part
    {
        public override async Task<string> GetResultAsync(string inputFile)// 25663320831
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

            List<long> values = new ();
            foreach (var v in input)
            {
                for (long i = v.startRange; i < v.endRange + 1; i++)
                {
                    var s = i.ToString();
                    if (!Repeating(s)) continue;
                    values.Add(long.Parse(s));
                }
            }
            return values.Sum().ToString();

            bool Repeating(string s)
            {
                int len = s.Length;
                for (int seqLen = 1; seqLen <= len / 2; seqLen++) // can't repeat if more than half length
                {
                    if (len % seqLen != 0) continue; // not equal parts
                    string seq = s[..seqLen]; // first part
                    bool repeating = true;
                    for (int i = seqLen; i < len; i += seqLen)
                    {
                        if (s.Substring(i, seqLen) == seq) continue; // matches
                        repeating = false;
                        break;
                    }
                    if (repeating) return true; // repeating
                }
                return false;
            }
        }
    }
}
