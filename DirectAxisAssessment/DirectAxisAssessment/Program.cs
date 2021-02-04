using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;

namespace DirectAxisAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(AppContext.BaseDirectory))
            .AddJsonFile("appsettings.json", optional: false);

            var _configuration = builder.Build();
            var selectedCars = new List<Car>();
            var validSelection = false;
            var tracks = new List<Track>();

            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            Console.WriteLine("----------- WELCOME TO DIRECT AXIS RACING GAME -----------");
            Console.WriteLine();

            using (var connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var query = "procSelectTracks";

                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tracks.Add(new Track()
                            {
                                TrackId = Convert.ToInt32(reader["TrackID"]),
                                TrackName = reader["TrackName"].ToString(),
                                TrackValues = reader["TrackValues"].ToString()
                            });
                        }

                        Console.WriteLine();
                    }
                }
            }

            var selection = 0;
            Track selectedTrack = null;

            do
            {
                Console.WriteLine("Please choose track by selecting a number below. Alternatively you can type 999 to input your own:");
                Console.WriteLine();

                for (int i = 0; i < tracks.Count; i++)
                {
                    Console.WriteLine($"{tracks[i].TrackId}. {tracks[i].TrackName}");
                }

                selection = Convert.ToInt32(Console.ReadLine());

                selectedTrack = tracks.FirstOrDefault(x => x.TrackId == selection);

                if (selectedTrack == null && selection != 999)
                {
                    Console.WriteLine("Invalid Selection. Please try again");
                    Console.WriteLine();
                }
                else
                {
                    validSelection = true;
                    Console.WriteLine();
                }

            } while (!validSelection);


            var cars = new List<Car>();

            // Get the cars here before we move on.
            using (var connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var query = "procSelectCars";

                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cars.Add(new Car()
                            {
                                CarID = Convert.ToInt32(reader["CarID"]),
                                CarName = reader["CarName"].ToString(),
                                Acceleration = Convert.ToInt32(reader["Acceleration"]),
                                Braking = Convert.ToInt32(reader["Braking"]),
                                Cornering = Convert.ToInt32(reader["Cornering"]),
                                TopSpeed = Convert.ToInt32(reader["TopSpeed"]),
                                TimeStamp = Convert.ToDateTime(reader["TimeStamp"])
                            });
                        }
                    }
                }
            }

            // Ask the user how many cars s/he would like to race.
            validSelection = false;
            int selectedCarsCount = 0;

            do
            {
                Console.Write($"How many cars would you like to race? Minimum = 3 / Maximum = {cars.Count}: ");
                selectedCarsCount = Convert.ToInt32(Console.ReadLine());

                if (selectedCarsCount >= 3 && selectedCarsCount <= cars.Count)
                {
                    validSelection = true;
                }
                else
                {
                    Console.WriteLine("Invalid Selection. Please try again.");
                    Console.WriteLine();

                }
            } while (!validSelection);

            var indx = 0;

            do
            {
                foreach (var car in cars)
                {
                    Console.WriteLine($"{car.CarID}. {car.CarName}");
                }

                Console.WriteLine();
                Console.Write($"Please select car number {(indx + 1)}: ");

                var selectedCarId = Convert.ToInt32(Console.ReadLine());

                var selectedCar = cars.FirstOrDefault(x => x.CarID == selectedCarId);

                if (selectedCar == null)
                {
                    Console.WriteLine("Invalid Selection.");
                    Console.WriteLine();
                }
                else
                {
                    selectedCars.Add(selectedCar);
                    cars.Remove(selectedCar);
                    indx++;
                }

            } while (indx != selectedCarsCount);

            List<Car> racingVehicles = null;

            if (selection == 999)
            {
                racingVehicles = CreateOwnTrack(tracks.Count, selectedCars, connectionString);
            }
            else
            {
                racingVehicles = PerformRace(selectedTrack, selectedCars);
            }

            Console.WriteLine();
            Console.WriteLine();

            for (int i = 5; i > 0; i--)
            {
                Console.WriteLine("Race in progress. Completing in " + i);
                Thread.Sleep(1000);
            }

            Console.WriteLine();
            Console.WriteLine("Calculating Results...");
            Thread.Sleep(2000);
            Console.WriteLine();

            for (int i = 0; i < racingVehicles.Count; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine($"WINNER: {racingVehicles[i].CarName} managed to score {racingVehicles[i].Score}");
                }
                else
                {
                    Console.WriteLine($"Place Number {(i + 1)}: {racingVehicles[i].CarName} managed to score {racingVehicles[i].Score}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Race completed. Thanks for playing.");
            Console.ReadKey();
        }

        private static List<Car> PerformRace(Track selectedTrack, List<Car> selectedCars)
        {
            var racedCars = new List<Car>();

            foreach (var car in selectedCars)
            {
                var carScore = 0;

                foreach (var character in selectedTrack.TrackValues)
                {
                    int thisChar = character - '0';

                    if (Convert.ToInt32(thisChar).Equals(1))
                    {
                        carScore += car.Acceleration;
                        carScore += car.TopSpeed;
                    }
                    else if (Convert.ToInt32(thisChar).Equals(0))
                    {
                        carScore += car.Braking;
                        carScore += car.Cornering;
                    }
                }

                car.Score = carScore;
                racedCars.Add(car);
            }

            return racedCars.OrderByDescending(x => x.Score).ToList();
        }

        private static List<Car> CreateOwnTrack(int tracksCount, List<Car> selectedCars, string connectionString)
        {
            Console.WriteLine();
            Console.Write("Please enter the track name: ");
            var trackName = Console.ReadLine().ToString();

            var validSelection = false;
            var toSaveTrack = false;
            var trackValues = string.Empty;

            do
            {
                Console.Write("Please enter the track values, 0 for turns, 1 for straight: ");
                trackValues = Console.ReadLine().ToString();
                var textValid = true;

                foreach (var character in trackValues)
                {
                    int thisChar = character - '0';
                    if (!Convert.ToInt32(thisChar).Equals(0) && !Convert.ToInt32(thisChar).Equals(1))
                    {
                        textValid = false;
                        break;
                    }
                }

                if (textValid)
                {
                    validSelection = true;
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Your track values can only contain 1 or 0. Please try again.");
                    Console.WriteLine();
                }
            } while (!validSelection);

            validSelection = false;

            do
            {
                Console.Write("Would you like to save this new track? Y/N: ");
                var saveTrack = Console.ReadLine().ToString();

                if (saveTrack.ToLower().Equals("y") || saveTrack.ToLower().Equals("n"))
                {
                    validSelection = true;
                    toSaveTrack = saveTrack.ToLower().Equals("y");
                }
                else
                {
                    Console.WriteLine("Invalid Selection. Please try again");
                    Console.WriteLine();
                }
            } while (!validSelection);

            if (toSaveTrack)
            {
                SaveTrack(trackName, trackValues, connectionString);
            }

            var newTrack = new Track()
            {
                TrackId = tracksCount + 1,
                TrackName = trackName,
                TrackValues = trackValues
            };

            return PerformRace(newTrack, selectedCars);
        }

        private static void SaveTrack(string trackName, string trackValues, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var query = "procInsertNewTrack";

                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TrackName", trackName);
                    command.Parameters.AddWithValue("@TrackValues", trackValues);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}