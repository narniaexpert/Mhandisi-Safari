﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading; //Used for the time dealy

namespace VideoControl
{
    public enum CameraModes
    {
        Gunner=0,
        Driver=1
    }
    public partial class MainWindow : Form
    {
        private const string VERSION = "1.0";
        private string IPAddress = "http://192.168.1.125:81";
        private Settings SettingsWindow;
        private CameraModes CameraMode;
        private Translation Translator;
        public MainWindow()
        {
            InitializeComponent();

            Translator = new Translation(LANGUAGES.English);//English will be the default language
            UpdateInterface();//Update the interface for the new language

            CameraMode = CameraModes.Gunner;//Default as gunner because this mode is critical to the gunner, but optional for the driver.

            BackgroundURLBox.Visible = false;//This url box is only for message passing and should not be seen by the user.
            //Turns LED off by default
            BackgroundURLBox.Url = new System.Uri(IPAddress + "/set_misc.cgi?next_url=ptz.htm&loginuse=admin&loginpas=&ptz_patrol_rate=10&ptz_patrol_up_rate=10&ptz_patrol_down_rate=10&ptz_patrol_left_rate=10&ptz_patrol_right_rate=10&ptz_dispreset=1&ptz_preset=3&led_mode=0&ptz_run_times=2");
            
        }
        private void UpdateInterface() //Updates the interface in the new language
        {
            // 
            // UpButton
            // 
            this.UpButton.Text = Translator.GetWord(WORDS.Up);
            // 
            // DownButton
            // 
            this.DownButton.Text = Translator.GetWord(WORDS.Down);
            // 
            // LeftButton
            // 
            this.LeftButton.Text = Translator.GetWord(WORDS.Left);
            // 
            // RightButton
            // 
            this.RightButton.Text = Translator.GetWord(WORDS.Right);
            // 
            // FireButton
            // 
            this.FireButton.Text = Translator.GetWord(WORDS.Fire);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Text = Translator.GetWord(WORDS.File);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Text = Translator.GetWord(WORDS.About);
            // 
            // languagesToolStripMenuItem
            // 
            this.languagesToolStripMenuItem.Text = Translator.GetWord(WORDS.Languages);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Text = Translator.GetWord(WORDS.English);
            // 
            // 中文ToolStripMenuItem
            // 
            this.中文ToolStripMenuItem.Text = Translator.GetWord(WORDS.Chinese);
            // 
            // españolToolStripMenuItem
            // 
            this.españolToolStripMenuItem.Text = Translator.GetWord(WORDS.Spanish);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Text = Translator.GetWord(WORDS.Settings);
            // 
            // helpToolStripMenuItem
            //
            this.helpToolStripMenuItem.Text = Translator.GetWord(WORDS.Help);
            // 
            // viewHelpFileToolStripMenuItem
            // 
            this.viewHelpFileToolStripMenuItem.Text = Translator.GetWord(WORDS.OpenHelpFile);
            // 
            // viewHelpWebsiteToolStripMenuItem
            // 
            this.viewHelpWebsiteToolStripMenuItem.Text = Translator.GetWord(WORDS.ViewHelpWebsite);
            // 
            // MainWindow
            // 
            this.Text = Translator.GetWord(WORDS.MhandisiSafari);
        }

        public void setIPAddress(string address)
        {
            address=address.ToLower();
            if (address.StartsWith("http://"))
            {
                address=address.Substring(7);//Removes the first seven characters from "http://" in the string
                string [] splitAddress;
                splitAddress=address.Split(':');
                if (splitAddress.Count() == 2)//The count will be two if the address includes a port number
                {
                    splitAddress = address.Split('.');
                    if (splitAddress.Count() == 4)//The count will be four if there address includes four groups of numbers
                    {
                        address=address.TrimEnd('/');//remove any trailing slash charachters that could cause program errors
                        IPAddress = "http://" + address;//Replacing the http:// that was taken out
                        VideoStream.Url = new System.Uri(IPAddress + "/mobile.htm");
                    }
                    else
                    {
                        MessageBox.Show(Translator.GetWord(WORDS.AddressDoesNotHaveFourNumberGroups), Translator.GetWord(WORDS.Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(Translator.GetWord(WORDS.AddressDoesNotHaveAPortNumber), Translator.GetWord(WORDS.Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(Translator.GetWord(WORDS.AddressDoesNotStartWithHTTP), Translator.GetWord(WORDS.Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string getIPAddress()
        {
            return IPAddress;
        }

        public void setPlayerType(CameraModes PlayerType)
        {
            if (PlayerType == CameraModes.Gunner)
            {
                FireButton.Visible = true;
                CameraMode = PlayerType;
            }
            if (PlayerType == CameraModes.Driver)
            {
                FireButton.Visible = false;
                CameraMode = PlayerType;
            }
        }

        public CameraModes getPlayerType()
        {
            return CameraMode;
        }

        private void UpButton_MouseDown(object sender, MouseEventArgs e)
        {
            BackgroundURLBox.Url=new System.Uri(IPAddress+"/decoder_control.cgi?loginuse=admin&loginpas=&command=0&onestep=0&14021817903240.3322663000576133&_=1402181790325");
        }

        private void UpButton_MouseUp(object sender, MouseEventArgs e)
        {
            BackgroundURLBox.Url = new System.Uri(IPAddress + "/decoder_control.cgi?loginuse=admin&loginpas=&command=1&onestep=0&14021817903240.3322663000576133&_=1402181790325");
        }

        private void DownButton_MouseDown(object sender, MouseEventArgs e)
        {
            BackgroundURLBox.Url = new System.Uri(IPAddress + "/decoder_control.cgi?loginuse=admin&loginpas=&command=2&onestep=0&14021817903240.3322663000576133&_=1402181790325");

        }

        private void DownButton_MouseUp(object sender, MouseEventArgs e)
        {
            BackgroundURLBox.Url = new System.Uri(IPAddress + "/decoder_control.cgi?loginuse=admin&loginpas=&command=3&onestep=0&14021817903240.3322663000576133&_=1402181790325");

        }

        private void LeftButton_MouseDown(object sender, MouseEventArgs e)
        {
            BackgroundURLBox.Url = new System.Uri(IPAddress + "/decoder_control.cgi?loginuse=admin&loginpas=&command=4&onestep=0&14021817903240.3322663000576133&_=1402181790325");

        }

        private void LeftButton_MouseUp(object sender, MouseEventArgs e)
        {
            BackgroundURLBox.Url = new System.Uri(IPAddress + "/decoder_control.cgi?loginuse=admin&loginpas=&command=5&onestep=0&14021817903240.3322663000576133&_=1402181790325");

        }

        private void RightButton_MouseDown(object sender, MouseEventArgs e)
        {
            BackgroundURLBox.Url = new System.Uri(IPAddress + "/decoder_control.cgi?loginuse=admin&loginpas=&command=6&onestep=0&14021817903240.3322663000576133&_=1402181790325");

        }

        private void RightButton_MouseUp(object sender, MouseEventArgs e)
        {
            BackgroundURLBox.Url = new System.Uri(IPAddress + "/decoder_control.cgi?loginuse=admin&loginpas=&command=7&onestep=0&14021817903240.3322663000576133&_=1402181790325");

        }


        private void FireButton_MouseDown(object sender, MouseEventArgs e)
        {
            //Turn light on
            BackgroundURLBox.Url = new System.Uri(IPAddress + "/set_misc.cgi?next_url=ptz.htm&loginuse=admin&loginpas=&ptz_patrol_rate=10&ptz_patrol_up_rate=10&ptz_patrol_down_rate=10&ptz_patrol_left_rate=10&ptz_patrol_right_rate=10&ptz_dispreset=1&ptz_preset=3&led_mode=1&ptz_run_times=2");
            
        }

        private void FireButton_MouseUp(object sender, MouseEventArgs e)
        {
            //Wait to ensure there was enough time for the light to turn on for a minimum of 0.25 seconds
            Thread.Sleep(900);
            //The led flashes at a rate of 77 cycles per minute which represents 1.28333Hz or 1284ms wavelength
            //This means that the LED will be on for 671.6ms per cycle. To garuntee that the light is on for a minimum of 250ms, a 900ms delay is needed.
            //Turn light off
            BackgroundURLBox.Url = new System.Uri(IPAddress + "/set_misc.cgi?next_url=ptz.htm&loginuse=admin&loginpas=&ptz_patrol_rate=10&ptz_patrol_up_rate=10&ptz_patrol_down_rate=10&ptz_patrol_left_rate=10&ptz_patrol_right_rate=10&ptz_dispreset=1&ptz_preset=3&led_mode=0&ptz_run_times=2");
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsWindow = new Settings(this, Translator.GetLanguage());//Passing a reference to this form so that the settings window can communicate back
            SettingsWindow.Show(); //Open window
            SettingsWindow.BringToFront();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Translator.GetWord(WORDS.MhandisiSafariVideoControlPanel)+"\n"+Translator.GetWord(WORDS.Version) + VERSION + "\n\n"+Translator.GetWord(WORDS.CopyrightInfo), Translator.GetWord(WORDS.About), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Translator.SetLanguage(LANGUAGES.English);
            UpdateInterface();
            if (SettingsWindow.Visible == true)
            {
                SettingsWindow.UpdateInterface(LANGUAGES.English);
            }
        }

        private void 中文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Translator.SetLanguage(LANGUAGES.Chinese);
            UpdateInterface();
            if (SettingsWindow.Visible == true)
            {
                SettingsWindow.UpdateInterface(LANGUAGES.Chinese);
            }
        }

        private void españolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Translator.SetLanguage(LANGUAGES.Spanish);
            UpdateInterface();
            if (SettingsWindow.Visible == true)
            {
                SettingsWindow.UpdateInterface(LANGUAGES.Spanish);
            }
        }
    }
}
