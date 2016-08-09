using System;
using System.Collections.Generic;

namespace VKMessages.Core.Models
{
    public class Converters
    {
        public readonly Dictionary<Type, Func<string, object>> ConverterDictionary =
            new Dictionary<Type, Func<string, object>>()
            {
                {typeof(string), s => s},

                {typeof(bool), StringToBool}
            };

        private static object StringToBool(string val)
        {
            return val == "1";
        }
    }
}