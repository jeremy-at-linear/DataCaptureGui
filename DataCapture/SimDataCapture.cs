using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCapture
{
    public class SimDataCapture
    {
        private WaveformType _waveform = WaveformType.Sine;
        private Func<int, int> _generator = Sine;

        public WaveformType Waveform { 
            get => _waveform;
            set
            {
                _waveform = value;
                switch (_waveform)
                {
                    case WaveformType.Sine:
                        _generator = Sine;
                        break;
                    case WaveformType.Square:
                        _generator = Square;
                        break;
                    case WaveformType.Sawtooth:
                        _generator = Sawtooth;
                        break;
                    case WaveformType.Triangle:
                        _generator = Triangle;
                        break;
                }
            }
        }

        public int NumDataPoints { get; set; }

        public const int Max = 1024;

        public int[] Capture()
        {
            var data = new int[NumDataPoints];
            for (int i = 0; i < NumDataPoints; ++i)
            {
                data[i] = _generator(i);
            }

            return data;
        }

        private static int Sine(int i)
        {
            return (int) Math.Floor(Max * Math.Sin(2.0 * Math.PI / 21.237 * i));
        }

        private static int Square(int i)
        {
            return (i % 40) < 20 ? Max : -Max;
        }

        private static int Sawtooth(int i)
        {
            return (i % 40) * Max / 40;
        }

        private static int Triangle(int i)
        {
            var j = i % 40;
            if (j < 20)
            {
                j -= 10;
            }
            else
            {
                j = 30 - j;
            }

            return j * Max / 10;
        }

    }
}
