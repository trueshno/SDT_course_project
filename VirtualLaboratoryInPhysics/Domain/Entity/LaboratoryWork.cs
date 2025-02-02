﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class LaboratoryWork
    {
        public LaboratoryWork()
        {
            Reports = new HashSet<Report>();
            GroupLaboratoryWorks = new HashSet<GroupLaboratoryWorks>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string Name { get; set; }

        public string Objective { get; set; }

        [Required]
        [FileExtensions(Extensions = "doxc")]
        public string SampleReport { get; set; }

        [Required]
        [FileExtensions(Extensions = "doxc")]
        public string CriteriaForEvaluation { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<GroupLaboratoryWorks> GroupLaboratoryWorks { get; set; }
    }
}
