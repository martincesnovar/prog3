/*
 *  vir
 * https://www.codeproject.com/Articles/334773/Graphical-BinaryTrees
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace Vizualizacija_Dreves
{
    class Drevo<T> where T: IComparable
    {
        public T Vrednost { get; set; }
        public Drevo<T> Levo { get; set; }
        public Drevo<T> Desno { get; set; }
        public bool JeList { get { return Desno == null && Levo == null; } }
        public Drevo(T vrednost, Drevo<T> levo, Drevo<T> desno)
        {
            Desno = levo;
            Levo = desno;
            Vrednost = vrednost;
        }
        public Drevo(T vrednost) : this(vrednost, null, null) { }
        public Drevo() : this(default, null, null) { }

        
        private bool _je_Spremenjen = true;

        public bool JeSpremenjen
        {
            get
            {
                if (_je_Spremenjen)
                    return true;
                var spremenjeniNalsedniki = false;
                if (Levo != null)
                    spremenjeniNalsedniki |= Levo.JeSpremenjen;
                if (Desno != null)
                    spremenjeniNalsedniki |= Desno.JeSpremenjen;
                return spremenjeniNalsedniki;
            }
            private set { _je_Spremenjen = value; }
        }
        public int CompareTo(T other)
        {
            if (this.Vrednost.CompareTo(this.Levo) > 0) return 1;
            else if (this.Vrednost.CompareTo(this.Levo) < 0) return -1;
            else return 0;
        }

        /// <summary>
        /// Najde vrednost
        /// </summary>
        /// <param name="vrednost">Vrednost, ki jo iščemo</param>
        /// <returns></returns>
        public virtual Drevo<T> Find(T vrednost)
        {
            Drevo<T> vozel = this;
            while (vozel != null)
            {
                if (vozel.Vrednost.Equals(vrednost)) //našel je vrednost
                    return vozel;
                else
                {

                    if (Levo.CompareTo(Vrednost)<0)
                        vozel = vozel.Levo;
                    else
                        vozel = vozel.Desno;
                }
            }
            return null; //ni našel
        }

        public bool Add(Drevo<T> drevo)
        {
            if (!drevo.JeList)//
                throw new ArgumentException("Ni posamezen vozel drevesa.");

            var res = false;
            if (drevo.Vrednost.CompareTo(Vrednost) < 0) // dodaj na levo
            {
                res = true;
                if (Levo == null)
                    Levo = drevo;
                else
                    res = Levo.Add(drevo);
                JeSpremenjen = true;
            }
            else if (drevo.Vrednost.CompareTo(Vrednost) > 0) // dodaj na desno.
            {
                res = true;
                JeSpremenjen = true;
                if (Desno == null)
                    Desno = drevo;
                else
                    res = Desno.Add(drevo);
            }
            else throw new Exception("Vrednost je že v drevesu.");
            return res;
        }
        public bool Odstrani(T vrednost, out bool vsebuje)
        {
            Drevo<T> Vozel_odstrani;
            vsebuje = false;
            // iskanje
            var levi = vrednost.CompareTo(Vrednost)<0;
            if (vrednost.CompareTo(Vrednost) < 0)
                Vozel_odstrani = Levo;
            else if (vrednost.CompareTo(Vrednost)>0)
                Vozel_odstrani = Desno;
            else
            {
                if (Levo != null)
                    Levo.JeSpremenjen = true;
                if (Desno != null)
                    Desno.JeSpremenjen = true;
                vsebuje = true;
                return false; // ni še odstranjen
            }

            if (Vozel_odstrani == null)
                return false;

            bool vsebovan_na_sinu;
            var result = Vozel_odstrani.Odstrani(vrednost, out vsebovan_na_sinu);
            if (vsebovan_na_sinu) //
            {
                JeSpremenjen = true;
                if (Vozel_odstrani.Levo == null && Vozel_odstrani.Desno == null)// 1. odstranjevanje, če ni sinov
                {
                    if (levi) Levo = null; else Desno = null;
                }
                else if (Vozel_odstrani.Desno == null)                        // 2. odstranjevalni vozel ima levega sina
                {
                    if (levi) Levo = Vozel_odstrani.Levo; else Desno = Vozel_odstrani.Levo;
                }
                else                                                        // levi in desni nista prazna
                {
                    if (Vozel_odstrani.Desno.Levo == null)                    // 3. desni sin nima levega sina
                    {
                        Vozel_odstrani.Desno.Levo = Vozel_odstrani.Levo;
                        if (levi)
                            Levo = Vozel_odstrani.Desno;
                        else
                            Desno = Vozel_odstrani.Desno;
                    }
                    else                                                    // 4. desni sin ima levega sina
                    {
                        Drevo<T> naj_levi = null;
                        for (var node = Vozel_odstrani.Desno; node != null; node = node.Levo) //sprehod do najbolj levega sina.
                            if (node.Levo == null)
                                naj_levi = node;
                        bool temp;
                        var v = naj_levi.Vrednost;

                        // rekruzivni klic odstrani najbolj levega sina v desnem poddrevesu
                        Odstrani(naj_levi.Vrednost, out temp);
                        Vozel_odstrani.Vrednost = v;
                    }
                }
                return true;
            }
            return result;
        }
        public bool Obstaja(T vrednost)
        {
            var res = vrednost.Equals(Vrednost);
            if (!res && Levo != null)
                res = Levo.Obstaja(vrednost);
            if (!res && Desno != null)
                res = Desno.Obstaja(vrednost);
            return res;
        }
        /// <summary>
        /// prešteje vozlišča poddreves.
        /// </summary>
        public int Prestej
        {
            get
            {
                return 1 + (Levo != null ? Levo.Prestej : 0) + (Desno != null ? Desno.Prestej : 0);
            }
        }

        //metode za risanje
        private static Bitmap _nodeBg = new Bitmap(30, 25);
        private static Size _freeSpace = new Size(_nodeBg.Width / 8, (int)(_nodeBg.Height * 1.3f));
        private static readonly float Coef = _nodeBg.Width / 40f;

        /// <summary>
        /// Statični konstruktor
        /// </summary>
        static Drevo()
        {
            var g = Graphics.FromImage(_nodeBg);                                    // get a Graphics from _nodeBg bitmap, 
            g.SmoothingMode = SmoothingMode.HighQuality;                            // set the smoothing mode
            var rcl = new Rectangle(1, 1, _nodeBg.Width - 2, _nodeBg.Height - 2);   // get a rectangle of drawer
            g.FillRectangle(Brushes.White, rcl);
            g.DrawEllipse(new Pen(Color.Green, 1.2f), rcl);                          // draw ellipse, you could also comment this line, and uncomment the above line as another option for background image
        }

        Image _lastImage;
        private int _lastImageLocationOfStarterNode;
        private static Font font = new Font("Tahoma", 14f * Coef);

        public Image Draw(out int center)
        {
            center = _lastImageLocationOfStarterNode;
            if (!JeSpremenjen) // if the current node and it's childs are up to date, just return the last drawed image.
                return _lastImage;

            var lCenter = 0;
            var rCenter = 0;

            Image lNodeImg = null, rNodeImg = null;
            if (Levo != null)       // draw left node's image
                lNodeImg = Levo.Draw(out lCenter);
            if (Desno != null)      // draw right node's image
                rNodeImg = Desno.Draw(out rCenter);

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
            JeSpremenjen = false;
            _lastImage = result;
            _lastImageLocationOfStarterNode = center;
            return result;
        }

    }
}
