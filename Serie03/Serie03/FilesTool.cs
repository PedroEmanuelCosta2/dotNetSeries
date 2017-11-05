using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

namespace Serie03
{
    public class FilesTool
    {
        //Argument
        private String fileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Serie03.FilesTool"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public FilesTool(String fileName)
        {
            this.fileName = fileName;
        }

        /// <summary>
        /// Get the words from the file to put it in a List.
        /// </summary>
        /// <returns>The to list.</returns>
        public List<Word> FileToList()
        {
            List<Word> listWord = new List<Word>();

            FileStream fileStream = null;

            try{
                fileStream = new FileStream(@"../../../" + fileName, FileMode.Open);    
            }catch(FileNotFoundException){
                Console.WriteLine("Ce Fichier n'existe pas.");
                return null;
            }catch(FileLoadException){
                Console.WriteLine("Le fichier n'as pas pu être chargé.");
                return null;
            }

			StreamReader reader = new StreamReader(fileStream);

			using (reader)
			{
				while (reader.Peek() >= 0)
				{
                    String inputDataWord = reader.ReadLine();
                    if(!CheckWordValidity(inputDataWord)){
						Word word = new Word(inputDataWord);
						listWord.Add(word);   
                    }
				}
			}

            fileStream.Close();
            reader.Close();

            Console.WriteLine(listWord.ToArray().Length+" mots chargés avec succès");
            Console.WriteLine();

            return listWord;
        }

        /// <summary>
        /// Checks the word validity.
        /// </summary>
        /// <returns><c>true</c>, if word validity was checked, <c>false</c> otherwise.</returns>
        /// <param name="inputDataWord">Input data word.</param>
        private bool CheckWordValidity(string inputDataWord)
        {
            var errors = Regex.Matches(inputDataWord, @"[^a-zA-ZÿüûùôïîëêèéçâàŸÜÛÙÔÏÎËÊÈÉÇÂÀ\-]").Count;
            return errors > 0;
        }
    }
}
