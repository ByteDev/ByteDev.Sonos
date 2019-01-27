﻿using System;
using System.Linq;
using System.Xml.Linq;
using ByteDev.Sonos.Upnp.Services.Models;

namespace ByteDev.Sonos.Upnp.Services.Factories
{
    public class GetMediaInfoResponseFactory
    {
        public GetMediaInfoResponse CreateFor(XNamespace actionXNamespace, string xml)
        {
            var element = XElement.Parse(xml);

            var responseNode = element.Descendants(actionXNamespace + "GetMediaInfoResponse").First();

            return new GetMediaInfoResponse
            {
                NumberOfTracks = Convert.ToInt32(responseNode.Element("NrTracks")?.Value),
                MediaDuration = responseNode.Element("MediaDuration")?.Value,
                CurrentUri = responseNode.Element("CurrentURI")?.Value,
                CurrentUriMetaData = responseNode.Element("CurrentURIMetaData")?.Value,
                NextUri = responseNode.Element("NextURI")?.Value,
                NextUriMetaData = responseNode.Element("NextURIMetaData")?.Value,
                PlayMedium = responseNode.Element("PlayMedium")?.Value,
                RecordMedium = responseNode.Element("RecordMedium")?.Value,
                WriteStatus = responseNode.Element("WriteStatus")?.Value
            };
        }
    }
}