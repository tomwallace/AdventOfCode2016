namespace AdventOfCode2016
{
    public class DayNineteen
    {
        public static int PUZZLE_INPUT = 3012210;

        public int GetPositionWithAllTheGifts(int numberOfElves)
        {
            WhiteElephantElf firstElf = new WhiteElephantElf(1, 1, null, null);
            WhiteElephantElf elf = firstElf;
            WhiteElephantElf floatingTarget = null;

            // Build the ring
            for (int i = 2; i <= numberOfElves; i++)
            {
                WhiteElephantElf nextElf = new WhiteElephantElf(1, i, null, elf);
                elf.Next = nextElf;
                elf = nextElf;
            }
            // Complete last connection
            elf.Next = firstElf;
            firstElf.Previous = elf;

            floatingTarget = firstElf.Next;

            // Begin process of stealing
            WhiteElephantElf activeElf = firstElf;
            while (activeElf.Next != activeElf)
            {
                activeElf.Gifts += floatingTarget.Gifts;

                // Removes the target from circle
                floatingTarget.Gifts = 0;
                floatingTarget.Previous.Next = floatingTarget.Next;
                floatingTarget.Next.Previous = floatingTarget.Previous;

                // Determine new target
                floatingTarget = floatingTarget.Next.Next;

                // Now move to elf on left
                activeElf = activeElf.Next;
            }

            return activeElf.Position;
        }

        public int AcrossGetPositionWithAllTheGifts(int numberOfElves)
        {
            WhiteElephantElf firstElf = new WhiteElephantElf(1, 1, null, null);
            WhiteElephantElf elf = firstElf;
            WhiteElephantElf floatingTarget = null;

            int floatingTargetIndex = PositionAcrossCircle(numberOfElves, 1);

            // Build the ring
            for (int i = 2; i <= numberOfElves; i++)
            {
                WhiteElephantElf nextElf = new WhiteElephantElf(1, i, null, elf);
                elf.Next = nextElf;
                elf = nextElf;

                // Halfway across, get our target
                if (i == floatingTargetIndex)
                    floatingTarget = elf;
            }
            // Complete last connection
            elf.Next = firstElf;
            firstElf.Previous = elf;

            // Begin process of stealing
            int count = numberOfElves;
            WhiteElephantElf activeElf = firstElf;
            while (activeElf.Next != activeElf)
            {
                activeElf.Gifts += floatingTarget.Gifts;

                // Removes the target from circle
                floatingTarget.Gifts = 0;
                floatingTarget.Previous.Next = floatingTarget.Next;
                floatingTarget.Next.Previous = floatingTarget.Previous;

                // Determine new target
                if (count % 2 == 1)
                {
                    // If odd, then go forward 2
                    floatingTarget = floatingTarget.Next.Next;
                }
                else
                {
                    // If even, only go forward 1
                    floatingTarget = floatingTarget.Next;
                }

                // Now move to elf on left
                activeElf = activeElf.Next;

                count--;
            }

            return activeElf.Position;
        }

        public int PositionAcrossCircle(int numberInCircle, int currentPosition)
        {
            int half = numberInCircle / 2;
            int summed = half + currentPosition;
            if (summed > numberInCircle)
            {
                return summed - numberInCircle;
            }
            return summed;
        }
    }

    public class WhiteElephantElf
    {
        public WhiteElephantElf Next;
        public WhiteElephantElf Previous;
        public int Gifts;
        public int Position;

        public WhiteElephantElf(int gifts, int position, WhiteElephantElf next, WhiteElephantElf previous)
        {
            Gifts = gifts;
            Position = position;
            Next = next;
            Previous = previous;
        }
    }
}