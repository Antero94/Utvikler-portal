namespace Utvikler_portal.Auth.ValueObjects;

public record Email
{
    public string value { get; }
    private static readonly int MaxLength =100;

    private Email(string value)
    {
        this.value = value;
    }

    public static Email Create(string value)
    {
        return new Email(value);
    }
}