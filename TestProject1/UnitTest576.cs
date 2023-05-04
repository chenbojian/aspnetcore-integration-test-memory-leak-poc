using Microsoft.AspNetCore.Mvc.Testing;
using WebApplication1;

namespace TestProject1;

public class UnitTest576 : IClassFixture<WebApplicationFactory<Program>>, IDisposable
{
    private readonly WebApplicationFactory<Program> factory;
    private readonly HttpClient defaultClient;

    public UnitTest576(WebApplicationFactory<Program> factory)
    {
        this.factory = factory;
        defaultClient = factory.CreateDefaultClient();
        TestRef.Factories.Add(new WeakReference<WebApplicationFactory<Program>>(factory));
    }

    [Fact]
    public void Test1()
    {
        System.GC.Collect();
        var factories = TestRef.Factories
            .Select(f =>
            {
                f.TryGetTarget(out var fac);
                return fac;
            })
            .ToList();

        Assert.Equal(factories.Where(f => f != null).ToList(), new[] { this.factory });

        var builders = Ref.Builders
            .Select(b =>
            {
                b.TryGetTarget(out var builder);
                return builder;
            })
            .ToList();
        
        Assert.Equal(1, builders.Count(b => b != null));

    }

    public void Dispose()
    {
        defaultClient.Dispose();
        factory.Server.Dispose();
        factory.Dispose();
    }

}