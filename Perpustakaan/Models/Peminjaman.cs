using System;
using System.Collections.Generic;

namespace Perpustakaan.Models
{
    public partial class Peminjaman
    {
        public Peminjaman()
        {
            Pengembalian = new HashSet<Pengembalian>();
        }

        public int NoPeminjaman { get; set; }
        public DateTime? TglPeminjaman { get; set; }
        public int? NoBuku { get; set; }
        public int? NoAnggota { get; set; }

        public Mahasiswa NoAnggotaNavigation { get; set; }
        public Buku NoBukuNavigation { get; set; }
        public ICollection<Pengembalian> Pengembalian { get; set; }
    }
}
