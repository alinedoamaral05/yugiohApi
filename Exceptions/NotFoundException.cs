namespace YuGiOhApi.Exceptions;

public class NotFoundException: Exception
{
    public string Name { get; set; }

    public NotFoundException(string name): base(message: $"{name} was not found") 
    {
        Name = name;
    }
}
