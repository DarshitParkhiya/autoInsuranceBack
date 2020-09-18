using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TestApi.Models.RequestModels;
using TestApi.Models.Settings;
using TestApi.Models.UserModels;
using TestApi.Models.RequestTypesModels;
using TestApi.Services.RequestRepo;
using TestApi.Services.RequestTypesRepo;
using TestApi.Services.UserRepo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TestApi.Services.Common;
using TestApi.Services.AssetRepo;
using TestApi.Models.AssetModels;
using TestApi.Services.StudentRepo;
using TestApi.Models.StudentModels;
using TestApi.Services.AdminRepo;
using TestApi.Models.AdminModels;

namespace TestApi
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            BootstrapDependency(services);
            services.AddControllers();
            //services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAll");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        private void BootstrapDependency(IServiceCollection services)
        {
            var config = Configuration.GetSection("ConnectionStrings");

            services.Configure<ApiConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            services.AddSingleton<IApiConnectionStrings>(cs => BuildApiConnectionStrings());
            services.AddSingleton<IAppSettings>(cs => BuildAppSettings());

            services.AddSingleton(new WebAppConfiguration());

            services.AddTransient(typeof(ICommonRepository<>), typeof(CommonRepository<>));
            services.AddTransient(typeof(ICommonService<>), typeof(CommonService<>));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService<User>, UserService>();

            services.AddTransient<IRequestRepository, RequestRepository>();
            services.AddTransient<IRequestService<Request>, RequestService>();

            services.AddTransient<IRequestTypeRepository, RequestTypeRepository>();
            services.AddTransient<IRequestTypeService<RequestType>, RequestTypeService>();

            services.AddTransient<IAssetRepository, AssetRepository>();
            services.AddTransient<IAssetService<Asset>, AssetService>();

            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IStudentService<Student>, StudentService>();

            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IAdminService<Admin>, AdminService>();


        }
    }
}
