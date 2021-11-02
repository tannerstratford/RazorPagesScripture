using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesScripture.Models
{
    public class Scripture
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        public string Book { get; set; }
        public int Chapter { get; set; }
        public int Verse { get; set; }
        public string Entry { get; set; }

    }
}