﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPGestionDeColonie
{
    abstract class Colon
    {
        // Variables
        private Tuple<int, int> positionColon;
        protected static int id  =  0;
        protected int idColon;
        public string Nom  {
            get;
            set;
        }
        public int positionX;
        public int positionY;
        public int Endurance
        {
            get;
            set;
        }
        public int Sante
        {
            get;
            set;
        }
        public int Faim
        {
            get;
            set;
        }
        public int Soif
        {
            get;
            set;
        }
        // protected List<string> capacites;

        //getter ID;
        public int getId()
        {
            return idColon;
        }
        public int[] StockRessources { get; }

        public Monde Planete { get; }
        // -------------------------------------------

        public Colon (string nom, int positionX, int positionY, int endurance, int sante, int faim, int soif, Monde planete) //, List<string> capacites
        {
            id = id+1;
            idColon = id;
            this.positionX = positionX;
            this.positionY= positionY;
            Endurance = endurance;
            Sante = sante;
            Faim = faim;
            Soif = soif;
            Nom = nom;
            positionColon = new Tuple<int, int>(positionX, positionY);
            Planete = planete;
            StockRessources = new int[]{ 0, 0, 10}; //Bois//Pierre//Eau
        }
        public Tuple<int, int> getPosition()
        {
            return positionColon;
        }

        public void EtreFatigue()
        {
            if (Endurance<20)
            {
                Console.WriteLine("Tristan est raplapla");
            }
        }
       
        public void AvoirSoif()
        {
            if (Soif < 20)
            {
                Console.WriteLine("Glouglou");
            }
        }
        
        public void SanteFaible()
        {
            if (Sante < 20)
            {
                Console.WriteLine("Aïe aïe aïe, je ne suis pas en bon état.");
            }
            
        }


        public void VerififierEtat()
        //Vérifie l'état physique du Colon
        {
            int pdvPerdus=0;
            if (0<Endurance && Endurance<= 10){pdvPerdus += 1;}
            else if(Endurance ==0){pdvPerdus +=2;}
            
            if (0<Soif && Soif<= 10){pdvPerdus += 1;}
            else if(Soif ==0){pdvPerdus +=2;}

            if (0<Faim && Faim<= 10){pdvPerdus += 1;}
            else if(Faim ==0){pdvPerdus +=2;}       

            Sante -= pdvPerdus;

            Console.WriteLine($"{Nom} a perdu {pdvPerdus} points de vie. Santé restante : {Sante} / 100.");
        }

        public override string ToString()
        {
            return $"Colon n°{idColon} : {GetType().Name} {Nom}, santé = {Sante}/100 PV, endurance = {Endurance}/100, faim = {Faim}/100, soif = {Soif}/100";
        }

        
        public virtual void Miner(int x, int y){ Console.Write("test"); } //pour Mineur

        public virtual void Couper(int x, int y) { } //pour Bûcheron

        public virtual void Planter() { } //pour Paysan

        public virtual void Recolter(int x, int y) { } //pour Paysan


        public void Deplacer(int x, int y)
        {
            Endurance -= Math.Abs(positionX - x) + Math.Abs(positionY - y);
            while (positionX != x && positionY != y)
            {
                if(positionX > x && positionY > y)
                {
                    positionX -= 1;
                    positionY -= 1;
                }
                else if (positionX < x && positionY > y)
                {
                    positionX += 1;
                    positionY -= 1;
                }
                else if (positionX > x && positionY < y)
                {
                    positionX -= 1;
                    positionY += 1;
                }
                else if (positionX < x && positionY < y)
                {
                    positionX += 1;
                    positionY += 1;
                }
            }
            if(positionX == x)
            {
                if (positionY > y)
                {
                    while (positionY != y)
                    {
                        positionY -= 1;
                    }
                }
                else if(positionY<y)
                {
                    while (positionY != y)
                    {
                        positionY += 1;
                    }
                }
            }
            if (positionY == y)
            {
                if (positionX > x)
                {
                    while (positionX != x)
                    {
                        positionX -= 1;
                    }
                }
                else if (positionX < y)
                {
                    while (positionX != x)
                    {
                        positionX += 1;
                    }
                }
            }
            positionColon = new Tuple<int, int>(positionX,  positionY);
            
        }

        public void SeDeplacerVersItem(int x, int y)
        {
            //cases autour de la cible : { x , y , distance au colon }
            int[] haut = new int[] {  x  -  1,  y, Math.Abs(positionX-(x-1))+Math.Abs(positionY-y)  };
            int[] bas = new int[] {  x  +  1,  y, Math.Abs(positionX - (x +1)) + Math.Abs(positionY - y) };
            int[] gauche = new int[] { x, y-1, Math.Abs(positionX - x) + Math.Abs(positionY - (y-1)) };
            int[] droite = new int[] { x, y+1, Math.Abs(positionX - x) + Math.Abs(positionY - (y + 1)) };

            int distanceMin = Math.Min(Math.Min(Math.Min(haut[2],  bas[2]),  gauche[2]),  droite[2]);  
            if(haut[2] == distanceMin)
            {
                Deplacer(haut[0], haut[1]);
            }
            else if(bas[2] == distanceMin)
            {
                Deplacer(bas[0], bas[1]);
            }
            else if (gauche[2] == distanceMin)
            {
                Deplacer(gauche[0], gauche[1]);
            }
            else if (droite[2] == distanceMin)
            {
                Deplacer(droite[0], droite[1]);
            }
        }
    }    
}
