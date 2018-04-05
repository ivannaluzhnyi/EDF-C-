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
using edf.Modele;

namespace edf.Adapters
{
    public class ClientAdapter : ArrayAdapter<Client>
    {

        Activity context;
        List<Client> lesClients;

        public ClientAdapter(Activity unContext, List<Client> desClients)
            : base(unContext, Resource.Layout.ItemClient, desClients)
        {
            context = unContext;
            lesClients = desClients;
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = context.LayoutInflater.Inflate(Resource.Layout.ItemClient, null);
            view.FindViewById<TextView>(Resource.Id.txtPrenom).Text = lesClients[position].prenomClient.ToString();
            view.FindViewById<TextView>(Resource.Id.txtNom).Text = lesClients[position].nomClient.ToString();
            view.FindViewById<TextView>(Resource.Id.txtAncienReleve).Text = lesClients[position].ancienReleveC.ToString();
            view.FindViewById<TextView>(Resource.Id.txtDernierReleve).Text = lesClients[position].dernierReleveC.ToString();

            return view;
        }
    }
}