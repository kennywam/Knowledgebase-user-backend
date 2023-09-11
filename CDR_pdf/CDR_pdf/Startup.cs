using CDR_pdf.Data;
using IBM.EntityFrameworkCore;


namespace CDR_pdf
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();
        }

    }

}