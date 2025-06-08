using AgentsProject;
using System;
using System.Collections.Generic;

class AgentsMenu
{
    private Dal dal = new Dal();
    public void Menu()
    {

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n===== AGENT MANAGEMENT MENU =====");
            Console.WriteLine("1. Add Agent");
            Console.WriteLine("2. Display All Agents");
            Console.WriteLine("3. Update Agent Location");
            Console.WriteLine("4. Delete Agent");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string input = Console.ReadLine();


            switch (input)
            {
                case "1":
                    AddAgent();
                    break;
                case "2":
                    DisplayAllAgents();
                    break;
                case "3":
                    UpdateAgentLocation();
                    break;
                case "4":
                    DeleteAgent();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    private void AddAgent()
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Code Name: ");
        string codeName = Console.ReadLine();

        Console.Write("Enter Real Name: ");
        string realName = Console.ReadLine();

        Console.Write("Enter Location: ");
        string location = Console.ReadLine();

        Console.Write("Enter Status: ");
        string status = Console.ReadLine();

        Console.Write("Enter Missions Completed: ");
        int missions = int.Parse(Console.ReadLine());

        Agent newAgent = new Agent(id, codeName, realName, location, status, missions);
        dal.AddAgent(newAgent);
        Console.WriteLine("Agent added successfully.");
    }
    private void DisplayAllAgents()
    {
        List<Agent> agents = dal.AddAllAgentsToList();

        foreach (Agent agent in agents)
        {
            Console.WriteLine($"ID: {agent.id}, Code Name: {agent.codeName}, Real Name: {agent.realName}, Location: {agent.location}, Status: {agent.status}, Missions: {agent.missionsCompleted}");
        }
    }

    private void UpdateAgentLocation()
    {
        Console.Write("Enter Agent ID to update: ");
        int updateId = int.Parse(Console.ReadLine());

        Console.Write("Enter new Location: ");
        string newLocation = Console.ReadLine();

        dal.UpdateAgentLocation(updateId, newLocation);
    }
    private void DeleteAgent()
    {
        Console.Write("Enter Agent ID to delete: ");
        int deleteId = int.Parse(Console.ReadLine());

        dal.DeleteAgent(deleteId);
        Console.WriteLine("Agent deleted.");
    }
}



