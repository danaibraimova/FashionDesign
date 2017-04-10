using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace FashionDesign
{
    class GeneticAlgorithm
    {
        public void Initializing(Form form)
        {
            int x = 0;
            int y = 0;
            List<Dress> dresspopulation = new List<Dress>();
            for(int i = 0; i < 8; i++)
            {
                Dress dress = new Dress();
                form.Controls.Clear();
                DressImage di=dress.ShowDress();
                di.Location= new Point(x, y);
                x += 200;
                if (x == form.Width) x = 0; y += 300;
                form.Controls.Add(di);
                dresspopulation.Add(dress);
            }
        }
    }
}
