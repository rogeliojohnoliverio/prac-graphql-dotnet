using practice_graphql.Services;
using practice_graphql.Schema;
using Microsoft.EntityFrameworkCore;
using practice_graphql.Services.Students;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer().AddQueryType<Query>();
builder.Services.AddGraphQLServer().AddMutationType<Mutation>();
builder.Services.AddPooledDbContextFactory<SchoolDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<StudentsRepository>();
var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

using (IServiceScope scope = app.Services.CreateScope())
{
    IDbContextFactory<SchoolDbContext> contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<SchoolDbContext>>();
    using (SchoolDbContext context = contextFactory.CreateDbContext())
    {
        context.Database.Migrate();
    }
}

app.MapGet("/", () => "Hello World!");

app.Run();
