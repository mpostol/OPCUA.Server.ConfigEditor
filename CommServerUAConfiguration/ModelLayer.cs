//<summary>
//  Title   : ModelLayer
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>


using System.Runtime.Serialization;

namespace CAS.UA.Server.ServerConfiguration
{
  /// <summary>
  /// Class ModelLayer. - <see cref="DataContract"/> to serialize 
  /// </summary>
  [DataContract( Namespace = CASConfiguration.DefaultNamespace )]
  public class ModelLayer
  {
    
    string namespaceUri;
    string filePathUanodes;
    string filePathCsv;

    /// <summary>
    /// Gets or sets the namespace URI.
    /// </summary>
    /// <value>The namespace URI.</value>
    [DataMember( IsRequired = true )]
    public string NamespaceUri
    {
      get { return this.namespaceUri; }
      set { this.namespaceUri = value; }
    }
    /// <summary>
    /// Gets or sets the file path of UA nodes.
    /// </summary>
    /// <value>The file path UA nodes.</value>
    [DataMember( IsRequired = true )]
    public string FilePathUanodes
    {
      get { return this.filePathUanodes; }
      set { this.filePathUanodes = value; }
    }
    /// <summary>
    /// Gets or sets the file path of CSV file.
    /// </summary>
    /// <value>The file path of CSV file.</value>
    [DataMember( IsRequired = true )]
    public string FilePathCsv
    {
      get { return this.filePathCsv; }
      set { this.filePathCsv = value; }
    }


  }
}
