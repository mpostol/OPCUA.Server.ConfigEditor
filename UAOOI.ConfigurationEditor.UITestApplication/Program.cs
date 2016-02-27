using System;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.UITestApplication
{
  class Program
  {
    [STAThread]
    static void Main(string[] args)
    {
      ConfigurationEditor.ConfigurationEditorBase _factory = new ConfigurationEditorBase();
      ConfigurationData _newConfiguration= new ConfigurationData();
      _factory.EditConfiguration(_newConfiguration);
    }
  }
}
