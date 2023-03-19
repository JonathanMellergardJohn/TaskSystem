

namespace TaskManager.Data.Entities
{
    public class StatusEntity
    {
        public int Id { get; set; }
        public string Message { get; set; } = "";
        // Considering if I should add navigation property to TaskItemEntity? To easily get access to all
        // tasks with status "NotOpened" for instance..?
    }
}
