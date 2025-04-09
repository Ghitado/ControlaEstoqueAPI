namespace ControlaEstoque.Communication.Requests.User;

public record RequestRegisterUserJson(
    string Name,
    string Email,
    string Password 
);
