using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using ACM.BL;
using System.ComponentModel;
using System.Windows;

namespace ACM.WPF.ViewModels
{
    public class CustomerListViewModel : ViewModelBase
    {
        private ObservableCollection<Customer> _CustomersList;
        /// <summary>
        /// Gets or sets the list of customers to bind to the View.
        /// </summary>
        public ObservableCollection<Customer> CustomersList
        {
            get { return _CustomersList; }
            set
            {
                if (_CustomersList != value)
                {
                    _CustomersList = value;
                    NotifyPropertyChanged();
                }
            }
        }

        Customers customerRepository = new Customers();

        public CustomerListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                LoadDesignData();
            }
            else
            {
                LoadData(); 
            }
            
        }

        public void LoadData()
        {
            _CustomersList = new ObservableCollection<Customer>();

            var customerList = Customers.Retrieve();

            foreach (var customerInstance in customerList.OrderBy(c => c.LastName))
            {
                _CustomersList.Add(customerInstance);
            }
        }

        private void LoadDesignData()
        {
            _CustomersList = new ObservableCollection<Customer>();

            _CustomersList.Add(new Customer
                                {
                                    LastName = "Baggins",
                                    FirstName = "Bilbo",
                                    EmailAddress = "b@bagend.me",
                                    InvoiceList = new List<Invoice>
                                        {
                                            new Invoice {
                                                InvoiceAmount = 100m,
                                                InvoiceDate = new DateTime(2013,9,1),
                                                DiscountPercent = 10m},
                                            new Invoice {
                                                InvoiceAmount = 20m,
                                                InvoiceDate = new DateTime(2013,8,1),
                                                DiscountPercent = 0m}
                                        }
                                });

            _CustomersList.Add(new Customer
                                {
                                    LastName = "Cotton",
                                    FirstName = "Rosie",
                                    EmailAddress = "Rosie@greendragon.me",
                                     InvoiceList = new List<Invoice>
                                        {
                                            new Invoice {
                                                InvoiceAmount = 50m,
                                                InvoiceDate = new DateTime(2013,9,12),
                                                DiscountPercent = 5m}
                                        }
                                });
        }
    }
}
