using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Amőba
{
    public partial class Form1 : Form
    {
        private string sajat;
        private string ellenfel;
        private string felhasznalonev;
        private BackgroundWorker MessageReceiver = new BackgroundWorker();
        public Form1()
        {
            InitializeComponent();
        }

        TcpClient clientSocket;
        NetworkStream serverStream = default(NetworkStream);
        string readdata = null;
        private void getMessage()
        {
            string returndata;
            while (true)
            {
                serverStream = clientSocket.GetStream();
                var buffersize = clientSocket.ReceiveBufferSize;
                byte[] instream = new byte[buffersize];
                serverStream.Read(instream, 0, buffersize);
                returndata = System.Text.Encoding.ASCII.GetString(instream);
                readdata = returndata;
                msg();
            }
        }
        private void msg()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(msg));
            }
            else
            {
                listBox1.Items.Add(readdata);

            }
        }
        private void Uzenetfogadas(object sender, DoWorkEventArgs e)
        {
            if (jatekagoritmus())
            {
                return;
            }
        }

        private void vege()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
        }
        private bool jatekagoritmus()
        {
            //vizszintes
            if (button1.Text == button2.Text && button2.Text == button3.Text && button3.Text != "")
            {
                if (button3.Text == sajat)
                {
                    MessageBox.Show(sajat + " Vége nyertél cső");
                }
                else
                {
                    MessageBox.Show(ellenfel + " Vége nyertél cső");
                }
                vege();
                return true;
            }
            else if (button4.Text == button5.Text && button5.Text == button6.Text && button6.Text != "")
            {
                if (button6.Text == sajat)
                {
                    MessageBox.Show(sajat + " Vége nyertél cső");
                }
                else
                {
                    MessageBox.Show(ellenfel + " Vége nyertél cső");
                }
                vege();
                return true;
            }
            else if (button7.Text == button8.Text && button8.Text == button9.Text && button9.Text != "")
            {
                if (button9.Text == sajat)
                {
                    MessageBox.Show(sajat + " Vége nyertél cső");
                }
                else
                {
                    MessageBox.Show(ellenfel + " Vége nyertél cső");
                }
                vege();
                return true;
            }
            //fuggoleges
            else if (button1.Text == button4.Text && button4.Text == button7.Text && button7.Text != "")
            {
                if (button7.Text == sajat)
                {
                    MessageBox.Show(sajat + " Vége nyertél cső");
                }
                else
                {
                    MessageBox.Show(ellenfel + " Vége nyertél cső");
                }
                vege();
                return true;
            }
            else if (button2.Text == button5.Text && button5.Text == button8.Text && button8.Text != "")
            {
                if (button8.Text == sajat)
                {
                    MessageBox.Show(sajat + " Vége nyertél cső");
                }
                else
                {
                    MessageBox.Show(ellenfel + " Vége nyertél cső");
                }
                vege();
                return true;
            }
            else if (button3.Text == button6.Text && button6.Text == button9.Text && button9.Text != "")
            {
                if (button9.Text == sajat)
                {
                    MessageBox.Show(sajat + " Vége nyertél cső");
                }
                else
                {
                    MessageBox.Show(ellenfel + " Vége nyertél cső");
                }
                vege();
                return true;
            }
            //átlós
            else if (button1.Text == button5.Text && button5.Text == button9.Text && button9.Text != "")
            {
                if (button9.Text == sajat)
                {
                    MessageBox.Show(sajat + " Vége nyertél cső");
                }
                else
                {
                    MessageBox.Show(ellenfel + " Vége nyertél cső");
                }
                vege();
                return true;
            }
            else if (button3.Text == button5.Text && button5.Text == button7.Text && button7.Text != "")
            {
                if (button7.Text == sajat)
                {
                    MessageBox.Show(sajat + " Vége nyertél cső");
                }
                else
                {
                    MessageBox.Show(ellenfel + " Vége nyertél cső");
                }
                vege();
                return true;
            }
            //döntetlen
            else if (button1.Text != "" && button2.Text != "" && button3.Text != "" && button4.Text != "" && button5.Text != "" && button6.Text != "" && button7.Text != "" && button8.Text != "" && button9.Text != "")
            {
                vege();
                MessageBox.Show("Döntetlen");
                return true;
            }
            return false;
        }
        public void inditas()
        {
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;

        }
        //public void jatekosdonto()
        //{
        //    if (jatekos == "X")
        //    {
        //        jatekos = "O";
        //    }
        //    else
        //    {
        //        jatekos = "X";
        //    }
        //}
        private void button10_Click(object sender, EventArgs e)
        {
            inditas();
            MessageBox.Show("Játék elindult");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            byte[] num = { byte.Parse(button.Tag as string) };
            //jatekosdonto();
            button.Text = sajat;
            jatekagoritmus();
            //button.Enabled = false;
            clientSocket.Client.Send(num);

            clientSocket.Client.Receive(num);
            if (num[0] == 1)
            {
                button1.Text = ellenfel.ToString();
            }
            if (num[0] == 2)
            {
                button2.Text = ellenfel.ToString();
            }
            if (num[0] == 3)
            {
                button3.Text = ellenfel.ToString();
            }
            if (num[0] == 4)
            {
                button4.Text = ellenfel.ToString();
            }
            if (num[0] == 5)
            {
                button5.Text = ellenfel.ToString();
            }
            if (num[0] == 6)
            {
                button6.Text = ellenfel.ToString();
            }
            if (num[0] == 7)
            {
                button7.Text = ellenfel.ToString();
            }
            if (num[0] == 8)
            {
                button8.Text = ellenfel.ToString();
            }
            if(num[0] == 9)
            {
                button9.Text = ellenfel.ToString();
            }
            //Uzenetfogadas.RunWorkerAsync();


        }

        void InitServerStream()
        {
            serverStream = clientSocket.GetStream();
            Thread ctThread = new Thread(getMessage);
            ctThread.Start();
            textBox5.Enabled = true;
        }
        private void button11_Click(object sender, EventArgs e)
        {

            clientSocket = new TcpClient();
            clientSocket.Connect(textBox1.Text, int.Parse(textBox2.Text));
            sajat = "O";
            ellenfel = "X";
            InitServerStream();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            byte[] outstream = Encoding.ASCII.GetBytes("\n" + felhasznalonev + ":" + textBox4.Text);
            listBox1.Items.Add("\n" + felhasznalonev + ":" + textBox4.Text);
            serverStream.Write(outstream, 0, outstream.Length);
            serverStream.Flush();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            TcpListener host = new TcpListener(new IPEndPoint(IPAddress.Any, int.Parse(textBox2.Text)));
            host.Start();
            sajat = "X";
            ellenfel = "O";
            clientSocket = host.AcceptTcpClient();
            InitServerStream();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button11.Enabled = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            felhasznalonev = textBox5.Text;
            button13.Enabled = true;
            listBox1.Enabled = true;
            textBox4.Enabled = true;
        }
    }
}
