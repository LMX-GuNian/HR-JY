using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using Unity;

namespace IOC
{
    public class ModelIOC
    {
        private static UnityContainer GetIOC(string name)
        {
            UnityContainer ioc = new UnityContainer();
            ExeConfigurationFileMap ecf = new ExeConfigurationFileMap();
            ecf.ExeConfigFilename = @"E:/HR-JY/HR/IOC/Unity.config";
            Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(ecf, ConfigurationUserLevel.None);
            UnityConfigurationSection cs = (UnityConfigurationSection)cf.GetSection("unity");
            ioc.LoadConfiguration(cs, name);
            return ioc;
        }

        public static T GetDAL<T>()
        {
            return GetIOC("DA0").Resolve<T>(typeof(T).Name);
        }

        public static T GetBLL<T>()
        {
            return GetIOC("BLL").Resolve<T>(typeof(T).Name);
        }
    }
}
