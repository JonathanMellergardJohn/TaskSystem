using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Data.Entities
{
    public class CommentEntity
    {
        public int Id { get; set; }
        public string Text { get; set; } = "";       
        public string Time { get; set; } = "";
        // This is not ideal. Better would be to add AuthorId as a FK to the StaffEntity
        // and then a navigation property as well. Couldn't get the migration to work for some reason though...
        public string Author { get; set; } = "";
        public string AuthorRole { get; set; } = "";
        public int TaskItemId { get; set; }
        public TaskItemEntity TaskItem { get; set; }
    }
}
