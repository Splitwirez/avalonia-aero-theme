using System;
using System.IO;
using Avalonia.Styling;

namespace AeroAvalonia.Demo
{
    internal sealed class Config
    {
        public static readonly Config Current = new();


        public readonly string ConfigDirPath;


        const string _ALLOW_TEST_PAGE = "ALLOW_TEST_PAGE";
        public readonly bool AllowTestPage = false;

        const string _REQUESTED_THEME_VARIANT = "REQUESTED_THEME_VARIANT";
        readonly bool _hasDesiredThemeVariant = false;
        readonly ThemeVariant _desiredThemeVariant = default;
        public bool TryGetDesiredThemeVariant(out ThemeVariant variant)
        {
            variant = _desiredThemeVariant;
            return _hasDesiredThemeVariant;
        }


        private Config()
        {
            string localAppDataDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            Console.WriteLine(
                $"{nameof(Environment)}.{nameof(Environment.GetFolderPath)}({nameof(Environment.SpecialFolder.LocalApplicationData)})\n"+
                $"    => '{localAppDataDir}'"
            );

            ConfigDirPath = Path.Combine(localAppDataDir, "AeroAvalonia.Demo");
            if (!Directory.Exists(ConfigDirPath))
                return;

            EnsureShowTestPage(ref AllowTestPage);
            EnsureDesiredVariant(ref _desiredThemeVariant, ref _hasDesiredThemeVariant);
        }


        void EnsureShowTestPage(ref bool allowTestPage)
        {
            string allowTestPagePath = Path.Combine(ConfigDirPath, _ALLOW_TEST_PAGE);
            if (File.Exists(allowTestPagePath))
                allowTestPage = true;
        }


        void EnsureDesiredVariant(ref ThemeVariant desiredThemeVariant, ref bool hasDesiredThemeVariant)
        {
            string reqVariantPath = Path.Combine(ConfigDirPath, _REQUESTED_THEME_VARIANT);
            if (!File.Exists(reqVariantPath))
                return;

            string reqVariantText = File.ReadAllText(reqVariantPath);
            ThemeVariantTypeConverter variantConverter = new();
            if (!(variantConverter.ConvertFromInvariantString(reqVariantText) is ThemeVariant reqVariant))
                return;

            if (reqVariant == null)
                return;

            if (reqVariant == ThemeVariant.Default)
                return;

            desiredThemeVariant = reqVariant;
            hasDesiredThemeVariant = true;
        }
    }
}