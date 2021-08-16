using System;
using System.Collections;
using System.Collections.Generic;

namespace Tankas
{
    class Program
    {
        static void Main(string[] args)
          
        {
            var cond = true;
            var forward = 0;
            var back = 0;
            var shoot = 0;
           
            while (cond)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("       TANK BATTLE       ");
                Console.WriteLine("------------------------");

                Console.WriteLine("MOVE FORWARD push 8: ");
                Console.WriteLine("MOVE BACK push 2: ");
                Console.WriteLine("TURN LEFT push 4: ");
                Console.WriteLine("TURN RIGHT push 6: ");
                Console.WriteLine("SHOOT push 0: ");
                Console.WriteLine("INFO push 1: ");
                Console.WriteLine("THE END push 3: ");
                Console.WriteLine("------------------------");

                var numIter = Convert.ToInt32(Console.ReadLine());
                

                switch (numIter)
                {
                    case 8:
                        Console.WriteLine("YOU MOVE FORWARD");
                        Tank.GoFoward();
                        forward++;
                        
                        break;
                    case 2:
                        Console.WriteLine("YOU MOVE BACK");
                        Tank.GoBack();
                        back++;
                        break;
                    case 4:
                        Console.WriteLine("YOU TURN LEFT");
                        Tank.TurnLeft();
                        break;
                    case 6:
                        Console.WriteLine("YOU TURN RIGHT");
                        Tank.TurnRight();
                        break;
                    case 0:
                        Console.WriteLine("YOU SHOOT");
                        shoot++;
                        Tank.Fire();
                        break;
                    case 1:
                        Console.WriteLine("INFO");
                        Tank.Info();
                        break;
                    case 3:
                        Console.WriteLine("THE END");
                        cond = false;
                        break;
                }
                
                Console.WriteLine(forward);
                Console.WriteLine(back);
                Console.WriteLine(shoot);


                Console.WriteLine("Hello World!");

            }
        }
        
    }
    class Tank
    {
        private static Direction direction = Direction.North;
        private static int positionNorthSouth = 0;
        private static string position = "";
        private static int positionWestEast = 0;
        private static int fireHow = 0;
        private static int fireNorth = 0;
        private static int fireSouth = 0;
        private static int fireWest = 0;
        private static int fireEast = 0;
        private static List<string> listOfFire = new List<string>();
        private static int actionGo = 0;
        public static void TurnLeft()
        {
            switch (direction)
            {
                case Direction.North:
                    direction = Direction.West;
                    break;
                case Direction.West:
                    direction = Direction.South;
                    break;
                case Direction.South:
                    direction = Direction.East;
                    break;
                case Direction.East:
                    direction = Direction.West;
                    break;
            }
        }

        public static void TurnRight()
        {
            switch (direction)
            {
                case Direction.North:
                    direction = Direction.East;
                    break;
                case Direction.East:
                    direction = Direction.South;
                    break;
                case Direction.South:
                    direction = Direction.West;
                    break;
                case Direction.West:
                    direction = Direction.North;
                    break;
            }
        }

        private static void Positon()
        {
            if (positionNorthSouth > 0 && positionWestEast > 0)
            {
                position = $"North: {positionNorthSouth}, West: {positionWestEast}";
            }
            else if (positionNorthSouth > 0 && positionWestEast < 0)
            {
                position = $"North: {positionNorthSouth}, East: {Math.Abs(positionWestEast)}";
            }
            else if (positionNorthSouth < 0 && positionWestEast > 0)
            {
                position = $"South: {Math.Abs(positionNorthSouth)}, West: {positionWestEast}";
            }
            else if (positionNorthSouth < 0 && positionWestEast < 0)
            {
                position = $"South: {Math.Abs(positionNorthSouth)}, East: {Math.Abs(positionWestEast)}";
            }
            else if (positionNorthSouth > 0 && positionWestEast == 0)
            {
                position = $"North: {positionNorthSouth}";
            }
            else if (positionNorthSouth == 0 && positionWestEast < 0)
            {
                position = $"East: {Math.Abs(positionWestEast)}";
            }
            else if (positionNorthSouth < 0 && positionWestEast == 0)
            {
                position = $"South: {Math.Abs(positionNorthSouth)}";
            }
            else if (positionNorthSouth == 0 && positionWestEast > 0)
            {
                position = $"West: {positionWestEast}";
            }
            else
            {
                position = "0";
            }
        }

        public static void Info()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine();
            Positon();
            Console.WriteLine(
                $"Tank position: {position}.\n" +
                $"Tank direction: {direction}.");
            if (fireHow > 0)
            {
                Console.WriteLine($"Tank fired: {fireHow} times");
            }
            if (fireNorth > 0)
            {
                Console.WriteLine($"Tank fired North: {fireNorth} times");
            }
            if (fireSouth > 0)
            {
                Console.WriteLine($"Tank fired South: {fireSouth} times");
            }
            if (fireWest > 0)
            {
                Console.WriteLine($"Tank fired West: {fireWest} times");
            }
            if (fireEast > 0)
            {
                Console.WriteLine($"Tank fired East: {fireEast} times");
            }
            if (fireHow > 0)
            {
                foreach (string text in listOfFire)
                {
                    Console.WriteLine(text);
                }
            }
        }

        public static void GoFoward()
        {

            if (actionGo < 10)
            {
                actionGo++;

                switch (direction)
                {
                    case Direction.North:
                        positionNorthSouth++;
                        break;
                    case Direction.East:
                        positionWestEast--;
                        break;
                    case Direction.South:
                        positionNorthSouth--;
                        break;
                    case Direction.West:
                        positionWestEast++;
                        break;
                }
            }
        }

        public static void GoBack()
        {

            if (actionGo < 100)
            {
                actionGo++;

                switch (direction)
                {
                    case Direction.North:
                        positionNorthSouth--;
                        break;
                    case Direction.East:
                        positionWestEast++;
                        break;
                    case Direction.South:
                        positionNorthSouth++;
                        break;
                    case Direction.West:
                        positionWestEast--;
                        break;
                }
            }
        }

        public static void Fire()
        {
            if (fireHow < 100)
            {
                fireHow++;
                Positon();

                switch (direction)
                {
                    case Direction.North:
                        fireNorth++;
                        break;
                    case Direction.East:
                        fireEast++;
                        break;
                    case Direction.South:
                        fireSouth++;
                        break;
                    case Direction.West:
                        fireWest++;
                        break;
                }
                listOfFire.Add($"Tank fire num. {fireHow}: direction = {direction}, position ({position})");
            }

        }


    }
    enum Direction
    {
        North,
        East,
        West,
        South
    }
}
