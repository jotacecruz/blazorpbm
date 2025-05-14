namespace BlazorPBM.Models
{
    public class Audit
    {
        public DateTime Modified { get; set; }
        public int ModifiedId { get; set; }
        public DateTime Created { get; set; }
        public int CreatedId { get; set; }
        public int DatabaseRow { get; set; }

        public virtual User? Modifier { get; set; }
    }
}
