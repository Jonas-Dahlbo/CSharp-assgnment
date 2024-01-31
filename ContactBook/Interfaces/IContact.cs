namespace ContactBook.Interfaces
{
    public interface IContact
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Adress { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
    }
}
