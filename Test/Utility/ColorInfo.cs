using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace Test.Utility
{
    public  class ColorInfo
    {
        private readonly string insertBtnColor = "#0072C6";
        private readonly string cancelBtnColor = "#F4503B";
        private readonly string closeBtnColor = "#ABABAB";
        private readonly string labelColor = "#F4503B";

        public void ChangeSaveBtnColor(SimpleButton insertButton)
        {
            insertButton.Appearance.BackColor = ColorTranslator.FromHtml(insertBtnColor);
        }

        public void ChangeCancelBtnColor(SimpleButton cancelButton)
        {
            cancelButton.Appearance.BackColor = ColorTranslator.FromHtml(cancelBtnColor);
        }

        public void ChangeCloseBtnColor(SimpleButton closeButton)
        {
            closeButton.Appearance.BackColor = ColorTranslator.FromHtml(closeBtnColor);
        }
        public void ChangeValiLabel(List<LayoutControlItem> label)
        {
            foreach(var item in label)
            {
                item.AppearanceItemCaption.ForeColor = ColorTranslator.FromHtml(labelColor);
            }
        }
    }
}
