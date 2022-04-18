﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPGestionDeColonie.ObjetsFixes
{
    class Rocher:ObjetFixe
    {
        protected override bool EstCible {get;set;}
       
        public Rocher(List<Tuple<int, int>> positionObjet,Monde planete) : base(positionObjet,planete) {
            EstCible = false;
        }



    }
}
