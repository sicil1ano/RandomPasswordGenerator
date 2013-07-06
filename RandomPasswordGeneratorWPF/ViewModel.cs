using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassGenLogic;


namespace RandomPasswordGeneratorWPF
{
    public class ViewModel : INotifyPropertyChanged
    {
        PasswordGenerator pwdGen;
        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModel()
        {
            pwdGen = new PasswordGenerator();
        }


        #region Properties
        private string md5Hash;

        public string MD5Hash
        {
            get { return md5Hash; }
            set
            {
                if (value != null)
                {
                    md5Hash = value;
                    OnPropertyChanged("MD5Hash");
                }
            }
        }
        

        private string generatedPassword;

        public string GeneratedPassword
        {
            get { return generatedPassword; }
            set {
                if (value != null)
                {
                    generatedPassword = value;
                    OnPropertyChanged("GeneratedPassword");
                }
            
            }
        }
        #endregion

        public void GeneratePassword()
        {
            if (pwdGen != null)
            {
                GeneratedPassword = pwdGen.CreatePassword();
            }
        }

        public void CalculateMD5Hash()
        {
            if (pwdGen != null)
            {
                MD5Hash = pwdGen.CalcMD5Hash(generatedPassword);
            }
        }

        public void CopyToClipboard()
        {
            System.Windows.Forms.Clipboard.SetText(GeneratedPassword);
        }

        #region INotifyPropertyChanged member
        // Create the OnPropertyChanged method to raise the event 
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

    }
}
