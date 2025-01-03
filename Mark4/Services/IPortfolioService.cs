﻿using Mark3.Data.Tables;

namespace Mark4.Services
{
    public interface IPortfolioService 
    {
        Task<List<PortfolioTable1>> GetPortfolioTable1sAsync(string _userName);
        Task<PortfolioTable1> CreatePortfolioTable1sAsync(PortfolioTable1 portfolioTable1);
    }
}
