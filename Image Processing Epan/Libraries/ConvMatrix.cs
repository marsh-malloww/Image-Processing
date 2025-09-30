using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Processing.Libraries
{
    public class ConvMatrix
    {

        public int TopLeft = 0, TopMid = 0, TopRight = 0;
        public int MidLeft = 0, Pixel = 1, MidRight = 0;
        public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;
        public int Factor = 1;
        public int Offset = 0;

        public void SetAll(int nVal)
        {
            TopLeft = TopMid = TopRight = MidLeft = Pixel = MidRight = BottomLeft = BottomMid = BottomRight = nVal;
        }

        public void setMatrix(int TopLeft, int TopMiddle, int TopRight, int MiddleLeft, int Pixel, int MiddleRight, int BottomLeft, int BottomMiddle, int BottomRight, int Factor = 1, int Offset = 0)
        {
            this.TopLeft = TopLeft;
            this.TopMid = TopMiddle;
            this.TopRight = TopRight;
            this.MidLeft = MiddleLeft;
            this.Pixel = Pixel;
            this.MidRight = MiddleRight;
            this.BottomLeft = BottomLeft;
            this.BottomMid = BottomMiddle;
            this.BottomRight = BottomRight;
            this.Factor = Factor;
            this.Offset = Offset;

        }
    }
}
