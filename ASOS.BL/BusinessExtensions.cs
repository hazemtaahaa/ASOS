using ASOS.DAL.Context;
using ASOS.DAL.Repositories.Brand;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ASOS.BL;

namespace ASOS.DAL;

public static class BusinessExtensions
{
    public static void AddBusinessServices(this IServiceCollection services,IConfiguration configuration)
    { 
        services.AddScoped<IMenManager, MenManager>();
    }
}
