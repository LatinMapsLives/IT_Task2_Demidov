using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_Demidov_Core.Models;

namespace Task2_Demidov.ViewModels
{
    public partial class ChessBoardViewModel : ObservableObject
    {
        [ObservableProperty]
        private PieceColor _currentTurnColor = PieceColor.White;

        private ChessPiece? _selectedPiece;
        public ObservableCollection<CellViewModel> Cells { get; } = new();

        public ChessBoardViewModel()
        {
            InitializeBoard();
            InitializePieces();
        }

        private void InitializeBoard()
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Cells.Add(new CellViewModel(x, y));
                }
            }
        }

        private void InitializePieces()
        {
            AddPiece(new Rook(PieceColor.White, new Position(0, 0)));
            AddPiece(new Bishop(PieceColor.White, new Position(3, 0)));
            AddPiece(new Queen(PieceColor.White, new Position(7, 0)));
            AddPiece(new Rook(PieceColor.Black, new Position(0, 7)));
            AddPiece(new Bishop(PieceColor.Black, new Position(3, 7)));
            AddPiece(new Queen(PieceColor.Black, new Position(7, 7)));
        }

        private void AddPiece(ChessPiece piece)
        {
            var cell = Cells.First(c => c.X == piece.Position.X && c.Y == piece.Position.Y);
            cell.Piece = piece;

            piece.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(ChessPiece.Position))
                    UpdatePiecePosition(piece);
            };
        }

        private void UpdatePiecePosition(ChessPiece piece)
        {
            var oldCell = Cells.FirstOrDefault(c => c.Piece == piece);
            if (oldCell != null) oldCell.Piece = null;

            var newCell = Cells.First(c => c.X == piece.Position.X && c.Y == piece.Position.Y);
            newCell.Piece = piece;
        }

        [RelayCommand]
        public void SelectCell(CellViewModel cell)
        {
            if (_selectedPiece == null)
            {
                // Выбор фигуры текущего игрока
                if (cell.Piece?.Color == CurrentTurnColor)
                    _selectedPiece = cell.Piece;
            }
            else
            {  
                bool isMoveValid = _selectedPiece.IsMovePossible(new Position(cell.X, cell.Y))
                    && (cell.Piece == null || cell.Piece.Color != _selectedPiece.Color);

                if (isMoveValid)
                {
                    _selectedPiece.MakeMove(new Position(cell.X, cell.Y));
                    CurrentTurnColor = CurrentTurnColor == PieceColor.White
                        ? PieceColor.Black
                        : PieceColor.White;
                }

                _selectedPiece = null;
            }
        }
    }
}
