using CMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Entities
{
    public class User : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(320)")]
        public string Email { get; set; }
        [Column(TypeName = "char(60)")]
        public string Password { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string Name { get; set; }
        public int RoleId { get; set; }
        [Column(TypeName = "char(30)")]
        public string Salt { get; set; }
        public Role Role { get; set; }
        public bool HasVotedToday { get; set; }
        public List<FoodItemFeedback> FoodItemFeedback {  get; set; }
        public List<Notification> Notification { get; set; }
    }
}
