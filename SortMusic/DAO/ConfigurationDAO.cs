using System.Collections.Generic;
using System.Xml;
using System.IO;
using Helper;


namespace DAO
{
    public class ConfigurationDAO
    {
        public List<string> GetStyle()
        {
            List<string> styles = new List<string>();

            using (StreamReader reader = new StreamReader(CstSortMusic.Instance.PathConfigurationFile))
            {
                string line = string.Empty;

               while((line = reader.ReadLine())!= null)
                {
                    styles.Add(line);
                }
            }

            return styles;
        }

        public void AddStyle(string element)
        {

        }
    }
}
