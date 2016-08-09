using System;

namespace VKMessages.Core.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ResponcePropertyNameAttribute : Attribute
    {
        public string Name { get; private set; }

        public ResponcePropertyNameAttribute(string name)
        {
            Name = name;
        }
    }
}