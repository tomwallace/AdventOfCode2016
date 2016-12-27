using System.Collections.Generic;

namespace AdventOfCode2016
{
    public class MazeStep
    {
        public Coordinate Coord;
        public int Step;
        public List<Coordinate> PreviousCoords;

        public MazeStep(Coordinate coord, int step, List<Coordinate> previousCoords)
        {
            Coord = coord;
            Step = step;
            PreviousCoords = previousCoords;
        }

        public bool ReachedDesintation(Coordinate targetCoord)
        {
            return (Coord.X == targetCoord.X && Coord.Y == targetCoord.Y);
        }

        public bool HaveAlreadyBeenToCoordinate(Coordinate coord)
        {
            Coordinate match = PreviousCoords.Find(p => p.X == coord.X && p.Y == coord.Y);
            return match != null;
        }

        public List<Coordinate> ClonePreviousCoords()
        {
            List<Coordinate> newList = new List<Coordinate>();
            foreach (Coordinate coord in PreviousCoords)
            {
                newList.Add(coord);
            }
            return newList;
        }
    }
}