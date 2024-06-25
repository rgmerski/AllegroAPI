using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllegroAPI.Models
{
    /*
     * ustawienia tabeli jak w poprzedniej
      CREATE TABLE [dbo].[OfferCost](
        [id] INT IDENTITY(1,1) NOT NULL, 
        [offerId] VARCHAR(45) NOT NULL, 
        [costType] VARCHAR(100) NOT NULL, 
        [amount] DECIMAL(18, 2) NOT NULL, 
        [currency] VARCHAR(10) NOT NULL, 
        [date] DATETIME NOT NULL,

        CONSTRAINT [PK_OfferCost] PRIMARY KEY CLUSTERED 
        (
            [id] ASC
        ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
                IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, 
                ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
        ) ON [PRIMARY]
        GO
     */
    internal class OfferCost
    {
        public int Id { get; set; }
        public string OfferId { get; set; } // ID oferty - unikalny identyfikator oferty w Allegro
        public string CostType { get; set; } // Typ kosztu - np. "Listing fee", "Commission fee", itp.
        public decimal Amount { get; set; } // Kwota kosztu
        public string Currency { get; set; } // Waluta, w której jest podana kwota
        public DateTime Date { get; set; } // Data powstania kosztu
    }
}
