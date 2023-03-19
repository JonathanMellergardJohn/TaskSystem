using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.Entities;

namespace TaskSystem.ConsoleUI.Services
{
    public class DisplayService
    {
        // display tasks
        public void DisplaySingleTaskFull(TaskItemEntity task)
        {
            // set supervisor text
            string supervisor;
            var commentList = task.Comments.ToList();

            if (task.SupervisorId != null)
            {
                supervisor = $"{task.Supervisor.FirstName} {task.Supervisor.LastName}\n";
            }
            else
            {
                supervisor = "NOT ASSIGNED\n";
            }
            // display main text
            Console.WriteLine(
                $" ----------------------------\n" +
                $" TASK ID: {task.Id}\n" +
                $" Subject: {task.Subject}\n" +
                $" Description: {task.Description}\n" +
                $" Time Reported: {task.CreatedDate} \n" +
                $" Status: {task.Status.Message}\n" +               
                $" Reportee: {task.Reportee.FirstName} {task.Reportee.LastName}\n" +
                $" Supervisor: {supervisor}\n" +
                $"\n" +
                $" ~~~~~~ COMMENTS ~~~~~~\n");
            // display comments
            if (task.Comments.Count == 0)
            {
                Console.WriteLine("     No comments added yet!");
            }
            else
            {
                foreach (var comment in commentList)
                {
                    Console.WriteLine(  $" Comment added: {comment.Time}\n" +
                                        $" {comment.Text}\n " +
                                        $" --{comment.Author} ({comment.AuthorRole})");
                }
            }
            Console.WriteLine(" ----------------------------");
        }
        public void DisplaySingleTaskShort(TaskItemEntity task)
        {
            Console.WriteLine("------------");
            Console.WriteLine(  $" TASK ID: {task.Id}\n" +
                                $" Subject: {task.Subject}");
            Console.WriteLine("------------");
        }
        public void DisplayTaskListShort(List<TaskItemEntity> list)
        {
            foreach(var task in list) 
            { 
                DisplaySingleTaskShort(task);
            }
        }
        // display staff
        public void DisplaySingleStaffFull(StaffEntity staff)
        {
            // properties to set
            string role;

            // set admin message
            if (staff.IsAdmin == true)
            {
                role = "Administrator";
            }
            else
            {
                role = "Staff";
            }           

            Console.WriteLine(" ~~~~ YOUR DETAILS ~~~~ ");
            Console.WriteLine(  $" Staff ID: {staff.Id}\n" +
                                $" Name: {staff.FirstName} {staff.LastName}\n" +
                                $" Email: {staff.Email}\n" +
                                $" Phonenumber: {staff.PhoneNumber}\n" +
                                $" Role: {role}\n");
            Console.WriteLine(" ~~~~ SUPERVISED TASKS ~~~~ \n");
            
            // display supervised tasks
            if (staff.SupervisedTasks.Count == 0)
            {
                Console.WriteLine("     No tasks under supervision!");
            }
            else
            {
                foreach (var task in staff.SupervisedTasks)
                {
                    Console.WriteLine(  $" -------- \n" +
                                        $" Task ID: {task.Id}\n" +
                                        $" Subject: {task.Subject}\n" +
                                        $" --------");
                }
            }
            Console.WriteLine("\n ~~~~ REPORTED TASKS ~~~~ \n");
            // display reported tasks
            if (staff.SupervisedTasks.Count == 0)
            {
                Console.WriteLine("     No tasks reported!");
            }
            else
            {
                foreach (var task in staff.ReportedTasks)
                {
                    Console.WriteLine(  $" -------- \n" +
                                        $" Task ID: {task.Id}\n" +
                                        $" Subject: {task.Subject}\n" +
                                        $" --------");
                }
            }
        }
        public void DisplaySingleStaffShort(StaffEntity staff)
        {
            Console.WriteLine("------------");
            Console.WriteLine(  $" STAFF ID: {staff.Id}\n" +
                                $" Name: {staff.FirstName} {staff.LastName}");
            Console.WriteLine("------------");
        }
        public void DisplayStaffListShort(List<StaffEntity> list) 
        { 
            foreach(var staff in list) 
            {
                DisplaySingleStaffShort(staff);
            }
        }
    }
}
