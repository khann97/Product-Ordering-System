using System;
using static System.Console;

namespace NaderK_Assign1
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product("Disposable Masks Pack", 12.99); //Created 3 Products from the "Product" constructor with 2 params within the "Product" class
            Product product2 = new Product("Hand Sanitizer", 6.99);
            Product product3 = new Product("Printer Paper Stack", 17.99);
            WriteLine("Welcome to wholesale product ordering system!");
            WriteLine("You can place orders for three different products!");
            
            WriteLine("\n" + "The products we have in stock are..."); //Added "\n" to provide space in the visual output
            WriteLine("Disposable Masks Pack with price per unit $12.99");
            WriteLine("Hand Sanitizer with price per unit $6.99");
            WriteLine("Printer Paper Stack with price per unit $17.99"); //Could have possibly made another method to call and just display instructions instead of multiple WriteLines

            WriteLine("\n" + "Let us begin by entering the quantities for each of these products");
            UpdateProductQty(product1);
            UpdateProductQty(product2); //Allowing the user to input the quantity of each product and calling the update and passing the corresponding product as param
            UpdateProductQty(product3);
            WriteLine("The quantities for each product has been entered");
            WriteLine();
            WriteLine();
            WriteLine();
            WriteLine();
            ChooseAction(product1, product2, product3); //At the end of the Main method, calling this method to display order options to view, update, or quit
        }
        static void UpdateProductQty(Product anyProductObj)
        {
            Write("Enter the quantity for " + anyProductObj.ProductName + ": ");
            int quantity = int.Parse(ReadLine()); //Parsing quantity string input into an integer
            anyProductObj.Quantity = quantity;
        }
        static void ChooseAction(Product product1, Product product2, Product product3)
        {
            string asterikLine = new string('*', 74);
            Write("What would you like to do?" + "\n" + "Press 1 for View Cart, Press 2 for Update Cart, Press 3 for quitting the application: ");
            char productOrderOptions = char.Parse(ReadLine());
            if (productOrderOptions == '1') //if statement to find proper input entered, and narrows down the selection to call the corresponding method
            {
                ViewCart(product1, product2, product3);
            }
            else if (productOrderOptions == '2')
            {
                UpdateCart(product1, product2, product3);
            }
            else if (productOrderOptions == '3')
            {
                WriteLine("Thank you for ordering the products. Good bye!");
            } else
            {
                WriteLine("Invalid input"); //A little exception handling so the program does not terminates after invalid input
                ReadLine();
            }
        }
        static void ViewCart(Product product1, Product product2, Product product3) //Calling these methods to get the data
        {
            GetCartTotalsSummary(product1, product2, product3, out double totalBeforeDiscount, out double discountAmount);
            ChooseAction(product1, product2, product3);
        }
        static void UpdateCart(Product product1, Product product2, Product product3) //Updating cart using if statements, displaying message upon successful quantity update
        {
            WriteLine("Press 1 to update quantity for Disposable Masks Pack");
            WriteLine("Press 2 to update quantity for Hand Sanitizer");
            WriteLine("Press 3 to update quantity for Printer Paper Stack");
            WriteLine("Enter the number 1, 2 or 3");
            char productUpdate = char.Parse(ReadLine());
            if (productUpdate == '1')
            {
                UpdateProductQty(product1);
                WriteLine("Great! Quantity for Disposable Masks Pack has been updated to: " + product1.Quantity);

            }
            else if (productUpdate == '2')
            {
                UpdateProductQty(product2);
                WriteLine("Great! Quantity for Hand Sanitizer has been updated to: " + product2.Quantity);

            }
            else if (productUpdate == '3')
            {
                UpdateProductQty(product3);
                WriteLine("Great! Quantity for Printer Paper Stack has been updated to: " + product3.Quantity);
            } else
            {
                WriteLine("Invalid input"); //Expection handling #2 but still terminates :\
                ReadLine();
            }
            ChooseAction(product1, product2, product3);
        }
        private static void GetCartTotalsSummary(Product product1, Product product2, Product product3, out double totalBeforeDiscount, out double discountAmount)
        {
            totalBeforeDiscount = product1.ProductTotalAfterTax + product2.ProductTotalAfterTax + product3.ProductTotalAfterTax;

            if (totalBeforeDiscount > 100) //If order total is over $100 it then applies the 10% discount in the line below
            {
                discountAmount = (totalBeforeDiscount * 0.10); 
            }
            else
            {
                discountAmount = (0.00);
            }
            double totalAfterDiscount = (totalBeforeDiscount) - (discountAmount);
            string asterikLine = new string('*', 74); //Week 1 & 2 practise for the output banner helped out as well as the slides for format specifiers
            WriteLine();
            WriteLine("Okay! Let's view your order!");
            WriteLine();
            WriteLine();
            WriteLine(asterikLine);
            WriteLine("*{0,30}: {1, -40}*", "Product Name: ", product1.ProductName);
            WriteLine("*{0,30}: {1, -40}*", "Price Per Unit: ", product1.PricePerUnit.ToString("C")); //C for currently to display $
            WriteLine("*{0,30}: {1, -40}*", "Quantity: ", product1.Quantity);
            WriteLine("*{0,30}: {1, -40}*", "Product Before Tax: ", product1.ProductTotalBeforeTax.ToString("C"));
            WriteLine("*{0,30}: {1, -40}*", "Product Tax: ", product1.ProductTax.ToString("C"));
            WriteLine("*{0,30}: {1, -40}*", "Product After Tax: ", product1.ProductTotalAfterTax.ToString("C"));
            WriteLine();
            WriteLine("*{0,30}: {1, -40}*", "Product Name: ", product2.ProductName);
            WriteLine("*{0,30}: {1, -40}*", "Price Per Unit: ", product2.PricePerUnit.ToString("C"));
            WriteLine("*{0,30}: {1, -40}*", "Quantity: ", product2.Quantity);
            WriteLine("*{0,30}: {1, -40}*", "Product Before Tax: ", product2.ProductTotalBeforeTax.ToString("C"));
            WriteLine("*{0,30}: {1, -40}*", "Product Tax: ", product2.ProductTax.ToString("C"));
            WriteLine("*{0,30}: {1, -40}*", "Product After Tax: ", product2.ProductTotalAfterTax.ToString("C"));
            WriteLine();
            WriteLine("*{0,30}: {1, -40}*", "Product Name: ", product3.ProductName);
            WriteLine("*{0,30}: {1, -40}*", "Price Per Unit: ", product3.PricePerUnit.ToString("C"));
            WriteLine("*{0,30}: {1, -40}*", "Quantity: ", product3.Quantity);
            WriteLine("*{0,30}: {1, -40}*", "Product Before Tax: ", product3.ProductTotalBeforeTax.ToString("C"));
            WriteLine("*{0,30}: {1, -40}*", "Product Tax: ", product3.ProductTax.ToString("C"));
            WriteLine("*{0,30}: {1, -40}*", "Product After Tax: ", product3.ProductTotalAfterTax.ToString("C"));
            WriteLine();
            WriteLine("*{0,30}: {1, -40}*", "Total before discount: ", totalBeforeDiscount.ToString("C"));
            WriteLine("*{0,30}: {1, -40}*", "Discount: ", discountAmount.ToString("C"));
            WriteLine("*{0,30}: {1, -40}*", "Total after discount: ", totalAfterDiscount.ToString("C"));
            WriteLine(asterikLine);
            WriteLine();
            WriteLine();
        }
    }
}