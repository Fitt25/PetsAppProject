// the ourAnimals array will store the following: 
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;

string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";


// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";
bool found = false;
string searchValue = "";

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 6];

string GetValidatedInput(string prompt, Func<string, bool> validator)
{
    bool isValid;
    do
    {
        Console.WriteLine(prompt);  // Prompt the user for input
        readResult = Console.ReadLine() ?? string.Empty;  // Read user input, default to an empty string if null
        isValid = validator(readResult);  // Use the validator to check the input
        if (!isValid) 
            Console.WriteLine("Invalid input. Please try again.");  // Error feedback
    } while (!isValid);  // Repeat until the input is valid
    if (readResult.GetType().Equals(typeof(string))) return readResult.ToLower();
    else return readResult;  // Return the validated input
}

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{   
    switch(i)
        {
            case (0):
                animalSpecies = "dog";
                animalID = "d1";
                animalAge = "2";
                animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
                animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
                animalNickname = "lola";
                break;
        
            case (1):
            
                animalSpecies = "dog";
                animalID = "d2";
                animalAge = "9";
                animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                animalNickname = "loki";
                break;
    
            case (2):
            
                animalSpecies = "cat";
                animalID = "c3";
                animalAge = "1";
                animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                animalPersonalityDescription = "friendly";
                animalNickname = "Puss";
                break;
    
            case (3):
                animalSpecies = "cat";
                animalID = "c4";
                animalAge = "?";
                animalPhysicalDescription = "";
                animalPersonalityDescription = "";
                animalNickname = "";
                break;
            default:
            
                animalSpecies = "";
                animalID = "";
                animalAge = "";
                animalPhysicalDescription = "";
                animalPersonalityDescription = "";
                animalNickname = "";
                break;
        }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
}

// display the top-level menu options
do 
{
    Console.Clear();

    Console.WriteLine("Welcome to the Furry Friends Pet app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();

    menuSelection = GetValidatedInput("Enter your selection number (or type Exit to exit the program)", input => !string.IsNullOrWhiteSpace(input) && ((int.TryParse(input, out int number) && number >= 1 && number <= 8) || input.ToLower() == "exit"));
   
    
    Console.WriteLine($"You selected menu option {menuSelection}.");
    Console.WriteLine("Press the Enter key to continue");
    readResult = Console.ReadLine();
    switch(menuSelection)
    {
        case "1":
            for (int i=0; i < maxPets; i++)
            {
                if (ourAnimals[i,0]!= "ID #: ")
                {
                    for(int j=0; j<6; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
    
            }
            break;
        case "2":
            string newPet = "y";
            int petCount = 0;
            bool validEntry = false;
            int petAge;
            for (int i=0; i < maxPets; i++)
            {
                if (ourAnimals[i,0]!="ID #: ") petCount++;
            }
            if (petCount<maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets. We can take {maxPets-petCount} more.");
            }
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            while(petCount<maxPets && newPet=="y")
            {
                newPet = GetValidatedInput("Do you want to enter info for another pet (y/n)", input => !string.IsNullOrWhiteSpace(input) && (input.ToLower() =="y" || input.ToLower() =="n"));
                /*do 
                {   Console.WriteLine("Do you want to enter info for another pet (y/n)");
                    readResult = Console.ReadLine();
                    if (readResult!=null) newPet = readResult.ToLower();
                    {
                        if (newPet == "y" || newPet == "n")
                        {
                            validEntry = true;
                        }else validEntry = false;
                    }
                }
                while(validEntry == false);*/
                
                if (newPet=="y") 
                {
                    animalSpecies = GetValidatedInput("Enter 'dog' or 'cat' to begin a new entry", input => !string.IsNullOrWhiteSpace(input) && (input.ToLower() =="cat" || input.ToLower() =="dog"));
                    /*do
                    {
                        Console.WriteLine("Enter 'dog' or 'cat' to begin a new entry");
                        readResult = Console.ReadLine();
                        if (readResult != null && readResult !="")
                        {
                            animalSpecies = readResult.ToLower();
                            
                            if(readResult == "cat" || readResult=="dog")
                            {
                                animalSpecies= readResult;
                                validEntry = true;
                            }else Console.WriteLine("Invalid entry. Enter 'dog' or 'cat' to begin a new entry");
                        }else validEntry = false;
                    } 
                    while(validEntry == false);*/
                    
                    animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();
                    
                    animalAge = GetValidatedInput("Enter the pet's age or enter ? if unknown", input => !string.IsNullOrWhiteSpace(input) && (int.TryParse(input,out petAge) || input == "?"));
                    /*do
                    {
                        Console.WriteLine("Enter the pet's age or enter ? if unknown");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalAge = readResult;
                            if (animalAge == "?")
                            {
                                validEntry = true;
                            }
                            else
                            {
                                validEntry = int.TryParse(animalAge,out petAge);
                            } 
                        
                        }
                    } 
                    while(validEntry == false);*/
                    animalPhysicalDescription = GetValidatedInput("Enter a physical description of the pet (size, color, gender, weight, housebroken)", input => input != null);

                    if (animalPhysicalDescription == "") animalPhysicalDescription ="tbd";
                    /*do
                    {
                        Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalPhysicalDescription = readResult.ToLower();
                            if (animalPhysicalDescription == "")
                            {
                                animalPhysicalDescription = "tbd";
                            }
                        }
                    } while (animalPhysicalDescription == "");*/

                    animalPersonalityDescription = GetValidatedInput("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)", input => input != null);

                    if (animalPersonalityDescription == "") animalPersonalityDescription ="tbd";
                    /*do
                    {
                        Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalPersonalityDescription = readResult.ToLower();
                            if (animalPersonalityDescription == "")
                            {
                                animalPersonalityDescription = "tbd";
                            }
                        }
                    } while (animalPersonalityDescription == "");*/

                    animalNickname = GetValidatedInput("Enter a nickname for the pet", input => input != null);

                    if (animalNickname == "") animalNickname ="tbd";
                    /*

                    do
                    {
                        Console.WriteLine("Enter a nickname for the pet");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalNickname = readResult.ToLower();
                            if (animalNickname == "")
                            {
                                animalNickname = "tbd";
                            }
                        }
                    } while (animalNickname == "");*/
                    ourAnimals[petCount, 0] = "ID #: " + animalID;
                    ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                    ourAnimals[petCount, 2] = "Age: " + animalAge;
                    ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                    ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                    ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;
                    petCount++; 
                    
                    
                }    
            }
            break;
        case "3":
            validEntry = false;
            for(int i=0; i<maxPets; i++)
            {
                if (ourAnimals[i,0] != "ID #: ")
                {   
                    if (ourAnimals[i,2] == "Age: ?")
                    {
                        do{
                            Console.WriteLine($"Enter an age for {ourAnimals[i,0]}");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalAge = readResult;
                                validEntry = int.TryParse(animalAge, out petAge);
                            }
                        }while(validEntry == false);
                    }
                    
                    if (ourAnimals[i,4] == "Physical description: tbd" || ourAnimals[i,4] == "Physical description: ")
                    { 
                        do{
                            Console.WriteLine($"Enter a physical description for {ourAnimals[i,0]} (size, color, breed, gender, weight, housebroken)");
                    
                            readResult = Console.ReadLine();
                            if (readResult != null && readResult!="")
                            {
                                animalPhysicalDescription = readResult;
                                validEntry = true;
                            }else validEntry = false;
                        }        
                        while(validEntry == false);
                    }
                }
                ourAnimals[i, 2] = "Age: " + animalAge;
                ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
            }
            Console.WriteLine("Age and physical description fields are complete for all of our friends. ");
            Console.WriteLine("Press the Enter key to continue.");
            break;
        case "4":
            for(int i=0; i<maxPets; i++)
            {
                if (ourAnimals[i,0] != "ID #: ")
                {   
                    if (ourAnimals[i,3] == "Nickname: tbd" || ourAnimals[i,3] == "Nickname: ")
                    {
                        do{
                            Console.WriteLine($"Enter a Nickname for {ourAnimals[i,0]}");
                    
                            readResult = Console.ReadLine();
                            if (readResult != null && readResult!="")
                            {
                                animalNickname = readResult;
                                validEntry = true;
                            }else validEntry = false;
                        }        
                        while(validEntry == false);
                    }
                    
                    if (ourAnimals[i,5] == "Personality: tbd" || ourAnimals[i,5] == "Personality: ")
                    { 
                        do{
                            Console.WriteLine($"Enter a personality description for {ourAnimals[i,0]} (likes or dislikes, tricks, energy level)");
                    
                            readResult = Console.ReadLine();
                            if (readResult != null && readResult!="")
                            {
                                animalPersonalityDescription = readResult;
                                validEntry = true;
                            }else validEntry = false;
                        }        
                        while(validEntry == false);
                    }
                }
                ourAnimals[i, 3] = "Nickname: " + animalNickname;
                ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
            }    
            Console.WriteLine("Nickname and personality description fields are complete for all of our friends.");
            Console.WriteLine("Press the Enter key to continue.");
            break;
        case "5":
            do
            {
                Console.WriteLine("Enter an ID # to change the pet age:");
                readResult = Console.ReadLine();
                if (readResult != null && readResult != "" && readResult.Length==2)
                {
                    animalID = readResult;
                    validEntry = true;
                }else 
                {
                    Console.WriteLine("ID not valid. Try Again.");
                    validEntry = false;
                }    
            }    
            while(validEntry == false);    
            for (int i=0; i<maxPets; i++)
            {
                if (ourAnimals[i,0].Contains(animalID))
                {   found = true;   
                    do{
                        Console.WriteLine("Enter new pet age:");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalAge = readResult;
                            validEntry = int.TryParse(animalAge, out petAge);
                        }
                    }while(validEntry == false);
                    ourAnimals[i, 2] = "Age: " + animalAge;
                }
                
            }
            if (found == false)
            {
                Console.WriteLine("ID not found.");
            }
            else
            {
                Console.WriteLine($"Pet ID #: {animalID} Age updated.");
            }
            break;
        case "6":
            do
            {
                Console.WriteLine("Enter an ID # to change the pet personality description:");
                readResult = Console.ReadLine();
                if (readResult != null && readResult != "" && readResult.Length==2)
                {
                    animalID = readResult;
                    validEntry = true;
                }else 
                {
                    Console.WriteLine("ID not valid. Try Again.");
                    validEntry = false;
                }    
            }    
            while(validEntry == false);
            for (int i=0; i<maxPets; i++)
            {
                if (ourAnimals[i,0].Contains(animalID))
                {   found = true;   
                    do{
                        Console.WriteLine($"Update personality description for {ourAnimals[i,0]} (likes or dislikes, tricks, energy level)");
                    
                        readResult = Console.ReadLine();
                        if (readResult != null && readResult!="")
                        {
                            animalPersonalityDescription = readResult;
                            validEntry = true;
                        }else validEntry = false;
                    }        
                    while(validEntry == false);
                    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
                }else found = false;
            }    
            if (found == false)
            {
                Console.WriteLine("ID not found.");
            }
            else
            {
                Console.WriteLine($"Pet ID #: {animalID} personality updated.");
            }
            break;
        case "7":
            Console.WriteLine("Enter the specified characteristic you want to look for to find cat matches: ID, Age, Personality, Description, Nickname");
            do
            {
                readResult = Console.ReadLine();

                if (readResult != null && readResult!="")
                {
                    searchValue = readResult;
                    switch (searchValue.ToLower())
                    {
                        case "id":
                            do
                            {
                                Console.WriteLine("Enter an ID # to view cat information:");
                                readResult = Console.ReadLine();
                                if (readResult != null && readResult != "" && readResult.Length==2)
                                {
                                    animalID = readResult;
                                    validEntry = true;
                                }else 
                                {
                                    Console.WriteLine("ID not valid. Try Again.");
                                    validEntry = false;
                                }    
                            }    
                            while(validEntry == false);

                            for (int i=0; i<maxPets; i++)
                            {
                                if (ourAnimals[i,0].Contains(animalID) && ourAnimals[i,1].Contains("cat"))
                                {   
                                    found = true; 
                                    for(int j=0; j<6; j++)
                                    {
                                        Console.WriteLine(ourAnimals[i, j]);
                                    }
                                    Console.WriteLine("");
                                }                  
                            }
                            if (found == false) Console.WriteLine("ID not found."); 

                            break;
                        case "age":
                            do{
                                Console.WriteLine("Enter a valid age to view matching cats information:");
                                readResult = Console.ReadLine();
                                if (readResult != null)
                                {
                                    animalAge = readResult;
                                    validEntry = int.TryParse(animalAge, out petAge);
                                }else validEntry = false;
                            }while(validEntry == false);

                            for (int i=0; i<maxPets; i++)
                            {
                                if (ourAnimals[i,2].Contains(animalAge) && ourAnimals[i,1].Contains("cat"))
                                {   
                                    found = true; 
                                    for(int j=0; j<6; j++)
                                    {
                                        Console.WriteLine(ourAnimals[i, j]);
                                    }
                                    Console.WriteLine("");
                                }                  
                            }
                            if (found == false) Console.WriteLine("Age not found.");
                            break;
                        case "personality":
                            do{
                                Console.WriteLine("Enter personality description to find cat matches:");
                                readResult = Console.ReadLine();
                                if (readResult != null && readResult!="")
                                {
                                    animalPersonalityDescription = readResult;
                                    validEntry = true;
                                }else validEntry = false;
                            }        
                            while(validEntry == false);

                            for (int i=0; i<maxPets; i++)
                            {
                                if (ourAnimals[i,5].Contains(animalPersonalityDescription.ToLower()) && ourAnimals[i,1].Contains("cat"))
                                {   
                                    found = true; 
                                    for(int j=0; j<6; j++)
                                    {
                                        Console.WriteLine(ourAnimals[i, j]);
                                    }
                                    Console.WriteLine("");
                                }                  
                            }
                            if (found == false) Console.WriteLine("Personality description not found.");
                            break;
                        case "description":
                            do{
                                Console.WriteLine("Enter physical description to find cat matches:");
                                readResult = Console.ReadLine();
                                if (readResult != null && readResult!="")
                                {
                                    animalPhysicalDescription = readResult;
                                    validEntry = true;
                                }else validEntry = false;
                            }        
                            while(validEntry == false);

                            for (int i=0; i<maxPets; i++)
                            {
                                if (ourAnimals[i,4].Contains(animalPhysicalDescription.ToLower()) && ourAnimals[i,1].Contains("cat"))
                                {   
                                    found = true; 
                                    for(int j=0; j<6; j++)
                                    {
                                        Console.WriteLine(ourAnimals[i, j]);
                                    }
                                    Console.WriteLine("");
                                }                  
                            }
                            if (found == false) Console.WriteLine("Physical description not found.");
                            break;
                        case "nickname":
                            do{
                                Console.WriteLine("Enter Nickname to find cat matches");
                                readResult = Console.ReadLine();
                                if (readResult != null && readResult!="")
                                {
                                    animalNickname = readResult;
                                    validEntry = true;
                                }else validEntry = false;
                            }        
                            while(validEntry == false);

                            for (int i=0; i<maxPets; i++)
                            {
                                if (ourAnimals[i,3].Contains(animalNickname.ToLower()) && ourAnimals[i,1].Contains("cat"))
                                {   
                                    found = true; 
                                    for(int j=0; j<6; j++)
                                    {
                                        Console.WriteLine(ourAnimals[i, j]);
                                    }
                                    Console.WriteLine("");
                                }                  
                            }
                            if (found == false) Console.WriteLine("Nickname not found.");
                            break;
                        default: 
                            validEntry = false;
                            break;
                    }        
                    
                }else validEntry = false;
                if (validEntry == false) Console.WriteLine("Invalid Entry. Type one of the following options: ID, Age, Personality, Description, Nickname");
            
            }
            while(validEntry ==false);
            break;
        case "8":
            Console.WriteLine("Enter the specified characteristic you want to look for to find dog matches: ID, Age, Personality, Description, Nickname");
            do
            {
                readResult = Console.ReadLine();

                if (readResult != null && readResult!="")
                {
                    searchValue = readResult;
                    switch (searchValue.ToLower())
                    {
                        case "id":
                            do
                            {
                                Console.WriteLine("Enter an ID # to view dog information:");
                                readResult = Console.ReadLine();
                                if (readResult != null && readResult != "" && readResult.Length==2)
                                {
                                    animalID = readResult;
                                    validEntry = true;
                                }else 
                                {
                                    Console.WriteLine("ID not valid. Try Again.");
                                    validEntry = false;
                                }    
                            }    
                            while(validEntry == false);

                            for (int i=0; i<maxPets; i++)
                            {
                                if (ourAnimals[i,0].Contains(animalID) && ourAnimals[i,1].Contains("dog"))
                                {   
                                    found = true; 
                                    for(int j=0; j<6; j++)
                                    {
                                        Console.WriteLine(ourAnimals[i, j]);
                                    }
                                    Console.WriteLine("");
                                }                  
                            }
                            if (found == false) Console.WriteLine("ID not found."); 

                            break;
                        case "age":
                            do{
                                Console.WriteLine("Enter a valid age to view matching dogs information:");
                                readResult = Console.ReadLine();
                                if (readResult != null)
                                {
                                    animalAge = readResult;
                                    validEntry = int.TryParse(animalAge, out petAge);
                                }else validEntry = false;
                            }while(validEntry == false);

                            for (int i=0; i<maxPets; i++)
                            {
                                if (ourAnimals[i,2].Contains(animalAge) && ourAnimals[i,1].Contains("dog"))
                                {   
                                    found = true; 
                                    for(int j=0; j<6; j++)
                                    {
                                        Console.WriteLine(ourAnimals[i, j]);
                                    }
                                    Console.WriteLine("");
                                }                  
                            }
                            if (found == false) Console.WriteLine("Age not found.");
                            break;
                        case "personality":
                            do{
                                Console.WriteLine("Enter personality description to find dog matches:");
                                readResult = Console.ReadLine();
                                if (readResult != null && readResult!="")
                                {
                                    animalPersonalityDescription = readResult;
                                    validEntry = true;
                                }else validEntry = false;
                            }        
                            while(validEntry == false);

                            for (int i=0; i<maxPets; i++)
                            {
                                if (ourAnimals[i,5].Contains(animalPersonalityDescription.ToLower()) && ourAnimals[i,1].Contains("dog"))
                                {   
                                    found = true; 
                                    for(int j=0; j<6; j++)
                                    {
                                        Console.WriteLine(ourAnimals[i, j]);
                                    }
                                    Console.WriteLine("");
                                }                  
                            }
                            if (found == false) Console.WriteLine("Personality description not found.");
                            break;
                        case "description":
                            do{
                                Console.WriteLine("Enter physical description to find dog matches:");
                                readResult = Console.ReadLine();
                                if (readResult != null && readResult!="")
                                {
                                    animalPhysicalDescription = readResult;
                                    validEntry = true;
                                }else validEntry = false;
                            }        
                            while(validEntry == false);

                            for (int i=0; i<maxPets; i++)
                            {
                                if (ourAnimals[i,4].Contains(animalPhysicalDescription.ToLower()) && ourAnimals[i,1].Contains("dog"))
                                {   
                                    found = true; 
                                    for(int j=0; j<6; j++)
                                    {
                                        Console.WriteLine(ourAnimals[i, j]);
                                    }
                                    Console.WriteLine("");
                                }                  
                            }
                            if (found == false) Console.WriteLine("Physical description not found.");
                            break;
                        case "nickname":
                            do{
                                Console.WriteLine("Enter Nickname to find dog matches");
                                readResult = Console.ReadLine();
                                if (readResult != null && readResult!="")
                                {
                                    animalNickname = readResult;
                                    validEntry = true;
                                }else validEntry = false;
                            }        
                            while(validEntry == false);

                            for (int i=0; i<maxPets; i++)
                            {
                                if (ourAnimals[i,3].Contains(animalNickname.ToLower()) && ourAnimals[i,1].Contains("dog"))
                                {   
                                    found = true; 
                                    for(int j=0; j<6; j++)
                                    {
                                        Console.WriteLine(ourAnimals[i, j]);
                                    }
                                    Console.WriteLine("");
                                }                  
                            }
                            if (found == false) Console.WriteLine("Nickname not found.");
                            break;
                        default: 
                            validEntry = false;
                            break;
                    }        
                    
                }else validEntry = false;
                if (validEntry == false) Console.WriteLine("Invalid Entry. Type one of the following options: ID, Age, Personality, Description, Nickname");
            
            }
            while(validEntry ==false);
            break;
    }
    // pause code execution
    readResult = Console.ReadLine();
} 
while(menuSelection != "exit");
