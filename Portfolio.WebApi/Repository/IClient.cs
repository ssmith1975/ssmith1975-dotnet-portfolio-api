using Portfolio.EntityModels;

public interface IClient
{
    public Task<IEnumerable<WpClient>> GetWpClientsAsync();
}