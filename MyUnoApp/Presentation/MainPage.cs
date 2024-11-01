using MyUnoApp.Styles;

namespace MyUnoApp.Presentation;

public sealed partial class MainPage : Page
{
    public IState<string> DialogResult => State<string>.Value(this, () => string.Empty); 
    public MainPage()
    {
        Loaded += MainPage_Loaded;
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
                                ),

                            //new DropDownButton()
                            //    .Name(out var btnDropThatDown)
                            //    .Content("Let's drop that down!")
                            //    .Flyout(
                            //        new MenuFlyout()
                            //            .Placement(FlyoutPlacementMode.Bottom)
                            //            .Items(
                            //                new MenuFlyoutItem()
                            //                    .Text("Let's go right!")
                            //                    .Icon(new FontIcon().Glyph("\uE72A"))
                            //                    .AutomationProperties(automationId: "Let's go right!")
                            //                    .Command(async() => 
                            //                    {
                            //                        btnDropThatDown.Flyout.Hide();
                            //                        await vm.ShowDialogAsync(this.XamlRoot,
                            //                                                "Some Intelligent Title",
                            //                                                "You dropped it down and gone right!",
                            //                                                "Go Back");
                            //                    }),

                            //                    new MenuFlyoutItem()
                            //                    .Text("Let's go left!")
                            //                    .Icon(new FontIcon().Glyph("\uE72B")),
                            //                new MenuFlyoutItem()
                            //                    .Text("Let's turn around!")
                            //                    .Icon(new FontIcon().Glyph("\uE72C"))
                            //                   )
                            //            ),
                            new TextBlock()
                                .Name (out var DialogResult)
                                .Style(Theme.TextBlock.Styles.DisplayMedium)
                                .AutomationProperties(automationId: "DialogResultOutput")
                                .Text(x => x.Binding(() => this.DialogResult).Mode(BindingMode.OneWay))
                        )
                )
            );
    }

    private void MainPage_Loaded(object sender, RoutedEventArgs e )
    {
        XamlRootService.Initialize(this.XamlRoot!);
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
}
