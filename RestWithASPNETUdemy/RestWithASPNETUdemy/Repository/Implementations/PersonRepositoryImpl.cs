using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Models.Context;
using RestWithASPNETUdemy.Repository;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PersonRepositoryImpl : IPersonRepository
    {
        private PostgreSQLContext _context;

        public PersonRepositoryImpl(PostgreSQLContext context)
        {
            _context = context;
        }
        
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            try
            {
                if(result != null)
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {

            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id))
                return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            return person;
        }

        public bool Exists(long? id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
