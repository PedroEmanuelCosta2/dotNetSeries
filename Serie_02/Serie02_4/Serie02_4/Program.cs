/*
 * Serie 02_4 Faite à l'arrache avec un ou deux bugs, sans respect des conventions ni des bonnes pratiques
 *  de codage C#...
 * 
 * 
 * 
 *  Hmm il y aura bien un étudiant pour corriger et sécuriser tout ça!
 *  cette technologique hmm ? jamais entendu ça!
 *  
 *  (c) ???? 2016
 */

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        String fileName = "";
        String dataFile = "";

        //Get the file name that the user enter
        Console.Write("Insert the name of your file (without the extension) : ");
        fileName = Console.ReadLine();

        //Read the data of the file and put it in the string dataFile
        ReadFile(fileName, ref dataFile);
        //Explode the values by the returns 
        string[] row = dataFile.Split('\n');

        //Declare a list that will take all the correct values
        List<int> data = new List<int>();
        for (int i = 0; i < row.Length; i++)
        {
            //Test that the value isn't empty and isn't a return
            if (!row[i].Equals("") && !@row[i].Equals("\r"))
            {
                if (Int32.TryParse(row[i], out int val)) // Parse the value
                    //Init the list with all the correct value of the data from the file
                    data.Add(val);
            }
        }
        //Print the values
        Print(data.ToArray());

        //Declare the filter array with the size of the corrects values
        int[] filterDataArray = new int[data.ToArray().Length];
        //Appliy the modifications to the data
        ModifyData(data.ToArray(), ref filterDataArray);
        //Print the new values
        Print(filterDataArray);

        //Assign them to a new Array
        int[] registerArray = filterDataArray;
        //And then put them in a new File
        WriteFile(fileName, ref registerArray);
    }

    /**
     * Open the file with the name that the user enter.
     * Then read all the data of it to puting it in the dataFile string.
     */
    private static void ReadFile(String fileName, ref String dataFile)
    {
        FileStream fileStreamOpen = null;

        try
        {
            fileStreamOpen = new FileStream(@"../../../../" + fileName + ".txt", FileMode.Open);
        }
        catch (FileLoadException)
        {
            Console.WriteLine("Failed to load the file : " + fileName + ".txt");
            Environment.Exit(0);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file : " + fileName + ".txt doesn't exists");
            Environment.Exit(0);
        }

        StreamReader reader = new StreamReader(fileStreamOpen);

        using (reader)
        {
            dataFile = reader.ReadToEnd();
        }

        reader.Close();
        fileStreamOpen.Close();
    }

    /**
     * Create a new file and write the data of the registerArray inside.
     * Make sure that the application quit if there is a problem to open the file.
     */
    private static void WriteFile(String fileName, ref int[] registerArray)
    {
        FileStream fileStreamWritter = null;
        try
        {
            fileStreamWritter = new FileStream(@"../../../../" + fileName + "Modified.txt", FileMode.Create);
        }
        catch (FileLoadException)
        {
            Console.WriteLine("Failed to load the file : " + fileName + "Modified.txt");
            Environment.Exit(0);
        }

        StreamWriter writter = new StreamWriter(fileStreamWritter);

        using (writter)
        {
            foreach (int val in registerArray)
            {
                writter.WriteLine(val);
            }
        }

        writter.Close();
        fileStreamWritter.Close();
    }

    /**
     * Modify the data from the data array by applying an averager and then put the values to the 
     * filterDataArray.
     */
    private static void ModifyData(int[] data, ref int[] filterDataArray)
    {
        for (int i = 0; i < data.Length - 2; i++)
        {
            try
            {
                filterDataArray[i] = data[i] / (data[i + 1] - data[i + 2]);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Attempt to divide by zero !");
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e);
            }
        }
    }

    /**
     * Print all the values of the data array.
     */
    private static void Print(int[] data)
    {
        foreach (int val in data)
        {
            Console.Write($"{val}, ");
        }
        Console.WriteLine();
    }
}