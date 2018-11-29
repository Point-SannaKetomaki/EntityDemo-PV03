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
            //Alustetaan uusi instanssi mallioliosta, joka luotiin EF-mallin luonnin yhteydessä
            //Malliolio hoitaa kaiken tietokantakäsittelyn taustalla
            //Käytetään oletustietokantayhteyksiä, jotka määriteltiin, kun EF-malli luotiin
                //(Löytyy: Solution Expl - NorthwindModel - NorthwindModel.Context:n alta
                //entiteetti-objekti sisältää tiedot db:n tauluista)

            northwindEntities entities = new northwindEntities();


            //LINQ-kysely        //from c  => c on Customer-taulun aliasointi
            //tulosten haku tietokannasta ja tiedot tallennetaan muuttujaan finnishCustomers
            //var-tietotyyppi: kääntäjä "kehittää" sopivan tietotyypin tulosten perusteella, koodaajan ei tarvitse tietää tietotyyppiä
            var finnishCustomers = from c in entities.Customers
                                   where c.Country == "Finland"
                                   select c;

            //tulosten tulostaminen   // cust = "tulostus"muuttujan nimi
            foreach (var cust in finnishCustomers)
            {
                MessageBox.Show($"Asiakas: {cust.CompanyName} \r\n" +
                    $"Yhteyshenkilö: {cust.ContactName}");
            }
        }

        private void BtnLINQ_Click(object sender, RoutedEventArgs e)
        {
            int[] numerot = { 5, 13, 6, 9, 10, 4, 12, 15, 3, 8, 11, 2, 1 };

            //suurempi kuin 5, tulokset lajiteltu
            //SQL: SELECT luku FROM numerot WHERE luku > 5 ORDER BY luku

            var suuretNumerot = from n in numerot
                                where n > 5
                                orderby n
                                select n;

            foreach (var num in suuretNumerot)
            {
                MessageBox.Show(num.ToString());
            }

            //LINQ soveltuu tiedon hakuun:
            //omat oliot
            //XML - tiedostot
            //DataSet - tietovarastot
            //SQL - tietokannat
        }
    }
}
