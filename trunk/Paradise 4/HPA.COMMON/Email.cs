using System;
using System.Collections.Generic;
using System.Text;

namespace HPA.Common
{
    public class Email
    {
      
        public static void Sendmail(String accountname, String password, String smtpname, String EmailAddress, String CompanyName, String Title, String Content)
        {
           
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

            //Thong so 1 mail , luu y cc va bcc

            msg.To.Add(EmailAddress);
            msg.From = new System.Net.Mail.MailAddress("ABC@abc.abc", CompanyName, System.Text.Encoding.UTF8);
            //msg.Bcc.Add("CuongVD44@yahoo.com.vn");
            msg.Subject = Title;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = Content;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            // nhan code html 
            msg.IsBodyHtml = true;
            msg.Priority = System.Net.Mail.MailPriority.High;
            // Add file       
            //msg.Attachments.Add(att);

            // thong tin sever
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(accountname, password);
            client.Port = 25;
            client.Host = smtpname;
            client.EnableSsl = true;

            try
            {

                //Send mail
                client.Send(msg);
               
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                throw ex;
            }
        }
        public static void Sendmail(String accountname, String password, String smtpname, String EmailAddress, String CompanyName, String Title, String Content, string att)
        {

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

            //Thong so 1 mail , luu y cc va bcc

            msg.To.Add(EmailAddress);
            msg.From = new System.Net.Mail.MailAddress("ABC@abc.abc", CompanyName, System.Text.Encoding.UTF8);
            msg.Bcc.Add("CuongVD44@yahoo.com.vn");
            msg.Subject = Title;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = Content;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            // nhan code html 
            msg.IsBodyHtml = true;
            msg.Priority = System.Net.Mail.MailPriority.High;
            // Add file       
            msg.Attachments.Add(new System.Net.Mail.Attachment(att));

            // thong tin sever
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(accountname, password);
            client.Port = 25;
            client.Host = smtpname;
            client.EnableSsl = true;

            try
            {

                //Send mail
                client.Send(msg);

            }
            catch (System.Net.Mail.SmtpException ex)
            {
                throw ex;
            }
        }
        public void abc()
        {

        }
        
    }
}
