using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRecords.Repositories
{
    internal class CustomerRepository
    {

        public bool ValidateUser(string usernName, string Passoword)
        {
            try
            {
                var dc = new ContactsEntities1();

                var userRecord = dc.Users.Where(w => w.UserName == usernName && w.Passoword == Passoword).Count();

                if (userRecord > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool AddContact(string firstname, string surname, DateTime dob, string phone,string email) 
        {
            try
            {
                var dc = new ContactsEntities1();
                var customer = new Customer()
                {
                    FirstName = firstname,
                    LastName = surname,
                    DOB = dob,
                    PhoneNumber = phone,
                    Email = email,
                    Status = 0,
                    LastUpdated=DateTime.Now,
                    CreatedOne=DateTime.Now,
                };
                dc.Customers.Add(customer);
                dc.SaveChanges();
                
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public Customer GetCustomerByID(int customerId ) 
        {
            try
            {
                var dc = new ContactsEntities1();

                var customerrec = dc.Customers.Where(w=>w.Id==customerId).First();
                if (customerrec != null)
                    return customerrec;
                else
                    return null;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        public List <Customer> GetCustomer() 
        {
            var dc = new ContactsEntities1();

            var customerRecords = dc.Customers.Where(w => w.Status == 0).ToList();
            return customerRecords;

        }

        public bool UpdateCustomerById(int id, string firstName, string lastName,DateTime? dob, string email, string phone) 
        {
            try
            {
                var dc = new ContactsEntities1();
                
                var findRecord= dc.Customers.Where(w => w.Id == id).FirstOrDefault();
                if (findRecord != null) 
                {

                    findRecord.FirstName = firstName;
                    findRecord.LastName = lastName;
                    findRecord.DOB = dob;
                    findRecord.PhoneNumber = phone;
                    findRecord.Email = email;
                    findRecord.Status = 0;
                    findRecord.LastUpdated = DateTime.Now;
                    
                    dc.SaveChanges();
                }

                return true;
            }
            catch (Exception e) 
            {
                return false;
            }
        }

        public bool DeleteContact(int id) 
        {
            try
            {
                var dc = new ContactsEntities1();
                var rec = dc.Customers.Where(w=>w.Id==id).First();
                if (rec == null)
                    return false;
                rec.Status = 255;
                dc.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }

        }

        public List<Customer> GetDeletedRecords() 
        {
            try 
            {
                var dc = new ContactsEntities1();
                var rec = dc.Customers.Where(w => w.Status == 255).ToList();
                if (rec != null)
                    return rec;
                else
                    return null;
            }
            catch (Exception e)
            {
                return null;
            }
         
        }

        public bool RecoverContact(int id) 
        {
            try
            {
                var dc = new ContactsEntities1();
                var rec = dc.Customers.Where(w=>w.Id==id).First();
                rec.Status = 0;
                dc.SaveChanges();

                if (rec != null)
                    return true;
                else
                    return false;
            }
            catch (Exception e) 
            {
                return false;
            }
        }

    }

}
