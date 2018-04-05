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
    public class Controleur
    {
        [JsonProperty("id")]
        public string idCtrl { get; set; }

        [JsonProperty("nom")]
        public string nomCtrl { get; set; }
        [JsonProperty("prenom")]
        public string prenomCtrl { get; set; }
        [JsonProperty("login")]
        public string logCtrl { get; set; }
        [JsonProperty("mdp")]
        public string mdpCtrl { get; set; }

    }
}