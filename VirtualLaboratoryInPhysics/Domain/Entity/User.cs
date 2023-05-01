using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Domain.Entity
{
    public class User
    {
        public User()
        {
            Reports = new HashSet<Report>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Guid GroupId { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int RecordNumber { get; set; }

        public virtual ICollection<Report> Reports { get; set; }

        [ForeignKey(nameof(GroupId))]
        public virtual Group GroupNavigation { get; set; }
    }
}
