using Microsoft.AspNetCore.Mvc.Testing;

namespace TestProject1;

public class CustomFixture
{
    public string Name { get; set; } = Guid.NewGuid().ToString();
}