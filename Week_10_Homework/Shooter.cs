using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_10_Homework
{
    class Shooter
    {
        // variables used throughout the class
        public string name { get; set; }  // keeps track of name
        public double shot { get; set; }  // keeps track of shot
        public bool alive { get; set; }   // keeps track of user being alive
        
        public Shooter(string name, double shot) // constructor that takes in a string and double
        {
            // assign all the variables
            this.name = name;
            this.shot = shot;
            alive = true;
        }

        public void shootTarget(Shooter target, Shooter shooter) // uses a class object in parameter
        {
            Random rand = new Random(); // creates a new rand object
            
            int bang = rand.Next(1, 100); // sets another variable equal to the random object

            if(bang < shooter.shot) // if the shot is within range
            {
                target.alive = false; // set the target to dead
            }
        }

        

            
        
      
    }
}
