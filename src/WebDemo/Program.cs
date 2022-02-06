using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using WebDemo.Cache;
using WebDemo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<CacheHandler>();
builder.Services.AddSingleton<MemoryCache>();
builder.Services.AddSwaggerGen(w =>
{
    w.SwaggerDoc("V1", new OpenApiInfo
    {
        Title = "Swagger docs",
        Version = "V1"
    });
    w.UseInlineDefinitionsForEnums();
});
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(allowIntegerValues: true));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();
if (app.Environment.IsDevelopment())
{
    app.MapSwagger();
    app.UseSwagger();
    app.UseSwaggerUI(ui =>
    {
        ui.SwaggerEndpoint("V1/swagger.json", "Swagger docs");
    });
}
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
