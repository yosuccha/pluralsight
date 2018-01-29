using Acme.Common;
using static Acme.Common.LoggingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages product carried in inventory
    /// </summary>
    public class Product
    {
        
        public Product()
        {
            Console.WriteLine("Product instance created");
            //this.ProductVendor = new Vendor();
            this.Category = "Tools";
        }
        public Product(int productID, 
                        string productName,
                        string description) : this()
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.Description = description;

            Console.WriteLine("Product instance has a name:" + 
                                ProductName);
        }
        private string productName;

        public string ProductName
        {
            get {
                var formattedValue = productName?.Trim();
                return formattedValue;
            }
            set { productName = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private int productID;

        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        private Vendor productVendor;

        public Vendor ProductVendor
        {
            get {
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                } 
                return productVendor; }
            set { productVendor = value; }
        }
        public string Category { get; set; }
        public int SequenceNumber { get; set; } = 1;

        public string ProductCode => this.Category + "-" + this.SequenceNumber;
        public string SayHello()
        {
            //var vendor = new Vendor();
            //vendor.SendWelcomeEmail("Message from Product");

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Product",
                this.ProductName, "sales@abc.com");

            var result = LogAction("saying hello");

            return "Hello " + ProductName + " (" + ProductID + "): " + Description;
        }

    }
}
