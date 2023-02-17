namespace MusicStore.Entities;
public class Genre
{
    public int ID { get; set; }
    public string Name { get; set; } = default!; // A partir de Net se puede inicializar String con valor vacio
    public bool Status { get; set; }

}
