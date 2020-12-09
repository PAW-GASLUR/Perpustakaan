using System;
using System.Collections.Generic;

namespace Perpustakaan.Models
{
    public partial class KondisiBuku
    {
        public KondisiBuku()
        {
            Pengembalian = new HashSet<Pengembalian>();
        }

        public int NoKondisi { get; set; }
        public string NamaKondisi { get; set; }

        public ICollection<Pengembalian> Pengembalian { get; set; }
    }
}
