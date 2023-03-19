using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Data.Entities;
using TaskSystem.ConsoleUI.Services;

DataContext _context = new DataContext();
TaskService taskService = new TaskService();
DisplayService displayService = new DisplayService();
StaffService staffService = new StaffService();
MenuService menuService = new MenuService();

menuService.LogInView();
