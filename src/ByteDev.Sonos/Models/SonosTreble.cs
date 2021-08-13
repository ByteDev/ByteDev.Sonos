using System;

namespace ByteDev.Sonos.Models
{
    public class SonosTreble
    {
        private const int DefaultTreble = 0;

        public static readonly int MinTreble = -10;
        public static readonly int MaxTreble = 10;
        
        public int Value { get; }

        public SonosTreble() : this(DefaultTreble)
        {
        }

        public SonosTreble(int value)
        {
            if (value < MinTreble || value > MaxTreble)
                throw new ArgumentOutOfRangeException(nameof(value), $"Treble value must be between {MinTreble} and {MaxTreble}.");

            Value = value;
        }
        
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}