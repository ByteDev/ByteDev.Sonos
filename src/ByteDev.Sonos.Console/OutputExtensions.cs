using ByteDev.Cmd;

namespace ByteDev.Sonos.Console
{
    public static class OutputExtensions
    {
        public static void PrintHeader(this Output source)
        {
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            var message = $" Sonos Console v{version} ";

            source.Write(new MessageBox(message));
        }

        public static void PrintHelp(this Output source)
        {
            source.WriteLine("Global arguments:");
            source.WriteLine("\tdeviceip <device_ip>");
            source.WriteLine();
            source.WriteLine("Operation arguments:");
            source.WriteLine("\thelp");
            source.WriteLine("\tgetvol");
            source.WriteLine("\tsetvol <0-100>");
            source.WriteLine("\tsetvolforever <0-100>");
            source.WriteLine("\tgetisplaying");
            source.WriteLine("\tplay");
            source.WriteLine("\tstop");
            source.WriteLine("\tstopforever");
        }
    }
}