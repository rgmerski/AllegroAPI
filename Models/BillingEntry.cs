using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllegroAPI.Models
{
// Na podstawie odpowiedzi przykładowej z dokumentacji
// https://developer.allegro.pl/documentation/#operation/getBillingEntries

    internal class BillingEntry
    {
        public int Id { get; set; }
        public string EntryId { get; set; } // ID wpisu billingowego
        public DateTime OccurredAt { get; set; } // Data wystąpienia
        public string TypeId { get; set; } // ID typu opłaty
        public string TypeName { get; set; } // Nazwa typu opłaty
        public string OfferId { get; set; } // ID oferty
        public string OfferName { get; set; } // Nazwa oferty
        public decimal Amount { get; set; } // Kwota
        public string Currency { get; set; } // Waluta
        public decimal TaxPercentage { get; set; } // Procent podatku
        public string TaxAnnotation { get; set; } // Adnotacja podatkowa
        public decimal BalanceAmount { get; set; } // Kwota salda
        public string BalanceCurrency { get; set; } // Waluta salda
        public string OrderId { get; set; } // ID zamówienia
    }
}
