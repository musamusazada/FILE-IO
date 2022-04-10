using StudentManager;

//Please change the file path if needed
string filePath = @"C:\Users\User\Desktop\outputAmrah.txt";

//Checking if the file with the give name exists
FileCreator(filePath);

//Getting lines from text file
List<string> lines = File.ReadLines(filePath).ToList();

AppLoop(lines,filePath);
File.WriteAllLines(filePath, lines);
foreach (var line in File.ReadLines(filePath).ToList())
{
    Console.WriteLine(line);
}

//Method handles the application loop
void AppLoop(List<string> fileLines, string path)
{
    Console.Clear();
    Console.WriteLine("Enter 1 to read");
    Console.WriteLine("Enter 2 to create new student");
    Console.WriteLine("Enter 0 to close the app");
    string userInput = Console.ReadLine();

    switch (userInput)
    {
        case "0":
            break;
        case "1":
            //Reading lines from file
            foreach (var line in File.ReadLines(path).ToList())
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("---------------------");
            Console.WriteLine("Press any key to return to menu");
            Console.ReadLine();
            AppLoop(fileLines, path);
            break;
        case "2":
            StudentCreator(fileLines, path);
            break;
        default:
            Console.Clear();
            Console.WriteLine("Please Choose Valid Option");
            Thread.Sleep(1500);
            AppLoop(fileLines, path);
            break;
    }

    Console.WriteLine("______________________________");
    Console.WriteLine("Press any key to close the app");
}


//Utility Methods
//--------------------------------------


//Creates a Student and saves it to file.
void StudentCreator( List<string> fileLines, string path )
{
    Console.Write("Enter Name: ");
    string name = Console.ReadLine();
    Console.Write("Enter Surname: ");
    string surname = Console.ReadLine();
    Console.Write("Enter Album No. :");
    string albumNo =  Console.ReadLine();
   
    
   
    fileLines.Add($"Name: {name} , Surname: {surname} , Album No: {albumNo}");
    File.WriteAllLines(path,fileLines);
    Console.WriteLine("New Student Successfully Added");

    Console.WriteLine("To create new student enter 1");
    Console.WriteLine("To go to previous menu enter 2");
    Console.WriteLine("To exit the application enter 3");
    Console.Write("Enter: ");
    string userInput = Console.ReadLine();
    switch (userInput)
    {
        case "1":
            StudentCreator( fileLines , path);
            break;
        case "2":
            AppLoop(fileLines, path);
            break;
        case "3":
            Console.WriteLine("App Terminated");
            Console.ReadLine();
            break;
        default:
            Console.WriteLine("Invalid choice");
            Console.WriteLine("Returning to Menu");
            AppLoop(fileLines, path);
            break;
    }

}
//Creates a file.
void FileCreator(string filepath)
{
    if (File.Exists(filepath))
    {
        File.Delete(filepath);
    }

    using (StreamWriter sw = File.CreateText(filepath))
    {
        Console.WriteLine("New File Created");
    }   
}