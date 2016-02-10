using System;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Kalkulator
{
    public partial class Form1 : Form
    {
        char sign = 'x';
        double liczba1;
        double liczba2;
        bool wyczysc = false;

        public Form1()
        {
            InitializeComponent();
        }

       void btnLiczWynikClick(object sender, EventArgs e)
        {
            double wynik;
            wyczysc = true;
            liczba2 = double.Parse(textBox1.Text);
            switch (sign)
            {
                case '+':
                    wynik = liczba1 + liczba2;
                    sign = 'x';
                    textBox1.Text = wynik.ToString();
                    break;
                case '-':
                    wynik = liczba1 - liczba2;
                    sign = 'x';
                    textBox1.Text = wynik.ToString();
                    break;
                case '/':
                    if (liczba2 == 0)
                    {
                        MessageBox.Show("Blad! Dzielenie przez 0!");
                        return;
                    }
                    wynik = liczba1 / liczba2;
                    sign = 'x';
                    textBox1.Text = wynik.ToString();
                    break;
                case '*':
                    wynik = liczba1 * liczba2;
                    sign = 'x';
                    textBox1.Text = wynik.ToString();
                    break;
            }

        }


        void Btn0Click(object sender, EventArgs e)
        {//procedura dla wszystkich przyciskow 0..9 i ","
            if (wyczysc == true)
            {
                textBox1.Clear();
                wyczysc = false;
            }
           
            String s = ((Button)sender).Text;
            textBox1.AppendText(s);
        }


        void BtnPlusMinusClick(object sender, EventArgs e)
        {//procedura dla przycisku "+/-"
            if (textBox1.Text.Length < 1)
                return;

            if (textBox1.Text[0] != '-')
                textBox1.Text = textBox1.Text.Insert(0, "-");
            else
                textBox1.Text = textBox1.Text.Remove(0, 1);
        }

        void BtnDzielenieClick(object sender, EventArgs e)
        { //procedura dla wszystkich przyciskow oznaczajacych operacje matematyczne
            if (sign != 'x')
                btnLiczWynikClick(null, null);
            wyczysc = true;
            sign = (((Button)sender).Text)[0];
            liczba1 = double.Parse(textBox1.Text);
        }

        void BtnBackspaceClick(object sender, EventArgs e)
        {
            String s = textBox1.Text;
            if (s.Length > 0)
                textBox1.Text = s.Remove(s.Length - 1);
        }

        void button19_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = Math.Sqrt(double.Parse(textBox1.Text)).ToString();

            }
        }

        void button18_Click(object sender, EventArgs e)
        {           
          textBox1.Clear();
        }

        
    }
}