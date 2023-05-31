namespace ForgetfulJames.Domain.Options
{
    public class JwtTokenOptions
    {
        public double Expires { get; set; }
        public string Secret { get; set; } = string.Empty;
    }
}
