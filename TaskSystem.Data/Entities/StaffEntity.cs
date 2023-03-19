namespace TaskManager.Data.Entities
{
    public class StaffEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public bool IsAdmin { get; set; } = false;
        public ICollection<TaskItemEntity> SupervisedTasks { get; set; } = new HashSet<TaskItemEntity>();
        public ICollection<TaskItemEntity> ReportedTasks { get;} = new HashSet<TaskItemEntity>();
    }
}
