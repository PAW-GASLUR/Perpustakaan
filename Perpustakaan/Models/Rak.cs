using System;
using System.Collections.Generic;

namespace Perpustakaan.Models
{
    public partial class Rak
    {
        public Rak()
        {
            Buku = new HashSet<Buku>();
        }

        public int NoRak { get; set; }
        public string NamaRak { get; set; }

        public ICollection<Buku> Buku { get; set; }
    }
}
