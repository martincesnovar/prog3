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

        public bool Add(Drevo<T> drevo)
        {
            if (!drevo.JeList)// if the node is not single do not add it!, you can change the code in order to make it addable!
                throw new ArgumentException("the node should be single to be added.");

            var res = false;
            if (drevo.Vrednost.CompareTo(Vrednost)<0) // add to left : it's value is less than the value of the current node
            {
                res = true;
                if (Levo == null)
                    Levo = drevo;
                else
                    res = Levo.Add(drevo);
                JeSpremenjen = true;
            }
            if (drevo.Vrednost.CompareTo(Vrednost) > 0) // add to right: it's value is greater than the value of the current node
            {
                res = true;
                JeSpremenjen = true;
                if (Desno == null)
                    Desno = drevo;
                else
                    res = Desno.Add(drevo);
            }
            return res;
        }

        public bool Remove(T Vrednost, out bool vsebovan_na_vozlu)
        {
            Drevo<T> Odstrani_vozel;
            vsebovan_na_vozlu = false;
            // search for the node containing the nodeValue
            var je_Levo = Vrednost.CompareTo(this.Vrednost);
            if (this.Vrednost.CompareTo(Vrednost)<0)
                Odstrani_vozel = Levo;
            else if (this.Vrednost.CompareTo(Vrednost) > 0)
                Odstrani_vozel = Desno;
            else
            {
                if (Levo != null)
                    Levo.JeSpremenjen = true;
                if (Desno != null)
                    Desno.JeSpremenjen = true;
                // the current node contains the nodeValue.
                // search is completed
                vsebovan_na_vozlu = true;
                return false; // not yet removed!
            }

            if (Odstrani_vozel == null)
                return false;

            bool vsebovan_na_naslednjem;
            bool result = Odstrani_vozel.Remove(Vrednost, out vsebovan_na_naslednjem);
            if (vsebovan_na_naslednjem) // if the child of the current node contained the nodeValue, that child should be removed.
            {
                JeSpremenjen = true;
                if (Odstrani_vozel.Levo == null && Odstrani_vozel.Desno == null)// 1. the removing node has no child
                {
                    if (je_Levo<0) Levo = null;
                    else Desno = null;
                }
                else if (Odstrani_vozel.Desno == null)                        // 2. the removing node has left child
                {
                    if (je_Levo<0) Levo = Odstrani_vozel.Levo;
                    else Desno = Odstrani_vozel.Levo;
                }
                else                                                        // left and right are not null
                {
                    if (Odstrani_vozel.Desno.Levo == null)                    // 3. the removing nodes' right child has no left child
                    {
                        Odstrani_vozel.Desno.Levo = Odstrani_vozel.Levo;
                        if (je_Levo<0)
                            Levo = Odstrani_vozel.Desno;
                        else
                            Desno = Odstrani_vozel.Desno;
                    }
                    else                                                    // 4. the removing nodes' right child has left child
                    {
                        Drevo<T> naj_Levo = null;
                        for (var drevo = Odstrani_vozel.Desno; drevo != null; drevo = drevo.Levo)
                            if (drevo.Levo == null)
                                naj_Levo = drevo;
                        bool temp;
                        var v = naj_Levo.Vrednost;

                        // recursive call: removing the most left child of the right child of the removing node.
                        Remove(naj_Levo.Vrednost, out temp);
                        Odstrani_vozel.Vrednost = v;
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
        /// the count of nodes under this node + 1
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

        static Drevo()
        {
            var g = Graphics.FromImage(_nodeBg);                                    // get a Graphics from _nodeBg bitmap, 
            g.SmoothingMode = SmoothingMode.HighQuality;                            // set the smoothing mode
            var rcl = new Rectangle(1, 1, _nodeBg.Width - 2, _nodeBg.Height - 2);   // get a rectangle of drawer
            g.FillRectangle(Brushes.White, rcl);
            //g.FillEllipse(new LinearGradientBrush(new Point(0, 0), new Point(_me.Width, _me.Height), Color.Goldenrod, Color.Black), rcl);
            g.DrawEllipse(new Pen(Color.Black, 1.2f), rcl);                          // draw ellipse, you could also comment this line, and uncomment the above line as another option for background image
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
