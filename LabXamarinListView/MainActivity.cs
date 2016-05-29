using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace LabXamarinListView
{
    [Activity(Label = "LabXamarinListView", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private EditText MyEditText;
        private Button MyButton;
        private ListView MyListView;

        private List<string> items;
        private ArrayAdapter<string> adapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            MyEditText = FindViewById<EditText>(Resource.Id.MyEditText);
            MyButton = FindViewById<Button>(Resource.Id.MyButton);
            MyListView = FindViewById<ListView>(Resource.Id.MyListView);

            items = new List<string>();
            items.Add("吃早餐");

            adapter = new ArrayAdapter<string>
                (this, Android.Resource.Layout.SimpleListItem1, items);
            MyListView.Adapter = adapter;

            MyButton.Click += delegate {
                adapter.Add(MyEditText.Text);
                adapter.NotifyDataSetChanged();

                Toast.MakeText(this, $"{MyEditText.Text} 已添加", ToastLength.Short)
                        .Show();
            };
        }
    }
}

