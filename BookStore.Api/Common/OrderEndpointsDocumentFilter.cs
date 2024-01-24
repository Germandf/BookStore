using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;

namespace BookStore.Api.Common;

public class OrderEndpointsDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var orderedPaths = swaggerDoc.Paths
            .OrderBy(entry => GetMethodOrder(entry.Value.Operations.FirstOrDefault().Key))
            .ThenBy(entry => entry.Key)
            .ToList();

        swaggerDoc.Paths.Clear();

        foreach (var path in orderedPaths)
        {
            swaggerDoc.Paths.Add(path.Key, path.Value);
        }
    }

    private int GetMethodOrder(OperationType? method)
    {
        switch (method)
        {
            case OperationType.Get:
                return 1;
            case OperationType.Post:
                return 2;
            case OperationType.Put:
                return 3;
            case OperationType.Patch:
                return 4;
            case OperationType.Delete:
                return 5;
            default:
                return 99;
        }
    }
}
