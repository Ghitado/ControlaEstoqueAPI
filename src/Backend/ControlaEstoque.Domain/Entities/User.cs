namespace ControlaEstoque.Domain.Entities;

public class User : Entity
{
    public bool Active { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
