using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Archie.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using CryptoAPI.Models;

namespace CryptoAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<CryptoAPIContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CryptoAPIContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            HttpClient client = new HttpClient();
            

            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(1);

            var timer = new System.Threading.Timer(async(e) =>
            {

                try
                {
                    HttpResponseMessage response = await client.GetAsync("https://coinroom.com/api/ticker/BTC/PLN");
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    TickerStorage ticker = JsonConvert.DeserializeObject<TickerStorage>(responseBody);

                    System.Data.SqlClient.SqlConnection sqlConnection1 =
                    new System.Data.SqlClient.SqlConnection("Server = tcp:syrakuza.database.windows.net,1433; Initial Catalog = Syrakuza; Persist Security Info = False; User ID = olasek; Password = Pwr183767; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ");

                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO TickerStorage(low, high, vwap, volume, last, ask, bid)   VALUES(@param1, @param2, @param3, @param4, @param5, @param6, @param7)";

                    cmd.Parameters.AddWithValue("@param1", ticker.low);
                    cmd.Parameters.AddWithValue("@param2", ticker.high);
                    cmd.Parameters.AddWithValue("@param3", ticker.vwap);
                    cmd.Parameters.AddWithValue("@param4", ticker.volume);
                    cmd.Parameters.AddWithValue("@param5", ticker.last);
                    cmd.Parameters.AddWithValue("@param6", ticker.ask);
                    cmd.Parameters.AddWithValue("@param7", ticker.bid);



                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection1.Close();
                }
                catch (HttpRequestException err)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", err.Message);
                }
            }, null, startTimeSpan, periodTimeSpan);
        }

    }
}
