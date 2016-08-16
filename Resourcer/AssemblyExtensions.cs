using System;
using System.IO;
using System.Reflection;

namespace Resourcer
{
    public static class AssemblyExtensions
    {      
        public static ResourceExtractionResult ExtractResource(this Assembly assembly, string resourceName)
        {
            var path = Path.GetTempPath();
            return assembly.ExtractResource(resourceName, path);
        }

        public static ResourceExtractionResult ExtractResource(this Assembly assembly, string resourceName, string directory)
        {
            var result = new ResourceExtractionResult();
            try
            {
                if (Directory.Exists(directory) == false) Directory.CreateDirectory(directory);

                var filePath = Path.Combine(directory, resourceName);

                if (File.Exists(filePath)) File.Delete(filePath);

                using (var s = assembly.GetManifestResourceStream(resourceName))
                {
                    if (s == null)
                    {
                        result.Success = false;
                        result.Error = $"Resource not found: `{resourceName}`";
                        return result;
                    }

                    using (var r = new BinaryReader(s))
                    using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
                    using (var w = new BinaryWriter(fs))
                    {
                        w.Write(r.ReadBytes((int)s.Length));
                    }
                }
                result.Location = filePath;
                result.Success = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Error = ex.Message;
                throw;
            }
        }
    }
}
