using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Data.Entities
{
    public class TaskItemEntity
    {
        public int Id { get; set; }
        public string Subject { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime CreatedDate { get; set; }
        public int? SupervisorId { get; set; } = null;
        public StaffEntity? Supervisor { get; set; } = null;
        public int? ReporteeId { get; set; }
        public StaffEntity? Reportee { get; set; } = null;
        public int StatusId { get; set; } = 1;
        public StatusEntity? Status { get; set; } = null;
        public ICollection<CommentEntity> Comments { get; set; } = new List<CommentEntity>();
    }
}
