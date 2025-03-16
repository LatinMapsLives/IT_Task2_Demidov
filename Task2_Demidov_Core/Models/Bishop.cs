using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Demidov_Core.Models
{
    public class Bishop : ChessPiece
    {
        public Bishop(PieceColor color, Position position) : base(color, position) { }

        public override string Symbol => Color == PieceColor.White ? "♗" : "♝";

        protected override bool CanMove(Position newPosition)
        {
            return Math.Abs(Position.X - newPosition.X) == Math.Abs(Position.Y - newPosition.Y);
        }
    }

}
