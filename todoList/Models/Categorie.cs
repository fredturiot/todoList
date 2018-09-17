using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace todoList.Models
{
	public class Categorie
	{
		public int ID { get; set; }

        [Required]
        [StringLength(20)]
        [Column("Nom")]
		
		public string Nom { get; set; }
	}
}