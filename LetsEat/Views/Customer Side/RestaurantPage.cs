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

namespace LetsEat
{
    [Activity(Label = "Restaurant's Info", Theme = "@style/Theme.DesignDemo")]
    public class RestaurantPage : Activity
    {
        TextView mName;
        TextView mCuisine;
        ImageView mPhoto;
        TextView madress;
        TextView mphone;
        TextView mhours;
        TextView mdescription;
        int resTrack;
        string resultName;
        Button mReserve1, mReserve2, mReserve3, mReserve4, mReserve5,
            mReserve6, mReserve7, mReserve8;
        //static readonly List<string> resultNames = new List<string>();
         
        public List<string> alohaReserves = new List<string>();
        public List<string> lagoReserves = new List<string>();
        public List<string> lemonReserves = new List<string>();
        public List<string> oliveReserves = new List<string>();
        public List<string> phoReserves = new List<string>();
        public List<string> robertoReserves = new List<string>();
        public List<string> swSteakReserves = new List<string>();
        public List<string> sweetReserves = new List<string>();
        public List<string> twistReserves = new List<string>();
        public List<string> zumaReserves = new List<string>();


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.RestaurantPage_Layout);
            mName = FindViewById<TextView>(Resource.Id.nameTextView);
            mCuisine = FindViewById<TextView>(Resource.Id.cuisineTextView);
            mPhoto = FindViewById<ImageView>(Resource.Id.photoImageView);
            madress = FindViewById<TextView>(Resource.Id.addressdetail);
            mphone = FindViewById<TextView>(Resource.Id.phonedetail);
            mhours = FindViewById<TextView>(Resource.Id.hoursdetail);
            mdescription = FindViewById<TextView>(Resource.Id.descriptiondetail);
            resTrack = 0;
            mReserve1 = FindViewById<Button>(Resource.Id.timeButton1);
            mReserve2 = FindViewById<Button>(Resource.Id.timeButton2);
            mReserve3 = FindViewById<Button>(Resource.Id.timeButton3);
            mReserve4 = FindViewById<Button>(Resource.Id.timeButton4);
            mReserve5 = FindViewById<Button>(Resource.Id.timeButton5);
            mReserve6 = FindViewById<Button>(Resource.Id.timeButton6);
            mReserve7 = FindViewById<Button>(Resource.Id.timeButton7);
            mReserve8 = FindViewById<Button>(Resource.Id.timeButton8);

            var reserveIntent = new Intent(this, typeof(ReservePage));
            String hourMinute;
            hourMinute = DateTime.Now.ToString("HH");
            int time1 = Int32.Parse(hourMinute) + 1;

            /*mDetail = FindViewById<TextView>(Resource.Id.description);*/

            mName.Text = Intent.GetStringExtra("Name");
            mCuisine.Text = Intent.GetStringExtra("Cuisine");
            var imageView = FindViewById<ImageView>(Resource.Id.photoImageView);

            addtime(time1, mReserve1);
            time1++;
            addtime(time1, mReserve2);
            time1++;
            addtime(time1, mReserve3);
            time1++;
            addtime(time1, mReserve4);
            time1++;
            addtime(time1, mReserve5);
            time1++;
            addtime(time1, mReserve6);
            time1++;
            addtime(time1, mReserve7);
            time1++;
            addtime(time1, mReserve8);

            if (Intent.GetStringExtra("Name") == "SW Steakhouse")
            {
                madress.Text = "3131 Las Vegas Boulevard South Las Vegas, NV 89109";
                mphone.Text = "(702) 770-3325";
                mhours.Text = "Dinner nightly, 5:30 pm to 10:15 pm";
                mdescription.Text = "Star chef David Walzog presents his unique interpretation of the classic American steakhouse along Wynn's Lake of Dreams. As befits a top-notch chophouse, SW offers a selection of expertly charred steaks, including a succulent porterhouse-for-two, New York strip, dry-aged tomahawk chop and Walzog's signature chile-rubbed double cut rib eye. SW also offers a wide variety of seafood and poultry options, and such innovative side dishes as black truffle creamed corn and cipollini onions with charred jalapeno. SW's décor matches its steakhouse-with-a-twist cuisine brilliantly, with an opulent dining space that radiates glamour, punctuated by floor-to-ceiling windows framing postcard views of the three-acre lakefront and forested mountain. The adjoining open-air dining terrace offers prime views of the multi-media shows of sound, light, video and puppetry that unfold both on the lake and against it's 90-foot tall coursing waterfall.";
                reserveIntent.PutStringArrayListExtra("list_reservations", swSteakReserves);
                resTrack = 1;
                imageView.SetImageResource(Resource.Drawable.steak);
            }

            else if (Intent.GetStringExtra("Name") == "Twist by Pierre Gagnaire")
            {
                madress.Text = "3752 Las Vegas Blvd S Las Vegas, NV 89158";
                mphone.Text = "(702) 590-3172";
                mhours.Text = "Dinner\nTue–Sat 6:00 pm–10:00 pm";
                mdescription.Text = "One of the most artistic and celebrated chefs in the world today, Pierre Gagnaire opened his first and only US restaurant at the Mandarin Oriental, Las Vegas to rave reviews in 2009. The accolades continue today and most recently, Twist was named Las Vegas’ 2017 Restaurant of the Year by Desert Companion Magazine and received the coveted Forbes Five Star award for 2017.\n\nJoin us for dinner and enjoy modern French cuisine in an elegant and comfortable setting, with tables offering great views of Las Vegas and the action in our kitchen.In addition, we have a private room available for your special occasion, with 20 ft high windows and a table that can accommodate up to 12 guests.Please note that all guests must be at least 13 years of age and older to dine at Twist.\n\nTwist will be hosting 4 Champagne dinners throughout the year on April 4, June 6, August 8 & October 10.\n\nTwist will be closed for our annual summer closure from 7/1 - 7/16. Twist will reopen on Tuesday, July 17th.";
                reserveIntent.PutStringArrayListExtra("list_reservations", twistReserves);
                imageView.SetImageResource(Resource.Drawable.french);
                resTrack = 2;
            }

            else if (Intent.GetStringExtra("Name") == "Zuma Restaurant")
            {
                madress.Text = "3708 Las Vegas Blvd S Level 3 of the Cosmopolitan Las Vegas, NV 89109";
                mphone.Text = "(702) 698-2199";
                mhours.Text = "Monday – Sunday DINNER 5.45PM -11.00PM\nMonday – Sunday BAR 5.00PM - 12.00AM\n\nLast orders for our kitchen are as follows:\nDinner: Monday to Saturday – last orders 10.45PM";
                mdescription.Text = "ZUMA, contemporary Japanese restaurant from creator and co-founder Rainer Becker, arrives in Las Vegas. Inspired by the informal izakaya dining style, the international restaurant features a modern Japanese cuisine that is authentic but not traditional.";
                reserveIntent.PutStringArrayListExtra("list_reservations", zumaReserves);
                resTrack = 3;
                imageView.SetImageResource(Resource.Drawable.japanese);

            }

            else if (Intent.GetStringExtra("Name") == "Lago - Bellagio")
            {
                madress.Text = "3600 Las Vegas Blvd S Las Vegas, NV 89109";
                mhours.Text = "Sunday: 10:30 AM - 11:00 PM\nMonday: 11:30 AM - 11:00 PM\nTuesday: 11:30 AM - 11:00 PM\nWednesday: 11:30 AM - 11:00 PM\nThursday:    11:30 AM - 11:00 PM\nFriday: 11:30 AM - 12:00 AM\nSaturday: 11:30 AM - 12:00 AM";
                mphone.Text = "(702) 693-7111";
                mdescription.Text = "NOW OPEN FOR LUNCH!!\n\nTour Italy from your table with a wave of Italian small plates at Lago by Julian Serrano.\n\nJames Beard Award - winning chef Julian Serrano sets the evening in motion with his stunning interpretation of innovative Italian small plates, each packed with distinct flavors from all the regions of Italy.\n\nEncompassing 6,650 square feet of prime Las Vegas real estate overlooking the legendary Fountains of Bellagio, Lago by Julian Serrano will bring a truly cutting-edge dining experience to Bellagio and Las Vegas.\n\nLago’s design takes its cues from Italian Futurism, rejecting the past to focus on forward-thinking dynamism and experimentation.\n\nSee, taste, and socialize at Lago.";
                reserveIntent.PutStringArrayListExtra("list_reservations", lagoReserves);
                resTrack = 4;
                imageView.SetImageResource(Resource.Drawable.lago);
            }

            else if (Intent.GetStringExtra("Name") == "Lemongrass - Aria")
            {
                madress.Text = "3730 Las Vegas Blvd South Las Vegas, NV 89109";
                mhours.Text = "Daily: 11:00am - 1:00am";
                mphone.Text = "(702) 590-8670";
                mdescription.Text = "Serving a modern interpretation of Thai cuisine, Lemongrass offers a wide variety of authentic dishes filled with flavor. Our Satay Bar offers charcoal-grilled beef, poultry, pork and seafood skewers served with a variety of sauces and seasonings. Or enjoy inspired Asian cocktails at the expanded bar and lounge located near the entrance. The casual, modern atmosphere also offers two private dining rooms for a more exclusive ";
                reserveIntent.PutStringArrayListExtra("list_reservations", lemonReserves);
                imageView.SetImageResource(Resource.Drawable.thai);
                resTrack = 5;
            }

            else if (Intent.GetStringExtra("Name") == "Aloha Kitchen")
            {
                madress.Text = "4745 S Maryland Pkwy, Las Vegas, NV 89119";
                mhours.Text = "Mon-Sun: 8AM-10PM";
                mphone.Text = "(702) 895-9444";
                mdescription.Text = "Located across from University of Nevada - Las Vegas, Pho Thanh Huong offers authentic Vietnamese specialties, like mouthwatering pho and tasty sandwiches!";
                alohaReserves.Add("Joe Rivers");
                reserveIntent.PutStringArrayListExtra("list_reservations", alohaReserves);
                resTrack = 6;
                imageView.SetImageResource(Resource.Drawable.vietnamese);

            }

            else if (Intent.GetStringExtra("Name") == "Pho Thanh Huong")
            {
                madress.Text = "131 E Tropicana Ave D, Las Vegas, NV 89119";
                mhours.Text = "Mon-Sun: 10AM-10PM";
                mphone.Text = "(702) 739-8703";
                mdescription.Text = "Located across from University of Nevada - Las Vegas, Pho Thanh Huong offers authentic Vietnamese specialties, like mouthwatering pho and tasty sandwiches!";
                reserveIntent.PutStringArrayListExtra("list_reservations", phoReserves);
                resTrack = 7;
            }

            else if (Intent.GetStringExtra("Name") == "Olive Garden")
            {
                madress.Text = "1545 E Flamingo Rd, Las Vegas, NV 89119";
                mhours.Text = "Mon-Thur:11AM-10PM\nFri-Sat:11AM-11PM\nSunday: 11AM-10PM";
                mphone.Text = "(702) 735-0082";
                mdescription.Text = "We're all family here. Enjoy a fresh, delicious meal every time. Olive Garden's menu features a variety of Italian specialties, including classic and filled pastas, chicken, seafood and beef. Enjoy our freshly baked garlic breadsticks and your choice of homemade soup or garden-fresh salad with any entree. All menu items are available for take -out, and our Parties To Go!menu offers generous family - sized meals for your next family gathering or office party.";
                reserveIntent.PutStringArrayListExtra("list_reservations", oliveReserves);
                resTrack = 8;
                imageView.SetImageResource(Resource.Drawable.italian2);

            }

            else if (Intent.GetStringExtra("Name") == "Roberto's Taco Shop")
            {
                madress.Text = "1220 E Harmon Ave A-2, Las Vegas, NV 89119";
                mhours.Text = "24 Hours";
                mphone.Text = "(702) 792-3611";
                mdescription.Text = "Roberto's Taco Shop was San Diego's first walk up and drive-thru taco shop, setting the standard for fresh, authentic and inexpensive Mexican food. Combining a passion for good ingredients with friendly service and a welcoming environment is what has made Roberto's a pioneer of classic Mexican food for over 50 years.";
                reserveIntent.PutStringArrayListExtra("list_reservations", robertoReserves);
                resTrack = 9;
                imageView.SetImageResource(Resource.Drawable.mexican);
            }

            else if (Intent.GetStringExtra("Name") == "Sweet Poke")
            {
                madress.Text = "4680 S Maryland Pkwy, Las Vegas, NV 89119";
                mhours.Text = "Mon-Sun: 11AM-9PM";
                mphone.Text = "(702) 202-2180";
                mdescription.Text = "Established in 2016. We started our first location in the Centennial Las Vegas area and are trying to expand throughout the Vegas area to open 5 more locations within 2017. We specialize in Hawaiian style poke bowls and Asian fusion sushi burritos. Customers can customize their own style of bowl or sushi burrito.";
                reserveIntent.PutStringArrayListExtra("list_reservations", sweetReserves);
                resTrack = 10;
                imageView.SetImageResource(Resource.Drawable.sushi);
            }

            //Reservations
            mReserve1.Click += (sender, e) =>
            {
                reserveIntent.PutExtra("reserve_time", mReserve1.Text);
                StartActivity(reserveIntent);
            };
            mReserve2.Click += (sender, e) =>
            {
                reserveIntent.PutExtra("reserve_time", mReserve2.Text);
                StartActivity(reserveIntent);
            };
            mReserve3.Click += (sender, e) =>
            {
                reserveIntent.PutExtra("reserve_time", mReserve3.Text);
                StartActivity(reserveIntent);
            };
            mReserve4.Click += (sender, e) =>
            {
                reserveIntent.PutExtra("reserve_time", mReserve4.Text);
                StartActivity(reserveIntent);
            };
            mReserve5.Click += (sender, e) =>
            {
                reserveIntent.PutExtra("reserve_time", mReserve5.Text);
                StartActivity(reserveIntent);
            };
            mReserve6.Click += (sender, e) =>
            {
                reserveIntent.PutExtra("reserve_time", mReserve6.Text);
                StartActivity(reserveIntent);
            };
            mReserve7.Click += (sender, e) =>
            {
                reserveIntent.PutExtra("reserve_time", mReserve7.Text);
                StartActivity(reserveIntent);
            };
            mReserve8.Click += (sender, e) =>
            {
                reserveIntent.PutExtra("reserve_time", mReserve8.Text);
                StartActivity(reserveIntent);
            };

        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
                resultName = data.GetStringExtra("list_return");


                if (resTrack == 1)
                {
                    swSteakReserves.Add(resultName);
                }
                else if (resTrack == 2)
                {
                    twistReserves.Add(resultName);

                }
                else if (resTrack == 3)
                {
                    zumaReserves.Add(resultName);

                }
                else if (resTrack == 4)
                {
                    swSteakReserves.Add(resultName);

                }
                else if (resTrack == 5)
                {
                    lemonReserves.Add(resultName);

                }
                else if (resTrack == 6)
                {
                    alohaReserves.Add(resultName);
                    Toast.MakeText(ApplicationContext, "Check 1: " + resultName, ToastLength.Long).Show();


                }
                else if (resTrack == 7)
                {
                    phoReserves.Add(resultName);

                }
                else if (resTrack == 8)
                {
                    oliveReserves.Add(resultName);

                }
                else if (resTrack == 9)
                {
                    robertoReserves.Add(resultName);

                }
                else if (resTrack == 10)
                {
                    sweetReserves.Add(resultName);

                }
            }
        }

        public void addtime(int time, Button timeb)
        {
            bool AM = false;
            string myString;
            int temp = time - 12;

            if (time > 24)
                time = time % 24;

            if (time < 12)
                AM = true;
            else
                AM = false;

            if (time == 12)
                myString = time.ToString() + ":00 PM";
            else
                if (time == 24)
            {

                myString = temp.ToString() + ":00 AM";
            }
            else
                    if (AM)
                myString = time.ToString() + ":00 AM";
            else
                myString = temp.ToString() + ":00 PM";

            timeb.Text = myString;
        }
    }

}