using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmsUtility;

namespace SMS
{
    public partial class SMS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            SmsFormat format = new SmsFormat();
            bool validate = true;
            if (tbPhone.Text.Trim() != "")
            {
                format.phone = tbPhone.Text.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                validate = false;
                cleanLabel();
                Label1.Text = "電話號碼不能空白!!";
            }

            format.subject = tbSubject.Text;
            format.content = tbContent.Text;

            //時間全空白表示立刻傳送
            if ((tbYear.Text.Trim() == "") && (tbMonth.Text.Trim() == "") && (tbDay.Text.Trim() == "") && (tbHour.Text.Trim() == "") && (tbMinute.Text.Trim() == "") && (tbSec.Text.Trim() == ""))
            {
                format.sendFormat = (int)EnumSendFormat.NOW;
            }
            else
            {
                DateTime dt = new DateTime();
                if (DateTime.TryParse(tbYear.Text + "/" + tbMonth.Text + "/" + tbDay.Text + " " + tbHour.Text + ":" + tbMinute.Text + ":" + tbSec.Text, out dt))
                {
                    format.datetime = dt;
                    format.sendFormat = (int)EnumSendFormat.RESERVE;
                }
                else
                {
                    validate = false;
                    cleanLabel();
                    Label1.Text = "請輸入合法日期";
                }
            }

            if (validate)
            {
                try
                {
                    cleanLabel();
                    Sms1wayModule.SmsSvc svc = new Sms1wayModule.SmsSvc();
                    Utility.Result result = svc.authAccount("n+ABj+1w6e1Ht2A2ziBh0Q==", "367f7deaa1ce47b185a0c91cb6d8f714", "Sms1wayModule");
                    Label1.Text = result.success.ToString() + result.description;
                    Utility.Result sendResult = svc.sendSms(format);
                    Label2.Text = sendResult.success.ToString() + sendResult.description + svc.getMsgId().ToString();
                    lbMsgID.Text = "MsgID=" + svc.getMsgId().ToString();
                }
                catch (Exception err)
                {
                    cleanLabel();
                    Label1.Text = err.Message;
                }
            }

        }

        public void cleanLabel()
        {
            Label1.Text = "";
            Label2.Text = "";
            lbMsgID.Text = "";
            lbMsgCancel.Text = "";
            lbMsgQuery.Text = "";
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            SmsFormat format = new SmsFormat();
            bool validate = true;
            if (tbPhoneq.Text.Trim() != "")
            {
                format.phone = tbPhoneq.Text.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                validate = false;
                cleanLabel();
                lbMsgQuery.Text = "電話號碼不能空白!!";
            }
            if (tbMsgIDq.Text.Trim() == "")
            {
                validate = false;
                cleanLabel();
                lbMsgQuery.Text = "請輸入要查的MsgID";
            }

            if (validate)
            {
                try
                {
                    cleanLabel();
                    Sms1wayModule.SmsSvc svc = new Sms1wayModule.SmsSvc();
                    Utility.Result result = svc.authAccount("n+ABj+1w6e1Ht2A2ziBh0Q==", "367f7deaa1ce47b185a0c91cb6d8f714", "Sms1wayModule");
                    Utility.QueryPackage qpg = svc.getSmsDeliveryStatusEx(tbMsgIDq.Text, format.phone);
                    string statusc = "";
                    switch (qpg.packageStatus)
                    {
                        case "0":
                            statusc = "等待傳送中";
                            break;
                        case "1":
                            statusc = "正在傳送中";
                            break;
                        case "2":
                            statusc = "已傳送完畢";
                            break;
                        case "3":
                            statusc = "傳送失敗";
                            break;
                        case "4":
                            statusc = "已取消傳送";
                            break;
                        case "10":
                            statusc = "預約待傳送";
                            break;
                        case "20":
                            statusc = "等待接收中";
                            break;
                    }
                    lbMsgQuery.Text = statusc;
                    for (int i = 0; i < qpg.recvStatusList.Count(); i++)
                    {
                        lbMsgQuery.Text += "<br/>";
                        lbMsgQuery.Text += "pkgrecvphone:" + (qpg.recvStatusList[i]).telephone + "  " + "pkgrecvreceiveTime:" + (qpg.recvStatusList[i].receiveTime) + "  " + "pkgrecvstatus:" + (qpg.recvStatusList[i]).status + "  " + "pkgrecvdescription:" + (qpg.recvStatusList[i]).description;
                    }

                }
                catch (Exception err)
                {
                    cleanLabel();
                    Label1.Text = err.Message;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            bool validate = true;
            if (tbMsgIDc.Text.Trim() == "")
            {
                validate = false;
                cleanLabel();
                lbMsgCancel.Text = "請輸入要取消的MsgID";
            }

            if (validate)
            {
                try
                {
                    cleanLabel();
                    Sms1wayModule.SmsSvc svc = new Sms1wayModule.SmsSvc();
                    Utility.Result result = svc.authAccount("n+ABj+1w6e1Ht2A2ziBh0Q==", "367f7deaa1ce47b185a0c91cb6d8f714", "Sms1wayModule");

                    Utility.Result cancelRes = svc.cancelSms(tbMsgIDc.Text.Trim());
                    lbMsgCancel.Text = "cancelRes=" + cancelRes.success + "   " + "cancelDsc=" + cancelRes.description;
                }
                catch (Exception err)
                {
                    cleanLabel();
                    Label1.Text = err.Message;
                }
            }
        }
    }
}