using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FashionDesign
{
    public class Dress
    {
        string skirt;
        string sleeve;
        string body;
        string bincode;
        public Dress()
        {
            this.skirt = Convert.ToString(RandomGenerator.rnd.Next(0, 9), 4);
            this.body = Convert.ToString(RandomGenerator.rnd.Next(0, 34), 6);
            this.sleeve = Convert.ToString(RandomGenerator.rnd.Next(0, 9), 4);
            this.bincode = GenerateBincode();
        }
        public string GenerateBincode()
        {
            string bincode = "";
            bincode += body;
            bincode += Convert.ToString(RandomGenerator.rnd.Next(0, 8), 6);
            bincode += sleeve;
            bincode += Convert.ToString(RandomGenerator.rnd.Next(0, 8), 6);
            bincode += skirt;
            bincode += Convert.ToString(RandomGenerator.rnd.Next(0, 8), 6);
            return bincode;
        }
        public DressImage ShowDress()
        {
            DressImage di = new DressImage();
            di.pictureBox1.BackgroundImage= Image.FromFile("Resources/body/"+body+".png");
            di.pictureBox2.BackgroundImage = Image.FromFile("Resources/sleeves/" + sleeve + ".png");
            di.pictureBox3.BackgroundImage = Image.FromFile("Resources/skirts/" + skirt + ".png");
            return di;
        }
    }
}
