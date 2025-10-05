using Portfolio.EntityModels;
//using Portfolio.EntityModels.Models;

using Microsoft.EntityFrameworkCore;

public class ClientRepository:IClient
{
    private readonly PostgresWebPortfolioContext _db;

    public ClientRepository(PostgresWebPortfolioContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<WpClient>> GetWpClientsAsync()
    {
        IEnumerable<WpClient> clients =  await _db.WpClients.ToListAsync();

        return clients;
    }
}