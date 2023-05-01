namespace Domain.Entity
{
    public partial class Report
    {
        public int Id { get; set; }
        public int IdLaboratoryWork { get; set; }
        public string Content { get; set; } = null!;
        public int? Grade { get; set; }

        public virtual LaboratoryWork IdLaboratoryWorkNavigation { get; set; } = null!;
    }
}
