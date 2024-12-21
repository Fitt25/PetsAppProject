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

// method for input validation
string GetValidatedInput(string prompt, Func<string, bool> validator)
{
    bool isValid;
    do
    {
        Console.WriteLine(prompt);  
        readResult = Console.ReadLine() ?? string.Empty;  
        isValid = validator(readResult);  
        if (!isValid) 
            Console.WriteLine("Invalid input. Please try again.");  
    } while (!isValid);  
    if (readResult.GetType().Equals(typeof(string))) return readResult.ToLower();
    else return readResult;  
}
// method for match finding
void FindMatch(string toFind, string toSearch, int positition) {
     for (int i=0; i<maxPets; i++)
        {
            if (ourAnimals[i,positition].Contains(toFind) && ourAnimals[i,1].Contains(toSearch))
            {   
                found = true; 
                for(int j=0; j<6; j++)
                {
                    Console.WriteLine(ourAnimals[i, j]);
                }
                Console.WriteLine("");
            }                  
        }
        if (found == false) Console.WriteLine("Sorry, we couldn't find a match."); 
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

// display menu options
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
   
    // get menu selection
    Console.WriteLine($"You selected menu option {menuSelection}.");
    Console.WriteLine("Press the Enter key to continue");
    readResult = Console.ReadLine();

    // provide access to menu options
    switch(menuSelection)
    {
        //display all pets
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
        //Add new pet    
        case "2":
            string newPet = "y";
            int petCount = 0;
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
                
                if (newPet=="y") 
                {
                    animalSpecies = GetValidatedInput("Enter 'dog' or 'cat' to begin a new entry", input => !string.IsNullOrWhiteSpace(input) && (input.ToLower() =="cat" || input.ToLower() =="dog"));
                    
                    animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();
                    
                    animalAge = GetValidatedInput("Enter the pet's age or enter ? if unknown", input => !string.IsNullOrWhiteSpace(input) && (int.TryParse(input,out petAge) || input == "?"));

                    animalPhysicalDescription = GetValidatedInput("Enter a physical description of the pet (size, color, gender, weight, housebroken)", input => input != null);

                    if (animalPhysicalDescription == "") animalPhysicalDescription ="tbd";

                    animalPersonalityDescription = GetValidatedInput("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)", input => input != null);

                    if (animalPersonalityDescription == "") animalPersonalityDescription ="tbd";

                    animalNickname = GetValidatedInput("Enter a nickname for the pet", input => input != null);

                    if (animalNickname == "") animalNickname ="tbd";
        
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
        // complete age and physical description fields    
        case "3":
            for(int i=0; i<maxPets; i++)
            {
                if (ourAnimals[i,0] != "ID #: ")
                {   
                    if (ourAnimals[i,2] == "Age: ?")
                    {
                        animalAge = GetValidatedInput($"Enter an age for {ourAnimals[i,0]}", input => !string.IsNullOrWhiteSpace(input) && int.TryParse(input,out petAge));
                        
                    }
                    
                    if (ourAnimals[i,4] == "Physical description: tbd" || ourAnimals[i,4] == "Physical description: ")
                    { 
                        animalPhysicalDescription = GetValidatedInput($"Enter a physical description for {ourAnimals[i,0]} (size, color, breed, gender, weight, housebroken)", input => !string.IsNullOrEmpty(input));
                        
                    }
                }
                ourAnimals[i, 2] = "Age: " + animalAge;
                ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
            }
            Console.WriteLine("Age and physical description fields are complete for all of our friends. ");
            Console.WriteLine("Press the Enter key to continue.");
            break;

        //complete nickname and personality fields
        case "4":
            for(int i=0; i<maxPets; i++)
            {
                if (ourAnimals[i,0] != "ID #: ")
                {   
                    if (ourAnimals[i,3] == "Nickname: tbd" || ourAnimals[i,3] == "Nickname: ")
                    {
                        animalNickname = GetValidatedInput($"Enter a Nickname for {ourAnimals[i,0]}", input => !string.IsNullOrEmpty(input));
                    
                    }
                    
                    if (ourAnimals[i,5] == "Personality: tbd" || ourAnimals[i,5] == "Personality: ")
                    { 

                        animalPersonalityDescription = GetValidatedInput($"Enter a personality description for {ourAnimals[i,0]} (likes or dislikes, tricks, energy level)", input => !string.IsNullOrEmpty(input));
                        
                    }
                }
                ourAnimals[i, 3] = "Nickname: " + animalNickname;
                ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
            }    
            Console.WriteLine("Nickname and personality description fields are complete for all of our friends.");
            Console.WriteLine("Press the Enter key to continue.");
            break;

        //edit pet age    
        case "5":
            animalID = GetValidatedInput($"Enter an ID # to change the pet age:", input => !string.IsNullOrEmpty(input) && input.Length==2);
            
            for (int i=0; i<maxPets; i++)
            {
                if (ourAnimals[i,0].Contains(animalID))
                {   found = true;   
                    animalAge = GetValidatedInput($"Enter new pet age:", input => !string.IsNullOrEmpty(input) && int.TryParse(input, out petAge));
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
        // edit personality description
        case "6":
             animalID = GetValidatedInput($"Enter an ID # to change the pet personality description:", input => !string.IsNullOrEmpty(input) && input.Length==2);
            
            for (int i=0; i<maxPets; i++)
            {
                if (ourAnimals[i,0].Contains(animalID))
                {   found = true;   
                    animalPersonalityDescription = GetValidatedInput($"Update personality description for {ourAnimals[i,0]} (likes or dislikes, tricks, energy level)", input => !string.IsNullOrEmpty(input));
                    
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
        // lookup and display cats with specific characteristic    
        case "7":
            
            searchValue = GetValidatedInput("Enter the specified characteristic you want to look for to find cat matches: ID, Age, Personality, Description, Nickname", input => !string.IsNullOrEmpty(input));
                
                switch (searchValue)
                {
                    case "id":
                        animalID = GetValidatedInput($"Enter an ID # to view cat information:", input => !string.IsNullOrEmpty(input) && input.Length==2);
                        
                        FindMatch(animalID, "cat", 0); 

                        break;
                    case "age":
                        animalAge = GetValidatedInput("Enter a valid age to view matching cats information:", input => !string.IsNullOrEmpty(input) && int.TryParse(input, out petAge));
                        
                        FindMatch(animalAge, "cat", 2);
                        break;
                    case "personality":
                        animalPersonalityDescription = GetValidatedInput("Enter personality description to find cat matches:", input => !string.IsNullOrEmpty(input));

                        FindMatch(animalPersonalityDescription, "cat", 5);

                        break;
                    case "description":

                        animalPhysicalDescription = GetValidatedInput("Enter physical description to find cat matches:", input => !string.IsNullOrEmpty(input));
                        
                        FindMatch(animalPhysicalDescription, "cat", 4);
                        
                        
                        break;
                    case "nickname":
                        animalNickname = GetValidatedInput("Enter Nickname to find cat matches:", input => !string.IsNullOrEmpty(input));
                       
                        FindMatch(animalNickname, "cat", 3);
                        
                        break;
                    default: 
                        Console.WriteLine("Characteristic not found.");
                        break;
                }        
                
            break;
        //lookup and display dogs with specific characteristics    
        case "8":
            searchValue = GetValidatedInput("Enter the specified characteristic you want to look for to find dog matches: ID, Age, Personality, Description, Nickname", input => !string.IsNullOrEmpty(input));
                
                switch (searchValue)
                {
                    case "id":
                        animalID = GetValidatedInput($"Enter an ID # to view dog information:", input => !string.IsNullOrEmpty(input) && input.Length==2);
                        
                        FindMatch(animalID, "dog", 0);

                        break;
                    case "age":
                        animalAge = GetValidatedInput("Enter a valid age to view matching dogs information:", input => !string.IsNullOrEmpty(input) && int.TryParse(input, out petAge));
                        
                        FindMatch(animalAge, "dog", 2);
                        break;
                    case "personality":
                        animalPersonalityDescription = GetValidatedInput("Enter personality description to find dog matches:", input => !string.IsNullOrEmpty(input));
                        
                        FindMatch(animalPersonalityDescription, "dog", 5);

                       
                        break;
                    case "description":

                        animalPhysicalDescription = GetValidatedInput("Enter physical description to find dog matches:", input => !string.IsNullOrEmpty(input));
                        
                        FindMatch(animalPhysicalDescription, "dog", 4);
                        
                        break;
                    case "nickname":
                        animalNickname = GetValidatedInput("Enter Nickname to find dog matches:", input => !string.IsNullOrEmpty(input));
                        
                        FindMatch(animalNickname, "dog", 3);
                        
                        break;
                    default: 
                        Console.WriteLine("Characteristic not found.");
                        break;
                }        
            
            break;
    }
    // pause code execution
    readResult = Console.ReadLine();
} 
while(menuSelection != "exit");
