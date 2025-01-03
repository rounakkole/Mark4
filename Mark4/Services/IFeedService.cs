using Mark3.Data.Tables;

namespace Mark4.Services
{
    public interface IFeedService
    {
        Task<List<FeedTable1>> GetFeedTable1sAsync(string _instrument);
        Task<FeedTable1> CreateFeedTable1sAsync(FeedTable1 feedTable1);
    }
}
