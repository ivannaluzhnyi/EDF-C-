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
using Newtonsoft.Json;

namespace edf.Modele
{
    public class Client
    {
        [JsonProperty("identifiant")]
        public int idClient { get; set; }
        [JsonProperty("nom")]
        public string nomClient { get; set; }
        [JsonProperty("prenom")]
        public string prenomClient { get; set; }
        [JsonProperty("adresse")]
        public string adressClient { get; set; }
        [JsonProperty("codePostal")]
        public string CPCliant { get; set; }
        [JsonProperty("ville")]
        public string villeClient { get; set; }
        [JsonProperty("ancienReleve")]
        public int ancienReleveC { get; set; }
        [JsonProperty("dernierReleve")]
        public int dernierReleveC { get; set; }
        [JsonProperty("idcontroleur")]
        public int idCtrl { get; set; }
    }
}