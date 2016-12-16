using System.Collections.Generic;

namespace AdventOfCode2016
{
    public class DayFifteen
    {
        public long MinimumTimeToGetThroughAllDiscs(List<KineticDisc> discs)
        {
            long time = 0;
            // Loop forever until we break out with an answer
            do
            {
                int fellThrough = 0;
                long localTimer = time;
                foreach (KineticDisc disc in discs)
                {
                    localTimer++;
                    if (disc.SlotAvailableAtTime(localTimer))
                        fellThrough++;
                    else
                        break; // Fail early
                }

                if (fellThrough == discs.Count)
                    return time;

                time++;
            } while (1 == 1);

            return 0;
        }
    }

    public class KineticDisc
    {
        public long Positions;
        public long StartPosition;

        public KineticDisc(long positions, long startPosition)
        {
            Positions = positions;
            StartPosition = startPosition;
        }

        public bool SlotAvailableAtTime(long time)
        {
            long remainder = time % Positions;
            long position = remainder + StartPosition;
            // Number of Positions is synonomous with 0
            return position == Positions || position == 0;
        }
    }
}