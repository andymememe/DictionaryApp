using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryAPI.Test
{
    [TestFixture]
    public class DictionaryAPITest
    {
        private MockApiClient _client;

        [SetUp]
        public void SetUp()
        {
            _client = new MockApiClient();
        }

        [Test]
        public async Task DictionaryAPIOkNotChsPhrase()
        {
            string result = "";

            _client.SetType(MockApiClient.Type.OkNotChsPhrase);
            result = await DictionaryAPIConnection.GetResult(_client, "zho", "eng", "中文");
            Assert.AreEqual("English", result);
        }

        [Test]
        public async Task DictionaryAPIOkChsPhrase()
        {
            string result = "";

            _client.SetType(MockApiClient.Type.OkChsPhrase);
            result = await DictionaryAPIConnection.GetResult(_client, "eng", "zho", "Taiwan");
            Assert.AreEqual("簡化字", result);
        }

        [Test]
        public async Task DictionaryAPIOkNotChsMeaning()
        {
            string result = "";

            _client.SetType(MockApiClient.Type.OkNotChsMeaning);
            result = await DictionaryAPIConnection.GetResult(_client, "eng", "eng", "Taiwan");
            Assert.AreEqual("English meaning", result);
        }

        [Test]
        public async Task DictionaryAPIOkChsMeaning()
        {
            string result = "";

            _client.SetType(MockApiClient.Type.OkChsMeaning);
            result = await DictionaryAPIConnection.GetResult(_client, "zho", "zho", "中文");
            Assert.AreEqual("簡化字", result);
        }

        [TearDown]
        public void TearDown()
        {
            _client = null;
        }
    }
}
