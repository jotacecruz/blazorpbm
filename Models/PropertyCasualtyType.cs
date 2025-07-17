namespace BlazorPBM.Models
{
    public class PropertyCasualtyType
    {
        public int PropertyCasualtyTypeId { get; set; }
        public bool Business { get; set; } = true;
        public string? Code { get; set; }
        public string? Name { get; set; }
    }
}
