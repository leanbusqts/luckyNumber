using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace LuckyNumber
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        SeekBar seekBar;
        TextView resultTextView;
        Button rollButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            seekBar = FindViewById<SeekBar>(Resource.Id.seekBar);
            resultTextView = FindViewById<TextView>(Resource.Id.resultTextView);
            rollButton = FindViewById<Button>(Resource.Id.rollButton);

            //resultTextView.Text = "9";

            // Click event Handler
            rollButton.Click += RollButton_Click;

        }

        private void RollButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Random random = new Random();
            int luckyNumber = random.Next(seekBar.Progress) + 1;
            resultTextView.Text = luckyNumber.ToString();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

       
    }
}
