using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace Resourcer
{
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Returns the resource with the given name as a T. Null if it does not exist.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assembly"></param>
        /// <param name="resourceName"></param>
        public static T GetResource<T>(this Assembly assembly, string resourceName) where T : class
        {
            using (var s = assembly.GetManifestResourceStream(resourceName))
            {
                if (s == null) return default(T);

                if (typeof(T) == typeof(string))
                {
                    using (var sr = new StreamReader(s))
                    {
                        return sr.ReadToEnd() as T;
                    }
                }

                if (typeof(T).IsSubclassOf(typeof(Image)))
                {
                    return Image.FromStream(s) as T;
                }

                if (typeof(T) == typeof(byte[]))
                {
                    using (var br = new BinaryReader(s))
                    {
                        return br.ReadBytes((int) s.Length) as T;
                    }
                }

                throw new NotSupportedException($"unsupported type '{typeof(T).Name}'");
            }
        }

        /// <summary>
        /// Extracts the given resource to a temporary file on disk.
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public static ResourceExtractionResult ExtractResource(this Assembly assembly, string resourceName)
        {
            var path = Path.GetTempPath();
            return assembly.ExtractResource(resourceName, path);
        }

        /// <summary>
        /// Extracts the given resource to a specified directory on disk.
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="resourceName"></param>
        /// <param name="directory"></param>
        /// <returns></returns>
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
