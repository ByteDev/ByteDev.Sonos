using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using ByteDev.Sonos.Upnp.Proxy.Soap;

namespace ByteDev.Sonos.Upnp.Proxy
{
    internal class UpnpRequestContentFactory : IUpnpRequestContentFactory
    {
        public StringContent CreateFor(SoapAction soapAction, UpnpArgumentList args)
        {
            if(soapAction == null)
                throw new ArgumentNullException(nameof(soapAction));

            if(args == null)
                throw new ArgumentNullException(nameof(args));

            var content = CreateSoapMessage(soapAction, args);

            var sc = new StringContent(content);                                       // TODO: create SoapContent?
            sc.Headers.ContentType = MediaTypeHeaderValue.Parse("text/xml");
            sc.Headers.Add(SoapAction.HeaderName, soapAction.HeaderValue);

            return sc;
        }

        private static string CreateSoapMessage(SoapAction sa, UpnpArgumentList list)
        {
            var body = CreateSoapMessageBody(sa, list);

            return $"<?xml version=\"1.0\" encoding=\"utf-8\"?><s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\"><s:Body>{body}</s:Body></s:Envelope>";
        }

        private static string CreateSoapMessageBody(SoapAction sa, UpnpArgumentList list)
        {
            var body = new StringBuilder();

            body.Append($"<u:{sa.Action} xmlns:u=\"{sa.ActionNamespace}\">");

            foreach (var property in list.Arguments)
            {
                body.Append($"<{property.Name}>{property.Value}</{property.Name}>");
            }

            body.Append($"</u:{sa.Action}>");

            return body.ToString();
        }
    }
}
