using ByteDev.Cmd;

namespace ByteDev.Sonos.Console
{
    internal class Program
    {
        private const string DefaultIpAddress = "10.0.1.92";

        private static readonly Output Output;

        static Program()
        {
            Output = new Output();            
        }

        private static void Main(string[] args)
        {
            Output.PrintHeader();

            if (args.Length < 1)
            {
                Output.WriteLine("No operation argument given, try...");
                Output.WriteLine();
                Output.PrintHelp();
                return;
            }

            if (args.Length == 1 && args[0] == "help")
            {
                Output.PrintHelp();
                return;
            }
                
            var ipAddress = GetIpAddress(args);
            Output.WriteLine($"Using device: {ipAddress}");
            Output.WriteLine();

            var sonosOperations = new SonosOperations(ipAddress);
            
            for (var i=0; i < args.Length; i++)
            {
                var opArg = args[i];

                switch (opArg)
                {
                    case "getvol":
                        var volume = sonosOperations.GetVolume();
                        Output.WriteLine($"Volume {volume.Value}");
                        return;

                    case "setvol":
                    {
                        var valueArg = GetValueArg(args, i);

                        if (string.IsNullOrEmpty(valueArg))
                        {
                            Output.WriteLine($"{opArg} has no supplied value arg.");
                            return;
                        }

                        sonosOperations.SetVolume(int.Parse(valueArg));
                        return;
                    }

                    case "setvolforever":
                    {
                        var valueArg = GetValueArg(args, i);

                        if (string.IsNullOrEmpty(valueArg))
                        {
                            Output.WriteLine($"{opArg} has no supplied value arg.");
                            return;
                        }
                        sonosOperations.SetVolumeForever(int.Parse(valueArg));
                        return;
                    }

                    case "getisplaying":
                    {
                        var isPlaying = sonosOperations.GetIsPlaying();
                        Output.WriteLine($"IsPlaying: {isPlaying}");
                        return;
                    }

                    case "play":
                    {
                        var isPlaying = sonosOperations.GetIsPlaying();
                        if (isPlaying)
                        {
                            Output.WriteLine("Device is already playing.");
                        }
                        else
                        {
                            sonosOperations.Play();
                            Output.WriteLine("Device is now playing.");
                        }
                        return;
                    }

                    case "stop":
                    {
                        var isPlaying = sonosOperations.GetIsPlaying();
                        if (isPlaying)
                        {
                            sonosOperations.Stop();
                            Output.WriteLine("Device is now stopped.");
                        }
                        else
                        {
                            sonosOperations.Play();
                            Output.WriteLine("Device is already stopped.");
                        }
                        return;
                    }

                    case "stopforever":
                    {
                        sonosOperations.StopForever();
                        return;
                    }
                }
            }
        }

        private static string GetIpAddress(string[] args)
        {
            for (var i = 0; i < args.Length; i++)
            {
                if (args[i] == "deviceip")
                {
                    return GetValueArg(args, i);
                }
            }
            return DefaultIpAddress;
        }

        private static string GetValueArg(string[] args, int i)
        {
            if (i + 1 < args.Length)
            {
                return args[i + 1];
            }
            return null;
        }
    }
}
