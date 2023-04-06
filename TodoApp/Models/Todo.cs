namespace TodoApp.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Description { get; set; } = "";
        public bool IsComplete { get; set; } = false;

        public override string ToString()
        {
            return $"{Description} Complete: {IsComplete.ToString()}";
        }
    }
}
