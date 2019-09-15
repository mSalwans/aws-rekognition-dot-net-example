using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.Rekognition;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using rekognition.service;
using rekognition.service.Implementation;
using rekognition.service.Interfaces;

namespace rekognition_api_demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IConfiguration _config { get; }
        private AmazonRekognitionClient _rekognitionClient;


        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            string accessKey = _config["aws:keys:accessKey"];
            string secretKey = _config["aws:keys:secretKey"];

            _rekognitionClient = new AmazonRekognitionClient(
                accessKey, secretKey, RegionEndpoint.USEast1);

            services.AddSingleton<IDetectLabels>(provider => new DetectLabels(_rekognitionClient));
            services.AddSingleton<ICompareFaces>(provider => new CompareFaces(_rekognitionClient));
            services.AddSingleton<IImageToText>(provider => new ImageToText(_rekognitionClient));
            services.AddSingleton<IRecognizeCelebrities>(provider => new RecognizeCelebrities(_rekognitionClient));

            services.Configure<FormOptions>(options =>
            {
                options.MemoryBufferThreshold = Int32.MaxValue;
            });
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

            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
