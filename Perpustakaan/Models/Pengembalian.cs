using System;
using System.Collections.Generic;

namespace Perpustakaan.Models
{
    public partial class Pengembalian
    {
        public int NoPengembalian { get; set; }
        public DateTime? TglPengembalian { get; set; }
        public int? NoKondisi { get; set; }
        public int? Denda { get; set; }
        public int? NoPeminjaman { get; set; }

        public KondisiBuku NoKondisiNavigation { get; set; }
        public Peminjaman NoPeminjamanNavigation { get; set; }
    }
}
