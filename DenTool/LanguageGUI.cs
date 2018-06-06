using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DenTool
{
    public class LanguageGUI
    {
        public static string currentLanguageCode()
        {
            // Get the Merged ResourceDictionary and trim the first and last 5 chars
            string code = Application.Current.Resources.MergedDictionaries[0].Source.ToString();
            /*  5 - "lang/"; 5 - ".xaml"    */
            return code.Substring(5, 5);
        }

        /* Localization
        * https://stackoverflow.com/questions/33867091/how-to-change-resourcedictionary-dynamically?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa 
        * Replace the first MergedDictionary's source
        */
        public static void changeLanguage(string lang)
        {
            Application.Current.Resources.MergedDictionaries[0].Source =
                new Uri("lang/" + lang + ".xaml", UriKind.RelativeOrAbsolute);
        }
    }
}
