namespace SREmulator.Gacha
{
    public class GachaRandom : Random
    {
        public static new GachaRandom Shared { get; } = new();

        public T GetItem<T>(T[] choices)
        {
            return GetItem(new ReadOnlySpan<T>(choices));
        }
        public T GetItem<T>(ReadOnlySpan<T> choices)
        {
            return choices[Next(choices.Length)];
        }
        public T GetItem<T>((T Choice, double Weight)[] choices)
        {
            double sum = choices.Select(t => t.Weight).Sum();
            double roll = NextDouble() * sum;
            double acc = 0;
            foreach (var (choice, weight) in choices)
            {
                if (roll >= acc && roll < acc + weight)
                {
                    return choice;
                }
                acc += weight;
            }
            throw new ArgumentException(null, nameof(choices));
        }

        public bool NextBool()
        {
            return NextBool(1, 2);
        }
        public bool NextBool(int denominator)
        {
            return NextBool(1, denominator);
        }
        public bool NextBool(int numerator, int denominator)
        {
            return Next(denominator) < numerator;
        }

        public void Redistribute(int[] points)
        {
            int sum = points.Sum();
            Array.Clear(points);
            while (sum-- > 0)
            {
                points[Next(points.Length)]++;
            }
        }
    }
}
