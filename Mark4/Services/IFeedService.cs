using Mark3.Data.Tables;

namespace Mark4.Services
{
    public interface IFeedService
    {
        Task<List<FeedTable1>> GetFeedTable1sAsync(int _instrumentId, int _intervalNum, int takeLast);
        Task<FeedTable1> CreateFeedTable1sAsync(FeedTable1 feedTable1);
    }
}
