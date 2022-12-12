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
    //AddNewtonsoftJson 导入Microsoft.aspnetcore.Mvc.NewtonsoftJson来加入的
    setupAction.UseCamelCasing(true);
    setupAction.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(op =>
{

    op.SwaggerDoc("v1", new OpenApiInfo { Title = "Jason Soft", Version = "v1", Description = "Json综合管理平台WebApi V1" });

    string basePath = AppDomain.CurrentDomain.BaseDirectory;
    string[] files = Directory.GetFiles(Path.Combine(basePath, "SwaggerXml"), "*.xml");
    foreach (string file in files)
        op.IncludeXmlComments(file);

    //../Jason.TestDemo.WebApi/SwaggerXml/JasonModels.xml
    op.OperationFilter<SecurityRequirementsOperationFilter>();
    //region Token绑定到ConfigureServices，swagger右上角显示Token输入框
    op.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
        Name = "Authorization",//jwt默认的参数名称
        In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
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
