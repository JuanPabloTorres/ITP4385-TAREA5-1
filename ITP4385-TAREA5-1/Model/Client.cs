using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITP4385_TAREA5_1.Model
{
    public class Client : Person
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Phone { get; set; }

        public bool IsActive { get; set; }

        public string Profession { get; set; }

        public string BusinessType { get; set; }

        public string Photo { get; set; }

        public string Notes { get; set; }

        public string Email { get; set; }
    }
}
