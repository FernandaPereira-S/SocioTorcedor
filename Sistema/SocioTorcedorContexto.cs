using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_SocioTorcedor
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class SocioTorcedorContexto : DbContext
    {
        public SocioTorcedorContexto() : 
            base("server=localhost;database=socio_torcedor;user=root;password=1234") { }

        public DbSet<Time> Times { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Torcedor> Torcedores { get; set; }
    }
}
