using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VideoControl
{
    public partial class Settings : Form
    {
        private MainWindow callingForm;
        private Translation Translator;
        public Settings(MainWindow creator, LANGUAGES DefaultLanguage)
        {
            InitializeComponent();
            callingForm = creator;

            IPAddressTextBox.Text = creator.getIPAddress(); //Fill the form with the current IP Address as a default value
            PlayerTypeComboBox.SelectedIndex = (int)creator.getPlayerType(); //0=Gunner

            Translator = new Translation(DefaultLanguage);
            UpdateInterface();
        }

        public void UpdateInterface(LANGUAGES NewLanguage)//overloaded version to be called by forms that don't have access to the private translator object
        {
            Translator.SetLanguage(NewLanguage);
            UpdateInterface();
        }

        private void UpdateInterface()
        {
            // 
            // IPAddressLabel
            // 
            this.IPAddressLabel.Text = Translator.GetWord(WORDS.IPAddress);
            // 
            // PlayerTypeLabel
            // 
            this.PlayerTypeLabel.Text = Translator.GetWord(WORDS.PlayerType);
            // 
            // PlayerTypeComboBox
            // 
            int selection= this.PlayerTypeComboBox.SelectedIndex;
            this.PlayerTypeComboBox.Items.Clear();//Clear existing items to replace them with the new language items
            this.PlayerTypeComboBox.Items.AddRange(new object[] {
            Translator.GetWord(WORDS.Gunner),
            Translator.GetWord(WORDS.Driver)});
            this.PlayerTypeComboBox.SelectedIndex = selection;
            // 
            // SaveSettingsButton
            // 
            this.SaveSettingsButton.Text = Translator.GetWord(WORDS.SaveSettings);
            // 
            // Settings
            // 
            this.Text = Translator.GetWord(WORDS.Settings);
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            callingForm.setIPAddress(this.IPAddressTextBox.Text);
            if (PlayerTypeComboBox.SelectedIndex == 0)
            {
                callingForm.setPlayerType(CameraModes.Gunner);
            }
            if (PlayerTypeComboBox.SelectedIndex == 1)
            {
                callingForm.setPlayerType(CameraModes.Driver);
            }
        }
    }
}
