//_______________________________________________________________
//  Title   : ResourcesManagement
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate:  $
//  $Rev: $
//  $LastChangedBy: $
//  $URL: $
//  $Id:  $
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using System.IO;
using System.Reflection;

namespace CAS.CommServer.UA.ConfigurationEditor.ServerConfiguration.EmbeddedResources
{
  internal static class ResourcesManagement
  {

    internal static Stream GetDefaultServerConfigurationFile()
    {
      Assembly _Assembly = Assembly.GetExecutingAssembly();
      string filename = typeof(ResourcesManagement).Namespace + ".CAS.UAServer.Default.uasconfig";
      return _Assembly.GetManifestResourceStream(filename);
    }

  }
}
