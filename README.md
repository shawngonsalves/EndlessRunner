# JeffMcCluckerson
 The Rampage of Jeff McCluckerson - Endless Runner Style Game
 
 Adding your own tiles:\
 (1) Find a path asset that you would like to use and drag it to the heirarchy window.\
 (2) For this asset, change its position in the inspector to be x:0, y:0, z:0.\
 (3) In the scene view, note how many grid boxes the path tile takes up in the Z direction.  You may need to position the asset again in order to count the gridboxes.\
     **IMPORTANT - the length (in Z direction) of each tile must be exactly the same, but the width can be any size.**\
     -In the Polygon Farm asset pack, there is a dirt path asset.  If we use these as a base for all of our tiles in this level, then    this is a step we do not have to worry about.\
 (4) Create a new Empty Game Object and name it according to what it will do.  Its position MUST be x:0, y:0, z:0.\
 (5) Drag the path tile onto the Empty Game Object.\
 (6) Now you can move the path tile within this Empty Game Object.  Make sure x and y on the path both remain 0 and that the Empty Game Object remains at x:0, y:0, z:0 or else this will not work.\
 (7) Line up each path with Jeff's feet, use the SampleTiles in the Prefab/Tiles folder as a guide.  Each tile MUST be the exact same length for this to work.\
 (8) Any objects/obstacles added to the path MUST be added as a child to the path itself NOT the Empty Game Object. (Refer to SampleTile3 in Prefabs/Tiles folder).\
 (9) When you are finished, drag the Empty Game Object to the Prefab/Tiles folder to save it as a prefab.\
 (10) Click on the TileManager object in the heirarchy view.  Under its script, there should be a dropdown for an array called "Tile Prefabs".  Change its size based on how many prefabs you have created.  Drag and drop each prefab from the Prefabs/Tiles folder onto each element of this array.\
    **IMPORTANT - make sure that there is a tile prefab without any obstacles on it.  Place this tile on "Element 0" in the array.  This way Jeff won't initially spawn into obstacles.**
     
