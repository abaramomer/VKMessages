using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VKMessages.Core;
using VKMessages.Core.Models;

namespace VKMessages.Tests
{
    [TestClass]
    public class ResponseSerializerTests
    {
        private string messagesInJson =
            @"{""response"": [113,{	""mid"": 125715,	""date"": 1470688112,	""out"": 1,	""uid"": 91894291,	""read_state"": 1,	""title"": "" ... "",	""body"": ""firstMessage""},{	""mid"": 125687,	""date"": 1470685209,	""out"": 1,	""uid"": 21754971,	""read_state"": 0,	""title"": "" ... "",	""body"": ""secondMessage""},{	""mid"": 125681,	""date"": 1470684269,	""out"": 1,	""uid"": 139648415,	""read_state"": 1,	""title"": "" ... "",	""body"": ""haha""}] }";
        private ResponseDeserializer deserializer;

        [TestMethod]
        public void Deserialize_JsonMessages_ReturnsMessageObjects()
        {
            deserializer = new ResponseDeserializer();

            var result = deserializer.Deserialize<Dialog>(messagesInJson);

            result.First().IsMy.Should().Be(true);
            result.Last().Text.Should().Be("haha");
            result[1].DialogId.Should().Be("2175497");
        }
    }
}
