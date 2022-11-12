using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using VukManic.EncryptorApp.Core.AES;

namespace VukManic.EncryptorApp.Core.Module
{
    public static class EncryptorCoreModule
    {
        public static void AddEncryptorApp(this IServiceCollection services)
        {
            services.AddScoped<IEncryptionStrategy, AesEncryptionStrategy>();
            services.AddScoped<IEncryptionApp, EncryptionApp>();
        }
    }
}
