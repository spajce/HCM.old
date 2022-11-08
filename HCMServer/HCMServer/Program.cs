using System;
using System.Data;
using System.Reflection;
using System.Text;
using Audit.Domain;
using AutoMapper;
using HCM.Domain;
using HCMServer.AutoMapper;
using HCMServer.Helpers;
using HCM.Application.Swagger;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MySqlConnector;
using NLog;
using NLog.Web;
using ProtoBuf.Meta;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebApiContrib.Core.Formatter.Protobuf;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;
using HCM.Application;
using HCM.Application.Repositories.Audits;
using HCM.Application.Repositories.Employees;
using HCM.Application.Services.Employees;
using Microsoft.AspNetCore.Http;

NLog.Logger logger;

string OS;
if (System.OperatingSystem.IsLinux())
{
    OS = "Linux";
    logger = NLogBuilder.ConfigureNLog("nlog.linux.config").GetCurrentClassLogger();
}
else if (System.OperatingSystem.IsWindows())
{
    OS = "Windows";
    logger = NLogBuilder.ConfigureNLog("nlog.windows.config").GetCurrentClassLogger();
}
else
{
    throw new Exception("The Operating System may not supported");
}
logger.Debug($"init main - {OS}");


try
{
    var builder = WebApplication.CreateBuilder(args);

    #region Json Configuration
    var cfgBuilder = new ConfigurationBuilder().AddJsonFile(builder.Environment.IsProduction() ? "appsettings.json" : "appsettings.Development.json", true, true);
    var configuration = cfgBuilder.Build();
    builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("Tokens"));
    //builder.Services.Configure<FileServerConfig>(configuration.GetSection("FileServerConfig"));
    #endregion

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    var config = builder.Configuration.GetSection("Logging");
    builder.Logging.AddConfiguration(config);
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    if (builder.Environment.IsProduction())
    {
        builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);
    }
    else // Development
    {
        builder.Logging.AddConsole();
        builder.Logging.AddDebug();
    }
    builder.Host.UseNLog();

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    #region Content File Limit Config
    // REF: https://github.com/dotnet/aspnetcore/issues/20369#issuecomment-607057822
    builder.Services.Configure<IISServerOptions>(options =>
    {
        options.MaxRequestBodySize = int.MaxValue;
    });

    builder.Services.Configure<KestrelServerOptions>(options =>
    {
        options.Limits.MaxRequestBodySize = int.MaxValue; // if don't set default value is: 30 MB
    });

    builder.Services.Configure<FormOptions>(x =>
    {
        x.ValueLengthLimit = int.MaxValue;
        x.MultipartBodyLengthLimit = int.MaxValue; // if don't set default value is: 128 MB
        x.MultipartHeadersLengthLimit = int.MaxValue;
    });
    #endregion

    #region Auto Mapper Configurations
    var mapperConfig = new MapperConfiguration(mc =>
    {
        mc.AddProfile(new MappingDtoToModelProfile());
        mc.AddProfile(new MappingEntityToDtoProfile());
        mc.AddProfile(new MappingModelToRequestProfile());
    });

    IMapper mapper = mapperConfig.CreateMapper();
    builder.Services.AddSingleton(mapper);
    #endregion

    builder.Services.AddDirectoryBrowser();

    builder.Services.AddControllers()
         .AddNewtonsoftJson()
         .AddProtobufFormatters();

    builder.Services.AddControllersWithViews();
    builder.Services.AddRazorPages();

    // Configure the Application Cookie
    //services.ConfigureApplicationCookie(c => {
    //    // Override the default events
    //    c.Events = new CookieAuthenticationEvents
    //    {
    //        OnRedirectToAccessDenied = ReplaceRedirectorWithStatusCode(HttpStatusCode.Forbidden),
    //        OnRedirectToLogin = ReplaceRedirectorWithStatusCode(HttpStatusCode.Unauthorized)
    //    };

    //    // Customize other stuff as needed
    //    c.Cookie.Name = ".applicationname";
    //    c.Cookie.HttpOnly = true; // This must be true to prevent XSS
    //    c.Cookie.SameSite = SameSiteMode.None;
    //    c.Cookie.SecurePolicy = CookieSecurePolicy.None; // Should ideally be "Always"

    //    c.SlidingExpiration = true;
    //});

    builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

    #region Swagger and Versioning Config
    builder.Services.AddApiVersioning(options =>
    {
        // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
        options.ReportApiVersions = true;
    });

    builder.Services.AddVersionedApiExplorer(options =>
    {
        // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
        // note: the specified format code will format the version as "'v'major[.minor][-status]"
        options.GroupNameFormat = "'v'VVV";

        // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
        // can also be used to control the format of the API version in route templates
        options.SubstituteApiVersionInUrl = true;
    });

    builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

    builder.Services.AddSwaggerGen(options =>
    {
        // add a custom operation filter which sets default values
        options.OperationFilter<SwaggerDefaultValues>();

        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);
    });

    #endregion

    var connectionString = builder.Configuration.GetConnectionString("HCMConnection");
    var audiConnectionString = builder.Configuration.GetConnectionString("HCMAuditConnection");

    #region Configure Identity
    //builder.Services.AddDbContext<ApplicationDbContext>(options =>
    //        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b => b.MigrationsAssembly("HCM")), ServiceLifetime.Scoped);

    //builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
    //{
    //    options.User.RequireUniqueEmail = true;

    //    options.Password.RequireDigit = true;
    //    options.Password.RequiredLength = 6;
    //    options.Password.RequireLowercase = false;
    //    options.Password.RequireNonAlphanumeric = false;
    //    options.Password.RequireUppercase = true;

    //    options.Lockout.AllowedForNewUsers = true;
    //    //options.Lockout.DefaultLockoutTimeSpan = new TimeSpan(0, 0, 5);
    //    options.Lockout.MaxFailedAccessAttempts = 3;
    //})
    //.AddEntityFrameworkStores<ApplicationDbContext>()
    //.AddDefaultTokenProviders();

    #endregion

    #region JWT Authentication Config
    var signingKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Tokens:Key"]));
    builder.Services.AddAuthentication(opt =>
    {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(cfg =>
    {
        cfg.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Tokens:Issuer"],
            ValidAudience = builder.Configuration["Tokens:Issuer"],
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Tokens:Key"])),
            ClockSkew = TimeSpan.Zero,
        };
    });
    #endregion

    #region Authorization
    //builder.Services.AddAuthorization(options =>
    //{
    //    options.AddPolicy(Policy.Administrators,
    //       policy =>
    //       {
    //           policy.Requirements.Add(new UserRequirement(Role.SuperAdmin));
    //           policy.Requirements.Add(new UserRequirement(Role.Admin));
    //       });
    //});

    //builder.Services.AddScoped<IAuthorizationHandler, UserAuthorizationHandler>();
    #endregion

    #region DbContext Config

    builder.Services.AddEntityFrameworkMySql();

    builder.Services.AddDbContextPool<HCMDbContext>(options => options
                                                    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), mySqlOptions =>
                                                    {
                                                        //mySqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                                                        mySqlOptions.EnableRetryOnFailure(
                                                                            maxRetryCount: 10,
                                                                            maxRetryDelay: TimeSpan.FromSeconds(30),
                                                                            errorNumbersToAdd: null);
                                                    })
                                                    //.LogTo(Console.WriteLine, LogLevel.Information)
                                                    .EnableSensitiveDataLogging() // These two calls are optional but help
                                                    .EnableDetailedErrors());      // with debugging (remove for production).

    //builder.Services.AddDbContextPool<HCMStoredProcedureDbContext>(options => options
    //                                                       .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), mySqlOptions =>
    //                                                       {
    //                                                           //mySqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    //                                                           mySqlOptions.EnableRetryOnFailure(
    //                                                                           maxRetryCount: 10,
    //                                                                           maxRetryDelay: TimeSpan.FromSeconds(30),
    //                                                                           errorNumbersToAdd: null);
    //                                                       })
    //                                                       //.LogTo(Console.WriteLine, LogLevel.Information)
    //                                                       .EnableSensitiveDataLogging() // These two calls are optional but help
    //                                                       .EnableDetailedErrors());      // with debugging (remove for production).

    builder.Services.AddDbContextPool<AuditDbContext>(options => options
                                                               .UseMySql(audiConnectionString, ServerVersion.AutoDetect(audiConnectionString), mySqlOptions =>
                                                               {
                                                                   mySqlOptions.EnableRetryOnFailure(
                                                                                   maxRetryCount: 10,
                                                                                   maxRetryDelay: TimeSpan.FromSeconds(30),
                                                                                   errorNumbersToAdd: null);
                                                               })
                                                               .EnableSensitiveDataLogging() // These two calls are optional but help
                                                               .EnableDetailedErrors());      // with debugging (remove for production).
    #endregion

    // JWT Token
    //builder.Services.AddScoped<IJwtUtils, JwtUtils>();

    #region Register Services
    //builder.Services.AddScoped<IUserService, UserService>();


    #endregion

    #region Register Repository 
    //builder.Services.AddScoped<IAuditRepository, AuditRepository>();


    #endregion


    //builder.Services.Scan(scan => scan
    //      .FromAssemblyOf<IEmployeeService>() // Startup Interface

    //      .AddClasses(classes => classes.AssignableTo<IEmployeeService>())
    //      .AsMatchingInterface()
    //      .WithScopedLifetime()

    //      .AddClasses(classes => classes.AssignableTo<IAuditRepository>())
    //      .AsMatchingInterface()
    //      .WithScopedLifetime()

    //      .AddClasses(classes => classes.AssignableTo<IEmployeeRepository>())
    //      .AsMatchingInterface()
    //      .WithScopedLifetime()
    //);

    builder.Services.AddApplicationServices();

    //builder.Services.AddScoped<IAmazonS3, AmazonS3Client>();

    // HttpContext
    builder.Services.AddHttpContextAccessor();
    builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

    var app = builder.Build();

    #region middleware
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();

        app.UseSwagger(options => { options.RouteTemplate = "api-docs/{documentName}/docs.json"; });
        app.UseSwaggerUI(options =>
        {
            options.RoutePrefix = "api-docs";
            var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
            foreach (var description in provider.ApiVersionDescriptions)
                options.SwaggerEndpoint($"/api-docs/{description.GroupName}/docs.json", description.GroupName.ToUpperInvariant());
        });

        app.UseExceptionHandler(builder =>
        {
            // define brand new pipeline

            // handle all application exception
            builder.Run(async httpContext =>
            {
                var feature = httpContext.Features.Get<IExceptionHandlerPathFeature>();
                //ctx.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var statusCode = httpContext.Response.StatusCode;
                var exception = feature?.Error;

                static string invalidOperationException(InvalidOperationException e)
                {

                    if (e.Message.Contains("cannot be pooled"))
                    {
                        return $"Workaround: Removed Public Constructor in DbContext";
                    }

                    if (e.Message.Contains("is part of a key and so cannot be modified or marked as modified"))
                    {
                        return $"{e.Message}\n\nWorkaround: Check URL Parameter Id and Id of initialized entity must be the same";
                    }
                    return $"{e.Message}\n\nStack Trace: {e.StackTrace}";
                }

                static string mySqlException(MySqlException e)
                {

                    if (e.Message.Contains("Data too long for column"))
                    {
                        return $"{e.Message}\n\nThe data length of the column is greater than the expected";
                    }

                    return $"{e.Message}\n\nStack Trace: {e.StackTrace}";
                }

                static string dbUpdateException(Exception e)
                {
                    StringBuilder message = new StringBuilder();
                    if (e.Message != null)
                    {
                        message.Append(e.Message);
                    }
                    if (e.InnerException != null)
                    {
                        message.AppendLine();
                        message.Append(e.InnerException.Message);
                    }
                    if (e.StackTrace != null)
                    {
                        message.AppendLine();
                        message.Append(e.StackTrace);
                    }
                    return message.ToString();
                }

                var responseModel = await ResultModel.FailureAsync(new string[] { exception.Message });
               
                string message = exception switch
                {
                    //AmazonS3Exception e => $"{e.Message}",
                    ObjectDisposedException e => $"{e.Message}",
                    InvalidOperationException e => invalidOperationException(e),
                    DbUpdateException e => dbUpdateException(exception),
                    FileNotFoundException e => $"{e.Message}",
                    System.Linq.Dynamic.Core.Exceptions.ParseException e => $"{e.Message}",
                    MySqlException e => mySqlException(e),
                    _ => $"Something Went Wrong!\n{exception?.Message}\n{exception?.StackTrace}",
                };

                responseModel.Errors = new string[] { message };

                await httpContext.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(responseModel));

            });
        });
    }
    else
    {
        app.UseExceptionHandler(builder =>
        {
            // define brand new pipeline

            // handle all application exception
            builder.Run(async httpContext =>
            {
                var feature = httpContext.Features.Get<IExceptionHandlerPathFeature>();
                //ctx.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var statusCode = httpContext.Response.StatusCode;
                var exception = feature?.Error;

                static string? dbUpdateException(Exception e)
                {
                    if (e.Message.Contains("Database operation expected to affect 1 row(s) but actually affected 0 row(s)"))
                    {
                        return "Data may have been modified or deleted since entities were loaded, check the URL parameter";
                    }
                    if (e.InnerException != null)
                    {
                        if (e.InnerException.Message.StartsWith("Duplicate entry"))
                        {
                            return e.InnerException.Message;
                        }

                        if (e.InnerException.Message.StartsWith("Cannot delete or update a parent row"))
                        {
                            return "The data has been already assigned to entities";
                        }
                        return e.InnerException.Message;
                    }
                    return null;
                }

                static string? fileNotFoundException(FileNotFoundException e)
                {
                    if (e.Message.StartsWith("Could not find file"))
                    {
                        return "Could not find file"; // Todo: Get File Name also
                    }
                    return null;
                }

                var responseModel = await ResultModel.FailureAsync(new string[] { exception.Message });


                string message = exception switch
                {
                    //AmazonS3Exception e => $"Error Code -7, {e.Message}",
                    NullReferenceException e => $"Error Code -8, {e.Message}",
                    ObjectDisposedException e => $"Error Code -9",
                    ArgumentException e => $"Error Code -10, {e.ParamName} & {e.Message}",
                    DataException e => "Error Code -11",
                    ArithmeticException e => "Error Code -12",
                    MySqlException e => "Error Code -13",
                    InvalidOperationException e => "Error Code -14",
                    DbUpdateException e => $"Error Code -15, {dbUpdateException(exception)}",
                    FileNotFoundException e => $"Error Code -16, {fileNotFoundException(e)}",
                    System.Linq.Dynamic.Core.Exceptions.ParseException e => $"Error Code -17, {e.Message}",
                    _ => $"Error Code -1, Something Went Wrong!",
                };

                responseModel.Errors = new string[] { message };

                await httpContext.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(responseModel));
            });
        });

        app.UseHsts();
    }

    #endregion

    app.UseRequestLocalization();

    app.UseHttpsRedirection();

    app.UseDefaultFiles();

    // wwwroot system updates using squirrel, archiveds, css, JavaScript, and images don't require authentication.
    app.UseStaticFiles();
    //var contentTypeProvider = new FileExtensionContentTypeProvider();
    // Add new mappings
    //contentTypeProvider.Mappings[".nupkg"] = "application/zip";


    string squirrelHCMDesktopPath = string.Empty;
    string requestPathHCMDesktopArchived = string.Empty;

    string docImagesPath = string.Empty;
    string docImageRequestPath = string.Empty;

    string pdfThumbnailsPath = string.Empty;
    string requestPathPdfThumbnails = string.Empty;

    if (System.OperatingSystem.IsLinux())
    {
        squirrelHCMDesktopPath = "squirrel/HCMdesktop/archived";
        requestPathHCMDesktopArchived = "/HCMdesktop/archived";

        pdfThumbnailsPath = "pdf_thumbnails/temp";
        requestPathPdfThumbnails = "/temp";

        docImagesPath = "images/";
        docImageRequestPath = "/images";
    }

    if (System.OperatingSystem.IsWindows())
    {
        squirrelHCMDesktopPath = @"squirrel\HCMdesktop\archived\";
        requestPathHCMDesktopArchived = "/HCMdesktop/archived";

        pdfThumbnailsPath = @"pdf_thumbnails\temp\";
        requestPathPdfThumbnails = "/temp";

        docImagesPath = @"images\";
        docImageRequestPath = "/images";
    }

    if (builder.Environment.WebRootPath != null)
    {
        var squirrelHCMDesktopPackageDirectory = Path.Combine(builder.Environment.WebRootPath, squirrelHCMDesktopPath);

        if (!Directory.Exists(squirrelHCMDesktopPackageDirectory))
            Directory.CreateDirectory(squirrelHCMDesktopPackageDirectory);

        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(squirrelHCMDesktopPackageDirectory),
            RequestPath = requestPathHCMDesktopArchived,
            //ContentTypeProvider = contentTypeProvider,
            ServeUnknownFileTypes = true
        });

        app.UseDirectoryBrowser(new DirectoryBrowserOptions
        {
            FileProvider = new PhysicalFileProvider(squirrelHCMDesktopPackageDirectory),
            RequestPath = requestPathHCMDesktopArchived
        });

        var pdfThumbnailsDirectory = Path.Combine(builder.Environment.WebRootPath, pdfThumbnailsPath);

        if (!Directory.Exists(pdfThumbnailsDirectory))
            Directory.CreateDirectory(pdfThumbnailsDirectory);

        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(pdfThumbnailsDirectory),
            RequestPath = requestPathPdfThumbnails
        });

        var docImagesPackageDirectory = Path.Combine(builder.Environment.WebRootPath, docImagesPath);

        if (!Directory.Exists(docImagesPackageDirectory))
            Directory.CreateDirectory(docImagesPackageDirectory);

        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(docImagesPackageDirectory),
            RequestPath = docImageRequestPath
        });

        logger.Debug($"WebRoot {builder.Environment.WebRootPath} - {OS}");

    }
    logger.Debug($"WebRoot {builder.Environment.WebRootPath}");



    app.UseRouting();

    app.UseCors(x => x
       .SetIsOriginAllowed(origin => true)
       .AllowAnyMethod()
       .AllowAnyHeader()
       .AllowCredentials());

    //app.UseMiddleware<JwtMiddleware>();

    app.UseAuthentication();

    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
        //endpoints.MapControllerRoute(
        //    name: "default",
        //    pattern: "{controller=Home}/{action=Index}/{id?}");
        //endpoints.MapRazorPages();
        endpoints.MapDefaultControllerRoute();
    });


    app.Run();
}
catch (Exception ex)
{

    // NLog: catch setup errors
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}
