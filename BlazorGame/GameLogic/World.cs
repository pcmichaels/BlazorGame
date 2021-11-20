using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGame.GameLogic
{
    public interface IWorld
    {
        void ApplyPhysics();
    }

    public class World : IWorld
    {
        private readonly IPlayer _player;

        public World(IPlayer player)
        {
            _player = player;
        }

        public void ApplyPhysics()
        {            
            _player.Update();

        }
            

    }

}
