using System.Net.Http;
using ByteDev.Sonos.Upnp.Proxy.Soap;

namespace ByteDev.Sonos.Upnp.Proxy
{
    public interface IUpnpRequestContentFactory
    {
        StringContent CreateFor(SoapAction soapAction, UpnpArgumentList args);
    }
}