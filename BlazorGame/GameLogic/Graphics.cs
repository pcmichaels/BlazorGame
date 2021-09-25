using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace BlazorGame.GameLogic
{
    public interface IGraphics
    {     

        int PlayerOffset { get; }

        void CyclePlayer();

        int PlayerDirection { get; }
    }

    public class Graphics : IGraphics
    {
        private readonly IPlayer _player;
        private int _playerOffset = 0;
        private DateTime _lastUpdate = DateTime.MinValue;

        public Graphics(IPlayer player)
        {
            _player = player;
        }

        public int PlayerOffset => _playerOffset;

        public int PlayerDirection =>
            _player switch
            {
                { IsWalkingLeft: true } => -1,
                { IsWalkingRight: true } => 1,
                _ => 0
            };
        
        public void CyclePlayer()
        {
            if (_lastUpdate.AddMilliseconds(100) > DateTime.Now) return;

            if (_playerOffset > -48)
                _playerOffset -= 16;
            else
                _playerOffset = 0;

            _lastUpdate = DateTime.Now;
        }


    }
}
