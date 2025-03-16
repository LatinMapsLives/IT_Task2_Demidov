using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_Demidov_Core.Models;

namespace Task2_Demidov.ViewModels
{
    public partial class CellViewModel : ObservableObject
    {
        [ObservableProperty]
        private ChessPiece? _piece;

        public int X { get; }
        public int Y { get; }

        public CellViewModel(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
