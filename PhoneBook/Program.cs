﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            View view = new View();
            ContactList contactList = new ContactList();
            while (true)
            {
                view.StartMenu();
                var v = view.GetInput();
                if (v.ToUpper() == "Q")
                {
                    System.Environment.Exit(0);
                }
                // Display all contacts.
                else if (v == "1")
                {
                    List<Contact> contacts = contactList.GetAllContacts();
                    if (contacts.Count == 0)
                        view.NoContacts();
                    else
                    {
                        view.PrintContacts(contacts);
                    }
                    view.PauseForUser();
                }
                // Add a contact.
                else if (v == "2")
                {
                    Contact contact = new Contact();
                    contact.FirstName = view.GetInputFor("Please enter your first name");
                    contact.LastName = view.GetInputFor("Please enter your last name");
                    contact.PhoneNumber = view.GetInputFor("Please enter your phone number");
                    contactList.AddContact(contact);
                    Console.Clear();
                    view.PrintContact(contact);
                    view.ContactAdded();
                    view.PauseForUser();
                }
                // Delete a contact.
                else if (v == "3")
                {
                    List<Contact> contacts = contactList.GetAllContacts();
                    if (contacts.Count == 0)
                    {
                        view.NoContacts();
                    }
                    else
                    {
                        view.PrintContacts(contacts);
                        int deletenumber =
                            int.Parse(view.GetContactNoFor("Enter number of contact to delete"));
                        if (deletenumber > contacts.Count || deletenumber < 1)
                        {
                            view.ContactInvalid();
                            view.PauseForUser();
                            continue;
                        }
                        else
                        {
                            contacts.RemoveAt(deletenumber - 1);
                            view.ContactDeleted();
                        }
                    }
                    view.PauseForUser();
                }
                // Edit a contact.
                else if (v == "4")
                {
                    List<Contact> contacts = contactList.GetAllContacts();
                    if (contacts.Count == 0)
                    {
                        view.NoContacts();
                    }
                    else
                    {
                        view.PrintContacts(contacts);
                        int editnumber =
                            int.Parse(view.GetContactNoFor("Please enter the number of the contact to edit"));
                        if (editnumber > contacts.Count || editnumber < 1)
                        {
                            view.ContactInvalid();
                            view.PauseForUser();
                            continue;
                        }
                        else
                        {
                            view.PrintContact(contacts[editnumber - 1]);
                            contacts[editnumber - 1].FirstName = view.GetInputFor("Enter the updated first name");
                            contacts[editnumber - 1].LastName = view.GetInputFor("Enter the updated last name");
                            contacts[editnumber - 1].PhoneNumber = view.GetInputFor("Enter the updated phone number");
                            Console.WriteLine();
                            view.PrintContact(contacts[editnumber - 1]);
                            view.ContactUpdated(editnumber);
                        }
                    }
                    view.PauseForUser();
                }
            }
        }
    }
}
