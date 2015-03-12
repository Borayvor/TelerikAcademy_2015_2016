namespace E04_VersionAttribute
{
    using System;

    [AttributeUsage(AttributeTargets.Struct |
        AttributeTargets.Class | AttributeTargets.Interface |
        AttributeTargets.Enum | AttributeTargets.Method,
        AllowMultiple = false)]
    public class VersionAttribute : System.Attribute
    {
        public int major { get; private set; }
        public int minor { get; private set; }

        public VersionAttribute(int major, int minor)
        {
            if (major < 0 || minor < 0)
            {
                throw new ArgumentException("Version can not be a negative number !");
            }
            this.major = major;
            this.minor = minor;
        }

        public override string ToString()
        {
            return string.Format("{0}.{1}", major, minor);
        }
    }
}
