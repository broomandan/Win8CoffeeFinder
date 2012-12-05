using win8CoffeeXAML.Common;
using win8CoffeeXAML.Model;
using System.Collections.ObjectModel;

public class BaseViewModel : BindableBase
{
    public ObservableCollection<Result> Results { get; set; }
}