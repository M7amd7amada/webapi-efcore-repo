using Api.Extensions;

var app = WebApplication.CreateBuilder().ConfigureServices().Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapControllers();
app.MapGet("/errors", () => "Error!");

await app.RunAsync();