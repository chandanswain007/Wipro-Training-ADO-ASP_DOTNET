using System.ComponentModel.DataAnnotations;

namespace SecureTaskManager.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        // This content could contain malicious scripts
        public string Description { get; set; }
    }
}