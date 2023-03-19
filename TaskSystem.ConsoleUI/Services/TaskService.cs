using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data;
using TaskManager.Data.Entities;

namespace TaskSystem.ConsoleUI.Services
{
    public class TaskService
    {
        private readonly DataContext _context = new DataContext();
        public async Task<List<TaskItemEntity>> GetAllTasksAsync()
        {
            List<TaskItemEntity> tasks = await _context.Tasks
                .Include(t => t.Supervisor)
                .Include(t => t.Reportee)
                .Include(t => t.Comments)
                .Include(t => t.Status)
                .ToListAsync();

            return tasks;
        }
        public async Task<TaskItemEntity> GetTaskByIdAsync(int id)
        {
            var task = await _context.Tasks
                .Include(t => t.Supervisor)
                .Include(t => t.Reportee)
                .Include(t => t.Comments)
                .Include(t => t.Status)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
            {
                throw new Exception("Task not found.");
            }

            return task;
        }
        public async Task AddTaskAsync(TaskItemEntity task)
        {
            task.CreatedDate = DateTime.Now;

            await _context.Tasks.AddAsync(task);
            _context.SaveChanges();
        }
        public async Task EditTaskSupervisorAsync(int taskId, int newSupervisorId)
        {
            var taskToUpdate = await _context.Tasks.FindAsync(taskId);
            taskToUpdate.SupervisorId = newSupervisorId;
            _context.SaveChanges();
        }
        public async Task EditTaskStatusAsync(int taskId, int newStatusId)
        {
            var taskToUpdate = await _context.Tasks.FindAsync(taskId);
            taskToUpdate.StatusId = newStatusId;
            _context.SaveChanges();
        }
        public async Task AddCommentToTaskAsync(CommentEntity comment)
        {
            await _context.AddAsync(comment);
            _context.SaveChanges();
        }
    }
}
