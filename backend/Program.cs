using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace B2BSaaSApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<InsightsContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public class InsightsContext : DbContext
    {
        public InsightsContext(DbContextOptions<InsightsContext> options) : base(options) { }

        public DbSet<Insight> Insights { get; set; }
    }

    public class Insight
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Source { get; set; }
        public string Date { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class InsightsController : ControllerBase
    {
        private readonly InsightsContext _context;

        public InsightsController(InsightsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Insight>>> GetInsights()
        {
            return await _context.Insights.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Insight>> PostInsight(Insight insight)
        {
            _context.Insights.Add(insight);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInsights), new { id = insight.Id }, insight);
        }
    }
}
