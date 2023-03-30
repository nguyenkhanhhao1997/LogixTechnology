using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace LogixTechnology.Data.Models
{
    public class UserActivity
    {
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("MovieId")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int Action { get; set; }
    }
}
