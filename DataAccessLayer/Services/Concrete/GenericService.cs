using DataAccessLayer.Services.Interfaces;
using DataAccessLayer.Settings;
using EntityLayer.Entities;
using MongoDB.Driver;
using System.Linq.Expressions;


namespace DataAccessLayer.Services.Concrete
{
    public class GenericService<T> : IGenericService<T> where T : IMongoEntity
    {
        private readonly IMongoCollection<T> _collection;

        public GenericService(DatabaseSettings databaseSettings)
        {
          
            var client = new MongoClient();
            var database= client.GetDatabase(databaseSettings.DatabaseName);
            var collectionName= database.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
            _collection = collectionName;
        }

        public async Task CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(x=>x.Id==id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _collection.AsQueryable().ToListAsync();
        }

       

        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(x=>x.Id==id).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetFilteredResultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.Find(predicate).ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await _collection.FindOneAndReplaceAsync<T>(x=>x.Id==entity.Id, entity);
        }
    }
}
