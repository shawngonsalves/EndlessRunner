# JeffMcCluckerson
 The Rampage of Jeff McCluckerson - Endless Runner Style Game
 
 Adding your own tiles:\
 (1) Grab the empty base tile from the folder.  Make a copy of it in the heirarchy window.\
 (2) For this copy, change the parent position in the inspector to be x:0, y:0, z:0.\
 (3) In the scene view, note how many grid boxes the path tile takes up in the Z direction. Our tiles will ALWAYS be 30 units in length!\
     **IMPORTANT - the length (in Z direction) of each tile must be exactly the same, but the width can be any size.**\
     -There is a prefab in the Level1 tiles folder that should be our base tile for everything.  Create a copy of it and add obstacles and environment details to this tile.  DO NOT overwrite the original prefab. There will be a base tile for each level.
 (4) Any objects/obstacles added to the path MUST be added as a child to the path. (Refer to SampleTile3 in Prefabs/Tiles folder).  Make sure to tag any objects that you want Jeff to die on as "Enemy". DO NOT tag the entire path or Empty Game Object, just tag the individual obstacles.\
 (5) When you are finished, drag the prefab to the appropriate Prefab/Tiles folder to save it as a prefab.
    **IMPORTANT - make sure that there is a tile prefab without any obstacles on it.  Place this tile on "Element 0" in the array.  This way Jeff won't initially spawn into obstacles.**\
   \
   A Note on Eggs:\
   (1) When adding an egg to a scene, make sure its y position is set above at least 0.5 so that the float mechanic works correctly.  Use the eggScript prefab.\
   (2) After the egg has been added, copy the collectSound object from SampleTile2 and place it as a child of the empty game object for the tile you're making.\
   (3) Drag the collectSound object onto the empty slot for the EggBounce script.\
   (4) Only ONE collectSound object needs to be on a tile.  Each egg must have this collectSound object added to it.
   
     
