using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace AgentsProject
{
    internal class Dal
    {
        private MySqlConnection ConnectToDataBase()
        {
            string connStr = "server=localhost;username=root;password=;database=eagleEyeDB";
            return new MySqlConnection(connStr);
        }


        public void AddAgent(Agent agent)
        {
            using (MySqlConnection connection = ConnectToDataBase())
            {
                try
                {
                    connection.Open();
                    string query = $"INSERT INTO agentdetails (id, codeName, realName, location, status, missionsCompleted) " +
                                   $"VALUES ('{agent.id}', '{agent.codeName}', '{agent.realName}', '{agent.location}', '{agent.status}', {agent.missionsCompleted});";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

        }
        public void UpdateAgentLocation(int agentId, string newLocation)
        {
            using (MySqlConnection connection = ConnectToDataBase())
            {
                try
                {
                    connection.Open();
                    string query = $"DELETE FROM agentdetails WHERE id = {agentId};";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    int updatedRow = command.ExecuteNonQuery();

                    if (updatedRow == 0)
                    {
                        Console.WriteLine("No agent found with the given ID.");
                    }
                    else
                    {
                        Console.WriteLine("Agent location updated successfully.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        public void DeleteAgent(int agentId)
        {
            using (MySqlConnection connection = ConnectToDataBase())
            {
                try
                {
                    connection.Open();
                    string query = $"DELETE FROM agentdetails WHERE '{agentId}' = {agentId};";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        Console.WriteLine("No agent found with the given ID.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
        }
        public List<Agent> AddAllAgentsToList()
        {
            List<Agent> agents = new List<Agent>();

            using (MySqlConnection connection = ConnectToDataBase())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM agentdetails;";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Agent agent = new Agent(
                            reader.GetInt32("id"),
                            reader.GetString("codeName"),
                            reader.GetString("realName"),
                            reader.GetString("location"),
                            reader.GetString("status"),
                            reader.GetInt32("missionsCompleted")
                        );

                        agents.Add(agent);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return agents;
        }

        public void DisplayAgents()
        {
            List<Agent> agents = AddAllAgentsToList();

            foreach (Agent agent in agents)
            {
                Console.WriteLine($"ID: {agent.id}");
                Console.WriteLine($"Code Name: {agent.codeName}");
                Console.WriteLine($"Real Name: {agent.realName}");
                Console.WriteLine($"Location: {agent.location}");
                Console.WriteLine($"Status: {agent.status}");
                Console.WriteLine($"Missions Completed: {agent.missionsCompleted}");
                Console.WriteLine("---------------------------");
            }
        }
    }
    }


        
    
