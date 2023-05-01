using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class GroupLaboratoryWorks
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid GroupId { get; set; }

        public Guid LaboratoryWorkId { get; set; }

        [ForeignKey(nameof(LaboratoryWorkId))]
        public virtual LaboratoryWork LaboratoryWorkNavigation { get; set; }

        [ForeignKey(nameof(GroupId))]
        public virtual Group Groupnavigation { get; set; }
    }
}
