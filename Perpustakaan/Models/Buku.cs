using System;
using System.Collections.Generic;

namespace Perpustakaan.Models
{
    public partial class Buku
    {
        public Buku()
        {
            Peminjaman = new HashSet<Peminjaman>();
        }

        public int NoBuku { get; set; }
        public string JudulBuku { get; set; }
        public int? NoKatalog { get; set; }
        public int? NoRak { get; set; }
        public string Pengarang { get; set; }
        public string Penerbit { get; set; }

        public KatalogBuku NoKatalogNavigation { get; set; }
        public Rak NoRakNavigation { get; set; }
        public ICollection<Peminjaman> Peminjaman { get; set; }
    }
}
