using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EntityDemo_pv03_SKe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void BtnDatanHaku_Click(object sender, RoutedEventArgs e)
        {
            //aluksi tarvitaan entiteetti-objekti, joka luotiin EF-mallin luonnin yhteydessä
            //kun ilmoitettiin, mihin tietokantaan halutaan olla yhteydessä
            //Löytyy: Solution Expl - NorthwindModel - NorthwindModel.Context:n alta
            //entiteetti-objekti sisältää tiedot db:n tauluista

            northwindEntities entities = new northwindEntities();

                                 //from c  => c on Customer-taulun aliasointi
            var finnishCustomers = from c in entities.Customers
                                   where c.Country == "Finland"
                                   select c;

                      // cust = "tulostus"muuttujan nimi
            foreach (var cust in finnishCustomers)
            {
                MessageBox.Show($"Asiakas: {cust.CompanyName} \r\n" +
                    $"Yhteyshenkilö: {cust.ContactName}");
            }
        }
    }
}
