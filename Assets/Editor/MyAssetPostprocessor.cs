using  UnityEditor ; 
using  UnityEngine ;

public  class  MyAssetPostprocessor  :  AssetPostprocessor 
{ 
    /// <Summary> 
    /// import of all assets will be called when the end 
    /// </ Summary> 
    /// <param Name = "ImportedAssets"> Imported asset path </ param> 
    /// <param Name = "DeletedAssets"> path of the deleted asset </ param> 
    /// <param Name = "MovedAssets"> path after the movement of the moved asset </ param> 
    /// <param name = "movedFromPath" > path before the movement of the moved asset </ param> 
    private  static  void  OnPostprocessAllAssets ( 
        string []  ImportedAssets ,  
        string []  DeletedAssets ,  
        string []  MovedAssets ,  
        string []  MovedFromPath ) 
    { 
        foreach  ( var  ImportedAsset  in  ImportedAssets ) 
        { 
            if ( IsTmxFile ( ImportedAsset )) 
            { 
                // TMX since the files the extension * .xml to a copy 
                var  NewAsset  =  ImportedAsset . Replace ( ".tmx" ,  ".xml" ); 
                // old XML is deleted 
                AssetDatabase . DeleteAsset ( NewAsset );
                AssetDatabase.CopyAsset(ImportedAsset, NewAsset);
            } 
        } 
    }

    /// TMX file whether examine 
    static  bool  IsTmxFile ( string  str ) 
    { 
        return  str . IndexOf ( ".tmx" )  >  0 ; 
    }

}
