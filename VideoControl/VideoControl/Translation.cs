using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;//For writing debug messages

namespace VideoControl
{
    public enum LANGUAGES
    {
        English = 0,
        Chinese = 1, //Translated from English to Chinese by David Sutton.
        Spanish = 2  //Translated by Raul Cabrera
        //If additional lanugages are added the NUMBEROFLANGUAGES constant should be changed and the dictonary should be updated
        //When adding new languages check for substrings that could cause errors when replacing values in the file in the ScoreControl.UpdateLanguage() function
    };
    public enum WORDS
    {
        File = 0,//for the File menu
        About = 1,//to open the About window (File/About)
        Languages = 2,//for the Languages menu
        English = 3,//for (Languages/English)
        Chinese = 4,//for (Languages/Chinese)
        Help = 5,//for the Help menu
        OpenHelpFile = 6,//for (Help/OpenHelpFile)
        ViewHelpWebsite = 7,//for (Help/ViewHelpFile)
        Settings = 8,//for the main menu bar
        Spanish = 9,//for (Languages/Espanol)
        Up = 10,//for the control button
        Down = 11,//for the control button
        Left = 12,//for the control button
        Right = 13,//for the control button
        Fire = 14,//for the control button
        IPAddress = 15,//for the settings window
        PlayerType = 16,//for the settings window
        Gunner = 17,//for the player type combo box in the settings window
        Driver = 18,//for the player type combo box in the settings window
        Error = 19,//for the error pop up boxes
        AddressDoesNotHaveFourNumberGroups = 20,//a specific IPAddress error message
        AddressDoesNotHaveAPortNumber = 21,//a specific IPAddress error message
        AddressDoesNotStartWithHTTP = 22,//a specific IPAddress error message
        MhandisiSafari = 23,//for the app title
        CopyrightInfo = 24,//for the about info box
        MhandisiSafariVideoControlPanel = 25,//for the about info box
        Version = 26,//for the about info box
        SaveSettings = 27//for the settings window

        //If additional words are added the NUMBEROFWORDS constant should be changed and the dictonary should be updated
    };
    class Translation
    {
        private const byte NUMBEROFLANGUAGES = 3;
        private const byte NUMBEROFWORDS = 28;
        private static LANGUAGES Language; //Default language is English (LANGUAGES=0)
        private static LANGUAGES PreviousLanguage; //Used for replacing strings from the previous language
        private string[,] dictionary = {
            {"File", "文件", "Archivo"}, //File=0, for the File menu
            {"About", "关于", "Acerca"},//About=1, to open the About window (File/About)
            {"Languages","语言", "Idiómas"},//Languages=2, for the Languages menu
            {"English","English", "English"},//English=3, for (Languages/English) kept as English in all languages to make it easier for natives to identify
            {"中文","中文", "中文"},//Chinese=4, for (Languages/中文) kept as 中文 in all languages to make it easier for natives to identify
            {"Help", "帮助", "Ayuda"},//Help=5, for the Help menu
            {"Open Help File", "开始帮助文件", "Abrir el Archivo de Ayuda"},//OpenHelpFile=6, for (Help/OpenHelpFile)
            {"View Help Website", "开始帮助网址","Ver Ayuda del sitio de Web"},//ViewHelpWebsite=7, for (Help/ViewHelpFile)
            {"Settings","选项",""},//Settings =8, for the main menu bar
            {"Español","Español","Español"},//Spanish = 9, for (Languages/Espanol) kept as Español in all languages for easy identification
            {"Up","上向",""},//Up = 10, for the control button
            {"Down","下向",""},//Down = 11, for the control button
            {"Left","左向",""},//Left = 12, for the control button
            {"Right","右向",""},//Right = 13, for the control button
            {"Fire","打枪",""},//Fire = 14, for the control button
            {"IP Address:", "互联网地址：",""},//IPAddress = 15,  for the settings window
            {"Player Type:","玩家类型：",""},//PlayerType = 16, for the settings window
            {"Gunner","枪家类",""}, //Gunner = 17, for the player type combo box in the settings window
            {"Driver","开车家类",""},//Driver = 18, for the player type combo box in the settings window
            {"Error","错误",""},//Error = 19, for the error pop up boxes
            {"This address does not have four groups of numbers in the form of http://192.168.1.125:81","这个互联网地址不合适。没有四个号集体。试一试这样的: http://192.168.1.125:81",""},//AddressDoesNotHaveFourNumberGroups = 20, a specific IPAddress error message
            {"This address does not include a port number.","这个互联网地址没有 port number。",""},//AddressDoesNotHaveAPortNumber = 21, a specific IPAddress error message
            {"This address does not start with http://","这个互联网地址头上没有“http://”",""},//AddressDoesNotStartWithHTTP = 22, a specific IPAddress error message
            {"Mhandisi Safari", "Mhandisi Safari", "Mhandisi Safari"},//MhandisiSafari = 23 for the app title. This is a Swahili word and was intentionally not translated
            {"©2014 Colorado Technical University","©2014 Colorado Technical University","©2014 Colorado Technical University"},//CopyrightInfo = 24 for the About info box. This was not translated because the copyright symbol and school name should be universal
            {"Mhandis Safari Video Control Panel", "Mhandisi Safari 摄像机控制台", ""},//MhandisiSafariVideoControlPanel = 25, for the about info box
            {"Version: ", "版本： ",""},//Version = 26 for the about info box
            {"Save Settings","存盘选项",""}//SaveSettings = 27, for the settings window
                                        };
        public Translation(LANGUAGES DefaultLanugage)
        {
            Language = DefaultLanugage;
        }

        public string GetWord(WORDS word)
        {
            if ((byte)word >= 0 && (byte)word < NUMBEROFWORDS) //Language is not checked for propper range because its integrity protected by a setter function
            {
                return dictionary[(byte)word, (byte)Language];
            }
            Debug.WriteLine("ERROR: GetWords was passed a value {0} that was out of range(0-{1})", (byte)word, (byte)NUMBEROFWORDS);
            return "";
        }

        public LANGUAGES GetLanguage()
        {
            return Language;
        }

        public void SetLanguage(LANGUAGES newLanguage)
        {
            if ((byte)newLanguage >= 0 && (byte)newLanguage < NUMBEROFLANGUAGES)
            {
                PreviousLanguage = Language;
                Language = newLanguage;
            }
            Debug.WriteLine("ERROR: SetLanguag was passed a value {0} that was out of range(0-{1})", (byte)newLanguage, (byte)NUMBEROFLANGUAGES);
        }

        /*Phrases:
         * Some expressions are more complex than a direct translation. These cases will be represented by methods.
         * For example these prases may take an argument and return a string output. This string will be formmatted
         * for gramattically correct output by using the appropriate plural form for the the output language.
         */
    }
}
