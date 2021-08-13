using System;

namespace ByteDev.Sonos.Models
{
    public class SonosBass
    {
        private const int DefaultBass = 0;

        public static readonly int MinBass = -10;
        public static readonly int MaxBass = 10;
        
        public int Value { get; }

        public SonosBass() : this(DefaultBass)
        {
        }

        public SonosBass(int value)
        {
            if (value < MinBass || value > MaxBass)
                throw new ArgumentOutOfRangeException(nameof(value), $"Bass value must be between {MinBass} and {MaxBass}.");

            Value = value;
        }
        
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}