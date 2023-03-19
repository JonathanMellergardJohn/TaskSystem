using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Data.Entities;

namespace TaskSystem.ConsoleUI.Services
{
    public class StaffService
    {
        private readonly DataContext _context = new DataContext();
        public async Task<List<StaffEntity>> GetAllStaffAsync()
        {
            List<StaffEntity> list = await _context.Staff
                .Include(s => s.SupervisedTasks)
                    .ThenInclude(t => t.Comments)
                .Include(s => s.SupervisedTasks)
                    .ThenInclude(t => t.Status)
                .Include(s => s.ReportedTasks)
                    .ThenInclude(t => t.Comments)
                 .Include(s => s.ReportedTasks)
                    .ThenInclude(t => t.Status)
                .ToListAsync();

            return list;
        }
        public async Task<StaffEntity> GetStaffById(int id)
        {
            var staff = await _context.Staff
                 .Include(s => s.SupervisedTasks)
                    .ThenInclude(t => t.Comments)
                .Include(s => s.SupervisedTasks)
                    .ThenInclude(t => t.Status)
                .Include(s => s.ReportedTasks)
                    .ThenInclude(t => t.Comments)
                 .Include(s => s.ReportedTasks)
                    .ThenInclude(t => t.Status)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (staff == null)
            {
                throw new Exception("Staff not found.");
            }

            return staff;
        }
    }
}
