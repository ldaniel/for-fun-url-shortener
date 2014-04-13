using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaboURLShortner.Handlers;

namespace RaboURLShortner.Tests
{
    [TestClass]
    public class XMLHandlerTest
    {
        public readonly String givenId = "6ab5";

        [TestMethod]
        public void given_id_should_retrieve_a_url_object_with_the_same_id()
        {
            var returnedUrl = XMLHandler.GetURLByID(givenId);
            Assert.IsNotNull(returnedUrl);
            Assert.AreEqual(givenId, returnedUrl.Id);
        }

        [TestMethod]
        public void given_retrieve_the_id_given_a_hash()
        {
            var returnedUrl = XMLHandler.GetURLByID(givenId);
            var x = RaboURLShortner.Models.AlphabetTest.Encode(1);
            Assert.AreEqual("123", x);
        }
    }
}
