using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Utiliity
{
    public class Util
    {
        public Dictionary<string, string> Pattern()
        {
            var dic = new Dictionary<string, string>(){ {"email", @"^[^@\s]+@[^@\s]+\.[^@\s]+$" }, 
                                                        { "passwd", "[^a-zA-Z0-9]"} };
            return dic;
        }
        public string Uuid()
        {
            Guid nGuid = Guid.NewGuid();
            string uuid = nGuid.ToString();

            return uuid;
        }
        public OpenFileDialog ImgOpenType()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "이미지 선택";
            openFileDialog.Filter = "이미지 파일 (*.png;*.jpg;*.jpeg;)|*.png;*.jpg;*.jpeg;";

            return openFileDialog;
        }

        public SaveFileDialog ImgSaveType()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "이미지 파일 (*.png;*.jpg;*.jpeg;)|*.png;*.jpg;*.jpeg;";
            saveFileDialog.Title = "이미지 저장";

            return saveFileDialog;
        }

        public string ImgFolderPath()
        {
            string path = @"C:\NAS\";
            return path;
        }
    }
}
