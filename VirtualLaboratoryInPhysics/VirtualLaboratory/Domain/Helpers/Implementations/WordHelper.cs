using Microsoft.Office.Interop.Word;
using Domain.Helpers.Interfaces;
using Word = Microsoft.Office.Interop.Word;

namespace Domain.Helpers.Implementations
{
    public class WordHelper : IWordHelper
    {
        private IParseHelper _parseHelper;

        public WordHelper(IParseHelper parseHelper)
        {
            _parseHelper = parseHelper;
        }

        public void CloseApplication(Word.Application application)
        {
            application.Quit();
        }

        public void CloseDocument(Word.Document document)
        {
            document.Close();
        }

        public void FillFile(Word.Application application, Dictionary<string, string> items)
        {
            try
            {
                foreach (var item in items)
                {
                    Word.Find find = application.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;

                    Object wrap = Word.WdFindWrap.wdFindContinue;
                    Object replace = Word.WdReplace.wdReplaceAll;

                    find.Execute(Wrap: wrap, Replace: replace);
                }
            }
            catch (Exception)
            {
                throw new Exception(Resources.ReportCreatingError);
            }
        }

        public Application OpenFile(string filePath)
        {
            if (_parseHelper.FileExist(filePath))
            {
                Word.Application app = new Word.Application();

                app.Documents.Open(filePath);

                return app;
            }
            else
            {
                throw new Exception(Resources.FileNotFound);
            }
        }

        public void SaveDocument(Word.Document document, string filePath)
        {
            document.SaveAs2(FileName: filePath);
        }
    }
}
