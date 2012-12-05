using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using win8CoffeeXAML.Model;
namespace win8CoffeeXAML.ViewModel
{
    class FakeResultsModel : BaseViewModel
    {
        public FakeResultsModel()
        {
            this.Results = new System.Collections.ObjectModel.ObservableCollection<Result>     
            {               
                new Result {Image="images/Coffee01.jpg", City = "Orange", Title = "Starbucks", Address="123 Main"}, 
                new Result {Image="images/Coffee02.jpg", City = "Rancho", Title = "Pintos Coffee", Address="101 Long St"},
                new Result {Image="images/Coffee03.jpg", City = "Irvine", Title = "Jonny Coffee", Address="222 Hope St"},  
                new Result {Image="images/Coffee04.jpg", City = "Los Angeles", Title = "Petes Coffee", Address="Happy Trails Drive"},                 
                new Result {Image="images/Coffee05.jpg", City = "Mission Viejo", Title = "Starbucks", Address="7748 Starry Way"},                
                new Result {Image="images/Coffee06.jpg", City = "Park City", Title = "Red Dawn Coffee House", Address="5628 Orange Ave"},       
                new Result {Image="images/Coffee07.jpg", City = "Elgin", Title = "Starbucks", Address="22 State "}, 
                new Result {Image="images/Coffee08.jpg", City = "Streamwood", Title = "Egan Cafe", Address="455 E Ocean Blvd"},       
                new Result {Image="images/Coffee09.jpg", City = "Los Angeles", Title = "Petes Coffee", Address="Happy Trails Drive"}, 
                new Result {Image="images/Coffee10.jpg", City = "Mission Viejo", Title = "Starbucks", Address="7748 Starry Way"},                 
                new Result {Image="images/Coffee11.jpg", City = "Park City", Title = "Red Dawn Coffee House", Address="5628 Orange Ave"},   
                new Result {Image="images/Coffee12.jpg", City = "Elgin", Title = "Starbucks", Address="22 State "},   
            };
        }
    }
}