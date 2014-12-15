using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ReviewPrintPDF
{
    class PDFCreator
    {
        public static readonly Font DefaultFont = new Font(Font.FontFamily.COURIER, 8);
        public static readonly Font LineNumberFont = new Font(Font.FontFamily.COURIER, 8, Font.BOLD);
        public static readonly Font PageHeaderFont = LineNumberFont;

        public PDFCreator(string[] args)
        {
            _outputFilename = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".pdf");
            PrintPDF(args);
            var process = new Process
                              {
                                  StartInfo = new ProcessStartInfo
                                                  {
                                                      FileName = _outputFilename
                                                  }
                              };
            process.Start();
            process.WaitForExit();
            File.Delete(_outputFilename);
        }

        private static string _outputFilename;

        private static void PrintPDF(string[] args)
        {
            _document = new Document();
            _writer = PdfWriter.GetInstance(_document,
                new FileStream(_outputFilename, FileMode.Create));
            _document.Open();

            _writer.PageEvent = new HeaderFooter();

            foreach (var file in args)
            {
                CreateFileChapter(file);
            }
            _document.Close();
            _writer.Close();
        }

        private static Document _document;
        private static PdfWriter _writer;

        public class HeaderFooter : PdfPageEventHelper
        {
            public override void OnStartPage(PdfWriter writer, Document document)
            {
                PageHeader();
            }
        }

        private static void PageHeader(Chapter chapter = null, string file = null, int page = -1)
        {

            //I use a PdfPtable with 1 column to position my header where I want it
            PdfPTable headerTbl = new PdfPTable(2);
            
            //set the width of the table to be the same as the document
            headerTbl.TotalWidth = _document.PageSize.Width;

            //I use an image logo in the header so I need to get an instance of the image to be able to insert it. I believe this is something you couldn't do with older versions of iTextSharp
            PdfPCell cell = new PdfPCell(new Phrase(_currentFile, PageHeaderFont));
            cell.PaddingLeft = 20;
            cell.Border = 0;
            cell.BorderWidthBottom = 1;
            headerTbl.AddCell(cell);

            cell = new PdfPCell(new Phrase(_currentFilePageNumber.ToString(), PageHeaderFont));
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.PaddingRight = 20;
            cell.Border = 0;
            cell.BorderWidthBottom = 1;
            headerTbl.AddCell(cell);

            //write the rows out to the PDF output stream. I use the height of the document to position the table. Positioning seems quite strange in iTextSharp and caused me the biggest headache.. It almost seems like it starts from the bottom of the page and works up to the top, so you may ned to play around with this.
            headerTbl.WriteSelectedRows(0, -1, 0, (_document.PageSize.Height - 10), _writer.DirectContent);
            _currentFilePageNumber++;
        }

        private static string _currentFile;
        private static int _currentFilePageNumber;
        private static bool _firstPage = true;

        private static void CreateFileChapter(string file)
        {
            _currentFile = file;
            _currentFilePageNumber = 1;
            //var chapter = new Chapter(0);
            if (_firstPage)
            {
                // I could not figure out how to get a header on first page....
                PageHeader();
                _firstPage = false;
            }
            else
            {
                _document.NewPage();
            }
            //PageHeader(chapter, file, 1);

            var lineNumber = 1;
            foreach (var line in File.ReadAllLines(file))
            {
                var paragraph = new Paragraph();
                paragraph.Leading = DefaultFont.GetCalculatedLeading(1.0f);
                

                var lineNumberString = lineNumber.ToString().PadLeft(3) + "  ";
                var lineNumberPhrase = new Phrase(lineNumberString, LineNumberFont);
                paragraph.Add(lineNumberPhrase);
                lineNumber++;
                
                var linePhrase = new Phrase(line, DefaultFont);
                paragraph.Add(linePhrase);

                _document.Add(paragraph);
            }
            // return chapter;
        }

       
    }
}
