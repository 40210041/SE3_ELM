using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ELM_40210041;

namespace ELM_Test
{
    [TestClass]
    public class UnitTest1
    {
        //check append lists is tweet
        [TestMethod]
        public void checkType_InputIsTweet_ReturnTrue()
        {
            // arrange
            var mainWindow = new MainWindow();
            string typeistweet = "Tweet";
            // act
            var result = mainWindow.checkType_Tweet(typeistweet);
            // assert
            Assert.IsTrue(result);
        }

        //check append lists is not tweet
        [TestMethod]
        public void checkType_InputIsNotTweet_ReturnFalse()
        {
            // arrange
            var mainWindow = new MainWindow();
            string typeistweet = "Tweeet";
            // act
            var result = mainWindow.checkType_Tweet(typeistweet);
            // assert
            Assert.IsFalse(result);
        }

        //checks body type is sms
        [TestMethod]
        public void check_BodyType_IsSMS_IsEqual()
        {
            // arrange
            var mainWindow = new MainWindow();
            string bodyContent_SMS = "SMS";
            int generatedID_SMS = 123456789;
            // act
            var result = mainWindow.check_BodyType(bodyContent_SMS, generatedID_SMS);
            // assert
            Assert.AreEqual(2,result);
        }

        //check body type is tweet
        [TestMethod]
        public void check_BodyType_IsTweet_IsEqual()
        {
            // arrange
            var mainWindow = new MainWindow();
            string bodyContent_Tweet = "Tweet";
            int generatedID_Tweet = 123456789;
            // act
            var result = mainWindow.check_BodyType(bodyContent_Tweet, generatedID_Tweet);
            // assert
            Assert.AreEqual(1, result);
        }

        //check body type email
        [TestMethod]
        public void check_BodyType_IsEMail_IsEqual()
        {
            // arrange
            var mainWindow = new MainWindow();
            string bodyContent_EMail = "E-Mail";
            int generatedID_EMail = 123456789;
            // act
            var result = mainWindow.check_BodyType(bodyContent_EMail, generatedID_EMail);
            // assert
            Assert.AreEqual(3, result);
        }
    }
}
