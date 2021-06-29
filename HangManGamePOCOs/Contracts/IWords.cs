using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManGamePOCOs.Contracts
{
    public interface IWords
    {
        string Word { get; set; }
        string Clue { get; set; }
    }
}
