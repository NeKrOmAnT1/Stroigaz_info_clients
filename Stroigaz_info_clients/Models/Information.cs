using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stroigaz_info_clients.Models
{
    class Information
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        public string Сlientele { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Number_Brigade { get; set; }
        public string Construction_Plan { get; set; }

    }
}
