using System;
using System.Collections.Generic;
using System.Text;

namespace App5.Services
{
    public interface IAudio
    {
        bool PlayMp3File();
        bool StopPlay();
    }
}
