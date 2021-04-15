
using System;

namespace Project
{
    class Program
    {
        // storing movie names and ratings in dynamic array
        static string[] moviename;
        static string[] rating ;

        //Admin panel login
        public static void AdminLogin(int n)
        {
            //Hardcoded password for admin login!
            string adminPass = "aaaa";

            //Attempt counter
            int attempt = n;

            //Taking user input as admin password
            Console.WriteLine("Please Enter The Admin Password:");
            string temp = Console.ReadLine();

            //Checking the passwords validity
            if (temp == adminPass)
            {
                //Take to admin panel array
                admin();
            }

            else if (temp == "b" || temp == "B")
            {
                //Taking back to Main app screen
                AppIntro();
            }
            else
            {
                if (attempt > 1)
                {
                    //Error message for admins login
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You entered an Invalid password.");
                    Console.ForegroundColor = ConsoleColor.White;
                    attempt = attempt - 1;
                    Console.WriteLine("You have {0} more attempts to enter the correct password OR Press B to go back to the previous screen.", attempt);
                    //Taking recurring password input
                    AdminLogin(attempt);
                }
                else
                {
                    //Taking back to Main app screen
                    AppIntro();
                }
            }
        }

        //App entry point
        public static void AppIntro()
        {
            //App header text
            string star = "************************************";
            string heading = "*** Welcome to MoviePlex Theatre ***";

            //Centering app header text
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (star.Length / 2)) + "}", star));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (heading.Length / 2)) + "}", heading));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (star.Length / 2)) + "}", star));

            //App user profile heading
            Console.WriteLine("Please Select From The Following Options");

            //App options
            Console.WriteLine("\t1: Administratior");
            Console.WriteLine("\t2: Guest");

            //Variable for user profile selection
            int user_profile;

            //Try catch to handle exception
            try
            {
                //User selection header
                Console.Write("Selection: ");

                //User input
                user_profile = Convert.ToInt32(Console.ReadLine());

                //Checking user input
                if (user_profile == 1)
                {
                    //Redirect to admin login
                    AdminLogin(5);
                }
                else if (user_profile == 2)
                {
                    //Redirect to guest login
                    GuestApp();
                }

                else
                {
                    //Provide error message with instruction
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Selection!!");
                    Console.WriteLine("Please enter 1 or 2!");
                    Console.ForegroundColor = ConsoleColor.White;

                    //Again take input from the user
                    AppIntro();
                }
        }
            catch
            {
                //Provide error message with instruction
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Selection!!");
                Console.WriteLine("Please select User Profile by typing only 1 or 2");
                Console.ForegroundColor = ConsoleColor.White;

                //Again take input from the user
                AppIntro();
    }
}
        public static void admin()
        {
            string star = "************************************";
            string heading = "*** Welcome to MoviePlex Theatre ***";

            //Centering app header text
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (star.Length / 2)) + "}", star));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (heading.Length / 2)) + "}", heading));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (star.Length / 2)) + "}", star));

            // Admin panel
            Console.WriteLine("WELCOME TO ADMIN PANEL");
            Console.WriteLine("How many movies are playing today?");
            // reading values for movies to ne screened
            int movie = Convert.ToInt32(Console.ReadLine());

            // For the invalid input (>10)
            if (movie > 10)
            {
                Console.WriteLine("Movies played cannot be more than 10");
                // again ask for admin input
                admin();
            }

            // For the valid input
            else if (movie<=10 && movie>0)
            {

                Console.WriteLine("FOLLOWING RATINGS ARE ALLOWED :");
                Console.WriteLine("\t ***************");

                Console.ForegroundColor = ConsoleColor.Green;

                // Ratings Display
                Console.WriteLine("G     - General Audience, all ages are permitted");
                Console.WriteLine("PG    - Parental Guidance Suggested,for 10 years or older.");
                Console.WriteLine("PG-13 - Parents Strongly Cautioned, for 13 years or older");
                Console.WriteLine("R     - Restricted, For 15 years old or above");
                Console.WriteLine("NC-17 - Adults Only, for 17 years or older.");

                Console.ForegroundColor = ConsoleColor.White;
                // storing movie names and age ratings in array
                moviename = new string[movie];
                rating = new string[movie];

                int count = 0;
                // taking movie and rating input from admin
                for (int j = 0; j < movie; j++)
                {
                    count++;
                    Console.WriteLine("Enter the {0} Movie's Name : {1} ", count, moviename[j]);
                    moviename[j] = Console.ReadLine();

                    bool isRating = false;
                    while(!isRating)
                    {
                        Console.Write("Enter the Rating for the {0} Movie : ", count);
                        rating[j] = Console.ReadLine();
                        if (rating[j] == "G" || rating[j] == "PG" || rating[j] == "PG-13" || rating[j] == "R" || rating[j] == "NC-17")
                        {
                            Console.WriteLine("You have added movie successfully.");
                            isRating=true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter valid rating from above.");
                        }
                    }
                }

                // List of movies to be screened
                Console.WriteLine("The Movies Played today are listed as below :");
                for (int i = 0; i < moviename.Length; i++)
                {
                    Console.WriteLine("{0}. {1}", i+1, moviename[i]);
                }

                // Asking for admin satisfaction for the list of movies
                string satis;
                Console.WriteLine("Are you Satisfied with the movies listed Above (Y/N)?");
                satis = Console.ReadLine();
                if (satis == "y" || satis == "Y")
                {
                    // Return to the Main screen
                    AppIntro();
                }
                else if (satis == "n" || satis == "N")
                {
                    // Again take input from the admin
                    admin();
                }
                else
                {
                    Console.WriteLine("Enter Only Y or N");
                }
            }
            else
            {
                // Again ask for admin input
                Console.WriteLine("Enter a Valid Input.");
                admin();
            }
    }

        //region guestSection
        static void GuestApp()
        {
            
            //App header text
            string star = "************************************";
            string heading = "*** Welcome to MoviePlex Theatre ***";

            //Centering app header text
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (star.Length / 2)) + "}", star));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (heading.Length / 2)) + "}", heading));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (star.Length / 2)) + "}", star));

            if(moviename?.Length > 0)
            {
                bool isAgeValid = false;
                while(!isAgeValid)
                {
                    DisplayMovie();
                    int movieSelected = MovieSelection();
                    isAgeValid = AgeVerification(movieSelected);
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Press M to go back to the Guest Main Menu");
                Console.WriteLine("Press S to go back to the Start Page");
                string input = Console.ReadLine();
                if(input == "M" || input == "m")
                {
                    // go to guest main menu
                    GuestApp();
                }
                else if(input == "S" || input == "s")
                {
                    //go to the start page
                    AppIntro();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter valid alphabet.");
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("There are no movies playing today.");

                Console.WriteLine("Press B to go back to the Start Page");
                string input = Console.ReadLine();

                if (input == "b" || input == "B")
                {
                    //go to the start page
                    AppIntro();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter valid alphabet.");
                    GuestApp();
                }

            }
        }

        static void DisplayMovie()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"There are {moviename.Length} movies playing today. Please choose from the following movies: ");
            for (int i = 0; i < moviename.Length; i++)
            {
                Console.WriteLine($"\t {i + 1}. {moviename[i]} {{{rating[i]}}}");
            }
        }

        static int MovieSelection()
        {
            int selectedMovie = -1;
            while (selectedMovie == -1)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Which movie would you like to watch: ");
                    int number = Convert.ToInt32(Console.ReadLine());

                    if (number<=0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter positive number.");
                    }
                    else
                    {
                        if (number <= moviename.Length)
                        {
                            //valid 
                            selectedMovie = number - 1;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please select appropriate option.");
                        }

                    } 
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter valid number.");
                }
            }
            return selectedMovie;  
        }

        static bool AgeVerification(int selectedMovie)
        {
           
            // age verification
            bool isAgeValid = false;
            while (!isAgeValid)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Please enter your age for verification: ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    if(age<=0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter positive number.");
                    }
                    else
                    {
                        bool ageVerify = false;
                        switch (rating[selectedMovie])
                        {
                            case "G" or "g":
                                ageVerify = true;
                                break;
                            case "PG" or "pg":
                                ageVerify = age >= 10;
                                break;
                            case "PG-13" or "pg-13":
                                ageVerify = age >= 13;
                                break;
                            case "R" or "r":
                                ageVerify = age >= 15;
                                break;
                            case "NC-17" or "nc-17":
                                ageVerify = age >= 17;
                                break;
                        }

                        if (ageVerify)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\nEnjoy the movie !\n");
                            isAgeValid = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sorry, you are under age limit for this movie.\n Please select another movie.");
                            //go to movie list 
                            break;
                        }
                    }   
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter valid number");
                }
            }
            return isAgeValid;
        }
        //endregion
        static void Main(string[] args)
        {
            //Calling app starting method
            AppIntro();
        }
    }
}

