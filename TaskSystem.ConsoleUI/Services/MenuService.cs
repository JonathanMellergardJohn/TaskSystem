using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.Entities;
using TaskSystem.Data.Migrations;

namespace TaskSystem.ConsoleUI.Services
{
    public class MenuService
    {
        TaskService taskService = new TaskService();
        DisplayService display = new DisplayService();
        StaffService staff = new StaffService();
        
        public void LogInView()
        {
            // set staff list          
            var staffList = staff.GetAllStaffAsync().Result;

            Console.Clear();
            Console.WriteLine(" ~~~~~((( TASK MANAGER APP )))~~~~~ \n");
            Console.WriteLine("Log in by typing your Staff ID in the console \n" +
                                "and pressing 'enter'. If you have forgotten \n" +
                                "your Staff ID, you can find your name in the \n" +
                                "list provided below.\n" +
                                "To exit the Task Manager App, type 'Q'.");

            display.DisplayStaffListShort(staffList);
            Console.Write("\nYour Staff ID: ");
            string input = Console.ReadLine();

            switch (input)
            {
                default:
                    Console.WriteLine(  "Invalid input. Please provide a valid Staff ID. Consult\n" +
                                        "the list that is provided if you have forgotten your ID." +
                                        "Press enter to continue.");
                    Console.ReadLine();
                    Console.Clear();
                    LogInView();
                    break;
                case "Q":
                    Console.WriteLine("Thank you for using the Task Manager App! Press enter to exit...");
                    Console.ReadLine();
                    Environment.Exit(0);
                    break;
                case string caseValue when staffList.Any(sl => sl.Id.ToString() == caseValue):
                    var user = staffList.Single(sl => sl.Id.ToString() == caseValue);
                    if (user.IsAdmin == true)
                    {
                        AdminMenuView(user);
                    }
                    else
                    {
                        Console.Clear();
                        StaffMenuView(user);
                    }
                    break;
            }

        }

        // staff views tree

        public void StaffMenuView(StaffEntity user)
        {
            Console.Clear();
            Console.WriteLine("\n ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ");
            Console.WriteLine($" Logged in as {user.FirstName.ToUpper()} {user.LastName.ToUpper()}");
            Console.WriteLine(  " ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ");
            Console.WriteLine(  " What would you like to do? Chose from \n" +
                                " the options in the menu below.\n");

            Console.WriteLine(  " ---- MENU ----");
            Console.WriteLine(  " 1 - View your profile");
            Console.WriteLine(  " 2 - View tasks you supervise");
            Console.WriteLine(  " 3 - View tasks you have reported");
            Console.WriteLine(  " 4 - Report a new task to be handled");
            Console.WriteLine(  " 00 - Log out and return to starting menu");
            Console.WriteLine(  " --------------");
            Console.WriteLine("\n");
            Console.Write("Your selection: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    UserProfileView(user);
                    break;
                case "2":
                    UserSupervisedTasksView(user);
                    break;
                case "3":
                    UserReportedTasksView(user);
                    break;
                case "4":
                    ReportNewTaskView(user);
                    break;
                case "00":
                    LogInView();
                    break;
                default:
                    Console.WriteLine(  "Your selection is not available. Please consult the provided" +
                                        "menu and make your selection. Press enter to continue.");
                    Console.ReadLine();
                    StaffMenuView(user);
                    break;
            }
        }
        public void UserProfileView(StaffEntity user)
        {
            Console.Clear();
            display.DisplaySingleStaffFull(user);
            Console.WriteLine("\n");
            Console.WriteLine(  "Press 0 to return to the previous menu. " +
                                "Press 00 to log out and return to starting menu.\n");
            Console.Write("Your selection: ");

            string input = Console.ReadLine();

            switch (input)
            {
                default:
                    Console.WriteLine(  "Your selection is not available. Please consult the" +
                                        "instructions provided under your profile for " +
                                        "available options. Press enter to continue.");
                    Console.ReadLine();
                    UserProfileView(user);
                    break;
                case "0":
                    StaffMenuView(user);
                    break;
                case "00":
                    LogInView();
                    break;
            }
        }
        public void UserSupervisedTasksView(StaffEntity user)
        {
            // fetch list of supervised tasks
            List<TaskItemEntity> tasks = user.SupervisedTasks.ToList();

            Console.Clear();
            Console.WriteLine(      " --- YOUR SUPERVISED TASKS --- ");
            if (tasks.Count > 0) 
                display.DisplayTaskListShort(tasks);
            else 
                Console.WriteLine("     You have no tasks for supervision at this time!");
                Console.WriteLine(  " ----------------------------- ");
            Console.WriteLine("\n");
            Console.WriteLine(  "To inspect a task, type its TASK ID in the console.\n" +
                                "To return to the previous menu, press 0. To log out\n" +
                                "and return to the starting menu, press 00.\n");
            Console.Write("Your selection: ");
            string input = Console.ReadLine();

            switch (input)
            {
                default:
                    Console.WriteLine("Your selection is not available. Please consult the provided" +
                                        "menu and make your selection. Press enter to continue.");
                    Console.ReadLine();
                    UserSupervisedTasksView(user);
                    break;
                case "0":
                    StaffMenuView(user);
                    break;
                case "00":
                    LogInView();
                    break;
                case string caseValue when tasks.Any(ti => ti.Id.ToString() == caseValue):
                    var taskToView = tasks.Single(ti => ti.Id.ToString() == caseValue);
                    SingleSupervisedTaskView(user, taskToView);
                    break;
            }

        }
        public void SingleSupervisedTaskView(StaffEntity user, TaskItemEntity task)
        {
            Console.Clear();
            display.DisplaySingleTaskFull(task);
            Console.WriteLine("\n");
            Console.WriteLine("To add a comment to your task, press 1. To return \n" +
                                "to the previous menu, press 0. To log out and return \n" +
                                "to the starting menu, press 00.");
            Console.Write("Your selection: ");
            string input = Console.ReadLine();

            switch (input)
            {
                default:
                    Console.WriteLine("Your selection is not available. Please consult the provided" +
                                        "menu and make your selection. Press enter to continue.");
                    SingleSupervisedTaskView(user, task);
                    break;
                case "0":
                    UserSupervisedTasksView(user);
                    break;
                case "00":
                    LogInView();
                    break;
                case "1":
                    // ugly...
                    _ = WriteCommentView(user, task);
                    break;
            }
        }
        public async Task WriteCommentView(StaffEntity user, TaskItemEntity task)
        {
            // set Authors role
            string authRole = "Supervisor";

            if (user.IsAdmin == true)
            {
                authRole = "Administrator";
            }
            // create entity
            CommentEntity comment = new CommentEntity
            {
                Author = $"{user.FirstName} {user.LastName}",
                AuthorRole = authRole,
                TaskItemId = task.Id
            };
            Console.Clear();
            display.DisplaySingleTaskFull(task);
            Console.WriteLine("\n");

            Console.Write("Your comment: ");
            string text = Console.ReadLine();

            comment.Text = text;
            comment.Time = DateTime.Now.ToString();

            await taskService.AddCommentToTaskAsync(comment);

            //user = await staff.GetStaffById(user.Id);

            Console.WriteLine("Your comment has been added! Press any key to return to return to your tasks.");
            Console.ReadLine();
            UserSupervisedTasksView(user);
        }
        public void UserReportedTasksView(StaffEntity user)
        {
            // set list of tasks
            List<TaskItemEntity> tasks = user.ReportedTasks.ToList();

            Console.Clear();
            Console.WriteLine(      " --- YOUR REPORTED TASKS ---\n");
            if (tasks.Count > 0)
                display.DisplayTaskListShort(tasks);
            else 
                Console.WriteLine("You have no reported tasks pending at this time!");
                Console.WriteLine(  " --------------------------- ");

            Console.WriteLine("\n");
            Console.WriteLine(  "To inspect a task, type its TASK ID in the console.\n" +
                                "To return to the previous menu, press 0. To log out\n" +
                                "and return to the starting menu, press 00.\n");
            Console.Write("Your input: ");
            string input = Console.ReadLine();

            switch (input)
            {
                default:
                    Console.WriteLine("Your selection is not available. Please consult the provided" +
                                        "menu and make your selection. Press enter to continue.");
                    Console.ReadLine();
                    UserReportedTasksView(user);
                    break;
                case "0":
                    StaffMenuView(user);
                    break;
                case "00":
                    LogInView();
                    break;
                case string caseValue when tasks.Any(ti => ti.Id.ToString() == caseValue):
                    var taskToView = tasks.Single(ti => ti.Id.ToString() == caseValue);
                    SingleReportedTaskView(user, taskToView);
                    break;
            }                        
        }
        public void SingleReportedTaskView(StaffEntity user, TaskItemEntity task)
        {
            Console.Clear();
            display.DisplaySingleTaskFull(task);
            Console.WriteLine("\n");
            Console.WriteLine(" To return to the previous menu, press 0. To log out \n " +
                               "and return to the starting menu, press 00.");
            Console.Write("Your selection: ");
            string input = Console.ReadLine();

            switch (input)
            {
                default:
                    Console.WriteLine("Your selection is not available. Please consult the provided" +
                                        "menu and make your selection. Press enter to continue.");
                    SingleReportedTaskView(user, task);
                    break;
                case "0":
                    UserReportedTasksView(user);
                    break;
                case "00":
                    LogInView();
                    break;
            }
        }
        public void ReportNewTaskView(StaffEntity user)
        {
            Console.Clear();

            TaskItemEntity task = new TaskItemEntity
            {
                ReporteeId = user.Id,
                StatusId = 1,
            };

            Console.WriteLine("Kindly provide a very succinct summary of the task you wish to report!\n");
            Console.Write("Subject: ");
            task.Subject = Console.ReadLine();

            Console.WriteLine("Provide a more detailed view of the task and its ramifications.");
            Console.Write("Description: ");
            task.Description = Console.ReadLine();

            // add the task async. I'm not sure if this can be done anther way, apart from
            // making the whole method async?
            Task.Run(async () => await taskService.AddTaskAsync(task)).Wait();

            //await taskService.AddTaskAsync(task);

            Console.WriteLine("Your report has been added!\n" +
                "Press enter to continue.");
            Console.ReadLine();
            StaffMenuView(user);
        }

        // admin views tree
        public void AdminMenuView(StaffEntity user)
        {
            Console.Clear();
            Console.WriteLine("\n ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ");
            Console.WriteLine($" Logged in as {user.FirstName.ToUpper()} {user.LastName.ToUpper()} (Administrator) ");
            Console.WriteLine(" ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ");
            Console.WriteLine(" What would you like to do? Chose from \n" +
                                " the options in the menu below.\n");

            Console.WriteLine(" ---- MENU ----");
            Console.WriteLine(" 1 - View all staff");
            Console.WriteLine(" 2 - View all tasks");
            Console.WriteLine(" 3 - View tasks by status, supervisor or reportee");
            Console.WriteLine(" 00 - Log out and return to starting menu");
            Console.WriteLine(" --------------");
            Console.WriteLine("\n");
            Console.Write("Your selection: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    // Didn't have time to finish this functionality...
                    // AdminSeeAllStaffView(user)
                    Console.WriteLine("This option is currently not available! Press enter to continue");
                    Console.ReadLine();
                    AdminMenuView(user);
                    break;
                case "2":
                    AdminSeeAllTasksView(user);
                    break;
                case "3":
                    // Didn't have time to finish this functionality...
                    //AdminSeeSortedTasksView(user);
                    Console.WriteLine("This option is currently not available! Press enter to continue");
                    Console.ReadLine();
                    AdminMenuView(user);
                    break;
                case "00":
                    LogInView();
                    break;
                default:
                    Console.WriteLine("Your selection is not available. Please consult the provided" +
                                        "menu and make your selection. Press enter to continue.");
                    Console.ReadLine();
                    AdminMenuView(user);
                    break;
            }
        }
        public void AdminSeeAllTasksView(StaffEntity user)
        {
            List<TaskItemEntity> tasks = taskService.GetAllTasksAsync().Result;

            Console.Clear();
            Console.WriteLine(" --- TASKS --- ");
            Console.WriteLine("\n");
            display.DisplayTaskListShort(tasks);
            Console.WriteLine("To inspect a task, type its TASK ID in the console.\n" +
                                "To return to the previous menu, press 0. To log out\n" +
                                "and return to the starting menu, press 00.\n");
            Console.Write("Your selection: ");
            string input = Console.ReadLine();

            switch (input)
            {
                default:
                    Console.WriteLine(  "Your selection is not available. Please consult the provided" +
                                        "menu and make your selection. Press enter to continue.");
                    Console.ReadLine();
                    AdminSeeAllTasksView(user);
                    break;
                case "0":
                    AdminMenuView(user);
                    break;
                case "00":
                    LogInView();
                    break;
                case string caseValue when tasks.Any(ti => ti.Id.ToString() == caseValue):
                    var taskToView = tasks.Single(ti => ti.Id.ToString() == caseValue);
                    AdminSingleTaskView(user, taskToView);
                    break;
            }
        }
        public async Task AdminSingleTaskView(StaffEntity user, TaskItemEntity taskToView)
        {
            Console.Clear();
            display.DisplaySingleTaskFull(taskToView);
            Console.WriteLine(  " --- ADMINISTER TASK --- \n");
            Console.WriteLine(  " 1  -  Assign or change task supervisor\n" +
                                " 2  -  Edit task status\n" +
                                " 3  -  Add comment to task\n" +
                                " 0  -  Return to previous menu (view all tasks)\n" +
                                " 00 -  Log out and return to starting menu\n");
            Console.Write("Your selection: ");
            string input = Console.ReadLine();

            switch (input)
            {
                default:
                    Console.WriteLine(  "Your selection is not available. Please consult the provided" +
                                        "menu and make your selection. Press enter to continue.");
                    Console.ReadLine();
                    await AdminSingleTaskView(user, taskToView);
                    break;
                case "1":
                    await AdminSetSupervisorView(user, taskToView); 
                    break;
                case "2":
                    await AdminSetStatusView(user, taskToView);
                    break;
                case "3":
                    await AdminAddCommentView(user, taskToView);
                    break;
                case "0":
                    AdminSeeAllTasksView(user);
                    break;
                case "00":
                    LogInView();
                    break;
            }
        }
        public async Task AdminSetSupervisorView(StaffEntity user, TaskItemEntity task)
        {
            List<StaffEntity> staffList = staff.GetAllStaffAsync().Result;

            Console.Clear();
            Console.WriteLine(" ~~~~~~ Task Under Administration ~~~~~~\n ");
            display.DisplaySingleTaskShort(task);
            Console.WriteLine(" \n~~~~~~ Staff Available to Supervise Task ~~~~~~ ");
            display.DisplayStaffListShort(staffList);
            Console.WriteLine("\n");
            Console.WriteLine(  "Select a supervisor for the task by typing his or her \n" +
                                "Staff ID on the prompt line. Assigning a supervisor will \n" +
                                "will automatically set the task to 'Opened' regardless \n" +
                                "of current status.\n" +
                                "To return to the previous meny, type '0'. To log out \n " +
                                "and return to starting menu, type '00'.\n");

            Console.Write("New supervisors Staff ID: ");
            string id = Console.ReadLine();

            switch (id)
            {
                default:
                    Console.WriteLine(  "Invalid input. Please enter a valid Staff ID to assign \n" +
                                        "a new supervisor. Press enter to continue.");
                    Console.ReadLine();
                    await AdminSetSupervisorView(user, task);
                    break;
                case "0":
                    AdminSingleTaskView(user, task);
                    break;
                case "00":
                    LogInView();
                    break;
                case string caseValue when staffList.Any(s => s.Id.ToString() == caseValue):
                    var newSupervisor = staffList.Single(s => s.Id.ToString() == caseValue);
                    await taskService.EditTaskSupervisorAsync(task.Id, newSupervisor.Id);
                    await taskService.EditTaskStatusAsync(task.Id, 2);
                    Console.Clear();
                    Console.WriteLine(  $"{newSupervisor.FirstName} {newSupervisor.LastName} has been assigned supervisor of task {task.Id}. \n" +
                                        $"Press enter to proceed.");
                    Console.ReadLine();
                    AdminSingleTaskView(user, task);
                    break;
            }
        }
        public async Task AdminSetStatusView(StaffEntity user, TaskItemEntity task)
        {
            // setting of status should be done differently. Options for status should
            // not really be stored in the db at all, but as an enum or something similar.
            Console.Clear();
            Console.WriteLine(" ~~~~~~ Task Under Administration ~~~~~~\n ");
            display.DisplaySingleTaskShort(task);
            Console.WriteLine(" \n~~~~~~ Menu ~~~~~~ ");
            Console.WriteLine("\n");
            Console.WriteLine(  " 1  - Set new status to 'NotOpened' \n" +
                                " 2  - Set new status to 'Opened' \n" +
                                " 3  - Set new status to 'Closed' \n" +
                                " 0  - Return to previous menu (view task)\n" +
                                " 00 - Log out and return to starting menu\n");

            Console.Write("Your selection: ");
            string input = Console.ReadLine();

            switch (input)
            {
                default:
                    Console.WriteLine(  "Invalid input. Please enter a valid option from \n" +
                                        "the menu choices above. Press enter to continue");
                    Console.ReadLine();
                    await AdminSetStatusView(user, task);
                    break;
                case "0":
                    await AdminSingleTaskView(user, task);
                    break;
                case "00":
                    LogInView();
                    break;
                case "1":
                    await taskService.EditTaskStatusAsync(task.Id, 1);
                    Console.Clear();
                    Console.WriteLine($"The task status has been set to 'NotOpened'. \n" +
                                        $"Press enter to proceed.");
                    Console.ReadLine();
                    await AdminSingleTaskView(user, task);
                    break;
                case "2":
                    await taskService.EditTaskStatusAsync(task.Id, 2);
                    Console.Clear();
                    Console.WriteLine(  $"The task status has been set to 'Opened'. \n" +
                                        $"Press enter to proceed.");
                    Console.ReadLine();
                    await AdminSingleTaskView(user, task);
                    break;
                case "3":
                    await taskService.EditTaskStatusAsync(task.Id, 3);
                    Console.Clear();
                    Console.WriteLine($"The task status has been set to 'Closed'. \n" +
                                        $"Press enter to proceed.");
                    Console.ReadLine();
                    await AdminSingleTaskView(user, task);
                    break;
            }
        }
        public async Task AdminAddCommentView(StaffEntity user, TaskItemEntity task)
        {
            // This function in conjunction with the AddCommentToTaskAsync is poorly 
            // constructed. The separation of concerns is not well executed at all
            // and its a duplicate of another method on the Staff View Tree.
            // The AddCommentToTaskAsync should be re-writen to take one TaskItemEntity
            // and one StaffEntity (a user) as arguments, and the time should then be set
            // automatically when the comment is added to the db. 

            // set Authors role
            string authRole = "Supervisor";

            if (user.IsAdmin == true)
            {
                authRole = "Administrator";
            }
            // create entity
            CommentEntity comment = new CommentEntity
            {
                Author = $"{user.FirstName} {user.LastName}",
                AuthorRole = authRole,
                TaskItemId = task.Id
            };
            Console.Clear();
            display.DisplaySingleTaskFull(task);
            Console.WriteLine("\n");

            Console.Write("Your comment: ");
            string text = Console.ReadLine();

            comment.Text = text;
            comment.Time = DateTime.Now.ToString();

            await taskService.AddCommentToTaskAsync(comment);

            //user = await staff.GetStaffById(user.Id);

            Console.WriteLine("Your comment has been added! Press any key to return to return to your tasks.");
            Console.ReadLine();
            await AdminSingleTaskView(user, task);
        }
    }
}
