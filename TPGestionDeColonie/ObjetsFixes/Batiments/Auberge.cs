﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPGestionDeColonie.ObjetsFixes.Batiments
{
    class Auberge:Batiment
    {
        public bool PresenceTavernier
        {
            get;
            set;
        }
        public int[] StockRessources{get;set;}

        public Auberge(List<Tuple<int, int>> positionObjet, int coutBois, int coutPierre, Monde planete) : base(
            positionObjet, coutBois, coutPierre, planete)
        {
            StockRessources = new int[] {0, 0, 0}; // Eau, blé, viande
        }

        //Auberge fait perdre de la fatigue
    }

    
}
