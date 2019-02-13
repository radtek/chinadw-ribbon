using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Ionic.Zip;

namespace ARM_User.ServiceLayer.Utils
{
  public class ExcelBox
  {
    public List<String> files = new List<String>();

    public void OpenLast()
    {
      var lastPath = files.Last();
      Process.Start(lastPath);
    }

    /// <summary>
    ///   Взять из передаваемого зип файла нужный файл
    /// </summary>
    public void AddFromZip(byte[] zip, string fileName, string newFileName, bool genUniqueName)
    {
      string tempFileName = newFileName;
      if (genUniqueName)
      {        
        if (newFileName != null)
        {
          if (Path.HasExtension(newFileName))
            tempFileName = Path.GetFileNameWithoutExtension(newFileName) + "(" + Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ")";
          else
            tempFileName = newFileName + '(' + Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ')';
        }
      }

      if (!Path.HasExtension(tempFileName))
        tempFileName = tempFileName + Path.GetExtension(fileName);

      string tempFilePath = Path.Combine(Path.GetTempPath(), tempFileName);
      files.Add(tempFilePath);

      // извлекаем из архива
      FileStream fs = new FileStream(tempFilePath, FileMode.CreateNew, FileAccess.ReadWrite);
      var zipFile = ZipFile.Read(new MemoryStream(zip));
      zipFile[fileName].Extract(fs);
      fs.Close();
    }

    public string AddNewEmptyWorkbook(string fileName)
    {
      var tempFileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
      if (fileName != null)
        tempFileName = fileName + '(' + tempFileName + ')';

      var tempFilePath = Path.Combine(Path.GetTempPath(), tempFileName + Path.GetExtension(fileName));
      files.Add(tempFilePath);

      return files.Last();
    }

    public void DeleteFiles()
    {
      foreach (var path in files)
      {
        try
        {
          File.Delete(path);
        }
        catch (Exception)
        {
        }
      }
    }

  }
}