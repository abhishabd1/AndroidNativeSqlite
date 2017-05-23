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
    [Activity(Label = "UpdateActivity")]
    public class UpdateActivity : Activity
    {
        Button btn_get;
        Button btn_update;
        Button btn_Delete;


        EditText txt_id;
        EditText txt_updatename;
        EditText txt_updatedept;
        EditText txt_updateplace;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Update);
            // Create your application here


            txt_updatename = FindViewById<EditText>(Resource.Id.txt_updatename);
           
            txt_updatedept = FindViewById<EditText>(Resource.Id.txt_updatedept);
            txt_updateplace = FindViewById<EditText>(Resource.Id.txt_updateplace);


            txt_id = FindViewById<EditText>(Resource.Id.txt_update_id);
            btn_get = FindViewById<Button>(Resource.Id.btnget);
            btn_update = FindViewById<Button>(Resource.Id.btn_update);
            btn_Delete = FindViewById<Button>(Resource.Id.btn_DEL);

            btn_get.Click += Btn_get_Click;
            btn_update.Click += Btn_update_Click;

            btn_Delete.Click += Btn_Delete_Click;
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Student.db4"); //Call Database  
            var db = new SQLiteConnection(dpPath);
            var data = db.Table<StudentTable>();


            int idvalue = Convert.ToInt32(txt_id.Text);

            var data1 = data.Where(x => x.id == idvalue).FirstOrDefault();

            if (data1.id != null)
            {
                db.Delete(data1);
                Toast.MakeText(this, "Delete Successfully", ToastLength.Short).Show();

                clear();
            }
            else
            {

                Toast.MakeText(this, "Not Found", ToastLength.Short).Show();
            }
        }

        private void Btn_update_Click(object sender, EventArgs e)
        {
            try
            {

                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Student.db4"); //Call Database  
                var db = new SQLiteConnection(dpPath);
                var data = db.Table<StudentTable>();
                int idvalue = Convert.ToInt32(txt_id.Text);

                var data1 = (from values in data
                             where values.id == idvalue
                             select values).Single();
                data1.StudentName = txt_updatename.Text;
                
                data1.Dept = txt_updatedept.Text;
                data1.Place = txt_updateplace.Text;
                db.Update(data1);
                Toast.MakeText(this, "Updated Successfully", ToastLength.Short).Show();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();

            }
        }

        private void Btn_get_Click(object sender, EventArgs e)
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
                    txt_updatename.Text = val.StudentName;
                   
                    txt_updatedept.Text = val.Dept;
                    txt_updateplace.Text = val.Place;
                }
            }
            else
            {

                Toast.MakeText(this, "Student Data Not Available", ToastLength.Short).Show();
            }
        }
        public void clear()
        {
            txt_id.Text = "";
            txt_updatename.Text = "";
            txt_updatedept.Text = "";
            txt_updateplace.Text = "";
        }
    }
}