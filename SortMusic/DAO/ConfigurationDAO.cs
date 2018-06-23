using System.Collections.Generic;
using System.Xml;
using System.IO;
using Helper;


namespace DAO
{
    public class ConfigurationDAO
    {

        /// <summary>
        /// Permet d'obtenir la listes des différents style de musique a partir du fichier plat
        /// </summary>
        public static void GetStyle()
        {
            if (CstSortMusic.Instance.Styles.Count == 0)
            {
                List<string> styles = new List<string>();

                using (StreamReader reader = new StreamReader(CstSortMusic.Instance.PathConfigurationFile))
                {
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        styles.Add(line);
                        line = reader.ReadLine();
                    }
                }

                CstSortMusic.Instance.Styles = styles;
            }
        }

        /// <summary>
        /// Permet de sauvegarder les différents style de musique dans un fichier plat
        /// </summary>
        public static void SaveStyle()
        {
            using (StreamWriter writer = new StreamWriter(CstSortMusic.Instance.PathConfigurationFile, false, System.Text.Encoding.UTF8))
            {
                CstSortMusic.Instance.Styles.ForEach(s =>
                {
                    writer.WriteLine(s);
                });
            }
        }
    }
}
