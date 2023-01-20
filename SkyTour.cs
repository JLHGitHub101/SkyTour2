
////////////////////////////////////////////////////////////////////////////////////////
/// Date:       2023-01-15
/// Author:     James Lee Harris
/// TINFO:      230A -C# Programming
/// Assignment: Cs1sky
///////////////////////////////////////////////////////////////////////////////////////
///     *** Helicopter Tour Booking and Cost Calculator *** 
///  Description: This program is used to book and calculate cost 
///  of passengers for tours to ount Rainer. The program takes  
///  name, age and weight information about the passenger.This 
///  information is used to book and determine tours cost for a 
///  passenger at the time of booking. This program uses 2 classes.
///////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Linq.Expressions;

//////////////////////////////////////////////////////////////////////////////////////////////////
/// Change History
/// Date                Developer               Description
/// 2023-01-15          James Harris            Intial Program Coding
/// 
/// 2023-01-16          James Harris            Defined Variables, Inserted Input Logic,
///                                             Created Classes SkyTourInc, SkyTourPassengers
///                                             Created Data & Output Processing Logic 
///                                             
/// 2023-1 01-17        James Harris            Updated Comments sections, Corrected Data
///                                             processing logic, added simple exception handling
//////////////////////////////////////////////////////////////////////////////////////////////////


namespace SkyTourInc
{

    ///////////////////////////////////////////////////////////////////////////////////
    /// SkyTour is 1 of 2 class in the SkyTourInt namespace. It contains the main method
    /// for the program. This class accepts user input and used it to populate the 
    /// skyTourPassenger object that is created at program start. This class also holds
    /// SkyTour is 1 of 2 class in the SkyTourInt namespace. It contains the main method
    /// the logic to calculate tour cost from passenger information. The class then uses
    /// SkyTour is 1 of 2 class in the SkyTourInt namespace. It contains the main method
    /// the entered information and calculates to create a output to the console for the user.
    ///////////////////////////////////////////////////////////////////////////////////
    internal class SkyTour
    {
        ///////////////////////////////////////////////////////////////////////////////
        /// This method contains the Input Data for populating the skyTourPassenger 
        /// class. The logic operations needed to determine tour cost and the output
        /// logic that displays back to the user at program completion.
        ///////////////////////////////////////////////////////////////////////////////
        static void Main()
        {
            
            decimal passengerWeight = 0;
            int passengerAge = 0;

            SkyTourPassenger skyTourPassenger = new SkyTourPassenger();

            ////////////////////////////////////////////////////////////////////////////
            /// User UI
            /// 1. Tell user why they want to use this Application
            /// 2. Tell user how to use this Application
            ////////////////////////////////////////////////////////////////////////////

            Console.WriteLine(@"
******************************************************************
********** SkyTour's Passgener Booking & Cost Estimator **********
******************************************************************
In order to book a tour with SkyTour, Inc, the system will require 
users first & last name, age and weight to be enterd when prompted.
This information will be used by the system to calculate the cost 
of the tour and provide an on screen confirmation of the  booking 
at completion.
*******************************************************************
*******************************************************************
******************************************************************* ");

            //////////////////////////////////////////////////////////////////////////////
            /// Input Process
            /// User will be prompted to enter first and last name, age and weight at time 
            /// of booking.This information is taken and stored in varibles before being
            /// assigned to a property of the SkyTourPassenger class.
            /////////////////////////////////////////////////////////////////////////////

            Console.Write("\nEnter SkyTour Passgeners First Name: ");
            string passengerFirstName = Console.ReadLine();
            skyTourPassenger.FirstName = passengerFirstName;

            Console.Write("Enter SkyTour Passgeners Last Name: ");
            string passengerlastName = Console.ReadLine();
            skyTourPassenger.LastName = passengerlastName;

            //////////////////////////////////////////////////////////////////////////////
            /// Prevent a 0 division error in Data Processing by not allowing 0 to be 
            /// entered as a value for weight or age when prompted. Age block required 
            /// an whole number but does not guard against other forms of numbers that
            /// would create an error. Both wieght and age must yield non-zero numbers
            /// before the values are stored in the SkyTourPassenger object.
            /////////////////////////////////////////////////////////////////////////////
          
            while (passengerWeight == 0 && passengerAge == 0)

            {
                do
                {
                    try
                    {
                        Console.Write("Enter SkyTour Passgeners age (i.e. 17,25,36,56): ");
                        passengerAge = int.Parse(Console.ReadLine());
                    }

                    catch (System.FormatException) { Console.WriteLine("Enter only whole numbers"); continue; } // Catch format error and continue code excution. 
                                        
                }
                while (passengerAge <= 0);

                do
                {
                    try
                    {
                        Console.Write("Enter SkyTour Passgeners weight in U.S Pounds (i.e. 110, 220, 225): ");
                        passengerWeight = decimal.Parse(Console.ReadLine());
                    }

                    catch(System.FormatException) { Console.WriteLine("Enter only numbers"); continue; } // Catch format error and continue code excution. 
                }
                while (passengerWeight <= 0);

                skyTourPassenger.Weight = passengerWeight;
                skyTourPassenger.Age = passengerAge;

                Console.WriteLine("\n\n**********  Passenger Information Accepted  **********\n\n");

            }

            /////////////////////////////////////////////////////////////////////////////
            /// Data Processing
            /// Read value from SkyTourPassenger.weight and convert value from lbs to Kg.
            /// Check if value is greater then 100 Kg if not multiple weight by $1.00. 
            /// If greater than 100 substract 100 from the passengerWeightKg value and 
            /// multiple by $1.50 and add $100
            /////////////////////////////////////////////////////////////////////////////

            double passengerWeightKg = (double) skyTourPassenger.Weight/2.205;
            decimal passengerCost;
            if ((passengerWeightKg - 100) <= 0)
            {
                passengerCost = (decimal)passengerWeightKg * 1.00M;
            }
            else
            {
                double passengerWeightOvHu = passengerWeightKg - 100;
                passengerCost = ((decimal)passengerWeightOvHu * 1.5M) + ((decimal)100.00);

            }

            //////////////////////////////////////////////////////////////////////////////
            /// Output Processing
            /// Display information given about the passenger and the calculations for the
            /// cost of the tour to the user on the console. 
            //////////////////////////////////////////////////////////////////////////////

            Console.WriteLine($"Passengers Name: {skyTourPassenger.FirstName + " " + skyTourPassenger.LastName}");
            Console.WriteLine($"Passengers Age: {skyTourPassenger.Age} years old");
            Console.WriteLine($"Weight: {skyTourPassenger.Weight} lbs. ({passengerWeightKg} Kg) price {passengerCost:C2}");
            Console.WriteLine($"Report Timestamp: {DateTime.Now}");

        }
    
    }
}
