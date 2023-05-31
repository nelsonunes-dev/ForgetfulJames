namespace ForgetfulJames.Domain.Constants
{
    public static class Resources
    {
        public const string Mock = "mock";
        public const string Seeding = "seeding";
        public const string Extension = "json";

        public static string GetSeedingFileName(Type type, bool mockData = false)
        {
            return mockData ? $"{type.Name}.{Seeding}.{Mock}.{Extension}".ToLower() : $"{type.Name}.{Seeding}.{Extension}".ToLower();
        }
    }
}
