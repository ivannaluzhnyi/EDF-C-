using Android.App;
using Android.Widget;
using Android.OS;
using System.Json;
using System.Net;
using System;
using edf.Modele;
using System.Collections.Generic;
using Newtonsoft.Json;
using Android.Content;
using edf.Activitys;

namespace edf
{
    [Activity(Label = "Gestion EDF", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button btnValider;
        EditText txtLog;
        EditText txtPass;
        List<Controleur> lesControleurs;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            WebClient wc = new WebClient();
            Uri url = new Uri("http://" + GetString(Resource.String.ip) + "get_all_controleurs.php");
            //Uri url = new Uri("http://172.16.1.31/SIO2/edf/get_all_controleurs.php");


            wc.DownloadStringAsync(url);
            wc.DownloadStringCompleted += Wc_DownloadStringCompleted;

            btnValider = FindViewById<Button>(Resource.Id.btnValider);
            txtLog = FindViewById<EditText>(Resource.Id.txtLog);
            txtPass = FindViewById<EditText>(Resource.Id.txtPass);

            btnValider.Click += BtnValider_Click;
        }

        private void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            lesControleurs = JsonConvert.DeserializeObject<List<Controleur>>(e.Result);
        }

        private void BtnValider_Click(object sender, System.EventArgs e)
        {
            var chekLog = lesControleurs.Find(x => x.logCtrl == txtLog.Text);
            var checkPass = lesControleurs.Find(x => x.mdpCtrl == txtPass.Text);

            if (chekLog != null && checkPass != null)
            {
                Intent intent = new Intent(this, typeof(ClientActivity));
                intent.PutExtra("idControleur", chekLog.idCtrl);
                StartActivity(intent);
            }
            else
            {
                Toast.MakeText(this, "Connexion ipossible!", ToastLength.Long).Show();
            }   
        }
    }
}

