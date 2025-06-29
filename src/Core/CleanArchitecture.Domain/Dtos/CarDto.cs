namespace CleanArchitecture.Domain.Dtos;

public class CarDto 
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public int Power { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime CreatedDate { get; set; }
}

