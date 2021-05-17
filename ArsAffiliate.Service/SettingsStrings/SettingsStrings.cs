using System.Configuration;
using System.IO;

namespace ArsAffiliate.Service.SettingsStrings
{
    public class SettingsStrings
    {

        //#region singletom

        //private static SettingsStrings Instance;

        //public static SettingsStrings Getinstance()
        //{
        //    if (Instance == null)
        //        Instance = new SettingsStrings();

        //    return Instance;
        //}

        //#endregion

        //static Configuration _Config;

        //private SettingsStrings()
        //{
        //    _Config = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap
        //    {
        //        ExeConfigFilename = Path.Combine(Directory.GetCurrentDirectory(), "App.config")
        //    }, ConfigurationUserLevel.None);

        //}

        public static string ConnectionString = @"server=(localdb)\MSSQLLocalDB; database=ArsAfiliados; Trusted_Connection=True;"; //_Config.ConnectionStrings.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static string OneOriginWeb => "http://localhost:4200/"; //_Config.AppSettings.Settings["WebClient"].ToString();
        public static string KeyJwt => "dmdvsKlkjLKJOIjiojRJ8YUY7W6Rq6r9q6r96qr0qqehr8y3242f23rFE3Robert190114Luis941127"; //_Config.AppSettings.Settings["keyJwt"].ToString();

    }
}
