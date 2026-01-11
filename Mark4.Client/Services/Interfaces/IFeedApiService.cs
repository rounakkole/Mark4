using static Mark4.Client.Services.FeedApiService;

namespace Mark4.Client.Services
{
    public interface IFeedApiService 
    {
        Task<FeedApiTable> GetFeedTablesApi(string _instrumentName, string _intervalNum);
    }
}




