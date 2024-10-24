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

            for (int idx = 0; idx < bna.CantidadCuentas; idx++)
            {
                Cuenta c = bna[idx];
                textBox1.Text += $"{c.Numero,10}|{c.Titular.Nombre,20}|{c.Saldo,20:f2}" + Environment.NewLine;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;


                FileStream fs = null;
                StreamReader sr = null;

                try
                {
                    fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
                    sr = new StreamReader(fs);

                    //cuenta;nombre;dni;saldo
                    sr.ReadLine();

                    while (sr.EndOfStream == false)
                    {
                        string linea = sr.ReadLine();

                        #region parsing
                        string[] campos = linea.Split(';');

                        int numero = Convert.ToInt32(campos[0].Trim());
                        string nombre = campos[1].Trim();
                        int dni = Convert.ToInt32(campos[2].Trim());
                        double saldo= Convert.ToDouble(campos[3].Trim());
                        #endregion

                        Cuenta cuenta=bna.AgregarCuenta(numero, dni, nombre);
                        cuenta.Saldo = saldo;   

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message+"|"+ex.StackTrace.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                finally
                {
                    if (sr != null) sr.Close();
                    if (fs != null) fs.Close();

                }

                   button1.PerformClick();

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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileStream fs = null;

            try
            {
                fs = new FileStream("banco.dat", FileMode.OpenOrCreate, FileAccess.Write);

                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(fs,bna);

            }
            finally
            {
                if (fs != null) fs.Close();
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                fs = new FileStream("banco.dat", FileMode.OpenOrCreate, FileAccess.Read);

                BinaryFormatter bf = new BinaryFormatter();

                bna = bf.Deserialize(fs) as Banco;

            }
            catch { }
            finally
            {
                if (fs != null) fs.Close();
            }


            if (bna == null)
            {
                bna = new Banco();
                bna.AgregarCuenta(34234, 23432432, "Martina");
            }

            button1.PerformClick();
        }
    }
}
