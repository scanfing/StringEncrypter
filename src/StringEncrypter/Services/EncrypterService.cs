using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using StringEncrypter.Encrypters;

namespace StringEncrypter.Services
{
    public class EncrypterService
    {
        #region Fields

        private List<IEncrypter> _encrypters;

        #endregion Fields

        #region Constructors

        public EncrypterService()
        {
            _encrypters = new List<IEncrypter>();
        }

        #endregion Constructors

        #region Methods

        public IEncrypter[] GetCrypters()
        {
            return _encrypters.ToArray();
        }

        /// <summary>
        /// 从指定目录加载加密插件
        /// </summary>
        /// <param name="pluginDir"></param>
        public async Task<IEncrypter[]> LoadEncrypterFromDir(string srcDir)
        {
            var diskEncrypters = new List<IEncrypter>();

            var interfaceType = typeof(IEncrypter);

            var files = Directory.GetFiles(srcDir, "*.exe");
            var dlls = Directory.GetFiles(srcDir, "*.dll");

            var allfiles = files.Concat(dlls);
            Assembly ass;
            foreach (var file in allfiles)
            {
                try
                {
                    ass = await Task.Run(() => Assembly.LoadFile(file));
                }
                catch (Exception)
                {
                    continue;
                }
                foreach (var t in ass.GetTypes())
                {
                    if (t.IsClass && !t.IsAbstract && interfaceType.IsAssignableFrom(t))
                    {
                        System.Diagnostics.Trace.TraceInformation($"Find Encrypter: {t.FullName}.");
                        diskEncrypters.Add(ass.CreateInstance(t.FullName) as IEncrypter);
                    }
                }
            }
            return diskEncrypters.ToArray();
        }

        #endregion Methods
    }
}