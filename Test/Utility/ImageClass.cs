
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Test.Employees.Dtos;
using Test.Employees.Models;

namespace Test.Utility.Forms
{
    public class ImageClass
    {
        public FIleType fileType = new FIleType();
        public PathAddr path = new PathAddr();
      
        public string MainImg()
        {
            string svgFile = @"C:\test\ic_person_24px.svg";
            return svgFile;
        }
        public bool InsertFormOpenImg(out Image img, out string imgFormat)//insert폼 이미지 열때
        {
            img = null;
            imgFormat = string.Empty;
            var openFile = fileType.OpenFile();

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFile.FileName;
                imgFormat = Path.GetExtension(filePath).ToLower();

                // 이미지 미리보기
                img = Image.FromFile(filePath);
                return true;
            }
            return false;
        }

        public string InsertFormSaveImg(Image img, int empId, string imgFormat) //insert폼 이미지 추가
        {
            if (img == null)
            {
                return null;
            }

            var saveFile = fileType.SaveFile();

            Guid nGuid = Guid.NewGuid();
            string uuid = nGuid.ToString();

            saveFile.FileName = uuid;
            string realFileName = saveFile.FileName + imgFormat;

            string folderPath = path.FolderPath() + empId;
            string savePath = folderPath + @"\" + saveFile.FileName + imgFormat;

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            img.Save(savePath);

            return realFileName;

        }
        public bool UpdateFormOpenImg(out Image img, out string imgFormat,out bool imgChange)
        {

            img = null;                
            imgFormat = string.Empty;  
            imgChange = false;

            var openFile = fileType.OpenFile();

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFile.FileName;

                imgFormat = Path.GetExtension(fileName).ToLower();
                imgChange = true;

                img = Image.FromFile(fileName);
              
                return true;
            }
            return false;
        }
        public string UpdateFormSaveImg(Image img, int empId, string imgFormat ,ImgDto imgInfo, bool imgChange, int cnt)
        {
           
            var saveFile = fileType.SaveFile();

            string folderPath = path.FolderPath() + empId;
            var saveFileName = saveFile.FileName;

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            if (imgInfo != null)
            {
                string imgPath = folderPath + @"\" + imgInfo.ImgName;
                //파일 삭제 조건
                if (imgChange && !string.IsNullOrEmpty(imgInfo.ImgName) && img != null) // 업데이트 사진 있을 시 원본 사진 지움
                {
                    File.Delete(imgPath);
                }
                else if (img == null && !string.IsNullOrEmpty(imgInfo.ImgName) && !imgChange && cnt < 1)  //업데이트 사진 없고 원본 사진 있을 때 x 버튼
                {
                    File.Delete(imgPath);
                }
                saveFileName = imgInfo.ImgName;
            }
            //이미지명 변경 조건
            if (img == null && !string.IsNullOrEmpty(imgInfo.ImgName) && !imgChange && cnt < 1)// 업데이트 사진 없고 원본 사진 있을 때 x 버튼
            {
                saveFileName = null;

            }
            else if (imgChange && img != null)// 사진 변경 있을 시
            {
                //uuid 설정
                Guid nGuid = Guid.NewGuid();
                string uuid = nGuid.ToString();
                saveFileName = uuid + imgFormat;
                img.Save(folderPath + @"\" + saveFileName);
            }
            return saveFileName;
        }
        public void DelImg(int imgId, int empId)
        {
            EmployeeRepository.EmpRepo.DelImgLinq(imgId);

            string folderPath = @"C:\NAS\" + empId;

            if (Directory.Exists(folderPath))
            {
                Directory.Delete(@"C:\NAS\" + empId, true);
            }
        }
    }
}
