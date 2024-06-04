using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDMysql
{
    public class Candidate
    {
        public int Id { get; set; }
        public string NumeroElection {  get; set; }
        public byte[] Pdp { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Tel { get; set; }
        public string Cin { get; set; }
        public string PartiPolitique { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public int Vato {  get; set; }
        public override string ToString()
        {
            return "nom:"+Nom;
        }
    }
}
