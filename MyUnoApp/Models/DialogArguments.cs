using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnoApp.Models;
public record DialogArguments(string Title, object Content, string? PrimaryButtonText = "OK", string? SecondaryButtonText = null,string? CloseButtonText = null);
