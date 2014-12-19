using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACM.Library;

namespace ACM.BL
{
    /// <summary>
    /// Manages a single invoice.
    /// </summary>
    public partial  class Invoice : BoBase
    {
        #region Properties
        /// <summary>
        /// Gets or sets the Id of the associated customer.
        /// </summary>
      public int CustomerId { get; set; }
        
        /// <summary>
        /// Gets or sets the percent amount of the discount given on the invoice.
        /// </summary>
        public decimal DiscountPercent { get; set; }

        /// <summary>
        /// Gets or sets the date of the invoice.
        /// </summary>
        public DateTimeOffset? InvoiceDate { get; set; }

        /// <summary>
        /// Gets or sets the amount of the invoice.
        /// </summary>
        public decimal InvoiceAmount { get; set; }

        /// <summary>
        /// Gets or sets the Id of the invoice.
        /// </summary>
        public int InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets the type of the invoice.
        /// </summary>
        public int? InvoiceType { get; set; }

        /// <summary>
        /// Gets or sets the number of items on the invoice.
        /// </summary>
        public int? NumberOfItems { get; set; }

        #endregion

        #region Create
        /// <summary>
        /// Creates a new customer with default values.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Ria Services cannot use this method. Need to repeat
        /// any defaults in the Silverlight client code.
        /// </remarks>
        public static Invoice Create()
        {
            Invoice newInvoice = new Invoice
            {
                InvoiceId = 0,
                InvoiceAmount = 0,
                InvoiceDate = null,
                InvoiceType = null,
                NumberOfItems=null
            };

            // Set the entity state
            newInvoice.SetEntityState(EntityStateType.Added);

            return newInvoice;
        }

        #endregion

        #region SaveItem
        /// <summary>
        /// Saves the customer properties back to the database.
        /// </summary>
        public override bool SaveItem()
        {
            bool success = false;

            return success;
        }
        #endregion

        #region ToString
        /// <summary>
        /// Displays the name as the logical identifier for the customer.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var description = this.InvoiceDate.Value.Date.ToShortDateString();
            description += " (" + CustomerId.ToString() + ")";
            return description;
        }
        #endregion
    }
}
