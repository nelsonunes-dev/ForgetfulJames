namespace ForgetfulJames.Domain.Options
{
    public class InfrastructureOptions
    {
        public bool RunMigrations { get; set; }
        public bool SeedDatabase { get; set; }
        public bool UseMockData { get; set; }
    }
}
