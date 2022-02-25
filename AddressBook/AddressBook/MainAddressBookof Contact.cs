using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class MainAddressBookof_Contact
    {
        //Collection Class
        private List<Contact> contactList;
        private List<Contact> cityList;
        private List<Contact> stateList;
        //Constructor.
        public MainAddressBookof_Contact()
        {
            this.contactList = new List<Contact>();
        }
        //Method to Add Contact
        public void AddContactDetails(string firstName, string lastName, string address, string city, string state, long zipCode, long phoneNumber, string email, Dictionary<string, List<Contact>> stateDictionary, Dictionary<string, List<Contact>> cityDictionary)
        {

            // finding the data that already has the same first name
            Contact contact = this.contactList.Find(x => x.firstName.Equals(firstName));
            // if same name is not present then add into address book
            if (contact == null)
            {
                Contact contactDetails = new Contact(firstName, lastName, address, city, state, zipCode, phoneNumber, email);
                this.contactList.Add(contactDetails);
                if (!cityDictionary.ContainsKey(city))
                {

                    cityList = new List<Contact>();
                    cityList.Add(contactDetails);
                    cityDictionary.Add(city, cityList);
                }
                else
                {
                    List<Contact> cities = cityDictionary[city];
                    cities.Add(contactDetails);
                }
                if (!stateDictionary.ContainsKey(state))
                {

                    stateList = new List<Contact>();
                    stateList.Add(contactDetails);
                    stateDictionary.Add(state, stateList);
                }
                else
                {
                    List<Contact> states = stateDictionary[state];
                    states.Add(contactDetails);
                }
            }
            // print person already exists in the address book
            else
            {
                Console.WriteLine("Person, {0} is already exist in the address book", firstName);
            }
        }
        //Display Contact
        public void DisplayContact()
        {
            //cheks if ContactList is empty or not.
            if (this.contactList.Count != 0)
            {
                foreach (Contact data in this.contactList)
                {
                    data.Display();
                }
            }
            else
                Console.WriteLine("No Contacts in AddressBook \n");
        }
        //Method to Edit Contact 
        public void EditContact(string name)
        {
            // checks for every object whether the name is equal the given name
            foreach (Contact data in this.contactList)
            {
                if (data.firstName.Equals(name))
                {
                    Console.WriteLine("Enter your choice:");
                    Console.WriteLine("1. Last Name");
                    Console.WriteLine("2. Address");
                    Console.WriteLine("3. City");
                    Console.WriteLine("4. State");
                    Console.WriteLine("5. Zip");
                    Console.WriteLine("6. Phone Number");
                    Console.WriteLine("7. Email");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            data.lastName = Console.ReadLine();
                            Console.WriteLine("Data updated successfully \n");
                            break;
                        case 2:
                            data.address = Console.ReadLine();
                            Console.WriteLine("Data updated successfully \n");
                            break;
                        case 3:
                            data.city = Console.ReadLine();
                            Console.WriteLine("Data updated successfully \n");
                            break;
                        case 4:
                            data.state = Console.ReadLine();
                            Console.WriteLine("Data updated successfully \n");
                            break;
                        case 5:
                            data.zipCode = Convert.ToInt64(Console.ReadLine());
                            Console.WriteLine("Data updated successfully \n");
                            break;
                        case 6:
                            data.phoneNumber = Convert.ToInt64(Console.ReadLine());
                            Console.WriteLine("Data updated successfully \n");
                            break;
                        case 7:
                            data.email = Console.ReadLine();
                            Console.WriteLine("Data updated successfully \n");
                            break;
                        default:
                            Console.WriteLine("Enter Valid Choice! \n");
                            break;
                    }
                }
                else
                    Console.WriteLine("No Contact With this Name! \n");
            }
        }
        //Method to Delete a Person
        public void DeleteContact(string dName)
        {
            foreach (Contact ct in this.contactList)
            {
                if (ct.firstName.Equals(dName))
                {
                    this.contactList.Remove(ct);
                    Console.WriteLine("Contact Deleted! \n");
                    break;
                }
            }
        }
        /// <summary>
        /// display list of person across adress book system
        /// </summary>
        /// <param name="addressDictionary"></param>
        public static void DisplayPerson(Dictionary<string, MainAddressBookof_Contact> addressDictionary)
        {
            List<Contact> list = null;
            Console.WriteLine("Enter City or State name");
            string name = Console.ReadLine();
            foreach (var data in addressDictionary)
            {
                MainAddressBookof_Contact address = data.Value;
                list = address.contactList.FindAll(x => x.city.Equals(name) || x.state.Equals(name));
                if (list.Count > 0)
                {
                    DisplayList(list);
                }
            }
            if (list == null)
            {
                Console.WriteLine("No person present in the address book with same city or state name");
            }
        }
        /// <summary>
        /// display the data 
        /// </summary>
        /// <param name="list"></param>
        public static void DisplayList(List<Contact> list)
        {
            foreach (var data in list)
            {
                data.Display();
            }
        }
        /// <summary>
        /// display the person details by city or state
        /// </summary>
        /// <param name="dictinary"></param>
        public static void PrintList(Dictionary<string, List<Contact>> dictionary)
        {
            foreach (var data in dictionary)
            {
                Console.WriteLine("Details of person in {0}", data.Key);
                foreach (var person in data.Value)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", person.firstName, person.lastName, person.address,
                                                                   person.city, person.state, person.zipCode, person.phoneNumber, person.email);
                }
                Console.WriteLine("-----------------------------");
            }
        }
        /// <summary>
        /// count number of person by city or state
        /// </summary>
        /// <param name="dictionary"></param>
        public static void CountPerson(Dictionary<string, List<Contact>> dictionary, string name)
        {
            if (dictionary.ContainsKey(name))
            {
                foreach (var person in dictionary)
                {
                    Console.WriteLine("Number of person {0}", person.Value.Count);
                    break;
                }
            }
        }
        /// <summary>
        /// Sort the address Book by city, state and Zip.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        public static void SortData(Dictionary<string, List<Contact>> dictionary)
        {
            //store the result inthe list and display the result
            List<Contact> list = new List<Contact>();
            foreach (var data in dictionary)
            {
                foreach (var item in data.Value)
                {
                    list.Add(item);
                }
            }
            Console.WriteLine("\nDisplaying the list based on zipcode");
            //display the sorted value based on city
            foreach (var item in list.OrderBy(detail => detail.zipCode))
            {
                item.Display();
            }
            Console.WriteLine("\nDisplaying the list based on state");
            //display the sorted value based on city
            foreach (var item in list.OrderBy(detail => detail.state))
            {
                item.Display();
            }
            Console.WriteLine("\nDisplaying the list based on city");
            //display the sorted value based on city
            foreach (var item in list.OrderBy(detail => detail.city))
            {
                item.Display();
            }
        }
    }
}
