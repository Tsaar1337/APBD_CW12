namespace APBD_CW12.DTOs;

public class TripsWithPagesDTO
{
    public int pageNum { get; set; }
    public int pageSize { get; set; }
    public int allPages { get; set; }
    public ICollection<TripDTO> trips { get; set; }
}