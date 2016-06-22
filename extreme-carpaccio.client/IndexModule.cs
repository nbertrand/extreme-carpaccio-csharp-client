using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml.Schema;

namespace xCarpaccio.client
{
    using Nancy;
    using System;
    using Nancy.ModelBinding;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ => "It works !!! You need to register your server on main server.";

            Post["/order"] = _ =>
            {
                using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    Console.WriteLine("Order received: {0}", reader.ReadToEnd());
                }

                var order = this.Bind<Order>();
                var bill = new Bill();
                var tax = 1.0M;
                var country = order.Country;
                //TODO: do something with order and return a bill if possible
                // If you manage to get the result, return a Bill object (JSON serialization is done automagically)
                // Else return a HTTP 404 error : return Negotiate.WithStatusCode(HttpStatusCode.NotFound);


                if (country == "FI")
                {
                    tax = 1.17M;
                }
                if (country == "SK")
                {
                    tax = 1.18M;
                }
                if (country == "ES" || country == "CZ")
                {
                    tax = 1.19M;
                }
                if (country == "DE" || country == "FR" || country == "RO" || country == "EL" || country == "LV" || country == "MT")
                {
                    tax = 1.20M;
                }

                if (country == "UK" || country == "PL" || country == "BG" || country == "DK" || country == "IE" || country == "CY")
                {
                    tax = 1.21M;
                }

                if (country == "AT")
                {
                    tax = 1.22M;
                }

                if (country == "BE" || country == "SI")
                {
                    tax = 1.23M;
                }
                
                if (country == "PT" || country == "SE" || country == "HR" || country == "LT")
                {
                    tax = 1.24M;
                }

                if (country == "IT" || country == "LU")
                {
                    tax = 1.25M;
                }
                if (country == "HU")
                {
                    tax = 1.27M;
                }

                //Pour chaque prix dans la liste de prix, on ajoute le prix au total
                for (var i=0; i < order.Prices.Length; i++)
                {
                    bill.total +=  order.Prices[i] *  order.Quantities[i] * tax;
                }
                



                
                // Gestion des réductions en fonction du total de la commande
                if (bill.total >= 50000.00M)
                {
                    bill.total = bill.total* 0.85M;
                }
                else if (bill.total >= 10000.00M && bill.total <= 49999.99M)
                {
                    bill.total = bill.total * 0.9M;
                }
                else if (bill.total >= 7000.00M && bill.total <= 9999.99M)
                {
                    bill.total = bill.total * 0.93M;
                }
                else if (bill.total >= 5000.00M && bill.total <= 6999.99M)
                {
                    bill.total = bill.total * 0.95M;
                }
                else if (bill.total >= 1000.00M && bill.total <= 4999.99M)
                {
                    bill.total = bill.total* 0.97M;
                }
                return bill;
            };

            Post["/feedback"] = _ =>
            {
                var feedback = this.Bind<Feedback>();
                Console.Write("Type: {0}: ", feedback.Type);
                Console.WriteLine(feedback.Content);
                return Negotiate.WithStatusCode(HttpStatusCode.OK);
            };
        }
    }
}