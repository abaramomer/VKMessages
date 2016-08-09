using System;

namespace VKMessages.Core.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ResponsePropertyAttribute : Attribute
    {
        public string Name { get; private set; }


        public ResponsePropertyAttribute(string name)
        {
            Name = name;
        }
    }
}