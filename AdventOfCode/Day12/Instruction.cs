namespace AdventOfCode.Day12
{
    class Instruction
    {
        public Direction Direction { get; set; }
        public int Distance { get; set; }

        public Instruction(string input)
        {
            var directionString = input.Substring(0, 1);
            Direction = GetDirection(directionString);
            Distance = int.Parse(input.Substring(1));
        }

        public Instruction(Direction direction, int distance)
        {
            Direction = direction;
            Distance = distance;
        }

        private Direction GetDirection(string input)
        {
            return input switch
            {
                "E" => Direction.East,
                "N" => Direction.North,
                "S" => Direction.South,
                "W" => Direction.West,
                "L" => Direction.Left,
                "R" => Direction.Right,
                "F" => Direction.Forward,
                _ => default,
            };
        }
    }
}
