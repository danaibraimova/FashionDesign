using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace FashionDesign
{
    public class GeneticAlgorithm
    {
        public List<Dress> dresspopulation = new List<Dress>();
        public List<DressImage> dressimages = new List<DressImage>();
        public void Initializing(Form form)
        {
            for (int i = 0; i < 8; i++)
            {
                Dress dress = new Dress();
                DressImage di = dress.CreateDressControl();
                dressimages.Add(di);
                dresspopulation.Add(dress);
            }
            ShowDressonForm(dressimages, form);
        }
        public void ShowDressonForm(List<DressImage> dressimages, Form form)
        {
            foreach (Control d in form.Controls)
            {
                if (d.GetType() == typeof(DressImage))
                {
                    form.Controls.Remove(d);
                }
            }
            int x = 2;
            int y = 2;
            for (int i = 0; i < 8; i++)
            {
                dressimages[i].Location = new Point(x, y);
                x += 250;
                if (x >= 1000)
                {
                    x = 2;
                    y += 300;
                }
                form.Controls.Add(dressimages[i]);
            }

        }
        public void GeneratePopulation(Form form)
        {
            int bl;
            dresspopulation.Sort();
            List<string> children = new List<string>();
            string child;
            for (int i = 1; i < 5; i++)
            {
                bl = RandomGenerator.rnd.Next(0, 1);
                if (bl == 0)
                {
                    child = Mutate(Crossover(dresspopulation[0].bincode, dresspopulation[i].bincode));
                    while (!CheckIfDressExists(child))
                    {
                        child= Mutate(Crossover(dresspopulation[0].bincode, dresspopulation[i].bincode));
                    }
                    children.Add(child);
                }
                else
                {
                    child = Mutate(Crossover(dresspopulation[i].bincode, dresspopulation[0].bincode));
                    while (!CheckIfDressExists(child))
                    {
                        child = Mutate(Crossover(dresspopulation[i].bincode, dresspopulation[0].bincode));
                    }
                    children.Add(child);
                }
            }
            for (int i = 2; i < 4; i++)
            {
                bl = RandomGenerator.rnd.Next(0, 1);
                if (bl == 0)
                {
                    child = Mutate(Crossover(dresspopulation[1].bincode, dresspopulation[i].bincode));
                    while (!CheckIfDressExists(child))
                    {
                        child = Mutate(Crossover(dresspopulation[1].bincode, dresspopulation[i].bincode));
                    }
                    children.Add(child);
                }
                else
                {
                    child = Mutate(Crossover(dresspopulation[i].bincode, dresspopulation[1].bincode));
                    while (!CheckIfDressExists(child))
                    {
                        child = Mutate(Crossover(dresspopulation[i].bincode, dresspopulation[1].bincode));
                    }
                    children.Add(child);
                }
            }
            for (int i = 3; i < 5; i++)
            {
                bl = RandomGenerator.rnd.Next(0, 1);
                if (bl == 0)
                {
                    child = Mutate(Crossover(dresspopulation[2].bincode, dresspopulation[i].bincode));
                    while (!CheckIfDressExists(child))
                    {
                        child = Mutate(Crossover(dresspopulation[2].bincode, dresspopulation[i].bincode));
                    }
                    children.Add(child);
                }
                else
                {
                    child = Mutate(Crossover(dresspopulation[i].bincode, dresspopulation[2].bincode));
                    while (!CheckIfDressExists(child))
                    {
                        child = Mutate(Crossover(dresspopulation[i].bincode, dresspopulation[2].bincode));
                    }
                    children.Add(child);
                }
            }
            dresspopulation.Clear();
            dressimages.Clear();
            for (int i = 0; i < 8; i++)
            {
                dresspopulation.Add(ConvertStringToDress(children[i]));
                DressImage dress = ConvertStringToDress(children[i]).CreateDressControl();
                dressimages.Add(dress);
            }
            ShowDressonForm(dressimages, form);
        }
        public bool CheckIfDressExists(string child)
        {
            string body = "", sleeve = "", skirt = "", skirtcol = "", sleevecol = "", bodycol = "";
            for (int i = 0; i < 23; i++)
            {
                if (i < 6)
                {
                    body += child[i];
                }
                else if (i >= 9 && i < 13)
                {
                    sleeve += child[i];
                }
                else if (i >= 17 && i < 21)
                {
                    skirt += child[i];
                }
            }
            if (Convert.ToInt32(body, 2) > 34 || Convert.ToInt32(sleeve, 2) > 8 || Convert.ToInt32(skirt, 2) > 8)
            {
                return false;
            }
            return true;
        }
        public Dress ConvertStringToDress(string child)
        {
            string body="", sleeve="", skirt="",skirtcol="",sleevecol="",bodycol="";
            for(int i = 0; i < 23; i++)
            {
                if (i < 6)
                {
                    body += child[i];
                }
                else if(i>=6 && i < 9)
                {
                    bodycol += child[i];
                }
                else if(i>=9 && i < 13)
                {
                    sleeve += child[i];
                }
                else if(i>=13 && i < 17)
                {
                    sleevecol += child[i];
                }
                else if(i>=17 && i < 21)
                {
                    skirt += child[i];
                }
                else if(i>=21 && i < 23)
                {
                    skirtcol += child[i];
                }
            }
            Dress dress = new Dress(body, bodycol, sleeve, sleevecol, skirt, skirtcol,child);
            return dress;
        }
        public string Crossover(string p1,string p2)
        {
            string child = "";
            int separator=RandomGenerator.rnd.Next(0, 22);
            for(int i = 0; i < separator; i++)
            {
                child += p1[i];
            }
            for(int i = separator; i < 23; i++)
            {
                child += p2[i];
            }
            return child;
        }
        public string Mutate(string child)
        {
            StringBuilder sb = new StringBuilder(child);
            int mutationind= RandomGenerator.rnd.Next(0, 22);
            if (child[mutationind] == '0')
            {
                sb[mutationind] = '1';
            }
            else
            {
                sb[mutationind] = '0';
            }
            child = sb.ToString();
            return child;
        }
    }
}
