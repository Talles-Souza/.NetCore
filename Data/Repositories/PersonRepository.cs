
using Data.Context;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ContextDb _db;

        public PersonRepository(ContextDb db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public async Task<ICollection<Person>> FindByAll()
        {
            List<Person> people = await _db.People.ToListAsync();
            return people;
        }

        public async Task<Person> FindById(int id)
        {
          Person person = await _db.People.FirstOrDefaultAsync(x => x.Id == id);
            return person;
        }

        public async Task<Person> Create(Person person)
        {
            _db.Add(person);
            await _db.SaveChangesAsync();
            return person;
        }
        public async Task<Person> Update(Person person)
        {
            _db.Update(person);
            await _db.SaveChangesAsync();
            return person;

        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                Person people = await _db.People.Where(p => p.Id == id)
                                    .FirstOrDefaultAsync();
                if (people == null) return false;
                _db.People.Remove(people);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public async Task<int> FindByIdDocument(string document)
        {
            return (await _db.People.FirstOrDefaultAsync(x => x.Document == document))?.Id ?? 0;
        }
    }
}
