using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Group
    {
        public Group()
        {
            Users = new HashSet<User>();
            GroupLaboratoryWorks = new HashSet<GroupLaboratoryWorks>();
        }

        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(100, 999)]
        public int Number { get; set; }


        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<GroupLaboratoryWorks> GroupLaboratoryWorks { get; set; }
    }
}
