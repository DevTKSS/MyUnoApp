using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnoApp.Services.XamlRootProvider;
public interface IXamlRootProvider
{
    public  XamlRoot? GetXamlRoot();
    public  void InitializeRoot(XamlRoot XamlRoot);
}
