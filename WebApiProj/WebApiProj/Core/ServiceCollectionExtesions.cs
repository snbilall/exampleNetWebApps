using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProj.Core.Abstract;
using WebApiProj.Core.Repositories;
using WebApiProj.Core.UOW;

namespace WebApiProj.Core
{
    public static class ServiceCollectionExtesions
    {
        public static void AddRepositories(this IServiceCollection collection)
        {
            collection.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
