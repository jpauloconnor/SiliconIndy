using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconIndy.Data
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }

        public Guid? OwnerId { get; set; } //nullable because it might be someone buying and not logged in

        [Required]
        public int ProductID { get; set; }

        public string ApplicationUserID { get; set; } //Foreign Key, but nullable if we don't have them logged in.

        public virtual Product Product { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
