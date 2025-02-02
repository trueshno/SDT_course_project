﻿using Domain.Exceptions;
using Domain.Helper.Interfaces;
using System;
using System.Collections.Generic;
using Word = Microsoft.Office.Interop.Word;


namespace Domain.Helper.Implementations
{
    internal class WordHelper : IWordHelper
    {
        private Parser _parser;

        public WordHelper(Parser parser)
        {
            _parser = parser;
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
                throw new WordException("Ошибка при заполнения файла данными");
            }
        }

        public Word.Application OpenFile(string filePath)
        {
            if (_parser.FileExist(filePath))
            {
                Word.Application app = new Word.Application();

                app.Documents.Open(filePath);

                return app;
            }
            else
            {
                throw new WordException("Файл не найден");
            }
        }

        public void CloseApplication(Word.Application application)
        {
            application.Quit();
        }

        public void CloseDocument(Word.Document document)
        {
            document.Close();
        }

        public void SaveDocument(Word.Document document, string filePath)
        {
            string bonus = "";

            if (_parser.FileExist(filePath))
            {
                bonus = "1"; // TODO посмотреть, можно ли это как-то нормально сделать
            }

            document.SaveAs2(FileName: filePath + bonus);
        }

        public Word.Application CreateEmptyFile()
        {
            var application = new Word.Application();

            application.Documents.Add();

            return application;
        }
    }
}

