using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//An interface for methods belonging to all objects that can be dropped by a loot generating object
public interface Droppable
{
    void onDrop();
}
