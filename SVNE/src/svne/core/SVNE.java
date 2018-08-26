package svne.core;

import svne.io.*;

public class SVNE {
    public static WindowFrame frame;  
    
    public static void main(String args[]) {    
        frame = new WindowFrame();
        loadFiles();
        
        gameLoop();
    }

    static void gameLoop() {
        while(true) {
            frame.canvas.repaint();
            
            try {
                Thread.sleep(16);
            } catch (Exception e) {
                 
            }
        }
    }
    
    static void loadFiles() {
        System.out.println(LoadData.Read("test.txt"));
    }
}
