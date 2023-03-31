using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogixTechnology.Data.Repositories
{
    public class MovieOutput
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }
        
        public int LikeNumber { get; set; }

        public int DisLikeNumber { get; set; }

        public int UserReact { get; set; }
    }
}
