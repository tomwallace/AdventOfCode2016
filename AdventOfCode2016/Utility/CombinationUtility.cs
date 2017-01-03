using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2016
{
    public static class CombinationUtility
    {
        public static IEnumerable<IEnumerable<T>> GetAllPermutationsToLength<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetAllPermutationsToLength(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        public static IEnumerable<Tuple<T, T>> GetAllPermutationPairsOrderDoesNotMatter<T>(IEnumerable<T> list)
        {
            var combinations = from pair in list.Select((value, index) => new { value, index })
                               from second in list.Skip(pair.index + 1)
                               select Tuple.Create(pair.value, second);

            return combinations;
        }
    }
}