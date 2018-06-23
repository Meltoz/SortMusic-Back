using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using BuisnessObject;

namespace UnitTest
{

    [TestClass]
    public class MusicDAOTest
    {

        #region TEST GetMusicName

        [TestMethod]
        public void GetMusicName_Test_OK()
        {
            List<string> expectedResult = new List<string>() { "test", "test2", };
            List<string> realResult = new MusicDAO().GetMusicName();

            CollectionAssert.AreEqual(expectedResult, realResult);
        }

        [TestMethod]
        public void GetMusicName_Test_KO()
        {
            List<string> expectedResult = new List<string>() { "test", "Test" };
            List<string> realResult = new MusicDAO().GetMusicName();

            CollectionAssert.AreNotEqual(expectedResult, realResult);
        }

        #endregion

        #region TEST GetMusicDetail

        [TestMethod]
        public void GetMusicDetails_Test_OK()
        {
            Music expectedMusic = new Music() { Title = "test", FileName = "test.mp3", Artists = new List<string>() { "Maxime" }, Duration =  7, Genres = new List<string>() { "Pop" }, };
            Music actualMusic = new MusicDAO().GetMusicByTitle("test.mp3");

            Assert.AreEqual(expectedMusic, actualMusic);
        }

        [TestMethod]
        public void GetMusicDetails_Test_KO_Title()
        {
            Music expectedMusic = new Music() { Title = "test5", FileName = "test.mp3", Artists = new List<string>() { "Maxime" }, Duration = 7, Genres = new List<string>() { "Pop" }, };
            Music actualMusic = new MusicDAO().GetMusicByTitle("test.mp3");

            Assert.AreNotEqual(expectedMusic, actualMusic);
        }
        
        [TestMethod]
        public void GetMusicDetails_Test_KO_Artists()
        {
            Music expectedMusic = new Music() { Title = "test", FileName = "test.mp3", Artists = new List<string>() { "Michel" }, Duration = 7, Genres = new List<string>() { "Pop" }, };
            Music actualMusic = new MusicDAO().GetMusicByTitle("test.mp3");

            Assert.AreNotEqual(expectedMusic, actualMusic);
        }

        [TestMethod]
        public void GetMusicDetails_Test_KO_Duration()
        {
            Music expectedMusic = new Music() { Title = "test", FileName = "test.mp3", Artists = new List<string>() { "Maxime" }, Duration = 6, Genres = new List<string>() { "Pop" }, };
            Music actualMusic = new MusicDAO().GetMusicByTitle("test.mp3");

            Assert.AreNotEqual(expectedMusic, actualMusic);
        }

        [TestMethod]
        public void GetMusicDetails_Test_KO_Genres()
        {
            Music expectedMusic = new Music() { Title = "test", FileName = "test.mp3", Artists = new List<string>() { "Maxime" }, Duration = 6, Genres = new List<string>() { "Rock" }, };
            Music actualMusic = new MusicDAO().GetMusicByTitle("test.mp3");

            Assert.AreNotEqual(expectedMusic, actualMusic);
        }
        #endregion

        #region TEST all()

        [TestMethod]
        public void All_Test_OK()
        {
            Music music1 = new Music() { Title = "test", FileName = "test.mp3", Artists = new List<string>() { "Maxime" }, Duration = 7, Genres = new List<string>() { "Pop" }, };
            Music music2 = new Music() { Title = "test2", FileName = "test2.mp3", Artists = new List<string>() { "Maxime" }, Duration = 7, Genres = new List<string>() { "Pop" }, };

            List<Music> expectedList = new List<Music>() { music1, music2 };

            List<Music> actualList = new MusicDAO().All();

            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestMethod]
        public void All_Test_KO()
        {
            Music music1 = new Music() { Title = "test3", FileName = "test.mp3", Artists = new List<string>() { "Maxime" }, Duration = 7, Genres = new List<string>() { "Pop" }, };
            Music music2 = new Music() { Title = "test2", FileName = "test2.mp3", Artists = new List<string>() { "Maxime" }, Duration = 7, Genres = new List<string>() { "Pop" }, };

            List<Music> expectedList = new List<Music>() { music1, music2 };

            List<Music> actualList = new MusicDAO().All();

            CollectionAssert.AreNotEqual(expectedList, actualList);
        }


        #endregion
    }
}
