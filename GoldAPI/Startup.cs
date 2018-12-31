using System;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Linq;

namespace GoldAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_ => Configuration);
            services.AddSingleton<CatalogContext>(_ => new CatalogContext(Configuration.GetConnectionString("archiedb")));
            /*services.AddSingleton(Configuration);
            // DbContext using an InMemory database provider
            var connectionString = "connection string to database";
            try
            {
                services.AddDbContext<CatalogContext>(options => options.UseSqlServer(Configuration.GetConnectionString("archiedb")));
            }
            catch { throw new IndexOutOfRangeException(); }
            services.AddDbContext<CatalogContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("archiedb")));*/
            services.AddDbContext<CatalogContext>(options =>
            {
                options.UseSqlServer(Configuration["archiedb"],
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 10,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
                });
            });

            //(Alternative: DbContext using a SQL Server provider
            /*services.AddDbContext<GoldAPIContext>(Configuration =>
            {
                Configuration.UseSqlServer(this.Configuration["ConnectionString"]);
            });
            services.AddDbContext<GoldAPIContext>(opt => opt.UseInMemoryDatabase());*/


            services.AddMvc();

            if (!services.Any(x => x.ServiceType == typeof(CatalogContext)))
            {
                // Service doesn't exist, do something
                Console.WriteLine("nie ma takiej uslugi");
                throw new System.InvalidOperationException("nie ma takiej uslugi");
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {   
            //wywolanie tworzenia tabel i danych na polaczonej bazie danych
          
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
                  
            app.UseMvc();
            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("archiedb")))
            {
                conn.Open(); // throws if invalid
            }
            // Other Configure code...
            // Seed data through our custom class


            GoldAPIContextSeed.SeedAsync(app)
                .Wait();
            //app.ApplicationServices.
            var context = (CatalogContext)app
               .ApplicationServices.GetService(typeof(CatalogContext));
           /* using (context)
            {
                context.Database.Migrate();
                if (!context.SpotAPI.Any())
                {
                    context.SpotAPI.AddRange(
                        GetPreconfiguredSpots());
                    await context.SaveChangesAsync();
                }
            }*/
            // Other Configure code...
            /*
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(60);

            var timer = new System.Threading.Timer(async (e) =>
            {
                
                try
                {
                    HttpResponseMessage response = await client.GetAsync("http://services.packetizer.com/spotprices/?f=json");
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {

               
                        JObject jObject = JObject.Parse(responseBody);
                        SpotAPI apiresponse = new SpotAPI();

                        apiresponse.dateInput = (DateTime)jObject["date"];
                        apiresponse.goldVal = (decimal)jObject["gold"];
                        apiresponse.silverVal = (decimal)jObject["silver"];
                        apiresponse.platiniumVal = (decimal)jObject["platinum"];


                        System.Data.SqlClient.SqlConnection sqlConnection1 =
                        new System.Data.SqlClient.SqlConnection((Configuration.GetConnectionString("GoldAPIContext")));

                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "INSERT INTO SpotsAPI(dateInput,goldVal,platiniumVal,silverVal) VALUES (@param1, @param2, @param3, @param4)";

                        cmd.Parameters.AddWithValue("@param1", (DateTime)apiresponse.dateInput);
                        cmd.Parameters.AddWithValue("@param2", (double)apiresponse.goldVal);
                        cmd.Parameters.AddWithValue("@param3", (double)apiresponse.silverVal);
                        cmd.Parameters.AddWithValue("@param4", (double)apiresponse.platiniumVal);

                      
                        cmd.Connection = sqlConnection1;

                        sqlConnection1.Open();
                        cmd.ExecuteNonQuery();
                        sqlConnection1.Close();
                    }
                    else
                        Console.WriteLine("404 - dont found http");
                }
                catch (HttpRequestException err)
                {
                    Console.WriteLine("\nError");
                    Console.WriteLine("Message :{0} ", err.Message);
                }
            }, null, startTimeSpan, periodTimeSpan);*/
        }
    }
}
