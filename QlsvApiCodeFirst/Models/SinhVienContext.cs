using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QlsvApi.Models
{
    public class SinhVienContext : DbContext
    {
        public SinhVienContext(DbContextOptions<SinhVienContext> options) : base(options)
        {

        }
        public DbSet<SinhVien> SinhViens { get; set; }

    }
}
