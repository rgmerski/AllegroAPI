using AllegroAPI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace AllegroAPI.Allegro
{
    internal class AllegroClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _accessToken;
        private readonly bool _useSandbox;


        public AllegroClient(HttpClient httpClient, string accessToken, bool useSandbox)
        {
            _httpClient = httpClient;
            _accessToken = accessToken;
            _useSandbox = useSandbox;
        }

        // Metoda do pobierania wpisów billingowych dla zamówienia
        public async Task<List<BillingEntry>> GetBillingEntriesAsync(string marketplaceId = "allegro-pl")
        {
            // Ustawienie adresu bazowego w zależności od środowiska (sandbox lub produkcyjne)
            var url = _useSandbox ?
                $"https://api.allegro.pl.allegrosandbox.pl/billing/billing-entries?marketplaceId={marketplaceId}" :
                $"https://api.allegro.pl/billing/billing-entries?marketplaceId={marketplaceId}";

            // Ustawienie nagłówków autoryzacji
            // Brak możliwości przetestowania - nie mam tokenu, nie wiem czy to nie wychodzi poza zakres zadania
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.allegro.public.v1+json"));

            // Wykonanie żądania GET
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var billingEntries = System.Text.Json.JsonSerializer.Deserialize<AllegroResponse>(content);
            return billingEntries.BillingEntries;
        }

        /* Metoda do pobierania kosztów ofert
            tutaj do wypełnienia, jeśli byśmy uzyskali sposób odczytywania stałych kosztów, przykładowo z jakiego url w API skorzystać
            przykład:

        // Metoda do pobierania kosztów ofert
        public async Task<List<OfferCost>> GetOfferCostsAsync(string offerId)
        {
            var url = ""; // url musi zawierać offerId
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var offerCosts = System.Text.Json.JsonSerializer.Deserialize<AllegroResponse>(content);
            return offerCosts.OfferCosts;
        }
        Dodatkowo wymagałoby to dodania w AllegroResponse listy, do której byśmy mogli to wczytać
       */

    }

    internal class AllegroResponse
    {
        public List<BillingEntry> BillingEntries { get; set; }
        public List<OfferCost> OfferCosts { get; set; }
    }
}
