using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;

namespace Exersize2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            string direction = null;
            if(radProgramming.IsChecked.Value)
            {
                direction = radProgramming.Content.ToString();
            }
            else if(radDesign.IsChecked.Value)
            {
                direction = radDesign.Content.ToString();
            }
            else if(radNetwork.IsChecked.Value)
            {
                direction = radNetwork.Content.ToString();
            }

            List<string> skills = new List<string>();
            if(chkCPlusPlus.IsChecked.Value)
            {
                skills.Add(chkCPlusPlus.Content.ToString());
            }
            if(chkCSharp.IsChecked.Value)
            {
                skills.Add(chkCSharp.Content.ToString());
            }
            if(chkMSSQL.IsChecked.Value)
            {
                skills.Add(chkMSSQL.Content.ToString());
            }
            if(chkADO.IsChecked.Value)
            {
                skills.Add(chkADO.Content.ToString());
            }
            if(chkUnity.IsChecked.Value)
            {
                skills.Add(chkUnity.Content.ToString());
            }
            if(chkPhotoshop.IsChecked.Value)
            {
                skills.Add(chkPhotoshop.Content.ToString());
            }
            if(chkIllustator.IsChecked.Value)
            {
                skills.Add(chkIllustator.Content.ToString());
            }
            if(chkHTMLAndCSS.IsChecked.Value)
            {
                skills.Add(chkHTMLAndCSS.Content.ToString());
            }
            if(chk3DSMax.IsChecked.Value)
            {
                skills.Add(chk3DSMax.Content.ToString());
            }
            if(chkMaya.IsChecked.Value)
            {
                skills.Add(chkMaya.Content.ToString());
            }
            if(chkCCNA.IsChecked.Value)
            {
                skills.Add(chkCCNA.Content.ToString());
            }
            if(chkCCNP.IsChecked.Value)
            {
                skills.Add(chkCCNP.Content.ToString());
            }
            if(chkMCSA.IsChecked.Value)
            {
                skills.Add(chkMCSA.Content.ToString());
            }
            if(chkMSCE.IsChecked.Value)
            {
                skills.Add(chkMSCE.Content.ToString());
            }
            Resume resume = new Resume(tbName.Text, tbAge.Text, tbMartialStatus.Text, tbAddress.Text, tbEmail.Text,direction,skills);
            string fileName = tbName.Text + ".txt";
            using(FileStream file=new FileStream(fileName,FileMode.Create))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Resume));
                xml.Serialize(file,resume);
            }
        }
    }
    [Serializable]
    public class Resume
    {
        public string FullName
        {
            get;
            set;
        }
        public string Age
        {
            get;
            set;
        }
        public string MartialStatus
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public string EMail
        {
            get;
            set;
        }
        public string Direction
        {
            get;
            set;
        }
        public List<string> Skills
        {
            get;
            set;
        }
        public Resume()
        {
        }
        public Resume(string fullName, string age, string martialStatus, string address, string eMail,string direction, List<string> skills)
        {
            FullName = fullName;
            Age = age;
            MartialStatus = martialStatus;
            Address = address;
            EMail = eMail;
            Direction = direction;
            Skills = skills;
        }
    }
}
