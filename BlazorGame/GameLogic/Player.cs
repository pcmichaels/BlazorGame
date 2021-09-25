using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGame.GameLogic
{
    public interface IPlayer
    {
        public int Top { get; }
        public int Left { get; }
        public bool IsJumping { get; }

        public bool IsWalking { get; }

        void WalkRight();
        void WalkLeft();
        void Jump();
        void Stop();        
        void Update();
    }

    public class Player : IPlayer
    {
        private int _top = WorldSettings.FLOOR;
        private int _left = 0;
        private int _forceUp = 0;
        private int _forceRight = 0;        

        public int Top { get => _top; }
        public int Left { get => _left; }
        public bool IsJumping => _forceUp > 0;
        public bool IsWalking => _forceRight != 0;

        public void Jump()
        {
            if (_forceUp == 0)
            {
                _forceUp += WorldSettings.JUMP_FORCE;
            }

        }

        public void WalkRight() => _forceRight = WorldSettings.SPEED;
        public void WalkLeft() => _forceRight = -WorldSettings.SPEED;

        public void Stop() => _forceRight = 0;

        public void Update()
        {
            _forceUp -= WorldSettings.GRAVITY;

            _top -= _forceUp;

            if (_top > WorldSettings.FLOOR)
            {
                _top = WorldSettings.FLOOR;
                _forceUp = 0;
            }

            if (_left <= 0 && _forceRight < 0) _forceRight = 0;

            _left += _forceRight;
            
        }
    }
}
