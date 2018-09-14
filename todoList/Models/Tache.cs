﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace todoList.Models
{
	public class Tache
	{
		public int ID { get; set; }

		public string Nom { get;set;}

		public string Description { get; set; }

		public DateTime DateFin { get; set; }

		public bool Statut { get; set; }

		public int Priorite { get; set; }


	}
}