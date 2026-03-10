namespace lab03;

public class MenuItem
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Id { get; set; }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Price)}: {Price}, {nameof(Id)}: {Id}";
    }
}