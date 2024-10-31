using MyUnoApp.Styles;

namespace MyUnoApp.Presentation;

public sealed partial class MainPage : Page
{
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
                                .Name(out var DialogResultOutput)
                                .AutomationProperties(automationId: "DialogResultOutput")
                                .Text(x => x.Binding(() => vm.DialogResult).Mode(BindingMode.OneWay))
                        )
                )
            );
    }

    private void MainPage_Loaded(object sender, RoutedEventArgs e )
    {
        XamlRootService.Initialize(this.XamlRoot!);
    }
    

}
