namespace APBD_CW12.DTOs;


public class TripDTO
{
    public String Name { get; set; }
    public String Description { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int MaxPeople { get; set; }
    
    public List<CountryDTO> IdCountries { get; set; }
    public List<ClientDTO> IdClients { get; set; }
    
}

public class CountryDTO
{
    public String Name { get; set; }
}

public class ClientDTO
{
    public String FirstName { get; set; }
    public String LastName { get; set; }
}