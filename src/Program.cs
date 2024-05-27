using HttpClientBestPractice.API.Integration.Wrapper;
using HttpClientBestPractice.API.Integration.Wrapper.Contract;
using Microsoft.Net.Http.Headers;
using Refit;

var builder = WebApplication.CreateBuilder(args);

#region HttpClient

#region Basic usage

builder.Services.AddHttpClient();

#endregion Basic usage

#region Named clients

builder.Services.AddHttpClient("GitHub", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api.github.com/");

    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.Accept, "application/vnd.github.v3+json");

    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.UserAgent, "HttpRequestsSample");

    // ...
});

#endregion Named clients

#region Typed clients

builder.Services.AddHttpClient<ProductNotificationWrapper_TypedClient>(httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api.github.com/");

    httpClient.DefaultRequestHeaders.Add(
                HeaderNames.Accept, "application/vnd.github.v3+json");

    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.UserAgent, "HttpRequestsSample");

    // ...
});

#endregion Typed clients

#region Generated clients

builder.Services.AddRefitClient<IProductNotificationWrapper_GeneratedClient>()
    .ConfigureHttpClient(httpClient =>
    {
        httpClient.BaseAddress = new Uri("https://api.github.com/");

        httpClient.DefaultRequestHeaders.Add(
            HeaderNames.Accept, "application/vnd.github.v3+json");

        httpClient.DefaultRequestHeaders.Add(
            HeaderNames.UserAgent, "HttpRequestsSample");

        // ...
    });

#endregion Generated clients

#endregion HttpClient

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
