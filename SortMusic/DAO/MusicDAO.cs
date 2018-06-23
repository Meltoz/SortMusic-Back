using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using BuisnessObject;
using Helper;
using System.Linq;


namespace DAO
{
    public class MusicDAO
    {
        /// <summary>
        /// Permet d'obtenir la liste des musiques
        /// </summary>
        /// <param name="folderPath">Chemin vers le dossier</param>
        /// <returns></returns>
        public List<string> GetMusicName()
        {
            List<string> musicName = new List<string>();
            string pattern = @"(.*)\\(.*)\.mp3";

            foreach (string filePath in Directory.GetFiles(CstSortMusic.Instance.Folder))
            {
                Match regEx = Regex.Match(filePath, pattern);
                musicName.Add(regEx.Groups[2].Value);
            }
            return musicName;
        }

        /// <summary>
        /// Permet d'obtenir les details a partir du nom d'une musique
        /// </summary>
        /// <param name="musicName">Titre de la musique (e.g : test.mp3)</param>
        /// <returns>Details de la musique</returns>
        public Music GetMusicByTitle(string musicName)
        {
            string pattern = @"(.*)\.mp3";
            Match regex = Regex.Match(musicName, pattern);

            Music music = new Music();
            music.FileName = musicName;
            music.Title = regex.Groups[1].Value;
            using (TagLib.File file = TagLib.File.Create(CstSortMusic.Instance.Folder + musicName))
            {
                music.Duration = Util.TimeSpanToSecond(file.Properties.Duration);
                music.Artists = file.Tag.AlbumArtists != null ? new List<string>(file.Tag.AlbumArtists) : new List<string>();
                music.Genres = file.Tag.Genres != null ? new List<string>(file.Tag.Genres) : new List<string>();
            }

            return music;
        }

        /// <summary>
        /// Permet d'enregister les métadonnées d'une musique
        /// </summary>
        /// <param name="music">Musique a sauvegarder</param>
        public void SaveMusic(Music music)
        {
            using (TagLib.File file = TagLib.File.Create(CstSortMusic.Instance.Folder + music.FileName))
            {
                bool modification = false;
                if (!music.Title.Equals(file.Tag.Title))
                {
                    file.Tag.Title = music.Title;
                    modification = true;
                }

                if (!music.Artists.SequenceEqual(new List<string>(file.Tag.Performers)))
                {
                    file.Tag.AlbumArtists = music.Artists.ToArray();
                    modification = true;
                }

                if (!music.Genres.SequenceEqual(new List<string>(file.Tag.Genres)))
                {
                    file.Tag.Genres = null;
                    file.Tag.Genres = music.Genres.ToArray();
                    modification = true;
                }

                if (modification)
                {
                    file.Save();
                }
            }
        }

        /// <summary>
        /// Permet d'obtenir la liste des musiques du dossiers
        /// </summary>
        /// <returns></returns>
        public List<Music> All()
        {
            List<Music> musics = new List<Music>();
            string pattern = @"(.*)\\(.*)\.mp3";

            Directory.GetFiles(CstSortMusic.Instance.Folder).ToList().ForEach(filePath =>
            {

                Match regex = Regex.Match(filePath, pattern);
                Music m = new Music
                {
                    Title = regex.Groups[2].Value,
                };
                m.FileName = m.Title + ".mp3";

                using (TagLib.File file = TagLib.File.Create(CstSortMusic.Instance.Folder + m.FileName))
                {
                    m.Duration = Util.TimeSpanToSecond(file.Properties.Duration);
                    m.Artists = file.Tag.AlbumArtists != null ? new List<string>(file.Tag.AlbumArtists) : new List<string>();
                    m.Genres = file.Tag.Genres != null ? new List<string>(file.Tag.Genres) : new List<string>();
                }
                musics.Add(m);

            });

            return musics;
        }
    }
}
