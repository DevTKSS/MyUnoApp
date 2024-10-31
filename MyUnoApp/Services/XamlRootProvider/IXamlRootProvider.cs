using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnoApp.Services;
internal interface IXamlRootProvider
{
    public  XamlRoot GetXamlRoot();
    public  void Initialize(XamlRoot XamlRoot);
}
