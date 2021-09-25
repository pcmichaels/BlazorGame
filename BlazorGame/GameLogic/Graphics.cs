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
    }

    public class Graphics : IGraphics
    {
        private int _playerOffset = 0;
        private DateTime _lastUpdate = DateTime.MinValue;

        public int PlayerOffset => _playerOffset;

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
