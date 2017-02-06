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
using Android.Views.InputMethods;

namespace TestPCL.Droid
{
    [Activity(Label = "PersonsList")]
    public class PersonsList : Activity
    {
        PersonRepo repo = new PersonRepo();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PersonsList);

            var listview = FindViewById<ListView>(Resource.Id.PersonsListView);
            var searchBtn = FindViewById<Button>(Resource.Id.SearchBtn);
            var showAllBtn = FindViewById<Button>(Resource.Id.ShowAllBtn);
            var searchTerm = FindViewById<EditText>(Resource.Id.NameSearch);


            var PersonsList = repo.getPersons();

            var names = new List<string>();

            foreach (var p in PersonsList)
            {
                var personInfo = p.Name + " | " + p.Title + ", " + p.Age;
                names.Add(personInfo);
            }

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, names);

            //listview.Adapter = adapter;

            listview.ItemClick += listview_ItemClick;

            searchBtn.Click += delegate
            {
                var person = repo.GetByName(searchTerm.Text);
                var searchResult = new List<string>();

                if (person != null)
                {
                    searchResult.Add( person.Name + " | " + person.Title + ", " + person.Age);
                    HideKeyboard();
                }
                else
                {
                    searchResult.Add("Couldn't find a user with that name.");
                }

                var newAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, searchResult);
                listview.Adapter = newAdapter;

            };

            showAllBtn.Click += delegate
            {
                listview.Adapter = adapter;
                HideKeyboard();
            };
            


        }
        private void listview_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, e.Position.ToString(), ToastLength.Long).Show();
        }
        private void HideKeyboard()
        {
            InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, 0);
        }
    }
}