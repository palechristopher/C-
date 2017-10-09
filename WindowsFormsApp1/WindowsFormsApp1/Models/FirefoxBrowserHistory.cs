using System;
using System.Linq;
using System.IO;

namespace WindowsFormsApp1.Models
{
    class FirefoxBrowserHistory : BrowserHistory
    {
        public FirefoxBrowserHistory() {
            path =  ReadFirefoxProfile() + "/places.sqlite";
            query = @"SELECT url as URL, title as Title, time(visit_date/1000000,'unixepoch', 'localtime' ) AS Time, date(visit_date/1000000,'unixepoch', 'localtime' ) as Date FROM moz_historyvisits, moz_places WHERE moz_historyvisits.place_id=moz_places.id ORDER BY visit_date DESC limit 50;";
            name = "FireFox";
        }
        private static string ReadFirefoxProfile()
        {

            string mozillaDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Mozilla");

            if (Directory.Exists(mozillaDir))
            {

                string firefoxDir = Path.Combine(mozillaDir, "firefox");

                if (Directory.Exists(firefoxDir))
                {
                    string prof_file = Path.Combine(firefoxDir, "profiles.ini");

                    if (File.Exists(prof_file))
                    {
                        StreamReader rdr = new StreamReader(prof_file);

                        string[] lines = rdr.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.None);

                        string location = lines.First(x => x.Contains("Path=")).Split(new string[] { "=" }, StringSplitOptions.None)[1];

                        return Path.Combine(firefoxDir, location);
                    }
                }
            }
            return "";
        }

    }
}
