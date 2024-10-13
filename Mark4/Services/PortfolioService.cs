using Mark3.Data.Tables;
using Mark4.Data;
using Microsoft.EntityFrameworkCore;

namespace Mark4.Services
{
    public class PortfolioService : IPortfolioService
    {
        //youtu.be/w8imy7LT9zY
        private readonly ApplicationDbContext _context;
        private IQueryable<PortfolioTable1> FilteredGrid;// => _context.PortfolioTable1.Where(m => m.ApplicationUser.Email.Equals("rk@gmail.com"));
        public PortfolioService(ApplicationDbContext context)
        { 
        _context = context;
        }
        public async Task<List<PortfolioTable1>> GetPortfolioTable1sAsync(string _userName)
        {
            //var PortfolioTable1s = await _context.PortfolioTable1.ToListAsync();
            //var tickets = (await (from ...).ToListAsync()).Select(...);
            FilteredGrid = _context.PortfolioTable1.Where(m => m.ApplicationUser.Email.Equals(_userName));
            var PortfolioTable1s = await FilteredGrid.ToListAsync();
            return PortfolioTable1s;
            //throw new NotImplementedException();
        }

        public Task<List<PortfolioTable1>> GetPortfolioTable1sAsync()
        {
            throw new NotImplementedException();
        }
    }
}
