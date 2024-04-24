using Microsoft.Extensions.Configuration;

namespace DisabilityInPortal.Infrastructure.Bundling
{
    public static class BundleHelper
    {
        private const string BundleConfig = "bundle.json";

        private static readonly BundleConfig JsConfig = new();
        private static readonly BundleConfig CssConfig = new();

        static BundleHelper()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile(BundleConfig)
                .Build();

            config.Bind(nameof(BundleType.Javascript), JsConfig);
            config.Bind(nameof(BundleType.Css), CssConfig);
        }

        public static string JsBundleName => JsConfig.OutputFileName;
        public static string[] JsBundleFiles => JsConfig.InputFiles;

        public static string CssBundleName => CssConfig.OutputFileName;
        public static string[] CssBundleFiles => CssConfig.InputFiles;
    }
}