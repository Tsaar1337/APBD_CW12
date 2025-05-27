using APBD_CW12.Data;
using APBD_CW12.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace APBD_CW12.Services;

public class TripsService : ITripsService
{
    
    private readonly _2019sbdContext _context;
    
    public TripsService(_2019sbdContext context)
    {
        _context = context;
    }
    

    public async Task<TripsWithPagesDTO> GetTrips(int page, int pageSize )
    {
        page = page < 1 ? 1 : page;
        pageSize = pageSize < 1 ? 1 : pageSize;
        
        var tripsList = await _context.Trips.Skip((page - 1) * pageSize).Take(pageSize)
            .Select(t => new TripDTO
        {
            Name = t.Name,
            Description = t.Description,
            DateFrom = t.DateFrom,
            DateTo = t.DateTo,
            MaxPeople = t.MaxPeople,
            IdCountries = t.IdCountries.Select(c => new CountryDTO
            {
                Name = c.Name
            }).ToList(),
            IdClients = t.ClientTrips.Select(ct => new ClientDTO
            {
                FirstName = ct.IdClientNavigation.FirstName,
                LastName = ct.IdClientNavigation.LastName
            }).ToList()
        }).ToListAsync();




        return new TripsWithPagesDTO
        {
            pageNum = page,
            pageSize = pageSize,
            allPages = (int)Math.Ceiling(await _context.Trips.CountAsync() / (double)pageSize),
            trips = tripsList
        };
    }
}