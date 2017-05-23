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
using System.IO;
using SQLite;

namespace AndroidSqlite
{
    [Activity(Label = "SelectActivity")]
    public class SelectActivity : Activity
    {
        Button btn_select;
        TextView txt_id;
        TextView txt_name;
        TextView txt_dept;
        TextView txt_place;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Select);


            txt_id = FindViewById<TextView>(Resource.Id.txtid);
            txt_name = FindViewById<TextView>(Resource.Id.txt_studentname);
            txt_dept = FindViewById<TextView>(Resource.Id.txt_dept);
            txt_place = FindViewById<TextView>(Resource.Id.txt_place);

            btn_select = FindViewById<Button>(Resource.Id.btnGet);


            btn_select.Click += Btn_select_Click;
            // Create your application here
        }

        private void Btn_select_Click(object sender, EventArgs e)
        {

            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Student.db4");

            var db = new SQLiteConnection(dbPath);

            var data = db.Table<StudentTable>();

            int idvalue = Convert.ToInt32(txt_id.Text);
            var data1 = (from values in data
                         where values.id == idvalue
                         select new StudentTable
                         {
                             StudentName = values.StudentName,
                             Dept = values.Dept,
                             Place = values.Place


                         }).ToList<StudentTable>();
            if (data1.Count > 0)
            {
                foreach (var val in data1)
                {

                    txt_name.Text = val.StudentName;
                    txt_dept.Text = val.Dept;
                    txt_place.Text = val.Place;
                }

            }
            else
            {
                Toast.MakeText(this, "sorry data not found", ToastLength.Short).Show();
                clear();
            }
        }

        public void clear()
        {
            txt_name.Text = "";
           
            txt_dept.Text = "";
            txt_place.Text = "";

        }
    }
}