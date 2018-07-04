using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ZedGraph;

namespace SeismicProfileNameSpace
{
    public class SeismicProfile
    {
        CurveList GcurveItems = new CurveList();
        ArrayList arrayList = new ArrayList();
        public int Nt { get; set; }
        public int Nx { get; set; }
        public int Nz { get; set; }
        public float[,] V { get; set; }
        public float[,] Record { get; set; }
        public SeismicProfile(int nt, int nx, int nz, float[,] v, CurveList curveItems)
        {
            Nt = nt;
            Nx = nx;
            Nz = nz;
            V = v;
            Record = new float[nx, nt];
            GcurveItems = curveItems;
            setKLines();
        }
        public void Calculate()
        {
            int row = Nx;
            int col = V.GetUpperBound(1) + 1;
            Random randObj = new Random();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col - 1; j++)
                {
                    if ((V[i, j] - V[i, (j + 1)]) != 0)
                    {
                        int x = (Nt * j) / Nz;
                        double coefficient = 1;
                        for (int k = 0; k < arrayList.Count; k++)
                        {
                            K_line_OBJ k_Line_OBJ = arrayList[k] as K_line_OBJ;
                            if (k_Line_OBJ.isContain(i, x))
                            {
                                coefficient = 1 / (1 + k_Line_OBJ.K);
                                break;
                            }
                        }
                        if (x - 5 != -1)
                        {
                            Record[i, x - 5] = -0.2F * float.Parse(coefficient.ToString());
                            Record[i, x - 4] = -0.3F * float.Parse(coefficient.ToString());
                            Record[i, x - 3] = 0F * float.Parse(coefficient.ToString());
                            Record[i, x - 2] = 0.3F * float.Parse(coefficient.ToString());
                            Record[i, x - 1] = 0.5F * float.Parse(coefficient.ToString());
                        }
                        Record[i, x] = 0.7F * float.Parse(coefficient.ToString());
                        if (x + 5 != Nt)
                        {
                            Record[i, x + 1] = 0.5F * float.Parse(coefficient.ToString());
                            Record[i, x + 2] = 0.3F * float.Parse(coefficient.ToString());
                            Record[i, x + 3] = 0F * float.Parse(coefficient.ToString());
                            Record[i, x + 4] = -0.3F * float.Parse(coefficient.ToString());
                            Record[i, x + 5] = -0.2F * float.Parse(coefficient.ToString());
                        }
                        //添加随机噪声
                        if (randObj.Next(2, 3) == 2)
                        {
                            if (x - 15 != -1)
                            {
                                Record[i, x - 15] = 0.1F;
                                Record[i, x - 10] = 0.2F;
                                Record[i, x - 8] = 0.1F;
                            }
                            if (x + 15 != -1)
                            {
                                Record[i, x + 15] = 0.1F;
                                Record[i, x + 10] = 0.2F;
                                Record[i, x + 8] = 0.1F;
                            }
                        }
                    }
                }
            }
            Thread.Sleep(10000);
        }

        public void setKLines()
        {
            for (int i = 0; i < GcurveItems.Count - 1; i++)
            {
                IPointListEdit oldlist = GcurveItems[i].Points as IPointListEdit;
                for (int j = 0; j < oldlist.Count - 1; j++)
                {
                    double k = Math.Abs((((oldlist[j + 1].Y * Nt) / Nz - (oldlist[j].Y * Nt) / Nz)) / ((oldlist[j + 1].X - oldlist[j].X)));
                    double[] box = { Math.Min(oldlist[j].X, oldlist[j + 1].X), Math.Min((oldlist[j + 1].Y * Nt) / Nz, (oldlist[j].Y * Nt) / Nz), Math.Max(oldlist[j].X, oldlist[j + 1].X), Math.Max((oldlist[j + 1].Y * Nt) / Nz, (oldlist[j].Y * Nt) / Nz) };
                    K_line_OBJ k_Line_OBJ = new K_line_OBJ(box, k);
                    arrayList.Add(k_Line_OBJ);
                }
            }
        }
        private class K_line_OBJ
        {
            public double[] Box { get; set; }
            public double K { get; set; }

            public K_line_OBJ(double[] box, double k)
            {
                Box = box;
                K = k;
            }
            public bool isContain(double x, double y)
            {
                bool res = false;
                if (x > Box[0] && x < Box[1] && y > Box[2] && y < Box[3])
                {
                    res = true;
                }
                return res;
            }
        }
    }
}
