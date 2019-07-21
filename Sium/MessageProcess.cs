using System;
using System.Collections;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace Sium
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageProcess
    {
        /// <summary>
        /// 消息提示窗口 - 系统名称
        /// </summary>
        static string strMessTitle = System.Configuration.ConfigurationSettings.AppSettings["SysName"];

        public MessageProcess()
        {
            ///
            /// TODO: 在此处添加构造函数逻辑
            ///            

        }
        /// <summary>
        /// 显示提示信息对话框
        /// </summary>
        /// <param name="message">提示信息</param>
        public static void ZAMessageShowInformation(string message)
        {
            MessageBox.Show(message, strMessTitle + " 提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 显示错误信息对话框
        /// </summary>
        /// <param name="message">错误信息</param>
        public static void ZAMessageShowError(string message)
        {
            MessageBox.Show(message, strMessTitle + " 错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 显示警告信息对话框
        /// </summary>
        /// <param name="message"></param>
        public static void ZAMessageShowWarning(string message)
        {
            MessageBox.Show(message, strMessTitle + " 警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 显示可以让用户选择的问题信息对话框
        /// </summary>
        /// <param name="message">问题信息</param>
        /// <returns>选择结果（Yes or No）</returns>
        public static bool ZAMessageDialogResult(string message)
        {
            bool b = false;
            if (MessageBox.Show
      (message, strMessTitle + " 请选择", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                b = true;

            }
            return b;
        }
    }
}
