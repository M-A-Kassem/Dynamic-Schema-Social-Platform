
using Dynamic_Schema_Social_Platform.Data.DataSeeding;
using Dynamic_Schema_Social_Platform.Data.DBContext;
using Dynamic_Schema_Social_Platform.Enteties;
using Dynamic_Schema_Social_Platform.IRepo;
using Dynamic_Schema_Social_Platform.Repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dynamic_Schema_Social_Platform
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            builder.Services.AddIdentity<User, IdentityRole<int>>()
             .AddEntityFrameworkStores<AppDbContext>()
             .AddDefaultTokenProviders();


            builder.Services.AddScoped<ITalentTypeService, TalentTypeService>();
            builder.Services.AddScoped<ITalentAttributeService, TalentAttributeService>();
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<IUserTalentService, UserTalentService>();
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider
                    .GetRequiredService<UserManager<User>>();
                var roleManager = scope.ServiceProvider
                    .GetRequiredService<RoleManager<IdentityRole<int>>>();

                await Roles.SeedAdminAsync(userManager, roleManager);
            }
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
