namespace MyUnoApp.Services.XamlRootProvider;
public class XamlRootProvider : IXamlRootProvider
{
    public XamlRootProvider(ILogger? logger = null)
    {
        _logger = logger;
    }

    private readonly ILogger? _logger;
    private static  XamlRoot? _xamlRoot;

    public void InitializeRoot(XamlRoot XamlRoot)
    {
        _xamlRoot = XamlRoot;
        _logger?.LogTraceMessage("XamlRoot has been initialized.");
    }

    public XamlRoot? GetXamlRoot()
    {
        if (_xamlRoot == null) _logger?.LogErrorMessage("XamlRoot has not been initialized. Call Initialize first.");
       
        return _xamlRoot;
    }
}
