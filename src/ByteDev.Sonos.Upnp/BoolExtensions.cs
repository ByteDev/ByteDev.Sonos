﻿namespace ByteDev.Sonos.Upnp
{
    public static class BoolExtensions
    {
        public static int ToInt(this bool source)
        {
            return source ? 1 : 0;
        }
    }
}