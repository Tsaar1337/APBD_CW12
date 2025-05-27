using APBD_CW12.DTOs;

namespace APBD_CW12.Services;

public interface ITripsService
{
    Task<TripsWithPagesDTO> GetTrips(int page, int pageSize);
    
}