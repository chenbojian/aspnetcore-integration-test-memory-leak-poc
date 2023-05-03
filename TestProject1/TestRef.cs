using Microsoft.AspNetCore.Mvc.Testing;

namespace TestProject1;

public class TestRef
{
    public static List<WeakReference<CustomFixture>> Fixtures = new();
    public static List<WeakReference<WebApplicationFactory<Program>>> Factories = new();
}