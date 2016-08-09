using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VKMessages.Core;

namespace VKMessages.Tests
{
    [TestClass]
    public class ResponseSerializerTests
    {
        private string messagesInJson =
            @"{""response"": [113,{	""mid"": 125715,	""date"": 1470688112,	""out"": 1,	""uid"": 91894291,	""read_state"": 1,	""title"": "" ... "",	""body"": ""да. он такой. если его увижу в противогазе так все понятно станет)""},{	""mid"": 125687,	""date"": 1470685209,	""out"": 1,	""uid"": 21754971,	""read_state"": 0,	""title"": "" ... "",	""body"": ""но это покс. машину все равно еще не скоро приобрету""},{	""mid"": 125681,	""date"": 1470684269,	""out"": 1,	""uid"": 139648415,	""read_state"": 1,	""title"": "" ... "",	""body"": ""ахахаха""}] }";
        private ResponseSerializer serializer; 

        [TestMethod]
        public void Deserialize_JsonMessages_ReturnsMessageObjects()
        {
            serializer = new ResponseSerializer();

            var result = serializer.Deserialize(messagesInJson);
        }
    }
}
