using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories {
    public class UserRepository : EFRepository<Users>, IAsyncRepository<Users>{
        public UserRepository(BudgetTrackerDbContext dbContext) : base(dbContext) {

        }
        public async override Task<Users> GetByIdAsync(int id) {
            var user = await _dbContext.Users.Include(u => u.Incomes).Include(u => u.Expenditures).FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async override Task<IEnumerable<Users>> GetAllAsync() {
            var users = await _dbContext.Users.ToListAsync();
            return users;
        }
    }
}
