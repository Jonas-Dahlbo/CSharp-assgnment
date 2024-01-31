using ContactBook.Interfaces;
using ContactBook.Models;

namespace ContactBook.Services
{
    public class MenuService : IMenuService
    {
        /// <summary>
        /// Displays the contactbook and handles the menu
        /// </summary>
        public void DisplayMenu()
        {
            IFileService fileService = new FileServices();
            IContactServices contactService = new ContactServices(fileService);

            Console.Clear();
            Console.WriteLine("  Contact Book");
            Console.WriteLine("----------------");

            int _id = 0;

            foreach (var c in contactService.GetAllContacts())
            {
                _id = _id + 1;
                c.Id = _id;
                Console.WriteLine($"{c.Id,-3} {c.FirstName} {c.LastName}");
            }

            Console.WriteLine("\nEnter a contact's id number to get detailed informaiton\n");
            Console.WriteLine("Type add: to add a contact");
            Console.WriteLine("Type remove: to remove a contact");
            Console.WriteLine("Type close: to close the application");

            IContact contact = new Contact();
            string _menuInput = Console.ReadLine().ToLower();

            switch (_menuInput)
            {
                case "add":
                    Console.Clear();
                    Console.WriteLine("Please enter a first name:");
                    contact.FirstName = Console.ReadLine().Trim();
                    Console.WriteLine("Please enter a surname:");
                    contact.LastName = Console.ReadLine().Trim();
                    Console.WriteLine("Please enter an adress:");
                    contact.Adress = Console.ReadLine().Trim();
                    Console.WriteLine("Please enter an Email:");
                    contact.Email = Console.ReadLine().Trim();
                    Console.WriteLine("Pleanse enter a phonenumber");
                    contact.Phone = Console.ReadLine().Trim();
                    contactService.AddContactToList(contact);
                    DisplayMenu();
                    break;
                case "remove":
                    Console.Clear();
                    Console.WriteLine("Please enter the email adress of the contact you wish to remove\n");
                    foreach (var c in contactService.GetAllContacts())
                    {
                        Console.WriteLine($"{c.FirstName} {c.LastName} {c.Email}");
                    }
                    Console.WriteLine();
                    contactService.RemoveContactFromList(Console.ReadLine().Trim());
                    DisplayMenu();
                    break;
                case "close":
                    break;
                default:
                    contactService.ShowContact(_menuInput);
                    Console.Clear();
                    DisplayMenu();
                    break;
            }
        }
    }
}
