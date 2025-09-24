using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.Utility
{
    public class FIleType
    {
        public OpenFileDialog OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "이미지 선택";
            openFileDialog.Filter = "이미지 파일 (*.png;*.jpg;*.jpeg;)|*.png;*.jpg;*.jpeg;";

            return openFileDialog;
        }
        public SaveFileDialog SaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "이미지 파일 (*.png;*.jpg;*.jpeg;)|*.png;*.jpg;*.jpeg;";
            saveFileDialog.Title = "이미지 저장";

            return saveFileDialog;
        }
        public SaveFileDialog ExcelExport()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = ".xlsx | *.xlsx";
            saveFileDialog.FileName = "기본";

            return saveFileDialog;
        }
    }
}
