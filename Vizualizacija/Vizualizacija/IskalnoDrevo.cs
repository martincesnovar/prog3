//====================================================================
//| Razred                                                           |
//| Visual C# Kicks - http://www.vcskicks.com/                       |
//| License - http://www.vcskicks.com/license.html                   |
//| Grafika                                                          |
//|https://www.codeproject.com/Articles/334773/Graphical-BinaryTrees |
//====================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace Vizualizacija
{
    class Vozel<T> where T : IComparable
    {
        private T vrednost;
        private Vozel<T> levi;
        private Vozel<T> desni;
        private Vozel<T> trenutni;
        //private IskalnoDrevo<T> drevo;

        public virtual T Vrednost
        {
            get { return vrednost; }
            set { this.vrednost = value; }
        }

        public virtual Vozel<T> Levi
        {
            get { return levi; }
            set { levi = value; }
        }

        public virtual Vozel<T> Desni
        {
            get { return desni; }
            set { desni = value; }
        }

        public virtual Vozel<T> Trenutni
        {
            get { return trenutni; }
            set { trenutni = value; }
        }


        public int CompareTo(T other)
        {
            return 0;
        }

        /// <summary>
        /// Ali je list
        /// </summary>
       public virtual bool JeList
        {
            get {
                if (Trenutni!= null)
                return Trenutni.Prestej == 0;
                return false;
            }
        }
        /// <summary>
        /// Ali je notranji
        /// </summary>
        public virtual bool JeNotranji
        {
            get { return this.Prestej > 0; }
        }
        /// <summary>
        /// Ali je vozel levi sin od vozla
        /// </summary>
        public virtual bool JeLevi
        {
            get { return this.Trenutni != null && this.Trenutni.Levi == this; }
        }

        /// <summary>
        /// Ali je vozel levi sin od vozla
        /// </summary>
        public virtual bool JeDesni
        {
            get { return this.Trenutni != null && this.Trenutni.Desni == this; }
        }

        /// <summary>
        /// Stevilo naslednikov vozla
        /// </summary>
        public virtual int Prestej
        {
            get
            {
                int stej = 0;
                if (Trenutni == null) return 0;
                if (Trenutni.Levi != null) stej++;
                else if (Trenutni.Desni != null) stej++;
                return stej;
            }
        }
        public virtual bool Ima_Levega
        {
            get { return Levi != null; }
        }

        public virtual bool Ima_Desnega
        {
            get { return Desni != null; }
        }

        public Vozel(T value)
        {
            this.vrednost = value;
        }
        //Grafika
        private static Bitmap _nodeBg = new Bitmap(30, 25);
        private static Size _freeSpace = new Size(_nodeBg.Width / 8, (int)(_nodeBg.Height * 1.3f));
        private static readonly float Coef = _nodeBg.Width / 40f;
        static Vozel()
        {
            var g = Graphics.FromImage(_nodeBg);                                    // get a Graphics from _nodeBg bitmap, 
            g.SmoothingMode = SmoothingMode.HighQuality;                            // set the smoothing mode
            var rcl = new Rectangle(1, 1, _nodeBg.Width - 2, _nodeBg.Height - 2);   // get a rectangle of drawer
            g.FillRectangle(Brushes.White, rcl);
            //g.FillEllipse(new LinearGradientBrush(new Point(0, 0), new Point(_me.Width, _me.Height), Color.Goldenrod, Color.Black), rcl);
            g.DrawEllipse(new Pen(Color.Black, 1.2f), rcl);                          // draw ellipse, you could also comment this line, and uncomment the above line as another option for background image
        }
        private bool je_Spremenjen = true;
        /// <summary>
        /// true indicates that the current node or it's childs' has been updated or changed, and this value will cause the drawer redraw the current node
        /// </summary>
        public bool JeSpremenjen
        {
            get
            {
                if (je_Spremenjen)
                    return true;
                var spremenjeni_nasledniki = false;
                if (Levi != null)
                    spremenjeni_nasledniki |= Levi.JeSpremenjen;
                if (Desni != null)
                    spremenjeni_nasledniki |= Desni.JeSpremenjen;
                return spremenjeni_nasledniki;
            }
            private set { je_Spremenjen = value; }
        }
        Image _lastImage;
        private int _lastImageLocationOfStarterNode;
        private static Font font = new Font("Tahoma", 14f * Coef);

        public Image Risi(out int center)
        {
            center = _lastImageLocationOfStarterNode;
            if (!JeSpremenjen) // if the current node and it's childs are up to date, just return the last drawed image.
                return _lastImage;

            var lCenter = 0;
            var rCenter = 0;

            Image lNodeImg = null, rNodeImg = null;
            if (Levi != null)       // draw left node's image
                lNodeImg = Levi.Risi(out lCenter);
            if (Desni != null)      // draw right node's image
                rNodeImg = Desni.Risi(out rCenter);

            // draw current node and it's childs (left node image and right node image)
            var lSize = new Size();
            var rSize = new Size();
            var under = (lNodeImg != null) || (rNodeImg != null);// if true the current node has childs
            if (lNodeImg != null)
                lSize = lNodeImg.Size;
            if (rNodeImg != null)
                rSize = rNodeImg.Size;

            var maxHeight = lSize.Height;
            if (maxHeight < rSize.Height)
                maxHeight = rSize.Height;

            if (lSize.Width <= 0)
                lSize.Width = (_nodeBg.Width - _freeSpace.Width) / 2;
            if (rSize.Width <= 0)
                rSize.Width = (_nodeBg.Width - _freeSpace.Width) / 2;

            var resSize = new Size
            {
                Width = lSize.Width + rSize.Width + _freeSpace.Width,
                Height = _nodeBg.Size.Height + (under ? maxHeight + _freeSpace.Height : 0)
            };

            var result = new Bitmap(resSize.Width, resSize.Height);
            var g = Graphics.FromImage(result);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), resSize));
            g.DrawImage(_nodeBg, lSize.Width - _nodeBg.Width / 2 + _freeSpace.Width / 2, 0);
            var str = Vrednost.ToString();
            g.DrawString(str, font, Brushes.Black, lSize.Width - _nodeBg.Width / 2 + _freeSpace.Width / 2 + (2 + (str.Length == 1 ? 10 : str.Length == 2 ? 5 : 0)) * Coef, _nodeBg.Height / 2f - 12 * Coef);


            center = lSize.Width + _freeSpace.Width / 2;
            var pen = new Pen(Brushes.Black, 1.2f * Coef)
            {
                EndCap = LineCap.ArrowAnchor,
                StartCap = LineCap.Round
            };


            float x1 = center;
            float y1 = _nodeBg.Height;
            float y2 = _nodeBg.Height + _freeSpace.Height;
            float x2 = lCenter;
            var h = Math.Abs(y2 - y1);
            var w = Math.Abs(x2 - x1);
            if (lNodeImg != null)
            {
                g.DrawImage(lNodeImg, 0, _nodeBg.Size.Height + _freeSpace.Height);
                var points1 = new List<PointF>
                                  {
                                      new PointF(x1, y1),
                                      new PointF(x1 - w/6, y1 + h/3.5f),
                                      new PointF(x2 + w/6, y2 - h/3.5f),
                                      new PointF(x2, y2),
                                  };
                g.DrawCurve(pen, points1.ToArray(), 0.5f);
            }
            if (rNodeImg != null)
            {
                g.DrawImage(rNodeImg, lSize.Width + _freeSpace.Width, _nodeBg.Size.Height + _freeSpace.Height);
                x2 = rCenter + lSize.Width + _freeSpace.Width;
                w = Math.Abs(x2 - x1);
                var points = new List<PointF>
                                 {
                                     new PointF(x1, y1),
                                     new PointF(x1 + w/6, y1 + h/3.5f),
                                     new PointF(x2 - w/6, y2 - h/3.5f),
                                     new PointF(x2, y2)
                                 };
                g.DrawCurve(pen, points.ToArray(), 0.5f);
            }
            je_Spremenjen = false;
            _lastImage = result;
            _lastImageLocationOfStarterNode = center;
            return result;
        }
    }



    /// <summary>
    /// Predstavitev iskalnega drevesa
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class IskalnoDrevo<T> : ICollection<T>
        where T : IComparable
    {
        public enum Pregled
        {
            Vmesni = 0,
            Obratni,
            Premi
        }

        private Vozel<T> vozel;
        private Comparison<IComparable> comparer = CompareElements;
        private int velikost;
        private Pregled pregled = Pregled.Vmesni;

        public virtual Vozel<T> Koren
        {
            get { return vozel; }
            set { vozel = value; }
        }
        public virtual int Velikost
        {
            get { return velikost; }
        }
        public virtual Pregled Pregled_Elementov
        {
            get { return pregled; }
            set { pregled = value; }
        }
        public IskalnoDrevo()
        {
            vozel = null;
            velikost = 0;
        }
        /// <summary>
        /// Ali je le za branje le za IColection
        /// </summary>
        public virtual bool IsReadOnly
        {
            get { return false; }
        }

        public int Count => velikost;

        /// <summary>
        /// Doda vozel v drevo. Add implementira IColection
        /// </summary>
        /// <param name="vrednost"></param>
        public virtual void Add(T vrednost)
        {
            Vozel<T> vozel = new Vozel<T>(vrednost);
            this.Vstavi(vozel);
        }
        public virtual void Vstavi(Vozel<T> vozel)
        {
            if (this.vozel == null) //doda prvi element.
            {
                this.vozel = vozel; //označi vozel kot koren
                //vozel.Drevo = this;
                velikost++;
            }
            else
            {
                if (vozel.Trenutni == null)
                    vozel.Trenutni = vozel; //zacetek
                //Če je element, ki ga vstavljamo manjši od trenutnega korena ga vstavimo na levo stran.
                bool vstavi_na_levo = comparer((IComparable)vozel.Vrednost, (IComparable)vozel.Trenutni.Vrednost) < 0;
                
                if (vstavi_na_levo)
                {
                    if (vozel.Trenutni.Levi == null)
                    {
                        vozel.Trenutni.Levi = vozel;
                        velikost++;
                        //vozel.Drevo = this;
                    }
                    else
                    {
                        vozel.Trenutni = vozel.Trenutni.Levi;
                        this.Vstavi(vozel);
                    }
                }
                else //vstavi na desno
                {
                    if (vozel.Trenutni.Desni == null)
                    {
                        vozel.Trenutni.Desni = vozel; //vstavi na desno
                        velikost++;
                        //vozel.Drevo = this;
                    }
                    else
                    {
                        vozel.Trenutni = vozel.Trenutni.Desni;
                        this.Vstavi(vozel);
                    }
                }
            }
        }
        /// <summary>
        /// Najde vrednost
        /// </summary>
        /// <param name="vrednost">Vrednost, ki jo iščemo</param>
        /// <returns></returns>
        public virtual Vozel<T> Find(T vrednost)
        {
            Vozel<T> vozel = this.vozel;
            while (vozel != null)
            {
                if (vozel.Vrednost.Equals(vrednost)) //našel je vrednost
                    return vozel;
                else
                {
                    bool isci_levo = comparer((IComparable)vrednost, (IComparable)vozel.Vrednost) < 0;

                    if (isci_levo)
                        vozel = vozel.Levi;
                    else
                        vozel = vozel.Desni;
                }
            }
            return null; //ni našel
        }
        /// <summary>
        /// Vrne, če je vrednost v drevesu - ICollection
        /// </summary>
        public virtual bool Contains(T vrednost)
        {
            return (Find(vrednost) != null);
        }
        /// <summary>
        /// Odstrani vrednost iz drevesa.
        /// </summary>
        public virtual bool Remove(T vrednost)
        {
            Vozel<T> vozel_odstrani = Find(vrednost);

            return this.Odstrani(vozel_odstrani);
        }
        /// <summary>
        /// Odstrani vozel iz drevesa.
        /// </summary>>
        public virtual bool Odstrani(Vozel<T> vozel)
        {
            if (vozel == null)// || vozel.Drevo != this)
                return false; //vrednost ne obstaja

            //Note whether the node to be removed is the root of the tree
            bool glavni = (vozel == this.vozel);

            if (this.Count() == 1)
            {
                this.vozel = null; //le 1 element je bil.
                //vozel.Drevo = null;

                velikost--; //zmanjšaj število elementov
            }
            else if (vozel.JeList) //Primer 1: Ni naslednikov
            {
                if (vozel.JeLevi)
                    vozel.Trenutni.Levi = null;
                else
                    vozel.Trenutni.Desni = null;

                //vozel.Drevo = null;
                vozel.Trenutni = null;

                velikost--;
            }
            else if (vozel.Prestej == 1) //Primer 2: 1 nasledni
            {
                if (vozel.JeLevi)
                {
                    //Put left child node in place of the node to be removed
                    vozel.Levi.Trenutni = vozel.Trenutni; //update parent

                    if (glavni)
                        this.Koren = vozel.Levi; //update root reference if needed

                    if (vozel.JeLevi) //update the parent's child reference
                        vozel.Trenutni.Levi = vozel.Levi;
                    else
                        vozel.Trenutni.Levi = vozel.Levi;
                }
                else //Ima desnega
                {
                    vozel.Levi.Trenutni = vozel.Trenutni; //update parent

                    if (glavni)
                        this.Koren = vozel.Desni; //update root reference if needed

                    if (vozel.JeLevi) //update the parent's child reference
                        vozel.Trenutni.Levi = vozel.Desni;
                    else
                        vozel.Trenutni.Desni = vozel.Desni;
                }

                //vozel.Drevo = null;
                vozel.Trenutni = null;
                vozel.Levi = null;
                vozel.Desni = null;

                velikost--; //decrease total element count
            }
            else //Primer 3: 2 naslednika
            {
                //Najdi predhodnika v vmesnem pregledu
                Vozel<T> naslednji_vozel = vozel.Levi;
                if (naslednji_vozel != null)
                {
                    while (naslednji_vozel.Desni != null)
                    {
                        naslednji_vozel = naslednji_vozel.Desni;
                    }

                    vozel.Vrednost = naslednji_vozel.Vrednost; //zamenjaj vrednost

                    this.Odstrani(naslednji_vozel); //rekurzivno odstrani.
                }
            }
            return true;
        }
        /// <summary>
        /// Odstrani vse elemente v drevesu.
        /// </summary>
        public virtual void Clear()
        {
            //Odstrani najprej naslednike, potem trenutne
            //(Obratni pregled)
            IEnumerator<T> enumerator = Obratni_Pregled();
            while (enumerator.MoveNext())
            {
                this.Remove(enumerator.Current);
            }
            enumerator.Dispose();
        }

        /// <summary>
        /// Vrne višino drevesa
        /// </summary>
        public virtual int Visina()
        {
            return Visina(Koren.Vrednost);
        }

        /// <summary>
        /// Returns the height of the subtree rooted at the parameter value
        /// </summary>
        public virtual int Visina(T vrednost)
        {
            //Find the value's node in tree
            Vozel<T> vrednost_vozla = this.Find(vrednost);
            if (vrednost != null)
                return this.Visina(vrednost_vozla);
            else
                return 0;
        }

        /// <summary>
        /// Vrne višino drevesa z začetkom v začetnem vozlu
        /// </summary>
        public virtual int Visina(Vozel<T> zacetni_vozel)
        {
            if (zacetni_vozel == null)
                return 0;
            else
                return 1 + Math.Max(Visina(zacetni_vozel.Levi), Visina(zacetni_vozel.Desni));
        }

        /// <summary>
        /// Vrne globino drevesa od dane vrednosti dalje
        /// </summary>
        public virtual int Globina(T value)
        {
            Vozel<T> voz = this.Find(value);
            return this.Globina(voz);
        }

        /// <summary>
        /// Vrne globino poddrevesa
        /// </summary>
        public virtual int Globina(Vozel<T> zacetni_vozel)
        {
            int globina = 0;

            if (zacetni_vozel == null)
                return globina;

            Vozel<T> trenutni = zacetni_vozel.Trenutni;
            while (trenutni != null)
            {
                globina++;
                trenutni = trenutni.Trenutni;
            }

            return globina;
        }

        /// <summary>
        /// Vrne enumerator
        /// Enumerator upotablja pregled nastavljen v Pregledu.
        /// </summary>
        public virtual IEnumerator<T> GetEnumerator()
        {
            switch (Pregled_Elementov)
            {
                case Pregled.Vmesni:
                    return Vmesni_Pregled();
                case Pregled.Obratni:
                    return Obratni_Pregled();
                case Pregled.Premi:
                    return Premi_Pregled();
                default:
                    return Vmesni_Pregled();
            }
        }

        /// <summary>
        /// Vrne enumerator
        /// Enumerator upotablja pregled nastavljen v Pregledu.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Vrne enumerator vmesnega pregleda (levi, trenutni, desni)
        /// </summary>
        public virtual IEnumerator<T> Vmesni_Pregled()
        {
            return new BinaryTreeInOrderEnumerator(this);
        }

        /// <summary>
        /// Vrne enumerator obratnega pregleda (levi, desni, trenutni)
        /// </summary>
        public virtual IEnumerator<T> Obratni_Pregled()
        {
            return new BinaryTreePostOrderEnumerator(this);
        }

        /// <summary>
        /// Vrne enumerator premega pregleda
        /// </summary>
        public virtual IEnumerator<T> Premi_Pregled()
        {
            return new BinaryTreePreOrderEnumerator(this);
        }

        /// <summary>
        /// Kopira elemente drevesa v seznam glede na pregled.
        /// </summary>
        public virtual void CopyTo(T[] array)
        {
            this.CopyTo(array, 0);
        }

        /// <summary>
        /// Kopira elemente drevesa v seznam glede na pregled.
        /// </summary>
        public virtual void CopyTo(T[] array, int startIndex)
        {
            IEnumerator<T> enumerator = this.GetEnumerator();

            for (int i = startIndex; i < array.Length; i++)
            {
                if (enumerator.MoveNext())
                    array[i] = enumerator.Current;
                else
                    break;
            }
        }

        /// <summary>
        /// Primerja 2 elementa v drevesu in ugotovi pozicijo
        /// </summary>
        public static int CompareElements(IComparable x, IComparable y)
        {
            return x.CompareTo(y);
        }

        /// <summary>
        /// Vrne enumerator vmesnega pregleda
        /// </summary>
        internal class BinaryTreeInOrderEnumerator : IEnumerator<T>
        {
            private Vozel<T> current;
            private IskalnoDrevo<T> tree;
            internal Queue<Vozel<T>> pregled_vrsta;

            public BinaryTreeInOrderEnumerator(IskalnoDrevo<T> drevo)
            {
                this.tree = drevo;

                //Build queue
                pregled_vrsta = new Queue<Vozel<T>>();
                Obisci_Vozel(this.tree.Koren);
            }

            private void Obisci_Vozel(Vozel<T> vozel)
            {
                if (vozel == null)
                    return;
                else
                {
                    Obisci_Vozel(vozel.Levi);
                    pregled_vrsta.Enqueue(vozel);
                    Obisci_Vozel(vozel.Desni);
                }
            }

            public T Current
            {
                get { return current.Vrednost; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {
                current = null;
                tree = null;
            }

            public void Reset()
            {
                current = null;
            }

            public bool MoveNext()
            {
                if (pregled_vrsta.Count > 0)
                    current = pregled_vrsta.Dequeue();
                else
                    current = null;

                return (current != null);
            }
        }

        /// <summary>
        /// Vrne enumerator obratnega pregleda
        /// </summary>
        internal class BinaryTreePostOrderEnumerator : IEnumerator<T>
        {
            private Vozel<T> trenutni;
            private IskalnoDrevo<T> drevo;
            internal Queue<Vozel<T>> pregled_vrsta;

            public BinaryTreePostOrderEnumerator(IskalnoDrevo<T> drevo)
            {
                this.drevo = drevo;

                pregled_vrsta = new Queue<Vozel<T>>();
                obisci_Vozel(this.drevo.Koren);
            }

            private void obisci_Vozel(Vozel<T> node)
            {
                if (node == null)
                    return;
                else
                {
                    obisci_Vozel(node.Levi);
                    obisci_Vozel(node.Desni);
                    pregled_vrsta.Enqueue(node);
                }
            }

            public T Current
            {
                get { return trenutni.Vrednost; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {
                trenutni = null;
                drevo = null;
            }

            public void Reset()
            {
                trenutni = null;
            }

            public bool MoveNext()
            {
                if (pregled_vrsta.Count > 0)
                    trenutni = pregled_vrsta.Dequeue();
                else
                    trenutni = null;

                return (trenutni != null);
            }
        }

        /// <summary>
        /// Vrne premi pregled drevesa
        /// </summary>
        internal class BinaryTreePreOrderEnumerator : IEnumerator<T>
        {
            private Vozel<T> trenutni;
            private IskalnoDrevo<T> drevo;
            internal Queue<Vozel<T>> pregled_vrsta;

            public BinaryTreePreOrderEnumerator(IskalnoDrevo<T> drevo)
            {
                this.drevo = drevo;

                pregled_vrsta = new Queue<Vozel<T>>();
                obisci_vozel(this.drevo.Koren);
            }

            private void obisci_vozel(Vozel<T> node)
            {
                if (node == null)
                    return;
                else
                {
                    pregled_vrsta.Enqueue(node);
                    obisci_vozel(node.Levi);
                    obisci_vozel(node.Desni);
                }
            }

            public T Current
            {
                get { return trenutni.Vrednost; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {
                trenutni = null;
                drevo = null;
            }

            public void Reset()
            {
                trenutni = null;
            }

            public bool MoveNext()
            {
                if (pregled_vrsta.Count > 0)
                    trenutni = pregled_vrsta.Dequeue();
                else
                    trenutni = null;

                return (trenutni != null);
            }
        }
    }
}
