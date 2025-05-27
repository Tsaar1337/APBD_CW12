using APBD_CW12.Data;

namespace APBD_CW12.Services;

public class ClientsService : IClientsService
{
    private readonly _2019sbdContext _context;
    
    public ClientsService(_2019sbdContext context)
    {
        _context = context;
    }
    
    public async Task DeleteClient(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        
        if(client == null)
        {
            throw new KeyNotFoundException("Client not found");
        }

        if (client.ClientTrips.Any())
        {
            throw new ArgumentException("Client has trips");
        }
        
        
        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
    }
}