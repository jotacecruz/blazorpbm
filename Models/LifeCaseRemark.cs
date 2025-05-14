namespace BlazorPBM.Models
{
    public class LifeCaseRemark : Audit
    {
        public int LifeCaseRemarkId { get; set; }
        public int LifeCaseId { get; set; }
        public string? Remark { get; set; }
    }
}