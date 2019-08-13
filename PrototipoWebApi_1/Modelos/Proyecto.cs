using PrototipoWebApi_1.Modelos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrototipoWebApi_1.Repositorios
{
    public class Proyecto
    {
        [Key]
        public virtual int Pro_I_Codigo { get; set; }
        [Column(TypeName =("varchar(60)"))]
        public  virtual string Pro_V_Descripcion { get; set; }
        [Column(TypeName = ("varchar(60)"))]
        public virtual ICollection<TeamColaborator> TeamColaborador { get; set; }
       
    }
}