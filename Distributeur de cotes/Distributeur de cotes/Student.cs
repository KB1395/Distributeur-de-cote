﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributeur_de_cotes
{
   public class Student:Person
    {
        //To create my variable
        private List<Evaluation>  cours; //with all the cursus

        //My constructor + base
        //base call the constructor from person
        public Student(string lastname, string firstname) : base(lastname,firstname)
        {
            cours = new List<Evaluation>();
        }

        //The different method

        //to Add the Eval
        public void Add(Evaluation eval)
        {
            
            cours.Add(eval);
            
        }

        //to make the average of all the eval
        public string Average()
        {
            var sum = 0;
            string result = "";
            
            foreach (var n in this.cours)

                sum += n.Note();
            try { 
                sum = sum / this.cours.Count;
                result = "The student average is:";
                result +=Convert.ToString(sum);
                return result;
                
            }
            catch(DivideByZeroException)
            {
                Convert.ToString(sum);
                result="Can't do student average: No evalutaions yet";
                return result;
            }
            
        }

       
        public string Bulletin()
        { 
            Dictionary<Activity, Tuple<int, int>> cotesforActivity = new Dictionary<Activity, Tuple<int, int>>();
            
            foreach (var point in cours){
                

                try
                {
                    
                    Tuple<int, int> t = cotesforActivity[point.Activity];
                    cotesforActivity[point.Activity] = new Tuple<int, int>(t.Item1 + point.Note(), t.Item2 + 1);
                }
                catch (KeyNotFoundException)
                {
                    cotesforActivity.Add(point.Activity, new Tuple<int, int>(point.Note(), 1));
                }
            }

            
            string bulletin = this.Lastname + " " + this.Firstname + "\n";
            
            
            foreach (KeyValuePair<Activity, Tuple<int, int>> entry in cotesforActivity)
            {
                
                bulletin += entry.Key.Code + " " + entry.Key.Name + " " + entry.Key.ECTS + " " + entry.Value.Item1 / entry.Value.Item2 + "\n";
            }

            

            return bulletin;
        }
    }

}
