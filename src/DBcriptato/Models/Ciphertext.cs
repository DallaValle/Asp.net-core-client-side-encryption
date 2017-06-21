using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DBcriptato.Models
{
    public class Ciphertext
    {
        [Key]
        public int ciphertextId { get; set; }
        [ForeignKey("AspNetUsers")]
        public string Id { get; set; }
        public string iv { get; set; }
        public int v { get; set; }
        public int iter { get; set; }
        public int ks { get; set; }
        public int ts { get; set; }
        public string mode { get; set; }
        public string adata { get; set; }
        public string cipher { get; set; }
        public string salt { get; set; }
        public string ct { get; set; }
    }
}
