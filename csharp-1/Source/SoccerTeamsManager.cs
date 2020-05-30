using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using Codenation.Challenge.Exceptions;
using Source;

namespace Codenation.Challenge
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {
        
        private List<Player> Players { get; set; }
        private List<Team>  Teams { get; set; }
        private Captain Captain { get; set; }

        public SoccerTeamsManager()
        {
        }

        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            if (Teams.Equals(id))
                throw new UniqueIdentifierException("Error! this Id is in used. ");
            Teams.Add(new Team(id, name, createDate, mainShirtColor, secondaryShirtColor));
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {

            if (Players.Contains(new Player(id))) //if id players exists. 
                throw new UniqueIdentifierException("Error! this Id is in used. ");
            if (!Teams.Contains(new Team(teamId))) //if id team not exists
                throw new TeamNotFoundException("Error! Team Id was not found. ");
            Players.Add(new Player(id, teamId, name, birthDate, skillLevel, salary));//add player
        }

        public void SetCaptain(long playerId)
        {
            if (!Players.Contains(new Player(playerId)))// if id player not exists
                throw new PlayerNotFoundException("Error!The Player Id was not found.");
            Captain.PlayerId= playerId;
            
        }

        public long GetTeamCaptain(long teamId)
        {
            if (!Teams.Equals(teamId))
                throw new TeamNotFoundException("Error! Team Id was not found. ");
            if (!(Teams..PlayerId is null))
                throw new CaptainNotFoundException("Error! Team Id was not found. ");

        }

        public string GetPlayerName(long playerId)
        {
            throw new NotImplementedException();
        }

        public string GetTeamName(long teamId)
        {
            throw new NotImplementedException();
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            throw new NotImplementedException();
        }

        public long GetBestTeamPlayer(long teamId)
        {
            throw new NotImplementedException();
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            throw new NotImplementedException();
        }

        public List<long> GetTeams()
        {
            throw new NotImplementedException();
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            throw new NotImplementedException();
        }

        public decimal GetPlayerSalary(long playerId)
        {
            throw new NotImplementedException();
        }

        public List<long> GetTopPlayers(int top)
        {
            throw new NotImplementedException();
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            throw new NotImplementedException();
        }

    }
}
