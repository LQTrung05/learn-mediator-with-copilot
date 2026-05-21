using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace BookingPaymentSystem
{
    // DTO representing a booking/room
    public record BookingDto
    {
        public int Id { get; init; }
        public string RoomNumber { get; init; } = string.Empty;
        public bool IsAvailable { get; init; }
        public decimal PricePerNight { get; init; }
    }

    // Query definition
    public class GetAvailableBookingsQuery : IRequest<List<BookingDto>>
    {
        // Add filters here if needed in future (e.g., date range, capacity)
    }

    // Handler that returns mock data
    public class GetAvailableBookingsHandler : IRequestHandler<GetAvailableBookingsQuery, List<BookingDto>>
    {
        public Task<List<BookingDto>> Handle(GetAvailableBookingsQuery request, CancellationToken cancellationToken)
        {
            // Mock data - only available rooms
            var mock = new List<BookingDto>
            {
                new BookingDto { Id = 1, RoomNumber = "101", IsAvailable = true, PricePerNight = 75.00m },
                new BookingDto { Id = 2, RoomNumber = "102", IsAvailable = true, PricePerNight = 80.00m },
                new BookingDto { Id = 3, RoomNumber = "201", IsAvailable = true, PricePerNight = 95.50m },
                new BookingDto { Id = 4, RoomNumber = "202", IsAvailable = true, PricePerNight = 110.00m }
            };

            return Task.FromResult(mock);
        }
    }
}
