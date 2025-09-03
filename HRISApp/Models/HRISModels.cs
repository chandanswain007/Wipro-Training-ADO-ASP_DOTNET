using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class Department
	{
        public int Id { get; set; }
        [Display(Name="Department Name")]
        public string Name { get; set; }
    }

	public class Employee
	{
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("dept")]
        public int DeptId { get; set; }
        public Department? dept { get; set; }

    }

   
}
