# How to highlight the tapped view in ItemTemplate in Xamarin.Forms ListView (SfListView)

You can set the background color of each view loaded inside the [ItemTemplate](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~ItemTemplate.html?) when tapped the view in Xamarin Forms [SfListView](https://help.syncfusion.com/xamarin/listview/overview?).

The following article explains you ItemTemplate customization.
https://www.syncfusion.com/kb/11235/how-to-highlight-the-tapped-view-in-itemtemplate-in-xamarin-forms-listview-sflistview 

**XAML**
``` xml
<syncfusion:SfListView x:Name="listView"
    ItemSpacing="1" ItemSize="120"
    ItemsSource="{Binding contactsinfo}">
    <syncfusion:SfListView.ItemTemplate>
        <DataTemplate>
            <Grid>
                <Grid.Behaviors>
                    <local:Behavior/>
                </Grid.Behaviors>
                <Grid.RowDefinitions>
                    <RowDefinition Height="*"/>
                    <RowDefinition Height="*"/>
                    <RowDefinition Height="2"/>
                </Grid.RowDefinitions>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="50"/>
                        <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>
                    <Image Source="{Binding ContactImage}"/>
                    <StackLayout Grid.Column="1" Padding="0, 10, 0, 0">
                        <Label Text="{Binding ContactName}" VerticalOptions="Center"/>
                        <Label Text="{Binding ContactNumber}" VerticalOptions="Center"/>
                    </StackLayout>
                </Grid>
                <Grid Grid.Row="1">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="Auto"/>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>
                    <Label Text="Availability" Margin="5,0,0,0" FontSize="15" HorizontalOptions="Start" VerticalOptions="Center"/>
                    <Button x:Name="Button1" CornerRadius="10" Text="Busy" FontSize="10" BackgroundColor="{Binding Availability, Converter={StaticResource backgroundColorConverter}, ConverterParameter={x:Reference Button1}}" Grid.Column="1"/>
                    <Button x:Name="Button2" CornerRadius="10" Text="Available" FontSize="10" BackgroundColor="{Binding Availability, Converter={StaticResource backgroundColorConverter}, ConverterParameter={x:Reference Button2}}" Grid.Column="2"/>
                    <Button x:Name="Button3" CornerRadius="10" Text="Away" FontSize="10" BackgroundColor="{Binding Availability, Converter={StaticResource backgroundColorConverter}, ConverterParameter={x:Reference Button3}}" Grid.Column="3"/>
                </Grid>
                <StackLayout Grid.Row="2" BackgroundColor="DarkGray"/>
            </Grid>
        </DataTemplate>
    </syncfusion:SfListView.ItemTemplate>
</syncfusion:SfListView>
```
**C#**

Property updated based on the view content when you tap the view.
``` c#
public class Behavior : Behavior<Grid>
{
    Button Button1;
    Button Button2;
    Button Button3;
 
    protected override void OnAttachedTo(Grid bindable)
    {
        Button1 = bindable.FindByName<Button>("Button1");
        Button2 = bindable.FindByName<Button>("Button2");
        Button3 = bindable.FindByName<Button>("Button3");
 
        Button1.Clicked += OnClicked;
        Button2.Clicked += OnClicked;
        Button3.Clicked += OnClicked;
 
        base.OnAttachedTo(bindable);
    }
 
    private void OnClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var bc = button.BindingContext as Contacts;
 
        if (button.Text == "Yes")
            bc.Availability = true;
        else if (button.Text == "No")
            bc.Availability = false;
        else
            bc.Availability = null;
    }
}
```
**C#**

Handled the color of the view by the value of view content.
``` c#
public class BackgroundColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var button = parameter as Button;
 
        if ((bool?)value == null && button.Text == "Busy")
            return Color.Red;
        else if ((bool?)value == true && button.Text == "Available")
            return Color.YellowGreen;
        else if ((bool?)value == false && button.Text == "Away")
            return Color.Orange;
        else
            return Color.Transparent;
    }
 
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
```
