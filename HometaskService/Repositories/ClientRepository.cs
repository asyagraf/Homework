using HometaskService.Database;
using HometaskService.DBModels;
using HometaskService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HometaskService.Repositories
{
    public class ClientRepository : IRentalRepository<DbClient>
    {
        private readonly HometaskServiceDbContext dbContext;
        public ClientRepository()
        {
            dbContext = new HometaskServiceDbContext();
        }
        public async Task<DbClient> GetById(int id)
        {
            return await dbContext.Clients.FindAsync(id);
        }

        public async Task<List<DbClient>> GetAll()
        {
            return await dbContext.Clients.ToListAsync();
        }

        public async Task Create(DbClient client)
        {
            await dbContext.Clients.AddAsync(client);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var client = await dbContext.Clients.FindAsync(id);
            dbContext.Clients.Remove(client);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(DbClient client)
        {
            var newClient = await dbContext.Clients.FindAsync(client.Id);
            newClient.FirstName = client.FirstName;
            newClient.LastName = client.LastName;
            newClient.MiddleName = client.MiddleName;
            newClient.Experience = client.Experience;
            await dbContext.SaveChangesAsync();
        }
    }
}
