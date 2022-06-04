using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torpedo.Model
{
    public class Result
    {
        [Key]
        public long Id { get; set; }
        public string ElsoJatekosNeve { get; set; }
        public string MasodikJatekosNeve { get; set; }
        public string Nyertes { get; set; }
        public int ElsoJatekosTalalata { get; set; }
        public int MasodikJatekosTalalata { get; set; }
        public int KorokSzama { get; set; }
    }
}
