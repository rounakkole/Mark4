using Mark3.Data.Tables;
using Mark4.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Mark4.Services
{
    public class PortfolioService : IPortfolioService
    {
        //youtu.be/w8imy7LT9zY
        private readonly ApplicationDbContext _context;
        private IQueryable<PortfolioTable1> FilteredGrid;
        public PortfolioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PortfolioTable1> CreatePortfolioTable1sAsync(PortfolioTable1 portfolioTable1)
        {
            _context.PortfolioTable1.Add(portfolioTable1);
            await _context.SaveChangesAsync();
            //NavigationManager.NavigateTo("/portfoliotable1s");
            return portfolioTable1;
        }

        public async Task<List<PortfolioTable1>> GetPortfolioTable1sAsync(string _userName)
        {
            //var PortfolioTable1s = await _context.PortfolioTable1.ToListAsync();
            //var tickets = (await (from ...).ToListAsync()).Select(...);
            FilteredGrid = _context.PortfolioTable1.Where(m => m.ApplicationUser.Email.Equals(_userName))
                .Include(m => m.InstrumentTable1)
                .Include(m => m.ApplicationUser);
            List<PortfolioTable1> PortfolioTable1s = await FilteredGrid.ToListAsync();
            return PortfolioTable1s;
            //throw new NotImplementedException();
        }
    }
}
