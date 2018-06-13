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
            Music expectedMusic = new Music() { Title = "test", FileName = "test.mp3", Artists = new List<string>() { "Maxime" }, Duration =  7,};
            Music actualMusic = new MusicDAO().GetMusicDetails("test.mp3");

            Assert.AreEqual(expectedMusic, actualMusic);
        }

        [TestMethod]
        public void GetMusicDetails_Test_KO_Title()
        {
            Music expectedMusic = new Music() { Title = "test5", FileName = "test.mp3", Artists = new List<string>() { "Maxime" }, Duration = 7, };
            Music actualMusic = new MusicDAO().GetMusicDetails("test.mp3");

            Assert.AreNotEqual(expectedMusic, actualMusic);
        }
        
        [TestMethod]
        public void GetMusicDetails_Test_KO_Artists()
        {
            Music expectedMusic = new Music() { Title = "test", FileName = "test.mp3", Artists = new List<string>() { "Michel" }, Duration = 7, };
            Music actualMusic = new MusicDAO().GetMusicDetails("test.mp3");

            Assert.AreNotEqual(expectedMusic, actualMusic);
        }

        [TestMethod]
        public void GetMusicDetails_Test_KO_Duration()
        {
            Music expectedMusic = new Music() { Title = "test", FileName = "test.mp3", Artists = new List<string>() { "Maxime" }, Duration = 6, };
            Music actualMusic = new MusicDAO().GetMusicDetails("test.mp3");

            Assert.AreNotEqual(expectedMusic, actualMusic);
        }

        #endregion
    }
}
