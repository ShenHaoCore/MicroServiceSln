using Autofac;
using Autofac.Extensions.DependencyInjection;
using Micro.BaseService.Behand;
using Micro.BaseService.Model;
using Micro.Common;
using Micro.Framework;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers(option =>
{
    //option.UseCentralRoutePrefix(new RouteAttribute(BaseConst.RoutePrefix));
    option.Filters.Add<GlobalExceptionFilter>();
}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); // 序列化时KEY为驼峰样式
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; // 忽略循环引用
    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());
builder.Services.AddSingleton(new AppSetting(builder.Configuration));
builder.Services.AddLogging(cfg => { cfg.AddLog4Net(new Log4NetProviderOptions() { Log4NetConfigFileName = "Config/log4net.config", Watch = true }); });
builder.Services.AddSwaggerGen(options =>
{
    var filePath = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
    if (File.Exists(Path.Combine(AppContext.BaseDirectory, filePath))) { options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, filePath), true); }
    typeof(CommonEnum.ApiVersion).GetEnumNames().ToList().ForEach(version => { options.SwaggerDoc(version, new OpenApiInfo { Title = "基础微服务", Version = version.ToString(), Description = $"基础微服务{version}版本" }); });
});
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => { builder.RegisterModule<AutofacAutowiredModule>(); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        typeof(CommonEnum.ApiVersion).GetEnumNames().ToList().ForEach(version => { options.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"版本{version}"); });
        options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None); //设置为None可折叠所有方法
        //options.RoutePrefix = BaseConst.RoutePrefix;
        options.DefaultModelsExpandDepth(0); // 设置为-1 可不显示Models
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();