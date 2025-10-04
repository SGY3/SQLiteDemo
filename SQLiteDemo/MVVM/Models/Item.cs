using SQLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.MVVM.Models
{
    [Table("Items")]
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique, NotNull]
        public string Name { get; set; }
        public decimal ItemPrice { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
