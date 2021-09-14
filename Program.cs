using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CustomerSystemWorkBook5
{
    class Program
    {
        struct Customer
        {
            public string forename;
            public string surname;
            public DateTime dob;
            private string email;
            private string phoneNumber;
            public string street;
            public string town;
            public string postcode;
            public string houseNo;

            public string PhoneNumber
            {
                get
                {
                    return phoneNumber;
                }

                set
                {
                    if (CheckPhoneNumber(value))
                    {
                        phoneNumber = value;
                    }
                    else
                    {
                        phoneNumber = "invalid";
                    }
                }
            }

            private static bool CheckPhoneNumber(string strPhoneNumber)
            {

                strPhoneNumber=Regex.Replace(strPhoneNumber, @"\s+", "");
                if (strPhoneNumber.Length == 11)
                {
                    foreach (var digit in strPhoneNumber)
                    {
                        if (!char.IsDigit(digit))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
            public string Email
            {
                get
                {
                    return email;
                }
                set
                {
                    if (CheckEmail(value))
                    {
                        email = value;

                    }
                    else
                    {
                        email = "invalid";
                    }
                }
            }

            private static bool CheckEmail(string strEmail)
            {
                bool AtSignReached = false;
                bool DotReached = false;
                string strEmailname = "";
                string strEmailHost = "";
                string strEmailSuffix = "";
                

                foreach (var character in strEmail)
                {
                    if (character.ToString() == " ")
                    {
                        return false;
                    }
                    else if (character.ToString() == "@")
                    {
                        AtSignReached = true;
                        if (strEmailname == "")
                        {
                            
                            return false;
                        }

                    }
                    if (!AtSignReached)
                    {
                        strEmailname += character;
                    }

                    if (AtSignReached && !DotReached)
                    {
                        strEmailHost += character;
                    }

                    if (character.ToString() == ".")
                    {
                        DotReached = true;

                    }
                    else if (DotReached)
                    {
                        strEmailSuffix += character;

                        if (!Char.IsLetter(character))
                        {
                            return false;
                        }
                    }
                }


                if (strEmail == "")
                {
                    return false;

                }
                else
                {
                    if (strEmailHost == "")
                    {
                        return false;

                    }
                    if (!AtSignReached)
                    {
                        return false;
                    }

                    if (!DotReached)
                    {
                        return false;

                    }

                    return true;
                }


            }

        }



        static void Main(string[] args)

        {
            Customer Customer1 = new Customer();
            Customer Customer2 = new Customer();
            Customer Customer3 = new Customer();
            Customer Customer4 = new Customer();
            Customer Customer5 = new Customer();

            List<Customer> Customers = new List<Customer>();

            CustomerSystem(Customers, Customer1, Customer2, Customer3, Customer4, Customer5);
        }





        static void CustomerSystem(List<Customer> Customers, Customer Customer1, Customer Customer2, Customer Customer3, Customer Customer4, Customer Customer5)
        {

            string strMenuSelection = "";
            string strPickAgain = "";


            if (Customers.Count < 5)
            {
                string[] options = { "1", "2", "3", "4" };
                while (!options.Contains(strMenuSelection))
                {
                    Console.WriteLine("Select Option:\n1.Create new customer record\n2.View all records\n3.Edit customer record\n4.Search for record");
                    
                    strMenuSelection = Console.ReadKey().KeyChar.ToString();
                    Console.WriteLine();

                    if (!options.Contains(strMenuSelection))
                    {
                        Console.WriteLine("Selection invalid");
                    }

                }
                if (strMenuSelection == "1")
                {
                    Customers = CreateNewCustomer(Customers, Customer1, Customer2, Customer3, Customer4, Customer5);
                    

                }
                else if (strMenuSelection == "2")
                {
                    ViewRecords(Customers);
                }
                else if (strMenuSelection == "3")
                {
                    Customers=EditCustomerRecord(Customers, Customer1, Customer2, Customer3, Customer4, Customer5);
                }
                else if (strMenuSelection == "4")
                {
                    SearchForRecord(Customers, Customer1, Customer2, Customer3, Customer4, Customer5);
                }
            }

            else
            {
                string[] options = { "1", "2", "3" };
                while (!options.Contains(strMenuSelection))
                {
                    Console.WriteLine("Select Option:\n1.View all records\n2.Edit customer record\n3.Search for record");
                    strMenuSelection = Console.ReadKey().KeyChar.ToString();
                    Console.WriteLine();

                    if (!options.Contains(strMenuSelection))
                    {
                        Console.WriteLine("Selection invalid");
                    }

                }

                if (strMenuSelection == "1")
                {
                    ViewRecords(Customers);

                }
                else if (strMenuSelection == "2")
                {
                    Customers=EditCustomerRecord(Customers, Customer1, Customer2, Customer3, Customer4, Customer5);
                }
                else if (strMenuSelection == "3")
                {
                    SearchForRecord(Customers, Customer1, Customer2, Customer3, Customer4, Customer5);
                }

            }

            while (strPickAgain != "Y" && strPickAgain != "N")
            {
                Console.Write("Would you like to select another option [Y/N]");
                strPickAgain = Console.ReadKey().KeyChar.ToString().ToUpper();
                Console.WriteLine();
                if (strPickAgain != "Y" && strPickAgain != "N")
                {
                    Console.WriteLine("Invalid choice");
                }
            }

            if (strPickAgain == "Y")
            {
                strPickAgain = "";
                CustomerSystem(Customers, Customer1, Customer2, Customer3, Customer4, Customer5);
            }



        }



        static void SearchForRecord(List<Customer> Customers, Customer Customer1, Customer Customer2, Customer Customer3, Customer Customer4, Customer Customer5)
        {
            bool boolFoundCustomer = false;
            string strSurnametoSearchFor = "";
            Console.Write("Enter surname to search for: ");
            strSurnametoSearchFor = Console.ReadLine().ToUpper();
            for (int i = 0; i < Customers.Count; i++)
            {
                Customer customertocompare = Customers[i];
                if (customertocompare.surname == strSurnametoSearchFor)
                {
                    boolFoundCustomer = true;
                    Console.WriteLine($"Forename:{customertocompare.forename}\nSurname:{customertocompare.surname}\nEmail:{customertocompare.Email}\nTelephone:{customertocompare.PhoneNumber}\nDOB:{customertocompare.dob.Date}\nAddress:\t{customertocompare.houseNo},\n\t\t{customertocompare.street},\n\t\t{customertocompare.town},\n\t\t{customertocompare.postcode} ");
                    Console.WriteLine();
                }

            }
            Console.WriteLine();
            if (!boolFoundCustomer)
            {
                string strSearchAgain = "";
                string[] options = { "Y", "N" };
                while (!options.Contains(strSearchAgain))
                {
                    Console.Write($"Customer with surname {strSurnametoSearchFor} not found, would you like to search again: [Y/N]");
                    strSearchAgain = Console.ReadKey().KeyChar.ToString().ToUpper();
                    Console.WriteLine();
                    if (!options.Contains(strSearchAgain))
                    {
                        strSearchAgain = "";
                        Console.WriteLine("Invalid option");
                        break;
                        
                    }
                    else if (strSearchAgain=="Y")
                    {
                        strSearchAgain = "";
                        SearchForRecord(Customers, Customer1, Customer2, Customer3, Customer4, Customer5);
                        break;
                        

                    }
                        
                
                }
                    

            }
        }

        static List<Customer> EditCustomerRecord(List<Customer> Customers, Customer Customer1, Customer Customer2, Customer Customer3, Customer Customer4, Customer Customer5)
        {
            string strSelection = "";
            int intSelection = 0;

            while (!int.TryParse(strSelection, out _))
            {
                Console.Write("Please enter number of customer whose record you wish to edit:");
                strSelection = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
                if (!int.TryParse(strSelection, out _))
                {
                    Console.WriteLine("Invalid entry: Customer number must be an integer");
                    continue;
                }

                intSelection = int.Parse(strSelection);

                if (intSelection > Customers.Count)
                {
                    strSelection = "";
                    Console.WriteLine($"Invalid Entry, customer #{intSelection} does not exist");
                    string strTryAgain = "";
                    while (strTryAgain != "Y" && strTryAgain != "N")
                    {
                        Console.Write("Do you want to enter a new customer number to edit? [Y/N]");
                        strTryAgain = Console.ReadKey().KeyChar.ToString().ToUpper();
                        Console.WriteLine();
                        if (strTryAgain != "Y" && strTryAgain != "N")
                        {
                            Console.WriteLine("Invalid entry, try again");
                        }
                        else if (strTryAgain == "N")
                        {
                            return Customers;
                        }
                        strSelection = "";
                    }

                }
                else
                {
                    bool boolTryagain = true;
                    while (boolTryagain)
                    {

                        boolTryagain = false;
                        //Customer customertoedit = Customers[intSelection - 1];

                        Customer customertoedit;
                        //customertoedit = Customer1;

                        int intCustomerEdited;

                        switch (intSelection)
                        {
                            case 1:
                                customertoedit= Customers[0];
                                intCustomerEdited = 1;
                                break;
                            case 2:
                                customertoedit = Customers[1];
                                intCustomerEdited = 2;
                                break;
                            case 3:
                                customertoedit = Customers[2];
                                intCustomerEdited = 3;
                                break;
                            case 4:
                                customertoedit = Customers[3];
                                intCustomerEdited = 4;
                                break;
                            case 5:
                                customertoedit = Customers[4];
                                intCustomerEdited= 5;
                                break;
                            default:
                                customertoedit = Customers[0];
                                intCustomerEdited = 1;
                                break;
                            
                        }


                        
                        Console.WriteLine("Do you want to edit customer:\n\t\t1 Forename\n\t\t2 Surname\n\t\t3 Email\n\t\t4 Telephone Number\n\t\t5 Address\n\t\t6 DOB");
                        string strMenuChoice = Console.ReadKey().KeyChar.ToString();
                        Console.WriteLine();
                        switch (strMenuChoice)
                        {
                            case "1":
                                Console.Write("Enter new forename:");
                                customertoedit.forename = Console.ReadLine();
                                break;
                            case "2":
                                Console.Write("Enter new surname:");
                                customertoedit.surname = Console.ReadLine();
                                break;
                            case "3":
                                string strCurrentEmail = customertoedit.Email;
                                customertoedit.Email = "";
                                while (customertoedit.Email == "invalid")
                                {
                                    Console.Write("Enter new Email:");
                                    customertoedit.Email = Console.ReadLine();

                                    if (customertoedit.Email != "invalid")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        string strEnterEmailAgain = "";
                                        while (strEnterEmailAgain != "T" && strEnterEmailAgain != "R")
                                        {
                                            Console.Write("Email invalid, would you like to try again or restore previous? [T/R]");
                                            strEnterEmailAgain = Console.ReadKey().KeyChar.ToString().ToUpper();
                                            Console.WriteLine();
                                            if (strEnterEmailAgain != "T" && strEnterEmailAgain != "R")
                                            {
                                                Console.WriteLine("Invalid entry");
                                                continue;
                                            }
                                            else if (strEnterEmailAgain == "T")
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                customertoedit.Email = strCurrentEmail;
                                            }

                                        }

                                    }


                                }
                                break;

                            case "4":
                                string strCurrentPhoneNumber = customertoedit.PhoneNumber;
                                customertoedit.PhoneNumber = "";
                                while (customertoedit.PhoneNumber == "invalid")
                                {
                                    Console.Write("Enter new Phone Number:");
                                    customertoedit.PhoneNumber = Console.ReadLine();

                                    if (customertoedit.PhoneNumber != "invalid")
                                    {
                                        break;
                                    }

                                    else

                                    {
                                        string strEnterPhoneAgain = "";
                                        while (strEnterPhoneAgain != "T" && strEnterPhoneAgain != "R")
                                        {
                                            Console.Write("Phone Number invalid, would you like to try again or restore previous? [T/R]");
                                            strEnterPhoneAgain = Console.ReadKey().KeyChar.ToString().ToUpper();
                                            Console.WriteLine();
                                            if (strEnterPhoneAgain != "T" && strEnterPhoneAgain != "R")
                                            {
                                                Console.WriteLine("Invalid entry");
                                                continue;
                                            }
                                            else if (strEnterPhoneAgain == "T")
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                customertoedit.PhoneNumber = strCurrentPhoneNumber;
                                            }

                                        }


                                    }


                                }
                                break;

                            case "5":
                                string strAddressLineToChange = "";
                                string[] AddressLines = { "1", "2", "3", "4" };
                         
                                while (!AddressLines.Contains(strAddressLineToChange))
                                {
                                    Console.WriteLine($"Enter number of line you wish to change:\n\t\t1: {customertoedit.houseNo}\n\t\t2: {customertoedit.street} \n\t\t3: {customertoedit.town} \n\t\t4:{customertoedit.postcode}");
                                    strAddressLineToChange = Console.ReadKey().KeyChar.ToString();
                                    Console.WriteLine();
                                    switch (strAddressLineToChange)
                                    {
                                        case "1":
                                            Console.Write("Enter new house number:");
                                            customertoedit.houseNo = Console.ReadLine();
                                            break;
                                        case "2":
                                            Console.Write("Enter new street:");
                                            customertoedit.street = Console.ReadLine();
                                            break;
                                        case "3":
                                            Console.WriteLine("Enter new town:");
                                            customertoedit.town = Console.ReadLine();
                                            break;
                                        case "4":
                                            Console.Write("Enter new postcode:");
                                            customertoedit.postcode = Console.ReadLine();
                                            break;
                                        default:
                                            Console.WriteLine("Invalid entry");
                                            break;

                                    }

                                }
                                break;

                            case "6":

                                string inputDOB = "";
                                bool boolContinue = true;
                                while (boolContinue)
                                {
                                    while (!DateTime.TryParse(inputDOB, out _))
                                    {
                                        Console.Write("Enter new DOB:");
                                        inputDOB = Console.ReadLine();
                                        if (DateTime.TryParse(inputDOB, out _))
                                        {
                                            customertoedit.dob = DateTime.Parse(inputDOB).Date;
                                            boolContinue = false;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid DOB entered");
                                            string strTryAgain = "";
                                            while (strTryAgain != "T" && strTryAgain != "R")
                                            {
                                                Console.Write("Do you want to try again or restore previous DOB:[T/R]");
                                                strTryAgain = Console.ReadKey().KeyChar.ToString().ToUpper();
                                                Console.WriteLine();
                                                if (strTryAgain == "T")
                                                {

                                                    break;
                                                }
                                                else if (strTryAgain == "R")
                                                {
                                                    boolContinue = false;

                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid entry");
                                                }

                                            }
                                            break;


                                        }
                                    }
                                }
                                break;

                            default:
                                Console.WriteLine("Invalid Choice");
                                boolTryagain = true;
                                break;
                        }

                        Customers[intCustomerEdited -1] = customertoedit;
                    }

                }
            }
            return Customers;
        }


        static void ViewRecords(List<Customer> Customers)
        {
            foreach (var customer in Customers)
            {
                Console.WriteLine($"Forename:{customer.forename}\nSurname:{customer.surname}\nEmail:{customer.Email}\nTelephone Number:{customer.PhoneNumber}\nDOB:{customer.dob.Date}\nAddress:\t{customer.houseNo}, \n\t\t {customer.street}, \n\t\t{customer.town}, \n\t\t{customer.postcode}");
                Console.WriteLine();
            }
        }




        static List<Customer> CreateNewCustomer(List<Customer> Customers, Customer Customer1, Customer Customer2, Customer Customer3, Customer Customer4, Customer Customer5)
        {
            Console.Write("Enter Forename:");
            string inputForename = Console.ReadLine().ToUpper();
            Console.Write("Enter Surname:");
            string inputSurname = Console.ReadLine().ToUpper();
            Console.Write("Enter Town:");
            string inputTown = Console.ReadLine().ToUpper();
            Console.Write("Enter Street:");
            string inputStreet = Console.ReadLine().ToUpper();
            Console.Write("Enter House Number:");
            string inputHouseNo = Console.ReadLine().ToUpper();
            Console.Write("Enter Postcode:");
            string inputPostcode = Console.ReadLine().ToUpper();
            DateTime inputDOB = new DateTime();
            string strDOB = "";

            while (!DateTime.TryParse(strDOB, out _))
            {
                Console.Write("Enter DOB:");
                strDOB = Console.ReadLine();
                if (DateTime.TryParse(strDOB, out _))
                {
                    inputDOB = DateTime.Parse(strDOB).Date;
                    break;
                }
                Console.WriteLine("DOB invalid, please try again");
            }

            switch (Customers.Count)
            {
                case 0:

                    Customer1.forename = inputForename;
                    Customer1.surname = inputSurname;
                    Customer1.street = inputStreet;
                    Customer1.town = inputTown;
                    Customer1.postcode = inputPostcode;
                    Customer1.houseNo = inputHouseNo;
                    Customer1.dob = inputDOB;
                    Customer1.Email = "";
                    Customer1.PhoneNumber = "";


                    while (Customer1.Email == "invalid")
                    {
                        Console.Write("Enter Email:");
                        Customer1.Email = Console.ReadLine();
                        if (Customer1.Email != "invalid")
                        {
                            break;
                        }
                        Console.WriteLine("Email invalid, please try again");

                    }

                    while (Customer1.PhoneNumber == "invalid")
                    {
                        Console.Write("Enter Phone Number:");
                        Customer1.PhoneNumber = Console.ReadLine();
                        if (Customer1.PhoneNumber != "invalid")
                        {
                            break;
                        }
                        Console.WriteLine("Phone Number invalid, please try again");

                    }

                    Customers.Insert(0, Customer1);

                    break;

                case 1:
                    Customer2.forename = inputForename;
                    Customer2.surname = inputSurname;
                    Customer2.street = inputStreet;
                    Customer2.town = inputTown;
                    Customer2.postcode = inputPostcode;
                    Customer2.houseNo = inputHouseNo;
                    Customer2.dob = inputDOB;
                    Customer2.Email = "";
                    Customer2.PhoneNumber = "";

                    while (Customer2.Email == "invalid")
                    {
                        Console.Write("Enter Email:");
                        Customer2.Email = Console.ReadLine();
                        if (Customer2.Email != "invalid")
                        {
                            break;
                        }
                        Console.WriteLine("Email invalid, please try again");

                    }

                    while (Customer2.PhoneNumber == "invalid")
                    {
                        Console.Write("Enter Phone Number:");
                        Customer2.PhoneNumber = Console.ReadLine();
                        if (Customer2.PhoneNumber != "invalid")
                        {
                            break;
                        }
                        Console.WriteLine("Phone Number invalid, please try again");

                    }

                    Customers.Insert(1, Customer2);

                    break;

                case 2:
                    Customer3.forename = inputForename;
                    Customer3.surname = inputSurname;
                    Customer3.street = inputStreet;
                    Customer3.town = inputTown;
                    Customer3.postcode = inputPostcode;
                    Customer3.houseNo = inputHouseNo;
                    Customer3.dob = inputDOB;
                    Customer3.Email = "";
                    Customer3.PhoneNumber = "";

                    while (Customer3.Email == "invalid")
                    {
                        Console.Write("Enter Email:");
                        Customer3.Email = Console.ReadLine();
                        if (Customer3.Email != "invalid")
                        {
                            break;
                        }
                        Console.WriteLine("Email invalid, please try again");

                    }

                    while (Customer3.PhoneNumber == "invalid")
                    {
                        Console.Write("Enter Phone Number:");
                        Customer3.PhoneNumber = Console.ReadLine();
                        if (Customer3.PhoneNumber != "invalid")
                        {
                            break;
                        }
                        Console.WriteLine("Phone Number invalid, please try again");

                    }

                    Customers.Insert(2, Customer3);

                    break;

                case 3:
                    Customer4.forename = inputForename;
                    Customer4.surname = inputSurname;
                    Customer4.street = inputStreet;
                    Customer4.town = inputTown;
                    Customer4.postcode = inputPostcode;
                    Customer4.houseNo = inputHouseNo;
                    Customer4.dob = inputDOB;
                    Customer4.Email = "";
                    Customer4.PhoneNumber = "";

                    while (Customer4.Email == "invalid")
                    {
                        Console.Write("Enter Email:");
                        Customer4.Email = Console.ReadLine();
                        if (Customer4.Email != "invalid")
                        {
                            break;
                        }
                        Console.WriteLine("Email invalid, please try again");

                    }

                    while (Customer4.PhoneNumber == "invalid")
                    {
                        Console.Write("Enter Phone Number:");
                        Customer4.PhoneNumber = Console.ReadLine();
                        if (Customer4.PhoneNumber != "invalid")
                        {
                            break;
                        }
                        Console.WriteLine("Phone Number invalid, please try again");

                    }

                    Customers.Insert(3, Customer4);

                    break;

                case 4:
                    Customer5.forename = inputForename;
                    Customer5.surname = inputSurname;
                    Customer5.street = inputStreet;
                    Customer5.town = inputTown;
                    Customer5.postcode = inputPostcode;
                    Customer5.houseNo = inputHouseNo;
                    Customer5.dob = inputDOB;
                    Customer5.Email = "";
                    Customer5.PhoneNumber = "";

                    while (Customer5.Email == "invalid")
                    {
                        Console.Write("Enter Email:");
                        Customer5.Email = Console.ReadLine();
                        if (Customer5.Email != "invalid")
                        {
                            break;
                        }
                        Console.WriteLine("Email invalid, please try again");

                    }

                    while (Customer5.PhoneNumber == "invalid")
                    {
                        Console.Write("Enter Phone Number:");
                        Customer5.PhoneNumber = Console.ReadLine();
                        if (Customer5.PhoneNumber != "invalid")
                        {
                            break;
                        }
                        Console.WriteLine("Phone Number invalid, please try again");

                    }

                    Customers.Insert(4, Customer5);

                    break;



            }

            return (Customers);
        }


    }
}
