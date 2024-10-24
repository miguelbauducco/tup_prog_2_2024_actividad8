using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        Banco bna = new Banco();

        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {


            textBox1.Text = $"{"Número Cuenta",10}|{"Nombre",20}|{"Saldo",20}" + Environment.NewLine;

            textBox1.Text += "".PadRight(59, '-') + Environment.NewLine;

            textBox1.Text += $"{234324324,10}|{"Pedro",20}|{234.2,20}" + Environment.NewLine;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string nombre = openFileDialog1.FileName;


                FileStream fs = null;
                StreamReader sr = null;

                try
                {
                    fs = new FileStream(nombre, FileMode.OpenOrCreate, FileAccess.Read);
                    sr = new StreamReader(fs);

                    while (sr.EndOfStream == false)
                    {
                        string linea = sr.ReadLine();
                        textBox1.Text += linea;
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    if (sr != null) sr.Close();
                    if (fs != null) fs.Close();

                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;

                FileStream fs = null;
                StreamWriter sw = null;

                try
                {
                    fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                    sw = new StreamWriter(fs);

                    for (int idx = 0; idx < bna.CantidadCuentas; idx++)
                    {
                        Cuenta cuenta = bna[idx];

                        string linea = $"{cuenta.Numero};{cuenta.Titular.Nombre};{cuenta.Titular.Dni};{cuenta.Saldo:f2}";

                        sw.WriteLine(linea);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "|" + ex.StackTrace.ToString());
                }
                finally
                {
                    if (sw != null) sw.Close();
                    if (fs != null) fs.Close();
                }


            }
        }
    }
}
