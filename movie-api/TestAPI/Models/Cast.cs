using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Models
{
    public class Cast
    {
        public int Id { get; set; }

        public virtual Actor Actor { get; set; }

        public virtual Movies Movie { get; set; }

        public int ActorId { get; set; }

        public int MovieId { get; set; }
    }
}
