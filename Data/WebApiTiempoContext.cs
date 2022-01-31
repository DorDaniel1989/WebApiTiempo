using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiTiempo.Models;

namespace WebApiTiempo.Data
{
    public class WebApiTiempoContext : DbContext
    {
        public WebApiTiempoContext (DbContextOptions<WebApiTiempoContext> options)
            : base(options)
        {
        }

        public DbSet<TiempoItem> TiempoItem { get; set; }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
