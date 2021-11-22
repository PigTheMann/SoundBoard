using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundBoard
{
    public partial class Form1 : Form
    {
        SoundEffectProcessing processor = new SoundEffectProcessing();

        public Form1()
        {
            InitializeComponent();
            getButtonText();
            getVolumes();
        }

        public void getButtonText()
        {
            button1.Text = processor.GetButtonText(1);
            button2.Text = processor.GetButtonText(2);
            button3.Text = processor.GetButtonText(3);
            button11.Text = processor.GetButtonText(4);
            button13.Text = processor.GetButtonText(5);
            button15.Text = processor.GetButtonText(6);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // Saves any button changes
        {
            processor.WriteButtons();
        }


        //START PLAY
        private void button1_Click(object sender, EventArgs e) // play button 1 sound
        {
            try
            {
                processor.PlaySound(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        private void button2_Click(object sender, EventArgs e) // play button 2 sound
        {
            try
            {
                processor.PlaySound(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void button3_Click(object sender, EventArgs e) // play button 3 sound
        {
            try
            {
                processor.PlaySound(3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void button11_Click(object sender, EventArgs e) // play button 4 sound
        {
            try
            {
                processor.PlaySound(4);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void button13_Click(object sender, EventArgs e) // play button 5 sound
        {
            try
            {
                processor.PlaySound(5);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void button15_Click(object sender, EventArgs e) // play button 6 sound
        {
            try
            {
                processor.PlaySound(6);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        //END PLAY







        //START PAUSE
        private void button4_Click(object sender, EventArgs e)// Pause for Button 1
        {
            processor.PauseSound(1);
        }

        private void button7_Click(object sender, EventArgs e)// Pause for Button 2
        {
            processor.PauseSound(2);
        }

        private void button9_Click(object sender, EventArgs e)// Pause for Button 3
        {
            processor.PauseSound(3);
        }

        private void button17_Click(object sender, EventArgs e)// pause for button 4
        {
            processor.PauseSound(4);
        }

        private void button18_Click(object sender, EventArgs e)// pause for button 5
        {
            processor.PauseSound(5);
        }

        private void button14_Click(object sender, EventArgs e)// pause for button 6
        {
            processor.PauseSound(6);
        }

        //END PAUSE


        //START RESUME
        private void button5_Click(object sender, EventArgs e)// Resume for Button 1
        {
            processor.ResumeSound(1);
        }

        private void button6_Click(object sender, EventArgs e)// Resume for Button 2
        {
            processor.ResumeSound(2);
        }
                
        private void button8_Click(object sender, EventArgs e)// Resume for Button 3
        {
            processor.ResumeSound(3);
        }

        private void button19_Click(object sender, EventArgs e)// Resume for Button 4
        {
            processor.ResumeSound(4);
        }

        private void button16_Click(object sender, EventArgs e)// Resume for button 5
        {
            processor.ResumeSound(5);
        }

        private void button12_Click(object sender, EventArgs e)// Resume for button 6
        {
            processor.ResumeSound(6);
        }
        //END RESUME



        //CHANGE BUTTON START

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add(button1.Text);
            comboBox1.Items.Add(button2.Text);
            comboBox1.Items.Add(button3.Text);
            comboBox1.Items.Add(button11.Text);
            comboBox1.Items.Add(button13.Text);
            comboBox1.Items.Add(button15.Text);
        }

        private void button10_Click(object sender, EventArgs e)// Set changes to button
        {
            int id = 0;
            try
            {
                while (processor.Buttons[id].soundName != (string)comboBox1.SelectedItem)
                {
                    id++;
                }

                if (textBox1.Text != null || textBox1.Text != "" || textBox1.Text != " ")
                {
                    processor.Buttons[id].soundName = textBox1.Text;
                }
                else
                {
                    //soundName stays the same
                }
                if (textBox2.Text != null || textBox2.Text != "" || textBox2.Text != " ")
                {
                    processor.Buttons[id].soundFilePath = textBox2.Text;
                }
                else
                {
                    //filepath stays the same
                }
            }
            catch
            {
                textBox1.Text = "ERROR";

            }
            
            

            getButtonText();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                while (processor.Buttons[id].soundName != (string)comboBox1.SelectedItem)
                {
                    id++;
                }
                textBox2.Text = processor.Buttons[id].soundFilePath;
            }
            catch
            {
                textBox2.Text = "";
            }
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) // Change tab
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }

        //CHANGE BUTTON END

        //START VOLUME CONTROL

        public void getVolumes()
        {
            processor.SetVolume(1, numericUpDown1.Value);
            processor.SetVolume(2, numericUpDown2.Value);
            processor.SetVolume(3, numericUpDown3.Value);
            processor.SetVolume(4, numericUpDown6.Value);
            processor.SetVolume(5, numericUpDown5.Value);
            processor.SetVolume(6, numericUpDown4.Value);

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) // Volume Control for button 1
        {
            processor.SetVolume(1, numericUpDown1.Value);
            processor.VolumeChanged(1);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)// Volume Control for button 2
        {
            processor.SetVolume(2, numericUpDown2.Value);
            processor.VolumeChanged(2);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)// Volume Control for button 3
        {
            processor.SetVolume(3, numericUpDown3.Value);
            processor.VolumeChanged(3);
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)// Volume Control for Button 4
        {
            processor.SetVolume(4, numericUpDown6.Value);
            processor.VolumeChanged(4);
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)// Volume Control for Button 5
        {
            processor.SetVolume(5, numericUpDown5.Value);
            processor.VolumeChanged(5);
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)// Volume Control for Button 6
        {
            processor.SetVolume(6, numericUpDown4.Value);
            processor.VolumeChanged(6);
        }





        //END VOLUME CONTROL
        //START LOOP CONTROL
        private void checkBox1_CheckedChanged(object sender, EventArgs e) // Loop Button 1
        {
            if (checkBox1.Checked == true)
            {
                processor.LoopMe(1);
            }
            if (checkBox1.Checked == false)
            {
                processor.UnLoopMe(1);
            }
        }
        /*
* 
* */
    }
}
