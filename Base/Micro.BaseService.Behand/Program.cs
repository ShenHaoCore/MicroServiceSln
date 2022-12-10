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
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); // ���л�ʱKEYΪ�շ���ʽ
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; // ����ѭ������
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
    typeof(CommonEnum.ApiVersion).GetEnumNames().ToList().ForEach(version => { options.SwaggerDoc(version, new OpenApiInfo { Title = "����΢����", Version = version.ToString(), Description = $"����΢����{version}�汾" }); });
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
        typeof(CommonEnum.ApiVersion).GetEnumNames().ToList().ForEach(version => { options.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"�汾{version}"); });
        options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None); //����ΪNone���۵����з���
        //options.RoutePrefix = BaseConst.RoutePrefix;
        options.DefaultModelsExpandDepth(0); // ����Ϊ-1 �ɲ���ʾModels
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();