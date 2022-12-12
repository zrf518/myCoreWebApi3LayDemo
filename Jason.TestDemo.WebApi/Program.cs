using Autofac;
using Autofac.Extensions.DependencyInjection;
using Jason.TestDemo.WebApi;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(setupAction =>
{
    //AddNewtonsoftJson ����Microsoft.aspnetcore.Mvc.NewtonsoftJson�������
    setupAction.UseCamelCasing(true);
    setupAction.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(op =>
{

    op.SwaggerDoc("v1", new OpenApiInfo { Title = "Jason Soft", Version = "v1", Description = "Json�ۺϹ���ƽ̨WebApi V1" });

    string basePath = AppDomain.CurrentDomain.BaseDirectory;
    string[] files = Directory.GetFiles(Path.Combine(basePath, "SwaggerXml"), "*.xml");
    foreach (string file in files)
        op.IncludeXmlComments(file);

    //../Jason.TestDemo.WebApi/SwaggerXml/JasonModels.xml
    op.OperationFilter<SecurityRequirementsOperationFilter>();
    //region Token�󶨵�ConfigureServices��swagger���Ͻ���ʾToken�����
    op.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���) ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�\"",
        Name = "Authorization",//jwtĬ�ϵĲ�������
        In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
        Type = SecuritySchemeType.ApiKey
    });
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule<AutoFacContainerInit>();
});

///// <summary>
///// AutoFact Container Init
///// </summary>

//public void ConfigureContainer(ContainerBuilder builder)
//{
//    builder.DependencyInJectionByAutoFact();
//}

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseSwaggerUI(op => {
    //    op.DocumentTitle = "JasonWebApi";
    //});
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
