namespace ContactBook.Interfaces
{
    public interface IContactServices
    {
        public IEnumerable<IContact> GetAllContacts();

        public bool AddContactToList(IContact contact);

        public bool RemoveContactFromList(string contactEmail);

        public void ShowContact(string contactId);
    }
}
