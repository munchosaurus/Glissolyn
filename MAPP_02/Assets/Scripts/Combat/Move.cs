using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    // Start is called before the first frame update
    public MoveBase Base {
        get;
        set;
    }

    public int PP {
        get;
        set;
    }

    public Move(MoveBase _base) {
        Base = _base;
        PP = _base.GetPP();
    }
}
