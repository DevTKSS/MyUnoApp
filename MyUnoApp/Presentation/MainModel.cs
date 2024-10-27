using System.Runtime.CompilerServices;

namespace MyUnoApp.Presentation;

public partial record MainModel
{
    private INavigator _navigator;

    public MainModel(
        IOptions<AppConfig> appInfo,
        INavigator navigator)
    {
        _navigator = navigator;
        Title = "Main";
        Title += $" - {appInfo?.Value?.Environment}";
    }

    public string? Title { get; }

    public IState<string> Name => State<string>.Value(this, () => string.Empty);

    public IState<string> DialogResult => State<string>.Value(this, () => string.Empty);

    public async Task GoToSecond()
    {
        var name = await Name;
        await _navigator.NavigateViewModelAsync<SecondModel>(this, data: new Entity(name!));
    }

    public async Task ShowDialogAsync(XamlRoot xamlRoot,
                                      string title,
                                      string message,
                                      string primaryButtonText,
                                      string? secondaryButtonText = null,
                                      string? closeButtonText = null)
    {
        ContentDialog dialog = new ContentDialog
        {
            Title = title,
            Content = message,
            PrimaryButtonText = primaryButtonText,
            SecondaryButtonText = secondaryButtonText,
            CloseButtonText = closeButtonText,
            XamlRoot = xamlRoot,
        };
        if (secondaryButtonText is not null)
        {
            dialog.SecondaryButtonText = secondaryButtonText;
        }
        if (closeButtonText is not null)
        {
            dialog.CloseButtonText = closeButtonText;
        }
        ContentDialogResult result = await dialog.ShowAsync();

        await DialogResult.SetAsync(result switch
        {
            ContentDialogResult.Primary => primaryButtonText,
            ContentDialogResult.Secondary => secondaryButtonText ?? "secondaryButton",
            _ => closeButtonText
        });
    }
}
