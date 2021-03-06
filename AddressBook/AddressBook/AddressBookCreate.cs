using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class AddressBookCreate
    {
        static MainAddressBookof_Contact addressBookMain = new MainAddressBookof_Contact();
        static Dictionary<string, MainAddressBookof_Contact> addressBook = new Dictionary<string, MainAddressBookof_Contact>();
        static Dictionary<string, List<Contact>> cityDictionary = new Dictionary<string, List<Contact>>();
        static Dictionary<string, List<Contact>> stateDictionary = new Dictionary<string, List<Contact>>();
        //created List of class Type.
        public void ReadInput()
        {
            bool CONTINUE = true;

            //the loop continues until the user exit from program.
            while (CONTINUE)
            {
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1.Add Address Book");
                Console.WriteLine("2.Add contacts");
                Console.WriteLine("3.Display");
                Console.WriteLine("4.Edit Details");
                Console.WriteLine("5.Delete Person");
                Console.WriteLine("6.Add Multiple Address Book");
                Console.WriteLine("7.Delete Any Address Book");
                Console.WriteLine("8.Display person by city or state name");
                Console.WriteLine("9.View person by city or state");
                Console.WriteLine("10.Count person by city or state");
                Console.WriteLine("11.Sort the Address book");
                Console.WriteLine("12.Sort by state city or zip");
                Console.WriteLine("0.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddressBookCreate.AddBook();
                        break;
                    case 2:
                        AddDetails(AddressBookCreate.BookName(addressBook), cityDictionary, stateDictionary);
                        break;
                    case 3:
                        addressBookMain = AddressBookCreate.BookName(addressBook);
                        addressBookMain.DisplayContact();
                        break;
                    case 4:
                        addressBookMain = AddressBookCreate.BookName(addressBook);
                        Console.WriteLine("Enter the first name of person");
                        string name = Console.ReadLine();
                        addressBookMain.EditContact(name);
                        break;
                    case 5:
                        addressBookMain = AddressBookCreate.BookName(addressBook);
                        Console.WriteLine("Enter the first name of person");
                        string dName = Console.ReadLine();
                        addressBookMain.DeleteContact(dName);
                        break;
                    case 6:
                        AddMultipleAddressBook();
                        break;
                    case 7:
                        Console.WriteLine("Enter address book name to delete:");
                        string addressBookName = Console.ReadLine();
                        addressBook.Remove(addressBookName);
                        break;
                    case 8:
                        MainAddressBookof_Contact.DisplayPerson(addressBook);
                        break;
                    case 9:
                        MainAddressBookof_Contact.PrintList(cityDictionary);
                        MainAddressBookof_Contact.PrintList(stateDictionary);
                        break;
                    case 10:
                        Console.WriteLine("Enter City Name");
                        string city = Console.ReadLine();
                        MainAddressBookof_Contact.CountPerson(cityDictionary, city);
                        Console.WriteLine("Enter State Name");
                        string state = Console.ReadLine();
                        MainAddressBookof_Contact.CountPerson(stateDictionary, state);
                        break;
                    case 11:
                        Console.WriteLine("AddressBook after sorting");
                        foreach (var data in addressBook.OrderBy(x => x.Key))
                        {
                            Console.WriteLine("{0}", data.Key);
                        }
                        break;
                    case 12:
                        //displaying the sorted records based on city,state,zipcode
                        MainAddressBookof_Contact.SortData(cityDictionary);
                        break;
                    case 0:
                        CONTINUE = false;
                        break;
                    default:
                        break;
                }
            }
        }
        //Method to create a AddressBook in Dictionary
        public static void AddBook()
        {
            Console.WriteLine("Enter address book name:");
            string addBookName = Console.ReadLine();
            addressBook.Add(addBookName, addressBookMain);
        }
        /// <summary>
        /// This method is used to add a new contact.
        /// </summary>
        /// <param name="addressBookMain"></param>
        public static void AddDetails(MainAddressBookof_Contact addressMain, Dictionary<string, List<Contact>> cityDictionary, Dictionary<string, List<Contact>> stateDictionary)
        {
            Console.WriteLine("Enter first Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter City");
            string city = Console.ReadLine();
            Console.WriteLine("Enter State");
            string state = Console.ReadLine();
            Console.WriteLine("Enter Zipcode");
            long zipCode = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Phone Number");
            long phoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();

            addressMain.AddContactDetails(firstName, lastName, address, city, state, zipCode, phoneNumber, email, stateDictionary, cityDictionary);
        }
        //Method to Add Multiple Contact
        public void AddMultipleAddressBook()
        {
            Console.WriteLine("How many AddressBook,you want to Add");
            int cNumber = int.Parse(Console.ReadLine());
            for (int i = 1; i <= cNumber; i++)
            {
                AddressBookCreate.AddBook();
            }
            Console.WriteLine("All Address Book Added successfully! \n");
        }
        /// <summary>
        /// method to find the address of particular address book.
        /// </summary>
        /// <param name="addBook"></param>
        /// <returns></returns>
        public static MainAddressBookof_Contact BookName(Dictionary<string, MainAddressBookof_Contact> addBook)
        {
            try
            {
                addressBook = addBook;
                Console.WriteLine("Enter address book name:");
                string name = Console.ReadLine();
                MainAddressBookof_Contact address = addressBook[name];
                return address;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                addressBook = addBook;
                Console.WriteLine("Enter address book name:");
                string name = Console.ReadLine();
                MainAddressBookof_Contact address = addressBook[name];
                return address;
            }
        }
    }
}

