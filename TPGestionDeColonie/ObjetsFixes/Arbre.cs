﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPGestionDeColonie.ObjetsFixes
{
    class Arbre:ObjetFixe
    {
        public Arbre(List<Tuple<int, int>> positionObjet, Monde planete) : base(positionObjet, planete) { }

    }
}
