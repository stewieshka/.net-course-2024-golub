namespace BankSystem.App.Exceptions;

public class MyValidationException(string name) 
    : Exception(message: $"Field {name} did not pass validation");