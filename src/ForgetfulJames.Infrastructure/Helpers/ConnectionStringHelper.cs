using ForgetfulJames.Domain.Options;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ForgetfulJames.Infrastructure.Helpers
{
    /// <summary>
    /// Helps build a SQL ConnectionString.
    /// </summary>
    public class ConnectionStringHelper
    {
        /// <summary>
        /// The formatted SQL ConnectionString.
        /// </summary>
        public string ConnectionString { get; private set; } = string.Empty;

        private readonly IConfiguration? _configuration;
        private readonly ConnectionStringsOptions? _options;

        /// <summary>
        /// Build the SQL ConnectionString using <cref=IConfiguration>IConfiguration</cref>.
        /// </summary>
        /// <param name="configuration"></param>
        public ConnectionStringHelper(IConfiguration configuration) 
        {
            _configuration = configuration;
            BuildWithConfiguration();
        }

        /// <summary>
        /// Build the SQL ConnectionString using <cref=IOptions>Options Pattern</cref>
        /// </summary>
        /// <param name="options"></param>
        public ConnectionStringHelper(IOptions<ConnectionStringsOptions> options) 
        {
            _options = options.Value;
            BuildWithOptions();
        }

        private void BuildWithConfiguration()
        {
            if (_configuration == null)
                return;

            Build(_configuration.GetConnectionString("DefaultConnection")!, _configuration.GetConnectionString("Password")!, _configuration.GetConnectionString("UserId")!);
        }

        private void BuildWithOptions()
        {
            if (_options == null)
                return;

            Build(_options.DefaultConnection, _options.Password, _options.UserId);
        }

        private void Build(string connectionString, string password, string userId)
        {
            var builder = new SqlConnectionStringBuilder()
            {
                ConnectionString = connectionString,
                Password = password,
                UserID = userId,
            };

            ConnectionString = builder.ConnectionString;
        }
    }
}
