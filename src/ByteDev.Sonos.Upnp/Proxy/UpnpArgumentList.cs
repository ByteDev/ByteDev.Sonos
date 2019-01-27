using System.Collections.Generic;
using System.Linq;

namespace ByteDev.Sonos.Upnp.Proxy
{
    public class UpnpArgumentList
    {
        public IList<UpnpArgument> Arguments { get; }

        public UpnpArgumentList() : this(null)
        {
        }

        public UpnpArgumentList(IList<UpnpArgument> args)
        {
            if (args == null)
                args = new List<UpnpArgument>();

            if (args.All(p => p.Name != "InstanceID"))
                args.Insert(0, new UpnpArgument("InstanceID", 0));

            Arguments = args;
        }
    }
}