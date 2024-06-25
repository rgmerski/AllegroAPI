using AllegroAPI.Data;
using AllegroAPI.Models;
using AllegroAPI.Allegro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AllegroAPI.Services
{
    internal class BillingService
    {
        private readonly AppDbContext _context;
        private readonly AllegroClient _allegroClient;

        public BillingService(AppDbContext context, AllegroClient allegroClient)
        {
            _context = context;
            _allegroClient = allegroClient;
        }

        // Metoda do przetwarzania wpisów billingowych
        public async Task ProcessBillingEntriesAsync()
        {
            // Pobieranie wpisów billingowych z API Allegro
            var billingEntries = await _allegroClient.GetBillingEntriesAsync();


            foreach (var entry in billingEntries)
            {
                // Dodawanie wpisów billingowych do bazy danych
                _context.BillingEntries.Add(new BillingEntry
                {
                    EntryId = entry.EntryId,
                    OccurredAt = entry.OccurredAt,
                    TypeId = entry.TypeId,
                    TypeName = entry.TypeName,
                    OfferId = entry.OfferId,
                    OfferName = entry.OfferName,
                    Amount = entry.Amount,
                    Currency = entry.Currency,
                    TaxPercentage = entry.TaxPercentage,
                    TaxAnnotation = entry.TaxAnnotation,
                    BalanceAmount = entry.BalanceAmount,
                    BalanceCurrency = entry.BalanceCurrency,
                    OrderId = entry.OrderId
                });
            }

            // do testów czytaj wpisy billingowe
            /*
            Console.WriteLine("TEST ---- WPISY BILLINGOWE");
            foreach (var entry in billingEntries)
            {
                Console.WriteLine("ID wpisu billingowego - " + entry.EntryId);
                Console.WriteLine("Data wystąpienia - " + entry.OccurredAt);
                Console.WriteLine("ID typu opłaty - " + entry.TypeId);
                Console.WriteLine("Nazwa typu opłaty - " + entry.TypeName);
                Console.WriteLine("ID oferty - " + entry.OfferId);
                Console.WriteLine("Nazwa oferty - " + entry.OfferName);
                Console.WriteLine("Kwota - " + entry.Amount);
                Console.WriteLine("Waluta - " + entry.Currency);
                Console.WriteLine("Procent podatku - " + entry.TaxPercentage);
                Console.WriteLine("Adnotacja podatkowa - " + entry.TaxAnnotation);
                Console.WriteLine("Kwota salda - " + entry.BalanceAmount);
                Console.WriteLine("Waluta salda - " + entry.BalanceCurrency);
                Console.WriteLine("ID zamówienia - " + entry.OrderId);
            }
            */
            
            await _context.SaveChangesAsync();
        }
    }
}