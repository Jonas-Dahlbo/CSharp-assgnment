﻿using ContactBook.Interfaces;
using ContactBook.Models;
using ContactBook.Services;
using Moq;

namespace ContactBook.Tests
{
    public class ContactService_Tests
    {
        [Fact]

        public void GetAllFromListShould_GetAllContactsInList_ThenReturnListOfContacts()
        {
            //Arrange 
            IContact contact = new Contact { FirstName = "Per", LastName = "Olofsson", Adress = "MinGata 123", Email = "Peol@domain.com", Phone = "0731234567" };
            var mockFileService = new Mock<IFileService>();
            IContactServices contactService = new ContactServices(mockFileService.Object);
            contactService.AddContactToList(contact);

            //Act
            IEnumerable<IContact> result = contactService.GetAllContacts();

            //Assert
            Assert.NotNull(result);
            IContact returned_contact = result.FirstOrDefault();
            Assert.NotNull(returned_contact);
            Assert.Equal(contact.FirstName, returned_contact.FirstName);
        }

        [Fact]

        public void AddToListShould_AddContactToList_ThenReturnTrue()
        {
            //Arrange
            var mockFileService = new Mock<IFileService>();
            IContactServices contactService = new ContactServices(mockFileService.Object);
            IContact contact = new Contact { FirstName = "Per", LastName = "Olofsson", Adress = "MinGata 123", Email = "Peol@domain.com", Phone = "0731234567" };


            //Act
            bool result = contactService.AddContactToList(contact);

            //Assert
            Assert.True(result);
        }

        [Fact]

        public void AddToListShould_FailToAddContactToList_ThenReturnFalse()
        {
            //Arrange
            var mockFileService = new Mock<IFileService>();
            IContactServices contactService = new ContactServices(mockFileService.Object);
            IContact contact = new Contact { FirstName = "Per", LastName = "Olofsson", Adress = "MinGata 123", Email = "Peol@domain.com", Phone = "0731234567" };
            contactService.AddContactToList(contact);

            //Act
            bool result = contactService.AddContactToList(contact);

            //Assert
            Assert.False(result);
        }

        [Fact]

        public void RemoveContactFromListShould_RemoveContactFromList_ThenReturnTrue()
        {
            //Arrange
            var mockFileService = new Mock<IFileService>();
            IContactServices contactService = new ContactServices(mockFileService.Object);
            IContact contact = new Contact { FirstName = "Per", LastName = "Olofsson", Adress = "MinGata 123", Email = "Peol@domain.com", Phone = "0731234567" };
            contactService.AddContactToList(contact);
            string contactEmail = "Peol@domain.com";

            //Act
            bool result = contactService.RemoveContactFromList(contactEmail);

            //Assert
            Assert.True(result);
        }

        [Fact]

        public void RemoveContactFromListShould_FailToRemoveContactFromList_ThenReturnFalse()
        {
            //Arrange
            var mockFileService = new Mock<IFileService>();
            IContactServices contactService = new ContactServices(mockFileService.Object);
            IContact contact = new Contact { FirstName = "Per", LastName = "Olofsson", Adress = "MinGata 123", Email = "Peol@domain.com", Phone = "0731234567" };
            contactService.AddContactToList(contact);
            string contactEmail = "123@domain.com";

            //Act
            bool result = contactService.RemoveContactFromList(contactEmail);

            //Assert
            Assert.False(result);
        }
    }
}
