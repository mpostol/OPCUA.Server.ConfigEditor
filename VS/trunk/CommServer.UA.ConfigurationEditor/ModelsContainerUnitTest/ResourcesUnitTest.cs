using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;


namespace CAS.UA.Model.Designer.ModelsContainer.UT
{
  [TestClass]
  public class ResourcesUnitTest
  {
    [TestMethod]
    public void ResourcesTestMethod()
    {
      DirectoryInfo _tergetDirectory = null;
      try
      {
        string _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), m_TestPath);
        _tergetDirectory = new DirectoryInfo(_path);
        Assert.IsFalse(_tergetDirectory.Exists, "The test directory already exist before test starting");
        ContainerResources.ExampleSolutionInstallation(m_TestPath, (x, y) => { });
        _tergetDirectory.Refresh();
        Assert.IsTrue(_tergetDirectory.Exists);
        Assert.AreEqual<int>(3, _tergetDirectory.GetFiles().Length, "Expected only 2 solutions and configuration editor");
        Assert.AreEqual<int>(2, _tergetDirectory.GetDirectories().Length, "Expected only 2 solutions folders");
      }
      catch (Exception)
      {
        throw;
      }
      finally
      {
        _tergetDirectory.Delete(true);
        _tergetDirectory.Refresh();
        Assert.IsFalse(_tergetDirectory.Exists);
      }
    }
    private const string m_TestPath = "TestingFolder2Delete";
  }
}
