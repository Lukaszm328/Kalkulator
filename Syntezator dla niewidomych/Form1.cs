using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Syntezator_dla_niewidomych
{
    public partial class Form1 : Form
    {

        // Initialize a new instance of the SpeechSynthesizer.
        SpeechSynthesizer synth = new SpeechSynthesizer();
        double number1, number2, result;
        bool plus = false, minus = false, dziel = false, mnoz = false;
        public Form1()
        {
            InitializeComponent();
            // Configure the audio output. 
            synth.SetOutputToDefaultAudioDevice();
            // Default speed voice 
            synth.Rate = -3;
            // Default volume voice
            synth.Volume = 100;
        }

        public void repeat()
        {
            if (textBox1.Text == "")
            {
                speak("Brak danych.");
            }
            else
            {
                speak(textBox1.Text);
            } 
        }

        public void speak_calc(string a)
        {
            speak(a);
            textBox1.Text = textBox1.Text + a;
        }

        public void speak(string b)
        {
            label9.BackColor = Color.Red;
            synth.Speak(b);
            label9.BackColor = Color.Empty;
        }

        public void speed_voice_up()
        {
            if ( synth.Rate == 10 )
            {
                speak("Tempo najszybsze.");
            }
            else
            {
                synth.Rate = synth.Rate + 1;
                speak("Prędkość mówienia " + synth.Rate);
                string tempo = synth.Rate.ToString();
                label13.Text = tempo;
            }
        }

        public void speed_voice_down()
        {
            if (synth.Rate == -10)
            {
                speak("Tempo najniższe.");
            }
            else
            {
                synth.Rate = synth.Rate - 1;
                speak("Prędkość mówienia " + synth.Rate);
                string tempo = synth.Rate.ToString();
                label13.Text = tempo;
            }
        }

        public void volume_voice_up()
        {
            if (synth.Volume == 100)
            {
                speak("Głośność maksymalna.");
            }
            else
            {
                synth.Volume = synth.Volume + 10;
                speak("Podgłaszam głos");
                int g = synth.Volume;
                label15.Text = g.ToString();
            }
        }
        public void volume_voice_down()
        {
            if (synth.Volume == 10)
            {
                speak("Głośność minimalna.");
            }
            else
            {
                synth.Volume = synth.Volume - 10;
                speak("ściszam głos");
                int g = synth.Volume;
                label15.Text = g.ToString();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.NumPad1)
            {
                speak_calc("1");
            }

            if (e.KeyCode == Keys.NumPad2)
            {
                speak_calc("2");
            }
            if (e.KeyCode == Keys.NumPad3)
            {
                speak_calc("3");
            }
            if (e.KeyCode == Keys.NumPad4)
            {
                speak_calc("4");
            }
            if (e.KeyCode == Keys.NumPad5)
            {
                speak_calc("5");
            }
            if (e.KeyCode == Keys.NumPad6)
            {
                speak_calc("6");
            }
            if (e.KeyCode == Keys.NumPad7)
            {
                speak_calc("7");
            }
            if (e.KeyCode == Keys.NumPad8)
            {
                speak_calc("8");
            }
            if (e.KeyCode == Keys.NumPad9)
            {
                speak_calc("9");
            }
            if (e.KeyCode == Keys.NumPad0)
            {
                speak_calc("0");
            }

            if (e.KeyCode == Keys.ShiftKey)
            {
                repeat();
            }

            if (e.KeyCode == Keys.Back)
            {
                if (textBox1.Text == "")
                {
                    speak("Brak liczby do usunięcia.");
                }
                else
                {
                    // Deleted last number from textBox1
                    speak("Usówam liczbę");
                    textBox1.Text = textBox1.Text.Remove((textBox1.Text.Length - 1), 1);
                }

            }

            if (e.KeyCode == Keys.Add)
            {
                if (textBox1.Text == "")
                {
                    speak("Najpierew wprowadź dane do obliczeń z klawiatury NumPad");
                }
                else
                {
                    speak("Dodać");
                    number1 = double.Parse(textBox1.Text);
                    textBox1.Text = "";
                    plus = true;
                    label8.Text = "+";
                }
            }

            if (e.KeyCode == Keys.Subtract)
            {
                if (textBox1.Text == "")
                {
                    speak("Najpierew wprowadź dane do obliczeń z klawiatury NumPad");
                }
                else
                {
                    speak("odjąć");
                    number1 = double.Parse(textBox1.Text);
                    textBox1.Text = "";
                    minus = true;
                    label8.Text = "-";
                }
            }

            if (e.KeyCode == Keys.Multiply)
            {
                if (textBox1.Text == "")
                {
                    speak("Najpierew wprowadź dane do obliczeń z klawiatury NumPad");
                }
                else
                {
                    speak("pomnożyć");
                    number1 = double.Parse(textBox1.Text);
                    textBox1.Text = "";
                    mnoz = true;
                    label8.Text = "*";
                }
            }

            if (e.KeyCode == Keys.Divide)
            {
                if (textBox1.Text == "")
                {
                    speak("Najpierew wprowadź dane do obliczeń z klawiatury NumPad");
                }
                else
                {
                    speak("podzielić");
                    number1 = double.Parse(textBox1.Text);
                    textBox1.Text = "";
                    dziel = true;
                    label8.Text = "/";
                }
            }

            if (e.KeyCode == Keys.ControlKey)
            {
                speak("Pomoc");
            }

            if (e.KeyCode == Keys.Decimal)
            {
                speak("Przecinek");
                textBox1.Text = textBox1.Text + ",";
            }
            if (e.KeyCode == Keys.Escape)
            {
                speak("Zamykam program");
                Close();
            }
            if (e.KeyCode == Keys.Home)
            {
                speak("Pomoc");
            }
            if (e.KeyCode == Keys.Up)
            {
                volume_voice_up();
            }
            if (e.KeyCode == Keys.Down)
            {
                volume_voice_down();
            }
            if (e.KeyCode == Keys.Left)
            {
                speed_voice_down();
            }
            if (e.KeyCode == Keys.Right)
            {
                speed_voice_up();
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (plus == true)
                {
                    if (textBox1.Text == "")
                    {
                        speak("Wprowadź najpierw liczbę do dodania");
                    }
                    else
                    {
                        number2 = double.Parse(textBox1.Text);
                        result = number1 + number2;

                        plus = false;
                    }
                }

                if (minus == true)
                {
                    if (textBox1.Text == "")
                    {
                        speak("Wprowadź najpierw liczbę do odjęcia");
                    }
                    else
                    {
                        number2 =  double.Parse(textBox1.Text);
                        result = number1 - number2;

                        minus = false;
                    }
                }
                if (dziel == true)
                {
                        if (textBox1.Text == "")
                        {
                            speak("Wprowadź najpierw liczbę do dzielenia");
                        }
                        else if (number2 == 0)
                    {
                        speak("Pamiętaj cholero nie dziel przez 0 !");
                    }
                        else
                        {
                            number2 = double.Parse(textBox1.Text);
                            result = number1 / number2;

                            dziel = false;
                        }
                }

                if (mnoz == true)
                {
                    if (textBox1.Text == "")
                    {
                        speak("Wprowadź najpierw liczbę do pomnozenia");
                    }
                    else
                    {
                        number2 = double.Parse(textBox1.Text);
                        result = number1 * number2;

                        mnoz = false;
                    }
                }

                string results = result.ToString();
                speak("Wynik działania" + number1 + label8.Text + number2 + " to " + results);
                label6.Text = results;
                textBox1.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            speak("Witaj w programie kalkulator, aby odsłuchać pomoc naciśnij prawy kontrol");
        }
        }
    }

