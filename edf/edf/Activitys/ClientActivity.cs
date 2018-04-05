using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using edf.Adapters;
using edf.Modele;
using Newtonsoft.Json;
using System.Json;

namespace edf.Activitys
{
    [Activity(Label = "Liste des clients")]
    public class ClientActivity : Activity
    {
        ListView lstClient;
        List<Client> lesClients;
        ClientAdapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ClientLayout);

            lstClient = FindViewById<ListView>(Resource.Id.lstClient);
            string idControleur = Intent.GetStringExtra("idControleur");
            WebClient wc = new WebClient();
           // Uri url = new Uri("http://172.16.1.31/SIO2/edf/get_all_clients_byControleurId.php?idControleur=" + idControleur);
            Uri url = new Uri("http://" + GetString(Resource.String.ip) + "get_all_clients_byControleurId.php?idControleur=" + idControleur);

            wc.DownloadStringAsync(url);
            wc.DownloadStringCompleted += Wc_DownloadStringCompleted;

            lstClient.ItemClick += LstClient_ItemClick;
        }


        private void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            lesClients = JsonConvert.DeserializeObject<List<Client>>(e.Result);

            adapter = new ClientAdapter(this, lesClients);
            lstClient.Adapter = adapter;
        }

        private void LstClient_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Client  c = lesClients[e.Position];
            Intent intent = new Intent(this, typeof(EditClientActivity));

            intent.PutExtra("client", JsonConvert.SerializeObject(c));
            StartActivity(intent);
        }
    }
}