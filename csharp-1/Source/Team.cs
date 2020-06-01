using System;
using System.Collections.Generic;
using System.Text;

namespace Source
{
    class Team
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DataCriacao { get; set; }
        public string CorUniformePrincipal { get; set; }
        public string CorUniformeSecundario { get; set; }
        public Captain Captain { get; set; }
        //public List<Player> Players { get; set; }

        public Team(long id)
        {
            Id = id;
        }
        public Team(long id, string name, DateTime dataCriacao, string corUniformePrincipal, string corUniformeSecundario) : this(id)
        {
            Name = name;
            DataCriacao = dataCriacao;
            CorUniformePrincipal = corUniformePrincipal;
            CorUniformeSecundario = corUniformeSecundario;
        }

      

        //public override bool Equals(object obj)
        //{
        //    if (!(obj is Team))
        //        throw new ArgumentException("Error:Invalid parameter");
        //    Team other = obj as Team;
        //    return Id.Equals(other.Id);
        //}

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}

    }
}
