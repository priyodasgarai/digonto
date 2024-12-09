using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using digonto.Data;
using digonto.Middleware;
using digonto.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace digonto.DependencyInjection
{
    public static class ServiceContainer
    {
         public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration Configuration)
        {
            //For Database
            string connectionString = "DefaultConnection";
            services.AddDbContext<ApplicationDBContext>(Options =>
                        Options.UseSqlServer(Configuration.GetConnectionString(connectionString),
                        sqlOptions =>
                        {
                            //Ensure this is the correct assemble
                            sqlOptions.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName);
                            sqlOptions.EnableRetryOnFailure(); //Enaple automatic retries for transient failures
                        })
                       // .UseExceptionProcessor()
                        , ServiceLifetime.Scoped);

           // services.AddScoped(typeof(IAppLogger<>), typeof(SerilogLoggerAdapter<>));
           // services.AddScoped<IFileService, FileService>();
            // services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
            // services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();

            return services;
        }
         public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration Configuration)
        {
            //var config = new IConfiguration();
            // services.AddAutoMapper(typeof(MappingConfig));
            // services.AddScoped<IProductRepository, ProductRepository>();
            // services.AddScoped<ICategoryRepository, CategoryRepository>();
            // services.AddScoped<IBrandRepository, BrandRepository>();
            // 

            // services.AddScoped<IRoleManagement, RoleManagement>();
            // services.AddScoped<ITokenManagement, TokenManagement>();
            // services.AddScoped<IUserManagement, UserManagement>();

            //For Identity 
        /*    services.AddDefaultIdentity<AppUser>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
                options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultProvider;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            }).AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDBContext>();


            //Adding Authentication
            services.AddAuthentication(options =>
                   {
                       options.DefaultAuthenticateScheme =
                       options.DefaultChallengeScheme =
                        options.DefaultForbidScheme =
                       options.DefaultScheme =
                        options.DefaultSignInScheme =
                        options.DefaultSignOutScheme =
                       JwtBearerDefaults.AuthenticationScheme;
                   })//Adding JWT Bearer
            .AddJwtBearer(Options =>
                {
                    Options.SaveToken = true;
                    Options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidIssuer = Configuration["JWT:Issuer"],
                        ValidAudience = Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey
                        (
                            Encoding.UTF8.GetBytes(Configuration["JWT:Signingkey"])
                        ),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        RequireExpirationTime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                }); */
            return services;
        }


        public static IApplicationBuilder UserInfrastructructureService(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            return app;
        }


    }
}