namespace AdventOfCode2025.Calendar.D01
{
    internal class Part2 : Part
    {
        public override async Task<string> GetResultAsync(string inputFile)// 7101
        {
            var input = (await ReadFileLinesAsync(inputFile))
                .Select(x =>
                {
                    var value = int.Parse(x[1..]);
                    return x[0] == 'L' ? -value : value;
                });

            List<IIndex> list = Enumerable.Range(0, 100)
                .Select(x => x == 0 ? (IIndex)new CountIndex() : new NonIndex())
                .ToList();

            int index = 50;
            foreach (var step in input)
            {
                for (int i = 0; i < Math.Abs(step); i++)
                {
                    index += step < 0 ? -1 : 1;
                    index = index switch
                    {
                        > 99 => 0,
                        < 0 => 99,
                        _ => index
                    };
                    list[index].Calculate();
                }
            }

            return (list[0] as CountIndex)!.Counter.ToString();
        }
        private interface IIndex
        {
            void Calculate();
        }
        private class NonIndex : IIndex
        {
            public void Calculate() { }
        }
        private class CountIndex : IIndex
        {
            public int Counter { get; private set; }
            public void Calculate() => Counter++;
        }
    }
}
