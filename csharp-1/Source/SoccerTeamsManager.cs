using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Exceptions;
using Source;

namespace Codenation.Challenge
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {

        private List<Team> Teams { get; set; } = new List<Team>();
        public List<Player> Players { get; set; } = new List<Player>();

        public SoccerTeamsManager()
        {
        }

        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            CheckTeamInUse(id);
            Teams.Add(new Team(id, name, createDate, mainShirtColor, secondaryShirtColor));
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            ChecPlayerInUse(id);
            CheckTeamExist(teamId);
            Players.Add(new Player(id, teamId, name, birthDate, skillLevel, salary));
        }

        public void SetCaptain(long playerId)
        {
            CheckPlayerExist(playerId);
            
            foreach (Player p in Players)
                    if (p.Id == playerId)
                    {
                        foreach (Team t in Teams)
                        {
                        if (t.Id == p.TeamId)
                        {
                            t.Captain = new Captain(playerId);
                            }
                        }
                    }   
            //Nao consegui fazer com Linq
        }

        public long GetTeamCaptain(long teamId)
        {
            CheckTeamExist(teamId);
            CheckCapitainExist(teamId);
            return Teams.Where(x => x.Id == teamId).Select(x =>x.Captain.PlayerId).SingleOrDefault();
        }

        public string GetPlayerName(long playerId)
        {
            CheckPlayerExist(playerId);
            return Players.Where(x => x.Id == playerId).First().Name;
        }

        public string GetTeamName(long teamId)
        {
            CheckTeamExist(teamId);
            return Teams.Where(x => x.Id == teamId).Select(x => x.Name).FirstOrDefault();
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            CheckTeamExist(teamId);
            return Players.Where(p => p.TeamId == teamId).OrderBy(p => p.Id).Select(p => p.Id).ToList();
        } 
        public long GetBestTeamPlayer(long teamId)
        {
            CheckTeamExist(teamId);
            return Players.Where(x => x.TeamId == teamId).OrderByDescending(x => x.SkillLevel).ThenBy(x => x.Id).Select(x => x.Id).FirstOrDefault();
         }

        public long GetOlderTeamPlayer(long teamId)
        {

            CheckTeamExist(teamId);
            return Players.Where(x => x.TeamId == teamId).
                OrderBy(x => x.BirthDate).ThenBy(x => x.Id).
                Select(x=>x.Id).FirstOrDefault();
        }

        public List<long> GetTeams()
        {
            return Teams.OrderBy(x=>x.Id).Select(x => x.Id).ToList();
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            CheckTeamExist(teamId);
            return Players.Where(x => x.TeamId == teamId).
            OrderByDescending(x => x.Salary).ThenBy(x=>x.Id).
            Select(x => x.Id).FirstOrDefault(); 
         }

        public decimal GetPlayerSalary(long playerId)
        {
            CheckPlayerExist(playerId);
            return Players.Where(x => x.Id == playerId).FirstOrDefault().Salary;
        }

        public List<long> GetTopPlayers(int top)
        {
            return Players.OrderByDescending(x => x.SkillLevel).
                ThenBy(x => x.Id).Select(x=>x.Id).Take(top).ToList(); 
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            CheckTeamExist(teamId);
            CheckTeamExist(visitorTeamId);
            string shirtColor;
            var home = Teams.Where(x => x.Id == teamId).
                Select(x => new { x.CorUniformePrincipal, x.CorUniformeSecundario }).
                FirstOrDefault();
            var visitor = Teams.Where(x => x.Id == visitorTeamId).
                Select(x => new { x.CorUniformePrincipal, x.CorUniformeSecundario }).
                FirstOrDefault();
            if (home.CorUniformePrincipal == visitor.CorUniformePrincipal)
                shirtColor = visitor.CorUniformeSecundario;
            else
                shirtColor = visitor.CorUniformePrincipal;
            return shirtColor;
        }

        //validaçoes
        private void CheckTeamInUse(long id)
        {
            if (Teams.Any(x => x.Id == id))
                throw new UniqueIdentifierException("Error! this Id is in used. ");
        }
        private void ChecPlayerInUse(long id)
        {
            if ((Players.Any(p => p.Id == id)))
                throw new UniqueIdentifierException("Error!The Player Id was not found.");
        }
        private void CheckPlayerExist(long id)
        {
            if (!(Players.Any(p => p.Id == id)))
                throw new PlayerNotFoundException("Error!The Player Id was not found.");
        }
        private void CheckTeamExist(long id)
        {
            if (!(Teams.Any(p => p.Id == id)))
                throw new TeamNotFoundException("Error! Team Id was not found. ");
        }
        private void CheckCapitainExist(long id)
        {
            if (Teams.Where(x => x.Id == id).First().Captain==null)   //Caso o time informado não tenha um capitão, retornar
                throw new CaptainNotFoundException("Error! Captain was not found. ");
        }
    }
   

}
