using System;
using System.Collections.Generic;

namespace Serie03
{
    class MainClass
    {
        //List of words
        public static List<Word> wordsList;
        //HintWord
        public static String letters = "";

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            int selection = WelcomeGame();

            while(true){
				switch (selection)
				{
					case 1:
						Console.Write("Donner le nom d'un fichier : ");
						String fileName = Console.ReadLine();

						FilesTool filesTool = new FilesTool(fileName);
						wordsList = filesTool.FileToList();
						break;
					case 2:
						Play();
						break;
					case 3:
						ShowScores();
						break;
					case 4:
						Environment.Exit(0);
						break;
				}
                selection = WelcomeGame();
            }
        }

        /// <summary>
        /// Play one party with a random word.
        /// </summary>
        private static void Play()
        {
			Random random = new Random();
            Word choosenWord;

            try{
                choosenWord = wordsList[random.Next(wordsList.ToArray().Length)];
            }catch(NullReferenceException){
                Console.WriteLine("Vous n'avez pas encore chargé de mots.");
                return;
            }
            
            int compteur = 0;
            String nouveauScore = "";

            Console.WriteLine("Mot : "+choosenWord.getMaskedWord());

            do
            {
                Console.Write("Proposer une lettre : ");
                String letter = Console.ReadLine();
                if (letter.Length <= 1){
					letters += letter;
					Console.WriteLine("Mot : " + choosenWord.getHintWord(letters));
					compteur++;
                }else{
                    Console.WriteLine("Ne saisir qu'une lettre svp.");
                }
            } while (choosenWord.getHintWord(letters) != choosenWord.getWord());

            if (choosenWord.getScore()>compteur || choosenWord.getScore() < 0){
                nouveauScore = "(nouveau score)";
            }

            choosenWord.setScore(compteur);

            Console.WriteLine();
            Console.WriteLine("Bravo vous avez trouvé le mot \""+choosenWord.getWord()+"\" en "+compteur+" essais "+nouveauScore);

            choosenWord.resetMaskedWord();
            letters = "";
        }

        /// <summary>
        /// Shows the scores.
        /// </summary>
        private static void ShowScores()
        {
            try{
				foreach (Word word in wordsList)
				{
					String maskedWord = word.getMaskedWord();
					String score = word.getScore() < 0 ? "pas trouvé" : "" + word.getScore();
					Console.WriteLine(word.getHashCode() + " : " + maskedWord + "\t" + score);
				}
            }catch(NullReferenceException){
                Console.WriteLine("Vous n'avez pas encore chargé de mots.");
            }
        }

        /// <summary>
        /// Welcomes the player with some choices.
        /// </summary>
        /// <returns>The choice</returns>
        private static int WelcomeGame()
        {
            Console.WriteLine();
            Console.WriteLine("Vos options sont : ");
            Console.WriteLine("1) Choisir un fichier de mots");
            Console.WriteLine("2) Jouer (trouver un mot)");
            Console.WriteLine("3) Afficher les scores");
            Console.WriteLine("4) Terminer");
            Console.WriteLine();

            return CheckInputValidity();
        }

        /// <summary>
        /// Checks the input validity.
        /// </summary>
        /// <returns>The valid input.</returns>
        private static int CheckInputValidity()
        {
            int inputValue = -1;

            while (inputValue < 0 || inputValue >4)
			{
                Console.Write("Entrez votre sélection : ");
                if (!int.TryParse(Console.ReadLine(), out inputValue))
				{
					Console.WriteLine("Parsing Error");
				}
			}

            return inputValue;
        }
    }
}
