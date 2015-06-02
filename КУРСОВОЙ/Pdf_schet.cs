using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp;
using System.IO;
using iTextSharp.text.pdf;

namespace КУРСОВОЙ
{
    class Pdf_schet
    {
        public void PDF(string fileName)
        {
            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(fileName.ToString() + @".pdf", FileMode.Create));
            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont(@"C:\Users\Ольга\ARIAL.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Phrase j0 = new Phrase("СЧЁТ НА ОПЛАТУ ",
           new iTextSharp.text.Font(baseFont, 20,
           iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
            Paragraph a0 = new Paragraph(j0);
            a0.Alignment = Element.ALIGN_CENTER;
            a0.SpacingAfter = 20;

            iTextSharp.text.Phrase jj = new Phrase(Program.naim,
           new iTextSharp.text.Font(baseFont, 12,
           iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
            Paragraph aa = new Paragraph(jj);
            aa.SpacingAfter = 10;

            iTextSharp.text.Phrase j1 = new Phrase("Количество: " + Math.Ceiling(Program.k),
           new iTextSharp.text.Font(baseFont, 12,
           iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
            Paragraph a1 = new Paragraph(j1);
            a1.SpacingAfter = 10;

            iTextSharp.text.Phrase jj1 = new Phrase("Цена: " +  Math.Ceiling(Program.cena),
           new iTextSharp.text.Font(baseFont, 12,
           iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
            Paragraph aa1 = new Paragraph(jj1);
            aa1.SpacingAfter = 10;

            iTextSharp.text.Phrase j2 = new Phrase("ИТОГО К оплате: " + Program.s + " рублей",
           new iTextSharp.text.Font(baseFont, 12,
           iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
            Paragraph a2 = new Paragraph(j2);
            a2.SpacingAfter = 10;

            iTextSharp.text.Phrase j3 = new Phrase("Клиент: " + Program.FIO,
          new iTextSharp.text.Font(baseFont, 12,
          iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
            Paragraph a3 = new Paragraph(j3);
            a3.SpacingAfter = 10;

            iTextSharp.text.Phrase j4 = new Phrase("Подпись клиента: " ,
          new iTextSharp.text.Font(baseFont, 12,
          iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
            Paragraph a4 = new Paragraph(j4);
            a4.SpacingAfter = 10;

            iTextSharp.text.Phrase j5 = new Phrase("Почта: " + Program.mail,
          new iTextSharp.text.Font(baseFont, 12,
          iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
            Paragraph a5 = new Paragraph(j5);
            a5.SpacingAfter = 10;

            iTextSharp.text.Phrase j6 = new Phrase("Дата: " + DateTime.Now,
          new iTextSharp.text.Font(baseFont, 12,
          iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
            Paragraph a6 = new Paragraph(j6);
            a6.SpacingAfter = 210;

            iTextSharp.text.Phrase j7 = new Phrase("ООО Мир Ремонта ",
           new iTextSharp.text.Font(baseFont, 12,
           iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
            Paragraph a7 = new Paragraph(j7);
            a7.Alignment = Element.ALIGN_CENTER;
            a7.SpacingAfter = 10;

            iTextSharp.text.Image j = iTextSharp.text.Image.GetInstance(@"C:/Users/Ольга/Documents/Visual Studio 2010/Projects/КУРСОВОЙ/1.jpg");
            j.Alignment = Element.ALIGN_RIGHT;

            doc.Add(j);
            doc.Add(a0);
            
            doc.Add(a3);
            doc.Add(a5);
            doc.Add(aa);
            doc.Add(a1);
            doc.Add(aa1);
            doc.Add(a2);
            doc.Add(a4);
            doc.Add(a6);
            doc.Add(a7);
            doc.Close();
        }
    }
}
