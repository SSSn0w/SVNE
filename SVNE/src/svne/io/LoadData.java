package svne.io;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.HashMap;

public class LoadData {
    public HashMap data = new HashMap();
    
    public static ArrayList<String> Read(String filePath) {
        Path file = Paths.get(filePath);
        
        String line = null;
        ArrayList<String> text = new ArrayList();
        
        InputStream input = null;
        
        try {
            input = Files.newInputStream(file);
            BufferedReader reader = new BufferedReader(new InputStreamReader(input));
            while((line = reader.readLine()) != null) {
                text.add(line);
            }  

            input.close();
        }
        catch (Exception e) {
            System.out.println(e);
        }
        
        return text;
    }
    
    public static ArrayList<String> ReadScript(String filePath) {
        return new ArrayList();
    }
    
    public static ArrayList<svne.assets.Character> ReadCharacter(String filePath) {
        return new ArrayList();
    }
    
    public static ArrayList<String> ReadAsset(String filePath) {
        return new ArrayList();
    }
    
    public static ArrayList<String> ReadUser(String filePath) {
        return new ArrayList();
    }
}
