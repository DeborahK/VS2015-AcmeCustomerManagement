using System;
using ACM.DL;
using System.Collections.Generic;

namespace ACM.BL
{
    #region Enums
    /// <summary>
    /// Defines the types of customers.
    /// </summary>
    public enum CustomerTypeOption
    {
        /// <summary>
        /// Customer type is unknown
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Customer is an individual
        /// </summary>
        Individual = 1,

        /// <summary>
        /// Customer is a corporation
        /// </summary>
        Corporation = 2,

        /// <summary>
        /// Customer is an educational institution
        /// </summary>
        Education = 3,

        /// <summary>
        /// Customer is a government agency.
        /// </summary>
        Government = 4
    }
    #endregion

    /// <summary>
    /// Manages a single customer.
    /// </summary>
    public class Customer : BoBase
    {
        /// <summary>
        /// Gets the Id of the customer
        /// </summary>
        public int CustomerId { get; internal set; }

        /// <summary>
        /// Gets or sets the customer type
        /// </summary>
        public CustomerTypeOption CustomerType { get; set; }

        /// <summary>
        /// Gets or sets the customer's email address
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the customer's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the set of invoices associated with this customer.
        /// </summary>
        public List<Invoice> InvoiceList { get; set; }
        
        /// <summary>
        /// Gets or sets the customer's last name
        /// </summary>
        public string LastName { get; set; }

        #region Create
        /// <summary>
        /// Creates a new customer with default values.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Ria Services cannot use this method. Need to repeat
        /// any defaults in the Silverlight client code.
        /// </remarks>
        public static Customer Create()
        {
            Customer newCustomer = new Customer
            {
                CustomerId = 0,
                CustomerType = CustomerTypeOption.Unknown,
                EmailAddress = null,
                FirstName = null,
                LastName = null
            };

            // Set the entity state
            newCustomer.SetEntityState(EntityStateType.Added);

            return newCustomer;
        }

        #endregion

        #region SaveItem
        /// <summary>
        /// Saves the customer properties back to the database.
        /// </summary>
        public override bool SaveItem()
        {
            bool success = false;

            // If the entity state is added, need to get the CustomerId back.
            bool isOutput = false;
            string spName = "CustomerUpdate";
            if (EntityState == EntityStateType.Added)
            {
                isOutput = true;
                spName = "CustomerInsert";
            }

                // Pass the properties back to the DAC
                // This would not be needed if the base class had code to use Reflection to build
                // the parameters from the object properties.
                int retVal = Dac.ExecuteNonQuery(spName,
                                Dac.Parameter("CustomerId", CustomerId, isOutput),
                                Dac.Parameter("LastName", LastName),
                                Dac.Parameter("FirstName", FirstName),
                                Dac.Parameter("EmailAddress", EmailAddress),
                                Dac.Parameter("CustomerType", CustomerType));

                // If it was an add, update the product ID
                if (EntityState == EntityStateType.Added)
                    CustomerId = retVal;

            // Reset the entity's state
            this.SetEntityState(EntityStateType.Unchanged);

            // Assume success
            success = true;

            return success;
        }

        #endregion

        #region ToString
        /// <summary>
        /// Overrides ToString to provide the full name of the customer.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Original code
            //return this.LastName + ", " + this.FirstName;

            // Code that passes all unit tests
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(this.LastName))
            {
                value += this.LastName;
            }
            if (!string.IsNullOrWhiteSpace(this.FirstName))
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    value += ", ";
                }
                value += this.FirstName;
            }
            value += " (" + this.CustomerId + ")";
            return value;
        }
        #endregion

    }
}

