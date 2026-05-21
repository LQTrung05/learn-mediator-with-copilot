using BookingPaymentSystem;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

app.MapGet("/", () => "Booking & Payment System with Mediator already!");

app.MapGet("/api/bookings", async (MediatR.IMediator mediator) =>
{
	// Sends a GetAvailableBookingsQuery through MediatR and returns the result
	var result = await mediator.Send(new GetAvailableBookingsQuery());
	return Results.Ok(result);
});

app.Run();