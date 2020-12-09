using System;
using System.Collections.Generic;

namespace Perpustakaan.Models
{
    public partial class Mahasiswa
    {
        public Mahasiswa()
        {
            Peminjaman = new HashSet<Peminjaman>();
        }

        public int NoAnggota { get; set; }
        public string Nim { get; set; }
        public string Nama { get; set; }
        public int? NoGender { get; set; }
        public string NoHp { get; set; }
        public string Alamat { get; set; }

        public Gender NoGenderNavigation { get; set; }
        public ICollection<Peminjaman> Peminjaman { get; set; }
    }
}
