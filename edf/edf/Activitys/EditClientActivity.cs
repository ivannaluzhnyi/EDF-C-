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
using edf.Modele;
using Newtonsoft.Json;

namespace edf.Activitys
{
    [Activity(Label = "EditClientActivity")]
    public class EditClientActivity : Activity
    {
        EditText txtPrenom;
        EditText txtNom;
        EditText txtAncienR;
        EditText txtDernierR;
        EditText txtNouveauR;
        Button btnValider;
        Client client;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EditClientLayout);

            string nameCli = Intent.GetStringExtra("client");
            client = JsonConvert.DeserializeObject<Client>(nameCli);

            txtPrenom = FindViewById<EditText>(Resource.Id.txtPrenom);
            txtNom = FindViewById<EditText>(Resource.Id.txtNom);
            txtAncienR = FindViewById<EditText>(Resource.Id.txtAncienR);
            txtDernierR = FindViewById<EditText>(Resource.Id.txtDernierR);
            txtNouveauR = FindViewById<EditText>(Resource.Id.txtNouveauR);
            btnValider = FindViewById<Button>(Resource.Id.btnValider);

            txtPrenom.Text = client.prenomClient;
            txtNom.Text = client.nomClient;
            txtAncienR.Text = client.ancienReleveC.ToString();
            txtDernierR.Text = client.dernierReleveC.ToString();
            btnValider.Click += BtnValider_Click;
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            var t = txtNouveauR.Text;
            int convertNouveauReleve = Convert.ToInt32(txtNouveauR.Text);
            if(client.dernierReleveC < convertNouveauReleve)
            {
                int idClient = Convert.ToInt32(client.idClient);
                int nouveauReleve = Convert.ToInt32(txtNouveauR.Text);
                int dernier = Convert.ToInt32(txtDernierR.Text);
                WebClient wc = new WebClient();
                Uri url = new Uri("http://" + GetString(Resource.String.ip) + "insert_nouveau_releve.php?idClient=" + idClient + "&dernierReleve=" + dernier + "&nouveauReleve=" + nouveauReleve);
                wc.DownloadStringAsync(url);
                txtAncienR.Text = txtDernierR.Text;
                txtDernierR.Text = nouveauReleve.ToString();
                txtNouveauR.Text = "";
                Toast.MakeText(this, "Mise a jour reussi", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(this, "La valeursaisi ne doit pas etre inferieur  a "+client.dernierReleveC, ToastLength.Long).Show();
            }
        }
    }
}