using System;
using System.Collections.Generic;

namespace Perpustakaan.Models
{
    public partial class KatalogBuku
    {
        public KatalogBuku()
        {
            Buku = new HashSet<Buku>();
        }

        public int NoKatalog { get; set; }
        public string JenisKatalog { get; set; }

        public ICollection<Buku> Buku { get; set; }
    }
}
