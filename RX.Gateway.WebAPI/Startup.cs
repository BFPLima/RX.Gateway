using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RX.Gateway.Repository;
using RX.Gateway.Repository.EF;
using RX.Gateway.Repository.Interface;
using RX.Gateway.Service;
using RX.Gateway.Service.Interface;

namespace RX.Gateway.WebAPI
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
            services.AddMvc();

            services.AddDbContext<RxGatewayDbContext>(optionsBuilder => optionsBuilder.UseMySql("Server=localhost;User Id=root;Password=root123456;Database=RxGateway"));

            services.AddTransient<IUnityOfWork, UnitOfWork>();

            services.AddTransient<IAcquirierRepository, AcquirierRepository>();
            services.AddTransient<IAntiFraudRepository, AntiFraudRepository>();
            services.AddTransient<ICreditCardTransactionRepository, CreditCardTransactionRepository>();
            services.AddTransient<IShopkeeperRepository, ShopkeeperRepository>();
            services.AddTransient<IStoreRepository, StoreRepository>();

            services.AddTransient<IAcquirierService, AcquirierService>();
            services.AddTransient<IAntiFraudService, AntiFraudService>();
            services.AddTransient<ICreditCardTransactionService, CreditCardTransactionService>();
            services.AddTransient<IShopkeeperService, ShopkeeperService>();
            services.AddTransient<IStoreService, StoreService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
