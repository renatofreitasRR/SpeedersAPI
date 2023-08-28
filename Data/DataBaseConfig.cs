namespace SpeedersAPI.Data
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, string connectionString)
        {
            //services.AddDbContext<AppDbContext>(b => b.UseSqlServer(connectionString));

            return services;
        }
    }
}
