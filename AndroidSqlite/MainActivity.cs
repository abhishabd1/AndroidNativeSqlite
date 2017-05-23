using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using SQLite;

namespace AndroidSqlite
{
    [Activity(Label = "AndroidSqlite", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button btninsert;
        Button btnupdate;
        Button btndelete;
        Button btnSelect;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            btninsert = FindViewById<Button>(Resource.Id.insertbtn);
            btnupdate = FindViewById<Button>(Resource.Id.updatebtn);
            
            btnSelect = FindViewById<Button>(Resource.Id.selectbtn);



            CreateDB();//called method here

            btninsert.Click += delegate
            {
                StartActivity(typeof(InsertActivity));
            };


            btnSelect.Click += delegate
              {
                  StartActivity(typeof(SelectActivity));
              };

            btnupdate.Click += delegate
            {
                StartActivity(typeof(UpdateActivity));
            };
        }


        //CREATE DB

        public string CreateDB()
        {
            var output = "";
            output += "Creating database if it dosen't exists";
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Student.db4");//this is use for create database

            var db = new SQLiteConnection(dbPath);
            output += "\n Database Created....";

            return output;
        }
    }
}

