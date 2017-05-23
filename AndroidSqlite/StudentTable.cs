using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace AndroidSqlite
{
   public class StudentTable
    {
        [PrimaryKey,AutoIncrement,Column("_Id")]

        public int id { get; set; }
        [MaxLength(50)]

        public string StudentName { get; set; }
        [MaxLength(50)]

        public string Dept { get; set; }
        [MaxLength(50)]

        public string Place { get; set; }
    }
}