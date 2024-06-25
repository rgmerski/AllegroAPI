using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AllegroAPI.Models
{
    /*
    CREATE TABLE [dbo].[OrderTable](
      [id] [int] IDENTITY(1,1) NOT NULL,
      [orderId] [varchar](45) NOT NULL,
      [erpOrderId] [int] NULL,
      [invoiceId] [int]  NULL,
      [storeId] [int]
    */
    internal class Order
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public int? ErpOrderId { get; set; }
        public int? InvoiceId { get; set; }
        public int StoreId { get; set; }
    }
}
