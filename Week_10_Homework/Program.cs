/*
 * Shooter.cs: This program will determine who has the better shot among three men by used conditional logic, variables
 * and class objects. 
 * Name: Spencer Unitt
 * Module: Week 10 Homework 
 * 
 * Algorithm: 
 * 1. Create a new class named Shooter.cs
 * 2. In the class define the following
 *    Three variables, one string, one bool and one double
 *    A constructor that takes in a string and a double. Initailize all variables in the constructor, bool = true
 *    A public void funtion that takes in a class object and alters bool based off conditions listed below.
 * 3. In the void function, create a new Random object and a variable assigned to a random number between 1-100
 *    If the the random number is less than the accuracy (double) of the shooter, Then set the bool value to false
 * 4. In the main function create three new shooter objects with a name and accuracy
 *    Have each object call the shoot function
 *    Once one duel has been solved loop through the program 10000 times and determine who wins the most
 *      
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_10_Homework
{
    class Program
    {
        static void Main(string[] args)
        {   
            // Creates new class objects
            Shooter aaron = new Shooter("Aaron", 33.3);
            Shooter bob = new Shooter("Bob", 50.0);
            Shooter charlie = new Shooter("Charlie", 99.5);
            
            // Counters for the program below
            int aaronCount = 0, bobCount = 0, charlieCount = 0;
            int loopCount = 0;

            // loops 10000 times
            while (loopCount <= 10000)
            {
                // Works through each option and determines who takes the next shot based off who is still alive
                aaron.shootTarget(charlie, aaron);
                bob.shootTarget(charlie, bob);

                // if charlie is dead after the first two shots above then aaron and bob have a duel
                if (charlie.alive == false)
                {
                    while (bob.alive == true && aaron.alive == true)
                    {
                        aaron.shootTarget(bob, aaron);
                        if (bob.alive == false)
                        {
                            break;
                        }
                        bob.shootTarget(aaron, bob);
                    }
                    if (aaron.alive == true && bob.alive == false)
                    {
                        aaronCount++;                        
                    }
                    else if (bob.alive == true && aaron.alive == false)
                    {
                        bobCount++;
                       
                    }
                }
                // otherwise charlie shots at bob and likely kills him
                else
                {
                    charlie.shootTarget(bob, charlie);
                }

                // if bob dies then charlie and aaron duel
                if (bob.alive == false)
                {
                    aaron.shootTarget(charlie, aaron);

                    if (charlie.alive == true)
                    {
                        charlie.shootTarget(aaron, charlie);
                    }

                    if (aaron.alive == false)
                    {
                        charlieCount++;
                    }

                }

                // keeps track of a current loop
                loopCount++;
                // resurects everyone for the next duel
                aaron.alive = true;
                bob.alive = true;
                charlie.alive = true;

            }   
          
            // Shows the results to the user
            Console.WriteLine("Arron wins: " + aaronCount + " times.");
            Console.WriteLine("Bob wins: " + bobCount + " times.");
            Console.WriteLine("Charlie wins: " + charlieCount + " times");
            

            Console.ReadLine();
           
        }
    }
}
