namespace AdventOfCode2025.Calendar.D04
{
    internal class Part1 : Part
    {
        private class Coordinate(bool value, int x, int y)
        {
            public bool Value { get; } = value;
            public int X { get; } = x;
            public int Y { get; } = y;
            public bool Moved { get; set; }
        }
        public override async Task<string> GetResultAsync(string inputFile) // 1523
        {
            var input = (await ReadFileLinesAsync(inputFile))
                .SelectMany((y, yi) => y.Select((x, xi) => new Coordinate(x == '@', xi, yi)))
                .ToDictionary(c => (c.X, c.Y));
            var adjacentOffsets = new (int dx, int dy)[]
            {
                (1, 0), (1, 1), (0, 1), (-1, 1),
                (-1, 0), (-1, -1), (0, -1), (1, -1)
            };
            foreach (var c in input.Values.Where(x => x.Value))
            {
                var adjacent = adjacentOffsets
                    .Select(offset => input.GetValueOrDefault((c.X + offset.dx, c.Y + offset.dy)));
                if (adjacent.Count(x => x?.Value == true) < 4)
                    c.Moved = true;
            }
            return input.Values.Count(x => x.Moved).ToString();
        }
    }
}
