using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace NaderK_Assign1
{
    class Product
    {
        //Read Only Properties
        public string ProductName //Read only property
        {
            get;
        }
        public double PricePerUnit
        {
            get;

        }
        public int Quantity //Read and Write Property
        {
            get; set;
        }
        public double ProductTotalBeforeTax //Calc for product price alongside quantity
        {
            get
            {
                return (Quantity * PricePerUnit);
            }
        }
        public double ProductTax //Calc for 8% tax only
        {
            get
            {
                return (Quantity * PricePerUnit * 0.08);
            }
        }
        public double ProductTotalAfterTax //Calc for product cost with 8% tax added up
        {
            get
            {
                return (Quantity * PricePerUnit * 1.08);
            }
        }
        public Product(string productName, double pricePerUnit) //Constructor with 2 args to initialize product name and price per unit
        {
            ProductName = productName;
            PricePerUnit = pricePerUnit;
        }
        public override string ToString() //To String method to return values in string format
        {
            string objectStr = "Product Name: " + ProductName +
                                  "\n Price Per Unit: " + PricePerUnit.ToString("C") +
                                  "\n Quantity: " + Quantity +
                                  "\n Product Before Tax: " + ProductTotalBeforeTax.ToString("C") +
                                  "\n Product Tax: " + ProductTax.ToString("C") +
                                  "\n Product Afrer Tax: " + ProductTotalAfterTax.ToString("C");
            return objectStr;

        }
    }
}
