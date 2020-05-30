using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;

namespace Source
{
    class Player 
    {
        public long Id { get; set; }
        public long TeamId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int SkillLevel { get; set; }
        public decimal Salary { get; set; }

        public Player(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary) : this(id)
        {
            TeamId = teamId;
            Name = name;
            BirthDate = birthDate;
            SkillLevel = skillLevel;
            Salary = salary;
        }

        internal Player(long id)
        {
            Id = id; 
        }
        



        public override bool Equals(object obj)
        {
            if (!(obj is Player))
                throw new ArgumentException("Error:Invalid parameter");
            Player other = obj as Player;
            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
