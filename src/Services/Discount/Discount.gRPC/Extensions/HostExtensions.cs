using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Discount.gRPC.Extensions
{
    public static class HostExtensions
    {
        /// <summary>
        /// Database Migrations with Seeding default data
        /// </summary>
        /// <param name="host"></param>
        /// <param name="retry"></param>
        /// <typeparam name="TContext"></typeparam>
        /// <returns></returns>
        public static IHost MigrateDatabase<TContext>(this IHost host, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var configuration = services.GetRequiredService<IConfiguration>();
                var logger = services.GetRequiredService<ILogger<TContext>>();

                try
                {
                    logger.LogInformation("Migrating postresql database.");

                    using var connection = new NpgsqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
                    connection.Open();

                    using var command = new NpgsqlCommand
                    {
                        Connection = connection
                    };

                    DropCouponTable(command, logger);

                    CreateCouponTable(command, logger);

                    SeedCouponTableData(command, logger);

                    logger.LogInformation("Migrated postresql database.");
                }
                catch (NpgsqlException ex)
                {
                    logger.LogError(ex, "An error occurred while migrating the postresql database");

                    if (retryForAvailability < 50)
                    {
                        retryForAvailability++;
                        System.Threading.Thread.Sleep(2000);
                        MigrateDatabase<TContext>(host, retryForAvailability);
                    }
                }
            }

            return host;
        }

        /// <summary>
        /// Drop Coupon Table if already exists
        /// </summary>
        /// <param name="command"></param>
        /// <param name="logger"></param>
        /// <typeparam name="TContext"></typeparam>
        private static void DropCouponTable<TContext>(NpgsqlCommand command, ILogger<TContext> logger)
        {
            logger.LogInformation("Dropping Coupon Table if already existse.");
            command.CommandText = "DROP TABLE IF EXISTS Coupon";
            command.ExecuteNonQuery();
            logger.LogInformation("Dropping Coupon Table done.");
        }

        /// <summary>
        /// Create Coupon Table shema
        /// </summary>
        /// <param name="command"></param>
        /// <param name="logger"></param>
        /// <typeparam name="TContext"></typeparam>
        private static void CreateCouponTable<TContext>(NpgsqlCommand command, ILogger<TContext> logger)
        {
            logger.LogInformation("Creating Coupon Table shema.");
            command.CommandText = @"CREATE TABLE Coupon(Id SERIAL PRIMARY KEY, 
                                                                ProductName VARCHAR(24) NOT NULL,
                                                                Description TEXT,
                                                                Amount INT)";
            command.ExecuteNonQuery();
            logger.LogInformation("Creating Coupon Table shema done.");
        }

        /// <summary>
        /// Seed Coupon Table initial data
        /// </summary>
        /// <param name="command"></param>
        /// <param name="logger"></param>
        /// <typeparam name="TContext"></typeparam>
        private static void SeedCouponTableData<TContext>(NpgsqlCommand command, ILogger<TContext> logger)
        {
            logger.LogInformation("Seeding Coupon Table initial data.");
            command.CommandText = "INSERT INTO Coupon(ProductName, Description, Amount) VALUES('IPhone X', 'IPhone Discount', 150);";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO Coupon(ProductName, Description, Amount) VALUES('Samsung 10', 'Samsung Discount', 100);";
            command.ExecuteNonQuery();
            logger.LogInformation("Seeding Coupon Table initial data done.");
        }
    }
}