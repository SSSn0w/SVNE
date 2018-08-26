package svne.core;

import java.awt.Dimension;
import javax.swing.JFrame;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;

public class WindowFrame extends JFrame {
    public GameCanvas canvas = new GameCanvas();
    public final int FRAME_HEIGHT = 480;
    public final int FRAME_WIDTH = 800;


    public WindowFrame() {
        super("Game");

        JMenuBar menuBar = new JMenuBar();
        JMenu fileMenu = new JMenu("File");
        JMenuItem startMenuItem = new JMenuItem("New");
        menuBar.add(fileMenu);
        fileMenu.add(startMenuItem);

        canvas.setPreferredSize(new Dimension(FRAME_WIDTH, FRAME_HEIGHT));
        
        super.getContentPane().add(canvas);
        super.setLocation(0, 0);
        super.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        //super.setJMenuBar(menuBar);
        super.setResizable(false);
        //super.setUndecorated(true);
        super.pack();
        
        super.setVisible(true);
    }
}
