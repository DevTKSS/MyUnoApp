using MyUnoApp.Styles;

namespace MyUnoApp.Presentation;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.DataContext<MainViewModel>((page, vm) => page
            .NavigationCacheMode(NavigationCacheMode.Required)
            .Background(Theme.Brushes.Background.Default)
            .Content(new Grid()
                .SafeArea(SafeArea.InsetMask.VisibleBounds)
                .RowDefinitions("Auto,*")
                .Children(
                    new NavigationBar().Content(() => vm.Title),
                    new StackPanel()
                        .Grid(row: 1)
                        .HorizontalAlignment(HorizontalAlignment.Center)
                        .VerticalAlignment(VerticalAlignment.Center)
                        .Spacing(16)
                        .Children(
                            new TextBox()
                                .Text(x => x.Binding(() => vm.Name).Mode(BindingMode.TwoWay))
                                .PlaceholderText("Enter your name:"),
                            new Button()
                                .Content("Go to Second Page")
                                .AutomationProperties(automationId: "SecondPageButton")
                                .Command(() => vm.GoToSecond),
                            new Button()
                                .Name(out var GoRightButton)
                                .Content("Let's go right")
                                .AutomationProperties(automationId: "GoRightButton")
                                .Command(() => vm.ShowDialogAsync)
                               // .CommandParameter(this.XamlRoot!)
                                ),
                        new TextBlock()
                            .Name (out var DialogTextBlock)
                            .Style(Theme.TextBlock.Styles.DisplayMedium)
                            .AutomationProperties(automationId: "DialogResultOutput")
                            .Text(x => x.Binding(() => vm.DialogResult)
                                                .Mode(BindingMode.OneWay))
                        )
                )
            );
    }
}

    //public async Task ShowDialogAsync()
    //{
    //    try
    //    {
    //        ContentDialog dialog = new ContentDialog
    //        {
    //            Title = "Some Title",
    //            Content = "Some Content",
    //            PrimaryButtonText = "OK",
    //            XamlRoot = XamlRootService.GetXamlRoot(),
    //            DefaultButton = ContentDialogButton.Primary
    //        };

    //        var result = await dialog.ShowAsync();
    //        if (result == ContentDialogResult.Primary)
    //        {
    //            await DialogResult.SetAsync(dialog.PrimaryButtonText);
    //        }
    //        else
    //        {
    //            await DialogResult.SetAsync("Canceled");
    //        }
    //        //await DialogResult.SetAsync(result switch
    //        //{
    //        //    ContentDialogResult.Primary => "OK",
    //        //    _ => "Canceled",
    //        //});
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"ShowDialogAsync got exception: {ex.Message}");
    //    }
    //}

    //private async void GoRight_Click(object sender, RoutedEventArgs e)
    //{
    //    ContentDialog dialog = new ContentDialog()
    //                                .Style(Theme.ContentDialog.Styles.Default)
    //                                .Title("Save your Work?")
    //                                .Content(
    //                                    new StackPanel()
    //                                          .VerticalAlignment(VerticalAlignment.Stretch)
    //                                          .HorizontalAlignment(HorizontalAlignment.Stretch)
    //                                          .Children(
    //                                                new TextBlock()
    //                                                    .Text("Lorem ipsum dolor sit amet, adipisicing elit.")
    //                                                    .TextWrapping(TextWrapping.Wrap),
    //                                                new CheckBox()
    //                                                    .Content("Upload your content to the cloud")
    //                                                    ))
    //                                .PrimaryButtonText("Save")
    //                                .SecondaryButtonText("Don't Save")
    //                                .CloseButtonText("Cancel")
    //                                .DefaultButton(ContentDialogButton.Primary);
    //dialog.XamlRoot = this.XamlRoot;

    //    var result = await dialog.ShowAsync();


    //    if (result == ContentDialogResult.Primary)
    //    {
    //        DialogResult.Text = "User saved their work";
    //    }
    //    else if (result == ContentDialogResult.Secondary)
    //    {
    //        DialogResult.Text = "User did not save their work";
    //    }
    //    else
    //    {
    //        DialogResult.Text = "User cancelled the dialog";
    //    }
    //}

    //private async Task ShowContentDialog()
    //{
    //    ContentDialog dialog = new ContentDialog()
    //                                .Style(Theme.ContentDialog.Styles.Default)
    //                                .Title("Save your Work?")
    //                                .Content(
    //                                    new StackPanel()
    //                                          .VerticalAlignment(VerticalAlignment.Stretch)
    //                                          .HorizontalAlignment(HorizontalAlignment.Stretch)
    //                                          .Children(
    //                                                new TextBlock()
    //                                                    .Text("Lorem ipsum dolor sit amet, adipisicing elit.")
    //                                                    .TextWrapping(TextWrapping.Wrap),
    //                                                new CheckBox()
    //                                                    .Content("Upload your content to the cloud")
    //                                                    ))
    //                                .PrimaryButtonText("Save")
    //                                .SecondaryButtonText("Don't Save")
    //                                .CloseButtonText("Cancel")
    //                                .DefaultButton(ContentDialogButton.Primary);
    //    dialog.XamlRoot = this.XamlRoot;

    //    var result = await dialog.ShowAsync();

    //    if (result == ContentDialogResult.Primary)
    //    {
    //        DialogResult.Text = "User saved their work";
    //    }
    //    else if (result == ContentDialogResult.Secondary)
    //    {
    //        DialogResult.Text = "User did not save their work";
    //    }
    //    else
    //    {
    //        DialogResult.Text = "User cancelled the dialog";
    //    }
    //}

