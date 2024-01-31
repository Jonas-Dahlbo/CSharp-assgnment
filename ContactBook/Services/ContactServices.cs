using ContactBook.Interfaces;
using System.Diagnostics;
using Newtonsoft.Json;
using ContactBook.Models;

namespace ContactBook.Services
{
    public class ContactServices : IContactServices
    {
        private readonly IFileService _fileService;

        public ContactServices(IFileService fileService)
        {
            _fileService = fileService;
        }

        private readonly string _filePath = @"..\..\..\Repositories\contactbook.json";
        private List<IContact> _contactList = new List<IContact>();

        public IEnumerable<IContact> GetAllContacts()
        {
            try
            {
                var content = _fileService.GetContentFromFile(_filePath);
                if (!string.IsNullOrEmpty(content))
                {
                    _contactList = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Objects,
                    })!;
                }

                return _contactList;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        public bool AddContactToList(IContact contact)
        {
            try
            {
                if (!_contactList.Any(x => x.Email.ToLower() == contact.Email.ToLower()))
                {
                    _contactList.Add(contact);
                    var json = JsonConvert.SerializeObject(_contactList, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Objects,
                    });

                    _fileService.SaveToFile(_filePath, json);
                    return true;
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return false;
        }


        public bool RemoveContactFromList(string contactEmail)
        {
            try
            {

                foreach (IContact contact in _contactList)
                {
                    if (contact.Email.ToLower() == contactEmail.ToLower())
                    {
                        _contactList.Remove(contact);
                        var json = JsonConvert.SerializeObject(_contactList, new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Objects,
                        });
                        _fileService.SaveToFile(_filePath, json);
                        Console.WriteLine("Contact removed\n\n");
                        return true;

                    }
                }
                Console.WriteLine("\nPlease enter a Email adress of an existing contact\n");
            }

            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return false;

        }

        public void ShowContact(string contactId)
        {
            try
            {
                foreach (Contact contact in _contactList)
                {
                    if (!Int32.TryParse(contactId, out int idInt) || idInt > _contactList.Count)
                    {
                        Console.WriteLine("\nPlease enter a valid id number");
                        ShowContact(Console.ReadLine().Trim());
                        break;
                    }
                    else if (contact.Id == idInt)
                    {

                        Console.Clear();
                        Console.WriteLine($"\n{contact.FirstName,0} {contact.LastName,0} {contact.Adress,25} {contact.Email,25} {contact.Phone,25}\n");
                        Console.WriteLine("Press any key to return to the Contact Book");
                        Console.ReadKey();
                    }
                }
            }
            catch (Exception ex) { Debug.WriteLine($"{ex.Message}"); }
        }
    }
}
