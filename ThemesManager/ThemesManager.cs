namespace Microshaoft
{
    using Fluent;
    using System;
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

        private static void ApplyTheme<T>(T target, string themeXamlFilePath)
        {


        }


        public static void ApplyTheme
                            (
                                this Application target
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
                target
                    .Resources
                    .MergedDictionaries.Clear();
                target
                    .Resources
                    .MergedDictionaries
                    .Add(resourceDictionary);
            }
        }

        public static void ApplyTheme
                                (
                                    this ContentControl target
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
                target
                        .Resources
                        .MergedDictionaries
                        .Clear();
                target
                        .Resources
                        .MergedDictionaries
                        .Add
                            (
                                resourceDictionary
                            );
            }
        }



        public static void ApplyTheme(this RibbonWindow target, string themeXamlFilePath)
        {
            var resourceDictionary = XamlReaderHelper
                                        .ParseFromFile<ResourceDictionary>
                                                (
                                                    themeXamlFilePath
                                                //@"D:\MyGitHub\Wpf.MEF.Themes\Themes\Themes.Basis.Parts\Themes.Basis.Parts\ExpressionDark\Theme.xaml"
                                                );

            if (resourceDictionary != null)
            {
                target
                        .Resources
                        .MergedDictionaries
                        .Clear();
                target
                        .Resources
                        .MergedDictionaries
                        .Add
                            (
                                resourceDictionary
                            );
            }

            //var resources = Application.Current.Resources;

            //foreach (DictionaryEntry dictionaryEntry in resources)
            //{
            //    Console.WriteLine(dictionaryEntry.Key);


            //}


            //Application.Current.Resources["RibbonThemeColorBrush"] = new SolidColorBrush(Colors.Red);
        }



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
            //return;
            string theme = e.NewValue as string;
            if (theme == string.Empty)
            {
                return;
            }

            if (dependencyObject is ContentControl)
            {
                ContentControl control = dependencyObject as ContentControl;
                if (control != null)
                {
                    control.ApplyTheme(theme);
                }
            }
            else if (dependencyObject is RibbonWindow)
            {
                RibbonWindow control = dependencyObject as RibbonWindow;
                if (control != null)
                {
                    Console.WriteLine(control.Name);
                    control.ApplyTheme(theme);
                }

            }



        }

  


        #endregion



    }
}
