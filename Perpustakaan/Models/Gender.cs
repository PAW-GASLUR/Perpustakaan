using System;
using System.Collections.Generic;

namespace Perpustakaan.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Mahasiswa = new HashSet<Mahasiswa>();
        }

        public int NoGender { get; set; }
        public string NamaGender { get; set; }

        public ICollection<Mahasiswa> Mahasiswa { get; set; }
    }
}
