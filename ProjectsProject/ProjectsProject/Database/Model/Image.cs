using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsProject.Database.Model
{
    [Table("Images")]
    public class Image
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [Unique]
        public string Name { get; set; }
        public string PathImage { get; set; }
    }
}
