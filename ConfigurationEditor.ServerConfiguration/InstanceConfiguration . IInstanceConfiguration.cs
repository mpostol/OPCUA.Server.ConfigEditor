//___________________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System.Windows.Forms;
using UAOOI.Configuration.Core;
using UAOOI.Windows.Forms;

namespace CAS.UA.Server.ServerConfiguration
{
  /// <summary>
  /// Class InstanceConfiguration.
  /// Implements the <see cref="IInstanceConfiguration" />
  /// </summary>
  /// <seealso cref="IInstanceConfiguration" />
  public partial class InstanceConfiguration : IInstanceConfiguration
  {
    #region IInstanceConfiguration Members

    /// <summary>
    /// Edits this instance.
    /// </summary>
    public void Edit()
    {
      InstanceConfiguration copy;
      copy = (InstanceConfiguration)Clone();
      using (AddObject<InstanceConfiguration> form = new AddObject<InstanceConfiguration>(copy))
        if (form.ShowDialog() == DialogResult.OK)
          DataSources = form.Object.DataSources;
    }

    /// <summary>
    /// Create new empty data bindings configuration for this instance node to store proprietary information of the UA server.
    /// </summary>
    public void ClearConfiguration()
    {
      DataSources = null;
    }

    #endregion IInstanceConfiguration Members
  }
}