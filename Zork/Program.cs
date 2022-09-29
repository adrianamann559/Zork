using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Zork
{
    
    class Program
    {
        public static Room CurrentRoom
        {
            get
            {
                return Rooms[Location.Row, Location.Column];
            }
        }
        private static readonly Dictionary<string, Room> RoomMap;

        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");
            Room previousRoom = null;
            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.WriteLine(CurrentRoom);
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());
               
                switch(command)
                {
                    case Commands.LOOK:
                        Console.WriteLine("This is an open field west of a white house, with a boarded up front door. \nA rubber mat saying 'Welcome to Zork!' lies by the door.");
                        break;

                    case Commands.QUIT:
                        Console.WriteLine("Thanks for playing");
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        if (Move(command) == false)
                        {
                          Console.WriteLine("The way is shut!");
                        }
                       break;

                    default:
                        Console.WriteLine("Unrecognized Command. Try Again, Buddy.");
                        break;
                }
            }
            if (previousRoom != CurrentRoom)
            {
                Console.WriteLine(CurrentRoom.Description);
                previousRoom = CurrentRoom;
            }

        }
        private static bool Move(Commands command)
        {
            Assert.IsTrue(IsDirection(command), "Invalid direction.");

            bool isValidMove = true; 
            switch (command)
            {
                case Commands.NORTH when Location.Row < Rooms.GetLength(0) - 1:
                    Location.Row++;
                    break;

                case Commands.SOUTH when Location.Row > 0:
                    Location.Row--;
                    break;

                case Commands.EAST when Location.Column < Rooms.GetLength(1) - 1:
                    Location.Column++;
                    break;

                case Commands.WEST when Location.Column > 0:
                    Location.Column--;
                    break;

                default:
                    isValidMove = false;
                    break;
            }

            return isValidMove;
        }


        private static Commands ToCommand(string commandString) =>
            Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;
        private static bool IsDirection(Commands command) => Directions.Contains(command);

        private static readonly Room[,] Rooms =
        {
            {new Room("Rocky Trail"), new Room("South of House"), new Room("Canyon View")},
            {new Room("Forest"), new Room ("West of House"), new Room ("Behind House")},
            {new Room("Dense Woods"), new Room("North of House"), new Room ("Clearing")}
        };
        private static void IntializeRoomDescriptions(string roomsFilename)
        {
            var roomMap = new Dictionary<string, Room>();
            foreach (Room room in Rooms)
            {
                roomMap.Add[room.Name, room] = room;
            }

            Room[] rooms = JsonConvert.DeserializeObject<Room[]>(File.ReadAllText(roomsFilename));
            foreach(Room room in rooms)
            {
                roomMap[room.Name].Description = room.Description;
            }
            
        }

        private static readonly List<Commands> Directions = new List<Commands>
        {
            Commands.NORTH,
            Commands.SOUTH,
            Commands.EAST,
            Commands.WEST,
        };

        private static (int Row, int Column) Location = (1, 1);
    }
}
