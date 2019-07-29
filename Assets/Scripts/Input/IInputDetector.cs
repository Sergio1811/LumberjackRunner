using System;
using System.Collections.Generic;

public enum InputDirection
{
    Left, Right, Top, Bottom
}

public interface IInputDetector
{
    InputDirection? DetectInputDirection();
}
