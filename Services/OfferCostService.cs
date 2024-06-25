using AllegroAPI.Allegro;
using AllegroAPI.Data;
using AllegroAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllegroAPI.Services
{
    internal class OfferCostService
    {
        private readonly AppDbContext _context;
        private readonly AllegroClient _allegroClient;

        // Konstruktor klasy OfferCostService
        public OfferCostService(AppDbContext context, AllegroClient allegroClient)
        {
            _context = context;
            _allegroClient = allegroClient;
        }

        // Metoda do przetwarzania kosztów ofert
        public async Task ProcessOfferCostsAsync()
        {
            // Pobieranie listy ofert z bazy danych
            var offers = await _context.Orders.Select(o => o.OrderId).Distinct().ToListAsync();

            foreach (var offerId in offers)
            {
                // Pobieranie kosztów ofert z API Allegro
                /*
                 * ZAKOMENTOWANE - metoda GetOfferCostsAsync nie jest zaimplementowana!
                 * 
                var offerCosts = await _allegroClient.GetOfferCostsAsync(offerId);

                foreach (var cost in offerCosts)
                {
                    // Dodawanie kosztów ofert do bazy danych
                    _context.OfferCosts.Add(new OfferCost
                    {
                        OfferId = cost.OfferId,
                        CostType = cost.CostType,
                        Amount = cost.Amount,
                        Currency = cost.Currency,
                        Date = cost.Date,
                    });
                }

                // do testów czytaj wpisy z kosztami
                Console.WriteLine("TEST ---- WPISY KOSZTOWE");
                foreach (var cost in offerCosts)
                {
                    Console.WriteLine("ID oferty - " + cost.OfferId);
                    Console.WriteLine("Typ kosztu - " + cost.CostType);
                    Console.WriteLine("Kwota kosztu - " + cost.Amount);
                    Console.WriteLine("Waluta - " + cost.Currency);
                    Console.WriteLine("Data powstania kosztu - " + cost.Date);
                }
                */

                // Zapis zmian w bazie danych
                //await _context.SaveChangesAsync();
            }
        }
    }
}
