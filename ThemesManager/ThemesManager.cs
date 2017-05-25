namespace Microshaoft
{
    //using Microshaoft;
    //using Fluent;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;

    public static class ThemesManager
    {
        //public static ResourceDictionary GetThemeResourceDictionary(string theme)
        //{
        //    if (theme != null)
        //    {
        //        Assembly assembly = Assembly.LoadFrom("WPF.Themes.dll");
        //        string packUri = String.Format(@"/WPF.Themes;component/{0}/Theme.xaml", theme);
        //        return Application.LoadComponent(new Uri(packUri, UriKind.Relative)) as ResourceDictionary;
        //    }
        //    return null;
        //}

        public static IEnumerable<string> GetThemes(string themesRootDirectory)
        {
            return
                Directory
                    .EnumerateFiles
                        (
                            themesRootDirectory
                            , "theme.xaml"
                            , SearchOption.AllDirectories
                        );
        }

        public static void ApplyTheme
                            (
                                this Application app
                                , string themeXamlFilePath
                            )
        {
            var resourceDictionary = XamlReaderHelper
                                        .ParseFromFile<ResourceDictionary>
                                                (
                                                    themeXamlFilePath
                                                    //@"D:\MyGitHub\Wpf.MEF.Themes\Themes\Themes.Basis.Parts\Themes.Basis.Parts\ExpressionDark\Theme.xaml"
                                                );

            if (resourceDictionary != null)
            {
                app
                    .Resources
                    .MergedDictionaries.Clear();
                app
                    .Resources
                    .MergedDictionaries
                    .Add(resourceDictionary);
            }
        }

        public static void ApplyTheme
                                (
                                    this ContentControl contentControl
                                    , string themeXamlFilePath
                                )
        {
            var resourceDictionary = XamlReaderHelper
                                        .ParseFromFile<ResourceDictionary>
                                                (
                                                    themeXamlFilePath
                                                    //@"D:\MyGitHub\Wpf.MEF.Themes\Themes\Themes.Basis.Parts\Themes.Basis.Parts\ExpressionDark\Theme.xaml"
                                                );

            if (resourceDictionary != null)
            {
                contentControl
                        .Resources
                        .MergedDictionaries
                        .Clear();
                contentControl
                        .Resources
                        .MergedDictionaries
                        .Add
                            (
                                resourceDictionary
                            );
            }
        }



        //public static void ApplyTheme(this RibbonWindow target, string theme)
        //{
        //    //ResourceDictionary dictionary = ThemeManager.GetThemeResourceDictionary(theme);

        //    //if (dictionary != null)
        //    //{
        //    //    target.Resources.MergedDictionaries.Clear();
        //    //    target.Resources.MergedDictionaries.Add(dictionary);
        //    //}

        //    var resources = Application.Current.Resources;

        //    foreach (DictionaryEntry dictionaryEntry in resources)
        //    {
        //        Console.WriteLine(dictionaryEntry.Key);


        //    }


        //    Application.Current.Resources["RibbonThemeColorBrush"] = new SolidColorBrush(Colors.Red);
        //}



        #region Theme

        /// <summary>
        /// Theme Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty ThemeProperty =
            DependencyProperty
                    .RegisterAttached
                            (
                                "Theme"
                                , typeof(string)
                                , typeof(ThemesManager)
                                , new FrameworkPropertyMetadata
                                        (
                                            string.Empty
                                            , new PropertyChangedCallback
                                                    (
                                                        OnThemeChanged
                                                    )
                                        )
                            );

        /// <summary>
        /// Gets the Theme property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static string GetTheme(DependencyObject dependencyObject)
        {
            return (string) dependencyObject.GetValue(ThemeProperty);
        }

        /// <summary>
        /// Sets the Theme property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static void SetTheme(DependencyObject dependencyObject, string value)
        {
            dependencyObject.SetValue(ThemeProperty, value);
        }

        /// <summary>
        /// Handles changes to the Theme property.
        /// </summary>
        private static void OnThemeChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            string theme = e.NewValue as string;
            if (theme == string.Empty)
            {
                return;
            }

            ContentControl control = dependencyObject as ContentControl;
            if (control != null)
            {
                control.ApplyTheme(theme);
            }
        }

        #endregion



    }
}
