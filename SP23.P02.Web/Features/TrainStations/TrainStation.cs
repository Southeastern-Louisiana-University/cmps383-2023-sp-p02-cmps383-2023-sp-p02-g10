using SP23.P02.Web.Features.Authorization;

namespace SP23.P02.Web.Features.TrainStations;

public class TrainStation
{
    public int Id { get; set; }

    public string? Name { get; set; } 

    public string? Address { get; set; }

    public int?  ManagerId { get; set; }

    public virtual User? Manager { get; set; }
}