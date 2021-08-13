using System;

namespace ByteDev.Sonos.Models
{
    public class SonosTrackNumber
    {
        private const int FirstTrackNumber = 1;

        public int Value { get; }

        public SonosTrackNumber() : this(FirstTrackNumber)
        {
        }

        public SonosTrackNumber(int value)
        {
            if (value < FirstTrackNumber)
                throw new ArgumentOutOfRangeException(nameof(value), $"Track number must be {FirstTrackNumber} or greater.");

            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
