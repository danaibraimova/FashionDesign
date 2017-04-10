using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FashionDesign
{
    public partial class Form1 : Form
    {
        GeneticAlgorithm ga;
        public Form1()
        {
            InitializeComponent();
            ga = new GeneticAlgorithm();
            ga.Initializing(this);
        }
        int generationnum = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Control d in this.Controls)
            {
                if (d.GetType() == typeof(DressImage))
                {
                    ga.dresspopulation[i].fitness=Int32.Parse((d as DressImage).textBox1.Text);
                    i++;

                }
            }
            if (generationnum < 10)
            {
                ga.GeneratePopulation(this);
            }
            generationnum++;
            foreach (Control d in this.Controls)
            {
                if (d.GetType() == typeof(DressImage))
                {
                    (d as DressImage).textBox1.Text = "";

                }
            }
        }

    }
}
