using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrototipoWebApi_1.Modelos
{
    public class TeamColaborator
    {

        [Key]
        public virtual int Id { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Colaborador> Colaboradors { get; set; }
    }
}
