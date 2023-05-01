namespace Domain.Entity
{
    public partial class LaboratoryWork
    {
        public LaboratoryWork()
        {
            Reports = new HashSet<Report>();
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; } = null!;
        public string Objective { get; set; } = null!;
        public string SampleReport { get; set; } = null!;
        public string CriteriaForEvaluation { get; set; } = null!;

        public virtual ICollection<Report> Reports { get; set; }
    }
}
