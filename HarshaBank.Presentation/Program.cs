class Program
{
    static void Main()
    {
        //display title
        System.Console.WriteLine("****************Harsha Bank****************");
        System.Console.WriteLine("::Login Page::");

        //declare varibales to store username and password;
        string userName = null, password = null;

        //read userName from keyboard
        System.Console.Write("Username:");
        userName = System.Console.ReadLine();

        //read password from keyboard only if username is entered
        if (userName != "")
        {
            //read password from keyboard
            System.Console.Write("Password:");
            password = System.Console.ReadLine();

        }

        //check username and password
        if (userName == "system" && password == "manager")
        {
            int mainMenuChoice = -1;
            do
            {
                //SHOW MAIN MENU
                System.Console.WriteLine("\n:::Main menu:::");
                System.Console.WriteLine("1. Customers");
                System.Console.WriteLine("2. Accounts");
                System.Console.WriteLine("3. Funds Transfer");
                System.Console.WriteLine("4. Funds Transfer Statement");
                System.Console.WriteLine("5. Account Statement");
                System.Console.WriteLine("0. Exit");
                //ACCEPT MENU CHOICE FROM KEYBOARD
                System.Console.Write("Enter choice :");
                mainMenuChoice = int.Parse(System.Console.ReadLine());
                //SWITCH-CASE TO CHECK MENU CHOICE


                switch (mainMenuChoice)
                {
                    case 1:
                        CustomersMenu();
                        break;
                    case 2:
                        AccountsMenu();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;

                }
            } while (mainMenuChoice != 0);

        }
        else
        {
            System.Console.WriteLine("Invalid username or password");
        }
        System.Console.WriteLine("Thank you! Visit again.");

        System.Console.ReadKey();
    }


    static void CustomersMenu()
    {
        //variable to store customer menu choice
        int customerMenuChoice = -1;

        do
        {   //print customers menu
            System.Console.WriteLine("\n:::Customers menu:::");
            System.Console.WriteLine("1. Add Customer");
            System.Console.WriteLine("2. Delete Customer");
            System.Console.WriteLine("3. Update Customer");
            System.Console.WriteLine("4. Search Customers");
            System.Console.WriteLine("5. View Customer");
            System.Console.WriteLine("0. Back To Main Menu");

            //accept customers menu choice
            System.Console.Write("Enter choice :");

            customerMenuChoice = System.Convert.ToInt32(System.Console.ReadLine());

            switch (customerMenuChoice)
            {
                case 1:
                    HarshaBank.Presentation.CustomerPresentation.AddCustomer();
                    break;
                case 2:
                    HarshaBank.Presentation.CustomerPresentation.DeleteCustomer();
                    break;
                case 3:
                    HarshaBank.Presentation.CustomerPresentation.UpdateCustomer();
                    break;
                case 4:
                    HarshaBank.Presentation.CustomerPresentation.SearchCustomers();
                    break;
                case 5:
                    HarshaBank.Presentation.CustomerPresentation.ViewCustomers();
                    break;
            }

        } while (customerMenuChoice != 0);

    }

    static void AccountsMenu()
    {
        //variable to store accounts menu choice
        int accountsMenuChoice = -1;

        do
        {   //print accounts menu
            System.Console.WriteLine("\n:::Accounts menu:::");
            System.Console.WriteLine("1. Add Account");
            System.Console.WriteLine("2. Delete Account");
            System.Console.WriteLine("3. Update Account");
            System.Console.WriteLine("4. View Account");
            System.Console.WriteLine("0. Back To Main Menu");


            //accept accounts menu choice
            System.Console.Write("Enter choice :");

            accountsMenuChoice = System.Convert.ToInt32(System.Console.ReadLine());
        } while (accountsMenuChoice != 0);

    }
}