namespace YuGiOhApi.Exceptions;

public class NotFoundException: Exception
{
    public NotFoundException(): base(message: "Not Found") { }
}
