// Copyright (c) SoftwareOne. All Rights Reserved.

namespace BlogEngine
{
	using Microsoft.AspNetCore.Authentication.JwtBearer;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;
    using Microsoft.Identity.Web;
    using Microsoft.IdentityModel.Tokens;
	using BlogEngine.Api.Config;
    using BlogEngine.Api.Filters;
    using BlogEngine.Business;
	using BlogEngine.Business.Interfaces;
	using BlogEngine.Repository;
	using BlogEngine.Repository.Filters;
	using BlogEngine.Repository.Interfaces;
	using System.Text;

	/// <summary>
	/// Startup.
	/// </summary>
	public class Startup
	{
		/// <summary>
		/// Configuration Interface property.
		/// </summary>
		public IConfiguration Configuration { get; }

		/// <summary>
		/// Startup constructor
		/// </summary>
		/// <param name="configuration">Application configuration</param>
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		/// <summary>
		/// This method gets called by the runtime. Use this method to add services to the container.
		/// </summary>
		/// <param name="services">Service Collection Interface.</param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddApplicationInsightsTelemetry();
			services.AddMvc();
			services.AddMvc(opt => opt.Filters.Add(typeof(ValidateModelAttribute)));
		
			services.AddTransient<IBlogEngineBusiness, BlogEngineBusiness>();
			services.AddTransient<IBlogEngineRepository, BlogEngineRepository>();

			services.AddControllers();
			services.AddScoped(typeof(DapperManager<>));
			services.AddScoped<TokenValidate>();
			ConfigureCorsService(ref services);
			services.AddRegistrationSwagger();
			
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
					.AddMicrosoftIdentityWebApi(options =>
					{
						Configuration.Bind("AzureAdB2C", options);

						options.TokenValidationParameters.NameClaimType = "name";
					},
			options => { Configuration.Bind("AzureAdB2C", options); });		
		}

		/// <summary>
		/// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		/// </summary>
		/// <param name="app"></param>
		/// <param name="env"></param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseStaticFiles();
			app.AddRegistration();

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthentication();//B2C
			app.UseAuthorization();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			ConfigureCorsApp(ref app);
			app.UseAuthentication();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}

		/// <summary>
		/// Configure CORS Service.
		/// </summary>
		/// <param name="services"></param>
		private void ConfigureCorsService(ref IServiceCollection services)
		{
			// Enables CORS and httpoptions
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy", builder =>
				{
					builder.AllowAnyOrigin();
					builder.AllowAnyHeader();
					builder.AllowAnyMethod();
					builder.WithHeaders("authorization", "accept", "content-type", "origin");
					builder.SetIsOriginAllowed((_) => true);
				});
			});
			services.AddRouting(r => r.SuppressCheckForUnhandledSecurityMetadata = true);
		}

		/// <summary>
		/// Configure Cors App.
		/// </summary>
		/// <param name="app"></param>
		private void ConfigureCorsApp(ref IApplicationBuilder app)
		{
			app.UseCors("CorsPolicy");
		}
	}
}
