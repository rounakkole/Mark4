using Mark3.Data.Tables;
using Mark4.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Mark4.Services
{
    public class FeedService : IFeedService
    {
        //youtu.be/w8imy7LT9zY
        private readonly ApplicationDbContext _context;
        private IQueryable<FeedTable1> FilteredGrid;
        public FeedService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FeedTable1> CreateFeedTable1sAsync(FeedTable1 feedTable1)
        {
            _context.FeedTable1.Add(feedTable1);
            await _context.SaveChangesAsync();
            //NavigationManager.NavigateTo("/feedtable1s");
            return feedTable1;
        }

        public async Task<List<FeedTable1>> GetFeedTable1sAsync(int _instrumentId, int _intervalNum, int takeLast)
        {
            //var FeedTable1s = await _context.FeedTable1.ToListAsync();
            //var tickets = (await (from ...).ToListAsync()).Select(...);
            FilteredGrid = _context.FeedTable1.Where(m => (m.InstrumentId.Equals(_instrumentId))
                                                 && (m.IntervalNum.Equals(_intervalNum)))
            .OrderByDescending(m => m.FeedDateTime)
            .Take(takeLast)
            .OrderBy(m => m.FeedDateTime)
            .Include(m => m.InstrumentTable1);
            List<FeedTable1> FeedTable1s = await FilteredGrid.ToListAsync();
            return FeedTable1s;
            //throw new NotImplementedException();
        }
    }
}
