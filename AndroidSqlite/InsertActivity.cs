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
    [Activity(Label = "InsertActivity")]
    public class InsertActivity : Activity
    {

        Button saveBtn;
        EditText nametxt;
        EditText deptxt;
        EditText placetxt;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Insert);
            // Create your application here

            nametxt = FindViewById<EditText>(Resource.Id.stuName);
            deptxt = FindViewById<EditText>(Resource.Id.depText);
            placetxt = FindViewById<EditText>(Resource.Id.placeText);


            saveBtn = FindViewById<Button>(Resource.Id.savebtn);


            saveBtn.Click += SaveBtn_Click;




        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Student.db4");
            var db = new SQLiteConnection(dbPath);

            db.CreateTable<StudentTable>();

            StudentTable tb1 = new StudentTable();
            tb1.StudentName = nametxt.Text;
            tb1.Dept = deptxt.Text;
            tb1.Place = placetxt.Text;

            db.Insert(tb1);

            Toast.MakeText(this, "Record saved...", ToastLength.Short).Show();
            clear();
        }

        public void clear()
        {
            nametxt.Text = "";
            deptxt.Text = "";
            placetxt.Text = "";
        }
    }
}