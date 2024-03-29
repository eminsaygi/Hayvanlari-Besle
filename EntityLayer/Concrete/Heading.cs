﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadingId { get; set; }
        [StringLength(150)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }
        public bool HeadingStatus { get; set; }

        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }


        public ICollection<Content> Contents { get; set; }


        public int? AnimalLoverId { get; set; }
        public virtual AnimalLover AnimalLover { get; set; }


    }
}
