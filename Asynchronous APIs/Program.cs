using Asynchronous_APIs.Data;
using Asynchronous_APIs.Dtos;
using Asynchronous_APIs.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(
    "Data Source=RequestDB.db"
    ));

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.MapPost("/api/products", async (AppDbContext db, ListingRequest listingReuest) =>
{
    if(listingReuest == null) 
        return Results.BadRequest();

    listingReuest.RequestStatus = "ACCEPT";
    listingReuest.EstimatedCompetionTime = "2023-02-06 14:00:00";

    await db.ListingRequests.AddAsync(listingReuest);
    await db.SaveChangesAsync();

    return Results.Accepted($"api/productstatus/{listingReuest.RequestId}",
        listingReuest);
});

app.MapGet("api/productstatus/{requestId}", (AppDbContext db, string requestId) =>
{
    var request = db.ListingRequests.FirstOrDefault(x => x.RequestId == requestId);

    if (request == null)
        return Results.NotFound();

    ListingStatus listStatus = new ListingStatus
    {
        RequestStatus = request.RequestStatus,
        ResourceURL = string.Empty
    };

    if (request.RequestStatus!.ToUpper() == "COMPLETE")
    {
        listStatus.ResourceURL = $"api/products/{Guid.NewGuid().ToString()}";

        return Results.Redirect($"https://localhost:7189/{listStatus.ResourceURL}");
    }

    listStatus.EstimatedCompetionTime = "2023-02-16:15:00:00";
    return Results.Ok(request);
});

app.MapGet("api/products/{requestId}", (string requestId) =>
{
    return Results.Ok("This is where you would pass back the final result");
});


app.Run();
