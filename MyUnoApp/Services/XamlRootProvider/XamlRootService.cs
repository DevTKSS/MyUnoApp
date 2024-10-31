using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnoApp.Services.XamlRootProvider;
internal class XamlRootService /*: IXamlRootProvider*/
{
    private static  XamlRoot? _xamlRoot;

    public static void Initialize(XamlRoot XamlRoot)
    {
        _xamlRoot = XamlRoot;
    }

    public static XamlRoot GetXamlRoot()
    {
        if (_xamlRoot == null)
        {
            throw new InvalidOperationException("XamlRoot has not been initialized. Call Initialize() first.");
        }
        return _xamlRoot;
    }
}
