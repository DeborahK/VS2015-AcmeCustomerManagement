using ACM.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ACM.BL
{
    /// <summary>
    /// Manages a list of customers
    /// </summary>
    public class Customers : BoListBase<Customer>
    {
        #region FindCustomers
        /// <summary>
        /// Finds customers by name.
        /// </summary>
        /// <param name="customerName">Portion of the last or first name.</param>
        /// <returns></returns>
        public List<Customer> FindCustomers(string customerName)
        {
            List<Customer> foundCustomers = null;

            if (!string.IsNullOrWhiteSpace(customerName))
            {
                foundCustomers = this.Where(c => c.LastName.Contains(customerName) ||
                                            c.FirstName.Contains(customerName)).ToList();
            }

            return foundCustomers;
        }

        /// <summary>
        /// Finds customers by Id.
        /// </summary>
        /// <param name="customerId">Id of the customer.</param>
        /// <returns></returns>
        public List<Customer> FindCustomers(int customerId)
        {
            List<Customer> foundCustomers;
            foundCustomers = this.Where(c => c.CustomerId == customerId).ToList();
            return foundCustomers;
        }
        #endregion

        #region Retrieve
        /// <summary>
        /// Retrieves customers from the database and gets a set of results.
        /// </summary>
        /// <remarks>
        /// NOTE: You must first build the database using the provided scripts.
        /// See the Database project for the scripts.
        /// </remarks>
        /// <returns></returns>
        public static Customers Retrieve()
        {
            Customers customerList = new Customers();

            // Retrieve the data using the data access component
            DataTable dt = Dac.ExecuteDataTable("CustomerRetrieve");

            // Process each row in the table
            foreach (DataRow dr in dt.Rows)
            {
                Customer customerInstance = new Customer {
                    CustomerId = (int)dr["CustomerId"],
                    LastName = dr["LastName"].ToString(),
                    FirstName = dr["FirstName"].ToString(),
                    EmailAddress = dr["EmailAddress"].ToString(),
                    CustomerType = (CustomerTypeOption)dr["CustomerType"]};

                // Retrieve the invoices for this customer
                customerInstance.InvoiceList = Invoices.Retrieve(customerInstance.CustomerId);

                customerList.Add(customerInstance);
            }

            return customerList;
        }
        #endregion
    }
}
