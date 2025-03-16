using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Task2_Demidov_Core.Models
{
    public enum PieceColor { White, Black }

    public abstract class ChessPiece : INotifyPropertyChanged
    {
        private Position _position;

        public PieceColor Color { get; }
        public abstract string Symbol { get; }

        public Position Position
        {
            get => _position;
            set
            {
                _position = value;
                OnPropertyChanged(nameof(Position));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected ChessPiece(PieceColor color, Position position)
        {
            Color = color;
            _position = position;
        }

        public void MakeMove(Position newPosition)
        {
            if (CanMove(newPosition))
                Position = newPosition;
        }

        public bool IsMovePossible(Position newPosition) // Публичный метод
        {
            return CanMove(newPosition);
        }


        protected abstract bool CanMove(Position newPosition);

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
