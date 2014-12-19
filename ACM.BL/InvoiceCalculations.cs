using System;

namespace ACM.BL
{
    public partial class Invoice
    {
        /// <summary>
        /// Gets or sets the total amount of the invoice with the associated discount.
        /// </summary>
        public decimal TotalAmount
        {
            get
            {
                return this.InvoiceAmount - (this.InvoiceAmount * (this.DiscountPercent/100));
            }
        }
    }
}
